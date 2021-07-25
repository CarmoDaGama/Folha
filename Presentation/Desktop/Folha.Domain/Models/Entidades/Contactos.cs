using Folha.Domain.Enuns.Entidades;

namespace Folha.Domain.Models.Entidades
{
    public  class Contacto
    {
        public int codigo { get; set; }
        public int CodTipoContacto { get; set; }
        public TipoContacto Tipo { get; set; }
        public int CodEntidade { get; set; }
        public Entidades Entidade { get; set; }
        public string descricao { get; set; }

    }
}
