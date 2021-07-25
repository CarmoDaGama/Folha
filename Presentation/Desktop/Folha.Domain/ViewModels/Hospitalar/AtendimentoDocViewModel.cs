using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class AtendimentoDocViewModel
    {
        /*AtendimentoHospitalar.Codigo As Codigo,"+  
                           "AtendimentoHospitalar.Facturado,"+
	                       "AtendimentoHospitalar.Data, "+
                           "AtendimentoHospitalar.Total As TotalAtendimento," +
                           "AtendimentoHospitalar.CodPaciente,"+
                           "Documentos.NumeroOrdem," +
	                       "Documentos.CodUsuario,"+
	                       "Documentos.Estado EstadoDoc,"+
                           "Documentos.Descritivo,"+
	                       "Documentos.Mascara,"+
	                       "Documentos.Total As TotalDocumento
                           "Operacoes.Nome As NomeOperacao,"+
                           "Operacoes.codigo As CodOperacao "*/
        public int Codigo { get; set; }
        public string Facturado { get; set; }
        public string Data { get; set; }
        public decimal TotalAtendimento { get; set; }
        public int CodPaciente { get; set; }
        public string NumeroOrdem { get; set; }
        public int CodUsuario { get; set; }
        public string EstadoDoc { get; set; }
        public string Descritivo { get; set; }
        public string Mascara { get; set; }
        public string TotalDocumento { get; set; }
        public string NomeOperacao { get; set; }
        public int CodOperacao { get; set; }

    }
}
