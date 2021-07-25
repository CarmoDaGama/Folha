using Folha.Domain.Interfaces.Application.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using Folha.Domain.ViewModels.Frame.Hospitalar;

namespace Folha.Driver.Application.Hospitalar
{
    public class MedicosApp : IMedicosApp
    {
        private readonly IMedicosRepository _MedicosRepository;

        public MedicosApp(IMedicosRepository MedicosRepository)
        {
            _MedicosRepository = MedicosRepository;
        }

        public void AddMedicoEspecialidade(List<MedicosEspecialidades> Lista)
        {
            _MedicosRepository.AddMedicoEspecialidade(Lista);
        }

        public void AddMedicos(Medicos Dados)
        {
            _MedicosRepository.Insert(Dados);
        }

        public IEnumerable<Medicos> GetMedico(string CodPessoa)
        {
            return _MedicosRepository.GetMedico(CodPessoa);
        }

        public IEnumerable<MedicosEspecialidades> GetAllMedicoEspecialidade(string CodMedico)
        {
            return _MedicosRepository.GetAllMedicoEspecialidade(CodMedico);
        }

        public List<MedicoEspecialidadeViewModel> ListarMedicoEspecialidade(string CodMedico)
        {
            return _MedicosRepository.ListarMedicoEspecialidade(CodMedico);
        }

        public IEnumerable<MedicosViewModel> ListarMedicos(string Nome, string CodEscala, string CodEspecialidade)
        {
            return _MedicosRepository.ListarMedicos(Nome,CodEscala,CodEspecialidade);
        }

        public void UpdateMedicoEspecialidade(MedicosEspecialidades Dados)
        {
            _MedicosRepository.UpdateMedicoEspecialidade(Dados);
        }

        public void UpdateMedicos(Medicos Dados)
        {
            _MedicosRepository.Update(Dados);
        }

        public void DeleteListEspecialidade(List<MedicoEspecialidadeViewModel> Lista)
        {
            _MedicosRepository.DeleteListEspecialidade(Lista);
        }

        public int GetIdMedico(string CodEntidade)
        {
          return  _MedicosRepository.GetIdMedico(CodEntidade);
        }

        public int GetLastIdMedico()
        {
            return _MedicosRepository.GetLastIdMedico();
        }

        public List<MedicosViewModel> ListarMedicosDisponiveis(string Nome, string CodEscala, string CodEspecialidade, string hora, string data)
        {
            return _MedicosRepository.ListarMedicosDisponiveis(Nome, CodEscala, CodEspecialidade, hora, data);
        }

        public List<MedicosViewModel> ListarMedicoFiltrado(string criterio)
        {
            return _MedicosRepository.ListarMedicoFiltrado(criterio);
        }

        public Medicos Eliminar(Medicos medico)
        {
            return _MedicosRepository.Eliminar(medico);
        }
    }
}
