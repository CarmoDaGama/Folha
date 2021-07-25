using Folha.Domain.Models.Hoteleiro;
using System;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Hoteleiro
{
    public interface IMovHabitacaoRepository
    {
        IEnumerable<MovHabitacao> ListarMovHabitacoes(Guid documentoID);
        bool VerificaDisponivel(Guid habitacaoID, DateTime checkin, DateTime ckeckout);
        IEnumerable<MovHabitacao> MostrarMovHabitacoes(string crit);
    }
}
