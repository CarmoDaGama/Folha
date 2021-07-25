using Folha.Domain.Models.Servicos;
using System;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Servicos
{
    public   interface IMovServicoRepository
    {
        IEnumerable<MovServico> MostrarMovServicosSaidas(Guid documentoID, Guid equpamentoID);
        IEnumerable<MovServico> MostrarMovServicos(int NumeroDocumento, Guid equipamentoID);
        void LancarServicosVenda(int NumeroVenda, MovServico movService);
        void LancarServicosNotaSaida(int NumeroVenda, MovServico movService);


    }
}
