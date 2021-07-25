using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Frame.Inventario
{
    class ArtigoListaViewModel
    {
        public string Armazem { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public float Preco { get; set; }

        public float Qtdade { get; set; }

        public string Familia { get; set; }

        public float StkMin { get; set; }

        public float StkMax { get; set; }

        public bool Controla { get; set; }
        public bool Vender { get; set; }

    }
}
