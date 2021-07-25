using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.ViewModels.Frame.Entidades;
using Folha.Driver.Repository.Entidades;
using Folha.Driver.Repository.Entidades;
using Folha.Domain.Helpers;


namespace Folha.Driver.Repository.Data.Repositories.Entidades
{
    using Folha.Domain.Models.Entidades;
    using Folha.Domain.ViewModels.Entidades;

    public class EntidadesRepository : RepositoryBase<DbDTO>, IEntidadesRepository
    {
        public List<Entidades> BuscarDadosEntidade(string tipoEntidades, Guid consumidorID, string procurar, bool admin)
        {
            DataTable DadosEntidade = new DataTable();
            String Criterio = string.Empty;
            string colunaAluno = string.Empty;
            List<Folha.Domain.Models.Entidades.Entidades> entidades = new List<Folha.Domain.Models.Entidades.Entidades>();
            if (tipoEntidades == "CLIENTES") Criterio = "Cliente=1";
            if (tipoEntidades == "FORNECEDORES") Criterio = "Fornecedor=1";
            if (tipoEntidades == "FUNCIONARIOS") Criterio = "Funcionario=1";

            if (admin)
            {
                Criterio = Criterio + " And Entidades.Codigo > 3";
            }

            string SQL = null;
            if (tipoEntidades == "LIMPEZA")
            {
                // SELECT Entidades.Codigo, Entidades.Nome from Entidades Join Camareiras on Camareiras.CodEntidade = Entidades.Codigo where Entidades.Nome like '%" + txtProcurar.Text + "%' and Entidades.Codigo  > 3
                SQL = "SELECT Funcionarios.IDPessoa, Entidades.Nome, TipoEntidade.Descricao from Entidades join TipoEntidade on TipoEntidade.Codigo=Entidades.CodTipo join Funcionarios on Funcionarios.CodEntidade=Entidades.Codigo Join Camareiras on Camareiras.CodEntidade=Funcionarios.IDPessoa where Entidades.Nome like '%" + procurar + "%' and Entidades.status=1";
            }

            if (tipoEntidades == "Hospedes")
            {
                SQL = "SELECT Entidades.Codigo, Entidades.Nome, TipoEntidade.Descricao from Entidades join TipoEntidade on TipoEntidade.Codigo=Entidades.CodTipo where Entidades.Nome like '%" +procurar + "%' and TipoEntidade.Descricao like 'PESSOA FISICA' and Entidades.status=1";
            }

            else if (tipoEntidades == "PROFESSORES")
            {
                SQL = "SELECT Professores.Codigo, Entidades.Nome, TipoEntidade.Descricao from Entidades join TipoEntidade on TipoEntidade.Codigo=Entidades.CodTipo join Professores on Professores.CodEntidade=Entidades.Codigo where Entidades.Nome like '%" + procurar + "%' and Entidades.status=1";
            }
            else if (tipoEntidades == "FUNCIONARIOS")
            {
                SQL = "SELECT Funcionarios.IDPessoa, Entidades.Nome, TipoEntidade.Descricao from Entidades join TipoEntidade on TipoEntidade.Codigo=Entidades.CodTipo join Funcionarios on Funcionarios.CodEntidade=Entidades.Codigo where Entidades.Nome like '%" + procurar + "%' and Entidades.status=1";

            }
            else if (tipoEntidades == "USUARIOS")
            {
                SQL = "SELECT Codigo, Nome from Usuarios where Nome like '%" + procurar + "'";
            }
            else if (tipoEntidades == "TECNICOS")
            {
                SQL = "SELECT Tecnicos.Codigo, Entidades.Nome from Tecnicos Join Entidades on Tecnicos.CodEntidade=Entidades.Codigo where Entidades.Nome like '%" + procurar + "%' and Entidades.status=1";
            }
            else if (tipoEntidades == "FABRICANTES")
            {
                SQL = "SELECT Fabricante.Codigo, Entidades.Nome from Fabricante Join Entidades on Fabricante.CodEntidade=Entidades.Codigo where Entidades.Nome like '%" + procurar + "%' and Entidades.status=1";
            }

            else if (tipoEntidades == "MOTORISTA")
            {
                SQL = "SELECT Motoristas.Codigo, Entidades.Nome, TipoEntidade.Descricao from Entidades join TipoEntidade on TipoEntidade.Codigo=Entidades.CodTipo join Motoristas on Motoristas.CodEntidade=Entidades.Codigo where Entidades.Nome like '%" + procurar + "%' and Entidades.status=1";
            }

            else if (tipoEntidades == "FORNECEDORES")
            {
                SQL = "SELECT Entidades.Codigo, Entidades.Nome from Fornecedores Join Entidades on Fornecedores.CodEntidade=Entidades.Codigo where Entidades.Nome like '%" + procurar + "%' and Entidades.status=1";
            }
            else if (tipoEntidades == "ALUNOS")
            {
                colunaAluno = "Gerero";
                SQL = "select Alunos.codigo, Entidades.Nome, Sexo.descricao from Alunos join Entidades on Entidades.Codigo=Alunos.CodEntidade join EntidadesPessoa on EntidadesPessoa.CodEntidade=Entidades.Codigo join Sexo on Sexo.codigo=EntidadesPessoa.CodSexo where Entidades.status=1 and Entidades.Nome like '%" + procurar + "%'";
            }

            else if (tipoEntidades == "CLIENTES")
            {

                if (Criterio == null) SQL = "SELECT Entidades.Codigo, Entidades.Nome, TipoEntidade.Descricao from Entidades left join TipoEntidade on TipoEntidade.Codigo=Entidades.CodTipo where Entidades.Nome like '%" + procurar + "%' and Entidades.Codigo!=3";
                else SQL = "SELECT Entidades.Codigo, Entidades.Nome, TipoEntidade.Descricao from Entidades left join TipoEntidade on TipoEntidade.Codigo=Entidades.CodTipo where Entidades." + Criterio + " And Entidades.Nome like '%" + procurar + "%' and Entidades.Codigo!=3 and Entidades.status=1";
            }

            if (tipoEntidades != "USUARIOS")
            {
                SQL += " Order by Entidades.Nome";
            }
            Object ob = Conexao.ClienteSql.SELECT(SQL);

            try
            {
               DadosEntidade = (DataTable)ob;
                //entidades = DadosEntidade.AsEnumerable<Entidade>().ToList();

                //for (int i = 0; i < DtDados.Rows.Count; i++)
                //{
                //    GradeEntidades.Rows.Add(); // Adicionar as Linhas
                //    for (int j = 0; j < DtDados.Columns.Count; j++)
                //    {
                //        GradeEntidades.Rows[i].Cells[j].Value = DtDados.Rows[i][j];
                //    }
                //}
            }
            catch (Exception ER)
            {
               // MessageBox.Show("Erro a Carregar Entidades \n" + ER.Message);
            }

            return entidades;
        }

        public List<Entidades> buscarEntidadeDocumento(string documentoID)
        {
            DataTable dtDados = new DataTable();

            try
            {
                string SQL = "Select Entidades.Codigo, Entidades.Nome from Entidades join Documentos on Documentos.CodEntidade= Entidades.Codigo where Documentos.Codigo='" + documentoID + "'";
                object ob = Conexao.ClienteSql.SELECT(SQL);
                dtDados = (DataTable)ob;

            }
            catch(Exception ex) {
                throw new Exception("Houve um erro a carregar " + ex.Message);
            }
            //List<Entidades> Entidades = new List<Entidades>(); List<Entidades> items = dtDados.AsEnumerable().Select(linha => new Entidades
            //{
            //    ID = linha.Field<Guid>("EntidadeCod"),
            //    Nome = linha.Field<String>("Nome")
            //}).ToList<Entidades>();
            return null;
        }

        public Guid EntidadePorDocumento(Guid documentoID)
        {
            Guid codigo = new Guid(); 
            DataTable dtDados = new DataTable();
            try
            {
                string SQL = "Select Entidades.Codigo, Entidades.Nome from Entidades join Documentos on Documentos.CodEntidade= Entidades.Codigo where Documentos.Codigo='" + documentoID + "'";
                object ob = Conexao.ClienteSql.SELECT(SQL);
                dtDados = (DataTable)ob;
            }
            catch(Exception a)
            {
                throw new Exception("Houve um erro a carregar " + a.Message);
            }
            return codigo;
        }

        public void lancarMotoristas(Guid documentoID, Guid motoristaID)
        {

            string[] Campos = { "CodDocumento", "CodMotorista" };
            Object[] Valores = { documentoID, motoristaID };
            DataTable dt = Conexao.BuscarTabela_com_Criterio("MovMotoristas", "CodDocumento='" + documentoID + "' and CodMotorista='" + motoristaID + "'");
            if (dt.Rows.Count > 0)
            {
                //throw new Exception("Motorista Já Adicionado !!!", "Adicionar Motorista", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*string x =*/ Conexao.ClienteSql.INSERT("MovMotoristas", Campos, Valores);

            //return x;

        }

        public void lancarTecnico(Guid documentoID, Guid tecnicoID)
        {

            string[] Campos = { "CodDocumento", "CodTecnico" };
            Object[] Valores = { documentoID, tecnicoID };
            /*string x =*/ Conexao.ClienteSql.INSERT("MovTecnicos", Campos, Valores);

            //return x;

        }

        public double LimiteDebitoCliente(Guid clienteID)
        {
            double limite = 0;

            DataTable dt = Conexao.BuscarTabela_com_Criterio("Entidades", "Codigo='" + clienteID + "'");
            if (dt.Rows.Count > 0)
            {
                limite = double.Parse(dt.Rows[0][4].ToString());
            }
            return limite;
        }

        public List<Entidades> Listar(string criterios)
        {
            var result = new List<Folha.Domain.Models.Entidades.Entidades>();

            var obj = Conexao.ClienteSql.SELECT(new string[] { "Entidades" },new string[] { }, new string[] { criterios });

            DataTable dtadados = (DataTable)obj;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Folha.Domain.Models.Entidades.Entidades>(dtadados);

            return result;
        }

        public bool PodeCreditar(double valor, Guid clienteID)
        {
            double Limite = 0; bool Res = false;
            bool admin = false;

            string SQL = "SELECT LIMITE from Entidades WHERE Codigo ='" + clienteID + "'";
            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable Dtdados = (DataTable)x;

            if (Dtdados.Rows.Count > 0)
            {
                Limite = double.Parse(Dtdados.Rows[0][0].ToString());
            }
            if (Saldo_Conta(clienteID, admin) > 0)
            {
                if (Saldo_Conta(clienteID, admin) + valor < Limite) Res = true;
            }
            else
                if (valor < Limite) Res = true;

            return Res;
        }

        public double Saldo_Conta(Guid clienteID, bool admin)
        {

            Double Credito = 0;
            Double Debito = 0;
            Double Total = 0;
            string Criterio = " and Operacoes.Nome<> 'NOTA DE PAGAMENTO'";
            string Criterio2 = " and Operacoes.Nome<> 'RECIBO'";

            if (admin)
            {

                string SQL = null;
                object x = null;

                SQL = "SELECT Pagamentos.Data as DATA,Pagamentos.Hora as HORA,Pagamentos.Descricao as DESCRICAO, Pagamentos.Tipo AS TIPO, Pagamentos.Valor AS VALOR, Usuarios.Nome as USUARIO from Pagamentos";
                SQL += " join Turnos on Turnos.Codigo=Pagamentos.CodTurno join Usuarios on Usuarios.Codigo=Turnos.CodUsuario join Documentos on Documentos.Codigo=Pagamentos.CodDocumento join Operacoes on Operacoes.Codigo=Documentos.CodOperacao";
                SQL += " WHERE Documentos.CodEntidade ='" + clienteID + "' " + Criterio + "";
                x = Conexao.ClienteSql.SELECT(SQL);

                DataTable DtPagamentos = (DataTable)x;

                SQL = "SELECT Documentos.Data as DATA,Documentos.Hora as HORA,Operacoes.Nome as DESCRICAO,Operacoes.MovFin as TIPO, Documentos.Total as VALOR, Documentos.Codigo as NUMERO, Operacoes.Nome as OPERACAO, Usuarios.Nome as USUARIO from Documentos ";
                SQL += " LEFT OUTER JOIN Operacoes on Operacoes.Codigo=Documentos.CodOperacao join Usuarios on Usuarios.Codigo=Documentos.CodUsuario";
                SQL += " WHERE Documentos.CodEntidade ='" + clienteID + "' And Operacoes.Entidade='CLIENTE' And Operacoes.Movfin='CREDITO' and Documentos.Estado like 'FECHADO' " + Criterio2 + "";
                x = Conexao.ClienteSql.SELECT(SQL);

                DataTable DtOperacoes = (DataTable)x;

                foreach (DataColumn col in DtOperacoes.Columns) col.ReadOnly = false;

                for (int i = 0; i < DtOperacoes.Rows.Count; i++)
                {
                    string Descricao = DtOperacoes.Rows[i]["DESCRICAO"].ToString();

                    DtOperacoes.Rows[i]["DESCRICAO"] = DtOperacoes.Rows[i]["DESCRICAO"] + " Nº: " + DtOperacoes.Rows[i]["NUMERO"];
                    if (!Descricao.Trim().Equals("RECIBO"))
                    {
                        DtOperacoes.Rows[i]["TIPO"] = "DEBITO";
                    }

                }

                DtOperacoes.Columns.RemoveAt(5);
                DataTable DtDados = DtOperacoes.Clone();
                for (int i = 0; i < DtPagamentos.Rows.Count; i++)
                {
                    DtDados.ImportRow(DtPagamentos.Rows[i]);
                }

                for (int i = 0; i < DtOperacoes.Rows.Count; i++)
                {
                    DtDados.ImportRow(DtOperacoes.Rows[i]);
                }

                for (int i = 0; i < DtDados.Rows.Count; i++)
                {

                    string Tipo = DtDados.Rows[i]["TIPO"].ToString();
                    if (Tipo.Equals("CREDITO")) Credito += double.Parse(DtDados.Rows[i]["VALOR"].ToString());
                    if (Tipo.Equals("DEBITO")) Debito += double.Parse(DtDados.Rows[i]["VALOR"].ToString());



                }

                Total = Credito - Debito;


            }
            return Total;
        }

        public Guid UsuarioDocumento(Guid documentoID)
        {
            Guid result = new Guid();

            DataTable dtDados = new DataTable();
            try
            {
                string SQL = "Select Usuarios.Codigo, Usuarios.Nome from Usuarios join Documentos on Documentos.CodUsuario = Usuarios.Codigo where Documentos.Codigo='" + documentoID + "'";
                object ob = Conexao.ClienteSql.SELECT(SQL);
                dtDados = (DataTable)ob;

            }
            catch { }


            return result;
        }

        #region CRUD GENÉRICO
        public void Insert(EntidadesViewModel entity)
        {
            Db.Add(entity);
           
        }
        public void InsertWithAllDependent(EntidadesViewModel entity)
        {
            Insert(entity);

            int codigo = (int)GetCodLast();
            saveContacto(codigo, entity.Contactos);
            saveContas(codigo, entity.Contas);
            saveMoradas(codigo, entity.Moradas);
            saveDocuments(codigo, entity.Documentos);

        }

        private void SalvarDadosPessoa(EntidadesPessoaViewModel pessoa)
        {
            if (Equals(pessoa, null) || UtilidadesGenericas.EntidadeValida(pessoa))
            {
                return;
            }
            Db.Add(pessoa);
        }

        public void UpdateWithAllDependent(EntidadesViewModel entity)
        {
            Update(entity);

            int codigo = entity.Codigo;
            saveContacto(codigo, entity.Contactos);
            saveContas(codigo, entity.Contas);
            saveMoradas(codigo, entity.Moradas);
            saveDocuments(codigo, entity.Documentos);

        }

        private void saveContas(int entityId, List<EntidadesContasViewModel> contas)
        {

            var contaRepository = new EntidadesContasRepository();
            foreach (var conta in contas)
            {
                conta.CodEntidade = entityId;
                if (conta.codigo <= 0)
                    contaRepository.Insert(conta);

                else contaRepository.Update(conta);
            }
        }
        private void saveMoradas(int entityId, List<MoradaViewModel> moradas)
        {

            var contaRepository = new MoradasRepository();
            foreach (var conta in moradas)
            {
                conta.IDPessoa = entityId;
                if (conta.IDMorada <= 0)
                    contaRepository.Insert(conta);

                else contaRepository.Update(conta);
            }
        }
        private void saveDocuments(int entityId, List<DocumentosEntidadeViewModel> documentos)
        {

            var contaRepository = new DocumentoEntidadeRepository();
            foreach (var conta in documentos)
            {
                conta.CodEntidade = entityId;
                if (conta.codigo <= 0)
                    contaRepository.Insert(conta);

                else contaRepository.Update(conta);
            }
        }

        private void saveContacto(int entityId, List<ContactosViewModel> Contactos)
        {

            var contactRepository = new ContactoRepository();
            foreach (var contact in Contactos)
            {
                contact.CodEntidade = entityId;
                if (contact.codigo <= 0)
                    contactRepository.Insert(contact);

                else contactRepository.Update(contact);
            }
        }
        private void insertEntityPessoa(EntidadesViewModel entity)
        {
            if (entity.Tipo.codigo == 1)
            {
                var entities = ((List<EntidadesViewModel>)GetAll(new EntidadesViewModel()));
                var entityInserted = entities[entities.Count - 1];

                var pessoasRepository = new EntidadePessoasRepository();
                if (entity.Pessoas.Count > 0)
                {
                    entity.Pessoas[0].CodEntidade = entityInserted.Codigo;
                    pessoasRepository.Insert(entity.Pessoas[0]);
                }
            }
        }
        private void updateEntityPessoa(EntidadesViewModel entity)
        {
            if (entity.Tipo.codigo == 1)
            {
                var lastId = entity.Codigo;
                if (entity.Codigo == 0)
                    lastId = (int)GetCodLast();

                var pessoasRepository = new EntidadePessoasRepository();
                if (entity.Pessoas.Count > 0)
                {
                    entity.Pessoas[0].CodEntidade = (int)lastId;
                    if (entity.Pessoas[0].CodEntidade <= 0 && pessoasRepository.Get(entity.Pessoas[0]) == null)
                        pessoasRepository.Insert(entity.Pessoas[0]);
                    else
                        pessoasRepository.Update(entity.Pessoas[0]);
                }
            }
        }

        public object Get(EntidadesViewModel entity)
        {
            return Db.GetById<EntidadesViewModel>(entity.Codigo);
        }
        public object GetCodLast()
        {
            var obj = Conexao.ClienteSql.SELECT("Select  MAX(Codigo) As Codigo From Entidades");

            DataTable dtadados = (DataTable)obj;

            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Entidades>(dtadados).ToList();

            return result[0].Codigo;
        }
        public EntidadesViewModel GetWithAllDependents(int id)
        {
            EntidadesViewModel entity = (EntidadesViewModel)Get(new EntidadesViewModel() { Codigo = id });
            if (Equals(entity, null)) return null;

            entity.Contactos = new ContactoRepository().GetAllForNorm(entity.Codigo);
            entity.Contas = new EntidadesContasRepository().GetAllForNorm(entity.Codigo);
            entity.Documentos = new DocumentoEntidadeRepository().GetAllForNorm(entity.Codigo);
            entity.Moradas = new MoradasRepository().GetAllForNorm(entity.Codigo);
            entity.Pessoas.Add((EntidadesPessoaViewModel)new EntidadePessoasRepository().Get(new EntidadesPessoaViewModel() { CodEntidade = id }));
            return entity;
        }
        public object GetAll(EntidadesViewModel entity)
        {
            return Db.GetEntities<EntidadesViewModel>();
        }
        public List<EntidadesViewModel> GetAll(string criterio)
        {
            return Db.GetEntities<EntidadesViewModel>("WHERE " + criterio);
        }
        public EntidadesViewModel GetEntidadePorNome(string nome)
        {

            return Db.GetEntities<EntidadesViewModel>("WHERE Nome = '" + nome + "'").FirstOrDefault();
        }
        public void Update(EntidadesViewModel entity)
        {
            Db.Update(entity);
            updateEntityPessoa(entity);
        }

        public void Delete(EntidadesViewModel entity)
        {
            //Conexao.ClienteSql.DELETE("Entidades", "Codigo ='" + entity.Codigo + "'");
            Db.Delete(entity);
        }
        public void MudarEstadoEntidade(int codEntidade, int estado)
        {
            Conexao.ClienteSql.UPDATE("Entidades", new string[] { "Status" }, new object[] { estado }, "Codigo = '" + codEntidade + "'");
        }
        private string getSQL(string entidade, string tipoEntidade)
        {
            string SQL = "";

            if (entidade == "CLIENTES")
            {
                SQL = "SELECT Entidades.Codigo As Codigo, " +
                                        "Entidades.Nome As Nome, " +
                                        "Entidades.limite As Limite, " +
                                        "EstadoCivil.descricao As EstadoCivil," +
                                        "Sexo.descricao As Sexo " +
                    "from Entidades left join TipoEntidade on TipoEntidade.Codigo=Entidades.CodTipo " +
                                            "left join EntidadesPessoa on EntidadesPessoa.CodEntidade = Entidades.Codigo " +
                                            "left Join EstadoCivil on EntidadesPessoa.CodEstadoCivil = EstadoCivil.codigo" +
                                            " left Join Sexo  on EntidadesPessoa.CodSexo = Sexo.codigo " +
                    " where  Entidades.Cliente=1 and Entidades.Codigo!=3 and status=1 And TipoEntidade.Codigo = " + tipoEntidade;
            }
            if (entidade == "FORNECEDORES")
            {

                SQL = "SELECT Entidades.Codigo, " +
                                        "Entidades.Nome, " +
                                        "Entidades.limite, " +
                                        "Entidades.Codigo " +
                    "from Entidades left join TipoEntidade on TipoEntidade.Codigo=Entidades.CodTipo" +
                                            " join Fornecedores on Fornecedores.CodEntidade=Entidades.Codigo " +
                                            "left join EntidadesPessoa on EntidadesPessoa.CodEntidade = Entidades.Codigo " +
                    "where status=1 And TipoEntidade.Codigo = " + tipoEntidade;
            }

            if (entidade == "FUNCIONARIOS")
            {
                SQL = "SELECT Entidades.Codigo, " +
                                        "Entidades.Nome As Nome, " +
                                        "Entidades.limite As Limite, " +
                                        "EstadoCivil.descricao As EstadoCivil," +
                                        "Sexo.descricao As Sexo " +
                    "from Entidades left join TipoEntidade on TipoEntidade.Codigo=Entidades.CodTipo " +
                                            "left join EntidadesPessoa on EntidadesPessoa.CodEntidade = Entidades.Codigo " +
                                            "left Join EstadoCivil on EntidadesPessoa.CodEstadoCivil = EstadoCivil.codigo" +
                                            " left Join Sexo  on EntidadesPessoa.CodSexo = Sexo.codigo " +
                                            "join Funcionarios on Funcionarios.CodEntidade=Entidades.Codigo" +
                                            " join EntidadesPessoa on EntidadesPessoa.CodEntidade = Entidades.Codigo " +
                    "where status=1 And TipoEntidade.Codigo = " + tipoEntidade;
            }
            if (entidade == "JURIDICA")
            {
                SQL = "SELECT " +
                        "Entidades.Codigo, " +
                        "Entidades.Nome As Nome, " +
                        "Entidades.limite As Limite " +
                    "from Entidades left join TipoEntidade on TipoEntidade.Codigo=Entidades.CodTipo " +
                    "where status=1 And TipoEntidade.Codigo = " + tipoEntidade;
            }
            return SQL;
        }

        public List<EntidadesNViewModel> ListarEntidade(string entidade, string tipoEntidade)
        {
            var result = new List<EntidadesNViewModel>();
            string SQL = getSQL(entidade, tipoEntidade) + " order by Nome";

            var obj = Conexao.ClienteSql.SELECT(SQL);

            DataTable dtadados = (DataTable)obj;

            result = DataTableHelper.DataTableToList<EntidadesNViewModel>(dtadados);

            return result;
        }

        #region MinhaRegiao
        //--------------------------------------
        //LISTAGEM
        //--------------------------------------
        public AllEntidadeViewModel ListEntidadeGetAll(string codEntidade)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT Entidades.Codigo, Entidades.Nome as Nome, Entidades.Nif as Nif, Entidades.CodTipo as CodTipo, Entidades.CodPais as CodPais,Pais.Descricao as Nacionalidade,Entidades.Foto, EntidadesPessoa.CodSexo as CodSexo," +
                     "Sexo.descricao as Sexo, EntidadesPessoa.DataNascimento, EntidadesPessoa.CodEstadoCivil as CodEstadoCivil, EntidadesPessoa.CodProfissao as CodProfissao, Profissao.Descricao as Profissao, EntidadesPessoa.CodHabilitacao as" +
                     " CodHabilitacao, Habilitacoes.Descricao as Habilitacao,EntidadesPessoa.CodEstadoCivil,EstadoCivil.descricao as EstadoCivil, Funcionarios.CodDepartamento, EntidadesPessoa.NomePai, EntidadesPessoa.NomeMae, Entidades.Limite from" +
                     " Entidades left Outer join EntidadesPessoa on EntidadesPessoa.CodEntidade = Entidades.Codigo left Outer join Profissao on Profissao.Codigo = EntidadesPessoa.CodProfissao left Outer join Habilitacoes on Habilitacoes.Codigo = EntidadesPessoa.CodHabilitacao" +
                     " left Outer join Funcionarios on Funcionarios.CodEntidade = Entidades.Codigo left Outer join Sexo on Sexo.codigo = EntidadesPessoa.CodSexo left Outer join EstadoCivil on EstadoCivil.codigo = EntidadesPessoa.CodEstadoCivil  left Outer join Pais on Pais.codigo=Entidades.CodPais";

                            var List = new List<AllEntidadeViewModel>();
                AllEntidadeViewModel result;
                if (!string.IsNullOrEmpty(codEntidade))
                {
                    SQL += " Where Entidades.Codigo='" + codEntidade + "'";

                    var ob = Conexao.ClienteSql.SELECT(SQL);

                    DtDados = (DataTable)ob;
                    List = DataTableHelper.DataTableToList<AllEntidadeViewModel>(DtDados);
                    return result = List[0];
                }
                else
                {
                    SQL += " Where Entidades.CodTipo='" + 1 + "'";
                    var ob = Conexao.ClienteSql.SELECT(SQL);

                    DtDados = (DataTable)ob;
                    List = DataTableHelper.DataTableToList<AllEntidadeViewModel>(DtDados);
                    return result = List[0];
                }
            }
            catch (Exception ex )
            {
                throw new Exception("Erro ao listar Entidade\n"+ex.Message);
            }
        }

        IEnumerable<EntidadeContaViewModel> IEntidadesRepository.CarregaContas(string CodEntidade)
        { 
            try
            {
                string[] campos = { "EntidadesContas.codigo", "EntidadesContas.CodBanco", "Bancos.Descricao as Banco", "EntidadesContas.Numero", "EntidadesContas.Natureza", "EntidadesContas.Sequencia", "EntidadesContas.Iban", "EntidadesContas.Swift" };
                string[] tabelas = { "EntidadesContas" };
                string[] CriteriosTodos = { "Bancos on EntidadesContas.CodBanco=Bancos.codigo" };
                string[] criterios = { "EntidadesContas.CodEntidade='" + CodEntidade + "'" };
                var ob = Conexao.ClienteSql.LEFTJOIN(tabelas[0].ToString(), campos, CriteriosTodos, criterios);

                DataTable DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<Folha.Domain.ViewModels.Frame.Entidades.EntidadeContaViewModel>(DtDados);
                return result;
            }
            catch (Exception x)
            {
                throw new Exception("Erro a Carregar Contas Bancárias \n" + x.Message);
            }
        }

        IEnumerable<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> IEntidadesRepository.CarregaDocumentos(string CodEntidade)
        {
            try
            {
                string[] campos = { "DocumentosEntidade.codigo", "DocumentosEntidade.CodTipoDocumento", "TiposDocumentos.descricao as TipoDocumento", "DocumentosEntidade.Numero", "DocumentosEntidade.Emissao", "DocumentosEntidade.Validade" };
                string[] tabelas = { "DocumentosEntidade" };
                string[] CriteriosTodos = { "TiposDocumentos on TiposDocumentos.codigo=DocumentosEntidade.CodTipoDocumento " };
                string[] criterios = { "DocumentosEntidade.CodEntidade='" + CodEntidade + "'" };
                Object ob = Conexao.ClienteSql.INNERJOIN(tabelas[0].ToString(), campos, CriteriosTodos, criterios);

                DataTable DtDocumentos = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel>(DtDocumentos);
                return result;
            }
            catch (Exception x)
            {
                throw new Exception("Erro a carregar Documentos \n" + x);
            }
        }

        public IEnumerable<Folha.Domain.ViewModels.Frame.Entidades.ContactoViewModel> CarregaContactos(string CodEntidade)
        {
            string[] campos = { "Contactos.Codigo", "Contactos.CodTipoContacto", "TipoContacto.descricao as TipoContacto", "Contactos.Descricao" };
            string[] tabelas = { "Contactos" };
            string[] CriteriosTodos = { "TipoContacto on TipoContacto.codigo = Contactos.CodTipoContacto" };
            string[] criterio = { "Contactos.CodEntidade='" + CodEntidade + "'" };

            Object ob = Conexao.ClienteSql.INNERJOIN(tabelas[0].ToString(), campos, CriteriosTodos, criterio);
            try
            {
                DataTable DtContactos = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<Folha.Domain.ViewModels.Frame.Entidades.ContactoViewModel>(DtContactos);
                return result;
            }
            catch (Exception) { throw new Exception("Erro a Carregar os Contactos \n" + (string)ob); }
        }

        IEnumerable<MoradaViewModel> IEntidadesRepository.CarregaMorada(string CodEntidade)
        {
            try
            { 
                string[] campos = { "Morada.IDMorada", "Morada.DescricaoMorada" };
                string[] tabelas = { "Morada" };
                string[] CriteriosTodos = { "Entidades on Entidades.codigo=Morada.IDPessoa" };
                string[] criterios = { "Morada.IDPessoa='" + CodEntidade + "'" };
                Object ob = Conexao.ClienteSql.SELECT(tabelas, campos, criterios);
                DataTable DtMorada = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<MoradaViewModel>(DtMorada);
                return result;
            }
            catch(Exception) { throw new Exception("Erro listar Morada"); }
        }

        //--------------------------------------
        //INSERT UPDATE
        //--------------------------------------
        public void UpdateEntidade(AllEntidadeViewModel Dados)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Entidades",
                Campos = new string[] { "Nome", "Nif", "CodTipo","Limite", "CodPais",  "Foto", "status" },
                Valores = new Object[] { Dados.Nome,Dados.Nif,"1",Dados.Limite, Dados.CodPais,Dados.Foto,"1" }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + Dados.Codigo + "'");
        }

        public void InserirEntidade(AllEntidadeViewModel Dados)
        {

            DbDTO dto = new DbDTO()
            {
                Nome = "Entidades",
                Campos = new string[] { "Nome", "Nif", "CodTipo", "Limite", "CodPais","Cliente", "Foto", "status", "CodCondicaoPagamento" },
                Valores = new Object[] { Dados.Nome, Dados.Nif, "1", Dados.Limite, Dados.CodPais,1, Dados.Foto, "1", 1 }
            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
        }

        public void InserirContactos (string CodEntidade, List<ContactoViewModel> Lista)
        {
            try
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[i].Codigo == "0" || Lista[i].Codigo==null)
                    {
                        string[] campos = { "CodEntidade", "CodTipoContacto", "descricao" };
                        Object[] valores = { CodEntidade, Lista[i].CodTipoContacto, Lista[i].Descricao };
                        Conexao.ClienteSql.INSERT("Contactos", campos, valores);                      
                    }
                }
            }
            catch (Exception ex)
            { throw new Exception("Erro a Gravar Contactos \n" + ex.Message); }
        }

        public void InserirContasBancarias(string CodEntidade,List<Folha.Domain.ViewModels.Frame.Entidades.EntidadeContaViewModel> Lista)
        {
                try
                {
                    for (int i = 0; i <Lista.Count; i++)
                    {
                        if (Lista[i].Codigo == "0" || Lista[i].Codigo == null)
                        {
                            string[] campos = { "CodEntidade", "Numero", "CodBanco", "Iban", "swift", "Natureza", "Sequencia" };
                            Object[] valores = { CodEntidade, Lista[i].Numero, Lista[i].CodBanco, Lista[i].Iban,Lista[i].Swift, Lista[i].Natureza, Lista[i].Sequencia };
                            Conexao.ClienteSql.INSERT("EntidadesContas", campos, valores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro a Gravar Contas Bancárias \n" + ex.Message);
                }
            }     
        public void InserirMoradas(string CodEntidade, List<MoradaViewModel> Lista)
        {
            try
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[i].IDMorada == 0)
                    {
                        string[] campos = { "IDPessoa", "DescricaoMorada", "status" };
                        Object[] valores = { CodEntidade, Lista[i].DescricaoMorada, 1 };
                        Conexao.ClienteSql.INSERT("Morada", campos, valores);
                    }
                }
            }
            catch (Exception x)
            {
                throw new Exception("Erro a Gravar Moradas \n" + x);
            }
        }

        public void InserirDocumentos(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> Lista)
        {
            try
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[i].Codigo == "0"|| Lista[i].Codigo == null)
                    {
                        string[] campos = { "CodEntidade", "CodTipoDocumento", "Numero", "Emissao", "Validade" };
                        Object[] valores = { CodEntidade, Lista[i].CodTipoDocumento, Lista[i].Numero, Lista[i].Emissao, Lista[i].Validade };
                        Conexao.ClienteSql.INSERT("DocumentosEntidade", campos, valores);
                    }
                }
            }
            catch (Exception x)
            {
                throw new Exception("Erro a Gravar Documentos \n" + x);
            }
        }
        public void ActualizaContactos(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.ContactoViewModel> Lista)
        {
            try
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[i].Codigo != "0" || Lista[i].Codigo != null)
                    {
                        string[] campos = { "CodEntidade", "CodTipoContacto", "descricao" };
                        Object[] valores = { CodEntidade, Lista[i].CodTipoContacto, Lista[i].Descricao };

                        Conexao.ClienteSql.UPDATE("Contactos", campos, valores, "codigo = '" + Lista[i].Codigo + "'");
                    }
                }
            }
            catch (Exception ex)
            { throw new Exception("Erro a Gravar Contactos \n" + ex.Message); }
        }

        public void ActualizaContasBancarias(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.EntidadeContaViewModel> Lista)
        {
            try
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[i].Codigo != "0" || Lista[i].Codigo != null)
                    {
                        string[] campos = { "CodEntidade", "Numero", "CodBanco", "Iban", "swift", "Natureza", "Sequencia" };
                        Object[] valores = { CodEntidade, Lista[i].Numero, Lista[i].CodBanco, Lista[i].Iban, Lista[i].Swift, Lista[i].Natureza, Lista[i].Sequencia };
                        Conexao.ClienteSql.UPDATE("EntidadesContas", campos, valores, "codigo = '" + Lista[i].Codigo + "'");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Gravar Contas Bancárias \n" + ex.Message);
            }
        }
        public void ActualizaMoradas(string CodEntidade, List<MoradaViewModel> Lista)
        {
            try
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[i].IDMorada != 0 )
                    {
                        string[] campos = { "IDPessoa", "DescricaoMorada", "status" };
                        Object[] valores = { CodEntidade, Lista[i].DescricaoMorada, 1 };
                        Conexao.ClienteSql.UPDATE("Morada", campos, valores, "IDMorada='" + Lista[i].IDMorada + "'");
                    }
                }
            }
            catch (Exception x)
            {
                throw new Exception("Erro a Gravar Moradas \n" + x);
            }
        }

        public void ActualizaDocumentos(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> Lista)
        {
            try
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[i].Codigo != "0" || Lista[i].Codigo != null)
                    {
                        string[] campos = { "CodEntidade", "CodTipoDocumento", "Numero", "Emissao", "Validade" };
                        Object[] valores = { CodEntidade, Lista[i].CodTipoDocumento, Lista[i].Numero, Lista[i].Emissao, Lista[i].Validade };
                        Conexao.ClienteSql.UPDATE("DocumentosEntidade", campos, valores, "codigo='" + Lista[i].Codigo + "'");
                    }
                }
            }
            catch (Exception x)
            {
                throw new Exception("Erro a Gravar Documentos \n" + x);
            }
        }

        public void DeleteContactos(List<ContactoViewModel> Lista)
        {
            try
            {
                if (Lista[0].Codigo != "0" || Lista[0].Codigo != null)
                {
                    Conexao.ClienteSql.DELETE("Contactos", "Codigo ='" + Lista[0].Codigo + "'");
                }
            }
            catch (Exception ex)
            { throw new Exception("Erro ao Deletar Contactos \n" + ex.Message); }
        }

        public void DeleteContasBancarias(List<Folha.Domain.ViewModels.Frame.Entidades.EntidadeContaViewModel> Lista)
        {
            try
            {
                if (Lista[0].Codigo != "0" || Lista[0].Codigo != null)
                {                   
                        Conexao.ClienteSql.DELETE("EntidadesContas", "Codigo ='" + Lista[0].Codigo + "'");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Deletar Contas Bancária \n" + ex.Message);
            }
        }
        public void DeleteMoradas(List<MoradaViewModel> Lista)
        {
            try
            {
                if (Lista[0].IDMorada!= 0 )
                {
                    Conexao.ClienteSql.DELETE("Morada", "IDMorada ='" + Lista[0].IDMorada + "'");
                }
            }
            catch (Exception x)
            {
                throw new Exception("Erro a Deletar Morada \n" + x);
            }
        }

        public void DeleteDocumentos(List<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> Lista)
        {
            try
            {
                if (Lista[0].Codigo != "0" || Lista[0].Codigo != null)
                {
                    Conexao.ClienteSql.DELETE("DocumentosEntidade", "Codigo ='" + Lista[0].Codigo + "'");
                }
            }
            catch (Exception x)
            {
                throw new Exception("Erro ao Deletar Documento \n" + x);
            }
        }

        void IEntidadesRepository.SalvarDadosPessoa(EntidadesPessoaViewModel pessoa)
        {
            if (Equals(pessoa, null))
            {
                return;
            }
            Db.Add(pessoa);
        }

        public void EditarDadosPessoa(EntidadesPessoaViewModel pessoa)
        {
            if (Equals(pessoa, null) || UtilidadesGenericas.EntidadeValida(pessoa))
            {
                return;
            }
            Db.Update(pessoa);
        }

        public ContactosViewModel GetContactoByEntidade(string CodEntidade)
        {
            return new ContactoRepository().GetContactoByEntidade(int.Parse(CodEntidade));
        }

        public MoradaViewModel GetMoradaByEntidade(string CodEntidade)
        {
            return new MoradasRepository().GetMoradaByEntidade(int.Parse(CodEntidade));
        }

        #endregion


        #endregion

    }
}
