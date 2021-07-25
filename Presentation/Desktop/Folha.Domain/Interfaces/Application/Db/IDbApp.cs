using Folha.Domain.Models.Genericos;
using Folha.Domain.Models.Db;

namespace Folha.Domain.Interfaces.Application.Db
{
    public  interface IDbApp
    {
        DadosTemporarios BuscarDadosTemporarios();
        void SalvarDadosTemporarios(DadosTemporarios dados);
        string TestarConexao();
        void ActualizarTabelas();
        void RegistarConexao(ConexaoDTO conexaoDTO);
        void actualizarMovProdutos();
    }
}
