using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Entidades;

namespace Folha.Driver.Application.Hospitalar
{
    public class LaboratorioApp : ILaboratorioApp
    {
        private readonly ILaboratorioRepository _labRepository;

        public LaboratorioApp(ILaboratorioRepository labRepository)
        {
            _labRepository = labRepository;
        }
        public void Delete(Laboratorio lab)
        {
            _labRepository.Delete(lab);
        }
        //
        public IEnumerable<Laboratorio> FiltrarLaboratorioEstadoData(string valor, string dtInicoEst, string dtFim)
        {
            return (List<Laboratorio>)_labRepository.FiltrarLaboratorioEstadoData(valor, dtInicoEst, dtFim);
        }

        public List<ExamesAtendimentoViewModel> GetAll()
        {
            return (List<ExamesAtendimentoViewModel>)_labRepository.GetAll(new ExamesAtendimentoViewModel());
        }

        public ExamesAtendimentoViewModel GetById(int codigo)
        {
            return (ExamesAtendimentoViewModel)_labRepository.Get(new ExamesAtendimentoViewModel() { Codigo = codigo });
        }

        public ContactosViewModel GetTelefoneByEntidade(string CodEntidade)
        {
            return _labRepository.GetContactoByEntidade(CodEntidade);
        }

        public Laboratorio Gravar(Laboratorio lab)
        {
            return _labRepository.Gravar(lab);
        }
        public IEnumerable<Laboratorio> Listar(string criterios, bool Pesquisa)
        {
            return (List<Laboratorio>)_labRepository.Listar(criterios);
        }
        
    }
}
