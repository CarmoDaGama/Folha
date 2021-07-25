using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Inventario
{
    public  interface IMotivoIsencaoRepository
    {
        MotivoIsencao GetMotivoPorCodigo(int codMotivo);
        MotivoIsencao GetMotivoPorDescricao(string descricao);
        IEnumerable<MotivoIsencao> Listar(string criterios);
        List<MovProdutosViewModel> GetMovsPorDescricao(string descricao);

    }
}
