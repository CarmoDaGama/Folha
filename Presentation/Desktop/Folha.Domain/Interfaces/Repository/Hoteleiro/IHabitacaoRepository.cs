
using Folha.Domain.Models.Hoteleiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Hoteleiro
{
    public interface IHabitacaoRepository
    {
        bool VerificaDisponivel(Guid habitacaoID, DateTime checkin, DateTime ckeckout);
        List<Habitacao> MostrarMovHabitacoes(string crit);
    }
}
