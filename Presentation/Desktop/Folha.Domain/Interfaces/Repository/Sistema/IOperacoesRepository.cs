using Folha.Domain.Models.Sistema;
using Folha.Domain.ViewModels.Sistema;
using Folha.Domain.ViewModels.Frame.Sistema;
using System;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Sistema
{
    public interface IOperacoesRepository : IRepositoryBase<OperacoesViewModel>
    {
        OperacoesViewModel GetOperacaPorNome(string Nome);
        OperacoesViewModel GetByApp(string app);
        int GetCodigoOperacaPorNome(string Nome);
        void GravaOperacao(string Nome, string MovStock, string MovFinanceiro, string App, string Entidade, int Pos, int Hotel, int Restaurante, int Cyber, int Escolar, int Hospitalar, int RH, int PT, int LAV, int Viagem);
        void CriaOperacoesIniciais();
        List<Operacoes> ListarOperacoes();
        void Mostra_Operacoes_PorCodigo(Guid documentoID);
        List<OperacaoViewModel> DocumentosPorUsuarios(string _TiposDocumentos, int usuarioID, bool admin);
        bool VerificarDuplicacaoDoRegistro(string Nometabela, Dictionary<string, object> dicionario);
    }
}
