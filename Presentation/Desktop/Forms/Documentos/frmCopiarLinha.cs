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
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.ViewModels.Frame.Documentos;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.ViewModels.Frame.Sistema;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Documentos
{
    public partial class frmCopiarLinha : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IDocumentosApp _documentosApp;
        private readonly IMovArtigosApp _movArtigosApp;
        private readonly IOperacoesApp _operacoesApp;
        private List<OperacaoViewModel> listaOperacoes;

        private List<MovArtigoViewModel> ArtigosMovArtigo { get; set; }
        private List<DocumentoViewModel> ListDocumentos { get;  set; }
        private DocumentoViewModel DocumentoEncontrado { get;  set; }
        private DocumentosViewModel DocumentoLinhasCopiadas { get; set; } = null;
        private string OperacaoApp { get; set; }
        private int CodEntidade { get; set; }
        private bool LinhasCopiadas { get; set; }

        public frmCopiarLinha(IDocumentosApp AppDocumentos,
                              IMovArtigosApp AppMovArtigos, 
                              IOperacoesApp operacoesApp)
        {
            InitializeComponent();
            _documentosApp = AppDocumentos;
            _movArtigosApp = AppMovArtigos;
            _operacoesApp = operacoesApp;
            DtInicio.EditValue = DateTime.Now;
        }

        private void CarregarMovArtigos()
        {
            if (Equals(DocumentoEncontrado, null) || DocumentoEncontrado.Codigo == 0)
            {
                return;
            }
            ArtigosMovArtigo = _movArtigosApp.ListarMovArtigo(DocumentoEncontrado.Codigo);
            gridControlMovArtigos.DataSource = ArtigosMovArtigo;

        }
        public DocumentosViewModel CopiarLinha(string operacaoApp, int codEntidade)
        {
            CodEntidade = codEntidade;
            OperacaoApp = operacaoApp;
            ShowDialog();
            return DocumentoLinhasCopiadas;
        }
        public bool CopiarLinha(int codDocumento)
        {
            DocumentoLinhasCopiadas = _documentosApp.GetById(codDocumento);
            OperacaoApp = DocumentoLinhasCopiadas.Operacao.APP;
            ShowDialog();
            return LinhasCopiadas;
        }
        private void CarregarCodigos()
        {
            DateTime data = DateTime.Parse(DtInicio.Text);
            string criterio = null;


            //criterio = " Documentos.Data like '" + data.ToString("yyyy-MM-dd") + "'";
            if (!string.IsNullOrEmpty(cboOperacoes.SelectedItem +""))
            {
                criterio += "Operacoes.Nome like '" + cboOperacoes.SelectedItem + "'";
            }


            try
            {
                if (Equals(_documentosApp, null))
                {
                    return;
                }
                ListDocumentos = (List<DocumentoViewModel>)_documentosApp.Listar(criterio);
                cboCodigo.Properties.Items.Clear();
                foreach (var item in ListDocumentos)
                {
                    if (item.Estado == "ABERTO" || item.Estado == "PENDENTE")
                    {
                        continue;
                    }
                    cboCodigo.Properties.Items.Add(item.Numero);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Houve um Erro apartir da Classe " + ex.Message);

            }
        }
        private void CarregarDocumento()
        {
            DateTime data = DateTime.Parse(DtInicio.Text);
            string criterio = null;

            //criterio = "Documentos.Data LIKE '" + data.ToString("yyyy-MM-dd") + "'";

            if (cboOperacoes.SelectedIndex >= 0)
            {
                criterio += "Operacoes.Nome like '" + cboOperacoes.SelectedItem + "'";
            }
            if (!string.IsNullOrEmpty(txtCodCliente.Text))
            {
                criterio += " and Documentos.CodEntidade='" + txtCodCliente.Text + "'";
            }
            if (cboCodigo.SelectedIndex >= 0)
            {
                criterio += " and Documentos.NumeroOrdem='" + cboCodigo.SelectedItem + "'";
            }
            try
            {
                if (Equals(_documentosApp, null))
                {
                    return;
                }
                DocumentoEncontrado = ((List<DocumentoViewModel>)_documentosApp.Listar(criterio)).FirstOrDefault();
                ApresentarDocumento();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Houve um Erro apartir da Classe " + ex.Message);

            }
        }

        private void ApresentarDocumento()
        {
            CarregarMovArtigos();
        }

        private void CarregarOperacoes()
        {
            if (listaOperacoes != null) listaOperacoes.Clear();
            listaOperacoes = _operacoesApp.Listar(null);
            listaOperacoes = listaOperacoes.OrderBy(o => o.Nome).ToList();
            cboOperacoes.Properties.Items.Clear();
            foreach (var operacao in listaOperacoes)
            {
                cboOperacoes.Properties.Items.Add(operacao.Nome);
            }
            cboOperacoes.SelectedItem = "FACTURA RECIBO";
        }
        private void frmCopiarLinha_Load(object sender, EventArgs e)
        {
            CarregarOperacoes();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            
        }

        private void cboOperacoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarCodigos();
        }

        private void cboCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDocumento();
        }

        private void btnActualizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            CarregarDocumento();
        }

        private void btnCloser_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SeRequisitosValidos())
            {
                var indexs = gridMovArtigos.GetSelectedRows();
                if (Equals(DocumentoLinhasCopiadas, null))
                {
                    DocumentoLinhasCopiadas = _documentosApp.CriarNovoDocumento(OperacaoApp, GetTotalLinhasCopiadas(), CodEntidade);
                }
                var movArtigos = _movArtigosApp.GetAllByIdDocumento(DocumentoLinhasCopiadas.codigo);
                foreach (var index in indexs)
                {
                    var codArtigo = ArtigosMovArtigo[index].CODIGO;
                    var artigo = _movArtigosApp.GetById(codArtigo);
                    var artigoDoc = movArtigos.Where(m => m.CodStock == artigo.CodStock || m.Descricao == artigo.Descricao).FirstOrDefault();
                    artigo.CodDocumento = DocumentoLinhasCopiadas.codigo;

                    artigo.codigo = 0;
                    if (!Equals(artigoDoc, null))
                    {
                        artigoDoc.Qtdade += artigo.Qtdade;
                        _movArtigosApp.Update(artigoDoc);
                    }
                    else
                    {
                        _movArtigosApp.Insert(artigo);
                    }
                }
                var docEnc = _documentosApp.GetById(DocumentoEncontrado.Codigo);
                var doc = _documentosApp.GetById(DocumentoLinhasCopiadas.codigo);
                LinhasCopiadas = true;
                //doc.Geracao = "Gerado apartir do documento " + DocumentoEncontrado.APP + " " + DateTime.Now.Year + "/" + docEnc.codigo;
                _documentosApp.Update(doc);

                Close();
            }
        }

        private bool SeRequisitosValidos()
        {
            if (gridMovArtigos.RowCount <= 0)
            {
                UtilidadesGenericas.MsgShow("AVISO","Não existem linha para serem copiadas!", MessageBoxIcon.Warning, MessageBoxButtons.OK);
                return false;
            }

            if (gridMovArtigos.GetSelectedRows().Length <= 0)
            {
                UtilidadesGenericas.MsgShow("AVISO", "Não tem linha selecionas para serem copiadas!", MessageBoxIcon.Warning, MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private decimal GetTotalLinhasCopiadas()
        {
            var totalLinhasCopiadas = 0.00m;
            var indexs = gridMovArtigos.GetSelectedRows();
            foreach (var item in indexs)
            {
                totalLinhasCopiadas += ArtigosMovArtigo[item].TOTAL;
            }
            return totalLinhasCopiadas;
        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnGravar_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void txtCliente_Click(object sender, EventArgs e)
        {
            var cliente = IOC.InjectForm<frmEntidadeBusca>().GetEntidadeSelecionada();
            txtCliente.Text = cliente.Nome;
            txtCodCliente.Text = cliente.Codigo.ToString();
            //CarregarDocumentos();
        }
    }
}