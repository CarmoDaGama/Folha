using Folha.Domain.Interfaces.Application.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Empresa;
using Folha.Domain.Interfaces.Repository.Empresa;

namespace Folha.Driver.Application.Empresa
{
    public class EmpresasApp : IEmpresaApp
    {
        private readonly IEmpresaRepository _EmpresaRepository;
        public EmpresasApp(IEmpresaRepository EmpresaRepository)
        {
            _EmpresaRepository = EmpresaRepository;
        }

        public void Editar(Folha.Domain.Models.Empresa.Empresa Dados)
        {
            _EmpresaRepository.Editar(Dados);
        }

        public void Eliminar(List<Folha.Domain.Models.Empresa.Empresa> lista)
        {
            throw new NotImplementedException();
        }

        public void Gravar(Folha.Domain.Models.Empresa.Empresa Dados)
        {
             _EmpresaRepository.Gravar(Dados);
        }

        public List<Folha.Domain.Models.Empresa.Empresa> Listar()
        {
           return _EmpresaRepository.Listar();
        }
    }
}
