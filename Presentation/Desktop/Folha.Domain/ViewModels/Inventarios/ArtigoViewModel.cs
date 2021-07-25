using Enterprise.Domain;
using Enterprise.Domain.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Framework.ViewModels.Inventario
{
  public  class ArtigoViewModel
    {
        public int codigo { get; set; }
        public int CodProduto { get; set; }

        public Produtos Artigo { get; set; }
        public string NomeArtigo { get { return Artigo.descricao; } }
        public decimal Preco { get { return Artigo.preco1; } }
        public bool Controla { get { return Artigo.movimentaStock == 1; } }
        public bool Vender { get { return Artigo.Vender == 1; } }
        public decimal Imposto { get { return Artigo.Imposto; } }
        public decimal Custo { get { return Artigo.custo; } }
        public string Familia { get { return Artigo.Familia.descricao; } }
        public int CodArmazem { get; set; }

        //[CodArmazem]
        public Armazens Armazem { get; set; }
        public string NomeArmazem { get { return Armazem.descricao; } }
        //[qtde]
        public decimal qtde { get; set; }
        //[stockMin]
        public decimal stockMin { get; set; }
        //[stockMax]
        public decimal stockMax { get; set; }
    }
}
