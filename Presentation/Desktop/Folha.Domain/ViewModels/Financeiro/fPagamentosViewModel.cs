namespace Folha.Domain.ViewModels.Financeiro
{
   public  class fPagamentosViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string descricao { get; set; }
        public string Movimentar { get; set; }
        public string  CodConta { get; set; }
        public ContasBancariasViewModel Conta { get; set; } = new ContasBancariasViewModel();
        //public string BancoDescricao { get; set; }
        public ForeignKey FKeyConta
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "ContasBancarias",
                    NameEntity = "Conta",
                    NameFieldThis = "CodConta",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public int Sistema { get; set; }
    }
}
