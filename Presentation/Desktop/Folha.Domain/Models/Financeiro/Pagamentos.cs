using Folha.Domain.Models.Documentos;
using System;

namespace Folha.Domain.Models.Financeiro
{
    public class Pagamentos
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public int CodDocumento { get; set; }
        public Documentos.Documentos Documento { get; set; } = new Documentos.Documentos();
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
        public ContasBancarias Conta { get; set; } = new ContasBancarias();
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
        public Caixas Caixa { get; set; } = new Caixas();
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
        public Moedas Moeda { get; set; } = new Moedas();
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
        public Cambio Cambio { get; set; } = new Cambio();
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
        public fPagamentos Forma { get; set; } = new fPagamentos();
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


        /////////////////// campos para internamnto
        public string NomeDocumento { get; set; }
        public string NomeMoeda{ get; set; }

    }


    //
}
