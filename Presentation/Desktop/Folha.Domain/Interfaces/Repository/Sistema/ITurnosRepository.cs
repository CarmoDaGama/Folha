using Folha.Domain.Models.Sistema;
using Folha.Domain.ViewModels.Sistema;
using Folha.Domain.ViewModels.Frame.Sistema;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Sistema
{
    public  interface ITurnosRepository : IRepositoryBase<TurnosViewModel>
    {
        bool ContemTurnosComCaixasNulos(int codTurno);
        int BuscaCodigoTurno(int usuarioID);
        string VerificaEstadoDoTurno(int usuarioID);
        int AbrirTurno(decimal saldoInicial);
        void FecharTurno(decimal SaldoTotal, decimal Informado, decimal SaldoVendas, decimal SaldoHospedagem, int CodTurno);
        IEnumerable<TurnosVendedoresViewModel> ListarTurnoVendedores(string criterios);
        IEnumerable<Turnos> ListarTurno();
        void ConfirmarTurno(int codCaixa, int codSuperVisor, int codTurno);

    }
}
