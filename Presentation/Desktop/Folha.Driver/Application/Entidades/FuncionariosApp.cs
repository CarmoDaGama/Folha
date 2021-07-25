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
    public class FuncionariosApp : IFuncionariosApp
    {
        private readonly IFuncionariosRepository Repository;
        public FuncionariosApp(IFuncionariosRepository repository)
        {
            Repository = repository;
        }
        public void Add(Funcionarios funcionario)
        {
            Repository.Insert(funcionario);
        }

        public void Editar(Funcionarios funcionario)
        {
            Repository.Update(funcionario);
        }

        public void Eliminar(Funcionarios funcionario)
        {
            Repository.Delete(funcionario);
        }

        public Funcionarios GetById(int id)
        {
            return (Funcionarios)Repository.Get(new Funcionarios() { IDPessoa = id });
        }

        public List<Funcionarios> Listar()
        {
            return (List<Funcionarios>)Repository.GetAll(new Funcionarios());
        }
    }
}
