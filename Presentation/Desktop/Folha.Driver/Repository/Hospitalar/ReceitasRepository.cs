using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Models.Db;
using Folha.Driver.Repository.Data;
using System.Data;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Hospitalar;

namespace Folha.Driver.Repository.Hospitalar
{
    public class ReceitasRepository : IReceitasRepository
    {
        public void Insert(Receitas Dados)
        {
            try
            {
                    DbDTO dto = new DbDTO()
                    {
                        Nome = "Receitas",
                        Campos = new string[] { "CodPaciente", "CodMedico", "CodConsulta", "Observacao", "Data","CodAtendimento"},
                        Valores = new Object[] {  Dados.CodPaciente, Dados.CodMedico, Dados.CodConsulta, Dados.Observacao, Dados.Data,Dados.CodAtendimento}
                    };
                    Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);

            }
            catch (Exception) { throw new Exception("Erro ao gravar receitas"); }
        }

        public void Update(Receitas Dados)
        {
           
            try
            {
                if (Dados.CodPaciente == 0 && Dados.CodMedico == 0 && Dados.CodConsulta == 0)
                {
                    string Nome = "Receitas";
                    string[] Campos = { "CodAtendimento", "CodConsulta", "CodMedico", "CodPaciente" };
                    Object[] Valores = { Dados.CodAtendimento, Dados.CodConsulta, Dados.CodMedico, Dados.CodPaciente };
                    Conexao.ClienteSql.UPDATE(Nome, Campos, Valores, "Codigo ='" + Dados.Codigo + "'");
                }
                else if (Dados.CodPaciente !=0)
                {
                    string Nome = "Receitas";
                    string[] Campos = { "Observacao", "CodConsulta", "CodMedico", "CodPaciente" };
                    Object[] Valores = { Dados.Observacao, Dados.CodConsulta, Dados.CodMedico, Dados.CodPaciente };
                    Conexao.ClienteSql.UPDATE(Nome, Campos, Valores, "Codigo ='" + Dados.Codigo + "'");
                }
            }
            catch (Exception ex) { throw new Exception("Erro ao actualizar receitas" + ex.Message); }
        }
       

        public void InsertFarmaco(List<FarmacoReceitaViewModel> Lista)
        {
                try
                {
                    for (int i = 0; i < Lista.Count; i++)
                    {
                        if(Lista[i].CodFarmacoReceita==0)
                        {    
                            DbDTO dto = new DbDTO()
                            {
                                Nome = "FarmacoReceita",
                                Campos = new string[] { "CodPaciente", "CodFarmaco", "CodReceita","CodAtendimento"},
                                Valores = new Object[] { Lista[i].CodPaciente, Lista[i].CodFarmaco,Lista[i].CodReceita,Lista[i].CodAtendimento}
                            };

                            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);

                        }
                    }
                }
                catch (Exception ex) { throw new Exception("Erro ao gravar Farmacos"+ex.Message); }
        }
        public void UpdateFarmaco(List<FarmacoReceita> Lista)
        {
            try
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[i].Codigo != 0)
                    {
                        DbDTO dto = new DbDTO()
                        {
                            Nome = "FarmacoReceita",
                            Campos = new string[] { "CodAtendimento" },
                            Valores = new Object[] { Lista[i].CodAtendimento }
                        };

                        Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores,"Codigo="+Lista[i].Codigo);
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Erro ao gravar Farmacos" + ex.Message); }
        }
        public void DeleteFarmacos(FarmacoReceita Dados)
        {
            try
            {
                if (Dados.Codigo != 0)
                {
                    Conexao.ClienteSql.DELETE("FarmacoReceita", "Codigo ='" + Dados.Codigo + "'");
                }
            }
            catch (Exception)
            { throw new Exception("Erro ao Deletar Farmacos \n" ); }
        }

        public IEnumerable<Receitas> CarregaReceita(string CodAtendimento)
        {
            try
            {
                string SQL = "SELECT Receitas.Codigo As Codigo, " +
                                    "CodMedico," +
                                    "CodAtendimento," +
                                    " Entidades.Nome as NomeMedico, " +
                                    "Observacao " +
                                    "FROM Receitas, Medicos, " +
                                    "Entidades Where Receitas.CodMedico = Medicos.Codigo And Entidades.Codigo = Medicos.CodPessoa And  Receitas.CodAtendimento = " + CodAtendimento;
                Object ob = Conexao.ClienteSql.SELECT(SQL);
                DataTable DtFarmaco = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<Receitas>(DtFarmaco);
                return result;
            }
            catch (Exception) { throw new Exception("Erro listar Farmacos"); }
        }
        public List<ReceitasViewModel> ListaReceita(string CodAtendimento)
        {
            try
            {
                string SQL = "SELECT Receitas.Codigo As Codigo, " +
                                    "Receitas.CodConsulta," +
                                    "Receitas.CodMedico," +
                                    "Receitas.CodAtendimento," +
                                    " Entidades.Nome as NomeMedico, " +
                                    "TipoConsultas.Descricao as TipoConsulta, " +
                                    "ConsultaHospitalar.Atendido, " +
                                    "Receitas.Observacao " +
                                    " FROM Receitas, Medicos, " +
                                    " Entidades, ConsultaHospitalar, TipoConsultas " +
                            "Where Receitas.CodMedico = Medicos.Codigo And " +
                            "Entidades.Codigo = Medicos.CodPessoa And  " +
                            "Receitas.CodConsulta = ConsultaHospitalar.Codigo And " +
                            "ConsultaHospitalar.CodTipoConsulta = TipoConsultas.Codigo And " +
                            "Receitas.CodConsulta = " + CodAtendimento;

                Object ob = Conexao.ClienteSql.SELECT(SQL);
                DataTable DtFarmaco = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<ReceitasViewModel>(DtFarmaco);
                return result;
            }
            catch (Exception) { throw new Exception("Erro listar Farmacos"); }
        }
        public IEnumerable<FarmacoReceitaViewModel> CarregaFarmacos(string CodAtendimento)
        {
                try
                {
                string SQL = "SELECT Farmacos.Codigo as CodFarmaco, FarmacoReceita.Codigo as CodFarmacoReceita, Farmacos.Descricao, FarmacoReceita.CodAtendimento FROM FarmacoReceita " +
                "Join Farmacos ON Farmacos.Codigo=FarmacoReceita.CodFarmaco Join Receitas ON Receitas.Codigo= FarmacoReceita.CodReceita Where Receitas.CodConsulta =" + CodAtendimento;
                    Object ob = Conexao.ClienteSql.SELECT(SQL);
                    DataTable DtFarmaco = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<FarmacoReceitaViewModel>(DtFarmaco);
                    return result;
                }
                catch (Exception) { throw new Exception("Erro listar Farmacos"); }
        }
    }
}
