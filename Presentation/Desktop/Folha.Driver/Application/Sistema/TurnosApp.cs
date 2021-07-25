using Folha.Domain.Interfaces.Application.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.ViewModels.Frame.Sistema;
using Folha.Domain.Interfaces.Repository.Sistema;
using Folha.Domain.Models.Sistema;
using Folha.Domain.ViewModels.Sistema;
using Folha.Domain.Helpers;

namespace Folha.Driver.Application.Sistema
{
    public class TurnosApp : ITurnosApp
    {
        private readonly ITurnosRepository _TurnosRepository;
        public TurnosApp(ITurnosRepository TurnosRepository)
        {
            _TurnosRepository = TurnosRepository;
        }
        public void CarregarTurnoCurrent()
        {
            if (VerificaEstadoDoTurno(UtilidadesGenericas.UsuarioCodigo) == "ABERTO")
            {
                UtilidadesGenericas.EstadoTurnoSistema = true;
                UtilidadesGenericas.CodigoTurno = BuscaCodigoTurno(UtilidadesGenericas.UsuarioCodigo);
            }
        }
        public int AbrirTurno(decimal saldoInicial)
        {
            return _TurnosRepository.AbrirTurno(saldoInicial);
        }

        public int BuscaCodigoTurno(int usuarioID)
        {
            return _TurnosRepository.BuscaCodigoTurno(usuarioID);
        }

        public void ConfirmarTurno(int codCaixa, int codSuperVisor, int codTurno)
        {
            _TurnosRepository.ConfirmarTurno(codCaixa, codSuperVisor, codTurno);   
        }

        public bool ContemTurnosComCaixasNulos(int codTurno)
        {
            return _TurnosRepository.ContemTurnosComCaixasNulos(codTurno);
        }

        public void FecharTurno(decimal SaldoTotal, decimal Informado, decimal SaldoVendas, decimal SaldoHospedagem, int CodTurno)
        {
            _TurnosRepository.FecharTurno(SaldoTotal,Informado,SaldoVendas, SaldoHospedagem,CodTurno);
        }

        public TurnosViewModel GetById(int codigoTurno)
        {
            return (TurnosViewModel)_TurnosRepository.Get(new TurnosViewModel() { codigo = codigoTurno });
        }

        public IEnumerable<TurnosVendedoresViewModel> ListarTurnoVendedores(string criterios)
        {
            return _TurnosRepository.ListarTurnoVendedores(criterios);
        }


        public IEnumerable<Turnos> ListarTurno()
        {
            return _TurnosRepository.ListarTurno();
        }

        public string VerificaEstadoDoTurno(int usuarioID)
        {
            return _TurnosRepository.VerificaEstadoDoTurno(usuarioID);
        }
    }
}
