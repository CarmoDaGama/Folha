using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Interfaces.Repository.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;

namespace Folha.Driver.Application.Financeiro
{
    public class FPagamentosApp : IFPagamentosApp
    {
        private readonly IFPagamentosRepository _FPagamentosRepository;
        public FPagamentosApp(IFPagamentosRepository FPagamentosRepository)
        {
            _FPagamentosRepository = FPagamentosRepository;
        }

        public void addFPagamentos(fPagamentos FPagamento, string Criterios)
        {
            _FPagamentosRepository.InsertFPagamentos(FPagamento,Criterios);
        }

        public void Delete(fPagamentosViewModel forma)
        {
            _FPagamentosRepository.Delete(forma);
        }

        public List<fPagamentosViewModel> GetAll()
        {
            return (List<fPagamentosViewModel>)_FPagamentosRepository.GetAll(new fPagamentosViewModel());
        }

        public fPagamentos GetByCodConta(int CodConta)
        {
            return _FPagamentosRepository.GetByCodConta(CodConta);
        }

        public fPagamentosViewModel GetById(int id)
        {
            return (fPagamentosViewModel)_FPagamentosRepository.Get(new fPagamentosViewModel() { codigo = id });
        }

        public void Insert(fPagamentosViewModel forma)
        {
            _FPagamentosRepository.Insert(forma);
        }

        public IEnumerable<fPagamentos> Listar(string[] criterios)
        {
            return _FPagamentosRepository.ListarFormasdePagamentos(criterios);
        }

        public void Update(fPagamentosViewModel forma)
        {
            _FPagamentosRepository.Update(forma);
        }
    }
}
