using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Documentos;
using System;
using Folha.Domain.Models.Documentos;
using Folha.Domain.ViewModels.Documentos;

namespace Folha.Driver.Repository.Documentos
{
    public class AcessoDocumentosRepository : RepositoryBase<DbDTO>, IAcessoDocumentosRepository
    {

        public void Delete(AcessoDocumentosViewModel acesso)
        {
            Db.Delete(acesso);
        }

        public object Get(AcessoDocumentosViewModel acesso)
        {
            return Db.GetById<AcessoDocumentosViewModel>(acesso.codigo);
        }

        public object GetAll(AcessoDocumentosViewModel acesso)
        {
            return Db.GetEntities<AcessoDocumentosViewModel>();
        }

        public void Insert(AcessoDocumentosViewModel acesso)
        {
            Db.Add(acesso);
        }

        public void Update(AcessoDocumentosViewModel acesso)
        {
            Db.Update(acesso);
        }

    }
}
