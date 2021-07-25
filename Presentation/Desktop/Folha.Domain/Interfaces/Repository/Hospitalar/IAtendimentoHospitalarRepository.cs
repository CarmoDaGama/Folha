using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Hospitalar;
using System;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Hospitalar
{
    public interface IAtendimentoHospitalarRepository
    {
        MotivoIsencao GetMotivoPorIdInternamento(int codInternamento);
        MotivoIsencao GetMotivoPorIdExame(int codExame);
        MotivoIsencao GetMotivoPorIdConsulta(int codConsulta);
        bool TemConsultasPorFacturar(int atendimentoId);
        bool TemInternamentoPorFacturar(int codAntendimnto);
        bool TemExamesPorFacturar(int atendimentoId);
        bool GetEstadoAtendimento(int codAtendimento);
        void FecharAtendimento(AtendimentoHospitalar Dados);
        InternaViewModel GetInternamentoPorIdAtendimento(int codInternamento);
        List<InternaViewModel> ListarInternamentoPorIdAtendimento(int codAntendimnto);
        ConsultaViewModel GetConsultaPorIdAtendimento(int codConsulta);
        ExameViewModel GetExamePorIdAtendimento(int codExame);
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
        PacienteInternadoViewModel GravarInternado(PacienteInternadoViewModel paciente);
        void DeleteInternado(PacienteInternado paciente);
        void UpdatePaciente(PacienteInternado entity);
        IEnumerable<PacienteInternado> ListarInternado(string paciente);
        IEnumerable<TiposQuartosHospitalarViewModel> ListaTipoQuarto(string criterios);
        IEnumerable<TarifaHospitalarViewModel> ListaTarifa(int criterios);
        IEnumerable<QuartosHospitalarViewModel> ListaQuarto(int criterios);
        IEnumerable<CamasQuartosHospitalarViewModel> ListaCama(int codQuartos);
        IEnumerable<PacienteInternado> ListarTudo(string paciente);
        List<CamasQuartosHospitalarViewModel> GetCamas(int codQuartos);
        List<PacienteInternado> ListaNova(int Codigo);
        object GetCodLast(int criterio);
        object BuscarUltimoRegistro(int Codigo);
        decimal Total(string criterio);
        List<PacienteInternado> DatasInternamento (DateTime Data);
        
        //
        IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentosSemFiltro();
        IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentosComFiltro(string valor, string dtInicial, string dtFim);
        IEnumerable<PacienteInternado> ListarInternadoSemFiltro();
        IEnumerable<PacienteInternado> FiltrarPacienteInternado(string valor, string dtInicoEst, string dtFim);
        //
    }
}
