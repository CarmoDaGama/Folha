using Folha.Domain.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Entidades
{
    public interface IFornecedoresApp
    {
        void Eliminar(Fornecedores fornecedor);
        void Add(Fornecedores fornecedor);
        void Editar(Fornecedores fornecedor);
        Fornecedores GetById(int id);
        List<Fornecedores> Listar();

        //não apaga Alcino
        IEnumerable<FornecedorBusca> ListarFornecedor(string criterios);



    }
}
