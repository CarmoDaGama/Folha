using Folha.Domain.ViewModels.Hospitalar;
using Folha.Framework.Helpers;
using System;
using System.Collections.Generic;

namespace Folha.Application.Reports.Reports.Hospitalar
{
    public partial class RelExames : DevExpress.XtraReports.UI.XtraReport
    {
        public RelExames(List<ExamesViewModel> lab, string NomePaciente, DateTime DataNascimento, string civil, string Sexo/*, string Contacto*/)
        {
            InitializeComponent();
            xrSubreport1.ReportSource = new RelCabecalho();
            lbdataHoje.Text = DateTime.Now.ToShortDateString();
            var DataQuandoFezExame = lab[0].Data;
            string idade = UtilidadesGenericas.GetIntervaloDeAno(DataNascimento, DataQuandoFezExame).ToString();
            lbNascimento.Text = idade;
            lbDataImprecaoRotolo.Text = "| Data Impressão " + DateTime.Now.ToShortDateString();
            lbdataemissaoRodape.Text = "| Data Emissão " + lab[0].Data.ToShortDateString();
            lbPaciente.Text = NomePaciente;
            lbSexo.Text = Sexo;
            lbdataNascimento.Text = DataNascimento.ToShortDateString();
            lbdataAtendimento.Text = DataQuandoFezExame.ToShortDateString();
            lbProcesso.Text = lab[0].CodAtendimento.ToString();
            //lbContacto.Text = Contacto;

            objectDataSource1.DataSource = lab;

        }
    }
}
