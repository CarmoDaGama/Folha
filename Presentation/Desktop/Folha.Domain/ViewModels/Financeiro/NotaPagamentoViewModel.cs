using Folha.Domain.ViewModels.Documentos;
using System;

namespace Folha.Domain.ViewModels.Financeiro
{

    public class NotaPagamentoViewModel
    {
        public int Codigo { get; set; }
        public int CodDocumento { get; set; }
        public DocumentosViewModel Documento { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public int Numero { get; set; }
        public string Finalidade { get; set; }
        public int CodCliente { get; set; }
        public string Cliente { get; set; }
        public string Obs { get; set; }
        public string Funcionario { get; set; }
        public string Descricao { get; set; }
        public string Forma { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }
        public string Moeda { get; set; }
        public string Estado { get; set; }
        public string CodCambio { get; set; }
        public Sistema.DadosEmpresaViewModel DadosEmpresa { get; set; }
    }
}
