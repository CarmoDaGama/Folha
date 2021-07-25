using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.Enuns.Genericos;
using DevExpress.XtraBars.Ribbon;
using Folha.Domain.Interfaces.Application.Entidades;

namespace Folha.Presentation.Desktop.Forms.Documentos
{
    public partial class frmGerarRecibo : RibbonForm
    {
        private readonly IDocumentosApp _documentosApp;
        private readonly IEntidadesApp _entidadeApp;

        private EntidadesViewModel DadosCliente { get; set; } = null;
        private bool Salvo { get; set; }
        private DocumentosViewModel Documento { get; set; }
        private string OperacaoApp { get; set; } = "RG";

        private CRUD Operacao = CRUD.Cadastro;

        public frmGerarRecibo(
            IDocumentosApp documentosApp,
            IEntidadesApp entidadeApp
        )
        {
            InitializeComponent();

            _documentosApp = documentosApp;
            _entidadeApp = entidadeApp;
        }

        public DocumentosViewModel GetFormaPagamento(int codCliente, decimal total)
        {
            Operacao = CRUD.Listar;
            txtValor.Text = total.ToString("N3");
            //txtValor.Enabled = false;
            //btnEntidade.Enabled = false;
            cboForma.Visible = false;
            DadosCliente = _entidadeApp.GetById(codCliente);
            txtCodCliente.Text = DadosCliente.Codigo.ToString();
            txtCliente.Text = DadosCliente.Nome;
            Text = "NOTA DE CREDITO";
            ShowDialog();
            if (Salvo)
            {
                return Documento;
            }
            else
            {
                return null;
            }
        }
        public DocumentosViewModel GetNovoDocumentoRecibo()
        {
            cboForma.Visible = false;
            Text = "NOVO RECIBO";
            OperacaoApp = "RG";
            ShowDialog();
            if (Salvo)
            {
                return Documento;
            }
            else
            {
                return null;
            }
        }
        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TemRequisitos())
            {
                if (Operacao == CRUD.Cadastro)
                {
                    Documento = _documentosApp.CriarNovoDocumento(
                        OperacaoApp, 
                        Convert.ToDecimal(txtValor.Text), 
                        DadosCliente.Codigo
                    );
                    UtilidadesGenericas.Alterou = true;                
                }
                Salvo = true;
                Close();
             }
            
        }

        private bool TemRequisitos()
        {
            if (string.IsNullOrEmpty(txtValor.Text) || Convert.ToDecimal(txtValor.Text) <= 0)
            {
                UtilidadesGenericas.MsgShow("Insira o Valor Do Credito!", MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtCodCliente.Text))
            {
                UtilidadesGenericas.MsgShow("Selecione o cliente!", MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnEntidade_Click(object sender, EventArgs e)
        {
            DadosCliente = IOC.InjectForm<frmEntidadeBusca>().GetEntidadeSelecionada();
            if (!Equals(DadosCliente, null) && DadosCliente.Codigo > 0)
            {
                txtCliente.Text = DadosCliente.Nome;
                txtCodCliente.Text = DadosCliente.Codigo.ToString();
            }
        }

        private void frmGerarRecibo_Load(object sender, EventArgs e)
        {
        }
    }
}