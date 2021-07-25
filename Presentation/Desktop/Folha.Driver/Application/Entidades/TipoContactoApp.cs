using Folha.Domain.Interfaces.Application.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Interfaces.Repository.Entidades;
using Folha.Domain.ViewModels.Entidades;

namespace Folha.Driver.Application.Entidades
{
    public class TipoContactoApp : ITipoContactoApp
    {
        private readonly ITipoContactoRepository Repository;
        public TipoContactoApp(ITipoContactoRepository repository)
        {
            Repository = repository;
        }
        public void Delete(TipoContactoViewModel tipo)
        {
            Repository.Delete(tipo);
        }

        public TipoContactoViewModel Get(int id)
        {
            return (TipoContactoViewModel)Repository.Get(new TipoContactoViewModel() { codigo = id });
        }

        public List<TipoContactoViewModel> GetAll()
        {
            return (List<TipoContactoViewModel>)Repository.GetAll(new TipoContactoViewModel());
        }

        public void Insert(TipoContactoViewModel tipo)
        {
            Repository.Insert(tipo);
        }

        public void Update(TipoContactoViewModel tipo)
        {
            Repository.Update(tipo);
        }
    }
}
