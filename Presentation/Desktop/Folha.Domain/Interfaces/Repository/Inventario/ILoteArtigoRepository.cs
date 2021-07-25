using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Inventario
{
    public interface ILoteArtigoRepository : IRepositoryBase<LoteViewModel>
    {
        Lote Gravar(Lote lote);
        //LoteViewModel GetById(int codigo);
        List<LoteViewModel> GetAll();
        List<LoteArtigosViewModel> GetLoteArtigo(int CodLote);
        void DeleteLoteArtigo(LoteArtigosViewModel delete);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        IEnumerable<Lote> Listar(string criterios);
    }
}
