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
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmInternamentoConfiguracoes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IAtendimentoHospitalarApp _AtendiApp;

        public List<TiposQuartosHospitalarViewModel> ListaTipoQuarto { get; private set; }
        public List<QuartosHospitalarViewModel> ListaQuarto { get; private set; }
        public List<TarifaHospitalarViewModel> ListaTafia { get; private set; }
        public List<CamasQuartosHospitalarViewModel> ListaCamas;
        private CamasHospitalarViewModel CamaInternamento { get; set; }
        private PacienteInternadoViewModel Internado;

        private int indexCama;
        private int codInternado;
        private int indexInternado;
        private int indexTipoQuarto;
        private int indexQuarto;
        private int indexTarifa;
        public frmInternamentoConfiguracoes(IAtendimentoHospitalarApp AtendiApp)
        {
            InitializeComponent();
            _AtendiApp = AtendiApp;


            UtilidadesGenericas.Busca.CodQuartoHospitalar = 0;
            UtilidadesGenericas.Busca.CodTarifaHospitalar = 0;
            UtilidadesGenericas.Busca.CodCamaHospitalar = 0;
            UtilidadesGenericas.Busca.ValorTarifa = 0;
        }

        public void CarregarTipoQuarto()
        {
            cboTipoQuarto.Properties.Items.Clear();

            ListaTipoQuarto = (List<TiposQuartosHospitalarViewModel>)_AtendiApp.ListaTipoQuarto(null);
            if (UtilidadesGenericas.ListaNula(ListaTipoQuarto))
            {
                return;
            }
            cboTipoQuarto.SelectedIndex = cboTipoQuarto.Properties.Items.Count + 0;
            foreach (var item in ListaTipoQuarto) cboTipoQuarto.Properties.Items.Add(item.Descricao);
            
        }
        public void CarregarQuarto()
        {
            cboQuarto.Properties.Items.Clear();
            if (ListaTipoQuarto[indexTipoQuarto].Codigo == 0)
            {
                cboQuarto.Properties.Items.Clear();
                cboCama.Properties.Items.Clear();
                return;
            }
            else
            {
                ListaQuarto = (List<QuartosHospitalarViewModel>)_AtendiApp.ListaQuarto(ListaTipoQuarto[indexTipoQuarto].Codigo);
                if (UtilidadesGenericas.ListaNula(ListaQuarto))
                {
                    return;
                }
                cboQuarto.SelectedIndex = cboQuarto.Properties.Items.Count + 0;
                foreach (var item in ListaQuarto) cboQuarto.Properties.Items.Add(item.Descricao);
            }
           
        }
        public void CarregarTarifa()
        {
            cboTarifa.Properties.Items.Clear();
            if (ListaTipoQuarto[indexTipoQuarto].Codigo == 0)
            {
                cboTarifa.Properties.Items.Clear();
                return;
            }
            else
            {
                ListaTafia = (List<TarifaHospitalarViewModel>)_AtendiApp.ListaTarifa(ListaTipoQuarto[indexTipoQuarto].Codigo);
                if (UtilidadesGenericas.ListaNula(ListaTafia))
                {
                    return;
                }
                cboTarifa.SelectedIndex = cboTarifa.Properties.Items.Count + 0;
                foreach (var item in ListaTafia) cboTarifa.Properties.Items.Add(item.Descricao);

                if (ListaTafia.Count < 0)
                {
                    cboTarifa.Properties.Items.Clear();

                }
            }
            
        }
        public void CarregarCama()
        {
            cboCama.Properties.Items.Clear();
            if (UtilidadesGenericas.ListaNula(ListaQuarto) || ListaQuarto[indexQuarto].Codigo == 0)
            {
                return;
            }
            ListaCamas = (List<CamasQuartosHospitalarViewModel>)_AtendiApp.ListaCama(ListaQuarto[indexQuarto].Codigo);
            if (UtilidadesGenericas.ListaNula(ListaCamas))
            {
                return;
            }
            cboCama.SelectedIndex = cboCama.Properties.Items.Count + 0;
            foreach (var item in ListaCamas) cboCama.Properties.Items.Add(item.Descricao);
        }
        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void frmInternamentoConfiguracoes_Load(object sender, EventArgs e)
        {
            CarregarTipoQuarto();
            cboTipoQuarto.SelectedIndex = 0;
            cboQuarto.SelectedIndex = 0;
            cboTarifa.SelectedIndex = 0;
            cboCama.SelectedIndex = 0;
        }

        private void cboTipoQuarto_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexTipoQuarto = cboTipoQuarto.SelectedIndex;
            CarregarQuarto();
            CarregarTarifa();
            CarregarCama();
        }

        private void cboTarifa_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexTarifa = cboTarifa.SelectedIndex;
            if (UtilidadesGenericas.ListaNula(ListaTafia))
            {
                return;
            }
            txtValorTarifa.Text = ListaTafia[indexTarifa].Valor.ToString();
        }

        private void cboQuarto_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexQuarto = cboQuarto.SelectedIndex;
            CarregarCama();
        }

        private void cboCama_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexCama = cboCama.SelectedIndex;
        }

        private void txtHora_TextChanged(object sender, EventArgs e)
        {

        }

        #region Passagem de dados

        public void Popular()
        {
            UtilidadesGenericas.Busca.CodQuartoHospitalar = ListaQuarto[indexQuarto].Codigo;
            UtilidadesGenericas.Busca.CodTarifaHospitalar = ListaTafia[indexTarifa].Codigo;
            UtilidadesGenericas.Busca.CodCamaHospitalar = ListaCamas[indexCama].Codigo;
           UtilidadesGenericas.Busca.QuantidadeHospitalar = txtQuantidade.Value.ToString();
           UtilidadesGenericas.Busca.ValorTarifa = decimal.Parse(txtValorTarifa.Text);
        }
        #endregion 
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
            if (cboTarifa.Text.Equals(string.Empty))
            {
                messageShow("Não foi informado nenhum Quarto");
                return false;
            }
            if (cboTipoQuarto.Text.Equals(string.Empty))
            {
                messageShow("Não foi informado nenhum Tipo de Quarto");
                return false;
            }
            if (cboQuarto.SelectedItem == null)
            {
                messageShow("Não foi informado nenhuma tarifa");
                return false;
            }
            if (cboCama.SelectedItem == null)
            {
                messageShow("Não foi informado nenhum Cama");
                return false;
            }
            
            return valid;
        }
        #endregion

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            Popular();
            Close();
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}