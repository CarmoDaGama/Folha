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
    public interface ICamasHospitalarRepository: IRepositoryBase <CamasHospitalarViewModel>
    {
        IEnumerable<CamasHospitalar> Listar(string criterios);
        void Delete(CamasHospitalar entity);
        void Update(CamasHospitalar entity);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        CamasHospitalar Gravar(CamasHospitalar cama);
        List<CamasHospitalarViewModel> GetAll();
        CamasHospitalarViewModel GetById(int codigo);
    }
}
