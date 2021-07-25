using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Entidades
{
    public class Funcionarios
    {
        //IDPessoa	CodEntidade	CodDepartamento	DataRegisto	CodEmpresa
        public int IDPessoa { get; set; }
        public string NameKey { get { return "IDPessoa"; } }
        public int CodEntidade { get; set; }
        public Entidades Entidade { get; set; } = new Entidades();
        public ForeignKey FKEntidade
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Entidades",
                    NameEntity = "Entidade",
                    NameFieldThis = "CodEntidade",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
        public int CodDepartamento { get; set; }
        public Departamentos Departamento { get; set; } = new Departamentos();
        public ForeignKey FKDepartamento
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Departamentos",
                    NameEntity = "Departamento",
                    NameFieldThis = "CodDepartamento",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
        public string DataRegisto { get; set; }
    }
}
