using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Folha.Domain.Interfaces.Application.Financeiro
{
    public interface IFPagamentosApp
    {
        IEnumerable<fPagamentos> Listar(string[] criterios);
        void addFPagamentos(fPagamentos FPagamento,string Criterios);
        List<fPagamentosViewModel> GetAll();
        void Insert(fPagamentosViewModel forma);
        void Update(fPagamentosViewModel forma);
        void Delete(fPagamentosViewModel forma);
        fPagamentosViewModel GetById(int id);
        fPagamentos GetByCodConta(int CodConta);

    }
}
