
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.ViewModels.Report;
using System;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Inventario
{
    public  interface IArmazensRepository : IRepositoryBase<ArmazensViewModel>
    {
        IEnumerable<Armazens> Listar(string criterios);
        void Insert(Armazens entity);
        void Update(Armazens armazem);
        void Delete(Armazens armazem);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        IEnumerable<Armazens> Meus_Armazens();


    }
}
