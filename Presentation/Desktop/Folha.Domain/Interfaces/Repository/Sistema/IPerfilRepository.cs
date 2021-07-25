using Folha.Domain.Models.Sistema;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Sistema
{
    public  interface IPerfilRepository
    {
        List<Perfil> ListarPerfis(string[] criterios);
    }
}
