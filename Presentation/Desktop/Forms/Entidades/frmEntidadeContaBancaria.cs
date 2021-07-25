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
using Folha.Presentation.Desktop.Separadores.Financeiro;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Helpers;
using Folha.Domain.Models.Entidades;
using Folha.Driver.Framework.IOC;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Entidades;
using Folha.Presentation.Desktop.Forms.Principal;

namespace Folha.Presentation.Desktop.Separadores.Entidades
{
    public partial class frmEntidadeContaBancaria : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private BancosViewModel banco = new BancosViewModel() { descricao = "BAI", codigo=1};

        private EntidadesContasViewModel Conta { get; set; }
        public frmEntidadeContaBancaria()
        {
            InitializeComponent();
            Conta = new EntidadesContasViewModel()
            {
                Banco = banco,
                CodBanco = 1,
                codigo = 0,
                Natureza = "Nenhum",
                Numero = "Nenhum",
                Sequencia = "Nenhum",
                iban = "Nenhum",
                swift = "Nenhum",
            };
        }

        private void btnBanco_Click(object sender, EventArgs e)
        {
            
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        public EntidadesContasViewModel GetConta()
        {
            ShowDialog();
            return Conta;
        }
        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidarField())
            {
                Conta = new EntidadesContasViewModel()
                {
                    Banco = Conta.Banco,
                    CodBanco = Conta.CodBanco,
                    codigo = Conta.codigo, 
                    Natureza = txtNatureza.Text,
                    Numero = txtNumero.Text,
                    Sequencia = txtSequencia.Text,
                    iban = txtIban.Text,
                    swift = txtSwift.Text
                };
                Close();
            }
        }

        private bool ValidarField()
        {
            bool validado = true;
            for (int i = panelFields.Controls.Count - 1; i >= 0; i--)
            {
                if (panelFields.Controls[i].Name.Contains("txt") && panelFields.Controls[i].Text == string.Empty)
                {
                    messageShow("Preencha o campo " + panelFields.Controls[i].Name.Replace("txt", ""));
                    validado = false;
                    break;
                }
            }
            return validado;
        }

        private void messageShow(string message)
        {
            MessageBox.Show(
                message,
                "MENSAGEM", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information
            );
        }

        private void btnGetBanco_Click(object sender, EventArgs e)
        {
            
        }

        public EntidadesContasViewModel EditarContacta(EntidadesContasViewModel entidadeConta)
        {
            Conta = null;
            Conta = entidadeConta;
            txtBanco.Text = entidadeConta.Banco.descricao;
            txtIban.Text = entidadeConta.iban;
            txtNatureza.Text = entidadeConta.Natureza;
            txtNumero.Text = entidadeConta.Numero;
            txtSequencia.Text = entidadeConta.Sequencia;
            txtSwift.Text = entidadeConta.swift;
            ShowDialog();

            return Conta;
        }

        private void txtBanco_Click(object sender, EventArgs e)
        {
            var formBanco = IOC.InjectForm<frmInteligente>();
            Conta.Banco = formBanco.GetSelecionado<BancosViewModel>("Bancos", "Bancos");
            if (!Equals(Conta.Banco, null))
            {
                Conta.CodBanco = Conta.Banco.codigo;
                txtBanco.Text = Conta.Banco.descricao;
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtBanco.Text = "";
            txtIban.Text = "";
            txtNatureza.Text = "";
            txtNumero.Text = "";
            txtSequencia.Text = "";
            txtSwift.Text = "";
            textEditCodigo.Text = "";
        }
    }

}