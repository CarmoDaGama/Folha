using Folha.Domain.Models.Entidades;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.Enuns.Entidades;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Entidades
{
    public interface IEntidadesApp
    {
        IEnumerable<ViewModels.Frame.Entidades.ContactoViewModel> CarregaContactos(string CodEntidade);
        List<EntidadesViewModel> Listar(int status);
        void addEntidade(EntidadesViewModel entity);
        void EditEntidade(EntidadesViewModel entity);
        List<EntidadesViewModel> Listar();
        List<EntidadeViewModel> ListarEntidade(string entidade, string tipoEntidade, TypeEntity tipo, int status);
        void RemoverEntidade(EntidadesViewModel entidade);
        EntidadesViewModel GetById(int codigo);
        EntidadesViewModel GetByIdWithAllDependent(int codigo);
        int GetCodLastEntity();
        void EditarDadosPessoa(EntidadesPessoaViewModel pessoa);
        void SalvarDadosPessoa(EntidadesPessoaViewModel pessoa);
        #region Regiao
        ViewModels.Frame.Entidades.AllEntidadeViewModel ListEntidadeGetAll(string codEntidade);
        void UpdateEntidade(ViewModels.Frame.Entidades.AllEntidadeViewModel Dados);
        void InserirContactos(string CodEntidade, List<ViewModels.Frame.Entidades.ContactoViewModel> Lista);
        void InserirContasBancarias(string CodEntidade, List<ViewModels.Frame.Entidades.EntidadeContaViewModel> Lista);
        void InserirMoradas(string CodEntidade, List<MoradaViewModel> Lista);
        void InserirDocumentos(string CodEntidade, List<ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> Lista);
        void InserirEntidade(ViewModels.Frame.Entidades.AllEntidadeViewModel Dados);
        IEnumerable<ViewModels.Frame.Entidades.EntidadeContaViewModel> CarregaContas(string CodEntidade);
        IEnumerable<ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> CarregaDocumentos(string CodEntidade);
        ContactosViewModel GetTelefoneByEntidade(string CodEntidade);
        MoradaViewModel GetMoradaByEntidade(string CodEntidade);
        IEnumerable<MoradaViewModel> CarregaMorada(string CodEntidade);
        void ActualizaContactos(string CodEntidade, List<ViewModels.Frame.Entidades.ContactoViewModel> Lista);
        void ActualizaContasBancarias(string CodEntidade, List<ViewModels.Frame.Entidades.EntidadeContaViewModel> Lista);
        void ActualizaMoradas(string CodEntidade,List<MoradaViewModel> Lista);
        void ActualizaDocumentos(string CodEntidade, List<ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> Lista);
        void DeleteContactos(List<ViewModels.Frame.Entidades.ContactoViewModel> Lista);
        void DeleteMoradas(List<MoradaViewModel> Lista);
        void DeleteDocumentos(List<ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> Lista);
        void DeleteContasBancarias(List<ViewModels.Frame.Entidades.EntidadeContaViewModel> Lista);
#endregion
    }
}
