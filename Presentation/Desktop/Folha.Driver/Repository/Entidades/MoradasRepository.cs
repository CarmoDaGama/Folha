using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Entidades;
using System;
using Folha.Domain.Models.Entidades;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Entidades;
using Folha.Driver.Repository.Data;

namespace Folha.Driver.Repository.Entidades
{
    public class MoradasRepository : RepositoryBase<DbDTO>, IMoradasRepository
    {
        public void Delete(MoradaViewModel morada)
        {
            Conexao.ClienteSql.DELETE("Morada", "IDMorada ='" + morada.IDMorada + "'");
        }

        public object Get(MoradaViewModel morada)
        {
            return Db.GetById<MoradaViewModel>(morada.IDMorada);
        }

        public object GetAll(Morada morada)
        {
            return Db.GetEntities<MoradaViewModel>();
        }

        public void Insert(MoradaViewModel morada)
        {
            Db.Add(morada);
        }

        public void Update(MoradaViewModel morada)
        {
            Db.Update(morada);
        }

        public List<MoradaViewModel> GetAllForNorm(int entidadeId)
        {
            return Db.GetEntities<MoradaViewModel>().Where(m => m.IDPessoa == entidadeId).ToList();
        }

        public object GetAll(MoradaViewModel tabela)
        {
            return Db.GetEntities<MoradaViewModel>();
        }

        public MoradaViewModel GetMoradaByEntidade(int entidadeId)
        {
            return Db.GetEntities<MoradaViewModel>(" WHERE IDPessoa = '" + entidadeId + "'").FirstOrDefault();
        }
    }
}
