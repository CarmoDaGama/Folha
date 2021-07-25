using Folha.Domain.Models.Entidades;
using Folha.Domain.ViewModels.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Entidades
{
    public interface IDocumentoEntidadeRepository : IRepositoryBase<DocumentosEntidadeViewModel>
    {
        List<DocumentosEntidadeViewModel> Listar();
    }
}
