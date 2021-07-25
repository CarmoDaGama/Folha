using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository
{
   public interface IRepositoryBase<T> where T : class
    {

        void Delete(T tabela);
        object Get(T tabela);
        object GetAll(T tabela);

        object Select(string query);

        void Insert(T tabela);

        void Update(T tabela);

        void Dispose();

        void Query(string query);
    }
}
