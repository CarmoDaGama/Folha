using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Hospitalar
{
    public class ExamesHospitalar
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int CodImposto { get; set; }
        public int CodMotivoIsencao { get; set; }
        public int CodSubCategoria { get; set; }
        public double Custo { get; set; }
        public double Preco { get; set; }
        public double Lucro { get; set; }
        public double PrecoVenda { get; set; }
        public byte[] Foto { get; set; }
        public int Status { get; set; }
        public string Facturado { get; set; }

    }
}
