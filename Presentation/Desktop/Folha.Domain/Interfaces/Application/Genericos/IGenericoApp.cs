using Folha.Domain.ViewModels.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Genericos
{
    public interface IGenericoApp
    {
        GenericoViewModel GetDescricaoByCodigo(string Tabela, int Codigo);
        bool VerificarRegisto(string Tabela, string Campo, string ParametroBusca);
        int LastCodGeral(string Tabela);
        int BuscarCodigo(string Tabela, string Campo, string ParametroBusca);
    }
}
