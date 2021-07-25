using Folha.Domain.Interfaces.Application.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Interfaces.Repository.Entidades;

namespace Folha.Driver.Application.Entidades
{
    public class FornecedoresApp : IFornecedoresApp
    {
        private readonly IFornecedoresRepository Repository;
        public FornecedoresApp(IFornecedoresRepository repository)
        {
            Repository = repository;
        }
        public void Add(Fornecedores fornecedor)
        {
            Repository.Insert(fornecedor);
        }

        public void Editar(Fornecedores fornecedor)
        {
            Repository.Update(fornecedor);
        }

        public void Eliminar(Fornecedores fornecedor)
        {
            Repository.Delete(fornecedor);
        }

        public Fornecedores GetById(int id)
        {
            return (Fornecedores)Repository.Get(new Fornecedores() { codigo = id });
        }

        public List<Fornecedores> Listar()
        {
            return (List<Fornecedores>)Repository.GetAll(new Fornecedores());
        }

       
        public IEnumerable<FornecedorBusca> ListarFornecedor(string criterios)
        {
            return (List<FornecedorBusca>)Repository.ListarFornecedor(criterios);
        }
    }
}
