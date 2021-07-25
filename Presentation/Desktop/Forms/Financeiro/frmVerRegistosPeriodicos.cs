using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Domain.Models.Sistema;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.ViewModels.Frame.Inventario;
using DevExpress.XtraGrid.Views.Grid;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Separadores.Entidades;
using SimpleInjector;
using System.Threading;
using Folha.Presentation.Desktop.Separadores.Sistema;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.ViewModels.Frame.Sistema;
using Folha.Presentation.Desktop.Classe;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmVerRegistosPeriodicos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IVendasApp _VendasApp;
        private readonly ITurnosApp _TurnosApp;
        private readonly IMovArtigosApp _MovArtigosApp;

        private List<RegistoVendasViewModel> lista;
        private List<string> lista2 = new List<string>();
        private int index;
        List<DadosRegistosPeriodicoViewModel> listaDadoGerais;
        List<MostraDocumentoViewModel> LtVenda;

        int Numero;
        string DataAbertura="";
        string DataFecho="";
        //Double SaldoInicial;
        //Double SaldoInformado;
        //int codCaixa;
        double SaldoTotal;
        double SaldoVendas;
        //Double SaldoQuebra;
        //double SaldoHospedagem;

        private int indexClick;
        bool load=false;
        private readonly IDocumentosApp _DocumentosApp;

        public frmVerRegistosPeriodicos(IVendasApp VendasApp, ITurnosApp TurnosApp,IMovArtigosApp MovArtigosApp,IDocumentosApp DocumentosApp)
        {
            Controle.Processamento();
            load = true;
            InitializeComponent();
            _VendasApp = VendasApp;
            _TurnosApp = TurnosApp;
            _MovArtigosApp = MovArtigosApp;
            _DocumentosApp = DocumentosApp;
        }
       
        #region Metodos
        private void ClickDocumento()
        {
            String Documento = "";
            //int indice;

                Documento = gridDocumentos.GetRowCellValue(indexClick, "NomeDocumento").ToString();
                UtilidadesGenericas.Busca.Codigo= gridDocumentos.GetRowCellValue(indexClick, "Codigo").ToString();

            try
            {
               // indice = GradeDocumentos.CurrentRow.Index;
               // String Nome = cboDocumentos.SelectedItem.ToString();
                //int CodDocumento = int.Parse(GradeDocumentos.CurrentRow.Cells[9].Value.ToString());
                //int Numero = int.Parse(GradeDocumentos.CurrentRow.Cells[0].Value.ToString());
                //string Estado = GradeDocumentos.CurrentRow.Cells[7].Value.ToString();

                //if (Documento.Equals("RESERVA"))
                //{
                //    frmRservar Reservar = new frmRservar(Numero.ToString());
                //    Reservar.ShowDialog();
                //    return;
                //}
                //if (Documento.Equals("HOSPEDAGEM"))
                //{
                //    frmHospedagem Hospedagem = new frmHospedagem(Numero.ToString(), Estado, null);
                //    Hospedagem.ShowDialog();
                //    return;
                //}
                //if (Documento.Trim().Equals("VENDA A DINHEIRO"))
                //{

                //    string SQL = "select Mesas.codigo,  Mesas.descricao from Mesas join Documentos on Documentos.CodMesa= Mesas.codigo where Documentos.codigo='" + Numero + "'";
                //    DataTable DtMesas = (DataTable)Geral.ClienteSql.SELECT(SQL);
                //    int CodMesa = 0;
                //    string Mesa = null;
                //    if (DtMesas.Rows.Count > 0)
                //    {
                //        Mesa = DtMesas.Rows[0]["descricao"].ToString();
                //        CodMesa = int.Parse(DtMesas.Rows[0]["codigo"].ToString());
                //    }
                //    frmVender Vender = new frmVender(CodDocumento, 2, Numero.ToString(), null, null, Estado);
                //    if (CodMesa > 0)
                //    {
                //        Vender.BarraVenda.CodMesa = CodMesa;
                //        Vender.cmdImprimir.Visible = true;
                //        Vender.BarraVenda.txtMesa.Text = Mesa;
                //        Vender.BarraVenda.txtMesa.Visible = true;
                //    }
                //    Vender.ShowDialog();
                //    return;
                //}
                //if (Documento.Trim().Equals("FACTURA"))
                //{

                //    frmVender Documentos = new frmVender(2, 2, Numero.ToString(), null, null, Estado);
                //    Documentos.DocumentoAberto = true;
                //    Documentos.ShowDialog();

                //    return;
                //}

                //if (Documento.Equals("VENDA DE BILHETE DE PASSAGEM"))
                //{
                //    frmBilhetesDados bilhere = new frmBilhetesDados(Numero.ToString());
                //    bilhere.ShowDialog();
                //    return;
                //}

                //if (Documento.Equals("REGULARIZAÇÃO DE DOCUMENTOS"))
                //{
                //    frmLegDocDados bilhere = new frmLegDocDados(Numero.ToString());
                //    bilhere.ShowDialog();
                //    return;
                //}
                //if (Documento.Equals("SEGURO DE VIAGEM"))
                //{
                //    frmSeguroViagensDados bilhere = new frmSeguroViagensDados(Numero.ToString());
                //    bilhere.ShowDialog();
                //    return;
                //}

                //if (Documento.Equals("SOLICITAÇÃO DE VISTOS"))
                //{
                //    frmVistosDados Reservar = new frmVistosDados(Numero.ToString());
                //    Reservar.ShowDialog();
                //    return;
                //}

                //if (Documento.Equals("IMPORTAÇÃO E EXPORTAÇÃO"))
                //{
                //    frmImportExportDados Reservar = new frmImportExportDados(Numero.ToString());
                //    Reservar.ShowDialog();
                //    return;
                //}
                ////IMPORTAÇÃO E EXPORTAÇÃO
                //if (Documento.Equals("ORDEM DE SERVIÇO"))
                //{
                //    //frmOrdemServico ordem = new frmOrdemServico(CodDocumento.ToString());
                //    //ordem.ShowDialog();
                //    //return;
                //}

                if (Documento.Trim().Equals("NOTA DE PAGAMENTO"))
                {
                    //if (Geral.TurnoAberto() == false) return;

                    frmNotaPagamento Documentos = IOC.InjectForm<frmNotaPagamento>();                   
                    Documentos.btnBancario.Enabled = false;
                    Documentos.btnNumerario.Enabled = false;
                    Documentos.btnSalvar.Enabled = false;
                    //Documentos.btnEntidade.Enabled = false;
                    //Documentos.cmdTipo.Enabled = false;
                    //Documentos.txtdetalhes.Enabled = false;
                    Documentos.ShowDialog();
                    return;
                }
                //if (Documento.Trim().Equals("RECIBO"))
                //{
                //    if (Geral.TurnoAberto() == false) return;

                //    frmCreditoCliente Documentos = new frmCreditoCliente(Numero.ToString());
                //    Documentos.ShowDialog();
                //    return;
                //}

                //if (Documento.Trim().Equals("GUIA DE ENTREGA"))
                //{
                //    if (Geral.TurnoAberto() == false) return;

                //    frmGuiasDados Documentos = new frmGuiasDados(CodDocumento, Numero.ToString());
                //    Documentos.ShowDialog();
                //    return;
                //}
                //if (Documento.Trim().Equals("TRANSFERENCIA DE PRODUTO"))
                //{
                //    frmStockTransferencia tranferencia = new frmStockTransferencia(Numero.ToString());
                //    tranferencia.ShowDialog();
                //    return;
                //}

                //if (Documento.Equals("CONTAGEM DE PRODUTOS"))
                //{
                //    frmStockContagem contagem = new frmStockContagem(Numero.ToString());
                //    contagem.ShowDialog();
                //    return;
                //}

                //if (Documento.Equals("PAGAMENTO DE EMOLUMENTOS"))
                //{
                //    frmPagamentosEscolar pagamento = new frmPagamentosEscolar(Numero.ToString());
                //    pagamento.ShowDialog();
                //    return;
                //}

                //if (Documento.Equals("ORDEM DE SAQUE"))
                //{
                //    frmOsDados saque = new frmOsDados(Numero.ToString());
                //    saque.ShowDialog();
                //    return;
                //}
                //if (Documento.Equals("PAGAMENTO DE SALARIO"))
                //{
                //    return;
                //}

                //if (Documento.Equals("ORDEM DE SERVIÇO"))
                //{
                //    frmOrdemServiços ordem = new frmOrdemServiços(Numero.ToString(), Documento);
                //    ordem.ShowDialog();
                //    return;
                //}
                //if (Documento.Equals("CONTRATO DE ELECTRICIDADE"))
                //{
                //    frmPtContratoDados notaSaida = new frmPtContratoDados(null, Numero.ToString());
                //    notaSaida.ShowDialog();
                //    return;
                //}

                //if (Documento.Equals("PAGAMENTO DE MENSALIDADE"))
                //{
                //    frmptPagar pagamento = new frmptPagar(Numero.ToString());
                //    pagamento.ShowDialog();
                //    return;
                //}

                if (Documento.Equals("TRANSFERÊNCIA DE VALOR"))
                {
                    return;
                }

                //if (Documento.Equals("SERVIÇOS DE LAVANDARIA"))
                //{
                //    if (Geral.TurnoAberto() == false) return;

                //    frmAtendimtnoLavandaria Documentos = new frmAtendimtnoLavandaria(Numero.ToString());
                //    Documentos.ShowDialog();

                //    return;
                //}

                //frmEditor Editor = new frmEditor(CodDocumento, 1, Numero.ToString(), Estado);
                //Editor.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Abrir Janela: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
      
        private void btnDadosEmpresa_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_DadosGerais;
        }

        private void btnDocumentos_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Documentos;
        }
        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Financeiro;
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage =navigationPage_Detalhe;
        }
     
        private void CarregaPagamentos()
        {

            DateTime inicio = DateTime.Parse(dtInicio.Text);
            DateTime termino = DateTime.Parse(dtFim.Text);

           string criterios = "Pagamentos.CodDocumento is Null or Documentos.CodOperacao<18";
            try
            {
                if (string.IsNullOrEmpty(dtInicio.Text) == false && string.IsNullOrEmpty(dtFim.Text) == false)
                {
                    criterios = "Pagamentos.CodDocumento is Null  and Documentos.Data between '" + inicio.ToString("yyyy-MM-dd") + "' and '" +termino.ToString("yyyy-MM-dd") + "' or Documentos.CodOperacao<18  and Documentos.Data between '" + inicio.ToString("yyyy-MM-dd") + "' and '" + termino.ToString("yyyy-MM-dd") + "'";
                }
                if (string.IsNullOrEmpty(txtCodEntidade.Text) == false)
                {
                    criterios = "Pagamentos.CodDocumento is Null  and Documentos.CodUsuario='" + txtCodEntidade.Text + "' or Documentos.CodOperacao<18  and Documentos.CodUsuario='" + txtCodEntidade.Text + "'";
                }

            
            }
            catch (Exception ex) { MessageBox.Show("Erro a Carregar os Pagamentos: \n" + ex.Message); }
            gradePagamento.DataSource = _VendasApp.ListarPagamentos(criterios);

            try
            {
                double soma = 0;
                double debito = 0;
                double credito = 0;

                for (int i = 0; i < gridPagamentos.RowCount; i++)
                {
                    if (gridPagamentos.GetRowCellValue(i,"Tipo").ToString() == "DEBITO")
                    {
                        debito = debito + double.Parse(gridPagamentos.GetRowCellValue(i, "Valor").ToString());
                    }
                }
                for (int k = 0; k < gridPagamentos.RowCount; k++)
                {
                    if (gridPagamentos.GetRowCellValue(k, "Tipo").ToString() == "CREDITO")
                    {
                        credito = credito + double.Parse(gridPagamentos.GetRowCellValue(k, "Valor").ToString());
                    }
                }
                soma = soma + credito - debito;
                txtTotalFinanceiro.Text = soma.ToString("N2");
                SaldoTotal = soma;
            }
            catch { }
        }
        private void CarregarVendas()
        {
            DateTime inicio = DateTime.Parse(dtInicio.Text);
            DateTime termino = DateTime.Parse(dtFim.Text);

            string criterios = "Operacoes.Codigo<3";

            if (string.IsNullOrEmpty(txtCodEntidade.Text) == false)
            {
                criterios = criterios + " and Documentos.CodUsuario='" + txtCodEntidade.Text + "'";
            }

            if (string.IsNullOrEmpty(dtInicio.Text) == false && string.IsNullOrEmpty(dtFim.Text) == false)
            {
                criterios = criterios + " and Documentos.Data between '" + inicio.ToString("yyyy-MM-dd") + "' and '" + termino.ToString("yyyy-MM-dd") + "'";
            }

            try
            {
               LtVenda =(List<MostraDocumentoViewModel>) _DocumentosApp.MostraDocumentos(criterios);
            }
            catch (Exception ) {}

            double soma = 0;
            for (int i = 0; i < LtVenda.Count; i++)
            {
                soma = soma + LtVenda[i].Total;
            }
            SaldoVendas = soma;


        }
        private void CarregarDocumentos()
        {
            DateTime inicio = DateTime.Parse(dtInicio.Text);
            DateTime termino = DateTime.Parse(dtFim.Text);

            string criterios = "Operacoes.MovFin!='ISENTO'";

            if (string.IsNullOrEmpty(dtInicio.Text) == false && string.IsNullOrEmpty(dtFim.Text) == false)
            {
                criterios = criterios + " and Documentos.Data between '" + inicio.ToString("yyyy-MM-dd") + "' and '" + termino.ToString("yyyy-MM-dd") + "'";
            }

            if (string.IsNullOrEmpty(txtCodEntidade.Text) == false)
            {
                criterios = criterios + " and Documentos.CodUsuario='" + txtCodEntidade.Text + "'";
            }

            try
            {
                lista =(List<RegistoVendasViewModel>)_VendasApp.ListarRegistoVendas(criterios);
            
                GradeDocumentos.DataSource = _VendasApp.ListarRegistoVendas(criterios);
            }
            catch (Exception ex) { MessageBox.Show("Erro \n" + ex); }
          
            double soma = 0;
            for (int i = 0; i <lista.Count; i++)
            {
                soma = soma + double.Parse(lista[i].Total.ToString());
            }
            txtTotalDocumentos.Text = soma.ToString("N2");

        }

        public void Buscaprodutos()
        {
            DateTime inicio = DateTime.Parse(dtInicio.Text);
            DateTime termino = DateTime.Parse(dtFim.Text);

            List<LerProdutosViewModel> ListDados = new List<LerProdutosViewModel>();

            string criterios = "Documentos.CodOperacao<'4'";
            if (string.IsNullOrEmpty(dtInicio.Text) == false && string.IsNullOrEmpty(dtFim.Text) == false)
            {
                criterios = criterios + " and Documentos.Data between '" + inicio.ToString("yyyy-MM-dd") + "' and '" + termino.ToString("yyyy-MM-dd") + "' And Documentos.Estado<>'ANULADO'";
                if(string.IsNullOrEmpty(txtEntidade.Text))
                criterios += " order by MovProdutos.CodProduto";
            }
            if (string.IsNullOrEmpty(txtCodEntidade.Text) == false)
            {
                criterios = criterios + " and Documentos.CodUsuario='" + txtCodEntidade.Text + "'  order by MovProdutos.CodProduto";
            }
            ListDados = (List<LerProdutosViewModel>) _MovArtigosApp.ListarProdutos_RP(criterios, inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"));

            try
            {
                for (int i = 0; i < ListDados.Count; i++)
                {
                    double qt = ListDados[i].Quantidade;
                    double imposto = ListDados[i].Imposto;
                    double preco = ListDados[i].Preco;
                    double custox = ListDados[i].Custo;
                    double total = qt * preco;
                    double tcusto = qt * custox;
                    double timposto = qt * imposto;
                    double lucro = total - custox;
                    ListDados[i].TotalReceita = total;
                    ListDados[i].Lucro = lucro;
                    ListDados[i].TotalCusto= custox;
                    ListDados[i].TotalImposto = timposto;

                }

                double RECEITAS = 0;
                double LUCRO = 0;
                double IMPOSTO = 0;
                double CUSTO = 0;

                for (int i = 0; i < ListDados.Count; i++)
                {
                    RECEITAS = RECEITAS + ListDados[i].TotalReceita;
                    LUCRO = LUCRO + ListDados[i].Lucro;
                    CUSTO = CUSTO + ListDados[i].TotalCusto;
                    IMPOSTO = IMPOSTO + ListDados[i].TotalImposto;

                }
 
                GradeAux.DataSource = ListDados;

                txttotalProdutos.Text = RECEITAS.ToString("N2");
                txtImposto.Text = IMPOSTO.ToString("N2");
                txttotalLucros.Text = LUCRO.ToString("N2");
                txtTotalCusto.Text = CUSTO.ToString("N2");
                //listaDadoGerais = new List<DadosRegistosPeriodicoViewModel>();
                listaDadoGerais.Add(new DadosRegistosPeriodicoViewModel { ItemCaixa = "Total de Custos", Descricao = CUSTO.ToString("N2") });
                listaDadoGerais.Add(new DadosRegistosPeriodicoViewModel { ItemCaixa = "Total de Receitas", Descricao = RECEITAS.ToString("N2") });
                listaDadoGerais.Add(new DadosRegistosPeriodicoViewModel { ItemCaixa = "Total de Impostos", Descricao = IMPOSTO.ToString("N2") });
                listaDadoGerais.Add(new DadosRegistosPeriodicoViewModel { ItemCaixa = "Total de Lucro", Descricao = LUCRO.ToString("N2") });

        }
            catch (Exception)
            {
                MessageBox.Show("Erro na Leitura de Produto");
            }
}
        public bool VerificaExiste(string CodProduto, string Preco, double Custo, List<DetalheProdutoViewModel> Dados)
        {
            bool res = false;
            for (int i = 0; i < Dados.Count; i++)
            {
                
                if (CodProduto == Dados[i].Codigo.ToString() && Preco == Dados[i].Preco.ToString() && Custo == double.Parse(Dados[i].Custo.ToString()))
                    res = true;
            }

            return res;
        }
        public void LerTurnoActual()
        {
            List<Turnos> listaTurno ;
            listaTurno = (List <Turnos>) _TurnosApp.ListarTurno();

            if (listaTurno.Count > 0)
            {
                try
                {
                    Numero =listaTurno.Count;
                    DataAbertura = dtInicio.Text;
                    DataFecho = dtFim.Text;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao listar Turno " + ex.Message);
                }
            }
           

        }
        private void Actualizar()
        {
            LerTurnoActual();
            CarregarDocumentos();
            CarregaPagamentos();
            CarregarVendas();
            //CarregarHospedagem();
        }
        public void MostrarDetalhes()
        {
            if(!load)
            Controle.Processamento();
            Actualizar();
            
            listaDadoGerais = new List<DadosRegistosPeriodicoViewModel>();
            listaDadoGerais.Add(new DadosRegistosPeriodicoViewModel { ItemCaixa = "Nº de Turnos", Descricao = Numero.ToString() });
            if (string.IsNullOrEmpty(txtCodEntidade.Text) == false)
            {
                listaDadoGerais.Add(new DadosRegistosPeriodicoViewModel { ItemCaixa = "Usuário", Descricao = txtEntidade.Text });
              
            }
            listaDadoGerais.Add(new DadosRegistosPeriodicoViewModel { ItemCaixa = "Data Inicio", Descricao = DataAbertura.ToString()});
            listaDadoGerais.Add(new DadosRegistosPeriodicoViewModel { ItemCaixa = "Data Termino", Descricao = DataFecho.ToString() });
            listaDadoGerais.Add(new DadosRegistosPeriodicoViewModel { ItemCaixa = "Saldo Vendas", Descricao =  SaldoVendas.ToString("N2")});
            listaDadoGerais.Add(new DadosRegistosPeriodicoViewModel { ItemCaixa = "Saldo Total do Sistema", Descricao = SaldoTotal.ToString("N2") });


            Buscaprodutos();

            GradeCaixa.DataSource = listaDadoGerais;
            Controle.AbortarThread();
            load = false;
        }

        private void frmVerRegistosPeriodicos_Load(object sender, EventArgs e)
        {
            dtInicio.Text = DateTime.Now.ToShortDateString();
            dtFim.Text = DateTime.Now.ToShortDateString();
            dtInicio.Properties.MaxValue = DateTime.Now;
            dtFim.Properties.MaxValue = DateTime.Now;

            MostrarDetalhes();         
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            index = e.RowHandle;
        }

        private void btnEntidade_Click(object sender, EventArgs e)
        {
            var  form=IOC.InjectForm<frmEntidadeBusca>().GetEntidadeSelecionada();
            if(form.Codigo!=0)
            {
                txtCodEntidade.Text = form.Codigo.ToString();
                txtEntidade.Text = form.Nome;
            }
           

        }       
        private void navigationPage_DadosGerais_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAtualizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            MostrarDetalhes();
        }

        private void GradeDocumentos_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridDocumentos_DoubleClick(object sender, EventArgs e)
        {

            //try
            //{
            //    GridView view = (GridView)sender;
            //    Point pt = view.GridControl.PointToClient(MousePosition);
            //    GridHitInfo info = view.CalcHitInfo(pt);

            //    indexClick = info.RowHandle;
            //    ClickDocumento();
            //}
            //catch (Exception) { }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}