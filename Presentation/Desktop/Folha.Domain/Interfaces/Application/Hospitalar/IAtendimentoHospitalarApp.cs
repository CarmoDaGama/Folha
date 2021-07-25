using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Hospitalar;
using System;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Hospitalar
{
    public interface IAtendimentoHospitalarApp
    {
        MotivoIsencao GetMotivoIsencao(string tipo, int codItem);
        bool TemItensPorFacturar(int codAtendimento);
        bool GetEstadoAtendimento(int codAtendimento);
        void FecharAtendimento(AtendimentoHospitalar Dados); 
        ItemAtendimentoFacturaViewModel GetItemFactura(string tipo, int codItem);
        List<ItemAtendimentoFacturaViewModel> ListarItensAtendimento(int atendimentoId);
        List<ExameViewModel> ListarExamesPorIdAtendimento(int atendimentoId);
        List<ConsultaViewModel> ListasConsultasPorIdAtendimento(int atendimentoId);
        List<AtendimentoDocViewModel> ListarAtendimentosNãoFacturadosPorUsuario(int usuarioId, int pacienteId);
        void Insert(AtendimentoHospitalar Dados);
        void Update(AtendimentoHospitalar Dados);
        void InsertExames(List<ExamesAtendimento> Lista);
        void DeleteExames(List<ExamesAtendimento> Lista);
        IEnumerable<ExamesAtendimento> CarregaExames(string CodPaciente, string data);
        IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentos(string dtInicio, string dtFim, string CodPaciente);
        IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentosRecepcao(string CodPaciente);


        IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentosSemFiltro(string valor, string dtInicial, string dtFim);
        IEnumerable<AtendimentoHospitalarGraficViewModel> TotalAtendimento(string dataInicial, string dataFinal, bool faturado);
        //____________________________________
        IEnumerable<PacienteInternado> ListarInternado(string paciente);
        PacienteInternadoViewModel GravarInternado(PacienteInternadoViewModel paciente);
        void DeleteInternado(PacienteInternado paciente);
        void UpdatePaciente(PacienteInternado entity);
        IEnumerable<TiposQuartosHospitalarViewModel> ListaTipoQuarto(string criterios);
        IEnumerable<TarifaHospitalarViewModel> ListaTarifa(int criterios);
        IEnumerable<QuartosHospitalarViewModel> ListaQuarto(int criterios);
        IEnumerable<CamasQuartosHospitalarViewModel> ListaCama(int codQuartos);
        decimal Total(string criterio);
        List<CamasQuartosHospitalarViewModel> GetCamas(int codQuartos);
        List<PacienteInternado> ListaNova(int Codigo);
        int GetCodLast(int criterio);
        int BuscarUltimoRegistro(int Codigo);
        List<PacienteInternado> DatasInternamento(DateTime Data);
        IEnumerable<PacienteInternado> ListarTudo(string paciente);

        //
        IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentosSemFiltro();
        IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentosComFiltro(string valor, string dtInicial, string dtFim);
        IEnumerable<PacienteInternado> ListarInternadoSemFiltro();
        IEnumerable<PacienteInternado> FiltrarPacienteInternado(string valor, string dtInicoEst, string dtFim);
        //
    }
}
