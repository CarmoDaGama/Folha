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
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.ViewModels.Frame.Documentos;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Documentos;

namespace Folha.Presentation.Desktop.Forms.Documentos
{
    public partial class frmDocumentosDisponiveis : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IOperacoesApp _operacaoApp;
        private readonly IDocumentosApp _documentoApp;
        private bool Selecionado { get;  set; }
        private List<DocumentoViewModel> DocumentosDisponiveis { get;  set; }
        private int IndexDocumento { get;  set; }
        private string NomeOperacao { get; set; }

        public frmDocumentosDisponiveis(IOperacoesApp operacaoApp, IDocumentosApp documentoApp)
        {
            InitializeComponent();
            _operacaoApp = operacaoApp;
            _documentoApp = documentoApp;
        }
        public DocumentosViewModel BuscarUmaDocumentoDiponivel(List<DocumentoViewModel> documentosDisponiveis, string nomeOperacao)
        {
            DocumentosDisponiveis = documentosDisponiveis;
            NomeOperacao = nomeOperacao;
            ShowDialog();
            if (UtilidadesGenericas.ListaNula(DocumentosDisponiveis) || IndexDocumento < 0 || !Selecionado)
            {
                return null;
            }
            return _documentoApp.GetById(DocumentosDisponiveis[IndexDocumento].Codigo);
        }
        private void carregasDocumentos()
        {
            DocumentosDisponiveis = DocumentosDisponiveis.Where(d => d.Documento == NomeOperacao && (d.Estado == "ABERTO" || d.Estado == "PENDENTE")).ToList();
            gradeDocumentos.DataSource = DocumentosDisponiveis;
        }
        private void btnSelecionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Selecionado = true;
            Close();
        }
        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void gridDocumentos_DoubleClick(object sender, EventArgs e)
        {
            Selecionado = true;
            Close();
        }

        private void gridDocumentos_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            IndexDocumento = e.RowHandle;
        }

        private void gridDocumentos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            IndexDocumento = e.RowHandle;
        }

        private void frmDocumentosDisponiveis_Load(object sender, EventArgs e)
        {
            carregasDocumentos();
        }
    }
}