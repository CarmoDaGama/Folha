using Folha.Domain.Interfaces.Application.Ficalizacao;
using Folha.Domain.Interfaces.Repository.Documentos;
using Folha.Domain.Interfaces.Repository.Inventario;
using Folha.Domain.Interfaces.Repository.Sistema;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Frame.Entidades;
using System;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.Enuns.Documentos;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.Models.Inventario;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Interfaces.Repository.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Driver.Framework.GeradorXmlSaft;

namespace Folha.Driver.Application.Ficalizacao
{
    public class SaftApp : ISaftApp
    {
        private readonly IDocumentosRepository _documentosRepository;
        private readonly IMovArtigoRepository _MovArtigoRepository;
        private readonly IUsuariosRepository _usuarioRepository;
        private readonly IEntidadesRepository _entidadeRepository;
        private readonly IMotivoIsencaoRepository _motivoIsencaoRepository;
        private readonly IAtendimentoHospitalarApp _AtendimentoHospitalarApp;
        private readonly IPagamentosRepository _pagamentosRepository;

        private AuditFile auditFile;

        public SaftApp(
            IMovArtigoRepository MovArtigoRepository, 
            IUsuariosRepository usuarioRepository, 
            IDocumentosRepository documentosRepository,
            IEntidadesRepository entidadeRepository,
            IMotivoIsencaoRepository motivoIsencaoRepository,
            IAtendimentoHospitalarApp atendimentoHospitalarApp,
            IPagamentosRepository pagamentosRepository)
        {
            _MovArtigoRepository = MovArtigoRepository;
            _usuarioRepository = usuarioRepository;
            _documentosRepository = documentosRepository;
            _entidadeRepository = entidadeRepository;
            _motivoIsencaoRepository = motivoIsencaoRepository;
            _AtendimentoHospitalarApp = atendimentoHospitalarApp;
            _pagamentosRepository = pagamentosRepository;
        }
        public void PreencherSaftHeader(DateTime dateStart, DateTime dateEnd)
        {
            auditFile = new AuditFile();
            auditFile.Header = new AuditFileHeader();
            auditFile.Header.CompanyAddress = new AuditFileHeaderCompanyAddress();


            auditFile.Header.AuditFileVersion = "2.0";//UtilidadesGenericas.DadosEmpresa.auditFileVersion;
            auditFile.Header.CompanyID = UtilidadesGenericas.DadosEmpresa.NIF;
            auditFile.Header.TaxRegistrationNumber = UtilidadesGenericas.DadosEmpresa.NIF;
            auditFile.Header.CompanyName = UtilidadesGenericas.DadosEmpresa.Nome;

             
            auditFile.Header.CompanyAddress.Country = UtilidadesGenericas.DadosEmpresa.Pais; // Subtr - para pegar somente o codigo do país ex.: 'Angola AO' pega o 'AO'
            auditFile.Header.CompanyAddress.City = UtilidadesGenericas.DadosEmpresa.Cidade;

            auditFile.Header.BusinessName = UtilidadesGenericas.DadosEmpresa.businessName;
            // Globalizar para buscar na bs
            auditFile.Header.CurrencyCode = "AOA";
            auditFile.Header.TaxAccountingBasis = "F";
            auditFile.Header.TaxEntity = "Global";
            // :::::::::::::::::x

            auditFile.Header.CompanyAddress.AddressDetail = UtilidadesGenericas.DadosEmpresa.Endereco;
            auditFile.Header.Telephone = UtilidadesGenericas.DadosEmpresa.Telefones;
            auditFile.Header.Email = UtilidadesGenericas.DadosEmpresa.Email;
            auditFile.Header.Website = UtilidadesGenericas.DadosEmpresa.Email;

            //auditFile.Header.Fax = ;
            auditFile.Header.FiscalYear = "2013";

            auditFile.Header.DateCreated = Convert.ToDateTime(DateTime.Now);
            auditFile.Header.StartDate = Convert.ToDateTime(dateStart);
            auditFile.Header.EndDate = Convert.ToDateTime(dateEnd);

            // Software 
            auditFile.Header.SoftwareValidationNumber = "0";

            // Dados que colocarei depois na base de dados
            auditFile.Header.ProductVersion = "0.1.2";
            auditFile.Header.ProductCompanyTaxID = "AO1100000";
            auditFile.Header.ProductID = "Trevo Folha/Trevo";

            //============================================


        }
        public void PreencheSaftMaster(DateTime dateStart, DateTime dateEnd)
        {
            var dadosClientes = _documentosRepository.GetDocumentosPor(dateStart, dateEnd);
            var dadosProdutos = _MovArtigoRepository.GetMovProdutosPor(dateStart, dateEnd);
            auditFile.MasterFiles = new AuditFileMasterFiles();

            if (dadosClientes != null && dadosClientes.Count > 0)
            {
                auditFile.MasterFiles.Customer = new AuditFileMasterFilesCustomer[dadosClientes.Count];

                for (int i = 0; i < dadosClientes.Count; i++)
                {
                    auditFile.MasterFiles.Customer[i] = new AuditFileMasterFilesCustomer();

                    auditFile.MasterFiles.Customer[i].CustomerID = dadosClientes[i].CodEntidade.ToString();
                    auditFile.MasterFiles.Customer[i].CompanyName = dadosClientes[i].Entidade.Nome;

                    auditFile.MasterFiles.Customer[i].AccountID = "Desconhecido";
                    auditFile.MasterFiles.Customer[i].CustomerTaxID = dadosClientes[i].Entidade.Nif;

                    auditFile.MasterFiles.Customer[i].SelfBillingIndicator = "0";

                    auditFile.MasterFiles.Customer[i].BillingAddress = new AuditFileMasterFilesCustomerBillingAddress();


                    auditFile.MasterFiles.Customer[i].BillingAddress.Country = "AO"; // Adicionar campo a base de dados
                    auditFile.MasterFiles.Customer[i].BillingAddress.AddressDetail = carregarEndereco(dadosClientes[i].CodEntidade);

                    auditFile.MasterFiles.Customer[i].BillingAddress.City = "Luanda"; // Adicionar campo a base de dados
                    auditFile.MasterFiles.Customer[i].BillingAddress.PostalCode = "0000"; // Adicionar campo a base de dados

                }

            }

            if (dadosProdutos != null && dadosProdutos.Count > 0)
            {
                auditFile.MasterFiles.Product = new AuditFileMasterFilesProduct[dadosProdutos.Count];
                auditFile.MasterFiles.TaxTable = new AuditFileMasterFilesTaxTableEntry[dadosProdutos.Count];

                for (int i = 0; i < dadosProdutos.Count; i++)
                {
                    auditFile.MasterFiles.Product[i] = new AuditFileMasterFilesProduct();
                    auditFile.MasterFiles.TaxTable[i] = new AuditFileMasterFilesTaxTableEntry();


                    auditFile.MasterFiles.Product[i].ProductType = "P"; // Adicioanr campo do tipo na base de dados
                    auditFile.MasterFiles.Product[i].ProductGroup = "N/A";
                    auditFile.MasterFiles.Product[i].ProductCode = dadosProdutos[i].codigo.ToString();
                    auditFile.MasterFiles.Product[i].ProductNumberCode = dadosProdutos[i].CodProduto.ToString();

                    auditFile.MasterFiles.Product[i].ProductDescription = dadosProdutos[i].Descricao;


                    // ------------------------------ TaxTable (Tabela de Imposto) -----------------------------------------
                    auditFile.MasterFiles.TaxTable[i].TaxType = dadosProdutos[i].TipoImposto;
                    auditFile.MasterFiles.TaxTable[i].TaxCode = dadosProdutos[i].CodImposto;
                    auditFile.MasterFiles.TaxTable[i].Description = dadosProdutos[i].DescricaoImposto;
                    auditFile.MasterFiles.TaxTable[i].TaxCountryRegion = "AO";
                }
            }

        }
        public void PreencheSaftMasterSourceDocuments(DateTime dateStart, DateTime dateEnd)
        {
            if (Equals(auditFile.SourceDocuments, null))
            {
                auditFile.SourceDocuments = new AuditFileSourceDocuments();
            }

            auditFile.SourceDocuments.SalesInvoices = new AuditFileSourceDocumentsSalesInvoices();
            auditFile.SourceDocuments.MovementOfGoods = new AuditFileSourceDocumentsMovementOfGoods();
            auditFile.SourceDocuments.WorkingDocuments = new AuditFileSourceDocumentsWorkingDocuments();
            auditFile.SourceDocuments.Payments = new AuditFileSourceDocumentsPayments();
            #region SalesInvoices
            var dadosDocumentosComerciais = _documentosRepository.GetMovFinDeDocumentosVenda(dateStart, dateEnd);
            auditFile.SourceDocuments.SalesInvoices.NumberOfEntries = GetNumeroDeDocumentosFacturadoOuAnulado(dateStart, dateEnd);
            auditFile.SourceDocuments.SalesInvoices.TotalDebit = _documentosRepository.GetTotalMovFinDeDocumentosVenda(dateStart, dateEnd, "DEBITO");
            auditFile.SourceDocuments.SalesInvoices.TotalCredit = _documentosRepository.GetTotalMovFinDeDocumentosVenda(dateStart, dateEnd, "CREDITO");
            auditFile.SourceDocuments.SalesInvoices.Invoice = new AuditFileSourceDocumentsSalesInvoicesInvoice[dadosDocumentosComerciais.Count];

            for (int i = 0; i < dadosDocumentosComerciais.Count; i++)
            {

                auditFile.SourceDocuments.SalesInvoices.Invoice[i] = new AuditFileSourceDocumentsSalesInvoicesInvoice();
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].InvoiceNo = dadosDocumentosComerciais[i].Operacao.APP + " AGT" + DateTime.Now.Year + "/" + dadosDocumentosComerciais[i].NumeroOrdem;
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].DocumentStatus = new AuditFileSourceDocumentsSalesInvoicesInvoiceDocumentStatus();
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].DocumentStatus.InvoiceStatus = GetSiglaEstadoDocumento(dadosDocumentosComerciais[i].Estado);
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].DocumentStatus.SourceID = dadosDocumentosComerciais[i].CodUsuario.ToString();
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].DocumentStatus.InvoiceStatusDate = GetDataFormatoCorreto(dadosDocumentosComerciais[i].Data, dadosDocumentosComerciais[i].Hora);
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].DocumentStatus.SourceBilling = "P";

                string invoiceNo = auditFile.SourceDocuments.SalesInvoices.Invoice[i].InvoiceNo;
                DateTime data = GetDataFormatoCorreto(dadosDocumentosComerciais[i].Data, dadosDocumentosComerciais[i].Hora);
                var total = dadosDocumentosComerciais[i].Total;
                string dadosParaHash = data + ";" + data.ToString("yyyy-MM-ddThh:mm:ss") + ";" + invoiceNo + ";" + total + ";" + "";

                string Hash = UtilidadesGenericas.GerarHash(dadosParaHash);

                auditFile.SourceDocuments.SalesInvoices.Invoice[i].Hash = Hash;
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].HashControl = "1";
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].Period = DateTime.Now.Month.ToString();
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].InvoiceDate = dadosDocumentosComerciais[i].Data;
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].InvoiceType = dadosDocumentosComerciais[i].Operacao.APP;
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].SpecialRegimes = new AuditFileSourceDocumentsSalesInvoicesInvoiceSpecialRegimes();
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].SpecialRegimes.SelfBillingIndicator = "0";
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].SpecialRegimes.SelfBillingIndicator = "0";
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].SourceID = dadosDocumentosComerciais[i].CodUsuario.ToString();
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].SystemEntryDate = DateTime.Now;
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].CustomerID = dadosDocumentosComerciais[i].CodEntidade.ToString();
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].Line = GetProdutosDoDocumentnto(dadosDocumentosComerciais[i].codigo);
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].DocumentTotals = new AuditFileSourceDocumentsSalesInvoicesInvoiceDocumentTotals();
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].DocumentTotals.TaxPayable = GetTotalParcelasImposto(dadosDocumentosComerciais[i].codigo);
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].DocumentTotals.NetTotal = GetTotalSemImposto(dadosDocumentosComerciais[i].codigo);
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].DocumentTotals.GrossTotal = dadosDocumentosComerciais[i].Total;
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].DocumentTotals.Payment = new AuditFileSourceDocumentsSalesInvoicesInvoiceDocumentTotalsPayment();
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].DocumentTotals.Payment.PaymentMechanism = GeteMeioDePagamento(dadosDocumentosComerciais[i].codigo);
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].DocumentTotals.Payment.PaymentAmount = GetSaldoPagamento(dadosDocumentosComerciais[i].codigo);
                auditFile.SourceDocuments.SalesInvoices.Invoice[i].DocumentTotals.Payment.PaymentDate = GetDataPagamento(dadosDocumentosComerciais[i].codigo);

            }
            #endregion


            #region MovementOfGoods
            var dadosDocumentosMovimento = _documentosRepository.GetMovFinDeDocumentosMovimento(dateStart, dateEnd);

            auditFile.SourceDocuments.MovementOfGoods.NumberOfMovementLines = dadosDocumentosMovimento.Count.ToString();
            auditFile.SourceDocuments.MovementOfGoods.TotalQuantityIssued = GetTotalQtdArtigodo(dadosDocumentosMovimento);
            #endregion

            #region WorkingDocuments
            var dadosDocumentosConferencias = _documentosRepository.GetMovFinDeDocumentosConferencias(dateStart, dateEnd);
            auditFile.SourceDocuments.WorkingDocuments.NumberOfEntries = dadosDocumentosConferencias.Count.ToString();
            auditFile.SourceDocuments.WorkingDocuments.TotalDebit = _documentosRepository.GetTotalMovFinDeDocumentosConferencias(dateStart, dateEnd, "DEBITO");
            auditFile.SourceDocuments.WorkingDocuments.TotalCredit = _documentosRepository.GetTotalMovFinDeDocumentosConferencias(dateStart, dateEnd, "CREDITO");
            auditFile.SourceDocuments.WorkingDocuments.WorkDocument = new AuditFileSourceDocumentsWorkingDocumentsWorkDocument[dadosDocumentosConferencias.Count];
            for (int i = 0; i < dadosDocumentosConferencias.Count; i++)
            {
                var doc = dadosDocumentosConferencias[i];
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i] = new AuditFileSourceDocumentsWorkingDocumentsWorkDocument();
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].DocumentNumber = doc.Operacao.APP + " AGT" + DateTime.Now.Year + "/" + doc.NumeroOrdem;
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].DocumentStatus = new AuditFileSourceDocumentsWorkingDocumentsWorkDocumentDocumentStatus();
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].DocumentStatus.WorkStatus = GetSiglaEstadoDocumento(doc.Estado);
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].DocumentStatus.WorkStatusDate = GetDataFormatoCorreto(doc.Data, doc.Hora);
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].DocumentStatus.Reason = "";
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].DocumentStatus.SourceID = doc.CodUsuario.ToString();
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].DocumentStatus.SourceBilling = "P";
                string dadosParaHash = doc.Data + ";" 
                                        + GetDataFormatoCorreto(doc.Data, doc.Hora).ToString("yyyy-MM-ddThh:mm:ss") + ";" 
                                        + auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].DocumentNumber + ";" 
                                        + doc.Total + ";" + "";

                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Hash = UtilidadesGenericas.GerarHash(dadosParaHash);
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].HashControl = "1";
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Period = DateTime.Now.Month.ToString();
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].WorkType = doc.Operacao.APP;
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].SourceID = doc.CodUsuario.ToString();
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].SystemEntryDate = DateTime.Now;
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].TransactionID = "";
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].CustomerID = doc.CodEntidade.ToString();
                var movsLine = _MovArtigoRepository.GetAllByIdDocumento(doc.codigo);
                if (!UtilidadesGenericas.ListaNula(movsLine))
                {
                    auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line = new AuditFileSourceDocumentsWorkingDocumentsWorkDocumentLine[movsLine.Count];

                    for (int l = 0; l < movsLine.Count; l++)
                    {

                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l] = new AuditFileSourceDocumentsWorkingDocumentsWorkDocumentLine();
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].LineNumber = (l+1).ToString();
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].ProductCode = movsLine[l].codigo.ToString();
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].ProductDescription = movsLine[l].Descricao;
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].Quantity = movsLine[l].Qtdade;
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].UnitOfMeasure = "Un";
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].UnitPrice = movsLine[l].Preco;
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].TaxPointDate = doc.Data;
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].Description = doc.Descritivo;
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].CreditAmount = (movsLine[l].Preco - (movsLine[l].Preco * (movsLine[l].Desconto / 100)));
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].Tax = new  AuditFileSourceDocumentsWorkingDocumentsWorkDocumentLineTax();
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].Tax.TaxType = movsLine[l].TipoImposto;
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].Tax.TaxCountryRegion = "AO";
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].Tax.TaxCode = movsLine[l].CodImposto;
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].Tax.TaxPercentage = movsLine[l].Imposto;
                        //if (mov.Imposto <= 0)
                        //{
                        //    var motivoIsecao = GetMotivoDeIsencao(mov);
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].TaxPointDate = GetDataFormatoCorreto(doc.Data, doc.Hora);
                        //}
                        auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].Line[l].SettlementAmount = (movsLine[l].Desconto + movsLine[l].DescontoGeral);
                
                    }
                }
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].DocumentTotals = new AuditFileSourceDocumentsWorkingDocumentsWorkDocumentDocumentTotals();
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].DocumentTotals.TaxPayable = GetTotalParcelasImposto(doc.codigo);
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].DocumentTotals.NetTotal = GetTotalSemImposto(doc.codigo);
                auditFile.SourceDocuments.WorkingDocuments.WorkDocument[i].DocumentTotals.GrossTotal = doc.Total;

            }

            #endregion

            #region Payments
            var dadosDocumentosRecibos = _pagamentosRepository.GetMovFinDeDocumentosRecibo(dateStart, dateEnd);

            auditFile.SourceDocuments.Payments.NumberOfEntries = dadosDocumentosRecibos.Count.ToString();
            auditFile.SourceDocuments.Payments.TotalDebit = _pagamentosRepository.GetTotalMovFinDeDocumentosRecibo(dateStart, dateEnd, "DEBITO");
            auditFile.SourceDocuments.Payments.TotalCredit = _pagamentosRepository.GetTotalMovFinDeDocumentosRecibo(dateStart, dateEnd, "CREDITO");
            auditFile.SourceDocuments.Payments.Payment = new AuditFileSourceDocumentsPaymentsPayment[dadosDocumentosRecibos.Count];
            for (int i = 0; i < dadosDocumentosRecibos.Count; i++)
            {

                var docP = dadosDocumentosRecibos[i];
                var tipoP = "RC";
                if (docP.Documento.Operacao.APP == "FR")
                {
                    tipoP = "RC";
                }
                else if (docP.Documento.Operacao.APP == "FT")
                {
                    tipoP = "RG";
                }
                auditFile.SourceDocuments.Payments.Payment[i] = new AuditFileSourceDocumentsPaymentsPayment();
                auditFile.SourceDocuments.Payments.Payment[i].PaymentRefNo = tipoP + " AGT" + DateTime.Now.Year + "/" + docP.NumeroOrdem ;
                auditFile.SourceDocuments.Payments.Payment[i].Period = DateTime.Now.Month.ToString();
                auditFile.SourceDocuments.Payments.Payment[i].TransactionDate = docP.Data;
                auditFile.SourceDocuments.Payments.Payment[i].PaymentType = tipoP;
                auditFile.SourceDocuments.Payments.Payment[i].Description = docP.Descricao;
                auditFile.SourceDocuments.Payments.Payment[i].SystemID = docP.codigo.ToString();
                auditFile.SourceDocuments.Payments.Payment[i].DocumentStatus = new AuditFileSourceDocumentsPaymentsPaymentDocumentStatus();
                auditFile.SourceDocuments.Payments.Payment[i].DocumentStatus.PaymentStatus = "N";
                auditFile.SourceDocuments.Payments.Payment[i].DocumentStatus.PaymentStatusDate = GetDataFormatoCorreto(docP.Data, docP.Hora);
                auditFile.SourceDocuments.Payments.Payment[i].DocumentStatus.SourceID = docP.Documento.CodEntidade.ToString();
                auditFile.SourceDocuments.Payments.Payment[i].DocumentStatus.SourcePayment = "P";
                var formasDePagamentos = _pagamentosRepository.GetAllPorIdDocumento(docP.codigo);
                if (!UtilidadesGenericas.ListaNula(formasDePagamentos))
                {
                    auditFile.SourceDocuments.Payments.Payment[i].PaymentMethod = new AuditFileSourceDocumentsPaymentsPaymentPaymentMethod[formasDePagamentos.Count];
                    auditFile.SourceDocuments.Payments.Payment[i].Line = new AuditFileSourceDocumentsPaymentsPaymentLine[formasDePagamentos.Count];

                    for (int f = 0; f < formasDePagamentos.Count; f++)
                    {

                        auditFile
                            .SourceDocuments
                            .Payments
                            .Payment[i].PaymentMethod[f] = new AuditFileSourceDocumentsPaymentsPaymentPaymentMethod();

                        auditFile
                            .SourceDocuments
                            .Payments
                            .Payment[i].
                            PaymentMethod[f].PaymentMechanism = GeteMeioDePagamento(formasDePagamentos[f]);
                        auditFile.SourceDocuments.Payments.Payment[i].PaymentMethod[f].PaymentAmount = formasDePagamentos[f].Valor;
                        auditFile.SourceDocuments.Payments.Payment[i].PaymentMethod[f].PaymentDate = formasDePagamentos[f].Data;


                        auditFile.SourceDocuments.Payments.Payment[i].Line[f] = new AuditFileSourceDocumentsPaymentsPaymentLine();
                        auditFile.SourceDocuments.Payments.Payment[i].Line[f].LineNumber = (f + 1).ToString();
                        auditFile.SourceDocuments.Payments.Payment[i].Line[f].CreditAmount = UtilidadesGenericas.GetTotalNaLista(formasDePagamentos, "Valor");
                        auditFile.SourceDocuments.Payments.Payment[i].Line[f].SourceDocumentID = new AuditFileSourceDocumentsPaymentsPaymentLineSourceDocumentID();
                        auditFile.SourceDocuments.Payments.Payment[i].Line[f].SourceDocumentID.OriginatingON = formasDePagamentos[f].Documento.NumeroOrdem + " F/" + formasDePagamentos[f].Documento.codigo;
                        auditFile.SourceDocuments.Payments.Payment[i].Line[f].SourceDocumentID.InvoiceDate = formasDePagamentos[f].Data;
                        auditFile.SourceDocuments.Payments.Payment[i].Line[f].SourceDocumentID.Description = formasDePagamentos[f].Descricao;
                    }
                }
                auditFile.SourceDocuments.Payments.Payment[i].SourceID = docP.Documento.CodUsuario.ToString();
                auditFile.SourceDocuments.Payments.Payment[i].SystemEntryDate = DateTime.Now;
                auditFile.SourceDocuments.Payments.Payment[i].CustomerID = docP.Documento.CodEntidade.ToString();
                
                auditFile.SourceDocuments.Payments.Payment[i].DocumentTotals = new AuditFileSourceDocumentsPaymentsPaymentDocumentTotals();
                auditFile.SourceDocuments.Payments.Payment[i].DocumentTotals.TaxPayable = 0.000m;
                auditFile.SourceDocuments.Payments.Payment[i].DocumentTotals.NetTotal = docP.Valor;
                auditFile.SourceDocuments.Payments.Payment[i].DocumentTotals.GrossTotal = docP.Valor;
                //auditFile.SourceDocuments.Payments.Payment[i].WithholdingTax = new AuditFileSourceDocumentsPaymentsPaymentWithholdingTax[];
                //auditFile.SourceDocuments.Payments.Payment[i].WithholdingTaxWithholdingTaxType = "IRC";
                //auditFile.SourceDocuments.Payments.Payment[i].WithholdingTax.WithholdingTaxDescription = "Aplicação da Retenção";
                //auditFile.SourceDocuments.Payments.Payment[i].WithholdingTax.WithholdingTaxAmount = GetTotalParcelasImposto(docP.Documento.codigo);
            }


            #endregion
        }


        public void GerarSaft(DateTime dateStart, DateTime dateEnd, string caminho, string nomeFicheiro)
        {
            PreencherSaftHeader(dateStart, dateEnd);
            PreencheSaftMaster(dateStart, dateEnd);
            PreencheSaftMasterSourceDocuments(dateStart, dateEnd);
            if (string.IsNullOrEmpty(caminho))
            {
                caminho = System.Windows.Forms.Application.StartupPath + @"\SAFT\";
            }
            salvarSalf(auditFile, caminho, nomeFicheiro + "");
        }
        public string salvarSalf(AuditFile audiFile, string caminho, string nomeFicheiro)
        {
            if (MetodosSaft.Salvar(audiFile, caminho, nomeFicheiro))
                return "Exportado Com sucesso..!";
            else
                return "Eroo ao exportar..!";
        }

        private string carregarEndereco(int codEntidade)
        {
            var contactos = (List<ContactoViewModel>)_entidadeRepository.CarregaContactos(codEntidade.ToString());
            if (UtilidadesGenericas.ListaNula(contactos))
            {
                return "DESCONHECIDO";
            }
            return contactos[0].Descricao;
        }


        private decimal GetTotalQtdArtigodo(List<DocumentosViewModel> dadosDocumentosMovimento)
        {
            var totatQtd = 0.0m;
            foreach (var item in dadosDocumentosMovimento)
            {
                if (UtilidadesGenericas.InEnumStdDoc(item.Estado) == TipoEstadoDocumento.ANULADO)
                {
                    continue;
                }
                var movArtigos = _MovArtigoRepository.GetAllByIdDocumento(item.codigo);
                foreach (var artigo in movArtigos)
                {
                    totatQtd += artigo.Qtdade;
                }
            }
            return totatQtd;
        }

        private DateTime GetDataPagamento(int codDocumento)
        {
            var pagamento = _pagamentosRepository.GetPorIdDocumento(codDocumento);
            if (Equals(pagamento, null))
            {
                return new DateTime();
            }
            return pagamento.Data;
        }
        private decimal GetSaldoPagamento(int codDocumento)
        {
            var pagamento = _pagamentosRepository.GetPorIdDocumento(codDocumento);
            if (Equals(pagamento, null))
            {
                return 0.0m;
            }
            return pagamento.Valor;
        }
        private string GeteMeioDePagamento(int codDocumento)
        {
            var pagamento = _pagamentosRepository.GetPorIdDocumento(codDocumento);
            if (Equals(pagamento, null))
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(pagamento.Forma.CodConta) || pagamento.Forma.CodConta == "0")
            {
                return "OU";
            }
            else
            {
                return "TB";
            }
        }
        private string GeteMeioDePagamento(PagamentosViewModel pagamento)
        {
            if (Equals(pagamento, null))
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(pagamento.Forma.CodConta) || pagamento.Forma.CodConta == "0")
            {
                return "OU";
            }
            else
            {
                return "TB";
            }
        }

        public decimal GetTotalParcelasImposto(int codDocumento)
        {
            var movArtigos = _MovArtigoRepository.GetAllByIdDocumento(codDocumento);
            var totalParcelasImposto = 0.0m;
            foreach (var item in movArtigos)
            {
                totalParcelasImposto += item.Preco * (item.Imposto / 100);
            }
            return totalParcelasImposto;

        }
        private decimal GetTotalSemImposto(int codDocumento)
        {
            var movArtigos = _MovArtigoRepository.GetAllByIdDocumento(codDocumento);
            var totalLimpo = 0.0m;
            foreach (var item in movArtigos)
            {
                totalLimpo += item.Preco;
            }
            return totalLimpo;
        }

        private AuditFileSourceDocumentsSalesInvoicesInvoiceLine[] GetProdutosDoDocumentnto(int codDocumento)
        {
            var movArtigos = _MovArtigoRepository.GetAllByIdDocumento(codDocumento);
            var lines = new AuditFileSourceDocumentsSalesInvoicesInvoiceLine[movArtigos.Count];
            for (int i = 0; i < movArtigos.Count; i++)
            {
                lines[i] = new AuditFileSourceDocumentsSalesInvoicesInvoiceLine();
                lines[i].LineNumber = i.ToString();
                lines[i].ProductCode = movArtigos[i].codigo.ToString();
                lines[i].ProductDescription = movArtigos[i].Descricao;
                lines[i].Quantity = movArtigos[i].Qtdade;
                lines[i].UnitOfMeasure = "Un";
                lines[i].UnitPrice = movArtigos[i].Preco;
                lines[i].TaxPointDate = DateTime.Now;
                lines[i].Description = "bom";
                if (UtilidadesGenericas.InEnumMov(movArtigos[i].Documento.Operacao.MovFin) == TipoMov.CREDITO)
                {

                    lines[i].CreditAmount = movArtigos[i].Preco;
                }
                else if(UtilidadesGenericas.InEnumMov(movArtigos[i].Documento.Operacao.MovFin) == TipoMov.DEBITO)
                {
                    lines[i].DebitAmount = movArtigos[i].Preco;
                }
                lines[i].Tax = new AuditFileSourceDocumentsSalesInvoicesInvoiceLineTax();
                lines[i].Tax.TaxType = movArtigos[i].TipoImposto;
                lines[i].Tax.TaxCountryRegion = "AO";
                lines[i].Tax.TaxCode = movArtigos[i].CodImposto;
                lines[i].Tax.TaxPercentage = movArtigos[i].Imposto;
                if (movArtigos[i].Imposto <= 0)
                {
                    var motivoIsecao = GetMotivoDeIsencao(movArtigos[i]);
                    if (!Equals(motivoIsecao, null))
                    {
                        lines[i].TaxExemptionReason = motivoIsecao.Descricao;
                        lines[i].TaxExemptionCode = motivoIsecao.Referencia;
                    }
                }
                lines[i].SettlementAmount = (movArtigos[i].Desconto + movArtigos[i].DescontoGeral);
            }
            return lines;
        }

        private MotivoIsencao GetMotivoDeIsencao(MovProdutosViewModel movArtigo)
        {
            var motivo = new MotivoIsencao();
            if ((movArtigo.CodProduto > 0 || movArtigo.CodStock > 0) && (!Equals(movArtigo.Artigo, null) || !Equals(movArtigo.ArtigoStock, null)))
            {
               motivo = _motivoIsencaoRepository.GetMotivoPorDescricao(movArtigo.ArtigoStock.Artigo.MotivoIsencao);
            }
            else if (!string.IsNullOrEmpty(movArtigo.ArtigoAbstrato))
            {

                var thisItem = new ItemViewModel(movArtigo.ArtigoAbstrato);
                if (!Equals(thisItem, null) && thisItem.Id > 0)
                {
                    motivo = _AtendimentoHospitalarApp.GetMotivoIsencao(thisItem.Tipo, thisItem.Id);
                }
            }
            return motivo;
        }

        private DateTime GetDataFormatoCorreto(DateTime data, string strHora)
        {
            int hora = 0, minuno = 0, segundo = 0;
            var spHora = strHora.Split(':');
            if (!Equals(spHora, null) && spHora.Length > 1)
            {
                hora = int.Parse(spHora[0]);
                minuno = int.Parse(spHora[1]);
            }
            segundo = data.Second;
            return new DateTime(data.Year, data.Month, data.Day, hora, minuno, segundo);
        }

        private string GetSiglaEstadoDocumento(string estado)
        {
            switch (estado)
            {
                case "ABERTO":
                    return "N";
                case "PENDENTE":
                    return "N";
                case "FECHADO":
                    return "F";
                case "ANULADO":
                    return "A";
                default:
                    return "N";
            }
        }

        private string GetNumeroDeDocumentosFacturadoOuAnulado(DateTime dateStart, DateTime dateEnd)
        {
            return _documentosRepository.GetNumeroDeDocumentosFacturadoOuAnulado(dateStart, dateEnd).ToString();
        }
    }
}
