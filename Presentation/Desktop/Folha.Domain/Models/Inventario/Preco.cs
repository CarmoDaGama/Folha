using Folha.Domain.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Inventario
{
    public class Preco: Entity
    {
        public Produtos Artigo { get; set; }
        public Moedas Moeda { get; set; }
        public TipoPreco TipoPreco { get; set; }
        public float Valor { get; set; }
    }
}
