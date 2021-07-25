using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.ViewModels.Frame.Inventario;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Inventario
{
    using Folha.Domain.ViewModels.Inventario;
    using Folha.Domain.ViewModels.Documentos;
    using Folha.Domain.ViewModels.Frame.Documentos;

    public interface IMovArtigosApp
    {
        List<MovArtigoViewModel> ListarMovArtigo(int CodDocumento);
        MotivoIsencao GetMotivoDeIsencao(MovProdutosViewModel movArtigo);
        List<DocumentoViewModel> GetDocumentosPor(int codAtendimento, int codItem);
        List<VendaViewModel> GetMovVendaByIdDocumento(int documentoId);
        List<DocumentoViewModel> GetDocumentosPor(int codAtendimento);
        MovProdutosViewModel GetMovProduto(int codItem, int codAtendimento, string descricao);
        List<MovProdutosViewModel> GetMovimemtosPorDescricao(int codAtendimento);
        IEnumerable<LerProdutosViewModel> ListarProdutos_RP(string criterios, string dtInicial, string dtFinal);
        List<MovArtigoViewModel> ListarMovArtigo(string ComissionarioID, string armazemID, string CodTurno);
        List<MovProdutosViewModel> GetAllByIdDocumento(int documentoId);
        void Insert(MovProdutosViewModel artigo); 
        void Update(MovProdutosViewModel artigo);
        void Delete(MovProdutosViewModel artigo);
        List<MovProdutosViewModel> GetAll();
        MovProdutosViewModel GetById(int id);
        int GetCodLast();
        void InsertOld(MovProdutosViewModel movProdutosViewModel);
        void UpdateOld(MovProdutosViewModel movProdutosViewModel);
        List<DocumentoViewModel> GetDocumetosPorDescricao(int codAtendimento);
    }
}
