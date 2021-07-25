using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Restaurante
{
  public  interface IMesaRepository
    {
        void Ocupa_DesocupaMesa(Guid mesa, Guid documentoVenda);
    }
}
