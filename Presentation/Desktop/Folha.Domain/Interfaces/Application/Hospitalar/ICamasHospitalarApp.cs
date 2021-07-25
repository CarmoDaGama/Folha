using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Hospitalar
{
    public interface ICamasHospitalarApp
    {
        IEnumerable<CamasHospitalar> Listar(string criterios);
        void Delete(CamasHospitalar entity);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        CamasHospitalar Gravar(CamasHospitalar cama);
        List<CamasHospitalarViewModel> GetAll();
        CamasHospitalarViewModel GetById(int codigo);
        void Update(CamasHospitalar entity);

    }
}
