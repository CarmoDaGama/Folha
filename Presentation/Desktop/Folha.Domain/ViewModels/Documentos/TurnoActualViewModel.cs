using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Documentos
{
    public class TurnoActualViewModel
    {
        public int codigo { get; set; }
        public string ESTADO { get; set; }
        public int CODUSUARIO { get; set; }
        public decimal QUEBRA { get; set; }
        public string NOME { get; set; }
        public DateTime ABERTURA { get; set; }
        public DateTime FECHO { get; set; }
        public decimal INICIAL { get; set; }
        public decimal INFORMADO { get; set; }
        public decimal VENDAS { get; set; }
        public decimal HOSPEDAGEM { get; set; }
        public decimal TOTAL { get; set; }


    }
}
