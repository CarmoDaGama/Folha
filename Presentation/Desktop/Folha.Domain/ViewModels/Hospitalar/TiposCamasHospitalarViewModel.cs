﻿namespace Folha.Domain.ViewModels.Hospitalar
{
    public class TiposCamasHospitalarViewModel
    {
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string Descricao { get; set; }
    }
}