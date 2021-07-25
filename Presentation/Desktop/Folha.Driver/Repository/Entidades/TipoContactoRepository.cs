using System;
using Folha.Driver.Repository;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Entidades;
using Folha.Driver.Repository.Data;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Entidades;

namespace Folha.Driver.Repository.Entidades
{
    public class TipoContactoRepository : RepositoryBase<DbDTO>, ITipoContactoRepository
    {
        public void Delete(TipoContactoViewModel tipoContacto)
        {
            Conexao.ClienteSql.DELETE("TipoContacto", "codigo ='" + tipoContacto.codigo + "'");
        }

        public object Get(TipoContactoViewModel tipoContacto)
        {
            return Db.GetById<TipoContactoViewModel>(tipoContacto.codigo);
        }

        public object GetAll(TipoContactoViewModel tipoContacto)
        {
            return Db.GetEntities<TipoContactoViewModel>();
        }

        public void Insert(TipoContactoViewModel tipoContacto)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "TipoContacto",
                Campos = new string[] {
                    "descricao"
                },
                Valores = new Object[] {
                    tipoContacto.descricao
                }
            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
        }

        public void Update(TipoContactoViewModel tipoContacto)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "TipoContacto",
                Campos = new string[] {
                    "descricao"
                },
                Valores = new Object[] {
                    tipoContacto.descricao
                }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "codigo ='" + tipoContacto.codigo + "'");

        }
    }
}
