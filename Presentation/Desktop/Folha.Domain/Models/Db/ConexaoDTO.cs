using Folha.Domain.Enuns.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Db
{
  public  class ConexaoDTO
    {
        public string Servidor { get; set; }
        public string DataBase { get; set; }
        public int Porta { get; set; }
        public ETipoBancoDados tipoBancoDados { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
