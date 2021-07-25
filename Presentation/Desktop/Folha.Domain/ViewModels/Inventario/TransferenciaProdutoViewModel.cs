using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.ViewModels.Empresa;
using Folha.Domain.ViewModels.Sistema;

namespace Folha.Domain.ViewModels.Inventario
{
    public class TransferenciaProdutoViewModel
    {
        #region Configuração

        public ForeignKey FkDocumento
        {
            get
            {
                return new ForeignKey()
                {
                    NameEntity = "Documento",
                    NameFieldOrigin = "Codigo",
                    NameFieldThis = "CodDocumento",
                    NameTable = "Documentos"
                };
            }
        }
        public ForeignKey FkProduto
        {
            get
            {
                return new ForeignKey()
                {
                    NameEntity = "Produto",
                    NameFieldOrigin = "Codigo",
                    NameFieldThis = "CodProduto",
                    NameTable = "Produtos"
                };
            }
        }

        #endregion

        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public int CodDocumento { get; set; }
        public string Descricao { get; set; }
        public DadosEmpresaViewModel DadosEmpresa { get; set; }
        public Folha.Domain.Models.Empresa.Empresa CabecalhoEmpresa { get; set; }

        public DocumentosViewModel Documento { get; set; } = new DocumentosViewModel();
        public int CodProduto { get; set; }
        public ProdutosViewModel Produto { get; set; } = new ProdutosViewModel();
        public decimal Quantidade { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public int CodOrigem { get; set; }
        public int CodDestino { get; set; }
        public int CodStock { get; set; }
        public decimal Preco { get; set; }
        public decimal Custo { get; set; }
    }
}
