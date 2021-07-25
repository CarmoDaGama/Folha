using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.Helpers;
using Folha.Domain.Models.Empresa;

namespace Folha.Presentation.Desktop.Reports
{
    public partial class RelCabecalhoInterno : DevExpress.XtraReports.UI.XtraReport
    {
        Empresa DadosEmpresa;
        public RelCabecalhoInterno()
        {
            InitializeComponent();
            DadosEmpresa = new Empresa()
            {
                codigo = UtilidadesGenericas.DadosEmpresa.codigo,
                Nome = UtilidadesGenericas.DadosEmpresa.Nome,
                NIF = UtilidadesGenericas.DadosEmpresa.NIF,
                Morada = UtilidadesGenericas.DadosEmpresa.Morada,
                Telefones = UtilidadesGenericas.DadosEmpresa.Telefones,
                WebSite = UtilidadesGenericas.DadosEmpresa.WebSite,
                Email = UtilidadesGenericas.DadosEmpresa.Email,
                Logotipo = UtilidadesGenericas.DadosEmpresa.Logotipo
            };
            lbdata.Text = DateTime.Now.ToString();
            objectDataSource1.DataSource = DadosEmpresa;
        }

    }
}
