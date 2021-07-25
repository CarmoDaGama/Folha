using Folha.Domain.Models.Genericos;
using Folha.Domain.Models.Db;

namespace Folha.Domain.Interfaces.Repository.Db
{
   public interface IDbRepository
    {
        DadosTemporarios BuscarDadosTemporarios();
        void SalvarDadosTemporarios(DadosTemporarios dados);
        void RegistarConexao(ConexaoDTO conexaoDTO);
        string TestarConexao();
        void ActualizarTabelas();
        void actualizarMovProdutos();
    }
}
