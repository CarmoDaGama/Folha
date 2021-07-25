using Folha.Domain.Interfaces.Application.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.Interfaces.Repository.Inventario;

namespace Folha.Driver.Application.Inventario
{
    public class LoteArtigoApp : ILoteArtigoApp
    {
        private readonly ILoteArtigoRepository _Repository;
        public LoteArtigoApp(ILoteArtigoRepository Repository)
        {
            _Repository = Repository;
        }

        public void DeleteLoteArtigo(LoteArtigosViewModel delete)
        {
            _Repository.DeleteLoteArtigo(delete);
        }

        public void EdiLote(LoteViewModel entity)
        {
            _Repository.Update(entity);
        }

        public List<LoteViewModel> GetAll()
        {
            return (List<LoteViewModel>)_Repository.GetAll(new LoteViewModel());
        }

        public LoteViewModel GetById(int codigo)
        {
            return (LoteViewModel)_Repository.Get(new LoteViewModel() { Codigo = codigo });
        }

        public List<LoteArtigosViewModel> GetLoteArtigo(int CodLote)
        {
            return _Repository.GetLoteArtigo(CodLote);
        }

        public Lote Gravar(Lote lote)
        {
            return _Repository.Gravar(lote);
        }

        public IEnumerable<Lote> Listar(string criterios, bool Pesquisa)
        {
            return (List<Lote>)_Repository.Listar(criterios);
        }
        public void RemoverLote(LoteViewModel lote)
        {
            _Repository.Delete(lote);
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return _Repository.VerificarDup(nomeTabela, dicionario);
        }
    }
}
