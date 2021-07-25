using Folha.Domain.Models.Genericos;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Entidades
{
    public interface IPaisApp
    {
        void Insert(Pais pais);
        Pais GetById(int id);
        List<Pais> Listar();
        void Delete(Pais pais);
        void Update(Pais pais);
    }
}
