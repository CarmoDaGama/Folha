using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Hospitalar
{
    public interface IInternamentoRepository : IRepositoryBase <MovHospitalarViewModel>
    {
        int GetCodigoInternamento(int codigo);
        MovHospitalarViewModel LerMovHospi(MovHospitalarViewModel hospital);
        MovHospitalarViewModel Gravar(MovHospitalarViewModel hospital);
        IEnumerable<TiposQuartosHospitalarViewModel> ListaTipoQuarto(string criterios);
        IEnumerable<TarifaHospitalarViewModel> ListaTarifa(int criterios);
        IEnumerable<QuartosHospitalarViewModel> ListaQuarto(int criterios);
        IEnumerable<MovHospitalar> Listar(string criterios);
        IEnumerable<PacienteInternado> ListarInternado(string paciente);
        IEnumerable<PacienteInternado> ListarTudo(string paciente);
        IEnumerable<Pagamentos> Listarpagamentos(string documento);
        List<CamasQuartosHospitalarViewModel> GetCamas(int codQuartos);
        PacienteInternadoViewModel GravarInternado(PacienteInternadoViewModel paciente);
        void DeleteInternado(PacienteInternado paciente);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        void Delete(MovHospitalar hospital);
        decimal Preco(string paciente);
        decimal Pago(string paciente);
        void Update(PacienteInternado entity);

    }
}
