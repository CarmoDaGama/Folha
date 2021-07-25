using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Hospitalar
{
    using Folha.Domain.Models.Entidades;
    public interface IPacienteRepository: IRepositoryBase<Paciente>
    {
        PacienteViewModel GetById(int id);
        IEnumerable<Paciente> Listar(string criterios);
        List<GrupoSanguineos> ListarGrupoSanguineo(GrupoSanguineos GrupoSanguineo);
        List<PacienteViewModel> GetAll(PacienteViewModel pacienteViewModel,string criterios);
        string RetornaGrupoSanguines(string CodPaciente);
        //
        List<PacienteViewModel> RetornaGrupoSPaciente(string Codgrupo);
    }
}
