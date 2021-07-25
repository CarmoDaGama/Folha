﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Frame
{
    public class MovimentosCaixaViewModel
    {
        public int Codigo { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public string Descricao { get; set; }
        public string Entidade { get; set; }
        public double Valor { get; set; }
        public string Sigla { get; set; }
        public string Tipo { get; set; }
        public string Caixa { get; set; }
        public string Estado { get; set; }
    }
}
