using Folha.Domain.ViewModels.Documentos;
using Folha.Framework.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Folha.Application.Reports.Reports.Vendas
{
    public partial class RelMotivoIsencao2 : DevExpress.XtraReports.UI.XtraReport
    {
        public RelMotivoIsencao2(List<MotivoViewModel> motivos)
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
