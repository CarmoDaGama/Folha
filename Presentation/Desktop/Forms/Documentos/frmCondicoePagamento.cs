using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Models.Documentos;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Documentos
{
    public partial class frmCondicoePagamento : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ICondicoesPagamentoApp _condicoesApp;

        public frmCondicoePagamento(ICondicoesPagamentoApp condicoesApp)
        {
            InitializeComponent();
            _condicoesApp = condicoesApp;
        }
         private void frmCondicoePagamento_Load(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.Busca.Editar)
            {
                txtCodigo.Text = UtilidadesGenericas.Busca.Codigo;
                txtDescricao.Text = UtilidadesGenericas.Busca.Descricao;
                txtDias.Text = UtilidadesGenericas.Busca.Dias;
            }

        }
        private bool isFieldsValid()
        {
            bool valid = true;
            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Insira uma Descricao !", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Descricao", txtDescricao.Text);
            if (txtCodigo.Text == "" && _condicoesApp.VerificarDup("CondicoesPagamentos", d))
            {
                MessageBox.Show("Já Existe Nome, Verifica nos Registros ");
                return false;
            }
            if (UtilidadesGenericas.CalculosFinanceiros.IsNumeric(txtDias.Text) == false)
            {
                MessageBox.Show("Formato dos Dias Invalido", "Informe a Quantidade Numerica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return valid;
        }
        public void CadatrarEdtar()
        {
            if (UtilidadesGenericas.Busca.Editar)
            {
                try
                {
                    _condicoesApp.Update(new CondicoesPagamento()
                    {
                        Codigo = int.Parse(txtCodigo.Text),
                        Descricao = txtDescricao.Text,
                        Dias = int.Parse(txtDias.Text)
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
                    _condicoesApp.Insert(new CondicoesPagamento()
                    {
                        Descricao = txtDescricao.Text,
                        Dias = int.Parse(txtDias.Text)
                    });

                }
                catch (Exception erro)
                {
                    throw new Exception("Erro ao Cadastrar " + erro.Message);
                }
            }
        }

        private void btnsalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            CadatrarEdtar();
            UtilidadesGenericas.Busca.Alterou = true;
            frmCondicoesPagamento chamada = IOC.InjectForm<frmCondicoesPagamento>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtCodigo.Text = "";
            txtDescricao.Text = "";
            txtDias.Text = "";
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCondicoesPagamento chamada = IOC.InjectForm<frmCondicoesPagamento>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
        }
    }
}