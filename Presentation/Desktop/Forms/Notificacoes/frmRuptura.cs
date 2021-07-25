using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.ViewModels.Report;


namespace Folha.Presentation.Desktop.Forms.Notificacoes
{
    public partial class frmRuptura : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        List<RelListagemArtigosViewModel> LtArtigo;
        private readonly IArtigoStockApp _ArtigoStockApp;
        private readonly IArmazemApp _ArmazemApp;
        private List<Folha.Domain.Models.Inventario.Armazens> LtArmazem;

        public frmRuptura(IArtigoStockApp ArtigoStockApp,IArmazemApp ArmazemApp)
        {
            InitializeComponent();
            _ArtigoStockApp = ArtigoStockApp;
            _ArmazemApp = ArmazemApp;
            LtArmazem = (List<Folha.Domain.Models.Inventario.Armazens>)_ArmazemApp.Listar(null,false);
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmRuptura_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < LtArmazem.Count; i++)
            {
                cboArmazem.Properties.Items.Add(LtArmazem[i].descricao);
            }
            cboArmazem.SelectedIndex = 0;
            LtArtigo = (List<RelListagemArtigosViewModel>)_ArtigoStockApp.RupturaStock(null);
            gradeArtigo.DataSource = LtArtigo;
        }

        private void cboArmazem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboArmazem.Text=="Todos")
            {
                LtArtigo = (List<RelListagemArtigosViewModel>)_ArtigoStockApp.RupturaStock(null);
                gradeArtigo.DataSource = LtArtigo;
            }
            else
            {
                LtArtigo = (List<RelListagemArtigosViewModel>)_ArtigoStockApp.RupturaStock(LtArmazem[cboArmazem.SelectedIndex - 1].codigo.ToString());
                gradeArtigo.DataSource = LtArtigo;
            }
            
        }
    }
}