using Folha.Domain.Models.Sistema;
using Folha.Domain.ViewModels.Frame.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.ViewModels.Sistema;

namespace Folha.Domain.Interfaces.Application.Sistema
{
    public interface ITurnosApp
    {
        void CarregarTurnoCurrent();
        bool ContemTurnosComCaixasNulos(int codTurno);
        void ConfirmarTurno(int codCaixa, int codSuperVisor, int codTurno);
        int BuscaCodigoTurno(int usuarioID);
        string VerificaEstadoDoTurno(int usuarioID);
        IEnumerable<TurnosVendedoresViewModel> ListarTurnoVendedores(string criterios);
        IEnumerable<Turnos> ListarTurno();
        int AbrirTurno(decimal saldoInicial);
        void FecharTurno(decimal SaldoTotal, decimal Informado, decimal SaldoVendas, decimal SaldoHospedagem, int CodTurno);
        TurnosViewModel GetById(int codigoTurno);
    }
}
