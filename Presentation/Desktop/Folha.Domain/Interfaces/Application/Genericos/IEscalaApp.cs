using Folha.Domain.Models.Genericos;
using Folha.Domain.ViewModels.Genericos;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Genericos
{
    public interface IEscalaApp
    {
        IEnumerable<Escala> Listar(string Descricao);
        IEnumerable<DiasSemana> ListDiasSemana();
        IEnumerable<EscalaConfig01ViewModel> ListEscalaConfig(string CodEscala);
        IEnumerable<EscalaConfig01ViewModel> ListEscalaDisponivel(string CodDia, string HoraInicial);
        List<DiasSemana01ViewModel> CarregarDiasSemana();

        //_______________________________
        Escala Gravar(Escala escala);
        Escala Eliminar(Escala escala);
        EscalaViewModel GetById(int codigo);
        List<EscalaConfigViewModel> GetEscalaConfig(int codigo);
        void DeleteEscalaConfig(EscalaConfigViewModel delete);
        void Apagar (EscalaViewModel apagar);
        void UpdateHora(Escala var);

        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);

        int HoraTrabalho (int Codigo);

    }
}
