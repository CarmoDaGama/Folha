using Folha.Domain.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Entidades
{
    public class EntidadeViewModel
    {
        public string Nome { get; set; }
        public EntidadesPessoaViewModel Pessoa { get; set; }
        public string NameSexo { get { return Equals(Pessoa, null)? Pessoa.Sexo.descricao : string.Empty; }  }
        public string NameEstadoCivil { get { return Equals(Pessoa, null) ? Pessoa.EstadoCivil.descricao : string.Empty; } }
        public string Limite { get; set; }
        public byte[] Foto { get; set; }
        public int Codigo { get; set; }
    }
}
