using DevExpress.XtraBars;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.Enuns.Genericos;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Principal;
using System;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Separadores.Entidades
{
    public partial class frmDocumentos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DocumentosEntidadeViewModel Documento { get; set; }
        public frmDocumentos()
        {
            InitializeComponent();
            txtNumero.Enabled = true;
            Documento = new DocumentosEntidadeViewModel()
            {
                Numero = "00000",
                Tipo = new TiposDocumentosViewModel() { descricao = "Nenhum" }
            };
            ValidacaoControles.InserirEnventosDeValidacao(txtNumero, TipoValidacao.Palavras);

            dateEmissao.Text = DateTime.Now.ToShortDateString();
            dateValidade.Text = DateTime.Now.ToShortDateString();
            dateEmissao.Properties.MaxValue = DateTime.Now;
            dateValidade.Properties.MaxValue = new DateTime(DateTime.Now.Year + 45, DateTime.Now.Month, DateTime.Now.Day);
        }
        private void FormDocumentos_Load(object sender, EventArgs e)
        {
            

        }

        private void btnTipo_Click(object sender, EventArgs e)
        {
            
        }
        public DocumentosEntidadeViewModel EditarDocumneto(DocumentosEntidadeViewModel oldDocumento)
        {
            Documento = null;
            Documento = oldDocumento;
            popularCampos();
            ShowDialog();
            return Documento;
        }

        private void popularCampos()
        {
            txtNumero.Text = Documento.Numero;
            dateEmissao.EditValue = Documento.Emissao;
            dateValidade.EditValue = Documento.Validade;
            txtTipo.Text = Documento.Tipo.descricao;
            textEditCodigo.Text = Documento.CodTipoDocumento.ToString();
        }

        public DocumentosEntidadeViewModel GetDocumento()
        {
            ShowDialog();
            return Documento;
        }
        private void buttonSaveClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ValidarField()) return;
            Documento.Tipo.descricao = txtTipo.Text;
            Documento.Numero = txtNumero.Text;
            Documento.Emissao = (Convert.ToDateTime(dateEmissao.EditValue)).ToShortDateString();
            Documento.Validade = (Convert.ToDateTime(dateValidade.EditValue)).ToShortDateString();
            Close();

        }
        private bool ValidarField()
        {
            bool validado = true;
            if (txtTipo.Text.Equals(string.Empty))
            {
                messageShow("Preencha o campo Caterização");
                return false;
            }
            if (txtNumero.Text.Equals(string.Empty))
            {
                messageShow("Preencha o campo Número");
                return false;
            }
            //if (dateEmissao.Text.Equals(string.Empty))
            //{
            //    messageShow("Preencha a Data de Emissão");
            //    return false;
            //}
            //if (dateValidade.Text.Equals(string.Empty))
            //{
            //    messageShow("Preencha a Data Validade");
            //    return false;
            //}
            //int intervalosDias = UtilidadesGenericas.GetIntervaloDeDia(Convert.ToDateTime(dateEmissao.Text), Convert.ToDateTime(dateValidade.Text));
            //if (intervalosDias < 1)
            //{
            //    messageShow("O intervalo das datas são invalido!");
            //    return false;
            //}
            
            //foreach (Control item in panelFields.Controls)
            //{
            //    if ((item.Name.Contains("txt") && item.Text == string.Empty) 
            //        ||(item.Name.Contains("date") && Equals(item, null))
            //    )
            //    {
            //        messageShow("Preencha o campo " + item.Name.Replace("txt", "").Replace("date", ""));
            //        validado = false;
            //        break;
            //    }
            //}
            return validado;
        }
        private void messageShow(string message)
        {
            MessageBox.Show(
                message,
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void panelFields_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTipo_Click(object sender, EventArgs e)
        {
            var formTipo = IOC.InjectForm<frmInteligente>();
            Documento.Tipo = formTipo.GetSelecionado<TiposDocumentosViewModel>("TiposDocumentos");

            if (!Equals(Documento.Tipo, null))
            {
                Documento.CodTipoDocumento = Documento.Tipo.codigo;
                txtTipo.Text = Documento.Tipo.descricao;
                textEditCodigo.Text = Documento.CodTipoDocumento.ToString();
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtNumero.Text = "";
            txtTipo.Text = "";
            textEditCodigo.Text = "";
        }
    }
}