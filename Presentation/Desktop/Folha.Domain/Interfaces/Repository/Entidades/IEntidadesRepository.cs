using Folha.Domain.ViewModels.Frame.Entidades;
using Folha.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Entidades;

namespace Folha.Domain.Models.Entidades
{
    public  interface IEntidadesRepository : IRepositoryBase<EntidadesViewModel>
    {
        ContactosViewModel GetContactoByEntidade(string CodEntidade);
        MoradaViewModel GetMoradaByEntidade(string CodEntidade);
        List<EntidadesViewModel> GetAll(string criterio);
        void MudarEstadoEntidade(int codEntidade, int estado);
        void SalvarDadosPessoa(EntidadesPessoaViewModel pessoa);
        object GetCodLast();
        void UpdateWithAllDependent(EntidadesViewModel entity);
        void EditarDadosPessoa(EntidadesPessoaViewModel pessoa);
        EntidadesViewModel GetWithAllDependents(int id);
        void InsertWithAllDependent(EntidadesViewModel entity);
        Guid EntidadePorDocumento(Guid documentoID);
        Guid UsuarioDocumento(Guid documentoID);
        bool PodeCreditar(double valor, Guid clienteID);
        double Saldo_Conta(Guid clienteID, bool admin);
        double LimiteDebitoCliente(Guid clienteID);
        List<Entidades> buscarEntidadeDocumento(string documentoID);
        List<Entidades> BuscarDadosEntidade(string tipoEntidades, Guid consumidorID, string procurar, bool admin);
        void lancarTecnico(Guid documentoID, Guid tecnicoID);
        void lancarMotoristas(Guid documentoID, Guid motoristaID);
        List<Entidades> Listar(string criterios);
        List<Folha.Domain.ViewModels.Frame.Entidades.EntidadesNViewModel> ListarEntidade(string Entidade, string tipoEntidade);
        AllEntidadeViewModel ListEntidadeGetAll(string CodEntidade);
        void UpdateEntidade(AllEntidadeViewModel Dados);
        void InserirEntidade(AllEntidadeViewModel Dados);
        void InserirContactos(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.ContactoViewModel> Lista);
        #region Minhas Ganbiarras
        void InserirContasBancarias(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.EntidadeContaViewModel> Lista);
        void InserirMoradas(string CodEntidade, List<MoradaViewModel> Lista);
        void InserirDocumentos(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> Lista);
        IEnumerable<Folha.Domain.ViewModels.Frame.Entidades.EntidadeContaViewModel> CarregaContas(string CodEntidade);
        IEnumerable<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> CarregaDocumentos(string CodEntidade);
        IEnumerable<Folha.Domain.ViewModels.Frame.Entidades.ContactoViewModel> CarregaContactos(string CodEntidade);
        IEnumerable<MoradaViewModel> CarregaMorada(string CodEntidade);
        void ActualizaContactos(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.ContactoViewModel> Lista);
        void ActualizaContasBancarias(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.EntidadeContaViewModel> Lista);
        void ActualizaMoradas(string CodEntidade,List<MoradaViewModel> Lista);
        void ActualizaDocumentos(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> Lista);
        void DeleteContactos(List<ContactoViewModel> Lista);
        void DeleteMoradas(List<MoradaViewModel> Lista);
        void DeleteDocumentos(List<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> Lista);
        void DeleteContasBancarias(List<Folha.Domain.ViewModels.Frame.Entidades.EntidadeContaViewModel> Lista);
        #endregion
    }
}
