namespace Folha.Domain.ViewModels.Inventario
{
    public  class ArtigoViewModel
    {
        public int codigo { get; set; }
        public int CodProduto { get; set; }
        public ProdutosViewModel Artigo { get; set; }
        public string NomeArtigo { get { return Artigo.descricao; } }
        public decimal Preco { get { return Artigo.preco1; } }
        public string Barra { get { return Artigo.Barra; } }
        public bool Controla { get { return Artigo.movimentaStock == 1; } }
        public bool Vender { get { return Artigo.Vender == 1; } }
        public decimal Custo { get { return Artigo.custo; } }
        public string Familia { get { return Artigo.Familia.descricao; } }
        public string Imposto {
            get {
                var strImposto = "";
                if (Artigo.EntityImposto.Percentagem == 0)
                {
                    strImposto = Artigo.EntityImposto.Percentagem.ToString("N3");
                }
                else
                {
                    strImposto = ((Artigo.EntityImposto.Percentagem / 100) * Artigo.preco1).ToString("N3");
                }
                return strImposto;
            } }
        public string MotivoIsencao { get { return Artigo.MotivoIsencao; } }
        public int CodArmazem { get; set; }
        public ArmazensViewModel Armazem { get; set; }
        public string NomeArmazem { get { return Armazem.descricao; } }
        public decimal qtde { get; set; }
        public decimal stockMin { get; set; }
        public decimal stockMax { get; set; }

        public Folha.Domain.Models.Empresa.Empresa CabecalhoEmpresa { get; set; }

    }
}
