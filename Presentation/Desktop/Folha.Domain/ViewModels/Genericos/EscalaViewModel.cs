using System.Collections.Generic;

namespace Folha.Domain.ViewModels.Genericos
{
    public class EscalaViewModel
    {
        #region Relacionamento
        public EscalaViewModel()
        {
            EscalaConfig = new List<EscalaConfigViewModel>();
        }
        #endregion
        public List<EscalaConfigViewModel> EscalaConfig { get; set; }
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string Descricao { get; set; }
        public int HorasSemanal { get; set; }


    }
}
