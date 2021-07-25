using System.Collections.Generic;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Interfaces.Repository.Inventario;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Inventario;
using System.Linq;
using Folha.Domain.ViewModels.Report;
using Folha.Domain.Enuns.Documentos;
using Folha.Domain.ViewModels.Sistema;

namespace Folha.Driver.Application.Inventario
{
    public class ArtigoStockApp : IArtigoStockApp
    {
        private readonly IArtigoStockRepository _artigoRepository;
        private readonly IArtigosApp _artigoApp;
        public ArtigoStockApp(IArtigoStockRepository repository, IArtigosApp artigoApp)
        {
            _artigoRepository = repository;
            _artigoApp = artigoApp;
        }
        public void Delete(ProdutoStockViewModel artigo)
        {
            _artigoRepository.Delete(artigo);
        }
        public ProdutoStockViewModel GetArtigoQtdTotal(int codArtigo)
        {
            var artigosInventario = _artigoRepository.GetTodosPorCodArtigo(codArtigo);
            var qtdTotal = 0.0m;
            foreach (var artigoInvetario in artigosInventario)
            {
                qtdTotal += artigoInvetario.qtde;
            }
            var artigoQtdTotal = artigosInventario.FirstOrDefault();
            artigoQtdTotal.qtde = qtdTotal;

            return artigoQtdTotal;
        }
        public bool PodeMudarQtdArtigoComposicao(ProdutoStockViewModel artigoStock, OperacoesViewModel operacao)
        {
            if (UtilidadesGenericas.PermitirVenderSemStock)
            {
                return true;
            }
            var PodeMudar = true;
            var composicoes = _artigoApp.GetComposicao(artigoStock.Artigo.Codigo);
            if (UtilidadesGenericas.InEnumMov(operacao.MovFin) == TipoMov.CREDITO)
            {
                foreach (var item in composicoes)
                {
                    var _artigoStock = GetArtigoQtdTotal(item.CodArtigoComponente);
                    var aumentarQtde = item.Qtde * artigoStock.qtde;
                    if (UtilidadesGenericas.ValidarEmCredito(_artigoStock.stockMax, aumentarQtde, " Artigo Composição "))
                    {
                        PodeMudar = false;
                        break;
                    }
                }
            }
            else if (UtilidadesGenericas.InEnumMov(operacao.MovFin) == TipoMov.DEBITO)
            {
                foreach (var item in composicoes)
                {
                    var _artigoStock = GetArtigoQtdTotal(item.CodArtigoComponente);
                    var diminuirQtd = item.Qtde * artigoStock.qtde;
                    if (UtilidadesGenericas.ValidarEmDebito(_artigoStock.qtde - _artigoStock.stockMin, diminuirQtd, " Artigo Composição "))
                    {
                        PodeMudar = false;
                        break;
                    }
                }
            }
            return PodeMudar;
        }

        public void IncrementarQtdComposicao(int codArtigo, decimal qtdIncrementar)
        {
            var artigosInventarios = _artigoRepository.GetTodosPorCodArtigo(codArtigo);
            //for (int i = artigosInventarios.Count - 1;  qtdIncrementar / artigosInventarios.Count < 1; i--)
            //{
            //    artigosInventarios.RemoveAt(i);
            //    if (UtilidadesGenericas.ListaNula(artigosInventarios))
            //    {
            //        break;
            //    }
            //}
            var artigosInventario = artigosInventarios.FirstOrDefault();
            artigosInventario.qtde += qtdIncrementar;
            Update(artigosInventario);
            //foreach (var item in artigosInventarios)
            //{
            //    item.qtde += qtdIncrementar;
            //    Update(item);
            //}
        }
        public void DecrementarQtdComposicao(int codArtigo, decimal qtdDecrementar)
        {
            var artigosInventarios = _artigoRepository.GetTodosPorCodArtigo(codArtigo);
            for (int i = artigosInventarios.Count - 1; qtdDecrementar > 0; i--)
            {
                var resultDecremento = artigosInventarios[i].qtde - qtdDecrementar;
                if (resultDecremento == 0)
                {
                    artigosInventarios[i].qtde = 0;
                    qtdDecrementar = 0;
                    Update(artigosInventarios[i]);
                }
                else if (resultDecremento > 0)
                {
                    artigosInventarios[i].qtde = resultDecremento;
                    qtdDecrementar = 0;
                    Update(artigosInventarios[i]);
                }
                else if(resultDecremento < 0)
                {
                    if (UtilidadesGenericas.PermitirVenderSemStock)
                    {
                        artigosInventarios[i].qtde = resultDecremento;
                        qtdDecrementar = 0;
                        Update(artigosInventarios[i]);
                    }
                    else
                    {
                        artigosInventarios[i].qtde = 0;
                        qtdDecrementar = -1 * resultDecremento;
                        Update(artigosInventarios[i]);
                    }
                }
                artigosInventarios.RemoveAt(i);
                if (UtilidadesGenericas.ListaNula(artigosInventarios))
                {
                    break;
                }
            }
        }
        public void MudarQtdComposicao(MovProdutosViewModel movArtigo)
        {
            var composicoes = _artigoApp.GetComposicao(movArtigo.Artigo.Codigo);
            if (UtilidadesGenericas.InEnumMov(movArtigo.Documento.Operacao.MovStk) == TipoMov.CREDITO)
            {
                foreach (var item in composicoes)
                {
                    //var artigoStock = GetById(item.CodArtigoComponente);
                    //artigoStock.qtde += item.Qtde * movArtigo.Qtdade;
                    //Update(artigoStock);
                    IncrementarQtdComposicao(item.CodArtigoComponente, item.Qtde * movArtigo.Qtdade);
                }
            }
            else if (UtilidadesGenericas.InEnumMov(movArtigo.Documento.Operacao.MovStk) == TipoMov.DEBITO)
            {
                foreach (var item in composicoes)
                {
                    //var artigoStock = GetById(item.CodArtigoComponente);
                    //artigoStock.qtde -= item.Qtde * movArtigo.Qtdade;
                    //Update(artigoStock);
                    DecrementarQtdComposicao(item.CodArtigoComponente, item.Qtde * movArtigo.Qtdade);
                }
            }
        }
        public List<ProdutoStockViewModel> GetAll()
        {
            return ((List<ProdutoStockViewModel>)_artigoRepository.GetAll( new ProdutoStockViewModel() { })).Where(a => a.Artigo.status == 1).ToList();
        }
        public List<ProdutoStockViewModel> GetTodos()
        {
            return ((List<ProdutoStockViewModel>)_artigoRepository.GetAll(new ProdutoStockViewModel() { }));
        }

        public List<ArtigoViewModel> GetArtigos()
        {
            return Mapper<ProdutoStockViewModel, ArtigoViewModel>.Map(GetAll());
        }
        public List<CardArtigoViewModel> GetArtigoCards()
        {
            return Mapper<ProdutoStockViewModel, CardArtigoViewModel>.Map(GetAll());
        }

        public ProdutoStockViewModel GetById(int id)
        {
            return (ProdutoStockViewModel)_artigoRepository.Get(new ProdutoStockViewModel() { codigo = id });
        }

      
        public int GetCodLastEntity()
        {
            return (int)_artigoRepository.GetCodLast();
        }

        public void Insert(ProdutoStockViewModel artigo)
        {
            _artigoRepository.Insert(artigo);
        }

        public void Update(ProdutoStockViewModel artigo)
        {
            _artigoRepository.Update(artigo);
        }

        public List<ArtigoViewModel> GetTodosArtigos()
        {
            return Mapper<ProdutoStockViewModel, ArtigoViewModel>.Map(GetTodos());
        }

        public IEnumerable<RelListagemArtigosViewModel> StoquePorProdutos(int CodArmazem)
        {
            return _artigoRepository.StoquePorProdutos(CodArmazem);
        }

        public IEnumerable<RelListagemArtigosViewModel> RupturaStock(string CodArmazem)
        {
            return _artigoRepository.RupturaStock(CodArmazem);
        }

        public IEnumerable<RelListagemArtigosViewModel> ApoioContagem(int CodArmazem)
        {
            return _artigoRepository.ApoioContagem(CodArmazem);
        }
    }
}
