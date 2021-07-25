using System;
using System.Collections.Generic;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Entidades;
using System.Data;
using System.Linq;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Entidades;
using Folha.Driver.Repository.Data;

namespace Folha.Driver.Repository.Entidades
{
    public class DocumentoEntidadeRepository : RepositoryBase<DbDTO>, IDocumentoEntidadeRepository
    {
        public void Delete(DocumentosEntidadeViewModel documento)
        {
            Conexao.ClienteSql.DELETE("DocumentosEntidade", "codigo ='" + documento.codigo + "'");
        }

        public object Get(DocumentosEntidadeViewModel documento)
        {
            return Db.GetById<DocumentosEntidadeViewModel>(documento.codigo);
        }

        public object GetAll(DocumentosEntidadeViewModel documento)
        {
            return Db.GetEntities<DocumentosEntidadeViewModel>();
        }

        public void Insert(DocumentosEntidadeViewModel documento)
        {

            Db.Add(documento);
        }

        public List<DocumentosEntidadeViewModel> Listar()
        {
            return (List<DocumentosEntidadeViewModel>)GetAll(new DocumentosEntidadeViewModel());
        }

        public void Update(DocumentosEntidadeViewModel documento)
        {
            Db.Update(documento);
        }

        public List<DocumentosEntidadeViewModel> GetAllForNorm(int entidadeId)
        {
            return Db.GetEntities<DocumentosEntidadeViewModel>().Where(d => d.CodEntidade == entidadeId).ToList();
        }
    }
}
