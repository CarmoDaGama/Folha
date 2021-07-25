using System;

namespace Folha.Domain.Models.Documentos
{
    public  class AnuladoDados : Entity
    {
        public Guid DocumentoID { get; set; }
        public string Motivo { get; set; }
    }
}
