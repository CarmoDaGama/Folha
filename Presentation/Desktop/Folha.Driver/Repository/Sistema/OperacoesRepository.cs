using System;
using System.Data;
using System.Collections.Generic;
using Folha.Domain.Models.Sistema;
using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Sistema;
using Folha.Domain.ViewModels.Frame.Sistema;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Sistema;
using System.Linq;

namespace Folha.Driver.Repository.Data.Repositories.Sistema
{
    public class OperacoesRepository: RepositoryBase<DbDTO>, IOperacoesRepository
    {
        public void GravaOperacao(string Nome, string MovStock, string MovFinanceiro, string App, string Entidade, int Pos, int Hotel, int Restaurante, int Cyber, int Escolar, int Hospitalar, int RH, int PT, int LAV, int Viagem)
        {
            string Sql1 = "SELECT Codigo from Operacoes where Nome Like '" + Nome + "'";
            object a = Conexao.ClienteSql.SELECT(Sql1);
            object ob = (DataTable)a;
            DataTable dt = (DataTable)ob;
            string[] campos = { "Nome", "MovStk", "MovFin", "App", "Entidade", "Pos", "Hotel", "Restaurante", "Cyber", "Escolar", "Hospitalar", "RH", "PT", "LAV", "Viagem", "Sistema" };
            Object[] valores = { Nome, MovStock, MovFinanceiro, App, Entidade, Pos, Hotel, Restaurante, Cyber, Escolar, Hospitalar, RH, PT, LAV, Viagem, 1 };
            if (dt.Rows.Count == 0)
            {
                Conexao.ClienteSql.INSERT("Operacoes", campos, valores);
            }
            else
            {
                string Criterio = "Codigo='" + dt.Rows[0]["Codigo"].ToString() + "'";

                Conexao.ClienteSql.UPDATE("Operacoes", campos, valores, Criterio);

            }
        }

        public void CriaOperacoesIniciais()
        {
            GravaOperacao("VENDA A DINHEIRO ", "DEBITO", "CREDITO", "VD", "CLIENTE", 1, 1, 1, 0, 0, 0, 0, 0, 0, 0);  //Venda
            GravaOperacao("FACTURA", "DEBITO", "CREDITO", "FT", "CLIENTE", 1, 1, 1, 0, 0, 0, 0, 0, 0, 0);  //enda V
            GravaOperacao("RESERVA", "ISENTO", "ISENTO", "RES", "CLIENTE", 0, 1, 0, 0, 0, 0, 0, 0, 0, 0);
            GravaOperacao("HOSPEDAGEM", "DEBITO", "CREDITO", "HOS", "CLIENTE", 0, 1, 0, 0, 0, 0, 0, 0, 0, 0);   // Venda
            GravaOperacao("ACESSO A COMPUTADOR", "DEBITO", "CREDITO", "ADM", "CLIENTE", 0, 0, 0, 1, 0, 0, 0, 0, 0, 0);
            GravaOperacao("FACTURA PROFORMA", "ISENTO", "ISENTO", "FP", "CLIENTE", 1, 1, 1, 1, 0, 0, 0, 0, 0, 0);
            GravaOperacao("ORÇAMENTO", "ISENTO", "ISENTO", "ADM", "CLIENTE", 1, 1, 1, 1, 0, 0, 0, 0, 0, 0);
            GravaOperacao("ACERTO DE STOCK (ENTRADA)", "CREDITO", "ISENTO", "ASE", "ISENTO", 1, 1, 1, 1, 0, 0, 0, 0, 1, 0);
            GravaOperacao("ACERTO DE STOCK (SAIDA)", "DEBITO", "ISENTO", "ASS", "ISENTO", 1, 1, 1, 1, 0, 0, 0, 0, 1, 0);
            GravaOperacao("COMPRA A FORNECEDOR", "CREDITO", "DEBITO", "CF", "FORNECEDOR", 1, 1, 1, 0, 0, 0, 0, 0, 1, 0);
            GravaOperacao("REQUISIÇAÕ DE ARTIGOS", "ISENTO", "ISENTO", "ADM", "ISENTO", 1, 1, 1, 1, 0, 0, 0, 0, 0, 0);
            GravaOperacao("FOLHA DE OBRA INTERNA", "DEBITO", "DEBITO", "ADM", "FORNECEDOR", 1, 1, 1, 1, 0, 0, 0, 0, 0, 0);
            GravaOperacao("TRANSFERENCIA DE PRODUTO", "ISENTO", "ISENTO", "TP", "ISENTO", 1, 1, 1, 0, 0, 0, 0, 0, 1, 0);
            GravaOperacao("CONTAGEM DE PRODUTOS", "ISENTO", "ISENTO", "CP", "ISENTO", 1, 1, 1, 0, 0, 0, 0, 0, 1, 0);
            GravaOperacao("FOLHA DE SALÁRIO", "ISENTO", "DEBITO", "FS", "FUNCIONARIO", 0, 0, 0, 0, 0, 0, 1, 0, 0, 0);
            GravaOperacao("PAGAMENTO DE EMOLUMENTOS", "ISENTO", "CREDITO", "PE", "CLIENTE", 0, 0, 0, 0, 1, 0, 0, 0, 0, 0);
            GravaOperacao("ORDEM DE SAQUE", "ISENTO", "CREDITO", "ADM", "CLIENTE", 1, 1, 1, 1, 0, 0, 0, 0, 0, 0);
            GravaOperacao("ORDEM DE SERVIÇO", "DEBITO", "CREDITO", "OS", "CLIENTE", 0, 0, 0, 1, 0, 0, 0, 0, 0, 0);
            GravaOperacao("NOTA DE PAGAMENTO", "ISENTO", "DEBITO", "NP", "CLIENTE", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            GravaOperacao("RECIBO", "ISENTO", "CREDITO", "REC", "CLIENTE", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
            GravaOperacao("GUIA DE ENTREGA", "DEBITO", "ISENTO", "GE", "CLIENTE", 1, 1, 1, 1, 0, 0, 0, 0, 0, 0);
            GravaOperacao("MATRICULA/CONFIRMAÇÃO", "ISENTO", "ISENTO", "M/C", "ISENTO", 0, 0, 0, 0, 1, 0, 0, 0, 0, 0);
            GravaOperacao("CONTRATO DE ELECTRICIDADE", "ISENTO", "CREDITO", "CE", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 1, 0, 0);
            GravaOperacao("PAGAMENTO DE MENSALIDADE", "ISENTO", "CREDITO", "PM", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 1, 0, 0);
            GravaOperacao("TRANSFERÊNCIA DE VALOR", "ISENTO", "ISENTO", "TV", "CLIENTE", 1, 1, 1, 1, 1, 1, 1, 1, 1, 0);
            GravaOperacao("TRANSFERENCIA DE PRODUTO(ENTRADA)", "CREDITO", "ISENTO", "TPE", "ISENTO", 1, 1, 1, 0, 0, 0, 0, 0, 1, 0);
            GravaOperacao("TRANSFERENCIA DE PRODUTO(SAIDA)", "DEBITO", "ISENTO", "TPS", "ISENTO", 1, 1, 1, 0, 0, 0, 0, 0, 1, 0);
            GravaOperacao("REAJUSTE DE STOCK", "ISENTO", "ISENTO", "RS", "ISENTO", 1, 1, 1, 0, 0, 0, 0, 0, 1, 0);
            GravaOperacao("FACTURA RECIBO", "ISENTO", "ISENTO", "ADM", "FR", 1, 1, 1, 1, 0, 0, 0, 0, 0, 0);
            GravaOperacao("SERVIÇOS DE LAVANDARIA", "DEBIDO", "CREDITO", "SL", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 1, 0);
            GravaOperacao("CONTRATO DE TRANSPORTE", "ISENTO", "ISENTO", "CT", "ISENTO", 0, 0, 0, 0, 1, 0, 0, 0, 0, 0);
            GravaOperacao("PAGAMENTO DE TRANSPORTE", "ISENTO", "ISENTO", "PT", "ISENTO", 0, 0, 0, 0, 1, 0, 0, 0, 0, 0);

            GravaOperacao("SOLICITAÇÃO DE VISTOS", "ISENTO", "CREDITO", "SV", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            GravaOperacao("REGULARIZAÇÃO DE DOCUMENTOS", "ISENTO", "CREDITO", "RD", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            GravaOperacao("DESPACHO ALFANDEGARIO", "ISENTO", "CREDITO", "DA", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            GravaOperacao("VENDA DE BILHETE DE PASSAGEM", "ISENTO", "CREDITO", "VB", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            GravaOperacao("PACOTES TURISTICOS", "ISENTO", "CREDITO", "PT", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            GravaOperacao("IMPORTAÇÃO E EXPORTAÇÃO", "ISENTO", "CREDITO", "I&E", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            GravaOperacao("SEGURO DE VIAGEM", "ISENTO", "CREDITO", "SV", "CLIENTE", 0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
        }

        public List<Operacoes> ListarOperacoes()
        {
            DataTable DtDados = new DataTable();
            string[] tabelas = { "Operacoes" };
            string[] campos = { "Codigo", "Nome", "MovStk", "MovFin", "Descricao", "Entidade", "SISTEMA" };
            Object ob = Conexao.ClienteSql.SELECT(tabelas, campos, null);
            try
            {
                DtDados = (DataTable)ob;

                var result = new List<Operacoes>();

                return result;
            }
            catch (Exception) {  throw new Exception ("Erro a Carregar as Operacoes\n" + (string)ob); }

        }

        public void Mostra_Operacoes_PorCodigo(Guid documentoID)
        {
            DataTable DtDados = new DataTable();
            string[] campos = { "Codigo", "Nome", "MovStk", "MovFin", "Descricao", "Entidade", "Sistema" };
            string[] tabelasTodos = { "Operacoes" };
            string[] criterioTodos = { "Codigo='" + documentoID + "'" };
            try
            {
                Object obj = Conexao.ClienteSql.SELECT(tabelasTodos, campos, criterioTodos);
                DtDados = (DataTable)obj;

                //_CodOperacao = int.Parse(DtDados.Rows[0][0].ToString());
                //_Nome = DtDados.Rows[0][1].ToString();
                //_MovStk = DtDados.Rows[0][2].ToString();
                //_MovFin = DtDados.Rows[0][3].ToString();
                //_Descricao = DtDados.Rows[0][4].ToString();
                //_Entidade = DtDados.Rows[0][5].ToString();
                //_Sistema = DtDados.Rows[0][6].ToString();
            }
            catch (Exception msg)
            {
                throw new Exception("Operação Não Encontrada" + msg.Message);

            }
        }
        public class CriteriosOperacoes
        {
            public string MovStk { get; set; }
            public int Codigo { get; set; } = -1;
        }
        public List<OperacaoViewModel> DocumentosPorUsuarios(string _TiposDocumentos, int usuarioID, bool admin)
        {
            DataTable DtOperacoes = new DataTable();
            List<OperacaoViewModel> result = new List<OperacaoViewModel>();
            CriteriosOperacoes ParmCriterios = new CriteriosOperacoes();

            try
            {
                DataTable dtAplicacoes = new DataTable();
                dtAplicacoes.Columns.Add("Aplicativo");

                string Criterios = "";
                if (!string.IsNullOrEmpty(_TiposDocumentos))
                {
                    if (admin)
                    {
                        //And AcessoDocumentos.CodUsuario='" + usuarioID + "' and Operacoes." + Criterios + "";
                        if (_TiposDocumentos == "ENTRADAS")
                            ParmCriterios.MovStk = "CREDITO";
                            //Criterios = "and Operacoes.MovStk='CREDITO' And AcessoDocumentos.CodUsuario='" + usuarioID + "'";
                        if (_TiposDocumentos == "SAIDAS")
                            ParmCriterios.MovStk = "DEBITO";
                        //Criterios = "and Operacoes.MovStk='DEBITO' And AcessoDocumentos.CodUsuario='" + usuarioID + "'";
                        if (_TiposDocumentos == " and FINANCEIRO ")
                            ParmCriterios.Codigo = 0;
                            //Criterios = "and Operacoes.Codigo <>'0' And AcessoDocumentos.CodUsuario='" + usuarioID + "'";
                    }
                    else
                    {
                        if (_TiposDocumentos == "ENTRADAS")
                            Criterios = "and MovStk='CREDITO'";
                        if (_TiposDocumentos == "SAIDAS")
                            Criterios = "and MovStk='DEBITO'";
                        if (_TiposDocumentos == " and FINANCEIRO")
                            Criterios = "and Codigo <>'0'";
                    }
                }

                string descritivo = "";



                for (int i = 0; i < dtAplicacoes.Rows.Count; i++)
                {
                    descritivo += "Operacoes." + dtAplicacoes.Rows[i]["Aplicativo"].ToString() + "=1  " + Criterios + " Or ";
                }


                descritivo = Folha.Domain.Helpers.Strings.Left(descritivo, descritivo.Length - 3);

            

                if (admin)
                {
                    Criterios += " and AcessoDocumentos.CodUsuario='" + usuarioID + "'";
                }

                Criterios += " order by Operacoes.Nome";

                if (admin)
                {
                    string SQL = "SELECT AcessoDocumentos.Codigo as AcessoDocumentoId, AcessoDocumentos.CodOperacao as OperacaoId, Operacoes.Nome as Descricao, Operacoes.Entidade As Entidade  from AcessoDocumentos join Operacoes on ";
                    SQL += "Operacoes.Codigo=AcessoDocumentos.CodOperacao where " + Criterios + "";
                    object selectResult = Conexao.ClienteSql.SELECT(SQL);
                    DtOperacoes = (DataTable)selectResult;
                }

                else
                {
                    DtOperacoes = Conexao.BuscarTabela_com_Criterio("Operacoes", Criterios);
                }

                result = DataTableHelper.DataTableToList<OperacaoViewModel>(DtOperacoes);

                return result;


            }
            catch (Exception a)
            {
                throw new Exception(a.Message);
            }


        }
        public int GetCodigoOperacaPorNome(string Nome)
        {
            string criterio = " WHERE Nome LIKE '" + Nome.Trim() + "'";
            DataTable tabelaOperacoes = (DataTable)Conexao.ClienteSql.SELECT("Select * From Operacoes" + criterio);
            if (tabelaOperacoes.Rows.Count <= 0)
            {
                return 0;
            }
            return Convert.ToInt32(tabelaOperacoes.Rows[0]["codigo"]);
        }
        public OperacoesViewModel GetOperacaPorNome(string Nome)
        {
            string criterio = " WHERE Nome LIKE '" + Nome + "'";
            DataTable tabelaOperacoes = (DataTable)Conexao.ClienteSql.SELECT("Select * From Operacoes" + criterio);

            return (OperacoesViewModel)Get(new OperacoesViewModel() { codigo = GetCodigoOperacaPorNome(Nome)});
        }
        #region CRUD GENERICO
        public void Delete(OperacoesViewModel operacao)
        {
            Db.Delete(operacao);
        }

        public object Get(OperacoesViewModel operacao)
        {
            return Db.GetById<OperacoesViewModel>(operacao.codigo);
        }
        public OperacoesViewModel GetByApp(string app)
        {
            return Db.GetEntities<OperacoesViewModel>("WHERE APP ='" + app + "'").FirstOrDefault();
        }

        public object GetAll(OperacoesViewModel operacao)
        {
            return Db.GetEntities<OperacoesViewModel>();
        }

        public void Insert(OperacoesViewModel operacao)
        {
            Db.Add(operacao);
        }

        public void Update(OperacoesViewModel operacao)
        {
            Db.Update(operacao);
        }
        #endregion
    }
}
