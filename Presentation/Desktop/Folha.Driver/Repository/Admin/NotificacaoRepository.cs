using Folha.Driver.Repository.Data;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.ViewModels.Admin;
using System.Data;
using Folha.Driver.Repository;
using Folha.Domain.Helpers;

namespace Folha.Driver.Repository.Admin
{
    public class NotificacaoRepository : RepositoryBase<DbDTO>, INotificacaoRepository
    {
        #region RepositoryBase
        public void Delete(NotificaoDocumentoViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public object Get(NotificaoDocumentoViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public object GetAll(NotificaoDocumentoViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public void Insert(NotificaoDocumentoViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public void Update(NotificaoDocumentoViewModel tabela)
        {
            throw new NotImplementedException();
        }

        #endregion
        public List<NotificaoDocumentoViewModel> ListarApagar(string Criterio)
        {
            //string SQL = "Select Documentos.Codigo from Documentos join Operacoes on Operacoes.Codigo= Documentos.CodOperacao and Operacoes.MovFin like 'DEBITO' and (Documentos.Estado = 'ABERTO' or Documentos.Estado = 'PENDENTE')";
            string SQL = "select count (Documentos.codigo) from Documentos join Operacoes on Operacoes.Codigo= Documentos.CodOperacao and Operacoes.MovFin like 'DEBITO' and (Documentos.Estado = 'ABERTO' or Documentos.Estado = 'PENDENTE')";

            object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtApagar = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<NotificaoDocumentoViewModel>(dtApagar);
            return result;
        }
        public List<NotificaoRuturaViewModel> ListarRotura(string Criterio)
        {
            string SQL = "Select*from ProdutoStock join Produtos on Produtos.codigo=ProdutoStock.CodProduto where qtde<1 and Produtos.status=1 and stockMin >0";
            object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtRutura = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<NotificaoRuturaViewModel>(dtRutura);
            return result;
        }
        public List<NotificaoDocumentoViewModel> ListarReceber(string Criterio)
        {
            string SQL = "Select Documentos.Codigo from Documentos join Operacoes on Operacoes.Codigo= Documentos.CodOperacao left Join Pagamentos on Pagamentos.CodDocumento=Documentos.Codigo where Pagamentos.CodDocumento is Null and Operacoes.MovFin like 'CREDITO' and Documentos.Total>0 and Documentos.Estado LIKE 'FECHADO'";
            object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtReceber = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<NotificaoDocumentoViewModel>(dtReceber);
            return result;
        }
        public List<NotificaoManutencaoViewModel> ListarManutencao(string Criterio)
        {

            string SQL = "Select PedidoManutencao.Codigo from PedidoManutencao  where  status=0";
            object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtManutencao = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<NotificaoManutencaoViewModel>(dtManutencao);
            return result;

        }
        public List<NotificaoTarefasViewModel> ListarTarefas(string Criterio)
        {
            string SQL = "Select Tarefas.Codigo from Tarefas  where  Estado=0 and CodUsuario='" + Criterio /*criterio será o codigo do usuario logado */ + "'";
            object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtTarefas = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<NotificaoTarefasViewModel>(dtTarefas);
            return result;
        }
        public List<NotificaoQuartoViewModel> ListarQuartos(string Criterio)
        {
            string SQL = "Select Habitacoes.Codigo from Habitacoes  where  Estado LIKE 'SUJO'";
            object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtQuarto = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<NotificaoQuartoViewModel>(dtQuarto);
            return result;
        }
        public List<NotificaoGraficoVendasViewModel> ListarGrafico(string Criterio)
        {
            throw new NotImplementedException();
        }

        public List<NotificaoQuartoViewModel> Backup(string Criterio)
        {
            throw new NotImplementedException();

        }

        public decimal TotalRotura()
        {
                DataTable DtDados = new DataTable();
                string SQL = "select (ProdutoStock.codigo) as total from ProdutoStock join Produtos on Produtos.codigo = ProdutoStock.CodProduto where qtde < 1 and Produtos.status = 1 and stockMin > 0";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                if (DtDados.Rows.Count == 0)
                return 0.0m;
                return Convert.ToDecimal(DtDados.Rows.Count);  
                
        }

        public decimal TotalPagar()
        {
            DataTable DtDados = new DataTable();
            string SQL = "select Total from Documentos join Operacoes on Operacoes.Codigo= Documentos.CodOperacao and Operacoes.MovFin like 'DEBITO' and (Documentos.Estado = 'ABERTO' or Documentos.Estado = 'PENDENTE')";
            var ob = Conexao.ClienteSql.SELECT(SQL);
            DtDados = (DataTable)ob;
            if (DtDados.Rows.Count == 0)
                return 0.0m;
            var totalPagar = UtilidadesGenericas.SomarTotal("Total", DtDados);
            return totalPagar;
        }

        public decimal TotalReceber()
        {
            DataTable DtDados = new DataTable();
            string SQL = "select Total from Documentos join Operacoes on Operacoes.Codigo = Documentos.CodOperacao left Join Pagamentos on Pagamentos.CodDocumento = Documentos.Codigo where Pagamentos.CodDocumento is Null and Operacoes.MovFin like 'CREDITO' and Documentos.Total > 0 and Documentos.Estado LIKE 'FECHADO'";
            var ob = Conexao.ClienteSql.SELECT(SQL);
            DtDados = (DataTable)ob;
            if (DtDados.Rows.Count == 0)
                return 0.0m;
            var totalPagar = UtilidadesGenericas.SomarTotal("Total", DtDados);
            return totalPagar;
        }
    }
}
