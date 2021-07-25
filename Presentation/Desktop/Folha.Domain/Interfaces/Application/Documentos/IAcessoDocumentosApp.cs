using Folha.Domain.Models.Documentos;
using Folha.Domain.ViewModels.Documentos;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Documentos
{
    public interface IAcessoDocumentosApp
    {
        List<AcessoDocumentos> Listar();
        AcessoDocumentos GetPorId(int id);
        void Add(AcessoDocumentosViewModel acesso);
        void editar(AcessoDocumentosViewModel acesso);
        void Eleminar(AcessoDocumentosViewModel acesso);
    }
}
