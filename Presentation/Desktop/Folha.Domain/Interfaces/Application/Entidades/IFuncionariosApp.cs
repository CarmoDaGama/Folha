using Folha.Domain.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Entidades
{
    public interface IFuncionariosApp
    {

        void Eliminar(Funcionarios funcionario);
        void Add(Funcionarios funcionario);
        void Editar(Funcionarios funcionario);
        Funcionarios GetById(int id);
        List<Funcionarios> Listar();
    }
}
