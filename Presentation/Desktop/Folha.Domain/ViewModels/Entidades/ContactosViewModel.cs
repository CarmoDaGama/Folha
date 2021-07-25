using Folha.Domain.Enuns.Entidades;

namespace Folha.Domain.ViewModels.Entidades
{
    public  class ContactosViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public int CodTipoContacto { get; set; }
        public TipoContactoViewModel Tipo { get; set; } = new TipoContactoViewModel();
        public ForeignKey FKEntidade
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "TipoContacto",
                    NameEntity = "Tipo",
                    NameFieldOrigin = "codigo",
                    NameFieldThis = "CodTipoContacto"
                };
            }
        }
        public int CodEntidade { get; set; }
        public string descricao { get; set; }

    }
}
