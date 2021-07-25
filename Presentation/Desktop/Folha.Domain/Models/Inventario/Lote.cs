using Folha.Domain.ViewModels.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Inventario
{
    public class Lote
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataVencimento { get; set; }
        public List<LoteArtigosViewModel> LoteArtigos { get; set; }

    }
}
