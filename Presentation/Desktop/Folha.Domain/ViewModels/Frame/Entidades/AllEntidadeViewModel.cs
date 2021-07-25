using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Frame.Entidades
{
    public class AllEntidadeViewModel
    { 
        public int Codigo { get; set; }
        public string CodTipo { get; set; }
        public string CodSexo { get; set; }
        public string CodPais { get; set; }
        public string Pais { get; set; }
        public string Nome { get; set; }
        public string Nif { get; set; }
        public byte[] Foto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CodEstadoCivil { get; set; }
        public string EstadoCivil { get; set; }
        public string CodProfissao { get; set; }
        public string Profissao { get; set; }
        public string CodHabilitacao { get; set; }
        public string Habilitacao { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string Sexo { get; set; }
        public string Nacionalidade { get; set; }
        public double Limite { get; set; }



    }
}
