using Folha.Domain.Interfaces.Repository.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.ViewModels.Genericos;
using Folha.Driver.Repository.Data;
using System.Data;

namespace Folha.Driver.Repository.Genericos
{
    public class GenericoRepository : IGenericoRepository
    {
        public bool VerificarRegisto(string Tabela,string Campo,string ParametroBusca)
        {
            return Conexao.VerificarRegisto(Tabela, Campo, ParametroBusca);
        }
        public int BuscarCodigo(string Tabela, string Campo, string ParametroBusca)
        {
            return Conexao.BuscarCodigo(Tabela, Campo, ParametroBusca);
        }
        public GenericoViewModel GetDescricaoByCodigo(string Tabela,int Codigo)
        {
            var result = new GenericoViewModel();
            DataTable dtGenerico = new DataTable();
            try
            {
                //result.Codigo = int.Parse(dtGenerico.Rows[0][0].ToString());
                result.Descricao = Conexao.BuscarDescricaoPorCodigo(Tabela, Codigo.ToString());
                
            }
            catch (Exception)
            {
            }
            return result;
        }

        public int LastCodGeral(string Tabela)
        {
            return Conexao.LastCodGeral(Tabela);
        }
    }
}
