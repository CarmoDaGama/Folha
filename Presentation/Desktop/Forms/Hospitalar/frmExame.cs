using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Genericos;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Genericos;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Enuns.Genericos;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Armazens;
using Folha.Presentation.Desktop.Forms.Geral;
using Folha.Presentation.Desktop.Forms.Principal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmExame : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IExamesHospitalarApp _ExamesHospitalarApp;
        private int codImposto;
        private int codMotivoInsencao;
        private readonly ISubCategoriaApp _SubCategoriaApp;
        List<SubCategoriaViewModel> LtSubCategoria = new List<SubCategoriaViewModel>();
        ExamesViewModel DadosExame = new ExamesViewModel();
        private int codSubCategoria;
        private bool Editar;

        private ImpostoViewModel ThisImposto { get;  set; }

        public frmExame(IExamesHospitalarApp ExamesHospitalarApp, ISubCategoriaApp SubCategoriaApp)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            _ExamesHospitalarApp = ExamesHospitalarApp;
            _SubCategoriaApp = SubCategoriaApp;
            ValidacaoControles.InserirEnventosDeValidacao(txtDescricao,  TipoValidacao.Palavras);
        }

        private void GravarExame()
        {
            byte[] logotipo = new byte[1];
            if (PicFoto.Image != null) logotipo = Imagens.Imagem_Byte(PicFoto.Image);

            _ExamesHospitalarApp.Insert(new ExamesHospitalar()
            {
                Descricao = txtDescricao.Text,
                CodImposto = codImposto,
                CodMotivoIsencao = codMotivoInsencao,
                CodSubCategoria = codSubCategoria,
                Custo = Convert.ToDouble(txtCusto.Text),
                Preco = Convert.ToDouble(txtPreco.Text),
                Lucro = Convert.ToDouble(txtLucro.Text),
                Foto = logotipo,
                Status = 1,
            });
        }

        public void EditarExameHospitalar(ExamesViewModel Dados)
        {
            Editar = true;
            DadosExame = Dados;
            CarregaCampos();
            ShowDialog();
            Close();
        }

        private void CarregaCampos()
        {
            txtDescricao.Text = DadosExame.Descricao;
            codImposto = DadosExame.CodImposto;
            txtImposto.Text = DadosExame.Imposto;
            codMotivoInsencao = DadosExame.CodMotivoIsencao;
            txtMotivoIsencao.Text = DadosExame.MotivoIsencao;
            codSubCategoria = DadosExame.CodSubCategoria;
            txtCusto.Text = DadosExame.Custo.ToString("N2");
            txtPreco.Text = DadosExame.Preco.ToString("N2");
            txtLucro.Text = DadosExame.Lucro.ToString("N2");
            var subCategoria = _SubCategoriaApp.GetSubCategoria(DadosExame.CodSubCategoria);
            txtCategoria.Text = subCategoria.Categoria;
            txtSubCategoria.Text = subCategoria.SubCategoria;

            try
            {
                PicFoto.Image = Imagens.Byte_Imagem(DadosExame.Foto);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void UpdateExame()
        {
            byte[] logotipo = new byte[1];
            if (PicFoto.Image != null) logotipo = Imagens.Imagem_Byte(PicFoto.Image);

            _ExamesHospitalarApp.Update(new ExamesHospitalar()
            {
                Codigo =DadosExame.CodExame,
                Descricao = txtDescricao.Text,
                CodImposto = codImposto,
                CodMotivoIsencao = codMotivoInsencao,
                CodSubCategoria = codSubCategoria,
                Custo = Convert.ToDouble(txtCusto.Text),
                Preco = Convert.ToDouble(txtPreco.Text),
                Lucro = Convert.ToDouble(txtLucro.Text),
                Foto = logotipo,
                Status = 1,
            });
        }
        private void UpdateAll()
        {
            UpdateExame();
        }
        private void InsertAll()
        {
            GravarExame();
        }
        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CamposValidos())
            {
                if (Editar) UpdateAll();

                else  InsertAll();

            }
        }

        private bool CamposValidos()
        {
            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                UtilidadesGenericas.MsgShow("Preencha o campo Descrição!", MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtImposto.Text))
            {
                UtilidadesGenericas.MsgShow("Preencha o campo Imposto!", MessageBoxIcon.Error);
                return false;
            }
            if (Equals(txtImposto.Text, "Isento") && string.IsNullOrEmpty(txtMotivoIsencao.Text))
            {
                UtilidadesGenericas.MsgShow("Preencha o campo motivo de isenção!", MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtCusto.Text))
            {
                UtilidadesGenericas.MsgShow("Preencha o campo Custo!", MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtPreco.Text))
            {
                UtilidadesGenericas.MsgShow("Preencha o campo Custo!", MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtLucro.Text))
            {
                UtilidadesGenericas.MsgShow("Preencha o campo Lucro!", MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtCategoria.Text))
            {
                UtilidadesGenericas.MsgShow("Preencha o campo Categorias!", MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtSubCategoria.Text))
            {
                UtilidadesGenericas.MsgShow("Preencha o campo Sub Categorias!", MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnImposto_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmImpostos>();
            form.btnselect.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;       
            ThisImposto = form.GetImposto();
            if (Equals(ThisImposto, null))
            {
                return;
            }
            codImposto = ThisImposto.Codigo;
            txtImposto.Text = ThisImposto.Descricao;
            var preco = 0.0m;
            if (!string.IsNullOrEmpty(txtPreco.Text))
            {
                preco = Convert.ToDecimal(txtPreco.Text);
            }
            txtValorIva.Text =(preco * (ThisImposto.Percentagem/100)).ToString("N2");
            if (codImposto == 1)
            {
                btnMotivoIsencao.Enabled = true;
            }
            else
            {
                btnMotivoIsencao.Enabled = false;
                txtMotivoIsencao.Text = "";
            }
        }
        private void btnMotivo_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmMotivoIsencao>();
            form.btnSelecionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            var motivoIsencao = form.GetMotivoIsencao();
            if (Equals(motivoIsencao, null)) { return; }
            codMotivoInsencao = motivoIsencao.Codigo;
            txtMotivoIsencao.Text = motivoIsencao.Descricao;
        }

        private void btnNovaCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                var formSub = IOC.InjectForm<frmSubcategorias>();
                formSub.btnSelecionar.Enabled = true;
                formSub.ShowDialog();
                if (formSub.DadosSubCategoria.SubCategoria == "Nenhuma") return;
                txtCategoria.Text = formSub.DadosSubCategoria.Categoria;
                txtSubCategoria.Text = formSub.DadosSubCategoria.SubCategoria;
                //LtSubCategoria.Add(formSub.DadosSubCategoria);
                codSubCategoria = formSub.DadosSubCategoria.Codigo;
                //gradeSubCategoria.DataSource = null;
                //gradeSubCategoria.DataSource = LtSubCategoria;
            }
            catch (Exception ex) { UtilidadesGenericas.MsgShow(ex.Message, MessageBoxIcon.Error); }
            

        }

        private void btnDadosGerais_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_DadosGerais;
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Categoria;
        }

        private void btnSalvarFechar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CamposValidos())
            {
                if (Editar) UpdateAll();

                else InsertAll();

                Close();
            }
        }

        private void btnFechar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void txtCusto_TextChanged(object sender, EventArgs e)
        {
            var custo = 0.0m;
            var preco = 0.0m;
            if (!string.IsNullOrEmpty(txtCusto.Text))
            {
                custo = Convert.ToDecimal(txtCusto.Text);
            }
            if (!string.IsNullOrEmpty(txtPreco.Text)) 
            {
                preco = Convert.ToDecimal(txtPreco.Text);
            }
            txtLucro.Text = (preco - custo).ToString("N2");
            if (!Equals(txtImposto.Text, "Isento") && !Equals(ThisImposto, null))
            {
                txtValorIva.Text = (preco * ThisImposto.Percentagem/100).ToString("N2");
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
    
}
