using Enterprise.Domain.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Domain.Inventario
{
   public class TransProduto : Entity
    {
        public int codigo { get; set; }
        public int CodDocumento { get; set; }
        public Documento Documenoto { get; set; }
        public int CodArtigo { get; set; }
        public Artigo Artigo { get; set; }
        public int CodOrigem { get; set; }
        public Origem Origem { get; set; }
        public int CodDestino { get; set; }
        public Destino Destino { get; set; }
        public float Quantidade { get; set; }

        public string Origem_texto { get; set; }
        public string Destino_texto { get; set; }
    }
}
