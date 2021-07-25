using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using Folha.Domain.Enuns.Documentos;
using Folha.Domain.Interfaces.Application.Inteligente;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Presentation.Desktop.Forms.Financeiro;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Separadores.Principal;

namespace Folha.Presentation.Desktop.Forms.Documentos
{
    public partial class frmDevolverArtigos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IDocumentosApp _documentosApp;
        private readonly IMovArtigosApp _movArtigosApp;
        private readonly IArtigoStockApp _stockApp;
        private readonly IInteligenteApp _inteligenteApp;
        private readonly ITurnosApp _turnoApp;
        private readonly IPagamentosApp _pagamentosApp;
        private DocumentosViewModel Documento { get; set; }
        private bool Devolvido { get;  set; }
        private List<VendaViewModel> ArtigosDevolver { get; set; } = new List<VendaViewModel>();
        private List<VendaViewModel> ArtigosNaoDevolver { get; set; } = new List<VendaViewModel>();
        public int IndiceArtigo { get; private set; }
        private frmTelaDocumento FormDocumento { get; set; }

        public frmDevolverArtigos(IDocumentosApp documentosApp,
                                  IMovArtigosApp movArtigosApp, 
                                  IArtigoStockApp stockApp,
                                  IInteligenteApp inteligenteApp,
                                  ITurnosApp turnoApp,
                                  IPagamentosApp pagamentosApp)
            {
            InitializeComponent();
            _documentosApp = documentosApp;
            _movArtigosApp = movArtigosApp;
            _stockApp = stockApp;
            _inteligenteApp = inteligenteApp;
            _turnoApp = turnoApp;
            _pagamentosApp = pagamentosApp;
        }



        private void carregarArtigosSemPagamentos()
        {
            carregarArtigoVenderByIdDocumento();
            //setIndexArtidoVender();
        }

        private void carregarArtigoVenderByIdDocumento()
        {
            if (!ExisteDocumento()) return;
            List<MovProdutosViewModel> movArtigos = _movArtigosApp.GetAllByIdDocumento(Documento.codigo);

            ArtigosDevolver = new List<VendaViewModel>();
            foreach (var item in movArtigos)
            {
                var isencao = _movArtigosApp.GetMotivoDeIsencao(item);
                ArtigosDevolver.Add(new VendaViewModel()
                {
                    MovArtigo = item,
                    Artigo = item.ArtigoStock,
                    CodProduto = item.CodProduto,
                    codigo = item.codigo,
                    Entidade = Documento.Entidade,
                    NomeCliente = Documento.NomeCliente,
                    qtde = item.Qtdade,
                    Referencia = Equals(isencao, null) ? "--" : isencao.Referencia
                });
                //DescontoGeral = item.DescontoGeral;
            }
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate {
                    gradeArtigoDevolver.DataSource = ArtigosDevolver;
                    labelConsumidor.Text = "Cliente: " + Documento.NomeCliente;
                    labelTotal.Text = "Total: " + GetTotalPrecoArtigosDevolver().ToString("N3") + "AKZ";
                }));
            }
            else
            {
                gradeArtigoDevolver.DataSource = ArtigosDevolver;
                labelConsumidor.Text = "Cliente: " + Documento.NomeCliente;
                labelTotal.Text = "Total: " + GetTotalPrecoArtigosDevolver().ToString("N3");
            }
        }

        private decimal GetTotalPrecoArtigosDevolver()
        {
            var total = 0.0m;
            foreach (var item in ArtigosDevolver)
            {
                total += item.Total;
            }

            return total;
        }
        private decimal GetTotalPrecoArtigosNaoDevolver()
        {
            var total = 0.0m;
            foreach (var item in ArtigosNaoDevolver)
            {
                total += item.Total;
            }

            return total;
        }
        private void AddArtigoNoDocNC(DocumentosViewModel docNotaCredito)
        {
            if (!UtilidadesGenericas.ListaNula(ArtigosDevolver))
            {
                var nomeMetodo = string.Empty;
                if (UtilidadesGenericas.ListaNula(ArtigosNaoDevolver))
                {
                    nomeMetodo = "Insert";
                    docNotaCredito.Descritivo = "ANULAÇÃO REFERENTE À " + 
                        Documento.Operacao.APP + " " + DateTime.Now.Year + "/" + Documento.NumeroOrdem;
                }
                else
                {
                    nomeMetodo = "Update";
                    docNotaCredito.Descritivo = "RECTIFICAÇÃO REFERENTE À " +
                        Documento.Operacao.APP + " " + DateTime.Now.Year + "/" + Documento.NumeroOrdem;
                    Documento.Total -= docNotaCredito.Total;
                    _documentosApp.Update(Documento); 
                }
                _documentosApp.Update(docNotaCredito);
                foreach (var item in ArtigosDevolver)
                {
                    item.MovArtigo.CodDocumento = docNotaCredito.codigo;
                    item.MovArtigo.ArtigoAbstrato = string.Empty;
                    _movArtigosApp.GetType().GetMethod(nomeMetodo).Invoke(_movArtigosApp, new object[] { item.MovArtigo});
                }
            }
        }
        private bool ExisteDocumento()
        {
            var DocumentoNulo = !Equals(Documento, null);
            var NaoTemCodigo = Documento.codigo > 0;
            return DocumentoNulo && NaoTemCodigo;
        }

        public bool DevolverArtigoDoDocumento(int codDocumento)
        {
            Documento = _documentosApp.GetById(codDocumento);
            ShowDialog();

            return Devolvido;
        }
        public bool DevolverArtigoDoDocumento(int codDocumento, frmTelaDocumento formDocumento)
        {
            FormDocumento = formDocumento;
            Documento = _documentosApp.GetById(codDocumento);
            ShowDialog();

            return Devolvido;
        }

        private void frmDevolverArtigos_Load(object sender, EventArgs e)
        {
            carregarArtigosSemPagamentos();
        }

        private void btnEliminarArtigo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!UtilidadesGenericas.ListaNula(ArtigosDevolver))
            {
                var artigoDevolverSelecionado = GetArtigoDevolverSelecionado();
                ArtigosNaoDevolver.Add(artigoDevolverSelecionado);
                ArtigosDevolver.RemoveAt(IndiceArtigo);
                gradeArtigoDevolver.DataSource = null;
                gradeArtigoDevolver.DataSource = ArtigosDevolver;
                labelTotal.Text = "Total: " + GetTotalPrecoArtigosDevolver().ToString("N3");
            }
            else
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO", 
                    "Não é possível eliminar este artigos!",
                    MessageBoxIcon.Warning, 
                    MessageBoxButtons.OK
                );
            }
        }

        private VendaViewModel GetArtigoDevolverSelecionado()
        {
            var codArtigoDevolver = Convert.ToInt16(gridViewDevolver.GetRowCellValue(IndiceArtigo, "codigo"));

            var artigoDevolverSelecionado = ArtigosDevolver.Where(a => a.codigo == codArtigoDevolver).FirstOrDefault();

            return artigoDevolverSelecionado;
        }

        private void gridViewDevolver_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            IndiceArtigo = e.RowHandle;
        }

        private void btnDevolver_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (UtilidadesGenericas.ListaNula(ArtigosDevolver))
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO",
                    "Não é possível devolver Artigos!",
                    MessageBoxIcon.Warning,
                    MessageBoxButtons.OK
                );
            }
            else
            {
                if (UtilidadesGenericas.ListaNula(ArtigosNaoDevolver) || UtilidadesGenericas.ListaNula(ArtigosDevolver))
                {

                    string movito = new frmMotivoAnularDocumento().GetDescricaoDoMotivo();
                    if (string.IsNullOrEmpty(movito))
                    {
                        return;
                    }
                    devolverQtdArtigosEmStock();
                    AnularDocumentoCurrent(movito);
                    //UtilidadesGenericas.MsgShow(Documento.Operacao.Nome + " Cancelada com sucesso!");
                }
                else
                {
                    devolverQtdArtigosEmStock();
                }

                var docNC = _documentosApp.CriarNovoDocumento("NC", GetTotalPrecoArtigosDevolver(), Documento.CodEntidade);
                docNC.NomeCliente = Documento.NomeCliente;
                var docPagamento =new DocumentoPagamentoViewModel()
                {
                    DescricaoDocumento = "ANULAÇÃO-FT " + DateTime.Now.Year + "/" + Documento.NumeroOrdem,
                    CodRecibo = docNC.codigo
                };
                _inteligenteApp.InsertDoc(docPagamento);

                if (IOC.InjectForm<frmReceberPagamentos>().ReceberPagmentoDocumento(docNC, 0.00m))
                {
                    AddArtigoNoDocNC(docNC);
                    docNC.Estado = "FECHADO";
                    docNC = _documentosApp.SetHashDocumento(docNC);
                    Devolvido = true;
                    //IOC.InjectForm<frmImprimirReport>().ImprimirNotaCredito(ArtigosDevolver, _pagamentosApp.GetAllByDoc(docNC.codigo, "DEBITO"));
                    IOC.InjectForm<frmImprimirReport>().ImprimirDocumentoVenda(_movArtigosApp.GetMovVendaByIdDocumento(docNC.codigo));
                    Close();
                }
                else
                {
                    _inteligenteApp.DeleteDoc(docPagamento);
                    _documentosApp.Delete(docNC);
                }
            }

        }
        private void SetHashDocumento(DocumentosViewModel documento)
        {
            if (documento.Operacao.APP != "PP" && documento.Operacao.APP != "ADM")
            {
                var codAGT = documento.Operacao.APP + " " + DateTime.Now.Year + "/" + documento.NumeroOrdem;
                documento.Hash = UtilidadesGenericas.GerarHash(
                    UtilidadesGenericas.GetDadosHash(documento.Data, documento.Hora, codAGT, documento.Total));
                var lengthHash = documento.Hash.Length;
            }
            _documentosApp.Update(documento);
        }
        private void devolverQtdArtigosEmStock()
        {
            if (UtilidadesGenericas.InEnumMov(Documento.Operacao.MovStk) == TipoMov.DEBITO)
            {
                foreach (var item in ArtigosDevolver) {
                    acertarEntradaArtigoStock(item.Artigo, item.qtde);
                    FormDocumento.DevolverComposicoes(item.MovArtigo, item.qtde);
                }
            }
        }
        private void acertarEntradaArtigoStock(ProdutoStockViewModel artigoStock, decimal qtdEntrar)
        {
            if (Equals(artigoStock, null))
            {
                return;
            }
            int stockId = artigoStock.codigo;
            artigoStock = null;
            artigoStock = _stockApp.GetById(stockId);
            if (!Equals(artigoStock, null))
            {
                artigoStock.qtde += qtdEntrar;
                _stockApp.Update(artigoStock);
            }
        }

        private void AnularDocumentoCurrent(string motivo)
        {
            _documentosApp.AnularDocumento(Documento.codigo, UtilidadesGenericas.UsuarioCodigo, motivo);
            var codDocumento = Documento.codigo;
            Documento = null;
            Documento = _documentosApp.GetById(codDocumento);
            UtilidadesGenericas.Alterou = true;
            //esvaziarElements();
        }
    }
}