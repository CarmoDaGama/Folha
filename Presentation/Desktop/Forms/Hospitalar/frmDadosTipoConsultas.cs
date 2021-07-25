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
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Presentation.Desktop.Forms.Armazens;
using Folha.Driver.Framework.IOC;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Helpers;
using Folha.Domain.Models.Inventario;
using Folha.Presentation.Desktop.Forms.Principal;
using Folha.Domain.ViewModels.Inventario;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmDadosTipoConsultas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ITipoConsultasApp _TipoConsultasApp;
        private string CodTipoConsulta;
        private int codImposto;
        private int codMotivoInsencao=0;
        private int codEspecialidade;

        List<TipoConsultaViewModel> LtTipoConsultas;

        private ImpostoViewModel Imposto { get; set; }

        public frmDadosTipoConsultas(ITipoConsultasApp TipoConsultasApp)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            _TipoConsultasApp = TipoConsultasApp;
        }
        public void EditarTipoConsultas(List<TipoConsultaViewModel> Dados)
        {
            this.LtTipoConsultas = Dados;
            CodTipoConsulta = Dados[0].Codigo.ToString();
            txtDescricao.Text = Dados[0].Descricao;
            txtValor.Text = Dados[0].Valor.ToString("N2");
            timeHora.EditValue = Dados[0].Tempo;
            codEspecialidade = Dados[0].CodEspecialidade;
            txtEspecialidade.Text = Dados[0].Especialidade;
            codImposto = Dados[0].CodImposto;
            txtImposto.Text = Dados[0].Imposto;
            codMotivoInsencao = Dados[0].CodMotivoIsencao;
            txtMotivoIsencao.Text = Dados[0].MotivoIsencao;
            txtValorIva.Text = Convert.ToDouble(Dados[0].Percentagem).ToString("N2");
            ShowDialog();

        }
        private void MetSalva()
        {
            try
            {
                if (txtEspecialidade.Text == "")
                {
                    MessageBox.Show("Escolha uma Especilidade!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                _TipoConsultasApp.Insert(new TipoConsultas()
                {                    
                    Descricao = txtDescricao.Text,
                    Valor= Convert.ToDouble(txtValor.Text),
                    Tempo=timeHora.Text,
                    CodEspecialidade = codEspecialidade,
                    CodImposto=codImposto,
                    CodMotivoIsencao = codMotivoInsencao
                });
            }
            catch (Exception)
            {
                throw new Exception("Erro ao cadastrar ");
            }

        }

        private void MetEdit()
        {
            try
            {
                _TipoConsultasApp.Update(new TipoConsultas()
                {
                    Codigo = int.Parse(CodTipoConsulta),
                    Descricao = txtDescricao.Text,
                    Valor = Convert.ToDouble(txtValor.Text),
                    Tempo = timeHora.Text,
                    CodEspecialidade = codEspecialidade,
                    CodImposto = codImposto,
                    CodMotivoIsencao = codMotivoInsencao
                });
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cadastrar " + e.Message);
            }
        }
        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CamposValidos())
            {
                if (string.IsNullOrEmpty(CodTipoConsulta))
                {
                    MetSalva();
                    MessageBox.Show("Dados cadastrados com sucesso!", "Moedas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MetEdit();
                    MessageBox.Show("Dados actualizados com sucesso!", "Moedas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }

        private bool CamposValidos()
        {
            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                UtilidadesGenericas.MsgShow("Insira a descrição do tipo de consulta");
                return false;
            }
            if (string.IsNullOrEmpty(txtImposto.Text))
            {
                UtilidadesGenericas.MsgShow("Insira o imposto do tipo de consulta");
                return false;
            }
            if (Equals(txtImposto.Text.ToLower(), "isento") && string.IsNullOrEmpty(txtMotivoIsencao.Text))
            {
                UtilidadesGenericas.MsgShow("Insira o motivo de isenção do\n imposto do tipo de consulta");
                return false;
            }
            if (string.IsNullOrEmpty(timeHora.Text))
            {
                UtilidadesGenericas.MsgShow("Insira a duração do tipo de consulta");
                return false;
            }
            if (string.IsNullOrEmpty(txtValor.Text))
            {
                UtilidadesGenericas.MsgShow("Insira o preço do tipo de consulta");
                return false;
            }
            return true;
        }

        private void btnImposto_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmImpostos>();
            form.btnselect.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            Imposto = form.GetImposto();
            if (Equals(Imposto, null))
            {
                return;
            }
            codImposto = Imposto.Codigo;
            txtImposto.Text = Imposto.Descricao;
            var valor = string.IsNullOrEmpty(txtValor.Text)? 0.0m : Convert.ToDecimal(txtValor.Text);

            txtValorIva.Text = (valor * (Imposto.Percentagem / 100)).ToString("N2");
            if(Equals(Imposto.Descricao.ToLower(), "isento"))
            {
                btnMotivoIsencao.Enabled = true;
            }
            else
            {
                btnMotivoIsencao.Enabled = false;
                txtMotivoIsencao.Text = "";
            }
        }

        private void btnMotivoIsencao_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmMotivoIsencao>();
            form.btnSelecionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            var motivoIsencao = form.GetMotivoIsencao();
            if (Equals(motivoIsencao, null)) { return; }
            codMotivoInsencao = motivoIsencao.Codigo;
            txtMotivoIsencao.Text = motivoIsencao.Descricao;
        }

        private void btnEspecialidade_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmInteligente>();
            var especilidade = form.GetSelecionado("Especialidades", "Especialidades ");

            if (Equals(codEspecialidade, null))
            {
                return;
            }
            else
            {
                codEspecialidade = especilidade.Codigo;
                txtEspecialidade.Text = especilidade.Descricao;
            }
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            if (!Equals(Imposto, null))
            {
                txtValorIva.Text = (Convert.ToDecimal(txtValor.Text) * (Imposto.Percentagem / 100)).ToString("N2");
            }
        }

        private void Clo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CamposValidos())
            {
                if (string.IsNullOrEmpty(CodTipoConsulta))
                {
                    MetSalva();
                    Close();
                }
                else
                {
                    MetEdit();
                    Close();
                }
            }
        }
    }
}