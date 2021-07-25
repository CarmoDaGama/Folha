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
using Folha.Driver.Framework.IOC;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmAtendimentos : XtraForm
    {
        private readonly IAtendimentoHospitalarApp _AtendimentoHospitalarApp;
        List<AtendimentoHospitalarViewModel> LtAtendimentos;
        List<AtendimentoHospitalarViewModel> Lista;
        int usuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private int IndexAtendimento { get; set; } = -1;

        public frmAtendimentos(IAtendimentoHospitalarApp AtendimentoHospitalarApp)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;

            _AtendimentoHospitalarApp = AtendimentoHospitalarApp;
            Permicao();

            ////Lançar Internamentos
            frmIntenamentoFaturacao chamadaCadastro = IOC.InjectForm<frmIntenamentoFaturacao>();
            chamadaCadastro.NovoIntenamento();
        }
        #region Permicao de Acesso
        private void Permicao()
        {
            if (usuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Eliminar") == false) { btnEliminar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Imprimir") == false) { btnPrint.Enabled = false; }
            }
        }
        #endregion

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmAtendimentoRecepcao>().ShowDialog();
            if (UtilidadesGenericas.Busca.Alterou)
            {
                carregarLastaAtendimento();
                UtilidadesGenericas.Busca.Alterou = false;
            }
        }

        private void frmAtendimentos_Load(object sender, EventArgs e)
        {
            dtinicio.Text = DateTime.Now.ToShortDateString();
            dtfim.Text = DateTime.Now.ToShortDateString();
            dtinicio.Properties.MaxValue = DateTime.Now;
            dtfim.Properties.MaxValue = DateTime.Now;
            gradeAtendimentos.DataSource=LtAtendimentos= (List < AtendimentoHospitalarViewModel >) _AtendimentoHospitalarApp.ListarAtendimentos(DateTime.Now.Date.ToString("yyyy-MM-dd"), DateTime.Now.Date.ToString("yyyy-MM-dd"), null);
            IndexAtendimento = 0;
        }

        private void gridAtendimentos_DoubleClick(object sender, EventArgs e)
        {
           
            if (IndexAtendimento <= -1)
            {
                UtilidadesGenericas.MsgShow("Selcione uma linha de registro!");
                return;
            }
            var form = IOC.InjectForm<frmAtendimentoRecepcao>();
            Lista = new List<AtendimentoHospitalarViewModel>();
            Lista.Add(LtAtendimentos[IndexAtendimento]);
            form.EditarAtendimento(Lista);

            if (UtilidadesGenericas.Busca.Alterou)
            {
                carregarLastaAtendimento();
                UtilidadesGenericas.Busca.Alterou = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            carregarLastaAtendimento();
        }
        private void carregarLastaAtendimento()
        {
            DateTime inicio = DateTime.Parse(dtinicio.Text);
            DateTime termino = DateTime.Parse(dtfim.Text);

            gradeAtendimentos.DataSource = LtAtendimentos = (List<AtendimentoHospitalarViewModel>)_AtendimentoHospitalarApp.ListarAtendimentos(inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"), null);
            IndexAtendimento = 0;
        }
        private void gridAtendimentos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            IndexAtendimento = e.RowHandle;
        }

        private void gridAtendimentos_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            IndexAtendimento = e.RowHandle;
        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnEntidade_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtinicio_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dtfim_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnEntidade_Click_1(object sender, EventArgs e)
        {

        }
    }
}