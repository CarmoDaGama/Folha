using Enterprise.Data;
using Enterprise.Data.Repository;
using Enterprise.Domain.Inventario;
using Enterprise.Framework.DTO.Db;
using Enterprise.Framework.Helpers;
using Enterprise.Repository.Contract.Inventario;
using System;
using System.Collections.Generic;
using System.Data;
using Enterprise.Framework.ViewModels.Inventario;

namespace Enterprise.Repository.Inventario
{
    public class TransProdutoRepository : RepositoryBase<DbDTO>, ITransProdutoRepository
    {
        public void Delete(TransProduto transProduto)
        {
            Conexao.ClienteSql.DELETE("TransferenciaProduto", "codigo ='" + transProduto.codigo + "'");
        }

        public void Insert(TransProduto transProduto)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "TransferenciaProduto",
                Campos = new string[] {
                    "CodDocumento",
                    "CodProduto",
                    "Qtidade",
                    "Origem",
                    "Destino",
                    "Codorigem",
                    "CodDestino",

                },
                Valores = new Object[] {
                    transProduto.CodDocumento,
                    transProduto.CodArtigo,
                    transProduto.Quantidade,
                    //transProduto.Origem,
                    //transProduto.Destino,
                    transProduto.Origem_texto,
                    transProduto.Destino_texto,
                    transProduto.CodOrigem,
                    transProduto.CodDestino,
                }

            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
        }

        public IEnumerable<TransferenciaProdutoViewModel> Lista(string criterios)
        {
           var obj = Conexao.ClienteSql.SELECT("SELECT  TransferenciaProduto.CodProduto as Codigo, Produtos.Descricao as Descricao, TransferenciaProduto.Qtidade as Qtidade, TransferenciaProduto.Origem as Origem, TransferenciaProduto.Destino as Destino From TransferenciaProduto Left Outer Join Produtos on TransferenciaProduto.Codigo = Produtos.Codigo");

            DataTable dtadados = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<TransferenciaProdutoViewModel>(dtadados);
            return result;

        }

        public List<TransProduto> Listar(string criterios, bool Pesquisa)
        {
            var obj = Conexao.ClienteSql.SELECT("SELECT  TransferenciaProduto.CodProduto as Codigo, Produtos.Descricao as Descricao, TransferenciaProduto.Qtidade as Qtidade, TransferenciaProduto.Origem as Origem, TransferenciaProduto.Destino as Destino From TransferenciaProduto Left Outer Join Produtos on TransferenciaProduto.Codigo = Produtos.Codigo");

            DataTable dtadados = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<TransProduto>(dtadados);
            return result;
        }

        public void Update(TransProduto transProduto, string criterios)
        {

            DbDTO dto = new DbDTO()
            {
                Nome = "TransferenciaProduto",
                Campos = new string[] {
                    "CodDocumento",
                    "CodProduto",
                    "Qtidade",
                    "Origem",
                    "Destino",
                    "Codorigem",
                    "CodDestino",

                },
                Valores = new Object[] {
                    transProduto.CodDocumento,
                    transProduto.CodArtigo,
                    transProduto.Quantidade,
                    transProduto.Origem_texto,
                    transProduto.Destino_texto,
                    transProduto.CodOrigem,
                    transProduto.CodDestino,
                }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "codigo ='" + criterios + "'");
        }
    }
}
