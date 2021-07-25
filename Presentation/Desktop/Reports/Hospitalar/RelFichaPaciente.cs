using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Reports.Hospitalar
{
    public partial class RelFichaPaciente : XtraReport
    {
        public RelFichaPaciente(PacienteViewModel paciente)
        {
            InitializeComponent();

            lbPaciente.Text = paciente.Nome;
            lbNascimento.Text = paciente.DataNascimento.ToShortDateString();
            lbSexo.Text =  paciente.Sexo;
            lbNomePai.Text = paciente.Pai;
            lbNomeMae.Text = paciente.Mae;
            lbNacionalidade.Text = paciente.Nacionalidade.Descricao;
            lbGrupoSanguineo.Text = paciente.GrupoSanguineo.Descricao;
            lbEstadoCivil.Text = paciente.EstadoCivil;
            picImagem.Image = Imagens.Byte_Imagem(paciente.Foto);

            lbIdentificacao.Text = paciente.Nif;
            lbMorada.Text = paciente.Morada;
            lbContacto1.Text = paciente.Contacto1;
            lbContacto2.Text = paciente.Contacto2;
            xrSubreport1.ReportSource = new RelCabecalho();

        }

    }
}
