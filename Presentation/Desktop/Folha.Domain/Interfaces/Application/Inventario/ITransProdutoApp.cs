using Enterprise.Domain.Inventario;
using Enterprise.Framework.ViewModels.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Application.Contract.Inventario
{
    public interface ITransProdutoApp
    {
        IEnumerable<TransProduto> Listar(string criterios, bool Pesquisa);
        void Insert(TransProduto entity);
        void Update(TransProduto entity, string criterios);
        void Delete(TransProduto transProduto);

    }
}
