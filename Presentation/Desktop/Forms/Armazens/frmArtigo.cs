using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Armazens;
using Folha.Presentation.Desktop.Forms.Entidades;
using Folha.Presentation.Desktop.Separadores.Principal;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Separadores.Armazens
{
    public partial class frmCadastroProdutos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IArtigosApp _ArtigosApp;
        private readonly IArmazemApp _ArmazemApp;
        private readonly IArtigoStockApp _stockApp;
        private bool Changed { get; set; } = false;

        private int codCategoria;
        private int codImposto;
        private int codFornecedores;
        private int codComposicao;
        private int codSubistituto;
        private int indexArmazem;
        private int indexArmazens = -1;

        private int codDeleteArmazem;
        private int codDeleteFornecedor;
        private int codDeleteSubist;
        private int codDeleteComposi;

        public List<Domain.Models.Inventario.Armazens> MostarArmazens { get; private set; }
        private ProdutosViewModel Entity { get; set; }
        public int Id { get; private set; }
        public decimal Minimo { get; private set; }
        public decimal Maximo { get; private set; }
        public int IndexArmazenEditado { get; private set; }

       
        public decimal codQuantidade;

        private List<ArmazenProdutosViewModel> listaArmazens;
        private List<SubistitutoViewModel> listaSubistituto;
        private List<FornecedorProdutosViewModel> listaFornecedores;
        private List<ComposicaoProdutosViewModel> listaComposicao;
        private Artigo artigo;
        private int indexDCompo;
        private int indexDForne;
        private int indexDSub;
        private int indexDArm;

        public frmCadastroProdutos(IArtigosApp ArtigosApp, IArmazemApp ArmazemApp, IArtigoStockApp stockApp)
        {
            InitializeComponent();
            Renderizar();
            _ArtigosApp = ArtigosApp;
            _ArmazemApp = ArmazemApp;
            _stockApp = stockApp;
           
        }
        public bool ChamarComAlt()
        {
            ShowDialog();
            return Changed;
        }
        #region Design e chamar Separadores
   
        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }   
       
        public void Renderizar()
        {
           var largura = panelRenderizar.Width / 3 + 2;
            panelPreco1.Size = new Size(largura, panelPreco1.Height);
            panelPreco2.Size = new Size(largura, panelPreco2.Height);
            panelPreco3.Size = new Size(largura, panelPreco3.Height);
        }
        #endregion
        #region INSERIR DADOS NAS LISTAS 
        private void btnNovoComposicao_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmBuscaArtigos>();
            var composicao  = form.GetArtigo();
            
            if ((Equals(composicao, null) || Equals(composicao.codigo, 0)))
            {
                return;
            }
            codComposicao = composicao.Artigo.Codigo;

            if (Equals(listaComposicao, null))
            {
                listaComposicao = new List<ComposicaoProdutosViewModel>();
            }
            var newlistaComposicao = (new ComposicaoProdutosViewModel()
            {
                CodArtigoComponente = composicao.CodProduto,
                Produtos = composicao.Artigo,
                Nome = composicao.Artigo.descricao,
                Qtde = UtilidadesGenericas.Busca.QuantidadeNova
            });
            if (listaComposicao.Count > 0 && ContemNaListasComposicao(newlistaComposicao.CodArtigoComponente))
            {
                UtilidadesGenericas.MsgShow( 
                    "Erro ao Adicionar Composição", 
                    "Este Produto Já está Adicionado",
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK
                );
                return;
            }
            listaComposicao.Add(newlistaComposicao);
            gradeComposicao.DataSource = null;
            gradeComposicao.DataSource = listaComposicao;
        }
        private void btnNovoSubstituto_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmBuscaArtigos>();
            var Subistituto = form.GetArtigo();
            if ((Equals(Subistituto, null) || Equals(Subistituto.codigo, 0)))
            {
                return;
            }
            codSubistituto = Subistituto.Artigo.Codigo;
            if (Equals(listaSubistituto, null))
            {
                listaSubistituto = new List<SubistitutoViewModel>();
            }
            var newlistaSub = (new SubistitutoViewModel()
            {
                CodigoSubstituto = Subistituto.Artigo.Codigo,
                Produtos = Subistituto.Artigo,
                Nome = Subistituto.Artigo.descricao,
            });
            if (listaSubistituto.Count > 0 && ContemNaListasSub(newlistaSub.CodigoSubstituto))
            {

                UtilidadesGenericas.MsgShow(
                    "Erro ao Adicionar Substituto", 
                    "Este Produto Já está Adicionado",
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK
                );

                return;
            }
            listaSubistituto.Add(newlistaSub);
            gradeSubistituto.DataSource = null;
            gradeSubistituto.DataSource = listaSubistituto;            
        }
        private void btnInserirArmzem_Click(object sender, EventArgs e)
        {
            Minimo = decimal.Parse(txtstockmin.Text);
            Maximo = decimal.Parse(txtstockmax.Text);
            if (cboArmazem.SelectedItem == null)
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO",
                    "Escolha um armazem", 
                    MessageBoxIcon.Error, 
                    MessageBoxButtons.OK);
                return;
            }
            if (cboArmazem.Properties.Items.Count == 0)
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO", 
                    "Não Existe Armazens Disponiveis", 
                    MessageBoxIcon.Error, 
                    MessageBoxButtons.OK
                );
                return;
            }
            if (string.IsNullOrEmpty(cboArmazem.SelectedItem.ToString()))
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO",
                    "Escolha um Armazem",
                    MessageBoxIcon.Error, 
                    MessageBoxButtons.OK
                );
                return;
            }

            if (Minimo > Maximo || Minimo == Maximo)
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO", 
                    "A quantidade minima não pode ser superior ou igual",
                    MessageBoxIcon.Error, 
                    MessageBoxButtons.OK);

                return;
            }
           
            if (Equals(listaArmazens, null))
            {
                listaArmazens = new List<ArmazenProdutosViewModel>();
            }
            var newArtigoStock = new ArmazenProdutosViewModel()
            {
                CodArmazem = MostarArmazens[indexArmazem].codigo,
                Armazem = MostarArmazens[indexArmazem],
                StockMin = Minimo,
                StockMax = Maximo,
                quantidade = 0,
                Nome = MostarArmazens[indexArmazem].descricao
            };
            if (listaArmazens.Count > 0 && ContemNaListasArmzem(newArtigoStock.CodArmazem))
            {
                UtilidadesGenericas.MsgShow(
                    "Erro ao Adicionar Armazem",
                    "Este Armazem Já está Adicionado", 
                    MessageBoxIcon.Error, 
                    MessageBoxButtons.OK
                );
                return;
            }
            listaArmazens.Add(newArtigoStock);
            gradeArmazem.DataSource = null;
            gradeArmazem.DataSource = listaArmazens;
        }
        private void btnNovoFornecedor_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmFornecedorBusca>();
            var Fornecedores = form.GetForneccedorSelecionado();  
            if (Equals(Fornecedores.Codigo, 0) || Equals(Fornecedores.Codigo, null))
            {
                return;
            }
            codFornecedores = Fornecedores.Codigo;
            if (Equals(listaFornecedores, null))
            {
                listaFornecedores = new List<FornecedorProdutosViewModel>();
            }

            var newFornecedor = (new FornecedorProdutosViewModel()
            {
               CodFornecedor = Fornecedores.Codigo,
               Fornecedor = Fornecedores,
               Nome = Fornecedores.Nome,
               Custo = 0,

            });
            if (listaFornecedores.Count > 0 && ContemNaListasFornecedor(newFornecedor.CodFornecedor))
            {
                UtilidadesGenericas.MsgShow(
                    "Erro ao Adicionar Fornecedor", 
                    "Este Fornecedor Já está Adicionado",
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK
                );
                return;
            }
            if (listaFornecedores.Count == 1)
            {
                UtilidadesGenericas.MsgShow(
                    "Erro ao Adicionar Fornecedor",
                    "Já está Adicionado um Fornecedor ", 
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK
                );
                return;
            }
            listaFornecedores.Add(newFornecedor);
            gradeFornecedor.DataSource = null;
            gradeFornecedor.DataSource = listaFornecedores;
        }
        #endregion
        #region APAGAR OU ELIMINAR DA GRID
        #endregion
        #region VALIDAÇÃO
        private void messageShow(string message)
        {
            UtilidadesGenericas.MsgShow(
                "AVISO",
                message,
                MessageBoxIcon.Error,
                MessageBoxButtons.OK
            );
        }
        private bool isCbo(Control item)
        {
            return item.GetType().Name.Contains("ComboBoxEdit");
        }
        private bool isFieldsValid()
        {
            bool valid = true;
            if (txtDescricao.Text.Equals(string.Empty))
            {
                messageShow("Preencha o campo Descrição");
                return false;
            }

            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("descricao", txtDescricao.Text);
            if (txtCodigo.Text == "" && _ArtigosApp.VerificarDup("Produtos", d))
            {
                messageShow("Já Existe essa Artigo Verifica nos Registros ");
                return false;
            }

            if (txtFamila.Text.Equals(string.Empty))
            {
                messageShow("Escolha uma Familia");
                return false;
            }
            if (txtPreco1.Text.Equals(string.Empty))
            {
                messageShow("Adicionar um Preço");
                return false;
            }
            if (txtImposto.Text.Equals(string.Empty))
            {
                messageShow("Escolha um Imposto");
                return false;
            }
            if (txtImposto.Text == "Isento" && txtMotivoIsencao.Text == "")
            {
                messageShow("Escolha um Motivo de isencão");
                return false;
            }
            if (txtPreco1.Text.Equals(string.Empty))
            {
                messageShow("Escolha um Preco");
                return false;
            }
            if (Equals(listaArmazens, null) || listaArmazens.Count == 0)
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO",
                    "Adicina um ou mais Armazem de origem",
                    MessageBoxIcon.Error, 
                    MessageBoxButtons.OK
                );
                return false;
            }
            
            return valid;
        }
        private bool ContemNaListasArmzem(int armazemId)
        {
            return listaArmazens.Where(a => a.CodArmazem == armazemId).FirstOrDefault() != null;
            
        }
        private bool ContemNaListasSub(int subId)
        {
            return listaSubistituto.Where(a => a.CodigoSubstituto == subId).FirstOrDefault() != null;

        }
        private bool ContemNaListasComposicao(int CompoID)
        {
            return listaComposicao.Where(a => a.CodArtigoComponente == CompoID).FirstOrDefault() != null;

        }
        private bool ContemNaListasFornecedor(int FornecedorID)
        {
            return listaFornecedores.Where(a => a.CodFornecedor == FornecedorID).FirstOrDefault() != null;

        }
        #endregion
        private void frmCadastroProdutos_Load(object sender, EventArgs e)
        {
            caregarCboArm();
            cboArmazem.SelectedIndex = 0;
            if(!string.IsNullOrEmpty(UtilidadesGenericas.Busca.Codigo))
            {
                txtCodigo.Text = UtilidadesGenericas.Busca.Codigo;
                int Codigo = int.Parse(txtCodigo.Text);
                var artigo = _ArtigosApp.GetById(Codigo);
                if (Codigo > 0) PopularDadosArtigoEditar(Codigo);
            }
            Update();
            Renderizar();
        }
        private Artigo PopulaObjecto()
        {
            int movimentaR = 0;
            int vendeR = 0;

            

            if (cboTipoStock.SelectedItem == "Movimentar")
            {
                movimentaR = 1;
            }
            else if (cboTipoStock.SelectedItem == "Não Movimentar")
            {
                movimentaR = 0;
            }

            if (cboPermitirVenda.SelectedItem == "Sim")
            {
                vendeR = 1;
            }
            else if (cboPermitirVenda.SelectedItem == "Não")
            {
                vendeR = 0;
            }
            
            byte[] logotipo = new byte[1];
            if (PicImagem.Image != null) logotipo =Imagens.Imagem_Byte(PicImagem.Image);
            artigo = new Artigo()
            {
                Barra = txtBarra.Text,
                Descricao = txtDescricao.Text,
                movimentaStock = movimentaR,
                Vender = vendeR,
                Imagem = logotipo,
                Codcategoria = codCategoria,
                MotivoIsencao = txtMotivoIsencao.Text,
                CodImposto = codImposto,
                Custo = decimal.Parse(txtCusto.Text),
                Preco1 = decimal.Parse(txtPreco1.Text),
                Preco2 = decimal.Parse(txtPreco2.Text),
                Preco3 = decimal.Parse(txtPreco3.Text),
                Retencao = decimal.Parse(txtRetencao.Text),
                Data_fabrico = null,
                Data_validade = null,
                status = 1,
                Armazens = new List<ProdutoStock>(),
                Fornecedores = new List<FornecedorProdutosViewModel>(),
                Substitutos = new List<SubistitutoViewModel>(),
                Composicao = new List<ComposicaoProdutosViewModel>()               
            };
            

            if (!string.IsNullOrEmpty(txtCodigo.Text)) artigo.Codigo = int.Parse(txtCodigo.Text);
            var registo = listaArmazens;
            for (int i = 0; i < gridArmazem.RowCount; i++)
            {
                var arm = new ProdutoStock()
                {
                    CodArmazem = listaArmazens[i].CodArmazem,
                    StockMax = listaArmazens[i].StockMax,
                    StockMin = listaArmazens[i].StockMin,
                    Codigo = listaArmazens[i].Codigo,
                };

                if (listaArmazens[i].Artigo != null)
                {
                    arm.CodProduto = listaArmazens[i].Artigo.Codigo;
                }
                artigo.Armazens.Add(arm);
            }
            artigo.Substitutos = null;
            artigo.Substitutos = listaSubistituto;
            artigo.Composicao = null;
            artigo.Composicao = listaComposicao;
            artigo.Fornecedores = null;
            artigo.Fornecedores = listaFornecedores;
            return artigo;
        }
        private void PopularDadosArtigoEditar(int Codigo)
        {
            if (Codigo == 0) return;
            Id = Codigo;
            Entity = _ArtigosApp.GetById(Codigo);
            txtBarra.Text = Entity.Barra;
            txtDescricao.Text = Entity.descricao;

            cboTipoStock.SelectedIndex  = Entity.movimentaStock;
            cboPermitirVenda.SelectedIndex = Entity.Vender;

            if (cboTipoStock.SelectedIndex == 1)
            {
                cboTipoStock.SelectedIndex = 0;
            }
            else if(cboTipoStock.SelectedIndex == 0)
            {
                cboTipoStock.SelectedIndex = 1;
            }

            if (cboPermitirVenda.SelectedIndex == 1)
            {
                cboPermitirVenda.SelectedIndex = 0;
            }
            else if (cboPermitirVenda.SelectedIndex == 0)
            {
                cboPermitirVenda.SelectedIndex = 1;
            }
            
            PicImagem.Image = Imagens.Byte_Imagem(Entity.Imagem);
            txtFamila.Text =  Entity.Familia.descricao;
            codCategoria = Entity.Codcategoria;
            txtImposto.Text = Entity.EntityImposto.Descricao;
            codImposto = Entity.CodImposto;
            txtMotivoIsencao.Text = Entity.MotivoIsencao;
            txtCusto.Text = Entity.custo.ToString("N3");
            txtPreco1.Text = Entity.preco1.ToString("N3");
            txtPreco2.Text = Entity.preco2.ToString("N3");
            txtPreco3.Text = Entity.preco1.ToString("N3");
            txtRetencao.Text = Entity.Retencao.ToString("N3");
            gradeArmazem.DataSource = listaArmazens = _ArtigosApp.GetArmazens(Codigo);
            gradeFornecedor.DataSource = listaFornecedores = _ArtigosApp.GetFornecedores(Codigo);
            gradeSubistituto.DataSource = listaSubistituto = _ArtigosApp.GetSubstitutos(Codigo);
            gradeComposicao.DataSource = listaComposicao = _ArtigosApp.GetComposicao(Codigo);
        }
        private void btnSalve_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            var artigo = PopulaObjecto();
            artigo = _ArtigosApp.Gravar(artigo);
            PopularDadosArtigoEditar(artigo.Codigo);
            txtCodigo.Text = artigo.Codigo.ToString();
            UtilidadesGenericas.Busca.Alterou = true;
        }
        private void btnBuscaCategoria_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmCategorias>();
            form.btnselect.Visibility = BarItemVisibility.Always;

            var categoria = form.GetCategoria();
            if (Equals(categoria, null) )
            {
                return;
            }
            else
            {
                codCategoria = categoria.codigo;
                txtFamila.Text = categoria.descricao;
            }
         }
        public void caregarCboArm()
       {
            MostarArmazens = (List<Domain.Models.Inventario.Armazens>)_ArmazemApp.Listar(null, false);
            cboArmazem.SelectedIndex = cboArmazem.Properties.Items.Count + 0;
            foreach (var item in MostarArmazens)cboArmazem.Properties.Items.Add(item.descricao);
        }
        private void cboArmazem_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexArmazem = cboArmazem.SelectedIndex;
        } 
        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            var artigo = PopulaObjecto();
            artigo = _ArtigosApp.Gravar(artigo);
            PopularDadosArtigoEditar(artigo.Codigo);
            txtCodigo.Text = artigo.Codigo.ToString();
            UtilidadesGenericas.Busca.Alterou = true;

            frmVerProdutos chamada = IOC.InjectForm<frmVerProdutos>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
        }
        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            //navigationFrame1.SelectedPage = navigationRentacao;
        }
        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmVerProdutos chamada = IOC.InjectForm<frmVerProdutos>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
        }     
        private void btnImposto_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmImpostos>();
            form.btnselect.Visibility = BarItemVisibility.Always;
            
            var imposto = form.GetImposto();
            if (Equals(imposto, null))
            {
                return;
            }
            codImposto = imposto.Codigo;
            txtImposto.Text = imposto.Descricao;

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
        private void btnMotivoIsencao_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmMotivoIsencao>();
            var motivoIsencao = form.GetMotivoIsencao();
            if (Equals(motivoIsencao, null)) { return; }
            txtMotivoIsencao.Text = motivoIsencao.Descricao;
        }
        private void btnImprimir_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (codDeleteSubist>0)
            {
                _ArtigosApp.DeleteSubstituto(new SubistitutoViewModel()
                {
                    Codigo = codDeleteSubist,
                });
                UtilidadesGenericas.MsgShow(
                    "AVISO",
                    "Registro excluído ",
                    MessageBoxIcon.Information,
                    MessageBoxButtons.OK
                );

                gradeSubistituto.DataSource = null;
                gradeSubistituto.DataSource = listaSubistituto;
                gradeSubistituto.DataSource = listaSubistituto = _ArtigosApp.GetSubstitutos(Id);
            }
            else
            {
                listaSubistituto.RemoveAt(indexDSub);
                gradeSubistituto.DataSource = null;
                gradeSubistituto.DataSource = listaSubistituto;
                UtilidadesGenericas.MsgShow(
                    "AVISO", 
                    "Registro excluído ", 
                    MessageBoxIcon.Information,
                    MessageBoxButtons.OK
                );

            }
        }
        private void btnDeleteForneced_Click(object sender, EventArgs e)
        {
            if (codDeleteFornecedor > 0)
            {
                _ArtigosApp.DeleteFornecedor(new FornecedorProdutosViewModel()
                {
                    Codigo = codDeleteFornecedor,
                });
                UtilidadesGenericas.MsgShow(
                    "AVISO", 
                    "Registro excluído ", 
                    MessageBoxIcon.Information, 
                    MessageBoxButtons.OK
                );

                gradeFornecedor.DataSource = null;
                gradeFornecedor.DataSource = listaFornecedores;
                gradeFornecedor.DataSource = listaFornecedores = _ArtigosApp.GetFornecedores(Id);
            }
            else
            {
                listaFornecedores.RemoveAt(indexDForne);
                gradeFornecedor.DataSource = null;
                gradeFornecedor.DataSource = listaFornecedores;
                UtilidadesGenericas.MsgShow(
                    "AVISO",
                    "Registro excluído ", 
                    MessageBoxIcon.Information, 
                    MessageBoxButtons.OK
                );

            }
        }
        private void btnDeletCompo_Click(object sender, EventArgs e)
        {
            if (codDeleteComposi > 0)
            {
            _ArtigosApp.DeleteComposicao(new ComposicaoProdutosViewModel()
            {
                Codigo = codDeleteComposi,
            });
            UtilidadesGenericas.MsgShow(
                "AVISO",
                "Registro excluído ",
                MessageBoxIcon.Information,
                MessageBoxButtons.OK
            );
            gradeComposicao.DataSource = null;
            gradeComposicao.DataSource = listaComposicao;
            gradeComposicao.DataSource = listaComposicao = _ArtigosApp.GetComposicao(Id);

            }
            else
            {
               
                listaComposicao.RemoveAt(indexDCompo);
                gradeComposicao.DataSource = null;
                gradeComposicao.DataSource = listaComposicao;
                UtilidadesGenericas.MsgShow(
                    "AVISO", 
                    "Registro excluído ",
                    MessageBoxIcon.Information,
                    MessageBoxButtons.OK
                );

            }
        }
        private void btnEliminarArmzem_Click(object sender, EventArgs e)
        {
           
                if (codDeleteArmazem > 0)
                {
                    if (codQuantidade == 0)
                    {
                        _ArtigosApp.DeleteArmazem(new ArmazenProdutosViewModel()
                        {
                            Codigo = codDeleteArmazem,
                        });
                        UtilidadesGenericas.MsgShow(
                            "AVISO",
                            "Registro excluído ", 
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK
                        );

                        gradeArmazem.DataSource = null;
                        gradeArmazem.DataSource = listaArmazens;
                        gradeArmazem.DataSource = listaArmazens = _ArtigosApp.GetArmazens(Id);

                    }
                    else
                    {
                        UtilidadesGenericas.MsgShow(
                            "AVISO",
                            "Já Ouvi Alteração no Stock",
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK
                        );
                    }
                }
                else
                {
                    listaArmazens.RemoveAt(indexDArm);
                    gradeArmazem.DataSource = null;
                    gradeArmazem.DataSource = listaArmazens;
                    UtilidadesGenericas.MsgShow(
                        "AVISO", 
                        "Registro excluído ",
                        MessageBoxIcon.Information, 
                        MessageBoxButtons.OK
                    );

                }
            
           
        }
        private void GridSubstituto_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexDSub = e.RowHandle;
            codDeleteSubist = listaSubistituto[e.RowHandle].Codigo;
        }
        private void gridArmazem_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
          indexDArm = e.RowHandle;
          codDeleteArmazem = listaArmazens[e.RowHandle].Codigo;
          codQuantidade = listaArmazens[e.RowHandle].quantidade;
          IndexArmazenEditado = e.RowHandle;
        }
        private void GridFornecedores_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexDForne= e.RowHandle;
            codDeleteFornecedor = listaFornecedores[e.RowHandle].Codigo;
        }
        private void GridComposicao_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexDCompo = e.RowHandle;
            codDeleteComposi = listaComposicao[e.RowHandle].Codigo;
        }
        

        private void gridArmazem_DoubleClick(object sender, EventArgs e)
        {
            UtilidadesGenericas.Busca.Alterou = false;
            UtilidadesGenericas.Busca.QuantidadeMAx = "";
            UtilidadesGenericas.Busca.QuantidadeMin = "";
            UtilidadesGenericas.Busca.CodNovoArmazem = "";

            if (IndexArmazenEditado <= -1)
            { return; }

            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (codDeleteArmazem > 0)
            {
                UtilidadesGenericas.Busca.QuantidadeMAx = gridArmazem.GetRowCellValue(info.RowHandle, "StockMax").ToString();
                UtilidadesGenericas.Busca.QuantidadeMin = gridArmazem.GetRowCellValue(info.RowHandle, "StockMin").ToString();
                UtilidadesGenericas.Busca.CodNovoArmazem = gridArmazem.GetRowCellValue(info.RowHandle, "Codigo").ToString();
                var form = IOC.InjectForm<FrmEditArmazens>();
                form.ShowDialog();
                if (UtilidadesGenericas.Busca.Alterou == true) gradeArmazem.DataSource = listaArmazens = _ArtigosApp.GetArmazens(int.Parse(txtCodigo.Text));

            }
            else
            {
                return;

            }

        }

        private void txtFamila_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void txtMotivoIsencao_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtImposto_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void tabNavigationPage4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtMotivoIsencao_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtFamila_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmCategorias>();
            form.btnselect.Visibility = BarItemVisibility.Always;

            var categoria = form.GetCategoria();
            if (Equals(categoria, null))
            {
                return;
            }
            else
            {
                codCategoria = categoria.codigo;
                txtFamila.Text = categoria.descricao;
            }
        }

        private void txtImposto_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmImpostos>();
            form.btnselect.Visibility = BarItemVisibility.Always;

            var imposto = form.GetImposto();
            if (Equals(imposto, null))
            {
                return;
            }
            codImposto = imposto.Codigo;
            txtImposto.Text = imposto.Descricao;

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

        private void txtMotivoIsencao_Click(object sender, EventArgs e)
        {
            if (codImposto == 1)
            {
                var form = IOC.InjectForm<frmMotivoIsencao>();
                var motivoIsencao = form.GetMotivoIsencao();
                if (Equals(motivoIsencao, null)) { return; }
                txtMotivoIsencao.Text = motivoIsencao.Descricao;
            }
            else
            {
                btnMotivoIsencao.Enabled = false;
                txtMotivoIsencao.Text = "";
            }

        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}