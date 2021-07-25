using DevExpress.XtraEditors;
using Folha.Domain.Interfaces.Application.Admin;
using Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.ViewModels.Admin;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Notificacoes;
using Folha.Presentation.Desktop.Forms.Utilitarios_Configuracoes;
using Folha.Presentation.Desktop.Separadores.Utilitarios_Configuracoes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Separadores.Notificacoes
{
    public partial class frmNotificacoes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        int Notificacoes = 0;
        private List<NotificaoDocumentoViewModel> Receber;
        private List<NotificaoDocumentoViewModel> Pagar;
        //private List<NotificaoManutencaoViewModel> Manutencao;
        //private List<NotificaoQuartoViewModel> Quarto;
        private List<NotificaoRuturaViewModel> Rotura;
        private List<NotificaoTarefasViewModel> Tarefa;
        List<PeriodoBackup> PeriodoBackuplista;

        private readonly INotificaoApp _NotificaoApp;
        private readonly IPeriodoBackupApp _perido;


        public frmNotificacoes(INotificaoApp NotificaoApp,IPeriodoBackupApp perido)
        {
            _NotificaoApp = NotificaoApp;
            _perido = perido;
            InitializeComponent();
            AllNotificacoes();
            Renderizar();
        }
      
        private void AllNotificacoes()
        {
            buscarRutura();
            BuscarContasApagar();
            BuscarContasReceber();
            //BuscarQuartosSujos();
            //buscarManutencao();
            buscarBackup();

        }

        public void Renderizar()
        {
            var largura = panelRenderizar.Width / 4 + 2;
            panelv1.Size = new Size(largura, panelv1.Height);
            panelv2.Size = new Size(largura, panelv2.Height);
            panelv3.Size = new Size(largura, panelv3.Height);
            panelv4.Size = new Size(largura, panelv4.Height);
        }

        #region Trazer dados
        private void BuscarContasApagar()
        {
            lbCountApagar.Text = _NotificaoApp.TotalPagar().ToString();
        }
        private void BuscarContasReceber()
        {
           
            lbCountReceber.Text = _NotificaoApp.TotalReceber().ToString();

        }
        private void buscarRutura()
        {
            lbRotura.Text = _NotificaoApp.TotalRotura().ToString();
            lbDataHoje.Text = DateTime.Now.ToShortDateString();
        }
        //private void BuscarQuartosSujos()
        //{
        //    Quarto = _NotificaoApp.ListarQuartos(null);
        //    var codigoQ = 0;
        //    if (Quarto.Count > 0)
        //    {
        //        codigoQ = Quarto[0].Codigo;
        //    }
        //    if (codigoQ > 0)
        //    {
        //        tilerCopiaSeguranca.Visible = true;
        //    }

        //}
        //private void buscarManutencao()
        //{
        //    Manutencao = _NotificaoApp.ListarManutencao(null);
        //    var codigoM = 0;
        //    if (Manutencao.Count > 0)
        //    {
        //        codigoM = Manutencao[0].Codigo;
        //    }
        //    if (codigoM > 0)
        //    {
        //        tileManutencao.Visible = true;
        //    }
        //}
        //private void buscartarefas()
        //{
        //    Tarefa = _NotificaoApp.ListarTarefas(null);
        //    var codigoT = 0;
        //    if (Tarefa.Count > 0)
        //    {
        //        codigoT = Tarefa[0].codigo;
        //    }

        //    if (codigoT > 0)
        //    {
        //        tileTarefa.Visible = true;
        //    }
        //}
        private void buscarBackup()
        {
            PeriodoBackuplista = (List<PeriodoBackup>)_perido.Listar();
            if (UtilidadesGenericas.ListaNula(PeriodoBackuplista))
            {
                MessageBox.Show("É obrigatorio Criar um Periodo de Copia de Segurança", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IOC.InjectForm<frmConfiguracoesBackup>().ShowDialog();
                return;
            }
            var periodo = PeriodoBackuplista[0].Periodo;
            var dataFim = PeriodoBackuplista[0].Data;
            var intervalo = PeriodoBackuplista[0].Intervalo;

           var intervaloFinal = UtilidadesGenericas.GetIntervaloDeDia(  dataFim, DateTime.Now);
            lbPeriodoBackup.Text = intervaloFinal.ToString();
            lbdiaRestante.Text = PeriodoBackuplista[0].Data.ToString();
        }
        #endregion


        #region Chamar Formularios
        private void tileApoio_ItemClick(object sender, TileItemEventArgs e)
        {
            frmApoioContagem contagem = new frmApoioContagem();
            contagem.ShowDialog();
        }

        private void tileContaApagar_ItemClick(object sender, TileItemEventArgs e)
        {
            

            //UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmContasPagar>());

        }

        private void tileContasReceber_ItemClick(object sender, TileItemEventArgs e)
        {
            
        }

        private void tileRutura_ItemClick(object sender, TileItemEventArgs e)
        {
            
        }

        private void tilerQuartosSujos_ItemClick(object sender, TileItemEventArgs e)
        {
            

        }

        private void tileManutencao_ItemClick(object sender, TileItemEventArgs e)
        {
        }

        private void tileTarefa_ItemClick(object sender, TileItemEventArgs e)
        {
        
        }

        #endregion

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frmContasPagar ContasPagar = IOC.InjectForm<frmContasPagar>();
            ContasPagar.ShowDialog();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            frmContasReceber ContasPagar = IOC.InjectForm<frmContasReceber>();
            ContasPagar.ShowDialog();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            frmRuptura rutura = IOC.InjectForm<frmRuptura>();
            rutura.ShowDialog();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            frmCopiaSegurança copia = IOC.InjectForm<frmCopiaSegurança>();
            copia.ShowDialog();
        }
    }
}