using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.ViewModels.Sistema;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Classe;
using Folha.Presentation.Desktop.Forms.Financeiro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Separadores.Armazens
{
    public partial class frmStockTransferencia : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ITransferenciaProdutoApp _transferenciaProdutoApp;
        private int indexOrigem { get; set; }
        private List<TransferenciaProdutoViewModel> TransProdutoViewModel { get; set; }
        public List<MovProdutosViewModel> MovProdutos { get; set; }
        public List<ArmazensViewModel> ListaArmazens { get; private set; }
        private DocumentosViewModel DocumentoTransferencia { get; set; }
        //private DocumentosViewModel DocumentoEntrada { get; set; }
        //private DocumentosViewModel DocumentoSaida { get; set; }

        private int CodArmazem { get;  set; }
        private string NomeArmazem { get; set; }
        private TransferenciaProdutoViewModel trans;
        public TransferenciaProduto  transferir { get; set; }
        
        int CodOperacao;
        //public int Index { get; private set; } = -1;
        private List<TransferenciaProdutoViewModel> ListaProdutos { get; set; }
        private bool TransferenciaEditada { get; set; }

        private readonly IArmazemApp _armazemApp;
        private readonly IDocumentosApp _documentoApp;
        private readonly IOperacoesApp _operacaoApp;
        private readonly IMovArtigosApp _movArtigosApp;
        private int codDoc;
        private int cod;
        private readonly IUsuariosApp _usuarioApp;
        //private readonly IEmpresaApp _empresaApp;
        private readonly IOperacoesApp _OperacoesApp;
        private OperacoesViewModel DadosOperacoes;

        public frmStockTransferencia
            (
            ITransferenciaProdutoApp transferenciaProdutoApp, 
            IArmazemApp armazemApp, 
            IDocumentosApp documentoApp, 
            IOperacoesApp operacaoApp, 
            IMovArtigosApp movArtigosApp,
            IUsuariosApp usuarioApp, IOperacoesApp OperacoesApp
            )
        {
            InitializeComponent();
            _transferenciaProdutoApp = transferenciaProdutoApp;
            _armazemApp = armazemApp;
            _documentoApp = documentoApp ;
            _operacaoApp = operacaoApp;
            _movArtigosApp = movArtigosApp;
            _usuarioApp = usuarioApp;
            _OperacoesApp = OperacoesApp;



        }
        #region Metodos de Execução de tarefas

        public bool EditarTransferenciaArtigo(int codigo)
        {
            DocumentoTransferencia = _documentoApp.GetById(codigo);
            ShowDialog();
            return TransferenciaEditada;
        }
        public void MostrarTransferencia()
        {
            if (!ExisteDocumento())
            {
                var operacao = _operacaoApp.GetOperacaPorNome("TRANSFERENCIA DE ARTIGO");
                DocumentoTransferencia = _documentoApp.GetUltimoDocumento(operacao.codigo, "ABERTO");
            }
            if (ExisteDocumento())
            {
                codDoc = DocumentoTransferencia.codigo;
                txtdoc.Text = codDoc.ToString();
                ListaProdutos = (List<TransferenciaProdutoViewModel>)_transferenciaProdutoApp.Listar(txtdoc.Text, false);
                gradeTrans.DataSource = ListaProdutos;
            }
            txtdata.Text = DateTime.Now.ToShortDateString();
            txtdata.Properties.MaxValue = DateTime.Now;
        }

        private bool ExisteDocumento()
        {
            return !Equals(DocumentoTransferencia, null) && DocumentoTransferencia.codigo > 0;
        }

        public void CarregarArmazensnaCbo()
        {
            ListaArmazens = _armazemApp.GetAll();
            foreach (var item in ListaArmazens) cboOrigem.Properties.Items.Add(item.descricao);
            foreach (var item in ListaArmazens) cboDestino.Properties.Items.Add(item.descricao);
            cboOrigem.SelectedIndex = 0;
            cboDestino.SelectedIndex = cboDestino.Properties.Items.Count - 1;
        }
        public void buscarProduto()
        {
            UtilidadesGenericas.Busca.Codigo = null;
            frmBuscaArtigos Buscar = IOC.InjectForm<frmBuscaArtigos>();
            Buscar.ShowDialog();
            if (UtilidadesGenericas.Busca.Codigo == null) return;
            txtcodigo.Text = UtilidadesGenericas.Busca.CodProduto;
            txtdescricao.Text = UtilidadesGenericas.Busca.Descricao;
            txtStock.Text = UtilidadesGenericas.Busca.Quantidade;
            CodArmazem = UtilidadesGenericas.Busca.CodArmazem;
            NomeArmazem = UtilidadesGenericas.Busca.NomeArmazem;
            cboOrigem.SelectedItem = NomeArmazem;
        }

        private bool ContemNaListas(int CompoID)
        {
            return ListaProdutos.Where(a => a.CodProduto == CompoID).FirstOrDefault() != null;

        }
        private TransferenciaProdutoViewModel PopulaObjecto()
        {
            trans = new TransferenciaProdutoViewModel()
            {
                CodDocumento = codDoc,
                CodProduto = int.Parse(txtcodigo.Text),
                Quantidade = int.Parse(txtQuant.Text),
                Origem = cboOrigem.SelectedItem.ToString(),
                Destino = cboDestino.SelectedItem.ToString(),
                CodOrigem = CodArmazem,
                CodDestino = ListaArmazens[cboDestino.SelectedIndex].codigo
            };
           // verifica();
            return trans;
        }

        private void verifica()
        {
            if (gridTrans.RowCount > 0 && ContemNaListas(trans.CodProduto))
            {
                UtilidadesGenericas.MsgShow("ERRO", "O Artigo: " + txtdescricao.Text + " Já está Adicionado", MessageBoxIcon.Error, MessageBoxButtons.OK);
                return;
            }
        }

        private DocumentosViewModel CriarNovoDocumento(string operacaoNome, string descritivo)
        {
            var operacao = _operacaoApp.GetOperacaPorNome(operacaoNome);
            var documentLast = _documentoApp.GetById(_documentoApp.GetCodDocumentoLastPorCodOperacao(operacao.codigo));
            var novoNumeroOrdem = Equals(documentLast, null) ? 1 : documentLast.NumeroOrdem + 1;

            string subMascara = operacao.APP + "/" + novoNumeroOrdem;

            _documentoApp.Insert(new DocumentosViewModel()
            {
                CodOperacao = operacao.codigo,
                Mascara = subMascara,
                Estado = "ABERTO",
                CodEntidade = 2,
                CodUsuario = UtilidadesGenericas.UsuarioCodigo,
                Total = 0,
                Descritivo = descritivo,
                NumeroOrdem = novoNumeroOrdem,
                Data = DateTime.Now,
                Hora = DateTime.Now.ToShortTimeString(),
                CodArea = 2,
                CodMesa = 0,
                CodTurno = UtilidadesGenericas.CodigoTurno,
            });

            return _documentoApp.GetById(_documentoApp.GetCodDocumentoLastPorCodOperacao(operacao.codigo));
        }
        private AlterarStockViewModel GetProdutoArterar()
        {
            int CodOrigem = ListaArmazens[cboOrigem.SelectedIndex].codigo ;
            int CodDestino = ListaArmazens[cboDestino.SelectedIndex].codigo  ;
            int codProduto = int.Parse(txtcodigo.Text);
            decimal Qtdade = decimal.Parse(txtQuant.Text);

            return new AlterarStockViewModel()
            {
                codigoProduto = codProduto,
                armaz = CodOrigem,
                Qtdade = Qtdade,
                CodDestino = CodDestino              
            };
        }
        private void ProdutoAlterarStock()
        {
            if (_transferenciaProdutoApp.ExisteNoArmazem(GetProdutoArterar()))
            {
                _transferenciaProdutoApp.AumentaStock(GetProdutoArterar());
            }
            else
            {
                _transferenciaProdutoApp.InserirQtdadeArmazem(GetProdutoArterar());
            }
        }
        private void Limpar()
        {
            txtcodigo.Text = "";
            txtdescricao.Text = "";
            txtStock.Text = "";
            txtQuant.Text = "";
        }
      
        private void GravarTransferenciaEntradaSaida()
        {
        //    DocumentoSaida = CriarNovoDocumento("TRANSFERENCIA DE ARTIGO(SAIDA)", "Saida de Artigos");
        //    DocumentoEntrada = CriarNovoDocumento("TRANSFERENCIA DE ARTIGO(ENTRADA)", "Entrada de Artigos");
            foreach (var item in ListaProdutos)
            {
                int codStockDestino = _transferenciaProdutoApp.GetCodigoStock(item.CodDestino, item.CodProduto);
                if (codStockDestino > 0)
                {
                    _movArtigosApp.Insert(getMovArtigoEntrada(item, codStockDestino));
                }
                int codStockOrigem = _transferenciaProdutoApp.GetCodigoStock(item.CodOrigem, item.CodProduto);
                if (codStockOrigem > 0)
                {
                    _movArtigosApp.Insert(getMovArtigoSaida(item, codStockOrigem));
                }
            }
            //fecharDocumento(DocumentoEntrada);
            //fecharDocumento(DocumentoSaida);
        }
        private MovProdutosViewModel getMovArtigoEntrada(TransferenciaProdutoViewModel item, int codStock)
        {           
            return new MovProdutosViewModel()
            {
                CodDocumento = DocumentoTransferencia.codigo,
                CodProduto = item.CodProduto,
                Descricao = item.Descricao,
                Preco = item.Preco,
                CodArmazem = item.CodDestino,
                Qtdade = item.Quantidade,
                Custo = item.Custo,
                Imposto = 0,
                Desconto = 0,
                Retencao = 0,
                CodStock = codStock
            };
        }
        private MovProdutosViewModel getMovArtigoSaida(TransferenciaProdutoViewModel item, int codStock)
        {
            return new MovProdutosViewModel()
            {
                CodDocumento = DocumentoTransferencia.codigo,
                CodProduto = item.CodProduto,
                Descricao = item.Descricao,
                Preco = item.Preco,
                CodArmazem = item.CodOrigem,
                Qtdade = item.Quantidade,
                Custo = item.Custo,
                Imposto = 0,
                Desconto = 0,
                Retencao = 0,
                CodStock = codStock
            };
        }
        #endregion
        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
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
            if (cboDestino.SelectedItem == null)
            {
          UtilidadesGenericas.MsgShow("AVISO ","Selecione armazem de destino", MessageBoxIcon.Information, MessageBoxButtons.OK);

                return false;

            }
            if (cboDestino.SelectedItem == cboOrigem.SelectedItem)
            {
                UtilidadesGenericas.MsgShow("AVISO ", "Selecione outro armazem de destino\nNao pode efectuar transferencia no mesmo armazem", MessageBoxIcon.Information, MessageBoxButtons.OK);

                return false;
            }

            if (string.IsNullOrEmpty(txtcodigo.Text))
            {
                UtilidadesGenericas.MsgShow("AVISO ", "selecionado um Artigo", MessageBoxIcon.Information, MessageBoxButtons.OK);

                return false;
            }
            if (string.IsNullOrEmpty(txtQuant.Text))
            {
                UtilidadesGenericas.MsgShow("AVISO ", "Informe a quantidade desejada", MessageBoxIcon.Information, MessageBoxButtons.OK);

                return false;
            }
            if (UtilidadesGenericas.CalculosFinanceiros.IsNumeric(txtQuant.Text) == false)
            {
                MessageBox.Show("Quantidade invalida", "Informe a Quantidade Numerica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return valid;
        }
        #endregion
        private void btnLancar_Click(object sender, EventArgs e)
        {
          
            if (!isFieldsValid()) return;
            if (Equals(DocumentoTransferencia, null))
            {
                DocumentoTransferencia = CriarNovoDocumento(
                    "TRANSFERENCIA DE ARTIGO",
                    "Transferência de " + cboOrigem.SelectedItem + " para " + cboDestino.SelectedItem
                    );
            }
            codDoc = DocumentoTransferencia.codigo;

            if (decimal.Parse(txtStock.Text) < decimal.Parse(txtQuant.Text))
            {
                UtilidadesGenericas.MsgShow(
                    "ERRO ", 
                    "Quantidade é superior ao stock",
                    MessageBoxIcon.Error, 
                    MessageBoxButtons.OK
                );

                return;
            }

            var transferncia = PopulaObjecto();
            transferncia = _transferenciaProdutoApp.Gravar(transferncia);
            var diminuir = GetProdutoArterar();
            _transferenciaProdutoApp.DiminuirStock(diminuir);
            ProdutoAlterarStock();
            MostrarTransferencia();
            Limpar();

        }
        private void fecharDocumento(DocumentosViewModel documento)
        {
            documento.Estado = "FECHADO";
            _documentoApp.Update(documento);
            documento = null;
            
        }       
        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {           
            if (gridTrans.RowCount > 0)
            { GravarTransferenciaEntradaSaida();
                fecharDocumento(DocumentoTransferencia);
                codDoc = 0;
                txtdoc.Text = string.Empty;
                UtilidadesGenericas.MsgShow(
                    "SUCESSO ", 
                    "Transferencia Feita Com Sucesso!",
                    MessageBoxIcon.None,
                    MessageBoxButtons.OK
                );
                TransferenciaEditada = true;
                gradeTrans.DataSource = null;
                Imprimir();               
            }
            else
            {
                UtilidadesGenericas.MsgShow(
                    "ERRO ",
                    "Faça uma Transfêrencia para conluir ", 
                    MessageBoxIcon.Error, 
                    MessageBoxButtons.OK
                );

                return;
            }
        }
        private void frmStockTransferencia_Load(object sender, EventArgs e)
        {
            MostrarTransferencia();
            CarregarArmazensnaCbo();
            cboDestino.SelectedIndex = 0;
            cboDestino.SelectedIndex = 1;

            DadosOperacoes = _OperacoesApp.GetOperacaPorNome("TRANSFERENCIA DE ARTIGO");
            CodOperacao = DadosOperacoes.codigo;
        }
        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {          
            if (DialogResult.Yes == (MessageBox.Show("Deseja Eliminar Registo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)))
            {
                try
                {
                    _transferenciaProdutoApp.Delete(new TransferenciaProduto()
                    {
                        codigo = cod,
                    });
                    MostrarTransferencia();
                    UtilidadesGenericas.MsgShow("SUCESSO ", "Eliminado", MessageBoxIcon.None, MessageBoxButtons.OK);

                }
                catch (Exception)
                {
                    throw new Exception("Erro ao Deletar\n");
                }
            }
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            cod = int.Parse(gridTrans.GetRowCellValue(e.RowHandle, "Codigo").ToString());
        }
        private void btnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            Imprimir();
            
        }

        private void Imprimir()
        {
            ListaProdutos = (List<TransferenciaProdutoViewModel>)_transferenciaProdutoApp.Listar(DocumentoTransferencia.codigo.ToString(), false);

            if (Equals(ListaProdutos, null) || ListaProdutos.Count == 0)
            {
                UtilidadesGenericas.MsgShow("AVISO ", "A lista encontra-se sem registros", MessageBoxIcon.Information, MessageBoxButtons.OK);

                return;
            }
            UsuariosViewModel usuario = _usuarioApp.GetById(UtilidadesGenericas.UsuarioCodigo);
            ListaProdutos[0].DadosEmpresa = new DadosEmpresaViewModel()
            {
                NomeFuncionario = usuario.Entidade.Nome,
                DataHora = DateTime.Now,
                DocumentoId = codDoc,
                Cambio = "000",
                Moeda = UtilidadesGenericas.Moeda
            };

            ListaProdutos[0].CabecalhoEmpresa = Controle.CabecalhoEmpresa;

            IOC.InjectForm<frmImprimirReport>().ApresentarReportTransferenciaProduto(ListaProdutos);
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (cboDestino.SelectedItem == null)
            {
                UtilidadesGenericas.MsgShow("ERRO ", "Selecione o Armazem de Destino ", MessageBoxIcon.Error, MessageBoxButtons.OK);

                return;
            }
            if (cboDestino.SelectedItem == cboOrigem.SelectedItem)
            {
                UtilidadesGenericas.MsgShow("ERRO ", "Selecione outro Armazem de Destino\nNão pode efectuar transferencia no mesmo armazem", MessageBoxIcon.Error, MessageBoxButtons.OK);

                return;
            }
            else
            {
                buscarProduto();
            }
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnLancar_Enter(object sender, EventArgs e)
        {
            if (!isFieldsValid()) return;
            if (Equals(DocumentoTransferencia, null))
            {
                DocumentoTransferencia = CriarNovoDocumento("TRANSFERENCIA DE ARTIGO", "Transferência de " + cboOrigem.SelectedItem + " para " + cboDestino.SelectedItem);
            }
            codDoc = DocumentoTransferencia.codigo;

            if (decimal.Parse(txtStock.Text) < decimal.Parse(txtQuant.Text))
            {

                //MessageBox.Show("Quantidade é superior ao stock", "AVISO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return ;


                if (MessageBox.Show("Quantidade é superior ao stock, deseja continuar", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                var transferncia = PopulaObjecto();
                transferncia = _transferenciaProdutoApp.Gravar(transferncia);
                var diminuir = GetProdutoArterar();
                _transferenciaProdutoApp.DiminuirStock(diminuir);
                ProdutoAlterarStock();
                MostrarTransferencia();
                Limpar();
            }
        }
    }
}