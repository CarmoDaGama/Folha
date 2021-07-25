using Folha.Domain.Models.Servicos;
using System;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Servicos
{
    public interface IEquipamentoRepository
    {
        List<Equipamento> ListarEquipamentos();
        List<MovEquipamento> ListarMovEquipamentos(Guid documentoID);
        void LançarEquipamento(Guid documentoID, MovEquipamento movEquipamento);
        void LancarEquipamento(int codDocumento, int CodEquipamneto, string Modelo, string Fabricante, string Matricula);
    }
}
