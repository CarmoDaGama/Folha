using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class ExamesViewModel
    {
        public int CodExameAtendimento { get; set; }
        public int CodExame { get; set; }
        public int CodPaciente { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public int CodAtendimento { get; set; }
        public string TipoResultado { get; set; }

        // Novos Dados
        public string Medico { get; set; }
        public string Estado { get; set; }
        public string NumeroProcesso { get; set; }
        public string NumeroAmostra { get; set; }
        public string ViaDocumento { get; set; }
        public string Unidade { get; set; }
        public string VReferencia { get; set; }
         ///

        public DateTime Data { get; set; }
        public int CodImposto { get; set; }
        public int CodMotivoIsencao { get; set; }
        public int CodSubCategoria { get; set; }
        public double Custo { get; set; }
        public double Lucro { get; set; }
        public double PrecoVenda { get; set; }
        public byte[] Foto { get; set; }
        public int Status { get; set; }

        public string Imposto { get; set; }
        public string MotivoIsencao { get; set; }
        public string Percentagem { get; set; }
        public string Facturado { get; set; }
    }
}
