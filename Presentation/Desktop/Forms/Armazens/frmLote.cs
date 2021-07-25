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
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Separadores.Armazens;

namespace Folha.Presentation.Desktop.Forms.Armazens
{
    public partial class frmLote : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ILoteArtigoApp _lote;
        private Lote lote;
        private LoteViewModel Entity { get; set; }
        private List<LoteArtigosViewModel> listaLote;


        private int codloteArtigo;
        private int CodArtigo;
        private int codDelete;
        private int indexLote;
        public int LoteArtigoId { get; private set; }
        public frmLote(ILoteArtigoApp lote)
        {
            InitializeComponent();
            _lote = lote;
        }
        private void btnArtigo_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void gradeConsultas_Click(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

            var form = IOC.InjectForm<frmBuscaArtigos>();
            var ArtigoBusca = form.GetArtigo();

            if (Equals(ArtigoBusca, null) || Equals(ArtigoBusca.codigo, 0))
            {
                return;
            }
            codloteArtigo = ArtigoBusca.codigo;

            if (Equals(listaLote, null))
            {
                listaLote = new List<LoteArtigosViewModel>();
            }
            var newAreaSaude = (new LoteArtigosViewModel()
            {
                CodProduto = ArtigoBusca.codigo,
                Artigo = ArtigoBusca.Artigo,
                Descricao = ArtigoBusca.Artigo.descricao,
            });
            //if (listaLote.Count > 0 && ContemNaListasSub(newAreaSaude.CodAreaSaude))
            //{
            //    MessageBox.Show("Já está Adicionado", "Erro ao Adicionar ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            listaLote.Add(newAreaSaude);
            gradeLote.DataSource = null;
            gradeLote.DataSource = listaLote;
        }
    }
}