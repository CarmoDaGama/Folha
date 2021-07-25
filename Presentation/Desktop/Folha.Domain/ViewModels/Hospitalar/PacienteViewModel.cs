using Folha.Domain.Models.Entidades;
using Folha.Domain.Models.Genericos;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class PacienteViewModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public EntidadesPessoa Pessoa { get; set; }
        public int CodEntidade { get; set; }
        public string Nif { get; set; }
        public byte[] Foto { get; set; }
        public string Sexo { get; set; }
        public int CodEstadoCivil { get; set; }
        public DateTime DataNascimento { get; set; }
        public string EstadoCivil { get; set; }
        public int CodProfissao { get; set; }
        public string Profissao { get; set; }
        public int CodHabilitacao { get; set; }
        public string Habilitacoes { get; set; }
        public string Pai { get; set; }
        public string Mae { get; set; }
        public Pais Nacionalidade { get; set; }
        public string Pais { get; set; }

        public GrupoSanguineos GrupoSanguineo { get; set; }
        public string Descricao { get; set; }
        public string CodGrupoSanguineos { get; set; }
        public string status { get; set; }
        public string Contacto1 { get; set; }
        public string Contacto2 { get; set; }
        public string Morada { get; set; }

    }
}
