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
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using Folha.Driver.Framework.IOC;
using SimpleInjector;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmFPagamentosCad : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IFPagamentosApp _FPagamentos;
        bool Editar=false;
        private readonly IGenericoApp _GenericoApp;

        public frmFPagamentosCad(IFPagamentosApp FPagamentos,IGenericoApp GenericoApp)
        {
            InitializeComponent();
            _FPagamentos = FPagamentos;
            _GenericoApp = GenericoApp;
        }
        private void frmFPagamentosCad_Load(object sender, EventArgs e)
        {

        }
        public frmFPagamentosCad EditarFPagamento(Mostrar Dados)
        {
            Editar = true;
            txtCodigo.Text = Dados.Codigo.ToString();
            txtDescricao.Text = Dados.Descricao;
            txtCodConta.Text = Dados.CodConta.ToString();
            txtBanco.Text = Dados.Banco;
            txtNumeroConta.Text = Dados.ContaBancaria;
            //ShowDialog();
            return this;
        }
        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TemRequisitos())
            {
                if (Editar)
                {
                    try
                    {
                        _FPagamentos.addFPagamentos(new fPagamentos()
                        {
                            descricao = txtDescricao.Text,
                            Movimentar = txtMovimentar.Text,
                            CodConta = txtCodConta.Text
                        }, "Codigo='" + txtCodigo.Text + "'");

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao editar:\n" + ex.Message);
                    }
                    Editar = false;
                    var _form = IOC.InjectForm<frmFPagamento>();
                    UtilidadesGenericas.ChamarNoPrincipal(_form);
                }
                else
                {
                    try
                    {
                        bool VerifFPagamento = _GenericoApp.VerificarRegisto("fPagamentos", "descricao", txtDescricao.Text);
                        bool VerifConta = _GenericoApp.VerificarRegisto("fPagamentos", "CodConta", txtCodConta.Text);

                        if (VerifFPagamento || VerifConta) {
                            UtilidadesGenericas.MsgShow(
                                "AVISO", 
                                "Registo já existente!", 
                                MessageBoxIcon.Error, 
                                MessageBoxButtons.OK
                            );
                            return; }


                        _FPagamentos.addFPagamentos(new fPagamentos()
                        {
                            descricao = txtDescricao.Text,
                            Movimentar = txtMovimentar.Text,
                            CodConta = txtCodConta.Text
                        }, txtCodigo.Text);

                    }
                    catch (Exception)
                    {
                        throw new Exception("Erro ao cadastrar\n");
                    }
                }
                var form = IOC.InjectForm<frmFPagamento>();
                UtilidadesGenericas.ChamarNoPrincipal(form);
            }
            
        }

        private bool TemRequisitos()
        {
            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                UtilidadesGenericas.MsgShow(
                    "Informação",
                    "É Preciso Informar o Nome da Tesouraria",
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK
                );
                return false;
            }
            if (string.IsNullOrEmpty(txtCodConta.Text))
            {
                UtilidadesGenericas.MsgShow(
                    "Informação",
                    "É Preciso informar uma conta bancária",
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK
                );
                return false;
            }
            return true;
        }

        private void btnContaBancaria_Click_1(object sender, EventArgs e)
        {
            var chamada = IOC.InjectForm<frmContasBancarias>();
            //UtilidadesGenericas.ChamarNoPrincipal();
            var conta = chamada.GetContaBancaria();
            if (conta == null) return;
            
            txtCodConta.Text = conta.codigo.ToString();
            txtBanco.Text = conta.Descricao;
            txtNumeroConta.Text = conta.Numero;

        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

       
    }
}