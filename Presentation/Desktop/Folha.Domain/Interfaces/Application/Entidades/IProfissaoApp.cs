using Folha.Domain.Models.Entidades;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Entidades
{
    public interface IProfissaoApp
    {
        void Insert(Profissao Proficao);
        Profissao GetById(int id);
        List<Profissao> Listar();
        void Delete(Profissao profissao);
        void Update(Profissao profissao);
    }
}
