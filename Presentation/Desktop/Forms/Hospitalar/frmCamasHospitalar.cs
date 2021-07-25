using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Principal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmCamasHospitalar : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ICamasHospitalarApp _camasApp;

        private CamasHospitalar Camas;
        private CamasHospitalarViewModel Entity { get; set; }
        private int codTipoCama;
        private bool Changed { get; set; } = false;
        public frmCamasHospitalar(ICamasHospitalarApp camasApp)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            _camasApp = camasApp;
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!isFieldsValid()) return;
                var cama = PopulaObjecto();
                cama = _camasApp.Gravar(cama);
                PopularDadosEditar(cama.Codigo);
                txtCodigo.Text = cama.Codigo.ToString();
                UtilidadesGenericas.Busca.Alterou = true;
            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao Cadastrar Porfavor volte a Tentar!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private CamasHospitalar PopulaObjecto()
        {
            Camas = new CamasHospitalar()
            {
                Descricao = txtDescricao.Text,
                CodTiposCamasHospitalar = codTipoCama,               
            };

            if (!string.IsNullOrEmpty(txtCodigo.Text)) Camas.Codigo = int.Parse(txtCodigo.Text);
            return Camas;
        }
        private void PopularDadosEditar(int Codigo)
        {
            if (Codigo == 0) return;
            Entity = _camasApp.GetById(Codigo);
            txtDescricao.Text = Entity.Descricao;
            txtTipoCamas.Text = Entity.TiposCamasHospitalar.Descricao;
            codTipoCama = Entity.CodTiposCamasHospitalar;
        }
        private void frmCamasHospitalar_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UtilidadesGenericas.Busca.Codigo))
            {
                txtCodigo.Text = UtilidadesGenericas.Busca.Codigo;
                int Codigo = int.Parse(txtCodigo.Text);
                var camas = _camasApp.GetById(Codigo);
                if (Codigo > 0) PopularDadosEditar(Codigo);
            }
        }
        private void btnBusca_Click(object sender, EventArgs e)
        {
            var TipoCamas =  IOC.InjectForm<frmInteligente>().GetSelecionado("TiposCamasHospitalar", "Tipo de Camas Hospitalar");
            if (Equals(TipoCamas, null))
            {
                return;
            }
            else
            {
                codTipoCama = TipoCamas.Codigo;
                txtTipoCamas.Text = TipoCamas.Descricao;
            }
        }
        #region VALIDAÇÃO
        private void messageShow(string message)
        {
            MessageBox.Show(
                message,
                "INFORMAÇÃO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        private bool isFieldsValid()
        {
            bool valid = true;
            if (txtDescricao.Text.Equals(string.Empty))
            {
                messageShow("Digita a descrição da Cama");
                return false;
            }
            if (txtTipoCamas.Text.Equals(string.Empty))
            {
                messageShow("Escolha uma tipo de Cama");
                return false;
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Descricao", txtDescricao.Text);

            if (txtCodigo.Text == "" && _camasApp.VerificarDup("CamasHospitalar", d))
            {
                messageShow("Já Existe Cama com o nome de: " +txtDescricao.Text+" Verifica nos Registros !");
                return false;
            }
           
            return valid;
        }
        #endregion
        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            var cama = PopulaObjecto();
            cama = _camasApp.Gravar(cama);
            PopularDadosEditar(cama.Codigo);
            txtCodigo.Text = cama.Codigo.ToString();
            UtilidadesGenericas.Busca.Alterou = true;
            Close();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}