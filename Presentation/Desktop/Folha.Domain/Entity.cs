using System;

namespace Folha.Domain
{
    public class Entity
    {
        public int Codigo { get; set; }
        public Guid ID { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAltecao { get; set; }
        public int UsuarioID { get; set; }
        public Guid AlteradoPor { get; set; }
        public string Nome { get; set; }
        public string Tabela { get; set; }
    }
}
