using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Frame.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Hospitalar
{
    public interface IMedicosRepository : IRepositoryBase<Medicos>
    {
        List<MedicosViewModel> ListarMedicosDisponiveis(string Nome, string CodEscala, string CodEspecialidade, string hora, string data);
        void AddMedicoEspecialidade(List<MedicosEspecialidades> Lista);
        void UpdateMedicoEspecialidade(MedicosEspecialidades Dados);
        IEnumerable<MedicosEspecialidades> GetAllMedicoEspecialidade(string codigo);
        IEnumerable<Medicos> GetMedico(string codigo);
        IEnumerable<MedicosViewModel> ListarMedicos(string Nome, string CodEscala, string CodEspecialidade);
        List<MedicoEspecialidadeViewModel> ListarMedicoEspecialidade(string CodMedico);
        void DeleteListEspecialidade(List<MedicoEspecialidadeViewModel> Lista);
        int GetIdMedico(string CodEntidade);
        int GetLastIdMedico();
        Medicos Eliminar(Medicos medico);

        List<MedicosViewModel> ListarMedicoFiltrado(string criterio);
    }
}
