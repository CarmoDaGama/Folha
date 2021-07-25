using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Domain.Interfaces.Repository.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Genericos;

namespace Folha.Driver.Application.Entidades
{
    public class PaisApp : IPaisApp
    {
        private readonly IPaisRepository _Repository;

        public PaisApp(IPaisRepository Repository)
        {
            _Repository = Repository;
        }

        public void Delete(Pais pais)
        {
            _Repository.Delete(pais);
        }

        public Pais GetById(int id)
        {
            return (Pais)_Repository.Get(new Pais() { codigo = id });
        }

        public void Insert(Pais pais)
        {
            _Repository.Insert(pais);
        }

        public List<Pais> Listar()
        {
            return (List<Pais>)_Repository.GetAll(new Pais());
        }

        public void Update(Pais pais)
        {
            _Repository.Update(pais);
        }
    }
}
