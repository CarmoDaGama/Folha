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
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Principal;
using Folha.Presentation.Desktop.Forms.Armazens;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmTarifasHospitalar : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ITarifaHospitalarApp _tarifaApp;

        private TarifaHospitalar tarefa;
        private int codTipoQuarto;
        private int codTipoCama;
        private int codImposto;
        private int codMotivoIsento;

        private string validar = ("|!qwertyuiop+asdfghjkl>><<zxcvbnm,.#$%&/()=?»\''««´+~º-.,.-*/+_::;ª^`*»?=|\\");


        private TarifaHospitalarViewModel Entity { get; set; }
        private bool Changed { get; set; } = false;

        public frmTarifasHospitalar(ITarifaHospitalarApp tarifaApp)
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;

            _tarifaApp = tarifaApp;
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
                messageShow("Preencha o campo Descrição");
                return false;
            }

            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Descricao", txtDescricao.Text);
            if (txtCodigo.Text == "" && _tarifaApp.VerificarDup("TarifaHospitalar", d))
            {
                messageShow("Já Existe essa Tarifa Hospitalar Verifica nos Registros ");
                return false;
            }

            if (txtDescricao.Text.Equals(string.Empty))
            {
                messageShow("Digita uma Descricao");
                return false;
            }
            if (txtipoQuarto.Text.Equals(string.Empty))
            {
                messageShow("Adicionar um Tipo de Quarto");
                return false;
            }
            if (txtTipoCama.Text.Equals(string.Empty))
            {
                messageShow("Escolha um Tipo de Cama");
                return false;
            }
            if (cboTarifa.Text.Equals(string.Empty))
            {
                messageShow("Escolha um Tipo de Tarifa");
                return false;
            }
            if (txtImposto.Text.Equals(string.Empty))
            {
                messageShow("Escolha um Imposto");
                return false;
            }
            if (txtValor.Text.Equals(string.Empty))
            {
                messageShow("Escolha um Valor da Tarifa");
                return false;
            }
            return valid;
        }
       
        #endregion
        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!isFieldsValid()) return;
                var tarefa = PopulaObjecto();
                tarefa = _tarifaApp.Gravar(tarefa);
                PopularDadosEditar(tarefa.Codigo);
                txtCodigo.Text = tarefa.Codigo.ToString();
                UtilidadesGenericas.Busca.Alterou = true;
            }
            catch (Exception)
            {

                MessageBox.Show("ERRO AO SALVAR VERIFICA OS DADOS !", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void PopularDadosEditar(int Codigo)
        {
            if (Codigo == 0) return;
            Entity = _tarifaApp.GetById(Codigo);
            txtDescricao.Text = Entity.Descricao;
            txtipoQuarto.Text = Entity.TiposQuartosHospitalar.Descricao;
            txtTipoCama.Text = Entity.TiposCamasHospitalar.Descricao;
            cboTarifa.SelectedItem = Entity.TipoTarifa;
            txtImposto.Text = Entity.Imposto.Descricao;
            txtMotivoIsencao.Text = Entity.MotivoIsencao.Descricao;
            txtTempoHora.Text = Entity.Horas.ToString();
            txtValor.Text = Entity.Valor.ToString();
            codTipoQuarto = Entity.CodTiposQuartosHospitalar;
            codTipoCama = Entity.CodTiposCamasHospitalar;
            codImposto = Entity.CodImposto;
            codMotivoIsento = Entity.CodMotivoIsencao;
        }
        private TarifaHospitalar PopulaObjecto()
        {
            tarefa = new TarifaHospitalar()
            {
                Descricao = txtDescricao.Text,
                CodTiposQuartosHospitalar = codTipoQuarto,
                CodTiposCamasHospitalar = codTipoCama,
                CodImposto = codImposto,
                CodMotivoIsencao= codMotivoIsento,
                TipoTarifa = cboTarifa.SelectedItem.ToString(),
                Horas = int.Parse(txtTempoHora.Text),
                Valor = decimal.Parse(txtValor.Text)
            };

            if (!string.IsNullOrEmpty(txtCodigo.Text)) tarefa.Codigo = int.Parse(txtCodigo.Text);
            return tarefa;
        }
        private void btnBuscaTipoQuarto_Click(object sender, EventArgs e)
        {
            var TipoQuarto = IOC.InjectForm<frmInteligente>().GetSelecionado("TiposQuartosHospitalar", "Tipos de Quartos Hospitalar");
            if (Equals(TipoQuarto, null))
            {
                return;
            }
            else
            {
                codTipoQuarto = TipoQuarto.Codigo;
                txtipoQuarto.Text = TipoQuarto.Descricao;
            }
        }
        private void btnBusacaTipoCama_Click(object sender, EventArgs e)
        {
            var TipoCamas = IOC.InjectForm<frmInteligente>().GetSelecionado("TiposCamasHospitalar", "Tipo de Camas Hospitalar");
            if (Equals(TipoCamas, null))
            {
                return;
            }
            else
            {
                codTipoCama = TipoCamas.Codigo;
                txtTipoCama.Text = TipoCamas.Descricao;
            }
        }
        private void btnBuscarImposto_Click(object sender, EventArgs e)
        {

            var form = IOC.InjectForm<frmImpostos>();
            form.btnselect.Visibility = BarItemVisibility.Always;
            var imposto = form.GetImposto();

            if (Equals(imposto, null))
            {
                return;
            }
            codImposto = imposto.Codigo;
            txtImposto.Text = imposto.Descricao;

            if (codImposto == 1)
            {
                btnBuscarIsento.Enabled = true;

            }
            else
            {
                btnBuscarIsento.Enabled = false;
                txtMotivoIsencao.Text = "";
                codMotivoIsento = 0;

            }
        }
        private void btnBuscarIsento_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmMotivoIsencao>();
            var motivoIsencao = form.GetMotivoIsencao();
            if (Equals(motivoIsencao, null)) { return; }
            txtMotivoIsencao.Text = motivoIsencao.Descricao;
            codMotivoIsento = motivoIsencao.Codigo;
        }
        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            var tarefa = PopulaObjecto();
            tarefa = _tarifaApp.Gravar(tarefa);
            PopularDadosEditar(tarefa.Codigo);
            txtCodigo.Text = tarefa.Codigo.ToString();
            UtilidadesGenericas.Busca.Alterou = true;
            Close();
        }
        private void frmTarifasHospitalar_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UtilidadesGenericas.Busca.Codigo))
            {
                txtCodigo.Text = UtilidadesGenericas.Busca.Codigo;
                int Codigo = int.Parse(txtCodigo.Text);
                var tarifa = _tarifaApp.GetById(Codigo);
                if (Codigo > 0) PopularDadosEditar(Codigo);
            }
            if (codImposto == 1)
            {
                btnBuscarIsento.Enabled = true;
            }
            else
            {
                btnBuscarIsento.Enabled = false;
            }
        }
        private void cboTarifa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //POR HORA
            if (cboTarifa.SelectedItem == "POR DIA")
            {
                txtTempoHora.Enabled = false;
                txtTempoHora.Text = "0";
            }
            else
            {
                txtTempoHora.Enabled = true;
                txtTempoHora.Text = "1";
            }  
        }
        private void txtValor_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validar.Contains(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}