using Folha.Domain.Models.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Inventario
{
   public class TransferenciaProduto 
    {
        public int codigo { get; set; }
        public Documentos.Documentos Documenoto { get; set; }
        public Produtos Artigo { get; set; }
        public Origem Origem { get; set; }
        public Destino Destino { get; set; }
        public float Quantidade { get; set; }
        public string Origem_texto { get; set; }
        public string Destino_texto { get; set; }
    }
}
