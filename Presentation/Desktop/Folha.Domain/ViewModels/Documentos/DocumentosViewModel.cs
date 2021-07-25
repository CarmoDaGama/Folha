using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.ViewModels.Sistema;
using Folha.Domain.Helpers;
using System;
using System.Collections.Generic;

namespace Folha.Domain.ViewModels.Documentos
{
    public class DocumentosViewModel
    {

        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public int CodOperacao { get; set; }
        public OperacoesViewModel Operacao { get; set; } = new OperacoesViewModel();
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
        public int CodEntidade { get; set; }
        public EntidadesViewModel Entidade { get; set; } = new EntidadesViewModel();
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
        public int CodUsuario { get; set; }
        public UsuariosViewModel Usuario { get; set; } = new UsuariosViewModel();
        public ForeignKey FKeyUsuario
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Usuarios",
                    NameEntity = "Usuario",
                    NameFieldThis = "CodUsuario",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public int CodArea { get; set; }
        public int CodMesa { get; set; }
        public int CodTurno { get; set; }
        public string Descritivo { get; set; }
        public string NomeCliente { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public int NumeroOrdem { get; set; }
        public string Mascara { get; set; }
        public DateTime DataVencimento { get; set; } = UtilidadesGenericas.GetDataVencimento(30);
        public string Emitido { get; set; } = "Não Imprimido";
        public List<MovProdutosViewModel> MovArtigos { get; set; }
        public string Geracao { get; set; } = "ISENTO";
        public string Liquidado { get; set; } = "NÃO";
        public string Hash { get; set; }
        public string TelCliente { get; set; } = string.Empty;
        public string MoredaCliente { get; set; } = string.Empty;
        public string NifCliente { get; set; } = string.Empty;
        public decimal Desconto { get; set; }
        public decimal Imposto { get; set; }
        public decimal TotalIliquido { get; set; }
    }
}
