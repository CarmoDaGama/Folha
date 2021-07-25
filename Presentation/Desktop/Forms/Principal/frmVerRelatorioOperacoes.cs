using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Principal;

namespace Folha.Presentation.Desktop.Separadores.Principal
{
    public partial class frmVerRelatorioOperacoes : DevExpress.XtraEditors.XtraForm
    {

        public frmVerRelatorioOperacoes()
        {
            InitializeComponent();

        }


        private void FormVerRelatorioDocumentos_Load(object sender, EventArgs e)
        {

        }

  
        private void tileLtOperacoes_ItemClick(object sender, TileItemEventArgs e)
        {
            var form = IOC.InjectForm<frmRelDadosDocumentos>();
            form.ImprimirListaOp();
        }

        private void tileGrafOperacoes_ItemClick(object sender, TileItemEventArgs e)
        {
            var form = IOC.InjectForm<frmRelDadosDocumentos>();
            form.ImprimirGrafTotOp();
        }

        private void tilePeriodoMov_ItemClick(object sender, TileItemEventArgs e)
        {
            var form = IOC.InjectForm<frmRelDadosDocumentos>();
            form.ImprimirGrafPeriodoMov();
        }
    }
}