using Folha.Domain.Models.Entidades;
using Folha.Domain.Models.Entities.Entidades;
using Folha.Domain.Enuns.Entidades;

namespace Folha.Domain.Models.Vendas
{
    public class Cliente : Entity
    {
        public PessoaFisica Pessoa { get; set; }
        public PessoaJuridica PessoaJurica { get; set; }
        public ETipoEntidade TipoEntidade { get; set; }
    }
}
