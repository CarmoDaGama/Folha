using System;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Entidades;
using Folha.Driver.Repository.Data;
using Folha.Domain.Helpers;
using System.Collections.Generic;
using System.Data;
using Folha.Domain.ViewModels.Frame.Entidades;
using Folha.Domain.ViewModels.Entidades;
using System.Linq;

namespace Folha.Driver.Repository.Entidades
{
    public class ContactoRepository : RepositoryBase<DbDTO>, IContactoRepository
    {
        public void Delete(ContactosViewModel contact)
        {
            Conexao.ClienteSql.DELETE("Contactos", "Codigo = '" + contact.codigo + "'");
        }

        public object Get(ContactosViewModel contact)
        {
            return Db.GetById<ContactosViewModel>(contact.codigo);
        }

        public object GetAll(ContactosViewModel contact)
        {
            return Db.GetEntities<ContactosViewModel>();
        }

        public void Insert(ContactosViewModel contact)
        {
            Db.Add(contact);
        }

        public void Update(ContactosViewModel contact)
        {
            Db.Update(contact);
        }

        public List<ContactosViewModel> GetAllForNorm(int entidadeId)
        {
            return Db.GetEntities<ContactosViewModel>(" WHERE CodEntidade = '" + entidadeId + "'");
        }
        public ContactosViewModel GetContactoByEntidade(int entidadeId)
        {
            return Db.GetEntities<ContactosViewModel>(" WHERE CodEntidade = '" + entidadeId + "'").FirstOrDefault();
        }
    }
}
