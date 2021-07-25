using Folha.Domain.ViewModels.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
   public class ProfissionalSaudeViewModel
    {
        #region Relacionamento
        public ProfissionalSaudeViewModel()
        {
            AreaSaude = new List<AreaSaudeProfissinalViewModel>();
        }
        #endregion
        public List<AreaSaudeProfissinalViewModel> AreaSaude { get; set; }
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public int CodEntidade { get; set; }
        public int status { get; set; }
        public EntidadesViewModel Entidades { get; set; } = new EntidadesViewModel();
        public ForeignKey FKeyEntidade
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Entidades",
                    NameEntity = "Entidades",
                    NameFieldThis = "CodEntidade",
                    NameFieldOrigin = "Codigo"
                };
            }
        }

        //public Folha.Domain.Models.Empresa.Empresa CabecalhoEmpresa { get; set; }


    }
}
