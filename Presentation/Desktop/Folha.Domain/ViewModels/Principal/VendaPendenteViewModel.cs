using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Principal
{
    public class VendaPendenteViewModel
    {
        public int Codigo { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Documento { get; set; }
        public string Area { get; set; }
        public string Descricao { get; set; }
        public string Total { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }

    }
}

