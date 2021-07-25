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
using DevExpress.XtraEditors;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.ViewModels.Hospitalar;
using DevExpress.XtraGrid.Views.Grid;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Inventario;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Financeiro;
using Folha.Domain.Models.Hospitalar;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Domain.Enuns.Entidades;
using Folha.Domain.ViewModels.Frame.Documentos;
using Folha.Presentation.Desktop.Forms.Geral;
using Folha.Presentation.Desktop.Separadores.Principal;
using Folha.Domain.Enuns.Documentos;
using Folha.Presentation.Desktop.Forms.Documentos;
using DevExpress.XtraGrid.Views.Base;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public enum TipoItem
    {
        SemDocumento, ComDocumento
    }
    public partial class frmFacturacaoHospitalar : XtraForm
    {
        private TipoItem Tipo { get; set; }
        private int CodAtendimento { get;  set; }
        private bool Facturado { get;  set; }
        private readonly IAtendimentoHospitalarApp _AtendimentoHospitalarApp;
        private readonly IExamesHospitalarApp _ExamesApp;
        private readonly IConsultaHospitalarApp _ConsultaHospitalarApp;
        private readonly IMovArtigosApp _MovArtigosApp;
        private readonly IDocumentosApp _DocumentosApp;
        private readonly IEntidadesApp _EntidadeApp;
        private readonly IInternamentoApp _InternamentoApp;
        private DocumentosViewModel Documento { get; set; } = null;
        private EntidadesViewModel Consumidor { get; set; }
        private List<ItemAtendimentoFacturaViewModel> ItensPorFactur { get; set; }
        private List<ItemAtendimentoFacturaViewModel> BackItensFactura { get; set; }
        private List<ItemAtendimentoFacturaViewModel> ItensComDoc { get; set; }
        public int OperacaoId { get; private set; }
        public string SubMascara { get; private set; }
        public string DescricaoDocumento { get; private set; }
        private List<DocumentoViewModel> ListaDocumentos { get;  set; }
        private int IndexDocumento { get;  set; }
        public bool EstadoRecepcao { get; private set; }

        public frmFacturacaoHospitalar(
            IAtendimentoHospitalarApp atendimentoHospitalarApp,
            IExamesHospitalarApp exameApp,
            IConsultaHospitalarApp consultaApp,
            IMovArtigosApp movArtigoApp,
            IDocumentosApp documentoApp,
            IEntidadesApp entidadeApp,
            IInternamentoApp internamentoApp
            )
        {
            InitializeComponent();
            _AtendimentoHospitalarApp = atendimentoHospitalarApp;
            _ExamesApp = exameApp;
            _ConsultaHospitalarApp = consultaApp;
            _MovArtigosApp = movArtigoApp;
            _DocumentosApp = documentoApp;
            _EntidadeApp = entidadeApp;
            _InternamentoApp = internamentoApp;
            Consumidor = _EntidadeApp.GetById(1);
        }
        private void verificarAtendimento()
        {

            if (CodAtendimento > 0)
            {
                EstadoRecepcao = _AtendimentoHospitalarApp.GetEstadoAtendimento(CodAtendimento);
                if (EstadoRecepcao)
                {
                    btnFactura.Enabled = true;
                    btnFacturaRecibo.Enabled = true;
                    btnItensComDoc.Visible = true;
                }
                else
                {
                    btnFactura.Enabled = false;
                    btnFacturaRecibo.Enabled = false;
                    btnItensComDoc.Visible = false;
                }
            }
        }
        private void frmFacturacaoHospitalar_Load(object sender, EventArgs e)
        {
            verificarAtendimento();
            carregarListaItensFactura();
            popularControles();
            CarregarDocumentosAtendimento(null);
            Tipo = TipoItem.SemDocumento;
            if(SemDocPorFacturar())
            {
                btnFacturaRecibo.Enabled = false;
                btnFactura.Enabled = false;
            }
            else
            {
                btnFacturaRecibo.Enabled = true;
                btnFactura.Enabled = true;
            }
        }

        private void popularControles()
        {
            //txtCliente.Text = Consumidor.Nome;
            //txtCodCliente.Text = Consumidor.Codigo.ToString();
        }

        public frmFacturacaoHospitalar FacturarDocumento(int codAtendimento)
        {
            CodAtendimento = codAtendimento;
            return this;
        }
        private void gridItens_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            CarregarDocumentosAtendimento(BackItensFactura[e.RowHandle]);
            if (BackItensFactura[e.RowHandle].Facturar)
            {
                btnFactura.Enabled = false;
                btnFacturaRecibo.Enabled = false;
                //var celula = gridItens.GetDataRow(e.RowHandle)[""];
                //gridItens.UnselectCell((GridCell)e.CellValue);
                gridItens.UnselectRow(e.RowHandle);
            }
            else
            {
                btnFactura.Enabled = true;
                btnFacturaRecibo.Enabled = true;
            }
        }
        private void gridItens_RowClick(object sender, RowClickEventArgs e)
        {
            CarregarDocumentosAtendimento(BackItensFactura[e.RowHandle]);
            //actualizarOsFacturados();
            //var indexsSele = gridItens.GetSelectedRows();
            //foreach (var index in indexsSele)
            //{
            //    if (BackItensFactura[index].Facturar)
            //    {
            //        btnFactura.Enabled = false;
            //        btnFacturaRecibo.Enabled = false;
            //        gridItens.UnselectRow(index);
            //    }
            //    else
            //    {
            //        btnFactura.Enabled = true;
            //        btnFacturaRecibo.Enabled = true;
            //    }
            //}
            if (BackItensFactura[e.RowHandle].Facturar)
            {
                btnFactura.Enabled = false;
                btnFacturaRecibo.Enabled = false;
                gridItens.UnselectRow(e.RowHandle);
            }
            else
            {
                btnFactura.Enabled = true;
                btnFacturaRecibo.Enabled = true;
            }
        }

        private void verificarFacturar(int rowHandle)
        {
            if (rowHandle > ItensPorFactur.Count || rowHandle < 0)
            {
                btnFactura.Enabled = false;
                btnFacturaRecibo.Enabled = false;
                return;
            }
            if (BackItensFactura[rowHandle].Facturar)
            {
                
                btnFactura.Enabled = false;
                btnFacturaRecibo.Enabled = false;
                ItensPorFactur[rowHandle].Facturar = true;
                gridItens.SetRowCellValue(rowHandle, "Facturar", true);
            }
            else
            {
                if (GetNomeFactura(ItensPorFactur[rowHandle]) == "FACTURA RECIBO")
                {
                    btnFactura.Enabled = false;
                    btnFacturaRecibo.Enabled = true;
                }
                else if(GetNomeFactura(ItensPorFactur[rowHandle]) == "FACTURA")
                {
                    btnFactura.Enabled = true;
                    btnFacturaRecibo.Enabled = false;
                }
                else
                {

                    btnFactura.Enabled = true;
                    btnFacturaRecibo.Enabled = true;
                }
            }
        }

        private string GetNomeFactura(ItemAtendimentoFacturaViewModel itemFactura)
        {
            var nome = string.Empty;
            var mov = _MovArtigosApp.GetMovProduto(itemFactura.ItemId, CodAtendimento, itemFactura.Nome);
            if (!Equals(mov, null))
            {
                Documento = mov.Documento;
                return mov.Documento.Operacao.Nome;
            }
            return nome;
        }
        private MovProdutosViewModel GetMovFactura(ItemAtendimentoFacturaViewModel itemFactura)
        {
            var nome = string.Empty;
            var mov = _MovArtigosApp.GetMovProduto(itemFactura.ItemId, CodAtendimento, itemFactura.Nome);
            if (!Equals(mov, null))
            {
                //Documento = mov.Documento;
                return mov;
            }
            return null;
        }

        private void CarregarDocumentosAtendimento(ItemAtendimentoFacturaViewModel itemFactura)
        {
            if (!Equals(itemFactura, null))
            {
                ListaDocumentos = _MovArtigosApp.GetDocumentosPor(CodAtendimento, itemFactura.ItemId);
            }
            else
            {
                ListaDocumentos = _MovArtigosApp.GetDocumetosPorDescricao(CodAtendimento);
                resumirDocumentos();
            }
            gradeDocumentos.DataSource = ListaDocumentos;
            if (UtilidadesGenericas.ListaNula(ListaDocumentos))
            {
                btnVerDocumento.Enabled = false;
                IndexDocumento =  -1;
            }
            else
            {
                btnVerDocumento.Enabled = true;
                IndexDocumento = 0;
            }
        }

        private void resumirDocumentos()
        {
            var resumeDocs = new List<DocumentoViewModel>();
            foreach (var item in ListaDocumentos)
            {
                if (UtilidadesGenericas.ListaNula(resumeDocs))
                {
                    resumeDocs.Add(item);
                }
                else
                {
                    if (resumeDocs.Where(d => d.Codigo == item.Codigo).FirstOrDefault() == null)
                    {
                        resumeDocs.Add(item);
                    }
                }
            }
            ListaDocumentos = null;
            ListaDocumentos = resumeDocs;
        }

        private void carregarListaItensFactura()
        {
            if (CodAtendimento > 0)
            {
                BackItensFactura = _AtendimentoHospitalarApp.ListarItensAtendimento(CodAtendimento);
                ItensComDoc = new List<ItemAtendimentoFacturaViewModel>();
                for (int i = BackItensFactura.Count - 1; i >= 0; i--)
                {
                    var mov = GetMovFactura(BackItensFactura[i]);
                    if (Equals(mov, null))
                    {
                        continue;
                    }
                    var estado = UtilidadesGenericas.InEnumStdDoc(mov.Documento.Estado);
                    if (!BackItensFactura[i].Facturar &&  (estado == TipoEstadoDocumento.ABERTO || estado == TipoEstadoDocumento.PENDENTE) )
                    {
                        ItensComDoc.Add(BackItensFactura[i]);
                        BackItensFactura.RemoveAt(i);
                    }
                }
                gradeItens.DataSource = BackItensFactura;
                gradeItensFR.DataSource = ItensComDoc;
            }
        }

        private void fecharDocumento()
        {
            Documento.Estado = "FECHADO";
            Documento.Total = getValorTotal();
            Documento.NomeCliente = Consumidor.Nome;
            _DocumentosApp.Update(Documento);
            clearGradeVender();
        }
        private DocumentosViewModel criarNovoDocumento()
        {
            if (Equals(Documento, null))
            {
                var consumidorId = (!Equals(Consumidor, null) && Consumidor.Codigo > 0) ? Consumidor.Codigo : 1;
                var documentLast = _DocumentosApp.GetById(_DocumentosApp.GetCodLast());
                var novoNumeroOrdem = Equals(documentLast, null) ? 1 : documentLast.NumeroOrdem + 1;
                var entidadeId = 1;
                if (!Equals(Consumidor, null))
                {
                    entidadeId = Consumidor.Codigo;
                }


                _DocumentosApp.Insert(new DocumentosViewModel()
                {
                    CodOperacao = OperacaoId,
                    Mascara = SubMascara + novoNumeroOrdem,
                    Estado = "ABERTO",
                    CodEntidade = consumidorId,
                    CodUsuario = UtilidadesGenericas.UsuarioCodigo,
                    Total = getValorTotal(),
                    Descritivo = DescricaoDocumento,
                    NomeCliente = Consumidor.Nome,
                    NumeroOrdem = novoNumeroOrdem,
                    Data = DateTime.Now,
                    Hora = DateTime.Now.ToShortTimeString(),
                    CodArea = 2,
                    CodMesa = 0,
                    CodTurno = UtilidadesGenericas.CodigoTurno
                });

                return _DocumentosApp.GetById(_DocumentosApp.GetCodLast());
            }
            return Documento;
        }

        private void EditarItem(ItemAtendimentoFacturaViewModel itemFactura, decimal qtd, int id)
        {
            Documento = criarNovoDocumento();
            _MovArtigosApp.UpdateOld(new MovProdutosViewModel()
            {
                codigo = id,
                CodArmazem = 0,
                CodDocumento = Documento.codigo,
                CodProduto = 0,
                Custo = 0,
                Desconto = 0,
                Imposto = Convert.ToDecimal(itemFactura.PercentagemImposto),
                Qtdade = qtd,
                Preco = Convert.ToDecimal(itemFactura.Preco),
                Retencao = 0,
                Total = Convert.ToDecimal(itemFactura.Preco) * qtd,
                Descricao = itemFactura.Nome,
                ArtigoAbstrato = itemFactura.Tipo + "?" + itemFactura.ItemId + "?" + CodAtendimento,
                CodStock = 0,
                CodImposto = itemFactura.CodImposto,
                TipoImposto = itemFactura.TipoImposto,
                DescricaoImposto = itemFactura.DescricaoImposto

            });

        }

        private MovProdutosViewModel InserirMov(ItemAtendimentoFacturaViewModel itemFactura, decimal qtd)
        {
            if (string.IsNullOrEmpty(GetNomeFactura(itemFactura)))
            {

                Documento = criarNovoDocumento();
                _MovArtigosApp.InsertOld(new MovProdutosViewModel()
                {
                    CodArmazem = 1,
                    CodDocumento = Documento.codigo,
                    CodProduto = 0,
                    Custo = 0,
                    Desconto = 0,
                    Imposto = Convert.ToDecimal(itemFactura.PercentagemImposto),
                    Qtdade = qtd,
                    Preco = Convert.ToDecimal(itemFactura.Preco),
                    Retencao = 0,
                    Total = Convert.ToDecimal(itemFactura.Preco) * qtd,
                    Descricao = itemFactura.Nome,
                    ArtigoAbstrato = itemFactura.Tipo + "?" +itemFactura.ItemId +"?" + CodAtendimento,
                    CodStock = 0,
                    CodImposto = itemFactura.CodImposto,
                    TipoImposto = itemFactura.TipoImposto,
                    DescricaoImposto = itemFactura.DescricaoImposto

                });
                return GetMovFactura(itemFactura);
            }
            return _MovArtigosApp.GetById(_MovArtigosApp.GetCodLast());
        }
        private decimal getValorTotal()
        {
            var itens = GetItensFacturar();
            var valor = 0.0m;
            for (int i = 0; i < itens.Count; i++)
            {
                valor += Convert.ToDecimal(itens[i].Preco);
            }
            return valor;
        }

        private void clearGradeVender()
        {
            Documento = null;
        }
        private void fecharItensFactura(List<ItemAtendimentoFacturaViewModel> itens)
        {
            foreach (var item in itens)
            {
                if (item.Facturar && !item.Eliminar)
                {
                    if (item.Tipo.Contains("Consulta"))
                    {
                        _ConsultaHospitalarApp.FecharFacturar(new ConsultaHospitalar()
                        {
                            Codigo = item.ItemId,
                            Facturado = "Sim"
                        });
                    }
                    else if (item.Tipo.Contains("Exame"))
                    {
                        _ExamesApp.FecharFacturar(new ExamesHospitalar()
                        {
                            Codigo = item.ItemId,
                            Facturado = "Sim"
                        });
                    }
                    else if (item.Tipo.Contains("Internamento"))
                    {
                        _InternamentoApp.Update(new PacienteInternado()
                        {
                            Facturado = "Sim",
                            Codigo = item.ItemId
                        });
                    }
                }
            }
            Documento = null;
        }
        private void btnFacturaRecibo_Click(object sender, EventArgs e)
        {
            if (!EstadoRecepcao)
            {
                UtilidadesGenericas.MsgShow("Não pode facturar pois este atendimento já está fechado");
            }
            var itens = GetItensFacturar();
            if (ItensChecados(itens))
            {
                if (ContemDocumentosDesponiveis("FACTURA RECIBO") && 
                    UtilidadesGenericas.TemCesteza("Pretenda Selecionar um dos Documentos Desponiveis?"))
                {
                    Documento = null;
                    Documento = IOC.InjectForm<frmDocumentosDisponiveis>().BuscarUmaDocumentoDiponivel(ListaDocumentos, "FACTURA RECIBO");
                    if (Equals(Documento, null))
                    {
                        return;
                    }
                }
                else
                {
                    Documento = null;
                }
                DescricaoDocumento = "Factura Recibo No Hospitalar";
                OperacaoId = 1;
                SubMascara = "FR/";
                Documento = criarNovoDocumento();

                for (int i = 0; i < itens.Count; i++)
                {
                        InserirMov(itens[i], 1);
                }
                if (IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento(Documento.codigo, itens))
                {
                    fecharItensFactura(itens);
                    CarregarDocumentosAtendimento(null);
                }
                carregarListaItensFactura();
            }
            else
            {
                UtilidadesGenericas.MsgShow("Selecione os Itens não facturados para factura-los", MessageBoxIcon.Warning);
            }

        }

        private bool ItensChecados(List<ItemAtendimentoFacturaViewModel> itens)
        {
            return !(UtilidadesGenericas.ListaNula(itens));
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            if (!EstadoRecepcao)
            {
                UtilidadesGenericas.MsgShow("Não pode facturar pois este atendimento já está fechado");
            }
            var itens = GetItensFacturar();
            if (ItensChecados(itens))
            {
                if (ContemDocumentosDesponiveis("FACTURA") &&
                UtilidadesGenericas.TemCesteza("Pretenda Selecionar um dos Documentos Desponiveis?"))
                {
                    Documento = null;
                    Documento = IOC.InjectForm<frmDocumentosDisponiveis>().BuscarUmaDocumentoDiponivel(ListaDocumentos, "FACTURA");
                    if (Equals(Documento, null))
                    {
                        return;
                    }
                }
                else
                {
                    Documento = null;
                }
                DescricaoDocumento = "Factura No Hospitalar";
                OperacaoId = 2;
                SubMascara = "FT/";
                Documento = criarNovoDocumento();

                for (int i = 0; i < itens.Count; i++)
                {
                        InserirMov(itens[i], 1);
                }
                if (IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento(Documento.codigo, itens))
                {
                    fecharItensFactura(itens);
                    CarregarDocumentosAtendimento(null);
                }
                carregarListaItensFactura();
            }
            else
            {
                UtilidadesGenericas.MsgShow("Selecione os Itens não facturados para factura-los", MessageBoxIcon.Warning);
            }

        }

        private bool ContemDocumentosDesponiveis(string nomeOperacao)
        {
            if (!UtilidadesGenericas.ListaNula(ListaDocumentos))
            {
                var documento = ListaDocumentos.Where(d => (UtilidadesGenericas.InEnumStdDoc(d.Estado) == TipoEstadoDocumento.PENDENTE ||
                                                            UtilidadesGenericas.InEnumStdDoc(d.Estado) == TipoEstadoDocumento.ABERTO) &&
                                                            Equals(d.Documento, nomeOperacao)).FirstOrDefault();
                return !Equals(documento, null);

            }
            else
            {
                return false;
            }
        }
        private List<ItemAtendimentoFacturaViewModel> GetItensFacturar()
        {
            switch (Tipo)
            {
                case TipoItem.SemDocumento:
                    var itens = new List<ItemAtendimentoFacturaViewModel>();
                    var indexs = gridItens.GetSelectedRows();
                    foreach (var index in indexs)
                    {
                        if(!BackItensFactura[index].Facturar)
                            itens.Add(BackItensFactura[index]);
                    }
                    return itens;
                case TipoItem.ComDocumento:
                    BackItensFactura = null;
                    return ItensComDoc;
                default:
                    return null;
            }
        }

        private bool verificarDocumento(string nomeOperacao)
        {
            if (!UtilidadesGenericas.ListaNula(ListaDocumentos))
            {
                if  (!ContemDocumentoNosItens() && UtilidadesGenericas.TemCesteza("Pretende Facturar o item com documento selecionada?"))
                {
                    if (UtilidadesGenericas.InEnumStdDoc(ListaDocumentos[IndexDocumento].Estado) == TipoEstadoDocumento.FECHADO ||
                        UtilidadesGenericas.InEnumStdDoc(ListaDocumentos[IndexDocumento].Estado) == TipoEstadoDocumento.ANULADO)
                    {
                        UtilidadesGenericas.MsgShow("Não possível facturar o Item pos o documento selecionado está " + ListaDocumentos[IndexDocumento].Estado);
                        Documento = null;
                        return false;
                    }

                    if (ListaDocumentos[IndexDocumento].Documento.Trim() != nomeOperacao)
                    {
                        UtilidadesGenericas.MsgShow("Não possível facturar o Item pos o documento não do tipo " + nomeOperacao);
                         Documento = null;
                        return false;
                    }
                    Documento = _DocumentosApp.GetById(ListaDocumentos[IndexDocumento].Codigo);
                }
                else
                {
                    Documento = null;

                }

            }
            else
            {
                Documento = null;

            }
            return true;
        }

        private bool ContemDocumentoNosItens()
        {
            
            foreach (var item in ItensPorFactur)
            {
                if (!string.IsNullOrEmpty(GetNomeFactura(item)))
                {
                    return false;
                }
            }
            return true;
        }

        private decimal getTotalDesconto()
        {
            var valor = 0.0m;
            foreach (var item in ItensPorFactur)
            {
                valor += item.Desconto;
            }
            return valor;
        }


        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
        //    Consumidor = IOC.InjectForm<frmEntidadeBusca>().GetEntidadeSelecionada(TypeEntity.CLIENTE);
        //    if (Equals(Consumidor, null))
        //    {
        //        return;
        //    }
        //    txtCliente.Text = Consumidor.Nome;
        //    txtCodCliente.Text = Consumidor.Codigo.ToString();
        }

        private void gridDocumentos_DoubleClick(object sender, EventArgs e)
        {
            btnVerDocumento_Click(sender, e);
        }
        private void actualizarOsFacturados()
        {
            for (int i = 0; i < ItensPorFactur.Count; i++)
            {
                if (BackItensFactura[i].Facturar)
                {
                    ItensPorFactur[i].Facturar = true;
                    gridItens.SetRowCellValue(i, "Facturar", true);
                }
            }
        }
        private void btnVerDocumento_Click(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.ListaNula(ListaDocumentos))
            {
                return;
            }
            Documento = _DocumentosApp.GetById(ListaDocumentos[IndexDocumento].Codigo);
            List<ItemAtendimentoFacturaViewModel> itens = GetItensFacturarPorDoc();

            if (IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento(Documento.codigo, itens))
            {
                fecharItensFactura(itens);
                carregarListaItensFactura();
                CarregarDocumentosAtendimento(null);
            }
        }

        private List<ItemAtendimentoFacturaViewModel> GetItensFacturarPorDoc()
        {
            var itens = new List<ItemAtendimentoFacturaViewModel>();
            foreach (var item in ItensComDoc)
            {
                if (GetMovFactura(item).CodDocumento == Documento.codigo)
                {
                    itens.Add(item);
                }
            }
            return itens;
        }

        private void gradeItens_Click(object sender, EventArgs e)
        {

        }

        private void ItemCheckFacturar_CheckedChanged(object sender, EventArgs e)
        {
            verificarFacturar(UtilidadesGenericas.GetGridIndexCurrent(gridItens, MousePosition));
            actualizarOsFacturados();
        }
        private void gridDocumentos_RowClick(object sender, RowClickEventArgs e)
        {
            IndexDocumento = e.RowHandle;
        }
        private void gridDocumentos_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            IndexDocumento = e.RowHandle;
        }

        private void cboTipoItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarListaItensFactura();
            if (cboTipoItem.SelectedItem.ToString().Trim() == "Facturados")
            {
                BackItensFactura = BackItensFactura.Where(i => i.Facturar).ToList();
            }
            else if (cboTipoItem.SelectedItem.ToString().Trim() == "Não Facturados")
            {
                BackItensFactura = BackItensFactura.Where(i => !i.Facturar).ToList();
            }
            gradeItens.DataSource = null;
            gradeItens.DataSource = BackItensFactura;
        }

        private void btnItensSemDoc_Click(object sender, EventArgs e)
        {
            lblTituloFacturacao.Text = "Itens De Facturação";
            navigationTiposItem.SelectedPage = pageItensSemDoc;
            Tipo = TipoItem.SemDocumento;
            if (SemDocPorFacturar())
            {
                btnFacturaRecibo.Enabled = false;
                btnFactura.Enabled = false;
            }
            else
            {
                btnFacturaRecibo.Enabled = true;
                btnFactura.Enabled = true;
            }

        }

        private bool SemDocPorFacturar()
        {
            return UtilidadesGenericas.ListaNula(GetItensFacturar());
        }

        private void btnItensFR_Click(object sender, EventArgs e)
        {
            lblTituloFacturacao.Text = "Itens Com Documento";
            navigationTiposItem.SelectedPage = pageItensFR;
            btnFacturaRecibo.Enabled = false;
            btnFactura.Enabled = false;
            Tipo = TipoItem.ComDocumento;
        }

        private void gridItensFR_RowClick(object sender, RowClickEventArgs e)
        {
            //btnFactura.Enabled = !(GetNomeFactura(ItensComDoc[e.RowHandle]) == "FACTURA RECIBO");
            //btnFacturaRecibo.Enabled = (GetNomeFactura(ItensComDoc[e.RowHandle]) == "FACTURA RECIBO");
            CarregarDocumentosAtendimento(ItensComDoc[e.RowHandle]);
        }

        private void gridItensFR_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            //btnFactura.Enabled = !(GetNomeFactura(ItensComDoc[e.RowHandle]) == "FACTURA RECIBO");
            //btnFacturaRecibo.Enabled = (GetNomeFactura(ItensComDoc[e.RowHandle]) == "FACTURA RECIBO");
            CarregarDocumentosAtendimento(ItensComDoc[e.RowHandle]);
        }
        
        private void ItemCheckComDoc_CheckedChanged(object sender, EventArgs e)
        {
            var rowHandle = UtilidadesGenericas.GetGridIndexCurrent(gridItensFR, MousePosition);
            //btnFactura.Enabled = !(GetNomeFactura(ItensComDoc[rowHandle]) == "FACTURA RECIBO");
            //btnFacturaRecibo.Enabled = (GetNomeFactura(ItensComDoc[rowHandle]) == "FACTURA RECIBO");
            CarregarDocumentosAtendimento(ItensComDoc[rowHandle]);
        }
    }
}