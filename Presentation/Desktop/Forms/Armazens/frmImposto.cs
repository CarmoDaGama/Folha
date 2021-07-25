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
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Principal;
using Folha.Domain.ViewModels.Inventario;

namespace Folha.Presentation.Desktop.Forms.Armazens
{
    public partial class frmImposto : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public bool Editado { get; set; } = false;

        private readonly IImpostoApp _impostoApp;
        public ImpostoViewModel Imposto { get; set; }
        private string validaPreco = ("qwertyuiop+´´asdfghjklçº~<zxcvbnm-/*-+_^`*ª»?=)(//&%$#:;|!#$%&/()=?»><*^ª%_:--»º|!?»`^ª[]}[}*-+^^`*");


        public frmImposto(IImpostoApp impostoAppApp)
        {
            InitializeComponent();
            _impostoApp = impostoAppApp;
        }
        public bool EditarImposto(ImpostoViewModel imposto)
        {
            UtilidadesGenericas.Busca.Editar = true;
            Imposto = imposto;
            ShowDialog();
            return Editado;
        }
     
        private void frmImposto_Load(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.Busca.Editar)
            {
                txtCodigo.Text = Imposto.Codigo.ToString();
                txtDescricao.Text = Imposto.Descricao;
                txtPercentagem.Text = Imposto.Percentagem.ToString("N2");
                txtSigla.Text = Imposto.Sigla;
                txtCodTipo.Text = Imposto.Tipo.Codigo.ToString();
                txtTipo.Text = Imposto.Tipo.Descricao;
            }
        }
        public void CadatrarEdtar()
        {

            if (UtilidadesGenericas.Busca.Editar)
            {
                try
                {
                    _impostoApp.Update(new ImpostoViewModel()
                    {
                        Codigo = int.Parse(txtCodigo.Text),
                        Descricao = txtDescricao.Text,
                        CodTipo = int.Parse(txtCodTipo.Text),
                        Sigla = txtSigla.Text,
                        Percentagem = decimal.Parse(txtPercentagem.Text.Replace("%", string.Empty))
                    }
                    );
                    Close();
                    UtilidadesGenericas.Busca.Editar = false;
                }
                catch (Exception erro)
                {
                    throw new Exception("Erro ao Editar " + erro.Message);
                }
            }
            else
            {
                try
                {
                    _impostoApp.Insert(new ImpostoViewModel()
                    {
                        Descricao = txtDescricao.Text,
                        CodTipo = int.Parse(txtCodTipo.Text),
                        Sigla = txtSigla.Text,
                        Percentagem = decimal.Parse(txtPercentagem.Text.Replace("%", string.Empty))
                    });
                    UtilidadesGenericas.Busca.Editar = false;

                    Close();
                }
                catch (Exception erro)
                {
                    throw new Exception("Erro ao cadastrar " + erro.Message);
                }
            }
        }

        private bool isFieldsValid()
        {
            bool valid = true;
            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Insira uma Descricao!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTipo.Text == "")
            {
                MessageBox.Show("Insira uma Tipo!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtSigla.Text == "")
            {
                MessageBox.Show("Insira uma Sigla!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtPercentagem.Text == "")
            {
                MessageBox.Show("Insira uma Percentagem!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Descricao", txtDescricao.Text);
            if (txtCodigo.Text == "" && _impostoApp.VerificarDup("Imposto", d))
            {
                MessageBox.Show("Já Existe Nome, Verifica nos Registros ");
                return false;
            }
            return valid;
        }

        private void btnsalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            CadatrarEdtar();

            frmImpostos chamada = IOC.InjectForm<frmImpostos>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);

            UtilidadesGenericas.Busca.Alterou = true;
        }

        private void txtPercentagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validaPreco.Contains(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.Busca.Editar = false;

            Close();
        }

        private void btnTipoImposto_Click(object sender, EventArgs e)
        {
           
        }

        private void txtTipo_EditValueChanged(object sender, EventArgs e)
        {
            //var tipo = IOC.InjectForm<frmInteligente>().GetSelecionado("TipoImposto", "Tipo De Imposto");
            //if (Equals(tipo, null) || Equals(tipo, 0))
            //{
            //    return;
            //}
            //txtCodTipo.Text = tipo.Codigo.ToString();
            //txtTipo.Text = tipo.Descricao;
        }

        private void txtTipo_Click(object sender, EventArgs e)
        {
            var tipo = IOC.InjectForm<frmInteligente>().GetSelecionado("TipoImposto", "Tipo De Imposto");
            if (Equals(tipo, null) || Equals(tipo, 0))
            {
                return;
            }
            txtCodTipo.Text = tipo.Codigo.ToString();
            txtTipo.Text = tipo.Descricao;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtCodigo.Text = "";
            txtCodTipo.Text = "";
            txtDescricao.Text = "";
            txtPercentagem.Text = "";
            txtSigla.Text = "";
            txtTipo.Text = ""; 
        
        }

        private void btnverListagem_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmImpostos chamada = IOC.InjectForm<frmImpostos>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
        }
    }
}