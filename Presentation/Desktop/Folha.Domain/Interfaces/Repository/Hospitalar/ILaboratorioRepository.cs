using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.ViewModels.Hospitalar;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Hospitalar
{
    public interface ILaboratorioRepository : IRepositoryBase<ExamesAtendimentoViewModel>
    {
        IEnumerable<Laboratorio> Listar(string criterios);
        Laboratorio Gravar(Laboratorio lab);
        void Delete(Laboratorio lab);
        List<ExamesAtendimentoViewModel> GetAll();
        IEnumerable<Laboratorio> FiltrarLaboratorioEstadoData(string valor, string dtInicoEst, string dtFim);
        ContactosViewModel GetContactoByEntidade(string CodEntidade);

    }
}
