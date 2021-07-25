using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Hospitalar
{
     public  interface IQuartosHospitalarApp
    {
        QuartosHospitalar Gravar(QuartosHospitalar quarto);
        void Delete(QuartosHospitalar entity);
        void EditQuarto(QuartosHospitalarViewModel entity);
        QuartosHospitalarViewModel GetById(int codigo);
        List<CamasQuartosHospitalarViewModel> GetCamas(int codQuartos);
        void DeleteCama(CamasQuartosHospitalarViewModel delete);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        IEnumerable<QuartosHospitalar> Listar(string criterios);
    }
}
