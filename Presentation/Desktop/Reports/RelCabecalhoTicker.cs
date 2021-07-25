using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.Models.Empresa;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Reports
{
    public partial class RelCabecalhoTicker : DevExpress.XtraReports.UI.XtraReport
    {
        Empresa DadosEmpresa;
        public RelCabecalhoTicker()
        {
            InitializeComponent();
            var nome = "TREVO SOFT";
            var nif = "999999999";
            var morada = "Luanda, Viana";
            if (!string.IsNullOrEmpty(UtilidadesGenericas.DadosEmpresa.Nome))
            {
                nome = UtilidadesGenericas.DadosEmpresa.Nome;
            }
            if (!string.IsNullOrEmpty(UtilidadesGenericas.DadosEmpresa.NIF))
            {
                nif = UtilidadesGenericas.DadosEmpresa.NIF;
            }
            if (!string.IsNullOrEmpty(UtilidadesGenericas.DadosEmpresa.Morada))
            {
                morada = UtilidadesGenericas.DadosEmpresa.Morada;
            }
            DadosEmpresa = new Empresa()
            {
                codigo = UtilidadesGenericas.DadosEmpresa.codigo,
                Nome = nome,
                NIF = nif,
                Morada = morada,
                Telefones = "TEL: "+UtilidadesGenericas.DadosEmpresa.Telefones,
                WebSite = UtilidadesGenericas.DadosEmpresa.WebSite,
                Email ="E-MAIL: "+ UtilidadesGenericas.DadosEmpresa.Email,
                Logotipo = UtilidadesGenericas.DadosEmpresa.Logotipo
            };
            objectDataSource1.DataSource = DadosEmpresa;

        }

    }
}
