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
    public class ReceitasApp : IReceitasApp
    {
        private readonly IReceitasRepository _ReceitasRepository;

        public ReceitasApp(IReceitasRepository ReceitasRepository)
        {
            _ReceitasRepository = ReceitasRepository;
        }

        public IEnumerable<FarmacoReceitaViewModel> CarregaFarmacos(string CodAtendimento)
        {
            return _ReceitasRepository.CarregaFarmacos(CodAtendimento);
        }

        public IEnumerable<Receitas> CarregaReceita(string CodAtendimento)
        {
            return _ReceitasRepository.CarregaReceita(CodAtendimento);
        }

        public void DeleteFarmacos(FarmacoReceita Dados)
        {
            _ReceitasRepository.DeleteFarmacos(Dados);
        }

        public void Insert(Receitas Dados)
        {
            _ReceitasRepository.Insert(Dados);
        }

        public void InsertFarmaco(List<FarmacoReceitaViewModel> Lista)
        {
           _ReceitasRepository.InsertFarmaco(Lista);
        }

        public List<ReceitasViewModel> ListaReceita(string CodAtendimento)
        {
            return _ReceitasRepository.ListaReceita(CodAtendimento);
        }

        public void Update(Receitas Dados)
        {
            _ReceitasRepository.Update(Dados);
        }

        public void UpdateFarmaco(List<FarmacoReceita> Lista)
        {
            _ReceitasRepository.UpdateFarmaco(Lista);
        }
    }
}
