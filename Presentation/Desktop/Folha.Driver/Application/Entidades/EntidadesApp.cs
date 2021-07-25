using System;
using System.Collections.Generic;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Driver.Repository.Entidades;
using System.Linq;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.Enuns.Entidades;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Frame.Entidades;

namespace Folha.Driver.Application.Entidades
{
    public class EntidadesApp : IEntidadesApp
    {
        private readonly IEntidadesRepository _Repository;

        public EntidadesApp(IEntidadesRepository Repository)
        { 
            this._Repository = Repository;
        }
        public List<EntidadesViewModel> Listar()
        {
            return (List<EntidadesViewModel>)_Repository.GetAll(new EntidadesViewModel());
        }
        public List<EntidadesViewModel> Listar(int status)
        {
            return _Repository.GetAll(" Status = '" + status + "'");
        }
        public void addEntidade(EntidadesViewModel entity)
        {
            _Repository.InsertWithAllDependent(entity);
            //inserirMoradas(entity.Moradas);
        }
        private void inserirMoradas(IEnumerable<Morada> moradas)
        {
            MoradasRepository repo = new MoradasRepository();
            foreach (Morada item in moradas)
            {
                DbDTO dto = new DbDTO()
                {
                    Nome = "Moradas", Campos = new string[] {"CodMorada", "Descricao"},
                     Valores = new object[] {item.IDMorada, item.DescricaoMorada}
                };

                repo.Insert(dto);
            }
        }

        public void EditEntidade(EntidadesViewModel entity)
        {
            _Repository.UpdateWithAllDependent(entity);
        }
        public List<EntidadeViewModel> ListarPorTipo(TypeEntity tipo)
        {
            var entidades = (List<Folha.Domain.Models.Entidades.Entidades>)_Repository.GetAll(new EntidadesViewModel());
            switch (tipo)
            {
                case TypeEntity.CLIENTE:
                    break;
                case TypeEntity.FUNCIONARIO:
                    entidades = entidades.Where(e => e.Funcionario == 1).ToList();
                    break;
                case TypeEntity.FORNECEDOR:
                    entidades = entidades.Where(e => e.Fornecedor == 1).ToList();
                    break;
                default:
                    break;
            }
            var EntidadeViews = Mapper<Folha.Domain.Models.Entidades.Entidades, EntidadeViewModel>.Map(entidades);

            return EntidadeViews;
        }

        public List<EntidadeViewModel> ListarEntidade(string entidade, string tipoEntidade, TypeEntity tipo, int status)
        {
            var entidades = (List <EntidadesViewModel> )_Repository.GetAll(new EntidadesViewModel());
            if (tipoEntidade == "Todos")
            {
                entidades = entidades.Where(e => e.status == status).ToList();
            }
            else
            {
                entidades = entidades.Where(e => e.CodTipo == int.Parse(tipoEntidade) && e.status == status).ToList();
            }
            switch (tipo)
            {
                case TypeEntity.CLIENTE:
                    break;
                case TypeEntity.FUNCIONARIO:
                    entidades = entidades.Where(e => e.Funcionario == 1).ToList();
                    break;
                case TypeEntity.FORNECEDOR:
                    entidades = entidades.Where(e => e.Fornecedor == 1).ToList();
                    break;
                default:
                    break;
            }
            var EntidadeViews = Mapper<EntidadesViewModel, EntidadeViewModel>.Map(entidades);

            return EntidadeViews;
        }

        public void RemoverEntidade(EntidadesViewModel entidade)
        {
            _Repository.MudarEstadoEntidade(entidade.Codigo, entidade.status);
        }

        public EntidadesViewModel GetById(int codigo)
        {
            return (EntidadesViewModel)_Repository.Get(new EntidadesViewModel() { Codigo = codigo });
        }
        public EntidadesViewModel GetByIdWithAllDependent(int codigo)
        {
            return _Repository.GetWithAllDependents(codigo);
        }

        public int GetCodLastEntity()
        {
            return (int)_Repository.GetCodLast();
        }
        #region MyRegion
        public Folha.Domain.ViewModels.Frame.Entidades.AllEntidadeViewModel ListEntidadeGetAll(string codEntidade)
        {
           return _Repository.ListEntidadeGetAll(codEntidade);
        }

        public void UpdateEntidade(Folha.Domain.ViewModels.Frame.Entidades.AllEntidadeViewModel Dados)
        {
            _Repository.UpdateEntidade(Dados);
        }

        public void InserirEntidade(Folha.Domain.ViewModels.Frame.Entidades.AllEntidadeViewModel Dados)
        {
            _Repository.InserirEntidade(Dados);
        }

        public void InserirContactos(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.ContactoViewModel> Lista)
        {
            _Repository.InserirContactos(CodEntidade, Lista);
        }

        public void InserirContasBancarias(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.EntidadeContaViewModel> Lista)
        {
            _Repository.InserirContasBancarias(CodEntidade,Lista);
        }

        public void InserirMoradas(string CodEntidade, List<MoradaViewModel> Lista)
        {
            _Repository.InserirMoradas(CodEntidade, Lista);
        }

        public void InserirDocumentos(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> Lista)
        {
            _Repository.InserirDocumentos(CodEntidade, Lista);
        }

        public IEnumerable<Folha.Domain.ViewModels.Frame.Entidades.EntidadeContaViewModel> CarregaContas(string CodEntidade)
        {
           return _Repository.CarregaContas(CodEntidade);
        }

        public IEnumerable<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> CarregaDocumentos(string CodEntidade)
        {
            return _Repository.CarregaDocumentos(CodEntidade);
        }

        public IEnumerable<Folha.Domain.ViewModels.Frame.Entidades.ContactoViewModel> GetContactoByEntidade(string CodEntidade)
        {
            return _Repository.CarregaContactos(CodEntidade);
        }

        public IEnumerable<MoradaViewModel> CarregaMorada(string CodEntidade)
        {
            return _Repository.CarregaMorada(CodEntidade);
        }

        public void ActualizaContactos(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.ContactoViewModel> Lista)
        {
            _Repository.ActualizaContactos(CodEntidade, Lista);
        }

        public void ActualizaContasBancarias(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.EntidadeContaViewModel> Lista)
        {
            _Repository.ActualizaContasBancarias(CodEntidade, Lista);
        }

        public void ActualizaMoradas(string CodEntidade,List<MoradaViewModel> Lista)
        {
            _Repository.ActualizaMoradas(CodEntidade, Lista);
        }

        public void ActualizaDocumentos(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> Lista)
        {
            _Repository.ActualizaDocumentos(CodEntidade, Lista);
        }

        public void DeleteContactos(List<ContactoViewModel> Lista)
        {
            _Repository.DeleteContactos(Lista);
        }

        public void DeleteMoradas(List<MoradaViewModel> Lista)
        {
            _Repository.DeleteMoradas(Lista);
        }

        public void DeleteDocumentos(List<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> Lista)
        {
            _Repository.DeleteDocumentos(Lista);
        }

        public void DeleteContasBancarias(List<Folha.Domain.ViewModels.Frame.Entidades.EntidadeContaViewModel> Lista)
        {
            _Repository.DeleteContasBancarias(Lista);
        }

        public void EditarDadosPessoa(EntidadesPessoaViewModel pessoa)
        {
            _Repository.EditarDadosPessoa(pessoa);
        }
        public void SalvarDadosPessoa(EntidadesPessoaViewModel pessoa)
        {
            _Repository.SalvarDadosPessoa(pessoa);
        }

        public ContactosViewModel GetTelefoneByEntidade(string CodEntidade)
        {
            return _Repository.GetContactoByEntidade(CodEntidade);
        }

        public MoradaViewModel GetMoradaByEntidade(string CodEntidade)
        {
            return _Repository.GetMoradaByEntidade(CodEntidade);
        }

        public IEnumerable<ContactoViewModel> CarregaContactos(string CodEntidade)
        {
            return _Repository.CarregaContactos(CodEntidade);
        }
        #endregion
    }
}
