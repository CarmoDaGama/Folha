using Folha.Domain.Interfaces.Application.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;

namespace Folha.Driver.Application.Hospitalar
{
    public class ExamesHospitalarApp : IExamesHospitalarApp
    {
        private readonly IExamesHospitalarRepository _ExamesHospitalarRepository;

        public ExamesHospitalarApp(IExamesHospitalarRepository ExamesHospitalarRepository)
        {
            _ExamesHospitalarRepository = ExamesHospitalarRepository;
        }

        public void DeleteExamesAtendimento(ExamesAtendimento Dados)
        {
            _ExamesHospitalarRepository.DeleteExamesAtendimento(Dados);
        }

        public void FecharFacturar(ExamesHospitalar Dados)
        {
            _ExamesHospitalarRepository.FecharFacturar(Dados);
        }

        public void Insert(ExamesHospitalar Dados)
        {
            _ExamesHospitalarRepository.Insert(Dados);
        }

        public void InsertUpdateExamesAtendimento(List<ExamesViewModel> Lista)
        {
            _ExamesHospitalarRepository.InsertUpdateExamesAtendimento(Lista);
        }

        public IEnumerable<ExamesViewModel> ListarAtendimento(string CodAtendimento)
        {
            return _ExamesHospitalarRepository.ListarAtendimento(CodAtendimento);
        }
        
        public IEnumerable<ExamesViewModel> ListarExamesHospitalar(string CodExame)
        {
            return _ExamesHospitalarRepository.ListarExamesHospitalar(CodExame);
        }

        public void Update(ExamesHospitalar Dados)
        {
            _ExamesHospitalarRepository.Update(Dados);
        }
    }
}
