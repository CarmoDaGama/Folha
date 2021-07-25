using System;

namespace Folha.Domain.Models.Entidades
{
    public class EntidadesPessoa
    {
        public int CodEntidade { get; set; }
        public string NameKey { get { return "CodEntidade"; } }
        /*public Entidades Entidade { get; set; }
        public ForeignKey FKEntidade {
            get {
                return new ForeignKey()
                {
                    NameTable= "Entidades",
                    NameEntity = "Entidade",
                    NameFieldOrigin = "Codigo",
                    NameFieldThis = "CodEntidade"
                };
            }
        }*/
        public int CodSexo { get; set; }
        public Sexo Sexo { get; set; } = new Sexo();
        public ForeignKey FKSexo
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Sexo",
                    NameEntity = "Sexo",
                    NameFieldOrigin = "codigo",
                    NameFieldThis = "CodSexo"
                };
            }
        }
        public int CodEstadoCivil { get; set; }
        public EstadoCivil EstadoCivil { get; set; } = new EstadoCivil();
        public ForeignKey FKEstadoCivil
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "EstadoCivil",
                    NameEntity = "EstadoCivil",
                    NameFieldOrigin = "codigo",
                    NameFieldThis = "CodEstadoCivil"
                };
            }
        }
        public string  DataNascimento { get; set; }
        public int CodHabilitacao { get; set; }
        public Habilitacoes Habilitacao { get; set; } = new Habilitacoes();
        public ForeignKey FKHabilitacao
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Habilitacoes",
                    NameEntity = "Habilitacao",
                    NameFieldOrigin = "Codigo",
                    NameFieldThis = "CodHabilitacao"
                };
            }
        }
        public int CodProfissao { get; set; }
        public Profissao Profissao { get; set; } = new Profissao();
        public ForeignKey FKProfissao
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Profissao",
                    NameEntity = "Profissao",
                    NameFieldOrigin = "Codigo",
                    NameFieldThis = "CodProfissao"
                };
            }
        }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }

    }
}
