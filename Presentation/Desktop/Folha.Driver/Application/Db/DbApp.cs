using Folha.Domain.Interfaces.Application.Db;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Db;
using Folha.Domain.Models.Genericos;

namespace Folha.Driver.Application.Db
{
    public class DbApp : IDbApp
    {
        private readonly IDbRepository _dbRepository;

        public DbApp(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public void actualizarMovProdutos()
        {
            _dbRepository.actualizarMovProdutos();
        }

        public void ActualizarTabelas()
        {
            _dbRepository.ActualizarTabelas();
        }

        public DadosTemporarios BuscarDadosTemporarios()
        {
            return _dbRepository.BuscarDadosTemporarios();
        }

        public void RegistarConexao(ConexaoDTO conexaoDTO)
        {
            _dbRepository.RegistarConexao(conexaoDTO);
        }

        public void SalvarDadosTemporarios(DadosTemporarios dados)
        {
            _dbRepository.SalvarDadosTemporarios(dados);
        }

        public string TestarConexao()
        {
            return _dbRepository.TestarConexao();
        }
    }
}
