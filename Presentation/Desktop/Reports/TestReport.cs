using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using static DevExpress.DataAccess.Native.DataFederation.QueryBuilder.AvailableItemData;
using Folha.Domain.Models.Entidades;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports
{
    public partial class TestReport : XtraReport
    {
        public TestReport()
        {
            InitializeComponent();
            List<Entidades> listEntities = new List<Entidades>()
            {
                new Entidades()
                {
                    Codigo = 1,
                    Nome = "Carmo Da Gama",
                    Tipo = new TipoEntidade()
                    {
                        descricao = "PESSOA"
                    }
                },
                new Entidades()
                {
                    Codigo = 2,
                    Nome = "Joaquim Da Gama",
                    Tipo = new TipoEntidade()
                    {
                        descricao = "PESSOA"
                    }
                },
                new Entidades()
                {
                    Codigo = 3,
                    Nome = "Celma Da Gama",
                    Tipo = new TipoEntidade()
                    {
                        descricao = "PESSOA"
                    }
                },
                new Entidades()
                {
                    Codigo = 4,
                    Nome = "Lirio Da Gama",
                    Tipo = new TipoEntidade()
                    {
                        descricao = "PESSOA"
                    }
                },
                new Entidades()
                {
                    Codigo = 5,
                    Nome = "Necas Da Gama",
                    Tipo = new TipoEntidade()
                    {
                        descricao = "PESSOA"
                    }
                },
                new Entidades()
                {
                    Codigo = 6,
                    Nome = "MAnuela Romão",
                    Tipo = new TipoEntidade()
                    {
                        descricao = "PESSOA"
                    }
                }
            };
            objectDataSource1.DataSource = listEntities;
        }

    }
}
