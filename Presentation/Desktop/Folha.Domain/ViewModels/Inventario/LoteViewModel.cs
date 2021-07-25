using System;
using System.Collections.Generic;

namespace Folha.Domain.ViewModels.Inventario
{
    public class LoteViewModel
    {

        #region Relacionamento
        public LoteViewModel()
        {
            LoteArtigos = new List<LoteArtigosViewModel>();
        }
        #endregion
        public List<LoteArtigosViewModel> LoteArtigos { get; set; }
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }

        public DateTime DataValidade { get; set; }
        public DateTime DataVencimento { get; set; }

    }
}
