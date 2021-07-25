using System;

namespace Folha.Domain.ViewModels.Financeiro
{
    public  class CaixasViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string Descricao { get; set; }
    }
}
