using Folha.Domain.Enuns.Genericos;
using Folha.Domain.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Folha.Driver.Repository.Data
{
    
    public class DbCostum
    {
        private enum CRUD
        {
            Create, Read, Updade, Delete
        }
        private enum TypeOrder
        {
            Columns, Values
        }
        private ETipoBancoDados TipoSGBD;
        private SqlCommand sCommand { get; set; }
        private SqlConnection sConnection { get; set; }
        private MySqlCommand mCommand { get; set; }
        private MySqlConnection mConnection { get; set; }
        private List<string> Campos { get; set; }
        private List<object> Valores { get; set; }

        public DbCostum(ETipoBancoDados tipoSGBD)
        {
            TipoSGBD = tipoSGBD;
            InitConexao();
            Campos = new List<string>();
            Valores = new List<object>();
        }

        private void InitConexao()
        {
            TipoSGBD = UtilidadesGenericas.ConexaoCorrente.tipoBancoDados;
            if (TipoSGBD == ETipoBancoDados.MySQL)
            {
                if (!Equals(Conexao.ClienteSql, null))
                {
                    mConnection = Conexao.ClienteSql.GetConexaoMySQL();
                    mCommand = mConnection.CreateCommand();
                }
            }
            else
            {
                if (!Equals(Conexao.ClienteSql, null))
                {
                    sConnection = Conexao.ClienteSql.GetConexaoSQL();
                    sCommand = sConnection.CreateCommand();
                }
            }
        }

        private void OpenConnection()
        {
            InitConexao();
            if (TipoSGBD == ETipoBancoDados.MySQL)
            {
                if (mConnection.State == ConnectionState.Closed)
                {
                    mConnection.Open();
                }
            }
            else
            {
                if (sConnection.State == ConnectionState.Closed)
                {
                    sConnection.Open();
                }
            }
        }
        private void CloseConnection()
        {
            InitConexao();
            if (TipoSGBD == ETipoBancoDados.MySQL)
            {
                if (mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            else
            {
                if (sConnection.State == ConnectionState.Open)
                {
                    sConnection.Close();
                }
            }
        }
        private bool IsEnumrable(PropertyInfo field)
        {
            return field.PropertyType.Name.Contains("IEnumerable")||
                   field.PropertyType.Name.Contains("ICollection")|| 
                   field.PropertyType.Name.Contains("IList")||
                   field.PropertyType.Name.Contains("List");
        }
        private bool IsKey(object entity, PropertyInfo field)
        {
            var fieldName = field.Name;
            return fieldName == entity.GetType().GetProperty("NameKey").GetValue(entity).ToString();

        }
        private bool IsFKey(object entity, PropertyInfo field)
        {
            var fieldName = field.Name;
            var fieldForeignKey = entity.GetType().GetProperty("ForeignKey");
            if (Equals(fieldForeignKey, null))
                return false;
            return fieldName == entity.GetType().GetProperty("ForeignKey").GetValue(entity).ToString();

        }
        private bool IsForeignKey(PropertyInfo field)
        {
            return field.PropertyType.Name == "ForeignKey";
        }
        private bool IsFielEntity(PropertyInfo field)
        {
            return field.PropertyType.FullName.Contains("Domain") && 
                   !IsForeignKey(field) &&
                   !IsEnumrable(field);
        }
        private object getField(DataRow row, object entity)
        {
            foreach (var field in entity.GetType().GetProperties())
            {
                if (IsFielEntity(field))
                {
                    var valueField = entity
                                        .GetType()
                                        .GetProperty(field.Name)
                                        .GetValue(entity);
                    field.SetValue(
                        entity,
                        getField(row, valueField)
                    );
                }
                else if (!IsEnumrable(field) && !IsForeignKey(field) && field.Name != "NameKey" && field.Name != "ForeignKey")
                {
                    string nameColunm = getNameTable(entity) + field.Name;
                    object value = row[nameColunm];
                    if (Equals(value.GetType().FullName.ToLower(), "System.DBNull".ToLower()))
                    {
                        field.SetValue(entity, null);
                    }
                    else
                        field.SetValue(entity, value);
                }

            }
            return entity;
        }
        private List<T> ToListCostum<T>(DataTable datas)where T : class, new()
        {
            List<T> entities = new List<T>();
            foreach (DataRow row in datas.Rows)
            {
                T entity = new T();
                entity = (T)getField(row, entity);
                entities.Add(entity);
            }
            return entities;
        }
        private void clearParameters()
        {
            if (TipoSGBD == ETipoBancoDados.MySQL)
            {
                mCommand.Parameters.Clear();
            }
            else
            {
                sCommand.Parameters.Clear();
            }
            Campos.Clear();
            Valores.Clear();
             
        }
        private void addValue(string name, object value, object entity)
        {
            InitConexao();
            value = TratarValor(name, value, entity);
            if (!isNull(value))
            {
                if (TipoSGBD == ETipoBancoDados.MySQL)
                {
                    mCommand.Parameters.AddWithValue("?" + name, value);
                }
                else
                {
                    sCommand.Parameters.AddWithValue("@" + name, value);
                }
                Campos.Add(name);
                Valores.Add(value);
            }
        }

        private object TratarValor(string name, object value, object entity)
        {
            if (UmaChaveEstrangeira(name, entity) && Equals(value, 0))
            {
                return DBNull.Value;
            }
            return value;
        }

        private bool UmaChaveEstrangeira(string name, object entity)
        {
            var fKeys = entity.GetType().GetProperties().Where(p => p.PropertyType.Name == "ForeignKey").ToList();
            foreach (var item in fKeys)
            {
                var valueField = item.GetValue(entity);
                var fieldAqui = valueField.GetType().GetProperty("NameFieldThis");
                var nomeAqui = fieldAqui.GetValue(valueField);
                if (nomeAqui.ToString() == name)
                {
                    return true;
                }
            }
            return false;
        }

        private bool isNull(object value)
        {
            return Equals(value, null) || Equals(value, new DateTime());
        }

        private  string orderParameters(TypeOrder type)
        {
            string strParameters = "";

            if (TipoSGBD == ETipoBancoDados.MySQL)
            {
                strParameters = GetParametersMySql(type);
            }
            else
            {
                strParameters = GetParametersSql(type);
            }

            return strParameters;
        }

        private string GetParametersSql(TypeOrder type)
        {
            string strParameters = string.Empty;
            foreach (SqlParameter item in sCommand.Parameters)
            {
                if (item.ParameterName.Contains("@ForeignKey"))
                {
                    continue;
                }
                string name = type == TypeOrder.Columns ?
                    item.ParameterName.Replace("@", string.Empty) :
                    item.ParameterName;
                strParameters += strParameters.Equals(string.Empty) ?
                    name : "," + name;
            }
            return strParameters;
        }

        private string GetParametersMySql(TypeOrder type)
        {
            string strParameters = string.Empty;
            foreach (MySqlParameter item in mCommand.Parameters)
            {
                if (item.ParameterName.Contains("?ForeignKey"))
                {
                    continue;
                }
                string name = type == TypeOrder.Columns ?
                    item.ParameterName.Replace("?", string.Empty) :
                    item.ParameterName;
                strParameters += strParameters.Equals(string.Empty) ?
                    name : "," + name;
            }
            return strParameters;
        }

        List<string> listTables = new List<string>();
        private string getJoins(object entity)
        {
            string joins = "";
            string nameTable = getNameTable(entity);

            if (nameTable == "Documentos")
            {

            }
            foreach (var field in entity.GetType().GetProperties())
            {
                if (IsForeignKey(field))
                {
                    var valueField = entity.GetType().GetProperty(field.Name).GetValue(entity);

                    string nameTaleJoin = field
                        .PropertyType
                        .GetProperty("NameTable")
                        .GetValue(valueField).ToString();
                    if (nameTaleJoin == "Entidades")
                    {

                    }
                    string nameColumnOrigin = field
                            .PropertyType
                            .GetProperty("NameFieldOrigin")
                            .GetValue(valueField).ToString();

                    string nameColumnThis = field
                            .PropertyType
                            .GetProperty("NameFieldThis")
                            .GetValue(valueField).ToString();

                    string nameEntity = field
                            .PropertyType
                            .GetProperty("NameEntity")
                            .GetValue(valueField).ToString();
                    var oldTable = listTables.Where(t => Equals(t, nameTaleJoin)).FirstOrDefault();
                    if (Equals(oldTable, null))
                    {
                        if (listTables.Count == 0)
                            listTables.Add(nameTable);

                        joins += " LEFT JOIN [" + nameTaleJoin + "] ON [" + nameTable + "]." + nameColumnThis + " = [" + nameTaleJoin + "]." + nameColumnOrigin;
                        var newJoin = getJoins(entity.GetType().GetProperty(nameEntity).GetValue(entity));
                        joins += joins.Contains(newJoin) ? "" : newJoin;

                        listTables.Add(nameTaleJoin);
                    }
                }
            }


            return joins;
        }
        private string getColumnKey(object entity)
        {
            string name = "Codigo";
            foreach (var field in entity.GetType().GetProperties())
            {
                if (IsKey(entity, field))
                {
                    name = field.Name;
                    break;
                }
            }
            return name;
        }
        private string getColumns(object entity)
        {
            string columns = string.Empty;
            string nameTable = "[" + getNameTable(entity) + "]";
            foreach (var field in entity.GetType().GetProperties())
            {
                
                if (IsEnumrable(field) || IsForeignKey(field) || columns.Contains(nameTable + "." + field.Name))
                    continue;
                if (IsFielEntity(field))
                {
                    if (Equals(entity.GetType().GetProperty(field.Name).GetValue(entity), null))
                    {

                    }
                    columns += columns.Equals(string.Empty) ?
                        getColumns(entity.GetType().GetProperty(field.Name).GetValue(entity)) :
                        ", " + getColumns(entity.GetType().GetProperty(field.Name).GetValue(entity));

                }
                else if(field.Name != "NameKey" && field.Name != "ForeignKey")
                {
                    
                    columns += columns.Equals(string.Empty) ?
                        nameTable + "." + field.Name + " AS " + getNameTable(entity) + field.Name :
                        ", " + nameTable + "." + field.Name + " AS " + getNameTable(entity) + field.Name;

                }
            }

            return columns;
        }
        private string getCriterio(object entity)
        {
            var nameKey = (string)entity.GetType().GetProperty("NameKey").GetValue(entity);
            return TrocarSeparador( " WHERE [" + getNameTable(entity) + "]." +
                entity.GetType().GetProperty("NameKey").GetValue(entity) +
                " = " + entity.GetType().GetProperty(nameKey).GetValue(entity));
        }
        private string GetNorm(object entity)
        {
            var nameKey = (string)entity.GetType().GetProperty("NameKey").GetValue(entity);
            return TrocarSeparador(" [" + getNameTable(entity) + "]." +
                entity.GetType().GetProperty("NameKey").GetValue(entity) +
                " = " + entity.GetType().GetProperty(nameKey).GetValue(entity));
        }
        private string getCriterio(object entity, int id)
        {
            return " WHERE [" + getNameTable(entity) + "]." +
                entity.GetType().GetProperty("NameKey").GetValue(entity) +
                " = " + id;
        }
        private string getCreateQuery(string nameTable, string criterio)
        {
            return TrocarSeparador("INSERT INTO [" + nameTable + "] ( " + orderParameters(TypeOrder.Columns) + " ) " +
                "VALUES ( " + orderParameters(TypeOrder.Values) + " )");
        }

        private string TrocarSeparador(string query)
        {
            if (TipoSGBD == ETipoBancoDados.MySQL)
            {
                return query.Replace("[", "`").Replace("]", "`");
            }
            else
            {
                return query.Replace("`", "[").Replace("`", "]");
            }
        }

        private string getReadQuery(string nameTable, string criterio, object entity)
        {
            return TrocarSeparador("SELECT " + getColumns(entity) +
                        " FROM [" + nameTable + "] " + getJoins(entity) + " " + criterio);
        }
        private string getUpdateQuery(string nameTable, string criterio)
        {
            string[] columns = orderParameters(TypeOrder.Columns).Split(',');
            string[] values = orderParameters(TypeOrder.Values).Split(',');
            string query = "";
            for (int i = 0; i < columns.Length; i++)
            {
                query += i.Equals(0) ?
                    columns[i] + " = " + values[i] :
                    ", " + columns[i] + " = " + values[i];
            }
            query = "UPDATE [" + nameTable + "] SET " + query + " " + criterio;
            return TrocarSeparador(query);
        }
        private string getDeleteQuery(string nameTable, string criterio)
        {
            return TrocarSeparador("DELETE FROM [" + nameTable + "] " + criterio);
        }
        private string getQuery(CRUD typeQuery, string nameTable, string criterio, object entity)
        {
            string query = "";
            nameTable = nameTable.Replace("ViewModel", string.Empty);
            switch (typeQuery)
            {
                case CRUD.Create:
                    query = getCreateQuery(nameTable, criterio);
                    break;
                case CRUD.Read:
                    query = getReadQuery(nameTable, criterio, entity);
                    break;
                case CRUD.Updade:
                    query = getUpdateQuery(nameTable, criterio);
                    break;
                case CRUD.Delete:
                    query = getDeleteQuery(nameTable, criterio);
                    break;

                default:
                    break;
            }
            return query;
        }
        private bool executeSql(CRUD type, string nameTable, string criterio, object entity)
        {
            OpenConnection();
            bool result = false;
            if (TipoSGBD == ETipoBancoDados.MySQL)
            {
                if (mCommand.Parameters.Count > 0)
                {
                    mCommand.CommandText = getQuery(type, nameTable, criterio, entity);
                    MySqlDataReader reader = mCommand.ExecuteReader();
                    result = reader.Read();
                    clearParameters();
                }
            }
            else
            {
                if (sCommand.Parameters.Count > 0)
                {
                    sCommand.CommandText = getQuery(type, nameTable, criterio, entity);
                    SqlDataReader reader = sCommand.ExecuteReader();
                    result = reader.Read();
                    clearParameters();
                }
            }
            return result;
        }
        private DataTable SelectTable(CRUD type, string nameTable, string criterio, object entity)
        {
            DataTable tableResult = new DataTable();
            try
            {
                OpenConnection();
                //mCommand.CommandText = getQuery(type, getNameTable(entity), criterio, entity);
                listTables.Clear();
                //SqlDataAdapter adp = new SqlDataAdapter(, mConnection);
                //SqlDataReader reader = mCommand.ExecuteReader();
                var query = getQuery(type, getNameTable(entity), criterio, entity);
                var objData = Conexao.ClienteSql.SELECT(query);
                //if (objData.GetType().Name.Trim().ToLower() == "string")
                //{
                //    return new DataTable();
                //}
                tableResult = (DataTable)objData;

                clearParameters();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return tableResult;
        }
        public void Add<T>(T entity) where T : class, new()
        {
            if (Equals(entity, null))
            {
                return;
            }
            foreach (var field in entity.GetType().GetProperties())
            {
                if ((IsKey(entity, field) && !IsFKey(entity, field)) ||
                    IsEnumrable(field) ||
                    field.Name == "NameKey" ||
                    field.Name == "ForeignKey" ||
                    IsForeignKey(field))
                {
                    continue;
                }
                    if (!IsFielEntity(field))
                    {
                        addValue(
                            field.Name,
                            field.GetValue(entity),
                            entity
                        );
                    }

            }
            Conexao.ClienteSql.INSERT(getNameTable(entity), Campos.ToArray(), Valores.ToArray());
            clearParameters();
            //executeSql(CRUD.Create, getNameTable(entity), "", entity);
            CloseConnection();
        }
        public void Update<T>(T entity) where T : class, new()
        {
            if (Equals(entity, null))
            {
                return;
            }
            foreach (var field in entity.GetType().GetProperties())
            {
                if (!IsKey(entity, field) &&
                    !IsEnumrable(field) &&
                    field.Name != "NameKey" &&
                    !IsForeignKey(field))
                {
                    if (!IsFielEntity(field))
                    {
                        addValue(
                            field.Name,
                            field.GetValue(entity),
                            entity
                        );
                    }
                }
            }
            Conexao.ClienteSql.UPDATE(getNameTable(entity), Campos.ToArray(), Valores.ToArray(), GetNorm(entity));
            clearParameters();
            //mysqldump -u root -p FolhaERP > C:\Users\TestBACKUP\backup.sql
            //mysqlimport -u root -p C:\Users\TestBACKUP\backup.sql > folharest
            //executeSql(CRUD.Updade, getNameTable(entity), getCriterio(entity), entity);
            CloseConnection();
        }
        public List<T> GetEntities<T>() where T : class, new()
        {
            var entity = new T();
            List<T> entities = ToListCostum<T>(SelectTable(CRUD.Read, getNameTable(entity), "", entity));
            CloseConnection();
            return entities;
        }
        public T GetById<T>(int id)where T : class, new()
        {
            T entity = new T();
            var entities = ToListCostum<T>(SelectTable(
                CRUD.Read,
                getNameTable(entity), 
                getCriterio(entity, id), 
                entity)
            );
            CloseConnection();
            if (entities.Count == 0)
            {
                return null;
            }
            return entities[0];
        }
        public void Delete<T>(T entity) where T : class, new()
        {
            executeSql(CRUD.Delete, getNameTable(entity), getCriterio(entity), entity);
            CloseConnection();
        }
        private string getNameTable<T>(T entity) where T : class, new()
        {
            var nameTable = entity.GetType().Name.Replace("ViewModel", string.Empty);

            return nameTable;
        }

        public List<T> GetEntities<T>(string criterio) where T : class, new()
        {
            var entity = new T();
            List<T> entities = ToListCostum<T>(SelectTable(CRUD.Read, getNameTable(entity), criterio, entity));
            CloseConnection();
            return entities;
        }
    }
}
