using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Tile;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Financeiro;
using Folha.Presentation.Desktop.Forms.Sistema;
using Folha.Presentation.Desktop.Separadores.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Separadores.Principal
{
    using DevExpress.XtraEditors;
    using Domain.ViewModels.Documentos;
    using Folha.Domain.Interfaces.Application.Admin;
    using Folha.Domain.Interfaces.Application.Financeiro;
    using Folha.Domain.Interfaces.Application.Hospitalar;
    using Folha.Domain.Interfaces.Application.Sistema;
    using Folha.Domain.Models.Hospitalar;
    using Folha.Domain.ViewModels.Entidades;
    using Folha.Domain.ViewModels.Hospitalar;
    using Folha.Domain.ViewModels.Sistema;
    using Folha.Domain.Enuns.Documentos;
    using Folha.Domain.Enuns.Entidades;
    using Folha.Domain.Helpers;
    using Folha.Presentation.Desktop.Forms.Documentos;
    using Folha.Presentation.Desktop.Forms.Geral;
    using Folha.Presentation.Desktop.Separadores.Armazens;
    using System.Drawing;
    using Domain.ViewModels.Financeiro;

    public enum TipoCatgoria
    {
        Categoria, Mesa, Hospedagem, Default
    }
    public partial class frmTelaDocumento : XtraForm
    {
        private TipoCatgoria Tipo { get; set; } = TipoCatgoria.Categoria;

        private OperacoesViewModel Operacao { get; set; } 
        private List<CardCategoriaViewModel> Categorias { get; set; }
        private List<CardArtigoViewModel> Artigos { get; set; }
        private List<ProdutoStockViewModel> ArtigosStock { get; set; }
        private List<VendaViewModel> ArtigosVender { get; set; } = new List<VendaViewModel>();
        private List<ComissaoViewModel> ListaComissoes { get;  set; }
        private List<ArmazensViewModel> ListaArmazens { get;  set;}
        private List<ArtigoViewModel> _Artigos;

        private DocumentosViewModel Documento { get; set; } = null;
        public EntidadesViewModel Consumidor { get; set; }

        private int indexCategoria { get; set; }
        private int indexArmazem { get; set; }
        private int indexArtigoVender { get; set; } = -1;
        private int OperacaoId { get; set; } = 1;
        private string OperacaoApp { get; set; } = "FR";
        private int indexArtigo;
        int UsuarioPerfil = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        public decimal DescontoGeral { get; set; } = 0.0m;
        public bool PermitirVenderSemStock { get; set; } = true;

        private string SubMascara { get; set; } = "FR/";
        private int IndexComissao { get; set; }
        private string EstadoDocumento { get; set; } = "ABERTO";
        private int PercentagemWidthPanelVenda { get; set; } = 100;
        private AnuladosViewModel Anulado { get; set; }
        private bool Facturado { get;  set; }
        private List<ItemAtendimentoFacturaViewModel> ItensFactura { get;  set; }

        private readonly IArtigosApp _artigoApp;
        private readonly IArtigoStockApp _stockApp;
        private readonly IArmazemApp _armazemApp;
        private readonly ICategoriaApp _categoriaApp;
        private readonly IDocumentosApp _documentosApp;
        private readonly IMovArtigosApp _movArtigosApp;
        private readonly IComissoesApp _comissoesApp;
        private readonly IEntidadesApp _entidadeApp;
        private readonly IOperacoesApp _operacoesApp;
        private readonly IAtendimentoHospitalarApp _AtendimentoHospitalarApp;
        private readonly IExamesHospitalarApp _ExamesApp;
        private readonly IConsultaHospitalarApp _ConsultaHospitalarApp;
        private readonly IInternamentoApp _InternamentoApp;
        private readonly IDefinicoesGeraisApp _definicoesGeraisApp;
        private readonly IPagamentosApp _pagamentosApp;


        public frmTelaDocumento(
            IArtigosApp artigoApp, 
            IArmazemApp armazemApp, 
            ICategoriaApp categoriaApp, 
            IArtigoStockApp stockApp, 
            IDocumentosApp documentosApp,
            IMovArtigosApp movArtigoSApp,
            IEntidadesApp entidadeApp,
            IComissoesApp comissoesApp,
            IOperacoesApp operacoesApp,
            IAtendimentoHospitalarApp atendimentoHospitalarApp,
            IExamesHospitalarApp examesApp,
            IConsultaHospitalarApp consultaHospitalarApp,
            IInternamentoApp internamentoApp,
            IDefinicoesGeraisApp definicoesGeraisApp,
            IPagamentosApp pagamentosApp)
        {
           // Controle.Processamento();
            InitializeComponent();
            navigationFrame1.SelectedPage = navigationPage_PostoVenda;
            _artigoApp = artigoApp;
            _categoriaApp = categoriaApp;
            _armazemApp = armazemApp;
            _stockApp = stockApp;
            _documentosApp = documentosApp;
            _movArtigosApp = movArtigoSApp;
            _entidadeApp = entidadeApp;
            _comissoesApp = comissoesApp;
            _operacoesApp = operacoesApp;
            _AtendimentoHospitalarApp = atendimentoHospitalarApp;
            _ExamesApp = examesApp;
            _ConsultaHospitalarApp = consultaHospitalarApp;
            _InternamentoApp = internamentoApp;
            _definicoesGeraisApp = definicoesGeraisApp;
            _pagamentosApp = pagamentosApp;
            //Permicao();
            //RenderizarOperacoes();

        }
        #region Permicao de acesso
        private void Permicao()
        {
            if (UsuarioPerfil != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Vendas") == false)
                {
                    btnGravarVenda.Enabled = false;
                }
                if (UtilidadesGenericas.TemAcesso("Vendas#Opções de Documentos#Venda a Cliente") == false)
                {
                    btnCliente.Enabled = false;
                }
                if (UtilidadesGenericas.TemAcesso("Vendas#Opções de Documento#Alterar Preço") == false)
                {
                    btnPreco.Enabled = false;
                }
                if (UtilidadesGenericas.TemAcesso("Vendas#Opções de Documento#Cancelar Venda") == false)
                {
                    btnCancelar.Enabled = false;
                }
                if (UtilidadesGenericas.TemAcesso("Vendas#Opções de Documento#Desconto na Venda") == false)
                {
                    btnDesconto.Enabled = false;
                }
                if (UtilidadesGenericas.TemAcesso("Vendas#Opções de Documento#Deixar Vanda Pendente") == false)
                {
                    btnDeixarPendente.Enabled = false;
                }
                if (UtilidadesGenericas.TemAcesso("Vendas#Opções de Documento#Receber Pagamentos de Vendas") == false)
                {
                    btnGravarVenda.Enabled = false;
                }
                if (UtilidadesGenericas.TemAcesso("Vendas#Opções de Documento#Quantidade") == false)
                {
                    btnQtd.Enabled = false;
                }
            }
        }
        #endregion
        private void InserirConsumidor()
        {
            if (!SeNaoTemDocumento())
            {
                Consumidor = Documento.Entidade;
                //labelConsumidor.Text = Consumidor.Nome;
            }
            if (Equals(Operacao, null))
            {
                Operacao = _operacoesApp.GetByApp(OperacaoApp);
            }
            else if (UtilidadesGenericas.InEnum(Operacao.Entidade) == TypeEntity.FORNECEDOR)
            {
                Consumidor = _entidadeApp.GetById(3);
            }
            else if (UtilidadesGenericas.InEnum(Operacao.Entidade) == TypeEntity.CLIENTE)
            {
                Consumidor = _entidadeApp.GetById(2);
            }
            else
            {
                Consumidor = _entidadeApp.GetById(1);
            }
        }

        private bool ExisteDocumentoAndMsg()
        {
            if (ExisteDocumento())
            {
                return true;
            }
            else
            {
                UtilidadesGenericas.MsgShow("Não Existo Documento!");
                return false;
            }
        }
        private void carregarGradeComissoes()
        {
           
            gradeComissoes.DataSource = ListaComissoes;
            if (!Equals(ListaComissoes, null) && ListaComissoes.Count <= 0)
                IndexComissao = 0;
            else IndexComissao = -1;
        }
        private void carregarListComissoes()
        {
            if (!ExisteDocumento())
            {
                return;
            }
            ListaComissoes = _comissoesApp.CarregaComissoes(Documento.codigo);
            if (!Equals(ListaComissoes, null) && ListaComissoes.Count > 0)
                IndexComissao = 0;
            else IndexComissao = -1;
        }
        private void btnVenda_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_PostoVenda;
        }
        private void btnPagamentos_Click_1(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Pagamentos;

        }
        private void btnComissoes_Click_1(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Commisao;
        }
        private void btnObservacoes_Click_1(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Observacao;
        }
        private void btnAnexos_Click_1(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Anexo;
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
           
        }
        private void btnQtd_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;

            // Quantidade
            if (Equals(ArtigosVender, null) || ArtigosVender.Count == 0)
            {
                UtilidadesGenericas.MsgShow("Adicione um artigo a lista  de " + Operacao.Nome);
                return;
            }
            var artigoVender = GetMovArtigoSelecionado();
            var objQtd = new frmValorNumerico().GetValor(artigoVender.qtde, null);
            var beckupQtd = artigoVender.qtde;
            if (Equals(objQtd, null))
            {
                return;
            }
            artigoVender.qtde = Convert.ToDecimal(objQtd.ToString().Replace(".", ","));
            if (validQtdStock(artigoVender.Artigo, artigoVender))
            {
                if (UtilidadesGenericas.InEnumMov(Operacao.MovStk) == TipoMov.DEBITO && artigoVender.qtde != beckupQtd)
                {
                    acertarEntradaArtigoStock(artigoVender.Artigo, beckupQtd);
                    DevolverComposicoes(artigoVender.MovArtigo, beckupQtd);
                    acertarSaidaDeArtigoStock(artigoVender.Artigo, artigoVender.qtde);
                    UpdateComposicao(artigoVender.MovArtigo, artigoVender.qtde);
                }
                EditarLancamentoArtigo(artigoVender, artigoVender.qtde, artigoVender.MovArtigo.codigo);
                gradeArtigoVender.DataSource = newInstanceThisList(ArtigosVender);
            }
            else
            {
                artigoVender.qtde = beckupQtd;
            }
            addValoresControlersTotal(getValorTotal());
        }
        private List<T> newInstanceThisList<T>(List<T> list) where T : class, new()
        {
            var newList = new List<T>();
            newList.AddRange(list);

            return newList;
        }
        private void btnPreco_Click(object sender, EventArgs e)
        {
            //Preco
            panelMenu.Visible = false;

            if (Equals(ArtigosVender, null) || ArtigosVender.Count == 0)
            {
                UtilidadesGenericas.MsgShow("Adicione Um artigo a lista de " + Operacao.Nome);
                return;
            }
            var artigoVender = GetMovArtigoSelecionado();
            var objPreco = new frmValorNumerico().GetValor(artigoVender.Preco, "Preço Do Artigo");
            if (Equals(objPreco, null))
            {
                return;
            }
            artigoVender.MovArtigo.Preco = Convert.ToDecimal(objPreco.ToString().Replace(".",","));
            artigoVender.MovArtigo.Total = artigoVender.Total;
            if (Equals(artigoVender.Artigo, null))
            {
                _movArtigosApp.UpdateOld(artigoVender.MovArtigo);
            }
            else
            {
                _movArtigosApp.Update(artigoVender.MovArtigo);
            }
            gradeArtigoVender.DataSource = newInstanceThisList(ArtigosVender);
            addValoresControlersTotal(getValorTotal());
            UtilidadesGenericas.Busca.Numerario = 0;
        }
        private void btnDesconto_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;

            if (Equals(ArtigosVender, null) || ArtigosVender.Count == 0)
            {
                UtilidadesGenericas.MsgShow("Adicione Um artigo a lista de " + Operacao.Nome);
                return;
            }
            var artigoVender = GetMovArtigoSelecionado();
            var objDesconto = new frmValorNumerico().GetValorPercentual(artigoVender.Desconto, "Desconto Do Artigo");
            if (Equals(objDesconto, null))
            {
                return;
            }
            var desconto = Convert.ToDecimal(objDesconto.ToString().Replace(".", ","));
            if (Equals(objDesconto, null))
            {
                return;
            }
            if (desconto > 100)
            {
                desconto = 100;
            }
            if (desconto < 0)
            {
                desconto = 0;
            }
                artigoVender.MovArtigo.Desconto = desconto;
                artigoVender.MovArtigo.Total = artigoVender.Total;
            if (Equals(artigoVender.Artigo, null))
            {
                _movArtigosApp.UpdateOld(artigoVender.MovArtigo);
            }
            else
            {
                _movArtigosApp.Update(artigoVender.MovArtigo);
            }
            gradeArtigoVender.DataSource = newInstanceThisList(ArtigosVender);
            addValoresControlersTotal(getValorTotal());
            UtilidadesGenericas.Busca.Numerario = 0;
        }
        private void frmTelaVenda_Load(object sender, EventArgs e)
        {
            new FrmProcessar(CarregarTudo).ShowDialog(this);
            if(OperacaoId>0)
            {
                btnCategoria_Click(sender, e);
            }
            if (Equals(Operacao, null))
            {
                Operacao = _operacoesApp.GetByApp(OperacaoApp);
            }
            if (!Equals(Documento, null))
            {
                if (UtilidadesGenericas.InEnumStdDoc(Documento.Estado) == TipoEstadoDocumento.ANULADO)
                {
                    //btnObservacoes.Visible = true;
                }
            }
            CarregarNomeOperacao();
        }

        private void CarregarNomeOperacao()
        {
            if (!Equals(Operacao, null))
            {
                RenderizarOperacoes();
                labelOperacao.Text = Operacao.Nome;
                comboBoxOperacao.Text = Operacao.Nome;
                comboBoxOperacao.SelectedIndexChanged += new EventHandler(comboBoxOperaracao_SelectedIndexChanged);
            }
            if (!Equals(Documento, null))
            {
                labelNumeroDocumento.Text = "Nº " + Documento.NumeroOrdem;
            }
        }

        void CarregarTudo()
        {
            //renderizarPanelVenda(100);

            if (!string.IsNullOrEmpty(OperacaoApp))
            {
                //Update();
                VerificarPErmissaoDeFacturacao();
                carregarArmazem();
                carregarArtigosSemPagamentos();
                carregarListaAndGrade();
                InserirConsumidor();
                addValoresControlersTotal(getValorTotal());
                if (Equals(Operacao, null))
                {
                    Operacao = _operacoesApp.GetByApp(OperacaoApp);
                    OperacaoId = Operacao.codigo;
                }
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(delegate {
                        btnCliente.Text = Operacao.Entidade;
                    }));
                }
                else
                {
                    btnCliente.Text = Operacao.Entidade;
                }
                
            }
          
        }

        private void VerificarPErmissaoDeFacturacao()
        {
            var dadosGerais = _definicoesGeraisApp.ListarGerais(null);
            PermitirVenderSemStock = dadosGerais.FirstOrDefault().StateVenderSemStock;
        }

        private void carregarArtigosSemPagamentos()
        {
            if (Equals(Documento, null) || Documento.codigo <= 0)
            {
                Documento = _documentosApp.GetUltimoDocumento(OperacaoApp, EstadoDocumento);
            }
            carregarArtigoVenderByIdDocumento();
            setIndexArtidoVender();
        }

        private void carregarObservacaoDeAnulamento()
        {
            if (UtilidadesGenericas.InEnumStdDoc(Documento.Estado) == TipoEstadoDocumento.ANULADO)
            {
                Anulado = _documentosApp.GetAnuladosPor(Documento.codigo);
                //btnObservacoes.Visible = true;
                //btnObservacoes.Enabled = true;
                txtObservacoes.Text = Anulado.Motivo;
                txtCodUsuario.Text = Anulado.Usuario.codigo.ToString();
                txtUsuario.Text = Anulado.Usuario.Login;
                txtPor.Text = Anulado.Usuario.Nome;
                dateDataHora.EditValue = Anulado.Data + " " + Anulado.Hora;
            }
        }

        private void carregarArmazem()
        {
            ListaArmazens = _armazemApp.GetAll();

              if(InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate {
                        CboArmazens.Properties.Items.Add("Todos");
                        foreach (var item in ListaArmazens) CboArmazens.Properties.Items.Add(item.descricao);
                        CboArmazens.SelectedItem = "GERAL";
                    }));
            }
            else
            {
                CboArmazens.Properties.Items.Add("Todos");
                foreach (var item in ListaArmazens) CboArmazens.Properties.Items.Add(item.descricao);
                CboArmazens.SelectedItem = "GERAL";
            }
                   
            indexCategoria = 0;
        }
        private void btnConveteLista_Click(object sender, EventArgs e)
        {
            if (navigationArtigos.SelectedPage == pageArtigoCartao)
            {
                navigationArtigos.SelectedPage = pageArtigoList;

            }
            else if(navigationArtigos.SelectedPage == pageArtigoList)
            {
                navigationArtigos.SelectedPage = pageArtigoCartao;
            }
        }
        private void btnConverteCartao_Click(object sender, EventArgs e)
        {
            navigationArtigos.SelectedPage = pageArtigoCartao;
        }
        private void txtProcurar_EditValueChanged(object sender, EventArgs e)
        {

            GradeArtigoCartao.DataSource = Artigos.Where(a => a.descricao.ToLower().ToUpper().Contains(txtProcurar.Text.ToLower().ToUpper())).ToList();
            GradeArtigo.DataSource = _Artigos.Where(a => a.Familia.ToLower().ToUpper().Contains(txtProcurar.Text.ToLower().ToUpper()) ||
                                                         a.NomeArtigo.ToLower().ToUpper().Contains(txtProcurar.Text.ToLower().ToUpper()) ||
                                                         a.Preco.ToString().Contains(txtProcurar.Text.ToLower().ToUpper()) ||
                                                         a.NomeArmazem.ToLower().ToUpper().Contains(txtProcurar.Text.ToLower().ToUpper())).ToList();
        }
        private void tileView1_ItemClick(object sender, TileViewItemClickEventArgs e)
        {
            if (Tipo == TipoCatgoria.Categoria)
            {
                indexCategoria = e.Item.RowHandle;
                testeCarregarArtigosEmGrid();
            }
            else if(Tipo == TipoCatgoria.Default)
            {
                txtCodigoBarra.Text = string.Empty;
                indexArtigo = e.Item.RowHandle;
                addArtigoListaVenda();
            }
        }

        private void addArtigoListaVenda()
        {

            if (CboArmazens.SelectedIndex == 0)
            {
                UtilidadesGenericas.MsgShow("Selecione um Armazem!");
            }
            else
            {
                var codArtigo = Convert.ToInt16(Modolista.GetRowCellValue(indexArtigo, "codigo").ToString());
                ProdutoStockViewModel artigo = null;
                if (!string.IsNullOrEmpty(txtCodigoBarra.Text))
                {
                    artigo = ArtigosStock.Where(a => a.Artigo.Barra == txtCodigoBarra.Text).FirstOrDefault();
                    if (Equals(artigo, null))
                    {
                        UtilidadesGenericas.MsgShow("Artigo não encontrado!");
                    }
                }
                else
                {
                    artigo = ArtigosStock.Where(a => a.codigo == codArtigo).FirstOrDefault();
                } 
                if (NotRequisitosAddArtigo(artigo))
                    return;
                if (!Equals(null, artigo))
                {
                    var oldArtigo = ArtigosVender.Where(a => a.Artigo.codigo == artigo.codigo).FirstOrDefault();
                    decimal qtd = 1;
                    if (!validQtdStock(artigo, oldArtigo))
                        return;
                    if (Equals(null, oldArtigo))
                    { 
                        var movArtigo = lancarArtigo(artigo, qtd);
                        var isencao = _movArtigosApp.GetMotivoDeIsencao(movArtigo);
                        UpdateComposicao(movArtigo, qtd);
                        oldArtigo = new VendaViewModel() {
                            Artigo = movArtigo.ArtigoStock,
                            codigo = movArtigo.codigo,
                            CodProduto = movArtigo.ArtigoStock.Artigo.Codigo,
                            qtde = qtd,
                            Entidade = Consumidor,
                            MovArtigo = movArtigo,
                            Referencia = Equals(isencao, null)? "--": isencao.Referencia
                        };

                        ArtigosVender.Add(oldArtigo);

                        if (UtilidadesGenericas.InEnumMov(Operacao.MovStk) == TipoMov.DEBITO)
                        {
                            acertarSaidaDeArtigoStock(artigo, qtd);
                            UpdateComposicao(oldArtigo.MovArtigo, 1.0m);

                        }
                    }
                    else
                    {
                        DevolverComposicoes(oldArtigo.MovArtigo, oldArtigo.MovArtigo.Qtdade);
                        oldArtigo.qtde++;
                        EditarLancamentoArtigo(oldArtigo, oldArtigo.qtde, oldArtigo.MovArtigo.codigo);
                        if (UtilidadesGenericas.InEnumMov(Operacao.MovStk) == TipoMov.DEBITO)
                        {
                            acertarSaidaDeArtigoStock(artigo, 1);
                            UpdateComposicao(oldArtigo.MovArtigo, oldArtigo.qtde);
                        }
                    }
                    gradeArtigoVender.DataSource = newInstanceThisList(ArtigosVender);
                    addValoresControlersTotal(getValorTotal());
                    setIndexArtidoVender();
                }
            }
        }

        private void UpdateComposicao(MovProdutosViewModel movArtigo, decimal qtd)
        {
            if (!Equals(movArtigo, null))
            {
                var tmpQtd = movArtigo.Qtdade;
                movArtigo.Qtdade = qtd;
                _stockApp.MudarQtdComposicao(movArtigo);
                movArtigo.Qtdade = tmpQtd;
            }
        }
        public void DevolverComposicoes(MovProdutosViewModel movArtigo, decimal qtd)
        {
            var tmpQtd = movArtigo.Qtdade;
            movArtigo.Qtdade = qtd;
            if (UtilidadesGenericas.InEnumMov(movArtigo.Documento.Operacao.MovStk) == TipoMov.CREDITO)
            {
                movArtigo.Documento.Operacao.MovStk = "DEBITO";
                UpdateComposicao(movArtigo, movArtigo.Qtdade);
            }
            else if (UtilidadesGenericas.InEnumMov(movArtigo.Documento.Operacao.MovStk) == TipoMov.DEBITO)
            {
                movArtigo.Documento.Operacao.MovStk = "CREDITO";
                UpdateComposicao(movArtigo, movArtigo.Qtdade);
            }
            movArtigo.Qtdade = tmpQtd;
        }
        private bool NotRequisitosAddArtigo(ProdutoStockViewModel artigo)
        {
            if ((Equals(Consumidor, null) || Consumidor.Codigo <= 0) && UtilidadesGenericas.InEnum(Operacao.Entidade) != TypeEntity.ISENTO)
            {
                Consumidor = _entidadeApp.GetById(2);
            }
            var ftConsumidor = Consumidor;
            if (!SeNaoTemDocumento())
            {
                ftConsumidor = Documento.Entidade;
            }
            if ((OperacaoApp == "FT") && ftConsumidor.Nome == "CLIENTE INDIFERENCIADO")
            {
                UtilidadesGenericas.MsgShow("Informe uma Entidade  diferente \n do CLIENTE INDIFERENCIADO!");
                return true;
            }
            if (Equals(artigo, null))
            {
                return true;
            }
            if (UtilidadesGenericas.InEnumMov(Operacao.MovStk) != TipoMov.ISENTO && artigo.Artigo.movimentaStock != 1)
            {
                UtilidadesGenericas.MsgShow("Erro","Artigo com insuficiencia de stock!",MessageBoxIcon.Error, MessageBoxButtons.OK);
                return true;
            }
            if (UtilidadesGenericas.InEnumMov(Operacao.MovStk) != TipoMov.ISENTO &&
                UtilidadesGenericas.InEnumMov(Operacao.MovFin) != TipoMov.ISENTO && artigo.Artigo.Vender != 1)
            {
                UtilidadesGenericas.MsgShow("Erro", "Artigo não é permitido a Vender!", MessageBoxIcon.Error, MessageBoxButtons.OK);
                return true;
            }
            if (UtilidadesGenericas.InEnum(Operacao.Entidade) != TypeEntity.ISENTO)
            {
                if (UtilidadesGenericas.ListaNula(ArtigosVender))
                {
                    var limit = 0.0m;
                    if (!string.IsNullOrEmpty(Consumidor.Limite))
                    {
                        limit = Convert.ToDecimal(Consumidor.Limite);
                    }
                    if (Operacao.Nome == "FACTURA" &&
                        limit < artigo.Artigo.preco1)
                    {
                        UtilidadesGenericas.MsgShow("Este " + Operacao.Entidade + " excedeu o limite do debito definido ");
                        return true;
                    }
                }
                else 
                {
                    var precoArtigoPagar = artigo.Artigo.preco1 + (artigo.Artigo.preco1 * (artigo.Artigo.EntityImposto.Percentagem / 100));
                    var oldArtigo = ArtigosVender.Where(a => a.Artigo.codigo == artigo.codigo).FirstOrDefault();
                    if (!Equals(oldArtigo, null))
                    {
                        precoArtigoPagar = oldArtigo.Artigo.Artigo.preco1 + (oldArtigo.Artigo.Artigo.preco1 * (oldArtigo.Artigo.Artigo.EntityImposto.Percentagem / 100));
                        precoArtigoPagar = precoArtigoPagar - (oldArtigo.Artigo.Artigo.preco1 * (oldArtigo.Desconto / 100));
                        precoArtigoPagar *= (oldArtigo.qtde);

                    }
                    if (Operacao.Nome == "FACTURA" && 
                        Convert.ToDecimal(Consumidor.Limite) < getValorTotal() + precoArtigoPagar)
                    {
                        
                        UtilidadesGenericas.MsgShow("Erro", "Este " + Operacao.Entidade + "\n excedeu o limite do debito definido ", MessageBoxIcon.Error, MessageBoxButtons.OK);
                        return true;
                    }
                }
            }
            if (DataSistemaIncorrecta())
            {
                UtilidadesGenericas.MsgShow("Erro", "Não é possível Criar " + Operacao.Entidade + ", pois a data do sistema está imcorrecta!", MessageBoxIcon.Error, MessageBoxButtons.OK);
                return true;
            }
            return false;
        }

        private bool DataSistemaIncorrecta()
        {
            var ultimoDocumento = _documentosApp.GetById(_documentosApp.GetCodLast());
            if (Equals(ultimoDocumento, null) || ultimoDocumento.codigo <= 0 || ultimoDocumento.CodOperacao <= 0)
            {
                return false;
            }
            var dataUltimo =UtilidadesGenericas.GetDataFormatoCorreto(ultimoDocumento.Data, ultimoDocumento.Hora);
            var intervalo = DateTime.Now.Subtract(dataUltimo);
            if (intervalo.Hours < 0 || intervalo.Days < 0)
            {
                return true;
            }
            return false;
        }

        private void acertarQtdCreditoStock()
        {
            if (UtilidadesGenericas.InEnumMov(Operacao.MovStk) == TipoMov.CREDITO)
            {
                foreach (var item in ArtigosVender)
                {
                    acertarEntradaArtigoStock(item.Artigo, item.qtde);
                    _stockApp.MudarQtdComposicao(item.MovArtigo);
                }
            }
        }

        private void setIndexArtidoVender()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    if (ArtigosVender.Count > 0)
                    {
                        indexArtigoVender = 0;
                        var movArtigoSelecionado = GetMovArtigoSelecionado();
                        if (movArtigoSelecionado.Qtdade == "UNIDADE")
                        {
                            btnQtd.Enabled = false;
                        }
                        else
                        {
                            btnQtd.Enabled = true;
                        }

                    }
                }));
            }
            else
            {
                if (ArtigosVender.Count > 0)
                {
                    indexArtigoVender = 0;
                    var movArtigoSelecionado = GetMovArtigoSelecionado();
                    if (movArtigoSelecionado.Qtdade == "UNIDADE")
                    {
                        btnQtd.Enabled = false;
                    }
                    else
                    {
                        btnQtd.Enabled = true;
                    }

                }
            }
        }

        private bool validQtdStock(ProdutoStockViewModel artigo, VendaViewModel oldArtigo)
        {
            if (Equals(artigo, null))
            {
                return true;
            }
            if (!_stockApp.PodeMudarQtdArtigoComposicao(artigo, Operacao))
            {
                return true;
            }
            bool valid = true;
            var qtd = Equals(oldArtigo, null) ? 1 : oldArtigo.qtde;
            var qtdLimite = artigo.qtde - artigo.stockMin;
            if (UtilidadesGenericas.InEnumMov(Operacao.MovStk) == TipoMov.DEBITO)
                valid = validarEmDebito(qtdLimite, qtd);
            else if (UtilidadesGenericas.InEnumMov(Operacao.MovStk) == TipoMov.CREDITO)
                valid = validarEmCredito(artigo.stockMax, qtd);
                    
            return valid;
        }

        private bool validarEmCredito(decimal stockMax, decimal qtdEntrar)
        {
            if (PermitirVenderSemStock)
            {
                return true;
            }
            if (qtdEntrar > stockMax)
            {
                UtilidadesGenericas.MsgShow("Erro","Quantidade maxima do Artigo é " + stockMax, MessageBoxIcon.Error, MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private bool validarEmDebito(decimal qtdLimite, decimal qtdSair)
        {
            if (PermitirVenderSemStock)
            {
                return true;
            }
            if (qtdLimite <= 0)
            {

                UtilidadesGenericas.MsgShow("Artigo com insuficiente de stock");
                return false;
            }
            else if (qtdSair > qtdLimite)
            {
                UtilidadesGenericas.MsgShow("Erro", "Quantidade do Artigo tem de ser Menor ou iqual que " + qtdLimite, MessageBoxIcon.Error, MessageBoxButtons.OK);

                return false;
            }
            return true;
        }

        private void addValoresControlersTotal(decimal valor)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    labelTotal.Text = valor.ToString("N3") + " AKZ";
                    labelDesconto.Text = GetTotalDescontos().ToString("N3") + " AKZ";
                }));
            }
            else
            {
                labelTotal.Text = valor.ToString("N3") + " AKZ";
                labelDesconto.Text = GetTotalDescontos().ToString("N3") + " AKZ";
            }
           // _documentosApp.Update(Documento);
        }

        private decimal GetTotalDescontos()
        {
            if (UtilidadesGenericas.ListaNula(ArtigosVender))
                return 0;
            Documento.Desconto = 0;
            Documento.Imposto = 0;

            foreach (var item in ArtigosVender)
            {
                Documento.Desconto += (item.Preco * (item.Desconto / 100)) * item.qtde;
                Documento.Imposto += (item.Preco * (item.MovArtigo.Imposto / 100)) * item.qtde;
            }
            var total = 0.0m;
            if (!Equals(Documento, null))
            {
                total = Documento.Total;
            }
            Documento.Desconto += total * (DescontoGeral / 100);
            return Documento.Desconto;
        }

        private decimal getValorTotal()
        {
            decimal valor = 0.0m;
            var totalDesconto = 0.0m;
            if (UtilidadesGenericas.ListaNula(ArtigosVender))
                return 0;
            Documento.TotalIliquido = 0.0m;

            foreach (var item in ArtigosVender)
            {
                valor += item.Total;
                Documento.TotalIliquido += item.Preco * item.qtde;
                totalDesconto += item.Desconto;
                item.NomeFumcionario = UtilidadesGenericas.NomeEntidade;
                item.NomeCliente = Equals(Consumidor, null) || Consumidor.Codigo <= 0 ? item.NomeCliente : Consumidor.Nome;
            }
            Documento.Total = (valor - (valor * (DescontoGeral / 100)));
            return Documento.Total;
        }

        private void EditarLancamentoArtigo(VendaViewModel artigo, decimal qtd, int id)
        {
            Documento = CriarNovoDocumento();
            CarregarNomeOperacao();
            if (indexArmazem > 0)
            {
                indexArmazem -= 1;
            }
            if (Equals(artigo.Artigo, null))
            {
                _movArtigosApp.UpdateOld(new MovProdutosViewModel()
                {
                    codigo = id,
                    CodDocumento = Documento.codigo,
                    Desconto = artigo.MovArtigo.Desconto,
                    Imposto = artigo.MovArtigo.Imposto,
                    Qtdade = qtd,
                    Preco = artigo.MovArtigo.Preco,
                    Retencao = artigo.MovArtigo.Retencao,
                    Total = artigo.MovArtigo.Preco * qtd,
                    Descricao = artigo.MovArtigo.Descricao,
                    DescontoGeral = DescontoGeral

                });
            }
            else
            {
                _movArtigosApp.Update(new MovProdutosViewModel()
                {
                    codigo = id,
                    CodArmazem = ListaArmazens[indexArmazem].codigo,
                    CodDocumento = Documento.codigo,
                    CodProduto = artigo.Artigo.Artigo.Codigo,
                    Custo = artigo.Artigo.Artigo.custo,
                    Desconto = artigo.Desconto,
                    Imposto = artigo.Artigo.Artigo.EntityImposto.Percentagem,
                    Qtdade = qtd,
                    Preco = artigo.Artigo.Artigo.preco1,
                    Retencao = artigo.Artigo.Artigo.Retencao,
                    Total = UtilidadesGenericas.CalcularTotal(
                        artigo.Artigo.Artigo.preco1,
                        qtd,
                        artigo.Artigo.Artigo.EntityImposto.Percentagem,
                        artigo.Desconto
                    ),
                    Descricao = artigo.Artigo.Artigo.descricao,
                    ArtigoStock = artigo.MovArtigo.ArtigoStock,
                    CodStock = artigo.MovArtigo.CodStock,
                    DescontoGeral = DescontoGeral

                });
            }

        }

        private MovProdutosViewModel lancarArtigo(ProdutoStockViewModel artigo, decimal qtd)
        {
            Documento = CriarNovoDocumento();
            CarregarNomeOperacao();
            if (indexArmazem > 0)
            {
                indexArmazem -= 1;
            }
            if (Equals(artigo.Artigo, null))
            {
                _movArtigosApp.UpdateOld(new MovProdutosViewModel()
                {
                    //codigo = id,
                    //CodDocumento = Documento.codigo,
                    //Desconto = 0,
                    //Imposto = 0,
                    //Qtdade = qtd,
                    //Preco = artigo.Artigo.preco1,
                    //Retencao = artigo.Artigo.Retencao,
                    //Total = artigo.MovArtigo.Preco * qtd,
                    //Descricao = artigo.MovArtigo.Descricao,
                    //DescontoGeral = DescontoGeral

                });
            }
            else
            {
                _movArtigosApp.Insert(new MovProdutosViewModel()
                {
                    CodArmazem = artigo.CodArmazem,
                    CodDocumento = Documento.codigo,
                    CodProduto = artigo.Artigo.Codigo,
                    Custo = artigo.Artigo.custo,
                    Desconto = 0,
                    Imposto = artigo.Artigo.EntityImposto.Percentagem,
                    Qtdade = qtd,
                    Preco = artigo.Artigo.preco1,
                    Retencao = artigo.Artigo.Retencao,
                    Total = UtilidadesGenericas.CalcularTotal(
                        artigo.Artigo.preco1,
                        qtd,
                        artigo.Artigo.EntityImposto.Percentagem,
                        0),
                    Descricao = artigo.Artigo.descricao,
                    ArtigoStock = artigo,
                    CodStock = artigo.codigo,
                    DescontoGeral = DescontoGeral,
                    CodImposto = artigo.Artigo.EntityImposto.Sigla,
                    TipoImposto = artigo.Artigo.EntityImposto.Tipo.Sigla,
                    DescricaoImposto = artigo.Artigo.EntityImposto.Descricao

                });
            }
            return _movArtigosApp.GetById(_movArtigosApp.GetCodLast());
        }

        private DocumentosViewModel CriarNovoDocumento()
        {
            UtilidadesGenericas.Alterou = true;
            if (SeNaoTemDocumento())
            {
                var consumidorId = (!Equals(Consumidor, null) && Consumidor.Codigo > 0) ? Consumidor.Codigo : 2;
                var documentLast = _documentosApp.GetById(_documentosApp.GetCodDocumentoLastPorCodOperacao(OperacaoId));
                var novoNumeroOrdem = Equals(documentLast, null) ? 1 : documentLast.NumeroOrdem + 1;
                var entidadeId = 2;
                var nomeCliente = "CLIENTE INDIFERENCIADO";
                ContactosViewModel telCliente = null;
                MoradaViewModel moradaCliente = null;
                if (!Equals(Consumidor, null))
                {
                    telCliente = _entidadeApp.GetTelefoneByEntidade(Consumidor.Codigo.ToString());
                    moradaCliente = _entidadeApp.GetMoradaByEntidade(Consumidor.Codigo.ToString());
                    entidadeId = Consumidor.Codigo;
                    nomeCliente = Consumidor.Nome;
                }


                var data = DateTime.Now;
                var hora = DateTime.Now.ToShortTimeString();
                _documentosApp.Insert(new DocumentosViewModel()
                {
                    CodOperacao = OperacaoId,
                    Mascara = SubMascara + novoNumeroOrdem,
                    Estado = "ABERTO",
                    CodEntidade = consumidorId,
                    CodUsuario = UtilidadesGenericas.UsuarioCodigo,
                    Total = 0,
                    Descritivo = "Edição do documento " + Operacao.Nome,
                    NomeCliente = nomeCliente,
                    NumeroOrdem = novoNumeroOrdem,
                    Data = data,
                    Hora = hora,
                    CodArea = 2,
                    CodMesa = 0,
                    CodTurno = UtilidadesGenericas.CodigoTurno,
                    Emitido = "Não Imprimido",
                    DataVencimento = UtilidadesGenericas.GetDataVencimento(30),
                    NifCliente = Consumidor.Nif,
                    TelCliente = Equals(telCliente, null) ? string.Empty : telCliente.descricao,
                    MoredaCliente = Equals(moradaCliente, null) ? string.Empty : moradaCliente.DescricaoMorada
                });

                return _documentosApp.GetById(_documentosApp.GetCodLast());
            }
            return Documento;
        }


        private void messageShow(string message)
        {
            UtilidadesGenericas.MsgShow(
                "MENSAGEM",
                message, 
                MessageBoxIcon.Information, 
                MessageBoxButtons.OK
            );
        }
        private void testeCarregarArtigosEmGrid()
        {
            loadArtigos();
            renderizeForArtigos();
            if (Tipo == TipoCatgoria.Categoria)
            {
                carregarPorArmazem();
                carregarPorCategoria();

                Tipo = TipoCatgoria.Default;
                GradeArtigo.DataSource = _Artigos;
                GradeArtigoCartao.DataSource = Artigos;
            }
            else
            {
                GradeArtigo.DataSource = _Artigos;
                GradeArtigoCartao.DataSource = Artigos;
            }
        }
        private void carregarPorArmazem()
        {
            if(indexArmazem > 0)
            {
                var armazem = ListaArmazens[indexArmazem - 1];
                Artigos = Artigos.Where(a => a.Armazem.codigo == armazem.codigo).ToList();
                _Artigos = _Artigos.Where(a => a.Armazem.codigo == armazem.codigo).ToList();

            }
        }
        private void carregarPorCategoria()
        {
            if (!UtilidadesGenericas.ListaNula(Categorias) && Equals(Categorias[indexCategoria].descricao, "Todos"))
            {
                return;
            }
            if (!UtilidadesGenericas.ListaNula(Categorias) && indexCategoria > -1)
            {
                var categaria = Categorias[indexCategoria];
                Artigos = Artigos.Where(a => a.Artigo.Familia.codigo == categaria.codigo).ToList();
                _Artigos = _Artigos.Where(a => a.Artigo.Familia.codigo == categaria.codigo).ToList();
            }
        }

        private void zerarAsGrids()
        {
            GradeArtigo.DataSource = null;
            GradeArtigoCartao.DataSource = null;
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            
        }
        private void renderizeForArtigos()
        {
            foreach (GridColumn item in Modolista.Columns)
            {
                if (!item.Name.Equals("gridColumnDescricao") &&
                    !item.Name.Equals("gridColumnCodigo"))
                {
                    item.Visible = true;
                }
            }
            gridColumnCodigo.FieldName = "codigo";
            gridColumnDescricao.FieldName = "NomeArtigo";
            gridColumnaArmazem.FieldName = "NomeArmazem";
            gridColumnPreco.FieldName = "Preco";
            gridColumnQtd.FieldName = "qtde";
            gridColumnFamilia.FieldName = "Familia";
            gridColumnCusto.FieldName = "Custo";
            gridColumnImposto.FieldName = "Imposto";

        }

        private void loadArtigos()
        {
            Artigos = _stockApp.GetArtigoCards();
            ArtigosStock = _stockApp.GetAll();
            _Artigos = _stockApp.GetArtigos();
        }

             
        private void CboArmazens_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tipo = TipoCatgoria.Categoria;
            indexArmazem = CboArmazens.SelectedIndex;
            testeCarregarArtigosEmGrid();
        }

        private void Modolista_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (Tipo == TipoCatgoria.Categoria)
            {
                indexCategoria = e.RowHandle;
                testeCarregarArtigosEmGrid();
            }
            else if (Tipo == TipoCatgoria.Default)
            {
                txtCodigoBarra.Text = string.Empty;
                indexArtigo = e.RowHandle;
                addArtigoListaVenda();
            }
        }

        private void btnGravarVenda_Click(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.ListaNula(ArtigosVender)|| Equals(Documento, null))
            {
                return;
            }
            if ((Equals(Documento, null) || Documento.Entidade.Codigo <= 0) && UtilidadesGenericas.InEnum(Operacao.Entidade) != TypeEntity.ISENTO)
            {
                messageShow("Informe Um " + Operacao.Entidade);
                return;
            }
            if ((Equals(Documento.Entidade, null) || Documento.Entidade.Codigo <= 0))
            {
                Consumidor = _entidadeApp.GetById(2);
            }
            if (OperacaoApp == "FT" && Documento.Entidade.Nome == "CLIENTE INDIFERENCIADO")
            {
                UtilidadesGenericas.MsgShow("Selecione uma Entidade \n diferente de  CLIENTE INDIFERENCIADO" );
                return;
            }

            if (inserirNomeCliente())
            {
                ArtigosVender[0].Entidade = Consumidor;
                if (OperacaoApp == "FT" || UtilidadesGenericas.InEnumMov(Operacao.MovFin) == TipoMov.ISENTO)
                {
                    labelDesconto.Text = "0,00";
                    //labelSubTotal.Text = "0,00";
                    lblTotalDesconto.Text = "0,00";
                    MudarEmitidoDocumento();
                    ArtigosVender[0].MovArtigo.Documento = null;
                    ArtigosVender[0].MovArtigo.Documento = Documento;
                    IOC.InjectForm<frmImprimirReport>().ImprimirDocumentoVenda(ArtigosVender);
                    acertarQtdCreditoStock();
                    fecharItensExistentes();
                    Facturado = true;
                    fecharDocumento();
                    carregarArtigoVenderByIdDocumento();
                    btnCategoria_Click(sender, e);
                }
                else
                {
                    Documento.Total = getValorTotal();
                    var totalDesconto = Convert.ToDecimal(labelDesconto.Text.Replace("AKZ", string.Empty).Trim());
                    if (IOC.InjectForm<frmReceberPagamentos>().ReceberPagmentoDocumento(Documento, totalDesconto))
                    {
                        labelDesconto.Text = "0,00";
                        //labelSubTotal.Text = "0,00";
                        MudarEmitidoDocumento();
                        ArtigosVender[0].MovArtigo.Documento = null;
                        ArtigosVender[0].MovArtigo.Documento = Documento;
                        ArtigosVender[0].ContaPagamento = GetPagamento(Documento.codigo);

                        IOC.InjectForm<frmImprimirReport>().ImprimirDocumentoVenda(ArtigosVender);
                        acertarQtdCreditoStock();
                        fecharItensExistentes();
                        Facturado = true;
                        fecharDocumento();
                        carregarArtigoVenderByIdDocumento();
                        btnCategoria_Click(sender, e);
                    }
                }

                UtilidadesGenericas.Alterou = true;
            }
        }

        private ContasBancariasViewModel GetPagamento(int codigo)
        {
            var pagamentos = _pagamentosApp.GetAllByDoc(codigo);
            PagamentosViewModel pagamento = new PagamentosViewModel();
            for (int i = pagamentos.Count -1; i >= 0 ; i--)
            {
                var conta = pagamentos[i].Forma.Conta;
                if (!Equals(conta, null) && conta.codigo > 0)
                {
                    pagamento = null;
                    pagamento = pagamentos[i];
                }
            }
            return pagamento.Forma.Conta;
        }

        private void MudarEmitidoDocumento()
        {
           Documento.Emitido = UtilidadesGenericas.MudarEmitidoDocumento(Documento.Emitido);
            _documentosApp.Update(Documento);
        }

        private void fecharItensExistentes()
        {
            foreach (var item in ArtigosVender)
            {
                if (!Equals(item.MovArtigo.ArtigoAbstrato, null) && item.MovArtigo.ArtigoAbstrato.Contains("?"))

                {
                    var thisItem = new ItemViewModel(item.MovArtigo.ArtigoAbstrato);
                    if (Equals(thisItem, null) || thisItem.Id <= 0)
                    {
                        continue;
                    }
                    int codAtendimento = thisItem.IdPai;
                    var itemFac = _AtendimentoHospitalarApp.GetItemFactura(thisItem.Tipo, thisItem.Id);

                    if (itemFac.Tipo.Contains("Consulta"))
                    {
                        _ConsultaHospitalarApp.FecharFacturar(new ConsultaHospitalar()
                        {
                            Codigo = itemFac.ItemId,
                            Facturado = "Sim"
                        });
                    }
                    else if (itemFac.Tipo.Contains("Exame"))
                    {
                        _ExamesApp.FecharFacturar(new ExamesHospitalar()
                        {
                            Codigo = itemFac.ItemId,
                            Facturado = "Sim"
                        });
                    }
                    else if (itemFac.Tipo.Contains("Internamento"))
                    {
                        _InternamentoApp.Update(new PacienteInternado()
                        {
                            Facturado = "Sim",
                            Codigo = itemFac.ItemId
                        });
                    }
                }
            }
        }

        private bool inserirNomeCliente()
        {
            if ((Operacao.Nome == "FACTURA RECIBO" || Operacao.Nome == "COMPRA A FORNECEDOR") && 
                (Consumidor.Nome == "CLIENTE INDIFERENCIADO" || Consumidor.Nome == "FORNECEDOR INDIFERENCIADO") &&
                (Documento.NomeCliente == "CLIENTE INDIFERENCIADO" || Documento.NomeCliente == "FORNECEDOR INDIFERENCIADO"))
            {
                var nomeCliente = new frmBuscaNomeCliente().GetNomeCliente(Consumidor.Nome);
                if (!string.IsNullOrEmpty(nomeCliente))
                {
                    Consumidor.Nome = nomeCliente;
                    ArtigosVender[0].NomeCliente = nomeCliente;
                    Documento.NomeCliente = nomeCliente;
                    labelConsumidor.Text = nomeCliente;
                    _documentosApp.Update(Documento);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void fecharDocumento()
        {
            UtilidadesGenericas.Alterou = true;
            Documento.Estado = "FECHADO";
            if (Documento.Operacao.APP != "FT")
            {
                Documento.Liquidado = "SIM";
            }
            Documento.Total = getValorTotal();
            Documento.NomeCliente = Consumidor.Nome;
            Documento.DataVencimento = UtilidadesGenericas.GetDataVencimento(Consumidor.Condicao.Dias);
            SetHashDocumento();
            _documentosApp.Update(Documento);
            clearGradeVender();
            esvaziarElements();
        }

        private void clearGradeVender()
        {
            Documento = null;
            Consumidor = _entidadeApp.GetById(2);
            ArtigosVender.Clear();
            gradeArtigoVender.DataSource = null;
            addValoresControlersTotal(getValorTotal());
            ListaComissoes = new List<ComissaoViewModel>();
            gradeComissoes.DataSource = null;
            labelConsumidor.Text = Consumidor.Nome;
            CarregarNomeOperacao();
        }

        private void acertarSaidaDeArtigoStock(ProdutoStockViewModel artigoStock, decimal qtdSair)
        {
            if (Equals(artigoStock, null) /*|| PermitirVenderSemStock*/)
            {
                return;
            }
            int stockId = artigoStock.codigo;
             if (!Equals(artigoStock, null))
            {
                artigoStock = null;
                artigoStock = _stockApp.GetById(stockId);
                artigoStock.qtde -= qtdSair;
                _stockApp.Update(artigoStock);
            }
        }
        private void acertarEntradaArtigoStock(ProdutoStockViewModel artigoStock, decimal qtdEntrar)
        {
            if (Equals(artigoStock, null) /*|| PermitirVenderSemStock*/)
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
        private void SetHashDocumento()
        {
            if (Documento.Operacao.APP != "PP" && Documento.Operacao.APP != "ADM")
            {
                var codAGT = Documento.Operacao.APP + " " + DateTime.Now.Year + "/" + Documento.NumeroOrdem;
                Documento.Hash = UtilidadesGenericas.GerarHash(UtilidadesGenericas.GetDadosHash(Documento.Data, Documento.Hora, codAGT, Documento.Total));
                var lengthHash = Documento.Hash.Length;
            }

        }
        private void ActualizarDadosClienteNoDoc()
        {
            var telCliente = _entidadeApp.GetTelefoneByEntidade(Documento.Entidade.Codigo.ToString());
            var moradaCliente = _entidadeApp.GetMoradaByEntidade(Documento.Entidade.Codigo.ToString());
            if (string.IsNullOrEmpty(Documento.NifCliente) || Documento.NifCliente == "999999999")
            {
                Documento.NifCliente = Documento.Entidade.Nif;
            }
            if (!Equals(telCliente, null) && string.IsNullOrEmpty(Documento.TelCliente))
            {
                Documento.TelCliente = telCliente.descricao;
            }
            if (!Equals(moradaCliente, null) && string.IsNullOrEmpty(Documento.MoredaCliente))
            {
                Documento.MoredaCliente = moradaCliente.DescricaoMorada;
            }
            _documentosApp.Update(Documento);
        }
        private void carregarArtigoVenderByIdDocumento()
        {
            if (!ExisteDocumento()) return;
            if (UtilidadesGenericas.InEnumStdDoc(EstadoDocumento) == TipoEstadoDocumento.ANULADO ||
                UtilidadesGenericas.InEnumStdDoc(EstadoDocumento) == TipoEstadoDocumento.FECHADO)
            {
                DesablitarOpcoes();
            }
            ActualizarDadosClienteNoDoc();
            List<MovProdutosViewModel> movArtigos = _movArtigosApp.GetAllByIdDocumento(Documento.codigo);
            Consumidor = Documento.Entidade;
            ArtigosVender = new List<VendaViewModel>();
            foreach (var item in movArtigos)
            {
                var isencao = _movArtigosApp.GetMotivoDeIsencao(item);
                ArtigosVender.Add(new VendaViewModel()
                {
                    MovArtigo = item,
                    Artigo  = item.ArtigoStock, 
                    CodProduto = item.CodProduto,
                    codigo = item.codigo,
                    Entidade = Consumidor,
                    NomeCliente = Documento.NomeCliente,
                    qtde = item.Qtdade,
                    Referencia = Equals(isencao, null) ? "--" : isencao.Referencia
                });
                DescontoGeral = item.DescontoGeral;
            }
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate {
                    gradeArtigoVender.DataSource = ArtigosVender;
                    labelConsumidor.Text = Documento.NomeCliente;
                }));
            }
            else
            {
                gradeArtigoVender.DataSource = ArtigosVender;
                labelConsumidor.Text = Documento.NomeCliente;
            }
        }

        private void gridViewVender_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            indexArtigoVender = e.RowHandle;
            var movArtigoSelecionado = GetMovArtigoSelecionado();
            if (movArtigoSelecionado.Qtdade == "UNIDADE")
            {
                btnQtd.Enabled = false;
            }
            else
            {
                btnQtd.Enabled = true;
            }
            SelecionarTipoValor(e);
        }

        private void SelecionarTipoValor(RowCellClickEventArgs e)
        {
            if (ExisteDocumento()  && (UtilidadesGenericas.InEnumStdDoc(Documento.Estado) == TipoEstadoDocumento.ABERTO ||
                UtilidadesGenericas.InEnumStdDoc(Documento.Estado) == TipoEstadoDocumento.PENDENTE))
            {
                var movArtigoSelecionado = GetMovArtigoSelecionado();
                switch (e.Column.Caption)
                {
                    case "Qtdade":
                        if (movArtigoSelecionado.Qtdade != "UNIDADE")
                        {
                            btnQtd_Click(btnQtd, e);
                        }
                        break;
                    case "Preço":
                        btnPreco_Click(btnPreco, e);
                        break;
                    case "Desc":
                        btnDesconto_Click(btnDesconto, e);
                        break;
                    default:
                        break;
                }
            }
            
        }

        private VendaViewModel GetMovArtigoSelecionado()
        {
            var codMovArtigo = Convert.ToDecimal(gridViewVender.GetRowCellValue(indexArtigoVender, "codigo"));
            var movArtigoSelecionado = ArtigosVender.Where(m => m.codigo == codMovArtigo).FirstOrDefault();

            return movArtigoSelecionado;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            var newConsumidor = IOC.InjectForm<frmEntidadeBusca>().GetEntidadeSelecionada(UtilidadesGenericas.InEnum(Operacao.Entidade));
            if (OperacaoApp == "FT" && !SeTemRequisitosClienteFT(newConsumidor))
            {
                return;
            }
            Consumidor = Equals(newConsumidor, null) || newConsumidor.Codigo == 0 ? Consumidor : newConsumidor;
            labelConsumidor.Text = Consumidor.Nome;
            if (!Equals(Documento, null) && Documento.codigo >= 0)
            {
                Documento.NomeCliente = Consumidor.Nome;
                Documento.Entidade = Consumidor;
                Documento.CodEntidade = Consumidor.Codigo;
                _documentosApp.Update(Documento);
            }
            
        }

        private bool SeTemRequisitosClienteFT(EntidadesViewModel newConsumidor)
        {
            if (newConsumidor.Nome == "CLIENTE INDIFERENCIADO")
            {
                UtilidadesGenericas.MsgShow("Selecione uma Entidade \n diferente de  CLIENTE INDIFERENCIADO");
                return false;
            }
            if (!string.IsNullOrEmpty(newConsumidor.Limite) && 
                Convert.ToInt32(newConsumidor.Limite) > 0 && 
                !SeNaoTemDocumento() &&
                Convert.ToInt32(newConsumidor.Limite) < Documento.Total)
            {
                UtilidadesGenericas.MsgShow("O valor do debito limite do cliente \né inferior ao preço total do documento!");
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Equals(Documento, null))
            {
               UtilidadesGenericas.MsgShow(
                   "ERRO",
                   "Não Existe nemhum documento!", 
                   MessageBoxIcon.Error, 
                   MessageBoxButtons.OK
                );
                return;
            }
            string movito = new frmMotivoAnularDocumento().GetDescricaoDoMotivo();
            if (string.IsNullOrEmpty(movito))
            {
                return;
            }
            devolverQtdArtigosEmStock();
            AnularDocumentoCurrent(movito);
            UtilidadesGenericas.MsgShow(
                "SUCESSO",
                Operacao.Nome +" Cancelada com sucesso!",
                MessageBoxIcon.None,
                MessageBoxButtons.OK
            );
        }
        private void devolverQtdArtigosEmStock()
        {
            if (UtilidadesGenericas.InEnumMov(Operacao.MovStk) == TipoMov.DEBITO)
            {
                foreach (var item in ArtigosVender)
                {
                    acertarEntradaArtigoStock(item.Artigo, item.qtde);
                    DevolverComposicoes(item.MovArtigo, item.qtde);
                }
            }
        }

        private void AnularDocumentoCurrent(string motivo)
        {
            _documentosApp.AnularDocumento(Documento.codigo, UtilidadesGenericas.UsuarioCodigo, motivo);
            UtilidadesGenericas.Alterou = true;
            esvaziarElements();
        }

        private void esvaziarElements()
        {
            Documento = null;
            gradeArtigoVender.DataSource = null;
            ArtigosVender = new List<VendaViewModel>();
            addValoresControlersTotal(getValorTotal());
            labelNumeroDocumento.Text = string.Empty;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(UtilidadesGenericas.ListaNula(ArtigosVender))
            {
                return;
            }
            if (indexArtigoVender <= -1)
            {
                UtilidadesGenericas.MsgShow("Selecione um artigo lista de Venda");

                return;
            }
            if (UtilidadesGenericas.TemCesteza("Tem certesa que pretende eliminar este artigo ?"))
            {
                var artigoVender = GetMovArtigoSelecionado();
                acertarEntradaArtigoStock(artigoVender.Artigo, artigoVender.qtde);
                DevolverComposicoes(artigoVender.MovArtigo, artigoVender.qtde);
                _movArtigosApp.Delete(artigoVender.MovArtigo);
                ArtigosVender.RemoveAt(indexArtigoVender);
                gradeArtigoVender.DataSource = newInstanceThisList(ArtigosVender);
                addValoresControlersTotal(getValorTotal());
                EliminarItemHosp();
            }
        }

        private void EliminarItemHosp()
        {
            if (!UtilidadesGenericas.ListaNula(ItensFactura) && 
                (indexArtigoVender < ItensFactura.Count && 
                indexArtigoVender >= 0) )
            {
                ItensFactura[indexArtigoVender].Eliminar = true;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MudarEmitidoDocumento();
            ArtigosVender[0].MovArtigo.Documento.Emitido = Documento.Emitido;
            int count = Documento.Hash.Length;
            ArtigosVender[0].ContaPagamento = GetPagamento(Documento.codigo);
            if (UtilidadesGenericas.InEnumMov(Documento.Operacao.MovFin) == TipoMov.ISENTO)
            {
                IOC.InjectForm<frmImprimirReport>().ImprimirDocumentoVenda(ArtigosVender);
            }
            else
                IOC.InjectForm<frmImprimirReport>().ImprimirDocumentoVenda(ArtigosVender, true);
        }
        private void DesablitarOpcoes()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate {
                    btnDeixarPendente.Visible = false;
                    btnImprimir.Visible = true;
                    btnQtd.Visible = false;
                    btnPreco.Visible = false;
                    btnEliminar.Visible = false;
                    btnDesconto.Visible = false;
                    btnCliente.Visible = false;
                    btnCancelar.Visible = false;
                    btnDescontoGeral.Visible = false;
                    btnGravarVenda.Visible = false;
                    btnCopiarLinhas.Visible = false;
                    txtCodigoBarra.Enabled = false;
                    btnMenu.Visible = false;
                    comboBoxOperacao.Enabled = false;
                    panelArtigos.Visible = false;
                    panelVenda.Dock = DockStyle.Fill;
                    GradeArtigoCartao.Visible = false;
                    GradeArtigo.Visible = false;
                    panelNavegador.Enabled = false;
                    if (UtilidadesGenericas.InEnumStdDoc(Documento.Estado) == TipoEstadoDocumento.FECHADO)
                    {
                        btnDevolver.Visible = true;
                    }
                    else
                    {
                        btnDevolver.Visible = false;
                    }
                }));
            }
            else
            {

                btnDeixarPendente.Visible = false;
                btnImprimir.Visible = true;
                btnQtd.Visible = false;
                btnPreco.Visible = false;
                btnEliminar.Visible = false;
                btnDesconto.Visible = false;
                btnCliente.Visible = false;
                btnCancelar.Visible = false;
                btnDescontoGeral.Visible = false;
                btnGravarVenda.Visible = false;
                btnCopiarLinhas.Visible = false;
                txtCodigoBarra.Enabled = false;
                btnMenu.Visible = false;
                comboBoxOperacao.Enabled = false;
                panelArtigos.Visible = false;
                panelVenda.Dock = DockStyle.Fill;
                GradeArtigoCartao.Visible = false;
                GradeArtigo.Visible = false;
                panelNavegador.Enabled = false;
                if (UtilidadesGenericas.InEnumStdDoc(Documento.Estado) == TipoEstadoDocumento.FECHADO)
                {
                    btnDevolver.Visible = true;
                }
            }
            //btnComissoes.Visible = false;
            //btnObservacoes.Visible = false;
            //btnPagamentos.Visible = false;
        }

        public bool EfectuarOperacaoDocumento(string app, string estadoDocumento)
        {
            OperacaoApp = app;
            Operacao = _operacoesApp.GetByApp(app);
            OperacaoId = Operacao.codigo;

            labelOperacao.Text = Operacao.Nome.ToUpper();
            SubMascara = Operacao.APP + "/";
            EstadoDocumento = estadoDocumento;
            renderizarControls();
            ShowDialog();
            return Facturado;
        }
        public bool EfectuarOperacaoDocumento(int codDocumento)
        {
            Documento = _documentosApp.GetById(codDocumento);
            OperacaoId = Documento.CodOperacao;
            Operacao = _operacoesApp.GetById(OperacaoId);
            OperacaoApp = Operacao.APP;
            labelOperacao.Text = Operacao.Nome.ToUpper();
            SubMascara = Documento.Operacao.APP;
            EstadoDocumento = Documento.Estado;
            if (UtilidadesGenericas.InEnumStdDoc(EstadoDocumento) == TipoEstadoDocumento.ANULADO ||
                UtilidadesGenericas.InEnumStdDoc(EstadoDocumento) == TipoEstadoDocumento.FECHADO)
            {
                DesablitarOpcoes();
            }
            renderizarControls();
            ShowDialog();
            return Facturado;
        }

        public bool EfectuarOperacaoDocumento(int codDocumento, List<ItemAtendimentoFacturaViewModel> itens)
        {
            ItensFactura = itens;
            return EfectuarOperacaoDocumento(codDocumento);
        }
        private void renderizarControls()
        {
            if (UtilidadesGenericas.InEnumMov(Operacao.MovStk) == TipoMov.CREDITO)
            {
                //btnNovoArtigo.Visible = true;
            }
            if (UtilidadesGenericas.InEnum(Operacao.Entidade) == TypeEntity.ISENTO)
            {
                btnCliente.Visible = false;
            }
        }

        private void btnDeixarPendente_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;

            if (ExisteDocumento() && UtilidadesGenericas.TemCesteza("Tem certeza que prentendes deixar pendente esta " + Operacao.Nome))
            {
                var descricaoCliente = new frmClienteVenda().DescricaoDeixarPendente();
                if (string.IsNullOrEmpty(descricaoCliente))
                {
                    return;
                }
                _documentosApp.DeixarPendenteDocumento(Documento.codigo, descricaoCliente);
                UtilidadesGenericas.Alterou = true;
                clearGradeVender();

            }else
            {
                UtilidadesGenericas.MsgShow("Não exite um Documento!");
            }
        }

        private bool ExisteDocumento()
        {
            return !Equals(Documento, null);
        }

        private void btnAddFuncionario_Click(object sender, EventArgs e)
        {
            if (ExisteDocumentoAndMsg())
            {
                var entidade = IOC.InjectForm<frmEntidadeBusca>().GetEntidadeSelecionada(TypeEntity.FORNECEDOR);
                if (Equals(entidade, null) || entidade.Codigo <= 0)
                {
                    return;
                }
                _comissoesApp.Insert(new ComissoesViewModel() { codDocumento = Documento.codigo, CodEntidade = entidade.Codigo });
                carregarListaAndGrade();
            }
        }

        private void carregarListaAndGrade()
        {
            carregarListComissoes();
            carregarGradeComissoes();
        }

        private void gridViewComissoes_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            IndexComissao = e.RowHandle;
        }

        private void btnRemoverFucionario_Click(object sender, EventArgs e)
        {
            if (!Equals(ListaComissoes, null) && IndexComissao > -1 && ListaComissoes.Count > 0)
            {
                var comissao = ListaComissoes[IndexComissao];
                _comissoesApp.Delete(new ComissoesViewModel() { codigo = comissao.Codigo });
                carregarListaAndGrade();
            }
        }

        private void btnArtigos_Click(object sender, EventArgs e)
        {
            //if (PercentagemWidthPanelVenda == 100)
            //{
            //    PercentagemWidthPanelVenda = 40;
            //}
            //else
            //{
            //    PercentagemWidthPanelVenda = 100;
            //}
            //renderizarPanelVenda(PercentagemWidthPanelVenda);
        }
        private void renderizarPanelVenda(int percentagem)
        {
            if (percentagem > 100)
            {
                percentagem = 100;
            }
            else if (percentagem < 0)
            {
                percentagem = 0;
            }
            decimal widthPai = navigationPage_PostoVenda.Width;
            //decimal widthPaiLivre = widthPai - accordionControlTipos.Width;
            decimal width = /*widthPaiLivre * */((decimal)percentagem / 100); if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    panelVenda.Size = new System.Drawing.Size((int)width, panelVenda.Size.Height);
                }));
            }
            else
            {
                panelVenda.Size = new System.Drawing.Size((int)width, panelVenda.Size.Height);
            }
        }

        private void accordionControlTipos_Resize(object sender, EventArgs e)
        {
            renderizarPanelVenda(PercentagemWidthPanelVenda);
        }

        private void btnNovoArtigo_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.Busca.Codigo = string.Empty;

            if (  IOC.InjectForm<frmCadastroProdutos>().ChamarComAlt())
            {
                if (Tipo == TipoCatgoria.Categoria)
                {
                    testeCarregarArtigosEmGrid();
                }
                else
                {
                    btnCategoria_Click(sender, e);
                }
            }
        }

        private void gridViewVender_RowClick(object sender, RowClickEventArgs e)
        {
            indexArtigoVender = e.RowHandle;
            var movArtigoSelecionado = GetMovArtigoSelecionado();
            if (movArtigoSelecionado.Qtdade == "UNIDADE")
            {
                btnQtd.Enabled = false;
            }
            else
            {
                btnQtd.Enabled = true;
            }
        }

        private void Modolista_RowClick(object sender, RowClickEventArgs e)
        {

        }

        private void btnDescontoGeral_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;

            if (UtilidadesGenericas.ListaNula(ArtigosVender))
            {
                return;
            }
            var objDescontoGeral = new frmValorNumerico().GetValorPercentual(DescontoGeral, "Desconto Global");
            if (Equals(objDescontoGeral, null))
            {
                return;
            }

            DescontoGeral = Convert.ToDecimal(objDescontoGeral.ToString().Replace(".", ","));
            if (DescontoGeral > 100)
            {
                DescontoGeral = 100.0m;

            }
            if (DescontoGeral < 0)
            {
                DescontoGeral = 0.0m;
            }
            foreach (var item in ArtigosVender)
            {
                item.MovArtigo.DescontoGeral = DescontoGeral;
                _movArtigosApp.UpdateOld(item.MovArtigo);
            }

            addValoresControlersTotal(getValorTotal());
            gradeArtigoVender.DataSource = UtilidadesGenericas.newInstanceThisList(ArtigosVender);
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                addArtigoListaVenda();
            }
        }

        private void btnCopiarLinhas_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;

            if (OperacaoApp == "FT" && Documento.Entidade.Nome == "CLIENTE INDIFERENCIADO")
            {
                UtilidadesGenericas.MsgShow("Selecione uma Entidade \n diferente de  CLIENTE INDIFERENCIADO");
                return;
            }
            if (SeNaoTemDocumento())
            {
                Documento = IOC.InjectForm<frmCopiarLinha>().CopiarLinha(OperacaoApp, Consumidor.Codigo);
                if (!Equals(Documento, null))
                {
                    frmTelaVenda_Load(sender, e);
                }
            }
            else
            {
                 if (IOC.InjectForm<frmCopiarLinha>().CopiarLinha(Documento.codigo))
                {
                    frmTelaVenda_Load(sender, e);
                }
            }
            CarregarNomeOperacao();
            
        }

        private bool SeNaoTemDocumento()
        {
            return Equals(Documento, null) || Documento.codigo <= 0 || Documento.CodOperacao <= 0;
        }

        private void btnFecharDoc_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFecharDoc_MouseHover(object sender, EventArgs e)
        {
            btnFecharDoc.BackColor = Color.Red;

        }

        private void btnFecharDoc_MouseLeave(object sender, EventArgs e)
        {
            btnFecharDoc.BackColor = Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            //loadCategorias();
            //renderizeForCategoria();
            //GradeArtigo.DataSource = Categorias;
            //GradeArtigoCartao.DataSource = Categorias;
            //Tipo = TipoCatgoria.Categoria;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (panelMenu.Visible == false)
            {
                panelMenu.Visible = true;
            }
            else
            {
                panelMenu.Visible = false;


            }
        }
        private void RenderizarOperacoes()
        {
            if (comboBoxOperacao.Properties.Items.Count > 0)
            {
                for (int i = comboBoxOperacao.Properties.Items.Count - 1; i >= 0; i--)
                {
                    if (!UtilidadesGenericas.TemAcesso("Operações#" + comboBoxOperacao.Properties.Items[i].ToString().ToUpper()))
                    {
                        comboBoxOperacao.Properties.Items.Remove(comboBoxOperacao.Properties.Items[i]);
                    }
                }
            }
        }
        private void comboBoxOperaracao_SelectedIndexChanged(object sender, EventArgs e)
        {
            string operacao = comboBoxOperacao.SelectedItem + "";
            var _Operacao = _operacoesApp.GetById(_operacoesApp.GetCodigoOperacaPorNome(operacao));
            if (!Equals(_Operacao, null))
            {
                Dispose();
                IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento(_Operacao.APP, "ABERTO");
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (ExisteDocumento())
            {
                if(IOC.InjectForm<frmDevolverArtigos>().DevolverArtigoDoDocumento(Documento.codigo, this))
                {
                    var codDocumeto = Documento.codigo;
                    Documento = null;
                    Documento = _documentosApp.GetById(codDocumeto);
                    frmTelaVenda_Load(sender, e);
                    SetHashDocumento();
                    _documentosApp.Update(Documento);
                }
            }
            else
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO",
                    "Não é possível Devolver Artigos!", 
                    MessageBoxIcon.Warning, 
                    MessageBoxButtons.OK
                );
            }
        }
    }
}