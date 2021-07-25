using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Admin
{
    public class DefinicoesHotelViewModel
    {
        public int codigo { get; set; }
        public string Checkin { get; set; }
        public string CheckOut { get; set; }

        public int CTempo { get; set; }
        public bool StateTempo{ get { return CTempo == 1; } }

        public int Automatico { get; set; }
        public bool StateAutomatico { get { return Automatico == 1; } }

        public int Horas { get; set; }

        public int Consumidor { get; set; }
        public bool StateConsumidor { get { return Consumidor == 1; } }

    }
}
