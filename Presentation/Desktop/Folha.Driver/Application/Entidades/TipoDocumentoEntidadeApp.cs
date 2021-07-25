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
    public class TipoDocumentoEntidadeApp : ITipoDocumentoEntidadeApp
    {
        private readonly ITipoDocumentoEntidadeRepository Repository;
        public TipoDocumentoEntidadeApp(ITipoDocumentoEntidadeRepository repository)
        {
            Repository = repository;
        }
        public void Delete(TiposDocumentosViewModel tipo)
        {
            Repository.Delete(tipo);
        }

        public TiposDocumentosViewModel Get(int id)
        {
            return (TiposDocumentosViewModel)Repository.Get(new TiposDocumentosViewModel() { codigo = id });
        }

        public List<TiposDocumentosViewModel> GetAll()
        {
            return (List<TiposDocumentosViewModel>)Repository.GetAll(new TiposDocumentosViewModel());
        }

        public void Insert(TiposDocumentosViewModel tipo)
        {
            Repository.Insert(tipo);
        }

        public void Update(TiposDocumentosViewModel tipo)
        {
            Repository.Update(tipo);
        }
    }
}
