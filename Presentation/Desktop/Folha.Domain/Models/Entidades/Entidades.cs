using Folha.Domain.Models.Compras;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Models.Genericos;
using Folha.Domain.Models.Vendas;
using Folha.Domain.Enuns.Entidades;
using System.Collections.Generic;

namespace Folha.Domain.Models.Entidades
{
    public  class Entidades
    {
        //"Nome", "Nif", "CodTipo", "Limite", "CodPais", "Cliente", "Foto", "status"
        public Entidades()
        {
            Contactos = new List<Contacto>();
            Moradas = new List<Morada>();
            Contas = new List<EntidadeConta>();
            Documentos = new List<DocumentoEntidade>();
            Pessoas = new List<EntidadesPessoa>();
        }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public int Fornecedor { get; set; }
        public int Funcionario { get; set; }
        public int Cliente { get; set; }
        public int CodPais { get; set; }
        public EntidadesPessoa Pessoa { get; set; } = new EntidadesPessoa();
        public ForeignKey FKeyPessoa
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "EntidadesPessoa",
                    NameEntity = "Pessoa",
                    NameFieldThis = "Codigo",
                    NameFieldOrigin = "CodEntidade"
                };
            }
        }
        public Pais Nacionalidade { get; set; } = new Pais();
        public ForeignKey FKeyNacionalidade
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Pais",
                    NameEntity = "Nacionalidade",
                    NameFieldThis = "CodPais",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public string Limite { get; set; }
        public byte[] Foto { get; set; }
        public string Nif { get; set; }
        public int status { get; set; }
        public int CodTipo { get; set; }
        public TipoEntidade Tipo { get; set; } = new TipoEntidade();
        public ForeignKey FKeyTipo
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "TipoEntidade",
                    NameEntity = "Tipo",
                    NameFieldThis = "CodTipo",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public int GetCodTipo()
        {
            return Tipo.codigo;
        }
        public List<Contacto> Contactos { get; set; } = new List<Contacto>();
        public List<Morada> Moradas { get; set; } = new List<Morada>();
        public List<EntidadeConta> Contas { get; set; }
        public List<DocumentoEntidade> Documentos { get; set; } = new List<DocumentoEntidade>();
        public List<EntidadesPessoa> Pessoas { get; set; }
    }
}
