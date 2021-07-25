using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Models.Inventario;
using Folha.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Separadores.Armazens
{
    public partial class frmArmazens : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IArmazemApp _armazemApp;

        public frmArmazens(IArmazemApp armazemApp)
        {
            InitializeComponent();

            _armazemApp = armazemApp;
        }

        private void frmArmazens_Load(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.Busca.Editar)
            {
                txtcodigo.Text = UtilidadesGenericas.Busca.Codigo;
                txtDescricao.Text = UtilidadesGenericas.Busca.Descricao;
            }
        }

        public void CadatrarEdtar()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("descricao", txtDescricao.Text);
            if (txtDescricao.Text == "" && _armazemApp.VerificarDup("Armazens", d))
            {
                MessageBox.Show("Já Existe esse Nome, Verifica nos Registros ");
            }
            if (UtilidadesGenericas.Busca.Editar)
            {
                try
                {
                    _armazemApp.Update(new Domain.Models.Inventario.Armazens()
                    {
                        codigo = int.Parse(txtcodigo.Text),
                        descricao = txtDescricao.Text,
                    }
                    );
                    UtilidadesGenericas.Busca.Editar = false;
                }
                catch (Exception erro)
                {
                    throw new Exception("Erro ao cadastrar " + erro.Message);
                }
            }
            else
            {
                try
                {
                    _armazemApp.Insert(new Domain.Models.Inventario.Armazens()
                    {
                        descricao = txtDescricao.Text
                    });
                }
                catch (Exception erro)
                {
                    throw new Exception("Erro ao cadastrar  " + erro.Message);
                }
            }
        }
        private void btnSarlvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            CadatrarEdtar();
            MessageBox.Show("Dados Cadastrados com sucesso!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        private void limpar()
        {
            txtcodigo.Text = "";
            txtDescricao.Text = "";
        }
        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
            limpar();
        }
    }
}