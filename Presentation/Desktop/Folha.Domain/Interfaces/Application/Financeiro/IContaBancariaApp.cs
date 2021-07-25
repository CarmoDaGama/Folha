using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Financeiro
{
    public interface IContaBancariaApp
    {
        IEnumerable<ContasBancarias>Listar(string criterios,bool Pesquisa);
        void addContaBancaria(ContasBancarias ContaBancaria);
        void Insert(ContasBancarias entity);
        void Update(ContasBancarias entity, string criterios);
        IEnumerable<MostraContasViewModel> Minhas_ContasBancarias();
        double buscarSaldoBanco(int CodBanco);
        DataViewModel RetortaDataSaldoConta();
        void Delete(int Codconta);
    }
}
