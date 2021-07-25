using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Admin
{
    public class DefinicoesHotel
    {
        public int codigo { get; set; }
        public string Checkin { get; set; }
        public string CheckOut { get; set; }

        public bool CTempo { get; set; }

        public bool Automatico { get; set; }

        public int Horas { get; set; }

        public bool Consumidor { get; set; }

    }
}
