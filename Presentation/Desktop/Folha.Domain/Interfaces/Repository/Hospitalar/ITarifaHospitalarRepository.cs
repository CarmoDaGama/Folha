using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Hospitalar
{
    public   interface ITarifaHospitalarRepository : IRepositoryBase<TarifaHospitalarViewModel>
    {
        IEnumerable<TarifaHospitalar> Listar(string criterios);
        void Delete(TarifaHospitalar entity);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        TarifaHospitalar Gravar(TarifaHospitalar tarifa);
        TarifaHospitalarViewModel GetById(int codigo);
    }
}
