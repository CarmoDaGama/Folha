using Folha.Domain.ViewModels.Sistema;

namespace Folha.Domain.Models.Inventario
{
    public  class Armazens
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string descricao { get; set; } 
        public Empresa.Empresa CabecalhoEmpresa { get; set; }
    }
}
