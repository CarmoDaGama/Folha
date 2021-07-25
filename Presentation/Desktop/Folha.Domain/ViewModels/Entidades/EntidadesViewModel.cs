using Folha.Domain.Models.Compras;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Models.Genericos;
using Folha.Domain.Models.Vendas;
using Folha.Domain.ViewModels.Genericos;
using Folha.Domain.Enuns.Entidades;
using System.Collections.Generic;


namespace Folha.Domain.ViewModels.Entidades
{
    public  class EntidadesViewModel
    {

        //"Nome", "Nif", "CodTipo", "Limite", "CodPais", "Cliente", "Foto", "status"
        public EntidadesViewModel()
        {
            Contactos = new List<ContactosViewModel>();
            Moradas = new List<MoradaViewModel>();
            Contas = new List<EntidadesContasViewModel>();
            Documentos = new List<DocumentosEntidadeViewModel>();
            Pessoas = new List<EntidadesPessoaViewModel>();
        }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public int Fornecedor { get; set; }
        public int Funcionario { get; set; }
        public int Cliente { get; set; }
        public int CodPais { get; set; }
        public EntidadesPessoaViewModel Pessoa { get; set; } = new EntidadesPessoaViewModel();
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
        public PaisViewModel Nacionalidade { get; set; } = new PaisViewModel();
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
        public int status { get; set; } = 1;
        public int CodTipo { get; set; }
        public TipoEntidadeViewModel Tipo { get; set; } = new TipoEntidadeViewModel();
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
        public int CodCondicaoPagamento { get; set; }
        public CondicoesPagamentosViewModel Condicao { get; set; } = new CondicoesPagamentosViewModel();
        public ForeignKey FKeyCondicao
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "CondicoesPagamentos",
                    NameEntity = "Condicao",
                    NameFieldThis = "CodCondicaoPagamento",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
        public List<ContactosViewModel> Contactos { get; set; }
        public List<MoradaViewModel> Moradas { get; set; }
        public List<EntidadesContasViewModel> Contas { get; set; }
        public List<DocumentosEntidadeViewModel> Documentos { get; set; }
        public List<EntidadesPessoaViewModel> Pessoas { get; set; }
    }
}
