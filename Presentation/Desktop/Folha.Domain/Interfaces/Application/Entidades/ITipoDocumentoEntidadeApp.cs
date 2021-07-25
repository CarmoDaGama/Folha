using Folha.Domain.Models.Entidades;
using Folha.Domain.ViewModels.Entidades;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Entidades
{
    public interface ITipoDocumentoEntidadeApp
    {
        void Delete(TiposDocumentosViewModel tipo);
        TiposDocumentosViewModel Get(int id);
        List<TiposDocumentosViewModel> GetAll();
        void Insert(TiposDocumentosViewModel tipo);
        void Update(TiposDocumentosViewModel tipo);
    }
}
