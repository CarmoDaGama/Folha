using Folha.Domain.Models.Entidades;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Entidades
{
    public interface IHabilitacaoApp
    {
        void Insert(Habilitacoes habilitacao);
        Habilitacoes GetById(int id);
        List<Habilitacoes> Listar();
        void Update(Habilitacoes habilitacao);
        void Delete(Habilitacoes habilitacao);
    }
}
