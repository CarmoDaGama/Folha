using Folha.Domain.Interfaces.Application.Admin;
using Folha.Domain.Models.Admin;
using Folha.Domain.Models.Administrador;
using Folha.Domain.ViewModels.Admin;
using Folha.Domain.Interfaces.Repository.Admin;
using System;
using System.Collections.Generic;

namespace Folha.Driver.Application.Admin
{
    public class DefinicoesGeraisApp : IDefinicoesGeraisApp
    {
        private readonly IDefinicoesGeraisRepository _definicoesRepository;

        public DefinicoesGeraisApp (IDefinicoesGeraisRepository definicoesGeraisRepository)
        {
            _definicoesRepository = definicoesGeraisRepository;
        }

        public DefinicoesGeraisViewModel GetById(int codigo)
        {
            return (DefinicoesGeraisViewModel)_definicoesRepository.Get(new DefinicoesGeraisViewModel() { codigo = codigo });

        }

        #region Update
        public DefinicoesGerais GravarGeral(DefinicoesGerais definicao)
        {
            return _definicoesRepository.GravarGeral(definicao);
        }
        public DefinicoesFactura GravarFactura(DefinicoesFactura definicao)
        {
            return _definicoesRepository.GravarFactura(definicao);
        }
        public DefinicoesHotel GravarHotel(DefinicoesHotel definicao)
        {
            return _definicoesRepository.GravarHotel(definicao);
        }
        public DefinicoesPreco GravarPreco(DefinicoesPreco definicao)
        {
            return _definicoesRepository.GravarPreco(definicao);
        }
        #endregion

        #region Carregar dados
        public List<DefinicoesFacturaViewModel> ListarFacturas(string Criterio)
        {
            return _definicoesRepository.ListarFacturas(null);
        }

        public List<DefinicoesGeraisViewModel> ListarGerais(string Criterio)
        {
            return _definicoesRepository.ListarGerais(null);
        }

        public List<DefinicoesHotelViewModel> ListarHoteis(string Criterio)
        {
            return _definicoesRepository.ListarHoteis(null);
        }

        public List<DefinicoesPrecosViewModel> ListarPrecos(string Criterio)
        {
            return _definicoesRepository.ListarPrecos(null);
        }
        #endregion

    }
}
