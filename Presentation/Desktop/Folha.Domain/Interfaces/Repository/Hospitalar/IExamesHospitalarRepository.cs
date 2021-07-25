using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Hospitalar
{
    public interface IExamesHospitalarRepository
    {
        void FecharFacturar(ExamesHospitalar Dados);
        void Insert(ExamesHospitalar Dados);
        void Update(ExamesHospitalar Dados);
        IEnumerable<ExamesViewModel> ListarAtendimento(string CodAtendimento);
        IEnumerable<ExamesViewModel> ListarExamesHospitalar(string CodExame);
        void InsertUpdateExamesAtendimento(List<ExamesViewModel> Lista);
        void DeleteExamesAtendimento(ExamesAtendimento Dados);
    }
}
