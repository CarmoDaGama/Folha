using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Admin
{
    public class NotificaoQuartoViewModel
    {
        public int Codigo { get; set; }
        public int CodTipoHabitacao { get; set; }
        public int CodArea { get; set; }
        public string Descricao { get; set; }
        public int CodCama { get; set; }
        public int Manutencao { get; set; }
        public string Venda { get; set; }
        public string Estado { get; set; }
    }
}
