using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Inventario
{
    public interface IImpostoRepository : IRepositoryBase<ImpostoViewModel>
    {
        IEnumerable<Imposto> Listar(string criterios);
        void Insert(Imposto entity);
        void Update(Imposto imposto);
        void Delete(Imposto imposto);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);

    }
}
