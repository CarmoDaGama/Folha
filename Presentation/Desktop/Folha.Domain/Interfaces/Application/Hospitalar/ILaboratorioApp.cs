using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.ViewModels.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Hospitalar
{
    public interface ILaboratorioApp
    {
        Laboratorio Gravar(Laboratorio lab);
        IEnumerable<Laboratorio> Listar(string criterios, bool Pesquisa);
        void Delete(Laboratorio lab);
        List<ExamesAtendimentoViewModel> GetAll();
        ExamesAtendimentoViewModel GetById(int codigo);
         IEnumerable<Laboratorio> FiltrarLaboratorioEstadoData(string valor, string dtInicoEst, string dtFim);
        ContactosViewModel GetTelefoneByEntidade(string CodEntidade);


    }
}
