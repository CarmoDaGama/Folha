using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Documentos;
using Folha.Presentation.Desktop.Forms.Sistema;
using Folha.Domain.Models.Entidades;
using Folha.Domain.ViewModels.Sistema;
using Folha.Domain.Interfaces.Application.Sistema;
using DevExpress.XtraGrid.Views.Grid;
using Folha.Domain.Interfaces.Application.Documentos;
using System.Linq;
using Folha.Domain.Interfaces.Application.Inteligente;

namespace Folha.Presentation.Desktop.Forms.Financeiro
{
    public partial class frmReceberPagamentos : DevExpress.XtraEditors.XtraForm
    {
        private readonly IPagamentosApp _pagamentoApp;
        private readonly IFPagamentosApp _formaApp;
        private readonly ITurnosApp _turnosApp;
        private readonly IDocumentosApp _docApp;
        private readonly IInteligenteApp _inteligenteApp;

        private List<fPagamentosViewModel> FormasPagamentos { get;  set; }
        private List<FormaViewModel> Formas { get;  set; }
        private bool PagamentoEfectuado { get; set; }
        public int FormaId { get; private set; }
        public int IndexForm { get; set; } = -1;
        public TurnosViewModel Turno { get; set; }
        private DocumentosViewModel DocumentoPagar { get;  set; }
        private decimal DescontoDocumento { get; set; }
        private int CodDocumentoRG { get;  set; }
        private DadosPagarViewModel[] CodDocumentos { get; set; }
        private int CodCilente { get; set; }

        public frmReceberPagamentos(
            IPagamentosApp pagamentoApp, 
            IFPagamentosApp formaApp, 
            ITurnosApp turnosApp, 
            IDocumentosApp docApp,
            IInteligenteApp inteligenteApp)
        { 
            InitializeComponent();
            _pagamentoApp = pagamentoApp;
            _formaApp = formaApp;
            _turnosApp = turnosApp;
            _docApp = docApp;
            _inteligenteApp = inteligenteApp;
            Turno = _turnosApp.GetById(UtilidadesGenericas.CodigoTurno);
        }

        private void carregarFormasPagamentos()
        {
            FormasPagamentos = _formaApp.GetAll(); 
            Formas = Mapper<fPagamentosViewModel, FormaViewModel>.Map(FormasPagamentos);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        public bool ReceberPagmentoDocumento(int codDocumento, decimal desconto)
        {
            return ReceberPagmentoDocumento(_docApp.GetById(codDocumento), desconto);
        }
        public int ReceberPagmentoDocumento(DadosPagarViewModel[] codDocumentos, decimal desconto, int codCilente)
        {
            PagamentoEfectuado = false;
            CodDocumentos = codDocumentos;
            CodCilente = codCilente;
            DescontoDocumento = desconto;
            CriarDocumentoRG();
            addValoresNosControlers();
            ShowDialog();
            return CodDocumentoRG;
        }
        public bool ReceberPagmentoDocumento(DocumentosViewModel documento, decimal desconto)
        {

            PagamentoEfectuado = false;
            DocumentoPagar = documento;
            DescontoDocumento = desconto;
            addValoresNosControlers();
            ShowDialog();
            return PagamentoEfectuado;
        }
        private void addValoresNosControlers()
        {
            txtCodEntidade.Text = DocumentoPagar.Entidade.Codigo.ToString();
            txtEntidade.Text = DocumentoPagar.NomeCliente.ToUpper();
            txtTotal.Text = getValorTotal().ToString("N3");
            if (DocumentoPagar.Operacao.APP == "RG")
            {
                txtDesc.Text = "PAGAMENTO DE FACTURA Nº " + DocumentoPagar.codigo;
            }
            else
            {
                txtDesc.Text = "PAGAMENTO DE " + DocumentoPagar.Operacao.Nome + " Nº " + DocumentoPagar.codigo;
            }
        }

        private decimal getValorTotal()
        {
            var total = DocumentoPagar.Total;
            if (!string.IsNullOrEmpty(txtTotal.Text) && txtTotal.Text != "0,000")
            {
                total = Convert.ToDecimal(txtTotal.Text);
            }
            return total;
        }

        private void frmReceberPagamentos_Load(object sender, EventArgs e)
        {
            carregarFormasPagamentos();
            gridPagamentos.DataSource = Formas;
            
            if (!Equals(DocumentoPagar, null))
            {
                txtDesconto.Text = getTotalDesconto() + "%";
                UtilidadesGenericas.Moeda = cboMoedas.SelectedItem.ToString();
            }
            else { 
                Close();
            }

        }

        private void CriarDocumentoRG()
        {
            if (!Equals(CodDocumentos, null))
            {
                var total = 0.0m;
                foreach (var item in CodDocumentos)
                {
                    total += item.TotalDocumento;
                }
                DocumentoPagar = _docApp.CriarNovoDocumento("RG", total, CodCilente);
                if (!Equals(DocumentoPagar, null))
                {
                    CodDocumentoRG = DocumentoPagar.codigo;
                }
            }
        }

        private decimal getTotalDesconto()
        {
            if (!Equals(DocumentoPagar, null))
            {
                return DescontoDocumento;
            }
            return 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridViewPagamentos_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            IndexForm = e.RowHandle;
            var forma = GetFormaSelecionada();
            var valor = Convert.ToDecimal(txtTotal.Text);
            if (forma.Valor > 0)
            {
                valor = forma.Valor;
            }
            var objValorPagamento = new frmValorNumerico().GetValor(valor, "Valor Do Pagamento");
            if (Equals(objValorPagamento, null))
            {
                return;
            }
            valor = (decimal)objValorPagamento;
            if (valor > 0)
            {
                SelecionarForma(valor);
            }
        }

        private FormaViewModel GetFormaSelecionada()
        {
            var codForma = Convert.ToInt16(gridViewPagamentos.GetRowCellValue(IndexForm, "codigo"));
            var forma = Formas.Where(f => f.codigo == codForma).FirstOrDefault();
            return forma;
        }

        private void SelecionarForma(decimal valor)
        {
            var actualTotal = getValorTotal();
            if (IndexForm <= -1)
            {
                return;
            }
            var forma = GetFormaSelecionada();
            forma.Valor = valor;
            FormaId = forma.codigo;
            gridPagamentos.DataSource = UtilidadesGenericas.newInstanceThisList(Formas);
            txtValorEntrego.Text = getValorTotalForma().ToString("N3");
            forma.Troco = (getValorTotalForma() - getValorTotal());
            txtTroco.Text = forma.Troco.ToString("N3");
            btnConcluir.Enabled = true;
            txtTotal.Text = getValorTotal().ToString("N3");
        }

        private decimal getValorTotalForma()
        {
            var totalForma = 0.0m;

            foreach (var item in Formas)
            {
                totalForma += item.Valor;
            }
            return totalForma;
        }

        private void zerarOutrasFormas()
        {
            var forma = GetFormaSelecionada();
            foreach (var item in Formas)
            {
                if (item.codigo != forma.codigo)
                {
                    item.Valor = 0.0m;
                }
            }
        }

        private void messageShow(string message)
        {
            UtilidadesGenericas.MsgShow(
                "MENSAGEM",
                message, 
                MessageBoxIcon.Information, 
                MessageBoxButtons.OK
            );
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            if (getValorTotalForma() < getValorTotal())
            {
                messageShow("Valor não pode ser menor que o valor do preço total!");
                return;
            }
            if (string.IsNullOrEmpty(txtValorEntrego.Text))
            {
                messageShow("Insira o valor de Entrega!");
            }
            else
            {
                efectuarPagamento();
                efectuarPagamentoAuxs();

                PagamentoEfectuado = true;
                Close();
            }
        }

        private void efectuarPagamento()
        {
            for (int i = 0; i < Formas.Count; i++)
            {
                if (Formas[i].Valor > 0)
                {
                    var codConta = 0;
                    if (FormasPagamentos[i].CodConta == null || FormasPagamentos[i].CodConta == "0")
                    {
                        codConta = 1;
                    }
                    else
                    {
                        codConta = int.Parse(FormasPagamentos[i].CodConta);
                    }
                    var codCaixa = 1;
                    if (!Equals(Turno, null))
                    {
                        codCaixa = Turno.CodCaixa;
                    }
                    var codDocumento = DocumentoPagar.codigo ;
                    var movFin = DocumentoPagar.Operacao.MovFin;
                    var troco = Formas[i].Troco > 0 ? Formas[i].Troco : 0;
                    var numeroPagamentoRecibo = 0;
                    if (DocumentoPagar.Operacao.APP == "FT" || DocumentoPagar.Operacao.APP == "RG")
                    {
                        numeroPagamentoRecibo = numeroPagamentoRecibo + _pagamentoApp.GetUltimoNumeroPagamentoRecibo() + 1;
                    }
                    _pagamentoApp.Insert(new PagamentosViewModel()
                    {
                        CodDocumento = codDocumento,
                        CodCaixa = codCaixa,
                        CodCambio = 1,
                        CodMoeda = 1,
                        CodConta = codConta,
                        Descricao = txtDesc.Text,
                        Hora = DateTime.Now.ToShortTimeString(),
                        CodTurno = UtilidadesGenericas.CodigoTurno,
                        CodForma = Formas[i].codigo,
                        Data = DateTime.Now,
                        Valor = Formas[i].Valor - troco,
                        Estado = "FECHADO",
                        Tipo = movFin,
                        NumeroOrdem = numeroPagamentoRecibo
                    });
                    if (Formas[i].Troco > 0)
                    {
                        _pagamentoApp.Insert(new PagamentosViewModel()
                        {
                            CodDocumento = codDocumento,
                            CodCaixa = codCaixa,
                            CodCambio = 1,
                            CodMoeda = 1,
                            CodConta = codConta,
                            Descricao = txtDesc.Text,
                            Hora = DateTime.Now.ToShortTimeString(),
                            CodTurno = UtilidadesGenericas.CodigoTurno,
                            CodForma = Formas[i].codigo,
                            Data = DateTime.Now,
                            Valor = Formas[i].Troco,
                            Estado = "FECHADO",
                            Tipo = "DEBITO",
                            NumeroOrdem = numeroPagamentoRecibo
                        });
                    }
                    
                }
                
            }
        }
        private void efectuarPagamentoAuxs()
        {
            if (!Equals(CodDocumentos, null))
            {
                for (int i = 0; i < CodDocumentos.Length; i++)
                {
                    var doc = _docApp.GetById(CodDocumentos[i].CodCocumento);
                    var forma = Formas.Where(f => f.Valor > 0).FirstOrDefault();
                    if (forma.Valor > 0)
                    {
                        var codConta = 0;
                        var fp = FormasPagamentos.Where(f => f.codigo == forma.codigo).FirstOrDefault();
                        if (fp.CodConta == null || fp.CodConta == "0")
                        {
                            codConta = 1;
                        }
                        else
                        {
                            codConta = int.Parse(fp.CodConta);
                        }
                        var codCaixa = 1;
                        if (!Equals(Turno, null))
                        {
                            codCaixa = Turno.CodCaixa;
                        }
                        var codDocumento = doc.codigo;
                        var movFin = doc.Operacao.MovFin;
                        var troco = forma.Troco > 0 ? forma.Troco : 0;
                        var numeroPagamentoRecibo = 0;
                        if (doc.Operacao.APP == "FT" || doc.Operacao.APP == "RG")
                        {
                            numeroPagamentoRecibo = numeroPagamentoRecibo + _pagamentoApp.GetUltimoNumeroPagamentoRecibo() + 1;
                        }
                        
                        _pagamentoApp.Insert(new PagamentosViewModel()
                        {
                            CodDocumento = codDocumento,
                            CodCaixa = codCaixa,
                            CodCambio = 1,
                            CodMoeda = 1,
                            CodConta = codConta,
                            Descricao = txtDesc.Text,
                            Hora = DateTime.Now.ToShortTimeString(),
                            CodTurno = UtilidadesGenericas.CodigoTurno,
                            CodForma = forma.codigo,
                            Data = DateTime.Now,
                            Valor = doc.Total,
                            Estado = "FECHADO",
                            Tipo = movFin,
                            NumeroOrdem = numeroPagamentoRecibo
                        });
                        //Liquidação da Factura 2020/4 -REF 3, Pagamento.
                        _inteligenteApp.InsertDoc(new DocumentoPagamentoViewModel()
                        {
                            DescricaoDocumento = "Liquidação da Factura " +
                            DateTime.Now.Year + "/" + doc.NumeroOrdem + "-REF " + numeroPagamentoRecibo +
                            "Pagamento.",
                            CodRecibo = DocumentoPagar.codigo,
                            DataOperacao = doc.Data,
                            Valor = doc.Total
                        });

                    }

                    }
                    DocumentoPagar.Estado = "FECHADO";
                    _docApp.Update(DocumentoPagar);
            }
        }

        private void cboMoedas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var valorEntrega = 0.0m;
            var valorTroco = 0.0m;
            var total = DocumentoPagar.Total;
            if (!string.IsNullOrEmpty(txtValorEntrego.Text))
            {
                valorEntrega = Convert.ToDecimal(txtValorEntrego.Text);
            }
            if (!string.IsNullOrEmpty(txtTroco.Text))
            {
                valorTroco = Convert.ToDecimal(txtTroco.Text);
            }
            if (!string.IsNullOrEmpty(txtTotal.Text))
            {
                total = Convert.ToDecimal(txtTotal.Text);
            }
            if (IndexForm > -1)
            {
                if (UtilidadesGenericas.Moeda == "USD" && Equals(cboMoedas.SelectedItem, "AKZ"))
                {
                    UtilidadesGenericas.Moeda = cboMoedas.SelectedItem.ToString();
                    txtValorEntrego.Text = ConverterParaKwanza(Convert.ToDecimal(txtValorEntrego.Text)).ToString("N3");
                    txtTotal.Text = ConverterParaKwanza(total).ToString("N3");
                    txtTroco.Text = ConverterParaKwanza(Convert.ToDecimal(txtTroco.Text)).ToString("N3");
                }
                else if (UtilidadesGenericas.Moeda == "AKZ" && Equals(cboMoedas.SelectedItem, "USD"))
                {
                    UtilidadesGenericas.Moeda = cboMoedas.SelectedItem.ToString();
                    txtValorEntrego.Text = ConverterParaDolar(valorEntrega).ToString("N3");
                    txtTotal.Text = ConverterParaDolar(total).ToString("N3");
                    txtTroco.Text = ConverterParaDolar(valorTroco).ToString("N3");
                }
                //SelecionarForma(valorEntrega);
                setFormas();
            }
            else
            {
                UtilidadesGenericas.Moeda = cboMoedas.SelectedItem.ToString();
                if (UtilidadesGenericas.Moeda == "AKZ")
                {
                    if (!string.IsNullOrEmpty(txtTotal.Text))
                    {
                        total = Convert.ToDecimal(txtTotal.Text);
                    }
                    txtTotal.Text = ConverterParaKwanza(total).ToString("N3");
                }
                else if (UtilidadesGenericas.Moeda == "USD")
                {
                    if (!string.IsNullOrEmpty(txtTotal.Text))
                    {
                        total = Convert.ToDecimal(txtTotal.Text);
                    }
                    txtTotal.Text = ConverterParaDolar(total).ToString("N3");
                }
            }
        }

        private void setFormas()
        {
            foreach (var item in Formas)
            {
                if (UtilidadesGenericas.Moeda == "AKZ")
                {
                    item.Valor = ConverterParaKwanza(item.Valor);
                    item.Troco = ConverterParaKwanza(item.Troco);
                }
                else if (UtilidadesGenericas.Moeda == "USD")
                {
                    item.Valor = ConverterParaDolar(item.Valor);
                    item.Troco = ConverterParaDolar(item.Troco);
                }
            }
            gridPagamentos.DataSource = UtilidadesGenericas.newInstanceThisList(Formas);
        }

        public decimal ConverterParaKwanza(decimal valorDolar)
        {
            return valorDolar * UtilidadesGenericas.UmDolarEmKWZ;
        }
        public decimal ConverterParaDolar(decimal valorKz)
        {
            return valorKz / UtilidadesGenericas.UmDolarEmKWZ;
        }
        private void btnEntidade_Click(object sender, EventArgs e)
        {
            
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmReceberPagamentos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Equals(CodDocumentos, null) && !PagamentoEfectuado)
            {
                _docApp.Delete(DocumentoPagar);
            }
        }

        private void txtEntidade_Click(object sender, EventArgs e)
        {

        }
    }
}