using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Folha.Driver.Repository.Data;
using System.Data;

namespace Folha.Driver.Repository.Empresa
{
    using Folha.Domain.Models.Empresa;
    using Folha.Domain.Helpers;

    public class EmpresasRepository : IEmpresaRepository
    {
        public void Eliminar(List<Folha.Domain.Models.Empresa.Empresa> lista)
        {
            throw new NotImplementedException();
        }

        public void Editar(Folha.Domain.Models.Empresa.Empresa tabela)
        {
            try
            {
                 
        string tabelaEmpresa = "Empresa";
                string[] camposEmpresa = { "Nome", "NIF", "Morada", "Telefones", "WebSite", "Email", "Logotipo","Validou", "TipoEmpresa", "Responsavel", "Slogan" };
                Object[] valoresEmpresa = { tabela.Nome, tabela.NIF, tabela.Morada, tabela.Telefones, tabela.WebSite, tabela.Email, tabela.Logotipo, tabela.Validou, tabela.TipoEmpresa, tabela.Responsavel, tabela.Slogan };
                Conexao.ClienteSql.UPDATE(tabelaEmpresa, camposEmpresa, valoresEmpresa, "codigo='" + tabela.codigo + "'");
                
            }
            catch (Exception ex) { }
        }

        public void Gravar(Folha.Domain.Models.Empresa.Empresa tabela)
        {
            try
            {
                string tabelaEmpresa = "Empresa";
                string[] camposEmpresa = { "Nome", "NIF", "Morada", "Telefones", "WebSite", "Email", "Logotipo", "Validou", "TipoEmpresa", "Responsavel", "Slogan" };
                Object[] valoresEmpresa = { tabela.Nome, tabela.NIF, tabela.Morada, tabela.Telefones, tabela.WebSite, tabela.Email, tabela.Logotipo, tabela.Validou, tabela.TipoEmpresa, tabela.Responsavel, tabela.Slogan };
                Conexao.ClienteSql.INSERT(tabelaEmpresa, camposEmpresa, valoresEmpresa);
            }
            catch (Exception ex) { }
        }

        public List<Folha.Domain.Models.Empresa.Empresa> Listar()
        {
            List<Empresa> Empresa = new List<Empresa>();
            try
            {
                String SQL = "SELECT * From Empresa";
                object obj = Conexao.ClienteSql.SELECT(SQL);
                DataTable dtFornmas = (DataTable)obj;

                Empresa = DataTableHelper.DataTableToList<Empresa>(dtFornmas);
                return Empresa;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

    }
}
