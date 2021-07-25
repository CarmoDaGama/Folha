using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Hospitalar
{
    public interface IReceitasApp
    {
        List<ReceitasViewModel> ListaReceita(string CodAtendimento);
        void Insert(Receitas Dados);
        void Update(Receitas Dados);
        IEnumerable<Receitas> CarregaReceita(string CodAtendimento);
        IEnumerable<FarmacoReceitaViewModel> CarregaFarmacos(string CodAtendimento);
        void InsertFarmaco(List<FarmacoReceitaViewModel> Lista);
        void DeleteFarmacos(FarmacoReceita Dados);
        void UpdateFarmaco(List<FarmacoReceita> Lista);
    }
}
