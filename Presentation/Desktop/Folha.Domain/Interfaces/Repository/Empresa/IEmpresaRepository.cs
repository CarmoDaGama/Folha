using Folha.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Empresa
{
    using Folha.Domain.Models.Empresa;
    public interface IEmpresaRepository 
    {
        List<Empresa> Listar();
        void Eliminar(List<Empresa> lista);
        void Gravar(Empresa Dados);
        void Editar(Empresa Dados);
    }
}
