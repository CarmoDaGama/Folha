using Folha.Domain.Models.Documentos;
using Folha.Domain.ViewModels.Documentos;
using System;

namespace Folha.Domain.ViewModels.Financeiro
{
    public class PagamentosViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public int CodDocumento { get; set; }
        public DocumentosViewModel Documento { get; set; } = new DocumentosViewModel();
        public ForeignKey FKeyDocumento
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Documentos",
                    NameEntity = "Documento",
                    NameFieldThis = "CodDocumento",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public String Descricao { get; set; }
        public decimal Valor { get; set; }
        public int CodConta { get; set; }
        public ContasBancariasViewModel Conta { get; set; } = new ContasBancariasViewModel();
        public ForeignKey FKeyConta
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "ContasBancarias",
                    NameEntity = "Conta",
                    NameFieldThis = "CodConta",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public int CodCaixa { get; set; }
        public CaixasViewModel Caixa { get; set; } = new CaixasViewModel();
        public ForeignKey FKeyCaixa
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Caixas",
                    NameEntity = "Caixa",
                    NameFieldThis = "CodCaixa",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        //public string CodTurno {get;set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public int CodMoeda { get; set; }
        public MoedasViewModel Moeda { get; set; } = new MoedasViewModel();
        public ForeignKey FKeyMoeda
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Moedas",
                    NameEntity = "Moeda",
                    NameFieldThis = "CodMoeda",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public int CodCambio { get; set; }
        public CambiosViewModel Cambio { get; set; } = new CambiosViewModel();
        public ForeignKey FKeyCambio
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Cambios",
                    NameEntity = "Cambio",
                    NameFieldThis = "CodCambio",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public int CodForma { get; set; }
        public fPagamentosViewModel Forma { get; set; } = new fPagamentosViewModel();
        public ForeignKey FKeyForma
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "fPagamentos",
                    NameEntity = "Forma",
                    NameFieldThis = "CodForma",
                    NameFieldOrigin = "codigo"
                };
            }
        }

        //---------------------------------------------CAMPOS TEMPORÁRIOS

        public string Tipo { get; set; }
        public int CodTurno { get; set; } 
        public string Estado { get; set; }
        public string Emitido { get; set; } = "Não Imprimido";
        public int NumeroOrdem { get; set; }
    }
}
