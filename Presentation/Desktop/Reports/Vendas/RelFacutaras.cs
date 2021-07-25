using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Reports.Vendas
{
    public partial class RelFacutaras : XtraReport
    {
        public RelFacutaras(List<DocumentoPagamentoViewModel> docs)
        {
            InitializeComponent();
            if (!UtilidadesGenericas.ListaNula(docs))
            {
                if (docs[0].DescricaoDocumento.Contains("ANULAÇÃO-"))
                {
                    lblTitulo.Text = "RECTIFICAÇÃO REFERENTE À ";
                    docs[0].DescricaoDocumento = docs[0].DescricaoDocumento.Replace("ANULAÇÃO-", string.Empty);

                }
                else
                {
                    //lblTitulo.Text += " " + docs[0].DescricaoDocumento;
                    //docs.RemoveAt(0);
                }
            }
            else
            {
                Visible = false;
            }
            
            objectDataSource1.DataSource = docs;
        }

    }
}
