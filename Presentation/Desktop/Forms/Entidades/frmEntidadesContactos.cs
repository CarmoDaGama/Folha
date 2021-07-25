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
using Folha.Domain.Models.Entidades;
using Folha.Driver.Framework.IOC;
using Folha.Domain.ViewModels.Entidades;
using Folha.Presentation.Desktop.Forms.Principal;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Separadores.Entidades
{
    public partial class frmEntidadesContactos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ContactosViewModel Contacto { get; set; }

        public frmEntidadesContactos( )
        {
            InitializeComponent();
            Contacto = new ContactosViewModel()
            {
                codigo = 0,
                descricao = "Nenhum",
                Tipo = new TipoContactoViewModel() { codigo = 0, descricao = "Nenhum" }
            };
            
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnTipoContacto_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtCodTipo.Text == "")
            {
                MessageBox.Show("Preencha o tipo de contacto!");
                return;
            }
            if(txtDescricao.Text == "")
            {
                MessageBox.Show("Preencha a descrição!");
                return;
            }


            if (Contacto == null)
            {
                Contacto = new ContactosViewModel()
                {
                    codigo=0,
                    CodEntidade = 0,
                    descricao = "Nenhum"
                };
            }
            Contacto.descricao = txtDescricao.Text;
            Close();
        }

        private void frmEntidadesContactos_Load(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.Busca.Editar)
            {
                txtCodTipo.Text = UtilidadesGenericas.Busca.Codigo;
                txtTipoContacto.Text = UtilidadesGenericas.Busca.CodConta;
                txtDescricao.Text = UtilidadesGenericas.Busca.Descricao;
            }
        }

        public ContactosViewModel EditarContacto(ContactosViewModel oldContacto)
        {
            Contacto = null;
            Contacto = oldContacto;
            txtCodTipo.Text = Contacto.CodTipoContacto.ToString();
            txtTipoContacto.Text = Contacto.Tipo.descricao;
            txtDescricao.Text = Contacto.descricao;
            ShowDialog();

            return Contacto;
        }

        private void txtTipoContacto_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmInteligente>();

            Contacto.Tipo = form.GetSelecionado<TipoContactoViewModel>("TipoContacto");
            if (!Equals(Contacto.Tipo, null))
            {
                Contacto.CodTipoContacto = Contacto.Tipo.codigo;
                txtTipoContacto.Text = Contacto.Tipo.descricao;
                txtCodTipo.Text = Contacto.CodTipoContacto.ToString();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtCodTipo.Text = "";
            txtDescricao.Text = "";
            txtTipoContacto.Text = "";
        }
    }
}