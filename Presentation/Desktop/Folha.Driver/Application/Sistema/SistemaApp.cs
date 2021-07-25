using Folha.Domain.Interfaces.Application.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Driver.Application.Sistema
{
   public class SistemaApp: ISistemaApp
    {
        private readonly ISistemaApp _sistemaApp;

        public SistemaApp(ISistemaApp sistemaApp)
        {
            _sistemaApp = sistemaApp;
        }

        public void ActualizarTabelas()
        {
            
        }
    }
}
