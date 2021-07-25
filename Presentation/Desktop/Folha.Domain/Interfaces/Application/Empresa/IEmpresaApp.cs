using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Empresa
{
    using Folha.Domain.Models.Empresa;
    public interface IEmpresaApp
    {
        List<Empresa> Listar( );
        void Eliminar(List<Empresa> lista);
        void Gravar(Empresa Dados);
        void Editar(Empresa Dados);
    }
}
