using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.Models.Empresa;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Reports
{
    public partial class RelCabecalho : XtraReport
    {
        public RelCabecalho()
        {
            InitializeComponent();
            var DadosEmpresa = new Empresa()
            {
                codigo = UtilidadesGenericas.DadosEmpresa.codigo,
                Nome = UtilidadesGenericas.DadosEmpresa.Nome,
                NIF = "NIF: " + UtilidadesGenericas.DadosEmpresa.NIF,
                Morada = "LOCALIZAÇÃO: "+ UtilidadesGenericas.DadosEmpresa.Morada,
                Telefones ="CONTACTO: " + UtilidadesGenericas.DadosEmpresa.Telefones,
                WebSite ="WEB SITE: "+ UtilidadesGenericas.DadosEmpresa.WebSite,
                Email ="E-MAIL: "+ UtilidadesGenericas.DadosEmpresa.Email,
                Logotipo = UtilidadesGenericas.DadosEmpresa.Logotipo
            };
            objectDataSource1.DataSource = DadosEmpresa;

        }

    }
}
