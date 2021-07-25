using Enterprise.Domain.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Domain.ViewModels.Inventarios
{
    public class CardCategoriaViewModel
    {
        public int codigo { get; set; }
        public string descricao { get; set; }
        public byte[] Imagem { get; set; }
    }
}
