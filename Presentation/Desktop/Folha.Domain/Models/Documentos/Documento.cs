using Enterprise.Domain.Entidades;
using Enterprise.Domain.Inventario;
using Enterprise.Domain.Restaurante;
using Enterprise.Domain.Sistema;
using System;
using System.Collections.Generic;

namespace Enterprise.Domain.Documentos
{
    public  class Documento : Entity
    {
        public Operacoes Operacao { get; set; }
        public Entidades.Entidades Entidade { get; set; }
        public int AreaID { get; set; }
        public Mesa Mesa { get; set; }
        public Guid TurnoID { get; set; }
        public string Descritivo { get; set; }
        public DateTime Data { get; set; }
        public Double Total { get; set; }
        public List<MovArtigo> Artigos { get; set; }
    }
}
