using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Models.Genericos;
using Folha.Domain.ViewModels.Genericos;
using Folha.Domain.Interfaces.Repository.Generico;
using Folha.Driver.Repository.Hospitalar;
using System;
using System.Collections.Generic;

namespace Folha.Driver.Application.Genericos
{
    public class EscalaApp : IEscalaApp
    {
        private readonly IEscalaRepository _EscalaRepository;

        public EscalaApp(IEscalaRepository EscalaRepository)
        {
            _EscalaRepository = EscalaRepository;
        }
        public IEnumerable<Escala> Listar(string Descricao)
        {
            return _EscalaRepository.Listar(Descricao);
        }

        public IEnumerable<DiasSemana> ListDiasSemana()
        {
            return _EscalaRepository.ListDiasSemana();
        }
        public List<DiasSemana01ViewModel> CarregarDiasSemana()
        {
            return _EscalaRepository.CarregarDiasSemana();
        }

        public IEnumerable<EscalaConfig01ViewModel> ListEscalaConfig(string CodEscala)
        {
            return _EscalaRepository.ListEscalaConfig(CodEscala);
        }

        public IEnumerable<EscalaConfig01ViewModel> ListEscalaDisponivel(string CodDia, string HoraInicial)
        {
            return _EscalaRepository.ListEscalaDisponivel(CodDia, HoraInicial);
        }

        public Escala Gravar(Escala escala)
        {
            return _EscalaRepository.Gravar(escala);
        }

        public Escala Eliminar(Escala escala)
        {
            return _EscalaRepository.Eliminar(escala);
        }

        public EscalaViewModel GetById(int codigo)
        {
            return (EscalaViewModel)_EscalaRepository.Get(new EscalaViewModel() { Codigo = codigo });
        }

        public void DeleteEscalaConfig(EscalaConfigViewModel delete)
        {
            _EscalaRepository.DeleteEscalaConfig(delete);
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return _EscalaRepository.VerificarDup(nomeTabela, dicionario);
        }

        public List<EscalaConfigViewModel> GetEscalaConfig(int codigo)
        {
            return _EscalaRepository.GetEscalaConfig(codigo);

        }

        public void Apagar(EscalaViewModel apagar)
        {
             _EscalaRepository.Apagar(apagar);
        }

        public int HoraTrabalho(int Codigo)
        {
            return _EscalaRepository.HoraTrabalho(Codigo);
        }

        public void UpdateHora(Escala var)
        {
            _EscalaRepository.UpdateHora(var);
        }
    }
}
