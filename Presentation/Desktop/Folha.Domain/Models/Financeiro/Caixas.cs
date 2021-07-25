using System;

namespace Folha.Domain.Models.Financeiro
{
    public  class Caixas
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string Descricao { get; set; }

        public Empresa.Empresa CabecalhoEmpresa { get; set; }

    }
}
