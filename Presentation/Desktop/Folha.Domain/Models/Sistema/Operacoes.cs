using Folha.Domain.Enuns.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Sistema
{
  public  class Operacoes
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string Nome { get; set; }
        public string MovStk { get; set; }
        public string MovFin { get; set; }
        public string APP { get; set; }
        public string Entidade { get; set; }
        public int Sistema { get; set; }
        public int Pos { get; set; }
        public int Hotel { get; set; }
        public int Restaurante { get; set; }
        public int Escolar { get; set; }
        public int Hospitalar { get; set; }
        public int Pt { get; set; }
        public int Cyber { get; set; }
        public int Rh { get; set; }
        public int LAV { get; set; }
        public int Viagem { get; set; }
    }
}
