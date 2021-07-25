using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Inventario
{
    public class LoteArtigosViewModel
    {
        public int Codigo { get; set; }
        public int CodProduto { get; set; }
        public int CodLote { get; set; }
        public string Descricao { get; set; }
        public ProdutosViewModel Artigo { get; set; }
    }
}
