using DevExpress.XtraEditors;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;


namespace Folha.Presentation.Desktop.Forms.Apresenta_Doc
{
    using Folha.Presentation.Desktop.Reports;
    using Folha.Presentation.Desktop.Reports.Admin;
    using Folha.Presentation.Desktop.Reports.Documentos;
    using Folha.Presentation.Desktop.Reports.Financeiro;
    using Folha.Presentation.Desktop.Reports.Hospitalar;
    using Folha.Presentation.Desktop.Reports.Inventario;
    using Folha.Domain.Models.Empresa;
    using Folha.Domain.Models.Financeiro;
    using Folha.Domain.Models.Hospitalar;
    using Folha.Domain.ViewModels.Financeiro;
    using Folha.Domain.ViewModels.Hospitalar;
    using Folha.Domain.ViewModels.Inventario;
    using Folha.Domain.ViewModels.Report;
    using Folha.Domain.ViewModels.Sistema;
    using Folha.Domain.ViewModels.Frame.Entidades;
    using Folha.Domain.ViewModels.Frame.Hospitalar;
    using System.Collections.Generic;
    using System;

    public partial class frmApresentaReport : XtraForm
    {

        public frmApresentaReport()
        {
            InitializeComponent();
        }

       public void ApresentarReport(object Datas, XtraReport report)
       {
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Datas;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
            //var path = @"C:\Reports\Venda.pdf";

            //if (File.Exists(path))
            //{
            //    File.Delete(path);
            //}
         
            //report.ExportToPdf(path);

        }


        #region  ==================== Hospitalar ===================================
        public void ApresentarReportPacientes(List<PacienteViewModel> Pacientes, DadosReportViewModel Dados)
        {
            var report = new RelPacientes(Pacientes,Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Pacientes;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportFichaPaciente(PacienteViewModel ficha)
        {
            var report = new RelFichaPaciente(ficha);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            //report.DataSource = ficha;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportAtendimentos(List<AtendimentoHospitalarViewModel> Atendimentos,DadosReportViewModel Dados)
        {
            var report = new RelAtendimentos(Atendimentos,Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Atendimentos;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportLaboratorios(List<Laboratorio> Laboratorios, DadosReportViewModel Dados)
        {
            var report = new RelLaboratorios(Laboratorios, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Laboratorios;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportPacienteInternado(List<PacienteInternado> PacienteInternados, DadosReportViewModel Dados)
        {
            var report = new RelInternamentos(PacienteInternados, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = PacienteInternados;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportConsultaHospitalar(List<ConsultaHospitalarViewModel> ConsultaHospitalar, DadosReportViewModel Dados)
        {
            var report = new RelConsultaHospitalar(ConsultaHospitalar, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = ConsultaHospitalar;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }

        
        public void ApresentarReportGrafAtendimento(List<AtendimentoHospitalarGraficViewModel> AtendimentoGrafico, DadosReportViewModel Dados)
        {
            var report = new RelGrafAtendimentoGrafico(AtendimentoGrafico, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportFichaLaboratorio(ExamesAtendimentoViewModel ficha, string NomePaciente, DateTime DataNascimento, string civil, string Sexo, string Contacto)
        {
            var report = new RelFichaLaboratorio(ficha, NomePaciente, DataNascimento, civil, Sexo, Contacto);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportTriagem(List<TriagemViewModel> LtTriagem, DadosReportViewModel Dados, AllEntidadeViewModel paciente)
        {
            var report = new RelTriagem(LtTriagem, Dados, paciente);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarRelFichaMedico(RelMedicoViewModel Dados,List<MedicoEspecialidadeViewModel> LtEspecialidade)
        {
            var report = new RelFichaMedico(Dados, LtEspecialidade);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }

        public void ApresentarReportReceita(List<FarmacoReceitaViewModel> LtFarmacos, DadosReportViewModel Dados)
        {
            //var report = new RelTriagem(LtTriagem, Dados, paciente);
            //foreach (Parameter item in report.Parameters)
            //{
            //    item.Visible = false;
            //}
            //documentViewer1.DocumentSource = report;
            //report.CreateDocument();
            //ShowDialog();
        }
        public void ApresentarReportMedicos(List<Folha.Domain.ViewModels.Frame.Hospitalar.MedicosViewModel> Medicos, DadosReportViewModel Dados)
        {
            var report = new RelMedicos(Medicos, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Medicos;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }

        #endregion =========================================================
        public void ApresentarReportTestMarcaDaAgua()
        {
            var report = new TestReport();
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }

        #region =========================================RelFinanceiro=========================================
        public void ApresentarReportFluxoCaixa(List<FluxoCaixaViewModel> LtFluxo, DadosReportViewModel Dados)
        {
            var report = new RelFuxoCaixa(LtFluxo, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportFluxoConta(List<FluxoCaixaViewModel> LtFluxo, DadosReportViewModel Dados)
        {
            var report = new RelFluxoConta(LtFluxo, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }

        public void ApresentarReportContaCorrente(List<FluxoCaixaViewModel> LtFluxo, DadosReportViewModel Dados)
        {
            var report = new RelContaCorrente(LtFluxo, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportSaldoCliente(List<SaldoClienteViewModel> LtSaldoCliente, DadosReportViewModel Dados)
        {
            var report = new RelSaldoCliente(LtSaldoCliente, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportDividaCliente(List<SaldoClienteViewModel> LtSaldoCliente, DadosReportViewModel Dados)
        {
            var report = new RelDividasCliente(LtSaldoCliente, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportNotasPagamentos(List<RelNotasPagamentosViewModel> LtNotasPagamentos, DadosReportViewModel Dados)
        {
            var report = new RelNotasPagamentos(LtNotasPagamentos, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportSaldoGeral(List<SaldoCaixaViewModel> LtSaldoCaixa, List<SaldoBancoViewModel> LtSaldoBanco, DadosReportViewModel Dados)
        {
            var report = new RelSaldoGeral(LtSaldoCaixa, LtSaldoBanco, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportGrafCaixa(List<SaldoCaixaViewModel> LtSaldoCaixa, DadosReportViewModel Dados)
        {
            var report = new RelGrafCaixa(LtSaldoCaixa, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportGrafConta(List<SaldoBancoViewModel> LtSaldoConta, DadosReportViewModel Dados)
        {
            var report = new RelGrafConta(LtSaldoConta, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportNotaFinalidade(List<RelNotaFinalidadeViewModel> LtNotaFinalidade, DadosReportViewModel Dados)
        {
            var report = new RelNotaFinalidade(LtNotaFinalidade, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportMoeda(List<MostraMoedasViewModel> Datas)
        {
            var report = new RelMoeda(Datas);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Datas;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportContaBancaria(List<ContasBancarias> Datas)
        {
            var report = new RelContasBancaria(Datas);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Datas;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportNotaPagamento(NotaPagamentoViewModel Datas, List<NotaPagamentoViewModel> Lista)
        {
            var report = new RelNotaPagamento(Datas, Lista);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReporFPagamento(List<Mostrar> Datas)
        {
            var report = new RelFormasPagamento(Datas);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Datas;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        #endregion=========================================================================================================
        #region =================================RelInventario=================================
        public void ApresentarRelListaArtigos(List<RelListagemArtigosViewModel> LtArtigos, string Armazem)
        {
            var report = new RelListagemArtigos(LtArtigos, Armazem);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarRelControleStock(List<RelListagemArtigosViewModel> LtArtigosStock, string NomeRelatorio, string Armazem)
        {
            var report = new RelStockArmazem(LtArtigosStock, NomeRelatorio, Armazem);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarRelArtgSemControleStock(List<RelListagemArtigosViewModel> LtArtigos, string Armazem)
        {
            var report = new RelArtgSemControlStock(LtArtigos, Armazem);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarRelTabelaPreco(List<RelListagemArtigosViewModel> LtArtigos, string Armazem)
        {
            var report = new RelTblPrecoArmazem(LtArtigos, Armazem);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarRelListaPrecoArmazem(List<RelListagemArtigosViewModel> LtArtigos, string Armazem)
        {
            var report = new RelListaPrecoArmazem(LtArtigos, Armazem);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarRelRupturaStock(List<RelListagemArtigosViewModel> LtRupruraStock, string Armazem)
        {
            var report = new RelRupturaStock(LtRupruraStock, Armazem);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarRelMovArtigo(List<RelMovArtigosViewModel> LtMovArtigo, string dtInicial, string dtFinal, string Armazem)
        {
            var report = new RelMovArtigo(LtMovArtigo, dtInicial, dtFinal, Armazem);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarRelGrafMovArtigo(List<RelMovArtigosViewModel> LtMovArtigo, string dtInicial, string dtFinal, string Armazem)
        {
            var report = new RelGrafMovArtigos(LtMovArtigo, dtInicial, dtFinal, Armazem);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarRelGrafArtigosVendidos(List<RelMovArtigosViewModel> LtMovArtigo, string dtInicial, string dtFinal, string Armazem)
        {
            var report = new RelGrafArtigosVendidos(LtMovArtigo, dtInicial, dtFinal, Armazem);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarRelRetencaoArtigos(List<RelListagemArtigosViewModel> LtArtigo, DadosReportViewModel Dados)
        {
            var report = new RelRetencaoArtigos(LtArtigo, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportTransferenciaProduto(List<TransferenciaProdutoViewModel> Datas)
        {
            var report = new RelTransferenciaProdutos(Datas);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Datas;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportArmazens(List<Domain.Models.Inventario.Armazens> Datas)
        {
            var report = new RelArmazens(Datas);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Datas;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportProdutos(List<ArtigoViewModel> Datas)
        {
            var report = new RelProdutos(Datas);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Datas;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        #endregion==================================================================================
     

        public void ApresentarRelOperacoes(List<RelOpercoesViewModel> LtOperacoes, DadosReportViewModel Dados)
        {
            var report = new RelOperacoes(LtOperacoes, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarRelGrafTotOp(List<RelOpercoesViewModel> LtOperacoes, DadosReportViewModel Dados)
        {
            var report = new RelGrafTotOperacoes(LtOperacoes, Dados);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarRelGrafPeriodicoMov(List<Saldos> LtSaldo)
        {
            var report = new RelGrafPeriodicoMov(LtSaldo);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }


        public void ApresentarReportCaixa(List<Caixas> Datas)
        {
            var report = new RelCaixas(Datas);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Datas;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
       
        public void ApresentarReportBancario(List<BancosViewModel> Datas)
        {
            var report = new RelBancaria(Datas);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Datas;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }

        public void ApresentarReportCategorias(List<Domain.Models.Inventario.Categoria> Datas)
        {
            var report = new RelCategoria(Datas);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Datas;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        public void ApresentarReportImposto(List<ImpostoViewModel> Datas)
        {
            var report = new RelImpostos(Datas);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Datas;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
     

        public void ApresentarReportUsuario(List<Domain.Models.UtilitariosConfiguracoes.Usuarios> Datas)
        {
            var report = new RelUsuario(Datas);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = Datas;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
        internal void ApresentarReporOpSistema(List<OperacoesViewModel> listOperacoes, Empresa cabecalhoEmpresa)
        {
            var report = new RelOpSistema(listOperacoes, cabecalhoEmpresa);
            foreach (Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.DataSource = listOperacoes;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            ShowDialog();
        }
    }
}
