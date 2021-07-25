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
    public interface IQuartosHospitalarRepository : IRepositoryBase<QuartosHospitalarViewModel>
    {

        QuartosHospitalar Gravar(QuartosHospitalar quarto);
        List<CamasQuartosHospitalarViewModel> GetCamas(int codQuartos);
        void Delete(QuartosHospitalar entity);
        void DeleteCama(CamasQuartosHospitalarViewModel delete);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        IEnumerable<QuartosHospitalar> Listar(string criterios);



    }
}
