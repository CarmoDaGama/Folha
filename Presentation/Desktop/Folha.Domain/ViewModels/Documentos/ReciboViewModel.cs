using Folha.Domain.ViewModels.Financeiro;
using System.Collections.Generic;

namespace Folha.Domain.ViewModels.Documentos
{
    public class ReciboViewModel
    {
        public List<PagamentosViewModel> Pagamentos { get; set; }
        public List<DocumentoPagamentoViewModel> Documentos { get; set; }
        public string Telefone { get; set; }
        public string Localizacao { get; set; }
    }
}
