using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Enuns.Documentos;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Domain.ViewModels.Frame.Documentos;
using Folha.Domain.ViewModels.Frame.Sistema;
using Folha.Presentation.Desktop.Forms.Documentos;
using Folha.Presentation.Desktop.Separadores.Armazens;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Presentation.Desktop.Separadores.Financeiro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.ViewModels.Inventario;
using Folha.Presentation.Desktop.Forms.Financeiro;
using Folha.Domain.Interfaces.Application.Admin;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Presentation.Desktop.Classe;
using Folha.Domain.ViewModels.Sistema;

namespace Folha.Presentation.Desktop.Separadores.Principal
{
    public partial class frmVerTodosDocumentos : DevExpress.XtraEditors.XtraForm
    {
        private readonly IDocumentosApp _documentosApp;
        private readonly IOperacoesApp _operacoesApp;
        private readonly IMovArtigosApp _movArtigoApp;
        private readonly IArtigoStockApp _stockApp;
        private readonly IDefinicoesGeraisApp _definicoesGeraisApp;
        private readonly IPagamentosApp _pagamentosAapp;
        private readonly ITransferenciaProdutoApp _transferenciaProdutoApp;
        private readonly IUsuariosApp _usuarioApp;
        private readonly INotasPagamentosApp _NotasPagamentosApp;
        private bool admin = true;
        private List<OperacaoViewModel> listaOperacoes;
        private string _TiposDocumentos = "ENTRADAS";

        private List<DocumentoViewModel> ListDocumentos { get; set; }
        private DocumentosViewModel DocumentoAnular { get; set; }
        private bool PermitirVenderSemStock { get; set; }
        private bool EditarOutro { get; set; }

        public frmVerTodosDocumentos(
            IDocumentosApp documentosApp, 
            IOperacoesApp operacoesApp,
            IMovArtigosApp movArtigoApp,
            IArtigoStockApp stockApp,
            IDefinicoesGeraisApp definicoesGeraisApp,
            IPagamentosApp pagamentosAapp, 
            ITransferenciaProdutoApp transferenciaProdutoApp,
            IUsuariosApp usuarioApp,
            INotasPagamentosApp notasPagamentosApp)
        {
            InitializeComponent();
            UtilidadesGenericas.ValidarDataFimDataInicio(DtInicio, DtFim);
            _documentosApp = documentosApp;
            _operacoesApp = operacoesApp;
            _movArtigoApp = movArtigoApp;
            _stockApp = stockApp;
            _definicoesGeraisApp = definicoesGeraisApp;
            _pagamentosAapp = pagamentosAapp;
            _transferenciaProdutoApp = transferenciaProdutoApp;
            _usuarioApp = usuarioApp;
            _NotasPagamentosApp = notasPagamentosApp;
            Permicao();
        }
        #region Permicao de Acesso
        int VerficaUsuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private int indexGrid;

        private void Permicao()
        {
            if (VerficaUsuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Documentos#Criar") == false) { btnNovoDocumento.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Documentos#Anular") == false) { btnAnularDocumentos.Enabled = false; }
            }
        }
        #endregion

        private void CarregarDocumentos(String DocumentoNome)
        {          
            DateTime inicio = DateTime.Parse(DtInicio.Text);
            DateTime termino = DateTime.Parse(DtFim.Text);
            string criterio = null;

            criterio = "Documentos.Data between '" + inicio.ToString("yyyy-MM-dd") + "' and '" + termino.ToString("yyyy-MM-dd") + "'";

            if (CboDocumentos.SelectedIndex==0)
            {
                if (string.IsNullOrEmpty(txtCodEntidade.Text) == false)
                {
                    criterio += " and Documentos.CodEntidade='" + txtCodEntidade.Text + "'";
                }
            }
            else
            {
                if (string.IsNullOrEmpty(DocumentoNome) == false)
                {
                    criterio += " and Operacoes.Nome like '" + DocumentoNome + "'";
                }
                if (string.IsNullOrEmpty(txtCodEntidade.Text) == false)
                {
                    criterio += " and Operacoes.Nome like '" + DocumentoNome + "' And Documentos.CodEntidade='" + txtCodEntidade.Text + "'";
                }

            }
            if (UtilidadesGenericas.UsuarioPerfilCodigo != 1)
            {
                criterio += " and Documentos.CodUsuario like '" + UtilidadesGenericas.UsuarioCodigo + "'";
            }
            try
            {
                if (Equals(_documentosApp, null))
                {
                    return;
                }
                ListDocumentos = _documentosApp.Listar(criterio);
                indexGrid = 0;
                refreshListaDocumentos();
                setSaldos();

            }
            catch (Exception ex)
            {

                UtilidadesGenericas.MsgShow("Houve um Erro apartir da Classe " + ex.Message);

            }
        }

        private void setSaldos()
        {
            decimal saldo = 0.0m, credito = 0.0m, debito = 0.0m;
            foreach (var item in ListDocumentos)
            {
                if (Equals(item.Estado.Trim(), "FECHADO"))
                {
                    if (item.MovFinanceiro == "CREDITO")
                    {
                        credito += (decimal)item.Total;
                    }
                    else if (item.MovFinanceiro == "DEBITO")
                    {
                        debito += (decimal)item.Total;
                    }
                }
            }
            txtCredito.Text = credito.ToString("N2");
            txtDebito.Text = debito.ToString("N2");
            saldo = credito - debito;
            txtSaldo.Text = saldo.ToString("N2");
        }

        private void refreshListaDocumentos()
        {
            GradeDocumentos.DataSource = UtilidadesGenericas.newInstanceThisList(ListDocumentos);
        }

        private void abriForm(object formaberto)
        {

        }
        private void CarregaTudo()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    CarregarOperacoes();
                    VerificarPErmissaoDeFacturacao();
                    CboDocumentos.SelectedIndex = 0;
                }));
            }
            else
            {
                CarregarOperacoes();
                VerificarPErmissaoDeFacturacao();
                CboDocumentos.SelectedIndex = 0;
            }
        }

        private void FormVerTodosDocumentos_Load(object sender, EventArgs e)
        {
            new Forms.Sistema.FrmProcessar(CarregaTudo).ShowDialog(this);  
        }


        private void btnNovo_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.Alterou = false;
            string Documento = CboDocumentos.SelectedItem.ToString().Trim();
            if (Equals(Documento, "TODOS DOCUMENTOS"))
            {
                messageShow("Escolha um documento");
                return;
            }
            var index = CboDocumentos.SelectedIndex - 1;
            var operacao = listaOperacoes[index];
            if (operacao.APP.ToUpper().Contains("TP"))
            {
                IOC.InjectForm<frmStockTransferencia>().ShowDialog();
                CarregarDocumentos(CboDocumentos.SelectedItem + "");
                return;
            }
            if (operacao.APP.ToUpper().Contains("NP"))
            {
                IOC.InjectForm<frmNotaPagamento>().ShowDialog();
                CarregarDocumentos(CboDocumentos.SelectedItem + "");
                return;
            }
            if (operacao.APP.ToUpper().Contains("NC"))
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO", 
                    "Não é possível criar este tipo Documento", 
                    MessageBoxIcon.Warning, 
                    MessageBoxButtons.OK
                );
                return;
            }
            if (operacao.APP.ToUpper().Contains("RG"))
            {
                var documentoRecibo = IOC.InjectForm<frmGerarRecibo>().GetNovoDocumentoRecibo();
                if (!Equals(documentoRecibo, null) && documentoRecibo.codigo > 0)
                {
                    if (IOC.InjectForm<frmReceberPagamentos>().ReceberPagmentoDocumento(documentoRecibo, 0.000m))
                    {
                        if (DocumentoFechadoOuAnulado(documentoRecibo))
                        {
                            IOC.InjectForm<frmImprimirReport>().ImprimirRecibo(
                                _pagamentosAapp.GetAllByDoc(documentoRecibo.codigo)
                            );
                        }
                        CarregarDocumentos(CboDocumentos.SelectedItem + "");
                    }
                }
                return;
            }
            if (UtilidadesGenericas.EstadoTurnoSistema)
            {
                if (IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento(operacao.APP, "ABERTO"))
                {
                    CarregarDocumentos(CboDocumentos.SelectedItem + "");
                }
                
            }
            else UtilidadesGenericas.MsgShow(
                    "Mensagem",
                    "Turno Está fechado!",
                    MessageBoxIcon.Stop,
                    MessageBoxButtons.OK
                );
            if (UtilidadesGenericas.Alterou)
            {
                //CarregarDocumentos(CboDocumentos.SelectedItem + "");
                //UtilidadesGenericas.Alterou = false;
            }
                
        }

        private bool DocumentoFechadoOuAnulado(DocumentosViewModel documentoRecibo)
        {
            return UtilidadesGenericas.InEnumStdDoc(documentoRecibo.Estado) == TipoEstadoDocumento.ANULADO ||
                   UtilidadesGenericas.InEnumStdDoc(documentoRecibo.Estado) == TipoEstadoDocumento.FECHADO;
        }

        private void btnEntidade_Click(object sender, EventArgs e)
        {
            var entidade = IOC.InjectForm<frmEntidadeBusca>().GetEntidadeSelecionada();
            if (Equals(entidade, null) || entidade.Codigo == 0)
            {
                return;
            }
            txtCodEntidade.Text = entidade.Codigo.ToString();
            txtNomeEntidade.Text = entidade.Nome;
            //CarregarDocumentos(CboDocumentos.SelectedItem.ToString());
        }

        private void CboDocumentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            selecionarOperacaoDoDocumento();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            CarregarDocumentos(CboDocumentos.SelectedItem.ToString());
        }

        private void gridDocumentos_DoubleClick(object sender, EventArgs e)
        {
            if (gridDocumentos.RowCount > 0)
            {
                EditarOutro = true;
                var documentoSelecionado = GetDocumentoSelcionado();
                if (DocumentoFechado() && !("FTFRPPAMDASEASSCFGE".Contains(documentoSelecionado.Operacao.APP)))
                {
                    ImprimirDocumentos();
                }
                else if (DocumentoAberto())
                {
                    EditarDocumento();
                }
                if (EditarOutro)
                {
                    if (IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento(GetDocumentoSelcionado().codigo))
                    {
                        CarregarDocumentos(CboDocumentos.SelectedItem + "");
                    }
                    
                }
                
            }
            else
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO",
                    "Lista de documentos está vazia",
                    MessageBoxIcon.Warning,
                    MessageBoxButtons.OK
                );
            }

        }

        private void EditarDocumento()
        {
            if (GetDocumentoSelcionado().Operacao.Nome.ToUpper().Contains("TRANSFERENCIA DE ARTIGO"))
            {
                if (IOC.InjectForm<frmStockTransferencia>().EditarTransferenciaArtigo(GetDocumentoSelcionado().codigo))
                {
                    CarregarDocumentos(CboDocumentos.SelectedItem + "");
                }
                EditarOutro = false;
                return;
            }
            if (GetDocumentoSelcionado().Operacao.Nome == "RECIBO")
            {
                if (DocumentoAberto())
                {
                    UtilidadesGenericas.MsgShow(
                        "Imformação",
                        "Não é possível imprimir este documento," +
                        "\n pois o mesmo está aberto",
                        MessageBoxIcon.Information,
                        MessageBoxButtons.OK
                    );
                    EditarOutro = false;
                    return;
                }
                else
                {
                    var documentoSelecionado = GetDocumentoSelcionado();
                    IOC.InjectForm<frmImprimirReport>().ImprimirRecibo(_pagamentosAapp.GetAllByDoc(documentoSelecionado.codigo, documentoSelecionado.Operacao.MovFin));
                    EditarOutro = false;
                    return;
                }
            }
            if (GetDocumentoSelcionado().Operacao.Nome == "NOTA DE CREDITO")
            {
                if (DocumentoAberto())
                {
                    UtilidadesGenericas.MsgShow(
                        "Imformação",
                        "Não é possível imprimir este documento," +
                        "\n pois o mesmo está aberto",
                        MessageBoxIcon.Information,
                        MessageBoxButtons.OK
                    );
                    EditarOutro = false;
                    return;
                }
                else
                {
                    var documentoSelecionado = GetDocumentoSelcionado();
                    IOC.InjectForm<frmImprimirReport>().ImprimirNotaCredito(
                        _movArtigoApp.GetMovVendaByIdDocumento(documentoSelecionado.codigo),
                        _pagamentosAapp.GetAllByDoc(documentoSelecionado.codigo, documentoSelecionado.Operacao.MovFin)
                    );
                    EditarOutro = false;
                    return;
                }
            }
            if (GetDocumentoSelcionado().Operacao.Nome.ToUpper().Contains("NOTA DE PAGAMENTO"))
            {
                if (IOC.InjectForm<frmNotaPagamento>().ReceberCodDocumento(GetDocumentoSelcionado().codigo.ToString()))
                {
                    CarregarDocumentos(CboDocumentos.SelectedItem + "");
                }
                EditarOutro = false;
                return;
            }
            
        }

        private bool DocumentoAberto()
        {
            return UtilidadesGenericas.InEnumStdDoc(GetDocumentoSelcionado().Estado) == TipoEstadoDocumento.ABERTO ||
                   UtilidadesGenericas.InEnumStdDoc(GetDocumentoSelcionado().Estado) == TipoEstadoDocumento.PENDENTE;
        }

        private bool DocumentoFechado()
        {
            return UtilidadesGenericas.InEnumStdDoc(GetDocumentoSelcionado().Estado) == TipoEstadoDocumento.ANULADO ||
                   UtilidadesGenericas.InEnumStdDoc(GetDocumentoSelcionado().Estado) == TipoEstadoDocumento.FECHADO;
        }

        private void ImprimirTransferenciaArtigos()
        {
            var ListaProdutos = (List<TransferenciaProdutoViewModel>)_transferenciaProdutoApp.Listar(GetDocumentoSelcionado().codigo.ToString(), false);

            if (UtilidadesGenericas.ListaNula(ListaProdutos))
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO ",
                    "A lista encontra-se sem registros", 
                    MessageBoxIcon.Information,
                    MessageBoxButtons.OK
                );

                return;
            }
            var usuario = _usuarioApp.GetById(UtilidadesGenericas.UsuarioCodigo);
            ListaProdutos[0].DadosEmpresa = new DadosEmpresaViewModel()
            {
                NomeFuncionario = usuario.Entidade.Nome,
                DataHora = DateTime.Now,
                DocumentoId = GetDocumentoSelcionado().codigo,
                Cambio = "000",
                Moeda = UtilidadesGenericas.Moeda
            };

            ListaProdutos[0].CabecalhoEmpresa = Controle.CabecalhoEmpresa;
            IOC.InjectForm<frmImprimirReport>().ApresentarReportTransferenciaProduto(ListaProdutos);
        }
        private void ImprimirDocumentos()
        {
            var doc = GetDocumentoSelcionado();
            //doc.Emitido = UtilidadesGenericas.MudarEmitidoDocumento(doc.Emitido);
            //_documentosApp.Update(doc);

            if (GetDocumentoSelcionado().Operacao.Nome.ToUpper().Contains("TRANSFERENCIA DE ARTIGO"))
            {
                ImprimirTransferenciaArtigos();
                EditarOutro = false;
                return;
            }
            if (GetDocumentoSelcionado().Operacao.Nome == "RECIBO")
            {
                doc = _documentosApp.GetById(doc.codigo);
                if (doc.Operacao.APP == "RG")
                {
                    IOC.InjectForm<frmImprimirReport>().ImprimirRecibo(_pagamentosAapp.GetAllByDoc(doc.codigo, doc.Operacao.MovFin));
                    EditarOutro = false;
                }
                return;
            }
            if (GetDocumentoSelcionado().Operacao.Nome.ToUpper().Contains("NOTA DE PAGAMENTO"))
            {
                ImprimirNotaPagamento();
                EditarOutro = false;
                return;
            }
            if (GetDocumentoSelcionado().Operacao.Nome.ToUpper().Contains("NOTA DE CREDITO"))
            {
                //IOC.InjectForm<frmImprimirReport>().ImprimirNotaCredito
                //    (_movArtigoApp.GetMovVendaByIdDocumento(doc.codigo),
                //    _pagamentosAapp.GetAllByDoc(doc.codigo, "DEBITO")
                //);
                IOC.InjectForm<frmImprimirReport>().ImprimirDocumentoVenda(_movArtigoApp.GetMovVendaByIdDocumento(doc.codigo));

                EditarOutro = false;
                return;
            }

            IOC.InjectForm<frmImprimirReport>().ImprimirDocumentoVenda(
                _movArtigoApp.GetMovVendaByIdDocumento(doc.codigo)
            );
        }
        private void ImprimirNotaPagamento()
        {
            var docSelecionado = GetDocumentoSelcionado();
            var dados = _NotasPagamentosApp.GetNotaPagamento(docSelecionado.codigo);
            var ltPagamento = _NotasPagamentosApp.ListarNotasPagamentos(docSelecionado.codigo);
            IOC.InjectForm<frmImprimirReport>().ApresentarReportNotaPagamento(dados, ltPagamento);
        }

        private DocumentosViewModel GetDocumentoSelcionado()
        {
            var codDoc = Convert.ToInt16(gridDocumentos.GetRowCellValue(indexGrid, "Codigo"));
            var docSelcionado = _documentosApp.GetById(codDoc);
            return docSelcionado;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            selecionarOperacaoDoDocumento();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }

        private void txtNomeEntidade_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void DataEdit_EditValueChanged(object sender, EventArgs e)
        {
            //CarregarDocumentos(CboDocumentos.SelectedItem+"");
        }

        private void btnAnularDocumentos_Click(object sender, EventArgs e)
        {
            if (gridDocumentos.RowCount == 0)
            {
                return;
            }
            var estado = gridDocumentos.GetRowCellValue(indexGrid, "Estado").ToString();
            if (estado == "ANULADO")
            {
                messageShow("Este documento já se encontra anulado!");
                return;
            }
            if (estado == "FECHADO")
            {
                messageShow("Não é possivel anular um documento fechado!");
                return;
            }
            if (UtilidadesGenericas.TemCesteza("Tem certeza que pretnde este documento?"))
            {
                string movito = new frmMotivoAnularDocumento().GetDescricaoDoMotivo();
                if (string.IsNullOrEmpty(movito))
                {
                    return;
                }
                var codDoc = Convert.ToInt16(gridDocumentos.GetRowCellValue(indexGrid, "Codigo"));
                DocumentoAnular = _documentosApp.GetById(codDoc);
                if (!Equals(DocumentoAnular, null))
                {
                    devolverQtdArtigosEmStock();
                    AnularDocumentoCurrent(movito);
                    CarregarDocumentos(CboDocumentos.SelectedItem + "");
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnImprecao_Click(object sender, EventArgs e)
        {
            if (gridDocumentos.RowCount > 0)
            {
                if (DocumentoFechado())
                {
                    ImprimirDocumentos();
                }
                else
                {
                    UtilidadesGenericas.MsgShow(
                        "Imformação",
                        "Não é possível imprimir este documento,"+
                        "\n pois o mesmo está aberto",
                        MessageBoxIcon.Information,
                        MessageBoxButtons.OK
                    );
                }
            }
            else
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO",
                    "Lista de documentos está vazia",
                    MessageBoxIcon.Warning,
                    MessageBoxButtons.OK
                );
            }
        }

        private void CarregarOperacoes()
        {
            if (listaOperacoes != null) listaOperacoes.Clear();
            listaOperacoes = _operacoesApp.Listar(_TiposDocumentos);
            listaOperacoes = listaOperacoes.OrderBy(o => o.Nome).ToList();
            CboDocumentos.Properties.Items.Clear();
            CboDocumentos.Properties.Items.Add("TODOS DOCUMENTOS");
            foreach (var operacao in listaOperacoes)
            {
                if (UtilidadesGenericas.UsuarioPerfilCodigo == 1)
                {
                    CboDocumentos.Properties.Items.Add(operacao.Nome);
                }
                else if (UtilidadesGenericas.TemAcesso("Operações#" + operacao.Nome))
                {
                    CboDocumentos.Properties.Items.Add(operacao.Nome);
                }
            }
        }
        private void selecionarOperacaoDoDocumento()
        {
            if (CboDocumentos.SelectedItem.ToString() != "TODOS DOCUMENTOS")
            {
                if (admin)
                {
                    string Entidade = listaOperacoes[CboDocumentos.SelectedIndex - 1].Entidade;
                    if (Entidade == "ISENTO") gridDocumentos.Columns[5].Visible = false;
                    else gridDocumentos.Columns[5].Visible = true;
                }
                else
                {
                    string Entidade = listaOperacoes[CboDocumentos.SelectedIndex - 1].Entidade;
                    if (Entidade == "ISENTO") gridDocumentos.Columns[5].Visible = false;
                    else gridDocumentos.Columns[5].Visible = true;
                }
            }

            CarregarDocumentos(CboDocumentos.SelectedItem.ToString());
        }
        private void messageShow(string message)
        {
            UtilidadesGenericas.MsgShow(
                "Documento",
                message,
                MessageBoxIcon.Information,
                MessageBoxButtons.OK
            );
        }
        private void devolverQtdArtigosEmStock()
        {
            if (UtilidadesGenericas.InEnumMov(DocumentoAnular.Operacao.MovStk) == TipoMov.DEBITO)
            {
                var artigos = _movArtigoApp.GetAllByIdDocumento(DocumentoAnular.codigo);
                foreach (var item in artigos)
                    acertarEntradaArtigoStock(item.ArtigoStock, item.Qtdade);
            }
        }
        private void VerificarPErmissaoDeFacturacao()
        {
            var dadosGerais = _definicoesGeraisApp.ListarGerais(null);
            PermitirVenderSemStock = dadosGerais.FirstOrDefault().StateVenderSemStock;
        }
        private void acertarEntradaArtigoStock(ProdutoStockViewModel artigoStock, decimal qtdEntrar)
        {
            if (Equals(artigoStock, null) || PermitirVenderSemStock)
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
            _documentosApp.AnularDocumento(DocumentoAnular.codigo, UtilidadesGenericas.UsuarioCodigo, motivo);
        }

        private void txtNomeEntidade_Click(object sender, EventArgs e)
        {
            var entidade = IOC.InjectForm<frmEntidadeBusca>().GetEntidadeSelecionada();
            if (Equals(entidade, null) || entidade.Codigo == 0)
            {
                return;
            }
            txtCodEntidade.Text = entidade.Codigo.ToString();
            txtNomeEntidade.Text = entidade.Nome;
            //CarregarDocumentos(CboDocumentos.SelectedItem.ToString());
        }
    }
}