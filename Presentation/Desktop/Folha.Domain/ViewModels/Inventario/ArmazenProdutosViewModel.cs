using Folha.Domain.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Inventario
{
    public class ArmazenProdutosViewModel : ProdutoStock
    {      
      
        public int codigo { get; set; }

        public string Nome { get; set; }
        public decimal quantidade { get; set; }

            public Armazens Armazem { get; set; }

    }
}
