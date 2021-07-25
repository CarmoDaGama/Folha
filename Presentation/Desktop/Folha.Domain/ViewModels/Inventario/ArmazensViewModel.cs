using Folha.Domain.ViewModels.Sistema;

namespace Folha.Domain.ViewModels.Inventario
{
    public  class ArmazensViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }

        public string descricao { get; set; } 
    }
}
