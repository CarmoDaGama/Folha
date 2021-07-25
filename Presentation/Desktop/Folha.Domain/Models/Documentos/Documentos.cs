using Folha.Domain.Models.Entidades;
using Folha.Domain.Models.Inventario;
using Folha.Domain.Models.Restaurante;
using Folha.Domain.Models.Sistema;
using System;
using System.Collections.Generic;

namespace Folha.Domain.Models.Documentos
{
    public  class Documentos
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public int CodOperacao { get; set; }
        public Operacoes Operacao { get; set; } = new Operacoes();
        public ForeignKey FKeyDocumento
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Operacoes",
                    NameEntity = "Operacao",
                    NameFieldThis = "CodOperacao",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public int CodUsuario { get; set; }
        public int CodEntidade { get; set; }
        public int CodTipoDocumento { get; set; }
        public Entidades.Entidades Entidade { get; set; } = new Entidades.Entidades();
        public ForeignKey FKeyEntidade
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Entidades",
                    NameEntity = "Entidade",
                    NameFieldThis = "CodEntidade",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
        public int CodArea { get; set; }
        public int CodMesa { get; set; }
        public int CodTurno { get; set; }
        public string Descritivo { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public int NumeroOrdem { get; set; }
        public string Mascara { get; set; }
        public List<MovProdutos> MovArtigos { get; set; }
    }
}
