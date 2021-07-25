using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.Helpers;
using System;

namespace Folha.Domain.ViewModels.Documentos
{
    using Entidades;
    using Financeiro;

    public class VendaViewModel
    {
        public int codigo { get; set; }
        public int CodProduto { get; set; }

        public ProdutoStockViewModel Artigo { get; set; }
        public MovProdutosViewModel MovArtigo { get; set; } = null;
        public string NomeArtigo {
            get {
                return MovArtigo.Descricao;
            }
        }
        public decimal Preco { get { return UtilidadesGenericas.GetValorCambio(MovArtigo.Preco); } }
        public bool Controla { get { return Artigo.Artigo.movimentaStock == 1; } }
        public bool Vender { get { return Equals(Artigo, null) || Artigo.codigo <= 0 ? false : Artigo.Artigo.Vender == 1; } }
        public DateTime Data { get { return MovArtigo.Documento.Data; } }
        public string Hora { get { return Data.ToShortTimeString(); } }
        public string Imposto {
            get
            {
                var strImposto = "";
                if (Equals(Artigo, null) || Artigo.codigo <= 0)
                {
                    strImposto = ((MovArtigo.Imposto/ 100) * MovArtigo.Preco).ToString("N3");
                }
                else if (Artigo.Artigo.EntityImposto.Percentagem == 0)
                {
                    strImposto = Artigo.Artigo.EntityImposto.Percentagem.ToString("N3");
                }
                else
                {
                    strImposto = ((Artigo.Artigo.EntityImposto.Percentagem / 100) * Artigo.Artigo.preco1).ToString("N3");
                }
                return strImposto;
            }
        }
        public decimal DecimalImposto { get{
                return MovArtigo.Imposto / 100;
            } }
        public string Moeda { get; set; }
        public string Cambio { get; set; }
        public decimal Desconto { get { return MovArtigo.Desconto; } }
        public decimal DecimalDesconto { get { return MovArtigo.Desconto/100; } }
        public decimal Custo { get { return UtilidadesGenericas.GetValorCambio(MovArtigo.Custo); } }
        public string Familia {
            get {
                if (Equals(Artigo, null)|| Artigo.codigo <= 0 )
                {
                    var nome = "Desconhecida";
                    if ((Equals(MovArtigo.ArtigoStock, null) || MovArtigo.ArtigoStock.codigo <= 0) && !string.IsNullOrEmpty(MovArtigo.ArtigoAbstrato))
                    {
                        var spNome = MovArtigo.ArtigoAbstrato.Split('?');
                        if (spNome.Length > 0)
                        {
                            nome = spNome[0];
                        }
                    }
                    return nome;

                }
                return Artigo.Artigo.Familia.descricao;
            }
        }
        public string Referencia { get; set; } = string.Empty;
        public int CodArmazem { get { return Equals(Artigo, null) || Artigo.codigo <= 0 ? 0 : Artigo.CodArmazem; } }
        public string NomeArmazem { get { return Equals(Artigo, null) || Artigo.codigo <= 0 ? "Desconhecido" : Artigo.Armazem.descricao; } }
        //[qtde]
        public decimal qtde { get; set; }
        public string Qtdade {
            get {
                if (Equals(MovArtigo.Artigo, null) || 
                    MovArtigo.Artigo.Codigo <= 0 || 
                    Equals(Artigo, null) ||
                    Artigo.codigo <= 0)
                {
                    return "UNIDADE";
                }
                else
                {
                    return qtde.ToString("N3");
                }
            }
        }
        //[stockMin]
        public decimal stockMin { get { return Artigo.stockMin; } }
        //[stockMax]
        public decimal stockMax { get { return Artigo.stockMax; } }
        public decimal Total {
            get
            {
                var total = 0.0m;
                if (Equals(Artigo, null) || Artigo.codigo <= 0)
                {
                    total = UtilidadesGenericas.CalcularTotal(
                        MovArtigo.Preco, 
                        qtde, 
                        MovArtigo.Imposto,
                        MovArtigo.Desconto
                    );
                }
                else
                {
                    total = UtilidadesGenericas.CalcularTotal(
                           MovArtigo.Preco,
                           qtde,
                           Artigo.Artigo.EntityImposto.Percentagem,
                           MovArtigo.Desconto
                       );

                }

                return UtilidadesGenericas.GetValorCambio(total);
            }
        }
        public EntidadesViewModel Entidade { get; set; }
        public string NomeFumcionario { get; set; } = "ADMINISTRADOR DO SISTEMA";
        public string NomeCliente { get; set; } = "CONSUMIDOR FINAL";
        public string NomeDocumeto { get; set; }
        public ContasBancariasViewModel ContaPagamento { get; set; } = new ContasBancariasViewModel() {
             Banco = new BancosViewModel() { descricao = "Caixa" }, Numero = "Numerário"
        };
        public decimal DescontoGeral { get { return MovArtigo.DescontoGeral; } }
        public string TotalExtenso(decimal valor) {
            return UtilidadesGenericas.Decimal_Extenso(valor);
        }
    }
}
