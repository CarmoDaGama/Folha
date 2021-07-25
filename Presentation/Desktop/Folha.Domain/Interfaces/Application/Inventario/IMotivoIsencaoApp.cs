using Folha.Domain.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Inventario
{
    public interface IMotivoIsencaoApp
    {

        MotivoIsencao GetById(int codigo);
        IEnumerable<MotivoIsencao> Listar(string criterios, bool Pesquisa);
     
    }
}
