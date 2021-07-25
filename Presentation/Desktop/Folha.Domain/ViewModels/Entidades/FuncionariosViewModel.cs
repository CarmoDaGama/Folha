namespace Folha.Domain.ViewModels.Entidades
{
    public class FuncionariosViewModel
    {
        //IDPessoa	CodEntidade	CodDepartamento	DataRegisto	CodEmpresa
        public int IDPessoa { get; set; }
        public string NameKey { get { return "IDPessoa"; } }
        public int CodEntidade { get; set; }
        public EntidadesViewModel Entidade { get; set; } = new EntidadesViewModel();
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
        public DepartamentosViewModel Departamento { get; set; } = new DepartamentosViewModel();
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
