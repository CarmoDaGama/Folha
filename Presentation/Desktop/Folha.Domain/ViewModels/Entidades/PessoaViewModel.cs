using System;

namespace Folha.Domain.ViewModels.Entidades
{
    public class PessoaViewModel
    {
        public int CodEntidade { get; set; }
        public EntidadesViewModel Entidade { get; set; }
        public string NomeEntidade { get { return Entidade.Nome; } }
        public int CodSexo { get; set; }
        public SexoViewModel Sexo { get; set; }
        public string strSexo { get { return Sexo.descricao; } }
        public int CodEstadoCivil { get; set; }
        public EstadoCivilViewModel EstadoCivil { get; set; }
        public string strEstadoCivil { get { return EstadoCivil.descricao; } }
        public DateTime DataNascimento { get; set; }
        public int CodHabilitacao { get; set; }
        public HabilitacoesViewModel Habilitacao { get; set; }
        public string strHabilitacao { get { return Habilitacao.Descricao; } }
        public int CodProfissao { get; set; }
        public ProfissaoViewModel Profissao { get; set; }
        public string strProfissao { get { return Profissao.Descricao; } }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
    }
}
