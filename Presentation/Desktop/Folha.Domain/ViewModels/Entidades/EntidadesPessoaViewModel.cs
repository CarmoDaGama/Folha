using System;

namespace Folha.Domain.ViewModels.Entidades
{
    public class EntidadesPessoaViewModel
    {
        public int CodEntidade { get; set; }
        public string NameKey { get { return "CodEntidade"; } }
        public string ForeignKey { get { return "CodEntidade"; } }
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
        public SexoViewModel Sexo { get; set; } = new SexoViewModel();
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
        public EstadoCivilViewModel EstadoCivil { get; set; } = new EstadoCivilViewModel();
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
        public HabilitacoesViewModel Habilitacao { get; set; } = new HabilitacoesViewModel();
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
        public ProfissaoViewModel Profissao { get; set; } = new ProfissaoViewModel();
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
