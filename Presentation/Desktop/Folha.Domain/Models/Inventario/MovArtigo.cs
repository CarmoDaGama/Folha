using System;

namespace Folha.Domain.Models.Inventario
{
    public class MovArtigo : Entity 
    {
        public Guid DocumentoID { get; set; }
        public Armazens Armazem { get; set; }
        public Produtos Artigo { get; set; }
        public int PercDesconto { get; set; }
        public int PercImposto { get; set; }
        public double Imposto { get; set; }
        public double Desconto { get; set; }
        public double Retencao { get; set; }
    }
}
