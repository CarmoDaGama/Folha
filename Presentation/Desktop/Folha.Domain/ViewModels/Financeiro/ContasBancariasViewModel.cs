namespace Folha.Domain.ViewModels.Financeiro
{
    public   class ContasBancariasViewModel
    {
        public int codigo { get; set; }
        public string Numero { get; set; }
        public string Iban { get; set; }
        public string Natureza { get; set; }
        public string Sequencia { get; set; }
        public string Swift { get; set; }
        public int CodBanco { get; set; }
        public BancosViewModel Banco { get; set; } = new BancosViewModel();
        //public string BancoDescricao { get; set; }
        public ForeignKey FKeyBanco
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Bancos",
                    NameEntity = "Banco",
                    NameFieldThis = "CodBanco",
                    NameFieldOrigin = "codigo"
                };
            }
        }
    }
}
