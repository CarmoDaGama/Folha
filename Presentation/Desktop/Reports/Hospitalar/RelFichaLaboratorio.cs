using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Helpers;
using System;

namespace Folha.Presentation.Desktop.Reports.Hospitalar
{
    public partial class RelFichaLaboratorio : DevExpress.XtraReports.UI.XtraReport
    {
        public RelFichaLaboratorio(ExamesAtendimentoViewModel lab, string NomePaciente, DateTime DataNascimento, string civil, string Sexo, string Contacto)
        {
            InitializeComponent();

            xrSubreport1.ReportSource = new RelCabecalho();

            // dados pessoal 
            lbPaciente.Text = NomePaciente;
            lbSexo.Text = Sexo;
            var DataQuandoFezExame = lab.Data;
            string idade = UtilidadesGenericas.GetIntervaloDeAno(DataNascimento, DataQuandoFezExame).ToString();
            lbNascimento.Text = idade;
            lbdataNascimento.Text = DataNascimento.ToShortDateString();
            lbContacto.Text = Contacto;
            lbMedico.Text = "Requesitado por: " + lab.Medico;

            //dados do cabecalho
            lbProcesso.Text = lab.NumeroProcesso;
            lbAmostra.Text = lab.NumeroAmostra;
            lbData.Text = lab.Data.ToShortDateString();
            lbdataHoje.Text = DateTime.Now.ToShortDateString();

            //dados do detalhes 
            xrExame.Text = lab.ExamesHospitalar.Descricao;

            if (lab.TipoResultado == "PERCENTAGEM")
            {
                xrResultado.Text = lab.Estado + "%";
            }
            else
            {
                xrResultado.Text = lab.Estado;
            }
            xrUnidade.Text = lab.Unidade;
            xrReferencia.Text = lab.VReferencia;

            //Rodape

            lbTecnico.Text = "Tecnico de Laboratório: " + lab.ProfissionalSaude.Entidades.Nome;

            lbDataImprecaoRotolo.Text = "| Data Impressão " + DateTime.Now.ToShortDateString();
            lbdataemissaoRodape.Text = "| Data Emissão " + lab.Data.ToShortDateString();
        }

    }
}
