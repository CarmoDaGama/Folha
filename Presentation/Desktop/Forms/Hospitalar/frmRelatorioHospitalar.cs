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
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using Folha.Domain.ViewModels.Frame.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Driver.Framework.IOC;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmRelatorioHospitalar : DevExpress.XtraEditors.XtraForm
    {
       
        public frmRelatorioHospitalar(IPacienteApp PacienteApp, IMedicosApp MedicosApp)
        {
            InitializeComponent();
        }


        #region Botons

        frmRelDadosHospitalar DadosHospitalar = IOC.InjectForm<frmRelDadosHospitalar>();
        private void tileMedicos_ItemClick(object sender, TileItemEventArgs e)
        {
            DadosHospitalar.LevarValor("Médicos"); DadosHospitalar.ShowDialog();
        }
        private void tilePacientes_ItemClick(object sender, TileItemEventArgs e)
        {
            DadosHospitalar.LevarValor("Pacientes"); DadosHospitalar.ShowDialog();
        }
        private void tilerAtendimentos_ItemClick(object sender, TileItemEventArgs e)
        {
            DadosHospitalar.LevarValor("Atendimentos"); DadosHospitalar.ShowDialog();
        }
        private void tileConsultorios_ItemClick(object sender, TileItemEventArgs e)
        {
            DadosHospitalar.LevarValor("Consultorios"); DadosHospitalar.ShowDialog();
        }
        private void tileInternamentos_ItemClick(object sender, TileItemEventArgs e)
        {
            DadosHospitalar.LevarValor("Internamentos"); DadosHospitalar.ShowDialog();
        }
        private void tileLaboratorios_ItemClick(object sender, TileItemEventArgs e)
        {
            DadosHospitalar.LevarValor("Laboratórios"); DadosHospitalar.ShowDialog();
        }
       
        private void tileItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            DadosHospitalar.LevarValor("Triagem"); DadosHospitalar.ShowDialog();
        }
        private void tileGrafAtendimento_ItemClick(object sender, TileItemEventArgs e)
        {
            DadosHospitalar.LevarValor("Gráfico Atendimentos"); DadosHospitalar.ShowDialog();
        }



        #endregion
    }
}