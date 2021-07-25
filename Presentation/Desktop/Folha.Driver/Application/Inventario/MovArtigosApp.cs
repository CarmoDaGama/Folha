using Folha.Domain.Interfaces.Application.Inventario;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Frame.Inventario;
using Folha.Domain.Interfaces.Repository.Inventario;
using Folha.Domain.ViewModels.Sistema;
using Folha.Domain.Helpers;

namespace Folha.Driver.Application.Inventario
{
    using System;
    using Folha.Domain.ViewModels.Inventario;
    using Folha.Domain.ViewModels.Frame.Documentos;
    using Folha.Domain.Interfaces.Repository.Sistema;
    using System.Linq;
    using Folha.Domain.ViewModels.Documentos;
    using Folha.Domain.Models.Inventario;
    using Folha.Domain.Interfaces.Repository.Inventario;
    using Folha.Domain.ViewModels.Hospitalar;
    using Folha.Domain.Interfaces.Application.Hospitalar;

    public class MovArtigosApp : IMovArtigosApp
    {
        private readonly IMovArtigoRepository _MovArtigoRepository;
        private readonly IMotivoIsencaoRepository _motivoIsencaoRepository;
        private readonly IUsuariosRepository _usuarioRepository;
        private readonly IAtendimentoHospitalarApp _AtendimentoHospitalarApp;
        public MovArtigosApp(IMovArtigoRepository MovArtigoRepository,
            IMotivoIsencaoRepository motivoIsencaoRepository,
            IUsuariosRepository usuarioRepository,
            IAtendimentoHospitalarApp atendimentoHospitalarApp)
        {
            _MovArtigoRepository = MovArtigoRepository;
            _usuarioRepository = usuarioRepository;
            _motivoIsencaoRepository = motivoIsencaoRepository;
            _AtendimentoHospitalarApp = atendimentoHospitalarApp;
        }
         
        public void Delete(MovProdutosViewModel artigo)
        {
            _MovArtigoRepository.Delete(artigo);
        }

        
        public MotivoIsencao GetMotivoDeIsencao(MovProdutosViewModel movArtigo)
        {
            var motivo = new MotivoIsencao();
            if (Equals(movArtigo, null))
            {
                return motivo;
            }
            if ((movArtigo.CodProduto > 0 || movArtigo.CodStock > 0) && (!Equals(movArtigo.Artigo, null) || !Equals(movArtigo.ArtigoStock, null)))
            {
                motivo = _motivoIsencaoRepository.GetMotivoPorDescricao(movArtigo.ArtigoStock.Artigo.MotivoIsencao);
                if (!string.IsNullOrEmpty(movArtigo.Artigo.MotivoIsencao))
                {
                    movArtigo.DescricaoImposto = movArtigo.Artigo.MotivoIsencao;
                    Update(movArtigo);
                }
            }
            else if (!string.IsNullOrEmpty(movArtigo.ArtigoAbstrato))
            {

                var thisItem = new ItemViewModel(movArtigo.ArtigoAbstrato);
                if (!Equals(thisItem, null) && thisItem.Id > 0)
                {
                    motivo = _AtendimentoHospitalarApp.GetMotivoIsencao(thisItem.Tipo, thisItem.Id);
                    if (!Equals(motivo, null))
                    {
                        movArtigo.DescricaoImposto = motivo.Descricao;
                        Update(movArtigo);
                    }
                }
            }
            return motivo;
        }

        public List<MovProdutosViewModel> GetAll()
        {
            return (List<MovProdutosViewModel>)_MovArtigoRepository.GetAll(new MovProdutosViewModel());
        }

        public List<MovProdutosViewModel> GetAllByIdDocumento(int documentoId)
        {
            return _MovArtigoRepository.GetAllByIdDocumento(documentoId);
        }

        public MovProdutosViewModel GetById(int id)
        {
            return (MovProdutosViewModel)_MovArtigoRepository.Get(new MovProdutosViewModel() { codigo = id });
        }

        public int GetCodLast()
        {
            return (int)_MovArtigoRepository.GetCodLast();
        }

        public List<DocumentoViewModel> GetDocumetosPorDescricao(int codAtendimento)
        {
            //var movs =  _MovArtigoRepository.GetDocumentosPor(codAtendimento);
            //var documentos = new List<DocumentoViewModel>();
            /**foreach (var item in movs)
            //{
            //    if (!UtilidadesGenericas.ListaNula(documentos))
            //    {
            //        var documento = documentos.Where(d => d.Codigo == item.CodDocumento).FirstOrDefault();
            //        if (!Equals(documento, null))
            //        {
            //            documento.NomeItem += "&" + getNomeLimpo(item.Descricao);
            //            continue;
            //        }
            //    }
            //    var usuario = ((UsuariosViewModel)_usuarioRepository.Get(new UsuariosViewModel() { codigo = item.Documento.CodUsuario }));
            //    documentos.Add(new DocumentoViewModel()
            //    {
            //        Codigo = item.Documento.codigo,
            //        Documento = item.Documento.Operacao.Nome,
            //        Area = "Hospitalar",
            //        Data = item.Documento.Data,
            //        Descritivo = item.Documento.Descritivo,
            //        Entidade = item.Documento.Entidade.Nome,
            //        Estado = item.Documento.Estado,
            //        Hora = item.Documento.Hora,
            //        MovFinanceiro = item.Documento.Operacao.MovFin,
            //        MovInventario = item.Documento.Operacao.MovStk,
            //        Total = (float)item.Documento.Total,
            //        Usuario = usuario.Nome,
            //        NomeItem = getNomeLimpo(item.Descricao),
            //        Numero = item.Documento.NumeroOrdem.ToString()
            //    });
            //}*/

            return _MovArtigoRepository.GetDocumentosPor(codAtendimento); 
        }

        public List<MovProdutosViewModel> GetMovimemtosPorDescricao(int codAtendimento)
        {
            return _MovArtigoRepository.GetMovsPorDescricao(codAtendimento);
        }
        private string getNomeLimpo(string descricao)
        {
            var spNome = descricao.Split('?');
            return !Equals(spNome, null) && spNome.Length > 1 ? spNome[0].Trim() : "Desconhecido";
        }

        public void Insert(MovProdutosViewModel artigo)
        {
            _MovArtigoRepository.Insert(artigo);
        }

        public void InsertOld(MovProdutosViewModel movProdutosViewModel)
        {
            _MovArtigoRepository.InsertOld(movProdutosViewModel);
        }

        public List<MovArtigoViewModel> ListarMovArtigo(string ComissionarioID, string armazemID, string CodTurno)
        {
            return _MovArtigoRepository.ListarMovArtigo(ComissionarioID, armazemID, CodTurno);
        }
        public List<MovArtigoViewModel> ListarMovArtigo(int CodDocumento)
        {
            return _MovArtigoRepository.ListarMovArtigo(CodDocumento);
        }

        public IEnumerable<LerProdutosViewModel> ListarProdutos_RP(string criterios, string dtInicial, string dtFinal)
        {
            return _MovArtigoRepository.ListarProdutos_RP(criterios,dtInicial,dtFinal);
        }

        public void Update(MovProdutosViewModel artigo)
        {
            _MovArtigoRepository.Update(artigo);
        }

        public void UpdateOld(MovProdutosViewModel movProdutosViewModel)
        {
            _MovArtigoRepository.UpdateOld(movProdutosViewModel);
        }

        public MovProdutosViewModel GetMovProduto(int codItem, int codAtendimento, string descricao)
        {
            return _MovArtigoRepository.GetMovProduto(codItem, codAtendimento, descricao);
        }

        public List<DocumentoViewModel> GetDocumentosPor(int codAtendimento)
        {
            return _MovArtigoRepository.GetDocumentosPor(codAtendimento);
        }

        public List<VendaViewModel> GetMovVendaByIdDocumento(int documentoId)
        {
            return _MovArtigoRepository.GetMovVendaByIdDocumento(documentoId);
        }

        public List<DocumentoViewModel> GetDocumentosPor(int codAtendimento, int codItem)
        {
            return _MovArtigoRepository.GetDocumentosPor(codAtendimento, codItem);
        }
    }
}
