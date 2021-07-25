using Folha.Domain.Interfaces.Application.Documentos;
using System;
using System.Collections.Generic;
using Folha.Domain.Models.Documentos;
using Folha.Domain.Interfaces.Repository.Documentos;
using Folha.Domain.ViewModels.Frame.Sistema;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Helpers;
using Folha.Driver.Application.Sistema;
using System.Linq;
using Folha.Domain.ViewModels.Documentos;

namespace Folha.Driver.Application.Documentos
{
    public class AcessoDocumentosApp : IAcessoDocumentosApp
    {
        private readonly IAcessoDocumentosRepository Repository;
        private readonly IOperacoesApp OperacoesApp;
        public AcessoDocumentosApp(IAcessoDocumentosRepository repository, IOperacoesApp operacoesApp)
        {
            Repository = repository;
            OperacoesApp = operacoesApp;
        }
        public void Add(AcessoDocumentosViewModel acesso)
        {
            Repository.Insert(acesso);
        }

        public void editar(AcessoDocumentosViewModel acesso)
        {
            Repository.Update(acesso);
        }

        public void Eleminar(AcessoDocumentosViewModel acesso)
        {
            Repository.Delete(acesso);
        }

        public AcessoDocumentos GetPorId(int id)
        {
            return (AcessoDocumentos)Repository.Get(new AcessoDocumentosViewModel() { codigo = id });
        }

        public List<AcessoDocumentos> Listar()
        {
            return (List<AcessoDocumentos>)Repository.GetAll(new AcessoDocumentosViewModel());
        }
        public class CriteriosOperacoes
        {
            public string MovStk { get; set; }
            public int Codigo { get; set; } = -1;
        }
        public List<OperacaoViewModel> DocumentosPorUsuarios(string _TiposDocumentos, int usuarioID, bool admin)
        {
            List<AcessoDocumentos> resultDocumentos = Listar();
            CriteriosOperacoes ParmCriterios = new CriteriosOperacoes();
            List<OperacaoViewModel> result = new List<OperacaoViewModel>();

            try
            {
                //dtAplicacoes.Columns.Add("Aplicativo");

                string Criterios = "";
                if (!string.IsNullOrEmpty(_TiposDocumentos))
                {
                    if (admin)
                    {
                        if (_TiposDocumentos == "ENTRADAS")
                            resultDocumentos = resultDocumentos.Where(
                                d => d.Operacao.MovStk == "CREDITO" && 
                                d.CodUsuario == usuarioID
                            ).ToList();
                        if (_TiposDocumentos == "SAIDAS")
                            resultDocumentos = resultDocumentos.Where(
                                d => d.Operacao.MovStk == "DEBITO" && 
                                d.CodUsuario == usuarioID
                            ).ToList();
                       if (_TiposDocumentos == " and FINANCEIRO ")
                            resultDocumentos = resultDocumentos.Where(
                                d => d.Operacao.codigo != 0 && 
                                d.CodUsuario == usuarioID
                            ).ToList();
                    }
                    else
                    {
                        if (_TiposDocumentos == "ENTRADAS")
                            resultDocumentos = resultDocumentos.Where(
                                d => d.Operacao.MovStk == "CREDITO" 
                            ).ToList();
                        if (_TiposDocumentos == "SAIDAS")
                            resultDocumentos = resultDocumentos.Where(
                                d => d.Operacao.MovStk == "DEBITO" 
                            ).ToList();
                        if (_TiposDocumentos == " and FINANCEIRO ")
                            resultDocumentos = resultDocumentos.Where(
                                d => d.Operacao.codigo != 0 
                            ).ToList();
                    }
                }



                //for (int i = 0; i < dtAplicacoes.Rows.Count; i++)
                //{
                //    descritivo += "Operacoes." + dtAplicacoes.Rows[i]["Aplicativo"].ToString() + "=1  " + Criterios + " Or ";
                //}


                //descritivo = Folha.Domain.Helpers.Strings.Left(descritivo, descritivo.Length - 3);



                //if (admin)
                //{
                //    Criterios += " and AcessoDocumentos.CodUsuario='" + usuarioID + "'";
                //}

                //Criterios += " order by Operacoes.Nome";

                if (admin)
                {
                    result = Mapper<AcessoDocumentos, OperacaoViewModel>.Map(resultDocumentos.OrderBy(d => d.Operacao.Nome).ToList());
                }

                else
                {
                    result =  OperacoesApp.Listar(Criterios);
                }


                return result;


            }
            catch (Exception a)
            {
                throw new Exception(a.Message);
            }


        }
    }
}
