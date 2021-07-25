using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Financeiro;
using System.Data;
using Folha.Driver.Repository.Data;
using Folha.Domain.ViewModels.Financeiro;

namespace Folha.Driver.Repository.Financeiro
{
    public class MoedaRepository : RepositoryBase<DbDTO>, IMoedaRepository
    {
        IEnumerable<MostraMoedasViewModel> IMoedaRepository.Listar()
        {
            var result = new List<MostraMoedasViewModel>();
            string SQL = "Select *,moedapadrao as Padrao  from Moedas";
            Object ob = Conexao.ClienteSql.SELECT(SQL);
            try
            {
                result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<MostraMoedasViewModel> ((DataTable)ob);
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar a Lista de Moedas\n");
            }


            return result;
        }
        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }
        public void Delete(Moedas tabela)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Moedas",
                Campos = new string[] { "Codigo", "Sigla" },
                Valores = new Object[] { tabela.codigo, tabela.Sigla}

            };
            Conexao.ClienteSql.DELETE("Moedas", "Codigo ='" +tabela.codigo + "'");
        }

        public object Get(Moedas tabela)
        {
            throw new NotImplementedException();
        }

        public object GetAll(Moedas tabela)
        {
            throw new NotImplementedException();
        }

        public void Insert(Moedas entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Moedas",
                Campos = new string[] { "Descricao","Sigla","moedapadrao" },
                Valores = new Object[] { entity.Descricao,entity.Sigla,entity.moedapadrao }
            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
        }

        public void Update(Moedas tabela)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Moedas",
                Campos = new string[] { "Descricao","Sigla", "moedapadrao" },
                Valores = new Object[] { tabela.Descricao,tabela.Sigla,tabela.moedapadrao }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + tabela.codigo + "'");
        }

        

        public IEnumerable<Moedas> ListarCriterio(string criterios)
        {
            var result = new List<Moedas>();

   
            string[] tabelas = { "Moedas" };
            string[] campos = { "Codigo", "Descricao", "Sigla", "moedapadrao" };
            string[] cri = { "Sigla = '" + criterios + "'" };

            Object ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);
            try
            {
                result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Moedas>((DataTable)ob);
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar a Lista de Moedas\n");
            }


            return result;
        }

        public IEnumerable<Moedas> ListarMoedaCambio()
        {
            var result = new List<Moedas>();
            string sql = "select sigla from moedas join cambios on moedas.Codigo = cambios.Moeda2 where Cambios.estado=1 order BY moedas.Descricao";

            Object ob = (DataTable)Conexao.ClienteSql.SELECT(sql);
            try
            {
                result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Moedas>((DataTable)ob);
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar Sigla Câmbio\n");
            }

            return result;
        }

        public void UpdateMoedaPadrao(Moedas Dados)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Moedas",
                Campos = new string[] {"moedapadrao" },
                Valores = new Object[] { Dados.moedapadrao }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + Dados.codigo + "'");
        }
    }
    }

