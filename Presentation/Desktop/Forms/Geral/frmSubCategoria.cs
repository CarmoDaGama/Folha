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
using Folha.Presentation.Desktop.Forms.Armazens;
using Folha.Driver.Framework.IOC;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Models.Genericos;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Geral
{
    public partial class frmSubCategoria : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int codCategoria;
        private readonly ISubCategoriaApp _SubCategoriaApp;

        public frmSubCategoria(ISubCategoriaApp SubCategoriaApp)
        {
            InitializeComponent();
            _SubCategoriaApp = SubCategoriaApp;
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmCategorias>();
            form.btnselect.Visibility = BarItemVisibility.Always;

            var categoria = form.GetCategoria();
            if (Equals(categoria, null))
            {
                return;
            }
            else
            {
                codCategoria = categoria.codigo;
                txtCategoria.Text = categoria.descricao;
            }
        }

        private void GravarSubCategoria()
        {
            _SubCategoriaApp.Insert(new SubCategoria()
            {
                Descricao = txtDescricao.Text,
                CodCategoria = codCategoria,
            });
        }
        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Adicionar uma Descrição", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtCategoria.Text == "")
            {
                MessageBox.Show("Adicionar uma Categoria", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtCategoria.Text))
                {
                    GravarSubCategoria();
                    Close();
                }
                else MessageBox.Show("Selecione a Categoria", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UtilidadesGenericas.Busca.Alterou = true;
            }

        }

       
    }
}