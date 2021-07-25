using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using Folha.Driver.Framework.IOC;
using Folha.Domain.Interfaces.Application.Escolar;
using Folha.Domain.ViewModels.Escolar;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Separadores.Gestao_Escolar
{
    public partial class frmAlunos : XtraForm
    {
        private readonly IAlunosApp _AlunosApp;
        private List<AlunosViewModel> LtAlunos;
        private int indexGrid=0;
        AlunosViewModel Aluno=null;
        public frmAlunos(IAlunosApp AlunosApp)
        {
            InitializeComponent();
            _AlunosApp = AlunosApp;
        }
       
        private void frmVerAlunos_Load(object sender, EventArgs e)
        {
            //VerificarAcesso

            string UltimaData = _AlunosApp.RetornaAno();
            if (!string.IsNullOrEmpty(UltimaData))
                dtAno.EditValue = Convert.ToDateTime(UltimaData);
            else
                dtAno.EditValue = DateTime.Now;

            cboEstados.SelectedIndex = 0;
            LtAlunos = (List<AlunosViewModel>)_AlunosApp.ListarAlunos(dtAno.Text);
            LtAlunos = LtAlunos.Where(r => r.status == 1).ToList();
            gradeAlunos.DataSource = LtAlunos;

            txtTotal.Text = (LtAlunos.Count != 0) ? (LtAlunos.Count.ToString()) : ("");

        }

        private void btnNovoAluno_ItemClick(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmAluno>().ShowDialog();
            if (UtilidadesGenericas.Busca.Alterou)
            {
                CarregaLista();
                UtilidadesGenericas.Busca.Alterou = false;
            }
        }

        private void cboEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void CarregaLista()
        {
            LtAlunos = (List<AlunosViewModel>)_AlunosApp.ListarAlunos(dtAno.Text);
            if (cboEstados.Text == "Activos")
                LtAlunos = LtAlunos.Where(r => r.status == 1).ToList();
            else if (cboEstados.Text == "Inactivos")
                LtAlunos = LtAlunos.Where(r => r.status == 0).ToList();

            gradeAlunos.DataSource = LtAlunos;
            txtTotal.Text = (LtAlunos.Count != 0) ? (LtAlunos.Count.ToString()) : ("");
        }
        private void btnActualizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            CarregaLista();
        }

        private void gridAlunos_DoubleClick(object sender, EventArgs e)
        {
                var form = IOC.InjectForm<frmAluno>();

                form.EditarAluno(new AlunosViewModel()
                {
                    Codigo = LtAlunos[indexGrid].Codigo,
                    Nome = LtAlunos[indexGrid].Nome,
                    CodEntidade= LtAlunos[indexGrid].CodEntidade,
                    status= LtAlunos[indexGrid].status
                });
                if (UtilidadesGenericas.Busca.Alterou)
                {
                    CarregaLista();
                    UtilidadesGenericas.Busca.Alterou = false;
                }
            }

        private void gridAlunos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }

        private void gridAlunos_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSelecionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Aluno = new AlunosViewModel();
            Aluno = LtAlunos[indexGrid];
        }

        public AlunosViewModel GetAluno()
        {
            ShowDialog();
            return Aluno;
        }
    }
    }
