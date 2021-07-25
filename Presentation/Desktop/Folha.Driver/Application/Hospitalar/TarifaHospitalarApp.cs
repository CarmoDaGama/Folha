using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;

namespace Folha.Driver.Application.Hospitalar
{
    public class TarifaHospitalarApp : ITarifaHospitalarApp
    {

        private readonly ITarifaHospitalarRepository _Repository;

        public TarifaHospitalarApp(ITarifaHospitalarRepository Repository)
        {
            _Repository = Repository;
        }

        public void Delete(TarifaHospitalar entity)
        {
            _Repository.Delete(entity);
        }

        public TarifaHospitalarViewModel GetById(int codigo)
        {
            return (TarifaHospitalarViewModel)_Repository.Get(new TarifaHospitalarViewModel() { Codigo = codigo });
        }

        public TarifaHospitalar Gravar(TarifaHospitalar tarifa)
        {
            return _Repository.Gravar(tarifa);
        }

        public IEnumerable<TarifaHospitalar> Listar(string criterios)
        {
            return (List<TarifaHospitalar>)_Repository.Listar(criterios);
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return _Repository.VerificarDup(nomeTabela, dicionario);
        }
    }
}
