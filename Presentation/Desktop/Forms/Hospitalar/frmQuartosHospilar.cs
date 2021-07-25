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
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Principal;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmQuartosHospilar : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IQuartosHospitalarApp _quartoApp;

        private QuartosHospitalar Quarto;
        private QuartosHospitalarViewModel Entity { get; set; }
        private List<CamasQuartosHospitalarViewModel> listaCamas;

        private int codCamas;
        private int codDelete;
        private int indexCamas;
        private int codAreasHospitalar;
        private int codTipoQuarto;

        public int camasId { get; private set; }


        private bool Changed { get; set; } = false;
        public int CamaId { get; private set; }
        public frmQuartosHospilar(IQuartosHospitalarApp quartoApp)
        {
            InitializeComponent();
            navigationFrame1.SelectedPage = navigationDadosGeral;
            _quartoApp = quartoApp;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDadosGerais_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationDadosGeral;

        }

        private void btnCamas_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPageCama;
            
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
                messageShow("Digite o Nome do Quarto");
                return false;
            }
            if (txtArea.Text.Equals(string.Empty))
            {
                messageShow("Escolha Uma Area");
                return false;
            }
            if (txtTipoQuarto.Text.Equals(string.Empty))
            {
                messageShow("Escolha o Tipo de Quarto");
                return false;
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Descricao", txtDescricao.Text);

            if (txtCodigo.Text == "" && _quartoApp.VerificarDup("QuartosHospitalar", d))
            {
                messageShow("Já Existe esse Quarto Verifica nos Registros ");
                return false;
            }
            
            return valid;
        }
        private bool ContemNaListas(int id)
        {
            return listaCamas.Where(a => a.CodCamasHospitalar == id).FirstOrDefault() != null;
        }
        #endregion

        #region Metodos de Inserir
        private QuartosHospitalar PopulaObjecto()
        {
            Quarto = new QuartosHospitalar()
            {
                Descricao = txtDescricao.Text,
                CodAreasHospitalar = codAreasHospitalar,
                CodTiposQuartosHospitalar = codTipoQuarto,
                Manutencao = "LIMPO",
                CamasdoQuarto = new List<CamasQuartosHospitalarViewModel>()
            };

            if (!string.IsNullOrEmpty(txtCodigo.Text)) Quarto.Codigo = int.Parse(txtCodigo.Text);
            Quarto.CamasdoQuarto = listaCamas;
            return Quarto;

        }
        private void PopularDadosEditar(int Codigo)
        {
            if (Codigo == 0) return;
            camasId = Codigo;
            Entity = _quartoApp.GetById(Codigo);
            txtDescricao.Text = Entity.Descricao;
            txtArea.Text = Entity.AreasHospitalar.Descricao;
            txtTipoQuarto.Text = Entity.TiposQuartosHospitalar.Descricao;
            codAreasHospitalar = Entity.CodAreasHospitalar;
            codTipoQuarto = Entity.CodTiposQuartosHospitalar; 
            gradeCamas.DataSource = listaCamas = _quartoApp.GetCamas(Codigo);
        }
        #endregion
        private void btnInserir_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmCamasHospitaleres>();
            form.btnselect.Visibility = BarItemVisibility.Always;   
            var CamasHospitalar = form.GetCamas();
            
            if (string.IsNullOrEmpty(CamasHospitalar.Codigo.ToString()))
            {
                return;
            }
            codCamas = CamasHospitalar.Codigo;

            Dictionary<string, object> V = new Dictionary<string, object>();
            V.Add("CodCamasHospitalar", codCamas);

            if (_quartoApp.VerificarDup("CamasQuartosHospitalar", V))
            {
                messageShow("A Cama já encontra-se em um quarto");
                return ;
            }

            if (Equals(listaCamas, null))
            {
                listaCamas = new List<CamasQuartosHospitalarViewModel>();
            }
            var newCamas = (new CamasQuartosHospitalarViewModel()
            {
                CodCamasHospitalar = CamasHospitalar.Codigo,
                Descricao = CamasHospitalar.Descricao,
                CamasHospitalar = CamasHospitalar
                
            });
            if (listaCamas.Count > 0 && ContemNaListas(newCamas.CodCamasHospitalar))
            {
                MessageBox.Show("Já está Adicionado", "Erro ao Adicionar ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listaCamas.Add(newCamas);
            gradeCamas.DataSource = null;
            gradeCamas.DataSource = listaCamas;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (codDelete > 0)
            {
                _quartoApp.DeleteCama(new CamasQuartosHospitalarViewModel()
                {
                    Codigo = codDelete,
                });
                gradeCamas.DataSource = null;
                gradeCamas.DataSource = listaCamas;
                gradeCamas.DataSource = listaCamas = _quartoApp.GetCamas(camasId);
                

                MessageBox.Show("Registro Excluído ! ", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                listaCamas.RemoveAt(indexCamas);
                gradeCamas.DataSource = null;
                gradeCamas.DataSource = listaCamas;
            }
        }
        private void btnBuscaArea_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmInteligente>();
            var AreasHospitalar = form.GetSelecionado<AreaSaudeViewModel>("AreasHospitalar", "Área De Saude");
          
            if (Equals(AreasHospitalar, null))
            {
                return;
            }
            else
            {
                codAreasHospitalar = AreasHospitalar.Codigo;
                txtArea.Text = AreasHospitalar.Descricao;
            }
        }
        private void btnBuscaTipoQuarto_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmInteligente>();
            var TipoQuarto = form.GetSelecionado<TiposQuartosHospitalarViewModel>("TiposQuartosHospitalar", "Tipos Quartos Hospitalar");

            if (Equals(TipoQuarto, null))
            {
                return;
            }
            else
            {
                codTipoQuarto = TipoQuarto.Codigo;
                txtTipoQuarto.Text = TipoQuarto.Descricao;
            }
        }
        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (!isFieldsValid()) return;
            var quarto = PopulaObjecto();
            quarto = _quartoApp.Gravar(quarto);
            PopularDadosEditar(quarto.Codigo);
            txtCodigo.Text = quarto.Codigo.ToString();
            UtilidadesGenericas.Busca.Alterou = true;
        }
        private void frmQuartosHospilar_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UtilidadesGenericas.Busca.Codigo))
            {
                txtCodigo.Text = UtilidadesGenericas.Busca.Codigo;
                int Codigo = int.Parse(txtCodigo.Text);
                var quarto = _quartoApp.GetById(Codigo);
                if (Codigo > 0) PopularDadosEditar(Codigo);
            }
        }
        private void gridCamas_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            codDelete = listaCamas[e.RowHandle].Codigo;
            indexCamas = e.RowHandle;
        }
        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            var quarto = PopulaObjecto();
            quarto = _quartoApp.Gravar(quarto);
            PopularDadosEditar(quarto.Codigo);
            txtCodigo.Text = quarto.Codigo.ToString();
            UtilidadesGenericas.Busca.Alterou = true;
            Close();
            UtilidadesGenericas.Busca.Alterou = true;

        }
        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}