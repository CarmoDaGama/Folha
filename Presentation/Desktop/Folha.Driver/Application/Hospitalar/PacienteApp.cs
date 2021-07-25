using Folha.Domain.Interfaces.Application.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using Folha.Driver.Repository.Data;
using System.Data;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Models.Entidades;

namespace Folha.Driver.Application.Hospitalar
{
    using Folha.Domain.Models.Entidades;
    using Folha.Domain.ViewModels.Entidades;
    using Folha.Domain.Helpers;
    using Folha.Domain.ViewModels.Frame.Entidades;

    public class PacienteApp : IPacienteApp
    {
        private readonly IPacienteRepository _PacienteRepository;
        private readonly IEntidadesRepository _Repository;
        public PacienteApp(IPacienteRepository PacienteRepository)
        {
            _PacienteRepository = PacienteRepository;
        }
        public void Delete(Paciente tabela)
        {
            _PacienteRepository.Delete(tabela);
        }

        public List<PacienteViewModel> GetAll(string criterios)
        {
            return (List<PacienteViewModel>)_PacienteRepository.GetAll(new PacienteViewModel(),criterios);
        }

        public void Insert(Paciente tabela)
        {
             _PacienteRepository.Insert(tabela);
        }
        public void Update(Paciente tabela)
        {
            _PacienteRepository.Update(tabela);
        }



        public void RemoverEntidade(EntidadesViewModel entidade)
        {
            _Repository.Delete(entidade);
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
        public Folha.Domain.ViewModels.Frame.Entidades.AllEntidadeViewModel ListEntidadeGetAll(string codEntidade)
        {
            return _Repository.ListEntidadeGetAll(codEntidade);
        }
        public void UpdateEntidade(Folha.Domain.ViewModels.Frame.Entidades.AllEntidadeViewModel Dados)
        {
            _Repository.UpdateEntidade(Dados);
        }
        public IEnumerable<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> CarregaDocumentos(string CodEntidade)
        {
            return _Repository.CarregaDocumentos(CodEntidade);
        }

        public IEnumerable<Folha.Domain.ViewModels.Frame.Entidades.ContactoViewModel> CarregaContactos(string CodEntidade)
        {
            return _Repository.CarregaContactos(CodEntidade);
        }

        public IEnumerable<Morada> CarregaMorada(string CodEntidade)
        {
            return new List<Morada>();
        }

        public void ActualizaContactos(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.ContactoViewModel> Lista)
        {
            _Repository.ActualizaContactos(CodEntidade, Lista);
        }
        public void ActualizaMoradas(string CodEntidade, List<Morada> Lista)
        {
           // _Repository.ActualizaMoradas(CodEntidade, Lista);
        }

        public void ActualizaDocumentos(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> Lista)
        {
            _Repository.ActualizaDocumentos(CodEntidade, Lista);
        }

        public List<GrupoSanguineos> ListarGrupoSanguineo(GrupoSanguineos GrupoSanguineo)
        {
            return _PacienteRepository.ListarGrupoSanguineo(GrupoSanguineo);
        }

        public PacienteViewModel GetByIdEntidade(int EntidadeId)
        {
            var pacientes = _PacienteRepository.GetAll(new PacienteViewModel(),  EntidadeId + "");
            return UtilidadesGenericas.ListaNula(pacientes) ? null : pacientes.FirstOrDefault();
        }

        public string RetornaGrupoSanguines(string CodPaciente)
        {
            return _PacienteRepository.RetornaGrupoSanguines(CodPaciente);
        }

        public PacienteViewModel GetByIdPaciente(int id)
        {
            return _PacienteRepository.GetById(id);
        }

        public List<PacienteViewModel> RetornaGrupoSPaciente(string Codgrupo)
        {
            return _PacienteRepository.RetornaGrupoSPaciente(Codgrupo);
        }
    }
}
