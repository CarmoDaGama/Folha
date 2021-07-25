using Folha.Domain.Models.Entidades;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Hospitalar
{
    using Folha.Domain.Models.Entidades;
    using Folha.Domain.ViewModels.Entidades;

    public interface IPacienteApp
    {
        //IEnumerable<Paciente> ListarTudo(string criterios);
        //List<Paciente> Listar(string criterios);
        List<PacienteViewModel> GetAll(string criterios);
        void Insert(Paciente tabela);
        void Update(Paciente tabela);
        void Delete(Paciente tabela);
        List<GrupoSanguineos> ListarGrupoSanguineo(GrupoSanguineos GrupoSanguineo);
        //
        void RemoverEntidade(EntidadesViewModel entidade);
        EntidadesViewModel GetById(int codigo);
        EntidadesViewModel GetByIdWithAllDependent(int codigo);
        int GetCodLastEntity();
        Folha.Domain.ViewModels.Frame.Entidades.AllEntidadeViewModel ListEntidadeGetAll(string codEntidade);
        void UpdateEntidade(Folha.Domain.ViewModels.Frame.Entidades.AllEntidadeViewModel Dados);
        void ActualizaMoradas(string CodEntidade, List<Morada> Lista);
        void ActualizaDocumentos(string CodEntidade, List<Folha.Domain.ViewModels.Frame.Entidades.DocumentoEntidadeViewModel> Lista);
        PacienteViewModel GetByIdPaciente(int EntidadeId);
        PacienteViewModel GetByIdEntidade(int EntidadeId);
        string RetornaGrupoSanguines(string CodPaciente);
        List<PacienteViewModel> RetornaGrupoSPaciente(string Codgrupo);
    }
}
