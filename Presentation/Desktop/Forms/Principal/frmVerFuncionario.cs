using System;
using DevExpress.XtraBars;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Driver.Framework.IOC;
using SimpleInjector;

namespace Folha.Presentation.Desktop.Separadores.Principal
{
    public partial class frmVerFuncionario : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmVerFuncionario()
        {
            InitializeComponent();
           
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btnNovaEntidade_Click(object sender, EventArgs e)
        {
            var container = new Container();
            IOC.RegistrarInjecao(container);
            container.GetInstance<frmEntidade>().ShowDialog();
        }
    }
}