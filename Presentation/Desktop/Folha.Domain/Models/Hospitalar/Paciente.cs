using Folha.Domain.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Hospitalar
{
    public class Paciente : EntidadesPessoa
    {
        //public Entidades()
        //{
        //    Contactos = new List<Contacto>();
        //    Moradas = new List<Morada>();
        //    Documentos = new List<DocumentoEntidade>();
        //    Pessoas = new List<EntidadesPessoa>();
        //}
        public int Codigo { get; set; }
        public int CodPessoa { get; set; }
        public int CodGrupoSanguineos { get; set; }
        public int status { get; set; }

       
        public List<Contacto> Contactos { get; set; } = new List<Contacto>();
        public List<Morada> Moradas { get; set; } = new List<Morada>();
        public List<DocumentoEntidade> Documentos { get; set; } = new List<DocumentoEntidade>();
        public List<EntidadesPessoa> Pessoas { get; set; }
    }
}
