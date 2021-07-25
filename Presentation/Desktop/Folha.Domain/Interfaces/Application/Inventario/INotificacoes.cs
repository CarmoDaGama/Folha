using Folha.Domain.ViewModels.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Inventario
{
    public interface INotificacoes
    {
        List<DocumentosViewModel> BuscarContasReceber();
        List<DocumentosViewModel> BuscarContasApagar();


    }
}
