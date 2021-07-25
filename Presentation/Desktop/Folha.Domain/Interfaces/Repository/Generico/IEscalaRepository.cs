using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.Genericos;
using Folha.Domain.ViewModels.Genericos;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Generico
{
    public interface IEscalaRepository : IRepositoryBase<EscalaViewModel>
    {
        List<DiasSemana01ViewModel> CarregarDiasSemana();
        void Insert(Escala Dados);
        void Update(Escala Dados);
        IEnumerable<Escala> Listar(string Descricao);
        IEnumerable<DiasSemana> ListDiasSemana();
        IEnumerable<EscalaConfig01ViewModel> ListEscalaConfig(string CodEscala);
        IEnumerable<EscalaConfig01ViewModel> ListEscalaDisponivel(string CodDia, string HoraInicial);

        //_______________________________
        Escala Gravar(Escala escala);
        Escala Eliminar(Escala escala);
        EscalaViewModel GetById(int codigo);
        List<EscalaConfigViewModel> GetEscalaConfig(int codigo);
        void DeleteEscalaConfig(EscalaConfigViewModel delete);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        void Apagar(EscalaViewModel apagar);
        void UpdateHora(Escala var);

        int HoraTrabalho(int Codigo);

    }
}
