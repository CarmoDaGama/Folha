using Folha.Domain.Interfaces.Application.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.ViewModels.Genericos;
using Folha.Domain.Interfaces.Repository.Generico;

namespace Folha.Driver.Application.Genericos
{
    public class GenericoApp : IGenericoApp
    {
        private readonly IGenericoRepository _GenericoRepository;

        public GenericoApp(IGenericoRepository GenericoRepository)
        {
            _GenericoRepository = GenericoRepository;
        }

        public int BuscarCodigo(string Tabela, string Campo, string ParametroBusca)
        {
            return _GenericoRepository.BuscarCodigo(Tabela, Campo, ParametroBusca);
        }

        public GenericoViewModel GetDescricaoByCodigo(string Tabela, int Codigo)
        {
            return _GenericoRepository.GetDescricaoByCodigo(Tabela, Codigo);
        }

        public int LastCodGeral(string Tabela)
        {
            return _GenericoRepository.LastCodGeral(Tabela);
        }

        public bool VerificarRegisto(string Tabela, string Campo, string ParametroBusca)
        {
            return _GenericoRepository.VerificarRegisto(Tabela, Campo, ParametroBusca);
        }
    }
}
