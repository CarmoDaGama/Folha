using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Folha.Presentation.Desktop.Reports.Vendas
{
    public partial class RelMotivos : DevExpress.XtraReports.UI.XtraReport
    {
        public RelMotivos(List<MotivoViewModel> motivos)
        {
            var thisMotivos = new List<MotivoViewModel>();
            thisMotivos.AddRange(motivos);
            foreach (var item in motivos)
            {
                var list = thisMotivos.Where(m => m.MotivoIsencao == item.MotivoIsencao).ToList();
                if (!UtilidadesGenericas.ListaNula(list) && list.Count > 1)
                {
                    thisMotivos.Remove(list.FirstOrDefault());
                }
            }
            InitializeComponent();
            objectDataSource1.DataSource = thisMotivos;
        }

    }
}
