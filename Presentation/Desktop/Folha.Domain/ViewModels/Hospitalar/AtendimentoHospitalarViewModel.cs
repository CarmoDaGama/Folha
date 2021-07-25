using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class AtendimentoHospitalarViewModel
    {
        public int Codigo { get; set; }
        public int CodPaciente { get; set; }
        public int CodEntidade { get; set; }
        public string Nome { get; set; }
        public string TipoConsulta { get; set; }
        public string Facturado { get; set; }
        public double Total { get; set; }
        public DateTime Data { get; set; }
    }
}
