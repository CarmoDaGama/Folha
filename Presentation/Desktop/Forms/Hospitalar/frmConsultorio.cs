using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Domain.ViewModels.Frame.Entidades;
using Folha.Domain.ViewModels.Frame.Hospitalar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmConsultorio : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IConsultaHospitalarApp _Consulta;
        private readonly IUsuariosApp _usuarios;
        private readonly IEntidadesApp _Entidades;
        private readonly IEntidadePessoaApp _EntidadePessoa;
        private readonly IMedicosApp _MedicosApp;
        private int codEntidade;
        private List<Folha.Domain.ViewModels.Frame.Hospitalar.MedicosViewModel> ListaMEdico;
        public MarcacaoConsultaViewModel Consultar { get; set; }
        private List<AllEntidadeViewModel> ListaEntidades;
        private int codMedico;
        private List<MarcacaoConsultaViewModel> ListaConsultas { get; set; }
        public int CodigoUsuario { get; private set; }
        public string NomeUsario { get; private set; }
        public int IndexAtendimento { get; private set; }
        public bool VerificaConsultorio { get; private set; }
        private readonly IAtendimentoHospitalarApp _AtendimentoHospitalarApp;
        List<AtendimentoHospitalarViewModel> Lista;
        List<AtendimentoHospitalarViewModel> ListaAtendimento;


        public frmConsultorio(IConsultaHospitalarApp Consulta, IUsuariosApp usuarios, IEntidadesApp Entidades, IEntidadePessoaApp EntidadePessoa, IMedicosApp Medicos, IAtendimentoHospitalarApp AtendimentoHospitalarApp)
        {
            InitializeComponent();
            _Consulta = Consulta;
            _usuarios = usuarios;
            _Entidades = Entidades;
            _EntidadePessoa = EntidadePessoa;
            _MedicosApp = Medicos;
            _AtendimentoHospitalarApp = AtendimentoHospitalarApp;
            var Usuario = _usuarios.GetById(UtilidadesGenericas.UsuarioCodigo);
            NomeUsario = UtilidadesGenericas.NomeUsuario;
            codEntidade = Usuario.CodEntidade;
            dtinicio.Text = DateTime.Now.ToShortDateString();
            dtfim.Text = DateTime.Now.ToShortDateString();

            CarregaCampos();
        }
        private void CarregaCampos()
        {
            codMedico = _MedicosApp.GetIdMedico(codEntidade.ToString());
            if (codMedico == 0 || codMedico == null)
            {
                MessageBox.Show("O Sr(a) "+ NomeUsario + " Não é um medico");
                return;
            }
            ListaConsultas = (List<MarcacaoConsultaViewModel>)_Consulta.ListarConsultaMedico(codMedico, dtinicio.EditValue.ToString(), dtfim.EditValue.ToString());
            txtCodigo.Text = codMedico.ToString();
            txtEntidade.Text = NomeUsario;
            if (UtilidadesGenericas.ListaNula(ListaConsultas))
            {
                return;
            }          
        }
        private void VerficarMedico()
        {
            if (UtilidadesGenericas.ListaNula(ListaConsultas))
            {
                MessageBox.Show("O Sr(a) " + NomeUsario + " Não possui Consulta marcadas");
                return;
            }  
        }
        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        
        private void frmConsultorio_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
        private void Mostrar()
        {
            ListaConsultas = (List<MarcacaoConsultaViewModel>)_Consulta.ListarConsultaMedico(codMedico, dtinicio.EditValue.ToString(), dtfim.EditValue.ToString());
            gradeConsultas.DataSource = ListaConsultas;

            if (cboInternamento.SelectedItem.ToString() == "TODOS")
            {
                ListaConsultas = (List<MarcacaoConsultaViewModel>)_Consulta.ListarConsultaMedico(codMedico, dtinicio.EditValue.ToString(), dtfim.EditValue.ToString());
                gradeConsultas.DataSource = ListaConsultas;
            }
            else if (cboInternamento.SelectedItem.ToString() == "ATENDIDOS")
            {
                gradeConsultas.DataSource = ListaConsultas.Where(a => a.Atendido == "Sim");
            }
            else if (cboInternamento.SelectedItem.ToString() == "NÃO ATENDIDOS")
            {
                gradeConsultas.DataSource = ListaConsultas.Where(a => a.Atendido == "Não");
            }
        }

        private void cboInternamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void gridConsulta_DoubleClick(object sender, EventArgs e)
        {
            if (IndexAtendimento <= -1)
            {
                UtilidadesGenericas.MsgShow("Selcione uma linha de registro!");
                return;
            }
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            UtilidadesGenericas.Busca.CodigoConsultaNova = gridConsulta.GetRowCellValue(info.RowHandle, "Codigo").ToString();
            UtilidadesGenericas.Busca.CodCosulta = gridConsulta.GetRowCellValue(info.RowHandle, "CodAtendimento").ToString();
            UtilidadesGenericas.Busca.CodMedicoNovo = gridConsulta.GetRowCellValue(info.RowHandle, "CodMedico").ToString();
            var Codpaciente = gridConsulta.GetRowCellValue(info.RowHandle, "CodPaciente").ToString();
            UtilidadesGenericas.Busca.CodPaceinteNovo = gridConsulta.GetRowCellValue(info.RowHandle, "CodPaciente").ToString();
            UtilidadesGenericas.Busca.Alterou = false;
            UtilidadesGenericas.Busca.VerificaConsultorio = true;
            ListaAtendimento = (List<AtendimentoHospitalarViewModel>)_AtendimentoHospitalarApp.ListarAtendimentosRecepcao(Codpaciente);
            var form = IOC.InjectForm<frmAtendimentoRecepcao>();
            Lista = new List<AtendimentoHospitalarViewModel>();
            Lista.Add(ListaAtendimento[IndexAtendimento]);
            form.EditarAtendimento(Lista);
            if (UtilidadesGenericas.Busca.Alterou) Mostrar();
            UtilidadesGenericas.Busca.VerificaConsultorio = false;
        }

        private void gridConsulta_RowClick(object sender, RowClickEventArgs e)
        {
            IndexAtendimento = e.RowHandle;
            Consultar = ListaConsultas[IndexAtendimento];
        }
    }
}