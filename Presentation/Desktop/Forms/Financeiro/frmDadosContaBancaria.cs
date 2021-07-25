using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Principal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmDadosContaBancaria : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IContaBancariaApp _ContaBancariaApp;
        bool Editar = false;
        private readonly IGenericoApp _GenericoApp;

        public frmDadosContaBancaria(IContaBancariaApp ContaBancariaApp,IGenericoApp GenericoApp)
        {
            InitializeComponent();
            _ContaBancariaApp = ContaBancariaApp;
            _GenericoApp = GenericoApp;
            ///Controle.CamposBancarioG(txtCodBanco,txtDescricao);

        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btnContaBancaria_Click(object sender, EventArgs e)
        {
            
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }


        private void frmDadosContaBancaria_Load(object sender, EventArgs e)
        {
        }
        public frmDadosContaBancaria EditarConta(ContasBancarias Dados)
        {
            Editar = true;
            txtCodBanco.Text = Dados.CodBanco.ToString();
            txtBanco.Text = Dados.Descricao;
            txtCodConta.Text = Dados.codigo.ToString();
            txtNumero.Text = Dados.Numero;
            txtNatureza.Text = Dados.Natureza;
            txtIban.Text = Dados.Sequencia;
            txtSequencia.Text = Dados.Iban;
            txtSwift.Text = Dados.Swift;
            //ShowDialog();
            return this;
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
       
        private void btnSvFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBanco.Text))
            {
                UtilidadesGenericas.MsgShow(
                    "Selecione o Banco", 
                    "Conta Bancária", 
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK
                );
                return;
            }
            if (string.IsNullOrEmpty(txtNumero.Text))
            {
                UtilidadesGenericas.MsgShow(
                    "Insira o número da Conta", 
                    "Conta Bancária", 
                    MessageBoxIcon.Error, 
                    MessageBoxButtons.OK);
                return;
            }

           
            if (Editar)
            {
                try
                {
                    _ContaBancariaApp.Update(new ContasBancarias()
                    {
                        codigo = int.Parse(txtCodConta.Text),
                        CodBanco = Convert.ToInt16(txtCodBanco.Text),
                        Numero = txtNumero.Text,
                        Natureza = txtNatureza.Text,
                        Sequencia = txtIban.Text,
                        Iban = txtSequencia.Text,
                        Swift = txtSwift.Text
                    }, txtCodConta.Text);
                    frmContasBancarias chamada = IOC.InjectForm<frmContasBancarias>();
                    UtilidadesGenericas.ChamarNoPrincipal(chamada);
                }
                catch (Exception)
                {
                    throw new Exception("Erro ao Editar");
                }
            }
            else
            {
                try
                {
                    if (RegistroJaExiste())
                    {
                        return;
                    }
                    _ContaBancariaApp.Insert(new ContasBancarias()
                    {
                        CodBanco = Convert.ToInt16(txtCodBanco.Text),
                        Numero = txtNumero.Text,
                        Natureza = txtNatureza.Text,
                        Sequencia = txtSequencia.Text,
                        Iban = txtIban.Text,
                        Swift = txtSwift.Text
                    });
                    Close();
                }
                catch (Exception ex )
                {
                    throw new Exception("Erro ao cadastrar: " + ex.Message);
                }
                Close();
                frmContasBancarias chamada = IOC.InjectForm<frmContasBancarias>();
                UtilidadesGenericas.ChamarNoPrincipal(chamada);
            }
        }

        private bool RegistroJaExiste()
        {
            bool VerificaConta = _GenericoApp.VerificarRegisto("ContasBancarias", "Numero", txtNumero.Text);
            bool VerificaIban = _GenericoApp.VerificarRegisto("ContasBancarias", "Iban", txtSequencia.Text);
            if (VerificaConta || VerificaIban)
            {
                UtilidadesGenericas.MsgShow(
                    "Conta já existente, verifique os registos.",
                    "Conta Bancária",
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK);
                return true;
            }
            return false;
        }

        private void txtBanco_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmInteligente>();
            var unidade = form.GetSelecionado("Bancos", "Unidade Bancaria");

            if (Equals(unidade, null))
            {
                return;
            }
            else
            {
                txtCodBanco.Text = unidade.Codigo.ToString();
                txtBanco.Text = unidade.Descricao;
            }

        }

        private void btnVerLista_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmContasBancarias chamada = IOC.InjectForm<frmContasBancarias>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
        }
    }
}