
using Folha.Domain.Models.Db;

namespace Folha.Domain.Interfaces.Repository
{
    public  interface IRepositoryBaseDb<T> where T : DbDTO
    {
        void Insert(T tabela);
        object Get(T tabela);
        void Query(string query);
        object GetAll(T tabela);
        object Select(string query);
        void Update(T tabela);
        void Delete(T tabela);
        void Dispose();
    }
}
