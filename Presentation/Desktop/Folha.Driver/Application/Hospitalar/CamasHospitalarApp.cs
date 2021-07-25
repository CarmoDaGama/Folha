using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;

namespace Folha.Driver.Application.Hospitalar
{
    public class CamasHospitalarApp : ICamasHospitalarApp
    {

        private readonly ICamasHospitalarRepository _Repository;

        public CamasHospitalarApp(ICamasHospitalarRepository Repository)
        {
            _Repository = Repository;
        }
        public void Delete(CamasHospitalar entity)
        {
            _Repository.Delete(entity);
        }

        public List<CamasHospitalarViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public CamasHospitalarViewModel GetById(int codigo)
        {
            return (CamasHospitalarViewModel)_Repository.Get(new CamasHospitalarViewModel() { Codigo = codigo });
        }

        public CamasHospitalar Gravar(CamasHospitalar cama)
        {
            return _Repository.Gravar(cama);
        }

        public IEnumerable<CamasHospitalar> Listar(string criterios)
        {
            return (List<CamasHospitalar>)_Repository.Listar(criterios);
        }

        public void Update(CamasHospitalar cama)
        {
            _Repository.Update(cama);

        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return _Repository.VerificarDup(nomeTabela, dicionario);
        }
    }
}
