using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Inventario
{
    public interface ILoteArtigoApp
    {
        Lote Gravar(Lote lote);
        LoteViewModel GetById(int codigo);
        void EdiLote(LoteViewModel entity);
        void RemoverLote(LoteViewModel lote);
        void DeleteLoteArtigo(LoteArtigosViewModel delete);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        List<LoteArtigosViewModel> GetLoteArtigo(int CodLote);
        List<LoteViewModel> GetAll();      
        IEnumerable<Lote> Listar(string criterios, bool Pesquisa);
    }
}
