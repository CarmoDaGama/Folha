﻿using Folha.Domain.Models.Admin;
using Folha.Domain.Models.Administrador;
using Folha.Domain.ViewModels.Admin;
using System.Collections.Generic;
namespace Folha.Domain.Interfaces.Application.Admin
{
    public interface IDefinicoesGeraisApp 
    {
        #region Trazer dados
        List<DefinicoesGeraisViewModel> ListarGerais(string Criterio);
        List<DefinicoesPrecosViewModel> ListarPrecos(string Criterio);
        List<DefinicoesFacturaViewModel> ListarFacturas(string Criterio);
        List<DefinicoesHotelViewModel> ListarHoteis(string Criterio);
        #endregion
        #region Update
        DefinicoesGerais GravarGeral(DefinicoesGerais definicao);
        DefinicoesPreco GravarPreco (DefinicoesPreco definicao);
        DefinicoesFactura GravarFactura (DefinicoesFactura definicao);
        DefinicoesHotel GravarHotel (DefinicoesHotel definicao);
        #endregion
        DefinicoesGeraisViewModel GetById(int codigo);
    }
}
