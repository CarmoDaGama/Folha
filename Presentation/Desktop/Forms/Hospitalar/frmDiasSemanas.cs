using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmDiasSemanas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IDiasSemanaApp _dia;
        public DiasSemanas Semana { get; set; }
        private List<DiasSemanas> Lista { get; set; }
        public int Index { get; private set; } = -1;
        public int index;
        private int cod;

        public frmDiasSemanas(IDiasSemanaApp dia)
        {
            InitializeComponent();
            _dia = dia;
            Index = 0;
        }
        private void Mostrar()
        {
            Lista = (List<DiasSemanas>)_dia.Listar();
            gradeDias.DataSource = Lista;
        }
        public DiasSemanas GetSemana()
        {
            ShowDialog();
            if (Semana != (null) && Semana.IDDias > 0)
            {
                return Semana;
            }
            else
            {
                return null;
            }
        }
        private void btnSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Index < 0) return;
            Semana = Lista[Index];
            Close();
        }
      

        private void frmDiasSemanas_Load(object sender, System.EventArgs e)
        {
            Mostrar();
        }

       

        private void gridDias_DoubleClick(object sender, System.EventArgs e)
        {
            if (btnSelect.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
            {
                if (Index < 0) return;
                Semana = Lista[Index];
                Close();
            }
            else
            {
                return;
            }
        }

        private void gridDias_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Index = e.RowHandle;
            Semana = Lista[Index];
        }
    }
}