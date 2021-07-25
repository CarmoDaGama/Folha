using System;
using System.Collections.Generic;

using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Report;

namespace Folha.Domain.Interfaces.Repository.Financeiro
{
    public   interface IContaBancariaRepository
    {
        IEnumerable<ContasBancarias> ContasBancariasAcessoPorUsuario(Guid usuarioID, bool admin);
        List<ContasBancarias> Listar(string criterios,bool Pesquisa);
        void Insert(ContasBancarias entity);
        void Update(ContasBancarias conta,string criterios);
        IEnumerable<MostraContasViewModel> Minhas_ContasBancarias();
        double buscarSaldoBanco(int CodBanco);
        DataViewModel RetortaDataSaldoConta();
        void Delete(int Codconta);
    }
}
