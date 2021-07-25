using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Frame.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Hospitalar
{
    public interface IMedicosApp
    {
        List<MedicosViewModel> ListarMedicosDisponiveis(string Nome, string CodEscala, string CodEspecialidade, string hora, string data);
        void AddMedicos(Medicos Dados);
        void UpdateMedicos(Medicos Dados);
        void AddMedicoEspecialidade(List<MedicosEspecialidades> Lista);
        IEnumerable<MedicosEspecialidades> GetAllMedicoEspecialidade(string CodMedico);
        IEnumerable<Medicos> GetMedico(string CodPessoa);
        void UpdateMedicoEspecialidade(MedicosEspecialidades Dados);
        IEnumerable<MedicosViewModel> ListarMedicos(string Nome, string CodEscala, string CodEspecialidade);
        Medicos Eliminar(Medicos medico);

        List<MedicoEspecialidadeViewModel> ListarMedicoEspecialidade(string CodMedico);
        void DeleteListEspecialidade(List<MedicoEspecialidadeViewModel> Lista);
        int GetIdMedico(string CodEntidade);
        int GetLastIdMedico();
        List<MedicosViewModel> ListarMedicoFiltrado(string criterio);

    }
}
