using System;
using System.Collections.Generic;
using System.Data;
using Folha.Domain.Models.Inventario;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Documentos;
using Folha.Domain.ViewModels.Frame.Documentos;
using Folha.Domain.Helpers;
using System.Linq;
using Folha.Domain.Models.Financeiro;

namespace Folha.Driver.Repository.Data.Repositories.Documentos
{
    using Folha.Domain.Models.Documentos;
    using Folha.Domain.ViewModels.Documentos;
    using Folha.Domain.ViewModels.Financeiro;
    using Folha.Domain.ViewModels.Report;
    using Folha.Domain.ViewModels.Sistema;

    public class DocumentosRepository : RepositoryBase<DbDTO>, IDocumentosRepository
    {
        private string Mascara;

        public bool LerDocumento(int CodOperacao, int CodArea, int CodMesa)
        {
            int DocAberto = 0;
            try
            {
                DataTable DtDados = new DataTable();

                string SQl = "Select Codigo from Documentos where CodOperacao='" + CodOperacao + "' and CodUsuario='" +
                             UtilidadesGenericas.UsuarioCodigo + "' And ESTADO='ABERTO' And CodArea='" + CodArea.ToString() +
                             "' and CodMesa='" + CodMesa + "'";
                Object ob = Conexao.ClienteSql.SELECT(SQl);
                DtDados = (DataTable)ob;

                if (DtDados.Rows.Count > 0)
                {
                    DocAberto = int.Parse(DtDados.Rows[DtDados.Rows.Count - 1][0].ToString());

                    return DocAberto == 1;
                }

            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }

            return false;
        }
        public IEnumerable<Folha.Domain.Models.Documentos.Documentos> DocumentosPorUsuarios(string _TiposDocumentos, int usuarioID, bool admin)
        {
            DataTable DtOperacoes = new DataTable();
            List<Folha.Domain.Models.Documentos.Documentos> result = new List<Folha.Domain.Models.Documentos.Documentos>();

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
                            Criterios = "and Operacoes.MovStk='CREDITO' And AcessoDocumentos.CodUsuario='" + usuarioID + "'";
                        if (_TiposDocumentos == "SAIDAS")
                            Criterios = "and Operacoes.MovStk='DEBITO' And AcessoDocumentos.CodUsuario='" + usuarioID + "'";
                        if (_TiposDocumentos == " and FINANCEIRO ")
                            Criterios = "and Operacoes.Codigo <>'0' And AcessoDocumentos.CodUsuario='" + usuarioID + "'";
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

                if (descritivo != string.Empty)
                    Criterios = "(" + descritivo + ")";

                if (admin)
                {
                    Criterios += " and AcessoDocumentos.CodUsuario='" + usuarioID + "'";
                }

                Criterios += " order by Operacoes.Nome";

                if (admin)
                {
                    string SQL = "SELECT AcessoDocumentos.Codigo as AcessoDocumentoId, AcessoDocumentos.CodOperacao as OperacaoId, Operacoes.Nome as Descricao, Operacoes.Entidade As Entidade  from AcessoDocumentos join Operacoes on ";
                    SQL += "Operacoes.Codigo=AcessoDocumentos.CodOperacao where " + Criterios + "";
                    object x = Conexao.ClienteSql.SELECT(SQL);
                    DtOperacoes = (DataTable)x;
                }

                else
                {
                    DtOperacoes = Conexao.BuscarTabela_com_Criterio("Operacoes", Criterios);
                }

                result = DataTableHelper.DataTableToList<Folha.Domain.Models.Documentos.Documentos>(DtOperacoes);

                return result;


            }
            catch (Exception a)
            {
                throw new Exception(a.Message);
            }


        }

        public int CriaDocumento(Documentos documento)
        {
            //Hora = DateTime.Now.ToShortTimeString();

            int order = Conexao.BuscarOrdemDocumento(documento.CodOperacao);
            object _codMesa;

            if (documento.CodMesa == 0)
                _codMesa = DBNull.Value;
            else
                _codMesa = documento.CodMesa;
            if (documento.CodOperacao != 0)
            {
                DataTable dt = Conexao.BuscarTabela_com_Criterio("Operacoes", "Codigo='" + documento.CodOperacao + "'");
                Mascara = dt.Rows[0]["APP"].ToString();
                Mascara = Mascara + "/" + order;
            }

            if (documento.CodMesa == 0)
            {
                documento.Descritivo = "";
            }
            try
            {
                DbDTO dto = new DbDTO()
                {
                    Nome = "Documentos",
                    Campos = new string[] { "CodOperacao", "CodArea", "CodMesa", "CodUsuario", "Estado", "CodTurno", "Data", "Hora", "CodEntidade", "Total", "Descritivo", "NumeroOrdem", "Mascara" },
                    Valores = new Object[] { documento.CodOperacao, documento.CodArea, _codMesa, UtilidadesGenericas.UsuarioCodigo, "ABERTO", UtilidadesGenericas.CodigoTurno, DateTime.Now, DateTime.Now.ToShortTimeString(), documento.CodEntidade, documento.Total, documento.Descritivo, order, Mascara }
                };
                Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
                return BuscarUltimoDocumento(documento.CodOperacao, UtilidadesGenericas.UsuarioCodigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a criar Documento \n");
            }

        }

        public void ActualizaTotalDocumento(Guid Numero, Guid CodEntidade, double Total)
        {
            DateTime Data = DateTime.Now;
            string Hora = DateTime.Now.ToShortTimeString();

            string[] Campos = { "CodEntidade", "Total" };
            Object[] Valores = { CodEntidade, Total };
            Conexao.ClienteSql.UPDATE("Documentos", Campos, Valores, "Codigo='" + Numero + "'");

        }

        public List<DocumentoViewModel> Listar(String criterios)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT Documentos.codigo as Codigo, " +
                            "Documentos.Data as Data," +
                            " Documentos.Hora as Hora," +
                            " Operacoes.Nome as Documento" +
                            ", Areas.descricao as Area, " +
                            "Documentos.NomeCliente AS Entidade, " +
                            "Documentos.Total as Total," +
                            " Documentos.Estado as Estado," +
                            " Usuarios.Nome AS Usuario, " +
                            "Documentos.CodOperacao as Documento," +
                            " Documentos.CodEntidade as CodCliente, " +
                            "Operacoes.MovFin as Tipo, " +
                            "Operacoes.MovFin as  MovFinanceiro," +
                            " Operacoes.MovStk as   MovInventario, " +
                            " Operacoes.APP, " +
                            "Documentos.Descritivo as Descritivo, " +
                            "Documentos.NumeroOrdem as Numero " +
                    " from Documentos JOIN Operacoes ON " +
                    " Operacoes.codigo = Documentos.CodOperacao " +
                    " JOIN Entidades ON Entidades.Codigo = Documentos.CodEntidade" +
                    " JOIN Usuarios ON Usuarios.codigo = Documentos.CodUsuario " +
                    " JOIN Areas ON Areas.codigo = Documentos.CodArea " +
                    " LEFT JOIN Comissoes ON Comissoes.CodDocumento = Documentos.Codigo ";

                if (!string.IsNullOrEmpty(criterios))
                {
                    SQL = SQL + " Where " + criterios;
                }

                SQL += " Order by Documentos.Codigo desc ";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<DocumentoViewModel>(DtDados);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a busca do Documento\n" + ex.Message);
            }

        }

        public void FecharDocumento(int documentoID, int entidadeID, double Total, string Descritivo)
        {
            if (string.IsNullOrEmpty(Descritivo))
            {
                Descritivo = "";
            }
            String[] Campos = { "Total", "Estado", "Descritivo", "CodEntidade" };
            Object[] Valores = { Total, "FECHADO", Descritivo, entidadeID };
            String[] Criterios = { "Codigo='" + documentoID + "'" };

            Conexao.ClienteSql.UPDATE("Documentos", Campos, Valores, Criterios);

        }

        public List<PendenteViewModel> CarregarDocumentosPendentes()
        {
            DataTable DtDados = new DataTable();
            var listaRetorno = new List<PendenteViewModel>();
            try
            {
                string SQL = "SELECT Documentos.codigo, Documentos.Data, Documentos.Hora, Operacoes.Nome, Operacoes.APP, Areas.descricao, VendaPendente.Cliente, Documentos.Total, Documentos.Estado, Documentos.CodOperacao, Documentos.CodArea, Documentos.CodEntidade AS CodCliente, Usuarios.Nome AS Usuario FROM Documentos";
                SQL = SQL + " INNER JOIN Operacoes ON Operacoes.codigo = Documentos.CodOperacao LEFT JOIN VendaPendente ON VendaPendente.CodDocumento = Documentos.Codigo INNER JOIN Usuarios ON Usuarios.codigo = Documentos.CodUsuario INNER JOIN Areas ON Areas.codigo = Documentos.CodArea";
                string criterios = "Documentos.Estado LIKE 'PENDENTE'";
                Object ob;
                if (string.IsNullOrEmpty(criterios))
                {
                    SQL = SQL + " Order by Documentos.Codigo desc";

                    ob = Conexao.ClienteSql.SELECT(SQL);
                }
                else
                {
                    SQL = SQL + " Where " + criterios + " Order by Documentos.Codigo desc";
                    ob = Conexao.ClienteSql.SELECT(SQL);
                }
                DtDados = (DataTable)ob;
                listaRetorno = DataTableHelper.DataTableToList<PendenteViewModel>(DtDados);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a busca do Documento\n" + ex.Message);
            }
            return listaRetorno;
        }
        public bool ContemDucumentosAberto(int turnoId)
        {
            DataTable tabelaDocumentos = (DataTable)Conexao.ClienteSql.SELECT("Select * From Documentos Where CodTurno = " + turnoId + " And CodOperacao < 3 And Estado = 'ABERTO'");
            return tabelaDocumentos.Rows.Count > 0;
        }
        public IEnumerable<Folha.Domain.Models.Documentos.Documentos> BuscarDocumentosPorEntidade(string crit)
        {
            List<Folha.Domain.Models.Documentos.Documentos> result = new List<Folha.Domain.Models.Documentos.Documentos>();

            DataTable DtDados = new DataTable();

            string[] tabelas = { "Documentos" }; //, "", "" };
            string[] campos = { "Documentos.Data", "Documentos.Hora", "Operacoes.Nome as Descricao", "Operacoes.MovFin as Tipo", "Documentos.Total" };
            string[] criteriosTodos = { "Operacoes on Operacoes.codigo = Documentos.CodOperacao" };
            Object ob;

            string[] criterios = { crit };

            if (string.IsNullOrEmpty(crit))
            {
                ob = Conexao.ClienteSql.INNERJOIN(tabelas[0].ToString(), campos, criteriosTodos, null);
            }
            else
            {
                ob = Conexao.ClienteSql.INNERJOIN(tabelas[0].ToString(), campos, criteriosTodos, criterios);
            }

            try
            {
                DtDados = (DataTable)ob;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return result;
        }

        public void AnularDocumento(int documentoID, int usuarioId, string Motivo)
        {

            DateTime Data = DateTime.Now;

            if (documentoID <= 0)
            {
                throw new Exception("Impossivel Eliminar este Documento");

            }

            String[] Campos = { "Estado", };
            Object[] Valores = { "ANULADO" };
            string[] criterios = { "Codigo='" + documentoID + "'" };

            try
            {
                Conexao.ClienteSql.UPDATE("Documentos", Campos, Valores, criterios);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Anular Documento" + ex.Message);
            }

            //Numero

            String[] Campos2 = { "Numero", "CodUsuario", "Data", "Motivo", "Hora" };
            Object[] Valores2 = { documentoID, usuarioId, Data.ToShortDateString(), Motivo, Data.ToShortTimeString() };

            try
            {
                Conexao.ClienteSql.INSERT("Anulados", Campos2, Valores2);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Anular Documento" + ex.Message);
            }


        }

        public void DeixarPendenteDocumento(int documentoID, string cliente)
        {
            if (documentoID == 0)
            {
                throw new Exception("Impossivel Deixar Pendente este Documento");
            }

            String[] Campos = { "Estado", };
            Object[] Valores = { "PENDENTE" };
            string[] criterios = { "Codigo='" + documentoID + "'" };

            try
            {
                Conexao.ClienteSql.UPDATE("Documentos", Campos, Valores, criterios);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Deixar Pendente Documento" + ex.Message);
            }

            string[] Campos2 = { "CodDocumento", "Cliente" };
            object[] Valores2 = { documentoID, cliente };
            try
            {
                Conexao.ClienteSql.INSERT("VendaPendente", Campos2, Valores2);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Deixar Pendente Documento" + ex.Message);
            }

        }

        public int BuscarUltimoDocumento(int operacaoID, int usuarioID)
        {
            int UltimaVenda = 0;
            DataTable DtDados = new DataTable();

            string sql = "Select Codigo from Documentos where CodOperacao='" + operacaoID + "' and CodUsuario='" + usuarioID + "' order by codigo desc";
            Object ob = Conexao.ClienteSql.SELECT(sql);
            DtDados = (DataTable)ob;

            UltimaVenda = int.Parse(DtDados.Rows[0][0].ToString());
            return UltimaVenda;

        }

        public Guid BuscarUltimoDocumentoAberto(Guid OperacaoID, Guid usuarioID)
        {
            string UltimaVenda;

            string sql = "Select Codigo, Estado from Documentos where CodOperacao='" + OperacaoID + "' and CodUsuario='" + usuarioID + "' order by codigo desc";
            Object ob = Conexao.ClienteSql.SELECT(sql);
            DataTable DtDados = (DataTable)ob;

            string Estado = DtDados.Rows[0]["Estado"].ToString();
            UltimaVenda = DtDados.Rows[0][0].ToString();

            return new Guid(UltimaVenda);

        }


        public int LerNumeroDocumentoAberto(int OperacaoID, int AreaID, int mesaID, int usuarioID)
        {
            int DocAberto = 0;
            try
            {

                DataTable DtDados = new DataTable();

                string SQl = "Select Codigo from Documentos where CodOperacao='" + OperacaoID + "' and CodUsuario='" + usuarioID + "' And ESTADO='ABERTO' And CodArea='" + AreaID + "'";
                if (OperacaoID != 19)
                    SQl += " and CodMesa='" + mesaID + "' ";
                Object ob = Conexao.ClienteSql.SELECT(SQl);
                DtDados = (DataTable)ob;

                if (DtDados.Rows.Count > 0)
                {
                    DocAberto = int.Parse(DtDados.Rows[DtDados.Rows.Count - 1][0].ToString());


                }
                return DocAberto;

            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }

        public void InserirTecnico(Guid documentoID, Guid tecnicoID)
        {
            string[] Campos = { "CodDocumento", "CodTecnico" };
            Object[] Valores = { documentoID, tecnicoID };
            Conexao.ClienteSql.INSERT("MovTecnicos", Campos, Valores);
        }

        public void InserirMotorista(Guid documentoID, Guid motoristaID)
        {
            string[] Campos = { "DocumentoID", "motoristaID" };
            Object[] Valores = { documentoID, motoristaID };
            DataTable dt = Conexao.BuscarTabela_com_Criterio("MovMotoristas", "CodDocumento='" + documentoID + "' and CodMotorista='" + motoristaID + "'");
            if (dt.Rows.Count > 0)
            {
                throw new Exception("Motorista Já Adicionado !!!");
            }
            Conexao.ClienteSql.INSERT("MovMotoristas", Campos, Valores);
        }

        public void LancarArtigoDocumento(Guid documentoID, MovArtigo a)
        {
            try
            {
                //string[] Campos = { "CodDocumento", "CodProduto", "Descricao", "Preco", "CodArmazem", "Qtdade", "Total", "Custo", "Imposto", "Desconto", "Retencao" };
                //Object[] Valores = { a.DocumentoID, a.Artigo.ID, a.Artigo.Nome, a.Artigo.preco1, a.Armazem.ID, a.Artigo., a.Artigo.Total(), a.Artigo.Custo, a.Imposto, a.Desconto, a.Retencao };

                //Conexao.ClienteSql.INSERT("MovProdutos", Campos, Valores);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Lançar o Produto \n " + ex.Message);
            }
        }

        public void ActualizarLinhaDocumento(Guid documentoID, MovArtigo a)
        {
            try
            {
                //string[] Campos = { "CodDocumento", "CodProduto", "Descricao", "Preco", "CodArmazem", "Qtdade", "Total", "Custo", "Imposto", "Desconto", "Retencao" };
                //Object[] Valores = { a.DocumentoID, a.Artigo.ID, a.Artigo.Descricao, a.Artigo.Preco, a.Armazem.ID, a.Artigo.Qtdade, a.Artigo.Total(), a.Artigo.Custo, a.Imposto, a.Desconto, a.Retencao };

                //string criterio = "CodDocumento='" + documentoID + "' and CodProduto='" + a.Artigo.ID + "'";
                //DataTable DtVer = Conexao.BuscarTabela_com_Criterio("MovProdutos", criterio);

                //if (DtVer.Rows.Count < 1)
                //{
                //    throw new Exception("Não foi encontrado o registo");
                //}

                //double Qua = double.Parse(DtVer.Rows[0]["Qtdade"].ToString()) + a.Artigo.Qtdade;
                //double Tota = Qua * a.Artigo.Preco;
                //double TotalImposto = Qua * a.Imposto;
                //Tota = Tota + TotalImposto;

                //string[] Campos2 = { "Qtdade", "Total", "Imposto", "Desconto" };
                //Object[] Valores2 = { Qua, Tota, TotalImposto, a.Desconto };
                //Conexao.ClienteSql.UPDATE("MovProdutos", Campos2, Valores2, criterio);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Lançar o Produto \n " + ex.Message);
            }
        }

        public List<Documentos> ListarDocumentosPendentes()
        {
            throw new NotImplementedException();
        }

        public void EliminarVendaPendente(Guid documentoID)
        {
            string criterio = "CodDocumento='" + documentoID + "'";
            string Venda = Conexao.ClienteSql.DELETE("VendaPendente", criterio);
        }

        public IEnumerable<MinhasContasBancariasViewModel> ListarMinhasContasBancarias()
        {

            DataTable DtCaixas = new DataTable();
            if (UtilidadesGenericas.UsuarioCodigo > 1)
            {
                string SQL = "SELECT ContasBancarias.Codigo,ContasBancarias.Numero, Bancos.Descricao as Banco from ContasBancarias,AcessoContas,Bancos WHERE ";
                SQL += "ContasBancarias.Codigo=AcessoContas.CodContaBancaria And Bancos.Codigo=ContasBancarias.CodBanco And AcessoContas.CodUsuario='" + UtilidadesGenericas.UsuarioCodigo + "'";

                var x = Conexao.ClienteSql.SELECT(SQL);

                DtCaixas = (DataTable)x;
                var result = DataTableHelper.DataTableToList<MinhasContasBancariasViewModel>(DtCaixas);
                return result;
            }
            else
            {
                string SQL = "SELECT ContasBancarias.Codigo,ContasBancarias.Numero, Bancos.Descricao as Banco ";
                SQL += "From ContasBancarias,Bancos WHERE ContasBancarias.CodBanco=Bancos.Codigo";
                var x = Conexao.ClienteSql.SELECT(SQL);
                DtCaixas = (DataTable)x;
                var result = DataTableHelper.DataTableToList<MinhasContasBancariasViewModel>(DtCaixas);
                return result;
            }

        }

        public IEnumerable<OpAcessoViewModel> Meus_Documentos(string _TiposDocumentos)
        {
            DataTable DtOperacoes = new DataTable();
            var Lista = new List<OpAcessoViewModel>();
            try
            {
                DataTable dtAplicacoes = new DataTable();
                dtAplicacoes.Columns.Add("Aplicativo");

                string Criterios = "";
                if (!string.IsNullOrEmpty(_TiposDocumentos))
                {
                    if (UtilidadesGenericas.UsuarioPerfilCodigo > 1)
                    {
                        if (_TiposDocumentos == "ENTRADAS")
                            Criterios = "and Operacoes.MovStk='CREDITO' And AcessoDocumentos.CodUsuario='" + UtilidadesGenericas.UsuarioCodigo.ToString() + "'";
                        if (_TiposDocumentos == "SAIDAS")
                            Criterios = "and Operacoes.MovStk='DEBITO' And AcessoDocumentos.CodUsuario='" + UtilidadesGenericas.UsuarioCodigo.ToString() + "'";
                        if (_TiposDocumentos == " and FINANCEIRO ")
                            Criterios = "and Operacoes.Codigo <>'0' And AcessoDocumentos.CodUsuario='" + UtilidadesGenericas.UsuarioCodigo.ToString() + "'";
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



                //if (UtilidadesGenericas.TemHotel == true) { dtAplicacoes.Rows.Add("Hotel"); }
                if (UtilidadesGenericas.TemAcesso("Vendas") == true) { dtAplicacoes.Rows.Add("Pos"); }
                //if (UtilidadesGenericas.TemPOS == true) { dtAplicacoes.Rows.Add("Pos"); }
                //if (UtilidadesGenericas.TemRestaurante == true) { dtAplicacoes.Rows.Add("Restaurante"); }
                //if (UtilidadesGenericas.TemRH == true) { dtAplicacoes.Rows.Add("RH"); }
                //if (UtilidadesGenericas.TemEscolar == true) { dtAplicacoes.Rows.Add("Escolar"); }
                //if (UtilidadesGenericas.TemCyber == true) { dtAplicacoes.Rows.Add("Cyber"); }
                if (UtilidadesGenericas.TemAcesso("Hospitalar")) { dtAplicacoes.Rows.Add("Hospitalar"); }
                //if (UtilidadesGenericas.TemPT == true) { dtAplicacoes.Rows.Add("PT"); }
                //if (UtilidadesGenericas.TemLavandaria == true) { dtAplicacoes.Rows.Add("LAV"); }
                //if (UtilidadesGenericas.TemViagem == true) { dtAplicacoes.Rows.Add("Viagem"); }

                for (int i = 0; i < dtAplicacoes.Rows.Count; i++)
                {
                    descritivo += "Operacoes." + dtAplicacoes.Rows[i]["Aplicativo"].ToString() + "=1  " + Criterios + " Or ";
                }
                descritivo = Folha.Domain.Helpers.Strings.Left(descritivo, descritivo.Length - 3);

                Criterios = "(" + descritivo + ")";

                if (int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString()) > 1)
                {
                    Criterios += " and AcessoDocumentos.CodUsuario='" + UtilidadesGenericas.UsuarioCodigo + "'";
                }

                Criterios += " order by Operacoes.Nome";


                if (int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString()) > 1)
                {

                    string SQL = "SELECT AcessoDocumentos.Codigo as Cod, AcessoDocumentos.CodOperacao as Codigo, Operacoes.Nome as Nome, Operacoes.Entidade from AcessoDocumentos join Operacoes on ";
                    SQL += "Operacoes.Codigo=AcessoDocumentos.CodOperacao where " + Criterios + "";
                    object x = Conexao.ClienteSql.SELECT(SQL);
                    DtOperacoes = (DataTable)x;

                }

                else
                {
                    DtOperacoes = Conexao.BuscarTabela_com_Criterio("Operacoes", Criterios);

                }

            }
            catch { }
            Lista = DataTableHelper.DataTableToList<OpAcessoViewModel>(DtOperacoes);
            return Lista;

        }

        public void ReceberPagamentos(DadosPagamentoViewModel Dados)
        {

            string Hora = DateTime.Now.ToShortTimeString();
            int codConta;

            if (Dados.CodForma > 1)
            {
                DataTable dt = Conexao.BuscarTabela_com_Criterio("fPagamentos", "Codigo='" + Dados.CodForma + "'");
                codConta = int.Parse(dt.Rows[0][3].ToString());

                try
                {

                    String[] Campos = { "Descricao", "Data", "Hora", "CodForma", "Valor", "Tipo", "CodDocumento", "CodConta", "CodTurno", "Estado", "CodMoeda", "CodCambio" };
                    Object[] Valores = { Dados.Descricao, Dados.Data, Hora, Dados.CodForma, Dados.Valor, "CREDITO", Dados.CodDoc, codConta, UtilidadesGenericas.CodigoTurno, "FECHADO", Dados.CodMoeda, Dados.CodCambio };

                    Conexao.ClienteSql.INSERT("Pagamentos", Campos, Valores);
                }
                catch (Exception ex) { throw new Exception("Erro a receber pagamento \n" + ex.Message); }
            }
            else
            {
                try
                {

                    String[] Campos = { "Descricao", "Data", "Hora", "CodForma", "Valor", "Tipo", "CodDocumento", "CodTurno", "Estado", "CodMoeda", "CodCambio" };
                    Object[] Valores = { Dados.Descricao, Dados.Data, Hora, Dados.CodForma, Dados.Valor, "CREDITO", Dados.CodDoc, UtilidadesGenericas.CodigoTurno, "FECHADO", Dados.CodMoeda, Dados.CodCambio };

                    Conexao.ClienteSql.INSERT("Pagamentos", Campos, Valores);
                }
                catch (Exception ex) { throw new Exception("Erro a receber pagamento \n" + ex.Message); }
            }


        }

        public void ReceberTroco(DadosPagamentoViewModel Dados)
        {
            string Hora = DateTime.Now.ToShortTimeString();
            try
            {

                String[] Campos = { "CodDocumento", "Descricao", "Data", "Hora", "CodForma", "Valor", "Tipo", "CodTurno", "Estado", "CodMoeda", "CodCambio" };
                Object[] Valores = { Dados.CodDoc, Dados.Descricao, Dados.Data, Hora, 1, Dados.Valor, "DEBITO", UtilidadesGenericas.EstadoTurnoSistema, "FECHADO", Dados.CodMoeda, Dados.CodCambio };

                Conexao.ClienteSql.INSERT("Pagamentos", Campos, Valores);
            }
            catch (Exception ex) { throw new Exception("Erro a receber pagamento \n" + ex.Message); }


        }
        public IEnumerable<Mostrar> ListarFPagamentos()
        {
            DataTable dtDados = new DataTable();
            try
            {
                string tabela = "fPagamentos";
                string[] tabelas = { "fPagamentos", };
                string[] campos = { "fPagamentos.Codigo", "ContasBancarias.Codigo as CodBanco", "fPagamentos.Descricao", "fPagamentos.Movimentar", "ContasBancarias.Numero as ContaBancaria", "Bancos.Descricao as Banco", "fPagamentos.CodConta" };
                string[] criterios = { "ContasBancarias on fPagamentos.CodConta=ContasBancarias.Codigo", "Bancos on ContasBancarias.CodBanco=Bancos.Codigo" };
                var ob = Conexao.ClienteSql.LEFTJOIN(tabela, campos, criterios, null);

                dtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<Mostrar>(dtDados);
                return result;

            }
            catch (Exception ex) { throw new Exception("Erro a Carregar Formas de Pagamentos \n" + ex.Message); }

        }

        public object GetCodLast()
        {
            var obj = Conexao.ClienteSql.SELECT("Select  MAX(codigo) As Codigo From Documentos");

            DataTable dtadados = (DataTable)obj;

            var result = DataTableHelper.DataTableToList<Documentos>(dtadados).ToList();

            return result[0].codigo;
        }
        public DocumentosViewModel GetDocumentoLastPorCodOperacao(int operacaoId)
        {
            var obj = Conexao.ClienteSql.SELECT("Select  MAX(codigo) As Codigo From Documentos WHERE CodOperacao = '" + operacaoId + "'");

            DataTable dtadados = (DataTable)obj;

            var result = DataTableHelper.DataTableToList<Documentos>(dtadados).ToList();

            return (DocumentosViewModel)Get(new DocumentosViewModel() { codigo = result[0].codigo });
        }
        public int GetCodDocumentoLastPorCodOperacao(int operacaoId)
        {
            var obj = Conexao.ClienteSql.SELECT("Select  MAX(codigo) As Codigo From Documentos WHERE CodOperacao = '" + operacaoId + "'");

            DataTable dtadados = (DataTable)obj;
            if (dtadados.Rows.Count == 0 || Equals(dtadados.Rows[0][0], DBNull.Value))
            {
                return 0;
            }

            return Convert.ToInt16(dtadados.Rows[0][0]);
        }
        #region CRUD
        public void Delete(DocumentosViewModel documento)
        {
            Db.Delete(documento);
        }

        public object Get(DocumentosViewModel documento)
        {
            return Db.GetById<DocumentosViewModel>(documento.codigo);
        }

        public object GetAll(DocumentosViewModel documento)
        {
            return Db.GetEntities<DocumentosViewModel>();
        }
        public AnuladosViewModel GetAnuladosPor(int documentoId)
        {
            return Db.GetEntities<AnuladosViewModel>(" WHERE [Anulados].Numero = '" + documentoId + "'").FirstOrDefault();
        }

        public void Insert(DocumentosViewModel documento)
        {
            Db.Add(documento);
        }

        public void Update(DocumentosViewModel documento)
        {
            Db.Update(documento);
        }
        #endregion



        public double buscarSaldoCaixa(int CodCaixa)
        {

            DataTable dtPagamento = Conexao.BuscarTabela_com_Criterio("Pagamentos", "CodCaixa='" + CodCaixa + "'");
            double credito = 0;
            double debido = 0;

            for (int i = 0; i < dtPagamento.Rows.Count; i++)
            {

                if (dtPagamento.Rows[i]["Tipo"].ToString() == "CREDITO")
                {
                    credito = credito + double.Parse(dtPagamento.Rows[i]["Valor"].ToString());
                }
                else
                {
                    debido = debido + double.Parse(dtPagamento.Rows[i]["Valor"].ToString());
                }
            }
            double Saldo = credito - debido;

            return Saldo;
        }


        public void EfectuarTransferenciaCx(DadosPagamentoViewModel Dados)
        {
            string Hora = DateTime.Now.ToShortTimeString();
            try
            {
                String[] Campos = { "CodDocumento", "Descricao", "Data", "Hora", "Valor", "Tipo", "CodCaixa", "Estado", "CodForma", "CodMoeda" };

                Object[] Debito = { Dados.CodDoc, Dados.Descricao, Dados.Data, Hora, Dados.Valor, "DEBITO", Dados.CodCaixaOrigem, "FECHADO", 1, 1 };
                Conexao.ClienteSql.INSERT("Pagamentos", Campos, Debito);

                Object[] Credito = { Dados.CodDoc, Dados.Descricao, Dados.Data, Hora, Dados.Valor, "CREDITO", Dados.CodCaixaDestino, "FECHADO", 1, 1 };
                Conexao.ClienteSql.INSERT("Pagamentos", Campos, Credito);

            }
            catch (Exception ex) { throw new Exception("Erro a Transferir Valor" + ex.Message); }
        }
        private void DescontaCaixa(int CodCaixa, decimal _valor)
        {
            string SQL = "SELECT * FROM Pagamentos WHERE TIPO='CREDITO' and CodCaixa=" + CodCaixa;
            var ob = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)ob;
            var result = DataTableHelper.DataTableToList<Pagamentos>(DtDados);

            decimal maior = result.Max(r => r.Valor);
            if (result.Max(r => r.Valor) > _valor)
            {
                decimal desconta = maior - _valor;

                String[] Campos = { "Valor" };
                Object[] Debito = { desconta };

                var contem = result.Where(r => r.Valor == maior).FirstOrDefault();
                Conexao.ClienteSql.UPDATE("Pagamentos", Campos, Debito, "Codigo=" + contem.codigo.ToString());
                return;
            }
            else
            {
                decimal dividido = maior / 2;
                //decimal subtraido
                //for (int i = 0; i < result.Count; i++)
                //{
                //    result[i].Valor= maior

                //}
            }


            // return result;
        }
        public void EfectuarTransferenciaBn(DadosPagamentoViewModel Dados)
        {
            string Hora = DateTime.Now.ToShortTimeString();
            try
            {
                String[] Campos = { "CodDocumento", "Descricao", "Data", "Hora", "Valor", "Tipo", "CodCaixa", "Estado", "CodForma", "CodMoeda" };
                Object[] Debito = { Dados.CodDoc, Dados.Descricao, Dados.Data, Hora, Dados.Valor, "DEBITO", Dados.CodCaixa, "FECHADO", 1, 1 };
                Conexao.ClienteSql.INSERT("Pagamentos", Campos, Debito);

                String[] Campos2 = { "CodDocumento", "Descricao", "Data", "Hora", "Valor", "Tipo", "CodConta", "Estado", "CodForma", "CodMoeda" };
                Object[] Credito = { Dados.CodDoc, Dados.Descricao, Dados.Data, Hora, Dados.Valor, "CREDITO", Dados.CodConta, "FECHADO", Dados.CodForma, 1 };
                Conexao.ClienteSql.INSERT("Pagamentos", Campos2, Credito);
            }
            catch (Exception ex) { throw new Exception("Erro a Transferir Valor" + ex.Message); }
        }
        public DocumentosViewModel GetUltimoDocumentoPor(int operacaoId, string estadoDocumento)
        {
            return Db.GetEntities<DocumentosViewModel>(" WHERE CodOperacao = '" + operacaoId + "' AND Estado = '" + estadoDocumento + "'").LastOrDefault();
        }
        public DocumentosViewModel GetUltimoDocumentoPor(string app, string estadoDocumento)
        {
            return Db.GetEntities<DocumentosViewModel>(" WHERE APP = '" + app + "' AND Estado = '" + estadoDocumento + "'").LastOrDefault();
        }
        public List<DocumentosViewModel> GetDocumentosPor(DateTime dataInicio, DateTime datafim)
        {
            var criterio = " Documentos.Data between '" + dataInicio.ToString("yyyy-MM-dd") + "' and '" + datafim.ToString("yyyy-MM-dd") + "'";
            return Db.GetEntities<DocumentosViewModel>(" WHERE " + criterio);
        }
        //public List<DocumentosViewModel> GetDocumentosComerciais(DateTime dataInicio, DateTime datafim)
        //{
        //    var criterio = " Documentos.Data between ('" + dataInicio.ToString("yyyy-MM-dd") + "' and '" + datafim.ToString("yyyy-MM-dd") + "') And Operacoes.MovFin = '"+ mov;
        //    return Db.GetEntities<DocumentosViewModel>(" WHERE " + criterio);
        //}

        public IEnumerable<MostraDocumentoViewModel> MostraDocumentos(string criterios)
        {
            DataTable DtDados = new DataTable();

            try
            {
                string SQL = "SELECT Documentos.codigo, Documentos.Data, Documentos.Hora, Operacoes.Nome as Documento, Areas.descricao as Area, Entidades.Nome AS Cliente, Documentos.Total, Documentos.Estado, Usuarios.Nome AS Usuario, Documentos.CodOperacao as CodOperacao, Documentos.CodEntidade as CodCliente, Operacoes.MovFin as TIPO, Documentos.Descritivo from Documentos";
                SQL = SQL + " JOIN Operacoes ON Operacoes.codigo = Documentos.CodOperacao JOIN Entidades ON Entidades.Codigo = Documentos.CodEntidade JOIN Usuarios ON Usuarios.codigo = Documentos.CodUsuario JOIN Areas ON Areas.codigo = Documentos.CodArea LEFT JOIN Comissoes ON Comissoes.CodDocumento = Documentos.Codigo ";

                if (!string.IsNullOrEmpty(criterios))
                {
                    SQL = SQL + " Where " + criterios;
                }

                SQL += " Order by Documentos.Codigo desc ";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<MostraDocumentoViewModel>(DtDados);
                return result;
            }
            catch (Exception) { throw new Exception("Erro"); }
        }
        public IEnumerable<RelOpercoesViewModel> LerOperacoes(string dataInicio, string dataFim, object[] CodOperacoes)
        {

            string SQL = "SELECT Documentos.Codigo, Operacoes.Codigo as CodOperacao, Documentos.Data as DATA,Documentos.Hora as HORA,Operacoes.Nome as DOCUMENTO,Operacoes.MovFin as TIPO,Entidades.Nome As Cliente,Documentos.Total as TOTAL,Documentos.Estado,Documentos.CodOperacao,Documentos.CodArea,Documentos.CodEntidade As CodCliente,Usuarios.Nome Usuario ";
            SQL += " FROM Documentos ";
            SQL += " LEFT OUTER JOIN Operacoes on Operacoes.Codigo=Documentos.CodOperacao LEFT OUTER JOIN Entidades on Entidades.Codigo=Documentos.CodEntidade LEFT OUTER JOIN Usuarios on Usuarios.Codigo=Documentos.CodUsuario";

            bool data = false;
            if (!string.IsNullOrEmpty(dataInicio) && !string.IsNullOrEmpty(dataFim))
            {
                SQL += " Where Documentos.[Data] between '" + dataInicio + "' and '" + dataFim + "'";
                data = true;
            }



            if (CodOperacoes != null)
            {
                if (!data)
                {
                    SQL += " Where";
                    for (int i = 0; i < CodOperacoes.Count(); i++)
                    {
                        if (CodOperacoes[i] != null)
                        {
                            if (i == 0) SQL += " and ("; else SQL += " or ";
                            SQL += " Operacoes.Codigo=" + CodOperacoes[i] + "";
                            if ((CodOperacoes.Count() - 1) == i) SQL += ")";
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < CodOperacoes.Count(); i++)
                    {
                        if (CodOperacoes[i] != null)
                        {
                            if (i == 0) SQL += " and ("; else SQL += " or ";
                            SQL += " Operacoes.Codigo=" + CodOperacoes[i] + "";
                            if ((CodOperacoes.Count() - 1) == i) SQL += ")";
                        }

                    }
                }

            }

            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)x;
            var result = DataTableHelper.DataTableToList<RelOpercoesViewModel>(DtDados);
            return result;
        }
        public int GetNumeroDeDocumentosFacturadoOuAnulado(DateTime dataInicio, DateTime datafim)
        {

            var criterio = " Documentos.Data between '" + dataInicio.ToString("yyyy-MM-dd") + "' and '" + datafim.ToString("yyyy-MM-dd") + "' And (Documentos.Estado LIKE 'FECHADO' OR Documentos.Estado LIKE 'ANULADO')";
            DataTable DtDados = new DataTable();

            try
            {
                string SQL = "SELECT Count(*) from Documentos ";

                if (!string.IsNullOrEmpty(criterio))
                {
                    SQL = SQL + " Where " + criterio;
                }


                //SQL += " Order by Documentos.Codigo desc ";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                if (NaoTipoString(ob))
                {

                    DtDados = (DataTable)ob;
                    if (DtDados.Rows.Count == 0)
                    {
                        return 0;
                    }
                    return Convert.ToInt16(DtDados.Rows[0][0]);
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public decimal GetTotalMovFinDeDocumentos(DateTime dataInicio, DateTime datafim, string movFin)
        {

            var criterio = " Documentos.Data between '" + dataInicio.ToString("yyyy-MM-dd") + "' and " +
                "'" + datafim.ToString("yyyy-MM-dd") + "' And " +
                "(Documentos.Estado != 'ABERTO' OR Documentos.Estado != 'ANULADO') And Operacoes.MovFin = '" + movFin + "' And Operacoes.Entidade = 'CLIENTE'";
            DataTable DtDados = new DataTable();

            try
            {
                string SQL = "SELECT Sum(Total) from Documentos INNER JOIN Operacoes On Documentos.CodOperacao = Operacoes.codigo";

                if (!string.IsNullOrEmpty(criterio))
                {
                    SQL = SQL + " Where " + criterio;
                }


                //SQL += " Order by Documentos.Codigo desc ";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                if (NaoTipoString(ob))
                {

                    DtDados = (DataTable)ob;
                    if (DtDados.Rows.Count == 0)
                    {
                        return 0.0m;
                    }
                    return Convert.ToDecimal(DtDados.Rows[0][0]);
                }
                else
                {
                    return 0.0m;
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public List<DocumentosViewModel> GetMovFinDeDocumentos(DateTime dataInicio, DateTime datafim, string movFin)
        {

            var criterio = " Documentos.Data between '" + dataInicio.ToString("yyyy-MM-dd") + "' and " +
                "'" + datafim.ToString("yyyy-MM-dd") + "' And " +
                "(Documentos.Estado != 'FECHADO' OR Documentos.Estado != 'ANULADO') And Operacoes.MovFin = '" + movFin + "'";
            DataTable DtDados = new DataTable();

            try
            {
                return Db.GetEntities<DocumentosViewModel>(" WHERE " + criterio);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public List<DocumentosViewModel> GetMovFinDeDocumentosConferencias(DateTime dataInicio, DateTime datafim)
        {

            var criterio = " Documentos.Data between '" + dataInicio.ToString("yyyy-MM-dd") + "' and " +
                "'" + datafim.ToString("yyyy-MM-dd") + "' And " +
                "(Documentos.Estado != 'ABERTO' OR Documentos.Estado != 'PENDENTE') And (Operacoes.APP != 'FR' OR Operacoes.APP != 'FT' OR Operacoes.APP != 'VD') And Operacoes.Entidade = 'CLIENTE'";

            try
            {
                return Db.GetEntities<DocumentosViewModel>(" WHERE " + criterio);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public decimal GetTotalMovFinDeDocumentosConferencias(DateTime dataInicio, DateTime datafim, string movFin)
        {
            var criterio = " Documentos.Data between '" + dataInicio.ToString("yyyy-MM-dd") + "' and " +
                   "'" + datafim.ToString("yyyy-MM-dd") + "' And " +
                   " Documentos.Estado != 'ABERTO' And Documentos.Estado != 'PENDENTE' And Documentos.Estado != 'ANULADO' And " +
                   "(Operacoes.APP != 'FR' OR Operacoes.APP != 'FT' OR Operacoes.APP != 'VD') And " +
                   " Operacoes.Entidade = 'CLIENTE' And " +
                   " Operacoes.MovFin = '" + movFin + "'";

            DataTable DtDados = new DataTable();

            try
            {
                string SQL = "SELECT Sum(Total) from Documentos INNER JOIN Operacoes On Documentos.CodOperacao = Operacoes.codigo";

                if (!string.IsNullOrEmpty(criterio))
                {
                    SQL = SQL + " Where " + criterio;
                }


                //SQL += " Order by Documentos.Codigo desc ";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                if (NaoTipoString(ob))
                {

                    DtDados = (DataTable)ob;
                    if (DtDados.Rows.Count == 0 || Equals(DtDados.Rows[0][0], DBNull.Value))
                    {
                        return 0.0m;
                    }
                    return Convert.ToDecimal(DtDados.Rows[0][0]);
                }
                else
                {
                    return 0.0m;
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public List<DocumentosViewModel> GetMovFinDeDocumentosVenda(DateTime dataInicio, DateTime datafim)
        {

            var criterio = " Documentos.Data between '" + dataInicio.ToString("yyyy-MM-dd") + "' and " +
                "'" + datafim.ToString("yyyy-MM-dd") + "' And " +
                " (Documentos.Estado != 'ABERTO' OR Documentos.Estado != 'PENDENTE') And (Operacoes.APP = 'FR' OR Operacoes.APP = 'FT' OR Operacoes.APP = 'VD') And Operacoes.Entidade = 'CLIENTE'";
            DataTable DtDados = new DataTable();

            try
            {
                return Db.GetEntities<DocumentosViewModel>(" WHERE " + criterio);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public decimal GetTotalMovFinDeDocumentosVenda(DateTime dataInicio, DateTime datafim, string movFin)
        {


            var criterio = " Documentos.Data between '" + dataInicio.ToString("yyyy-MM-dd") + "' and " +
                "'" + datafim.ToString("yyyy-MM-dd") + "' And " +
                   " Documentos.Estado != 'ABERTO' And Documentos.Estado != 'PENDENTE' And Documentos.Estado != 'ANULADO' And " +
                "(Operacoes.APP = 'FR' OR Operacoes.APP = 'FT') And " +
                "Operacoes.Entidade = 'CLIENTE' And " +
                " Operacoes.MovFin = '" + movFin + "' ";
            DataTable DtDados = new DataTable();

            try
            {
                string SQL = "SELECT Sum(Total) from Documentos INNER JOIN Operacoes On Documentos.CodOperacao = Operacoes.codigo";

                if (!string.IsNullOrEmpty(criterio))
                {
                    SQL = SQL + " Where " + criterio;
                }


                //SQL += " Order by Documentos.Codigo desc ";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                if (NaoTipoString(ob))
                {

                    DtDados = (DataTable)ob;
                    if (DtDados.Rows.Count == 0 || Equals(DtDados.Rows[0][0], DBNull.Value) || Equals(DtDados.Rows[0][0], null))
                    {
                        return 0.0m;
                    }
                    var value = DtDados.Rows[0][0];
                    return Convert.ToDecimal(DtDados.Rows[0][0]);
                }
                else
                {
                    return 0.0m;
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public List<DocumentosViewModel> GetMovFinDeDocumentosMovimento(DateTime dataInicio, DateTime datafim)
        {

            var criterio = " Documentos.Data between '" + dataInicio.ToString("yyyy-MM-dd") + "' and " +
                "'" + datafim.ToString("yyyy-MM-dd") + "' And Operacoes.Entidade != 'CLIENTE' And " +
                " Operacoes.MovFin != 'ISENTO'";
            DataTable DtDados = new DataTable();

            try
            {
                return Db.GetEntities<DocumentosViewModel>(" WHERE " + criterio);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public List<DocumentosViewModel> GetMovFinDeDocumentosRecibo(DateTime dataInicio, DateTime datafim)
        {

            var criterio = " Documentos.Data between '" + dataInicio.ToString("yyyy-MM-dd") + "' and " +
                "'" + datafim.ToString("yyyy-MM-dd") + "' And " +
                "(Documentos.Estado != 'ABERTO' OR Documentos.Estado != 'PENDENTE') And (Operacoes.APP = 'FR' OR Operacoes.APP = 'VD') And Operacoes.Entidade = 'CLIENTE'";

            try
            {
                return Db.GetEntities<DocumentosViewModel>(" WHERE " + criterio);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public decimal GetTotalMovFinDeDocumentosRecibo(DateTime dataInicio, DateTime datafim, string movFin)
        {
            var criterio = " Documentos.Data between '" + dataInicio.ToString("yyyy-MM-dd") + "' and " +
                   "'" + datafim.ToString("yyyy-MM-dd") + "' And " +
                   " Documentos.Estado != 'ABERTO' And Documentos.Estado != 'PENDENTE' And Documentos.Estado != 'ANULADO' And " +
                   "(Operacoes.APP = 'FR' OR Operacoes.APP = 'VD') And " +
                   " Operacoes.Entidade = 'CLIENTE' And " +
                   " Operacoes.MovFin = '" + movFin + "' "; ;

            DataTable DtDados = new DataTable();

            try
            {
                string SQL = "SELECT Sum(Total) from Documentos INNER JOIN Operacoes On Documentos.CodOperacao = Operacoes.codigo";

                if (!string.IsNullOrEmpty(criterio))
                {
                    SQL = SQL + " Where " + criterio;
                }


                //SQL += " Order by Documentos.Codigo desc ";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                if (NaoTipoString(ob))
                {

                    DtDados = (DataTable)ob;
                    if (DtDados.Rows.Count == 0)
                    {
                        return 0.0m;
                    }
                    return Convert.ToDecimal(DtDados.Rows[0][0]);
                }
                else
                {
                    return 0.0m;
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}

