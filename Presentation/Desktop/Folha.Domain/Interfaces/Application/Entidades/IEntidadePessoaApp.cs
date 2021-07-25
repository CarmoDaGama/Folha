using Folha.Domain.Models.Entidades;
using Folha.Domain.ViewModels.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Entidades
{
    public interface IEntidadePessoaApp
    {
        List<PessoaViewModel> GetPessoas();
        void Update(EntidadesPessoaViewModel pessoa);
        void Insert(EntidadesPessoaViewModel pessoa);
        EntidadesPessoaViewModel GetById(int id);
    }
}
