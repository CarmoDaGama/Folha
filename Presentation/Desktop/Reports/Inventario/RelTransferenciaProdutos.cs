using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Inventario;
using Folha.Presentation.Desktop.Reports.Geral;
using Folha.Domain.ViewModels.Documentos;
using System;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Reports.Inventario
{
    public partial class RelTransferenciaProdutos : XtraReport
    {
        public RelTransferenciaProdutos(List<TransferenciaProdutoViewModel> dados)
        {
            InitializeComponent();
            objectDataSource1.DataSource = dados;
            var documento = dados[0].Documento;
            xrSubreport1.ReportSource = new RelCabecalho();
            var codAGT = documento.Operacao.APP + " " + DateTime.Now.Year + "/" + documento.NumeroOrdem;
            lblEmitido.Text = documento.Emitido;
            xrSubreport2.ReportSource = new RelDadosGeraisDocumentos(
                new DadosGeraisDocumentosViewModel() {
                    Cambio = "0,000",
                    CodAGT = codAGT,
                    DataEmissao = documento.Data,
                    DataVencimento = documento.DataVencimento,
                    DescGeracao = string.Empty,
                    Hora = documento.Hora,
                    Moeda = UtilidadesGenericas.Moeda,
                    MoradaCliente = documento.MoredaCliente,
                    NifCliente = documento.NifCliente,
                    NomeCliente = documento.NomeCliente,
                    NomeDocumento = documento.Operacao.Nome,
                    NumeroDocumento = documento.NumeroOrdem,
                    TelCliente = documento.TelCliente,
                    UsuarioCaixa = documento.Usuario.Nome,
                    TipoCliente = documento.Operacao.Entidade
            });
        }
        
    }
    
}
