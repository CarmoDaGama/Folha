using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Frame.Inventario;
using System;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Inventario
{
    using Folha.Domain.ViewModels.Inventario;
    using Folha.Domain.ViewModels.Documentos;
    using Folha.Domain.ViewModels.Frame.Documentos;

    public interface IMovArtigoRepository: IRepositoryBase<MovProdutosViewModel>
    {
        List<MovProdutosViewModel> GetMovProdutosPor(DateTime dataInicio, DateTime datafim);
        List<DocumentoViewModel> GetDocumentosPor(int codAtendimento, int codItem);
        List<VendaViewModel> GetMovVendaByIdDocumento(int documentoId);
        object GetCodLast();
        List<DocumentoViewModel> GetDocumentosPor(int codAtendimento);
        MovProdutosViewModel GetMovProduto(int codItem, int codAtendimento, string descricao);
        List<MovArtigo> MostrarMovProdutos(int NumeroDocumento, String Criterios);
        void LancarProdutoVenda(int NumeroVenda, MovArtigo movArtigo, bool variasLinhas);
        void LancarProdutoHotel(int NumeroVenda, MovArtigo movArtigo, Guid quartoID);
        void LancarProdutoOrdemServico(int NumeroVenda, MovArtigo movArtigo, Guid equipamentoID);
        void LancarProdutoCyber(int NumeroVenda, MovArtigo movArtigo);
        List<MovProdutosViewModel> GetAllByIdDocumento(int documentoId);
        IEnumerable<LerProdutosViewModel> ListarProdutos_RP(string criterios, string dtInicial, string dtFinal);
        List<MovArtigoViewModel> ListarMovArtigo(string ComissionarioID, string armazemID, string CodTurno);
        List<MovArtigoViewModel> ListarMovArtigo(int CodDocumento);
        void InsertOld(MovProdutosViewModel movProdutosViewModel);
        void UpdateOld(MovProdutosViewModel movProdutosViewModel);
        List<MovProdutosViewModel> GetMovsPorDescricao(int codAtendimento);
    }
}
