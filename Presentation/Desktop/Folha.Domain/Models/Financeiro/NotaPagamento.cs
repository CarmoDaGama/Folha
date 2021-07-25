
using Folha.Domain.Models.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Financeiro
{
    using Folha.Domain.Models.Documentos;
  public  class NotaPagamento : Entity
    {
        public Guid FornecedorID { get; set; }
        public string CodTipoSaida { get; set; }        
        public Documentos Documento { get; set; }
        public string Descricao { get; set; }
        public TipoSaida TipoSaida { get; set; }
        public Moedas Moedas { get; set; }
    }
}
