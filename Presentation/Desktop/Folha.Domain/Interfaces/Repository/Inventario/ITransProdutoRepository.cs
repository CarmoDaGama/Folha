using Enterprise.Data.Repository.Contract;
using Enterprise.Domain.Inventario;
using Enterprise.Framework.ViewModels.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Repository.Contract.Inventario
{
    public interface ITransProdutoRepository
    {
       
        IEnumerable<TransferenciaProdutoViewModel> Lista(string criterios);
        
        List<TransProduto> Listar(string criterios, bool Pesquisa);
        void Insert(TransProduto entity);
        void Update(TransProduto transProduto, string criterios);
        void Delete(TransProduto transProduto);
    }
}
