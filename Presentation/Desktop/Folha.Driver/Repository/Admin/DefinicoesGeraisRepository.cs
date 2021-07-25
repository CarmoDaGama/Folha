using System;
using Folha.Driver.Repository;
using Folha.Domain.Models.Administrador;
using Folha.Domain.ViewModels.Admin;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Admin;
using Folha.Driver.Repository.Data;
using System.Data;
using System.Collections.Generic;
using Folha.Domain.Helpers;
using Folha.Domain.Models.Admin;

namespace Folha.Driver.Repository.Administrador
{
    public class DefinicoesGeraisRepository : RepositoryBase<DbDTO>, IDefinicoesGeraisRepository
    {
        
        #region LISTAR  
        public List<DefinicoesGeraisViewModel> ListarGerais(string Criterio)
        {
            string[] Cam = { "VenderSemStock", "HospedagemAberta", "LucroPos", "Documento", "Cliente", "ObrigatorioComissionario", "ImprimirComissionarios", "VariasLinhas" };
            DataTable TabelaDados = new DataTable();
            List<DefinicoesGeraisViewModel> litaReturn = new List<DefinicoesGeraisViewModel>();
            string[] tabelas = { "DefGeral" };
            String[] Criterios = { Criterio };
            Object ob;

            if (Criterio != null)
                ob = Conexao.ClienteSql.SELECT(tabelas, Cam, Criterios);
            else
                ob = Conexao.ClienteSql.SELECT(tabelas, Cam, null);
            try
            {
                TabelaDados = (DataTable)ob;
                litaReturn = DataTableHelper.DataTableToList<DefinicoesGeraisViewModel>(TabelaDados);
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar  DefGeral  \n" + (string)ob);
            }

            return litaReturn;
        }
        public List<DefinicoesPrecosViewModel> ListarPrecos(string Criterio)
        {
            string[] Cam = { "Preco1", "Preco2", "Preco3" };
            DataTable TabelaDados = new DataTable();
            List<DefinicoesPrecosViewModel> litaReturn = new List<DefinicoesPrecosViewModel>();
            string[] tabelas = { "DefPreco" };
            String[] Criterios = { Criterio };
            Object ob;

            if (Criterio != null)
                ob = Conexao.ClienteSql.SELECT(tabelas, Cam, Criterios);
            else
                ob = Conexao.ClienteSql.SELECT(tabelas, Cam, null);
            try
            {
                TabelaDados = (DataTable)ob;
                litaReturn = DataTableHelper.DataTableToList<DefinicoesPrecosViewModel>(TabelaDados);
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar  DefPreco  \n" + (string)ob);
            }

            return litaReturn;
        }
        public List<DefinicoesFacturaViewModel> ListarFacturas(string Criterio)
        {

            string[] Cam = { "Detalhes", "Validade", "Decreto" };
            DataTable TabelaDados = new DataTable();
            List<DefinicoesFacturaViewModel> litaReturn = new List<DefinicoesFacturaViewModel>();
            string[] tabelas = { "DefFactura" };
            String[] Criterios = { Criterio };
            Object ob;

            if (Criterio != null)
                ob = Conexao.ClienteSql.SELECT(tabelas, Cam, Criterios);
            else
                ob = Conexao.ClienteSql.SELECT(tabelas, Cam, null);
            try
            {
                TabelaDados = (DataTable)ob;
                litaReturn = DataTableHelper.DataTableToList<DefinicoesFacturaViewModel>(TabelaDados);
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar  Factura  \n" + (string)ob);
            }

            return litaReturn;
        }
        public List<DefinicoesHotelViewModel> ListarHoteis(string Criterio)
        {
            string[] Cam = { "Checkin", "CheckOut", "CTempo", "Automatico", "Horas", "Consumidor" };
            DataTable TabelaDados = new DataTable();
            List<DefinicoesHotelViewModel> litaReturn = new List<DefinicoesHotelViewModel>();
            string[] tabelas = { "Defhotel" };
            String[] Criterios = { Criterio };
            Object ob;

            if (Criterio != null)
                ob = Conexao.ClienteSql.SELECT(tabelas, Cam, Criterios);
            else
                ob = Conexao.ClienteSql.SELECT(tabelas, Cam, null);
            try
            {
                TabelaDados = (DataTable)ob;
                litaReturn = DataTableHelper.DataTableToList<DefinicoesHotelViewModel>(TabelaDados);
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar  Hotel  \n" + (string)ob);
            }

            return litaReturn;
        }

        #endregion

        #region UPDATE
        public DefinicoesGerais GravarGeral(DefinicoesGerais definicao)
        {
            string[] campos = { "VenderSemStock", "HospedagemAberta", "LucroPos", "Documento", "Cliente", "ObrigatorioComissionario", "ImprimirComissionarios", "VariasLinhas" };
            Object[] valores = {definicao.VenderSemStock, definicao.HospedagemAberta, definicao.LucroPos, definicao.Documento, definicao.Cliente, definicao.ObrigatorioComissionario, definicao.ImprimirComissionarios, definicao.VariasLinhas };
            string[] crit = { "Codigo is not null " };
            string tabela = "DefGeral";
            Conexao.ClienteSql.UPDATE(tabela, campos, valores, crit);
            return definicao;
        }
        public DefinicoesPreco GravarPreco(DefinicoesPreco definicao)
        {
            string[] Campos = { "Preco1", "Preco2", "Preco3" };
            Object[] valores = { definicao.Preco1, definicao.Preco2, definicao.Preco3};
            string[] crit = { "Codigo is not null " };
            string tabela = "DefPreco";
            Conexao.ClienteSql.UPDATE(tabela, Campos, valores, crit);
            return definicao;
        }

        public DefinicoesFactura GravarFactura(DefinicoesFactura definicao)
        {
            string[] Campos = { "Detalhes", "Validade", "Decreto" };
            Object[] valores = { definicao.Detalhes, definicao.Validade, definicao.Decreto };
            string[] criterio = { "Codigo is not null " };
            string tabela = "DefFactura";
            Conexao.ClienteSql.UPDATE(tabela, Campos, valores, criterio);
            return definicao;
        }

        public DefinicoesHotel GravarHotel(DefinicoesHotel definicao)
        {
            string[] campos = { "Checkin", "CheckOut", "CTempo", "Automatico", "Horas", "Consumidor" };
            Object[] valores = { definicao.Checkin, definicao.CheckOut, definicao.CTempo, definicao.Automatico, definicao.Horas, definicao.Consumidor };
            string[] criterios = { "Codigo is not null " };
            string tabela = "DefHotel";
            Conexao.ClienteSql.UPDATE(tabela, campos, valores, criterios);
            return definicao;
        }
        #endregion  

        #region REPOSITORY BASE
        public void Delete(DefinicoesGeraisViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public object Get(DefinicoesGeraisViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public object GetAll(DefinicoesGeraisViewModel tabela)
        {
            throw new NotImplementedException();
        }
        public void Insert(DefinicoesGeraisViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public void Update(DefinicoesGeraisViewModel tabela)
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}
