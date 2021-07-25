using Folha.Domain.Models.Entidades;
using Folha.Domain.ViewModels.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Entidades
{
    public interface ITipoContactoApp
    {
        void Delete(TipoContactoViewModel tipo);
        TipoContactoViewModel Get(int id);
        List<TipoContactoViewModel> GetAll();
        void Insert(TipoContactoViewModel tipo);
        void Update(TipoContactoViewModel tipo);
    }
}
