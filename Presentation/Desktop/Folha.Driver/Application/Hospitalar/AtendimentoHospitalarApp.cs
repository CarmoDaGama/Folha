using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;

namespace Folha.Driver.Application.Hospitalar
{
    public class AtendimentoHospitalarApp : IAtendimentoHospitalarApp
    {
        private readonly IAtendimentoHospitalarRepository _AtendimentoHospitalarRepository;

        public AtendimentoHospitalarApp(IAtendimentoHospitalarRepository AtendimentoHospitalarRepository)
        {
            _AtendimentoHospitalarRepository = AtendimentoHospitalarRepository;
        }

        public IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentos(string dtInicio, string dtFim, string CodPaciente)
        {
            return _AtendimentoHospitalarRepository.ListarAtendimentos(dtInicio, dtFim,CodPaciente);
        }

        public IEnumerable<ExamesAtendimento> CarregaExames(string CodPaciente,string data)
        {
            return _AtendimentoHospitalarRepository.CarregaExames(CodPaciente, data);
        }

        public void DeleteExames(List<ExamesAtendimento> Lista)
        {
            _AtendimentoHospitalarRepository.DeleteExames(Lista);
        }

        public void Insert(AtendimentoHospitalar Dados)
        {
            _AtendimentoHospitalarRepository.Insert(Dados);
        }

        public void InsertExames(List<ExamesAtendimento> Lista)
        {
            _AtendimentoHospitalarRepository.InsertExames(Lista);
        }

        public void Update(AtendimentoHospitalar Dados)
        {
            _AtendimentoHospitalarRepository.Update(Dados);
        }

        public List<AtendimentoDocViewModel> ListarAtendimentosNãoFacturadosPorUsuario(int usuarioId, int pacienteId)
        {
            return _AtendimentoHospitalarRepository.ListarAtendimentosNãoFacturadosPorUsuario(usuarioId, pacienteId);
        }

        public List<ConsultaViewModel> ListasConsultasPorIdAtendimento(int atendimentoId)
        {
            return _AtendimentoHospitalarRepository.ListasConsultasPorIdAtendimento(atendimentoId);
        }
        private string GetNomeJunto(string[] nomes)
        {
            string nome = string.Empty;
            for (int i = 1; i < nomes.Length; i++)
            {
                if (i == 1)
                {
                    nome = nomes[i];
                }
                else
                {
                    nome += " " + nomes[i];
                }
            }
            return nome.Trim();
        }
        public ItemAtendimentoFacturaViewModel GetItemFactura(string tipo, int codItem)
        {
            var item = new ItemAtendimentoFacturaViewModel();

            if (Equals(tipo.Trim(), "Consulta"))
            {

                var itemConsulta = _AtendimentoHospitalarRepository.GetConsultaPorIdAtendimento(codItem);
                if (string.IsNullOrEmpty(itemConsulta.Facturado))
                {
                    itemConsulta.Facturado = "Não";
                }
                item = new ItemAtendimentoFacturaViewModel()
                {
                    ItemId = itemConsulta.Codigo,
                    Data = itemConsulta.DataConsulta,
                    Facturar = itemConsulta.Facturado.ToLower().Contains("sim"),
                    PercentagemImposto = itemConsulta.ImpostoPercentagem.ToString(),
                    Imposto = (itemConsulta.ValorConsulta * (itemConsulta.ImpostoPercentagem / 100)).ToString("N2"),
                    Preco = itemConsulta.ValorConsulta.ToString("N2"),
                    Tipo = "Consulta",
                    Nome = itemConsulta.TipoConsultasDescricao
                };
            }
            else if (Equals(tipo.Trim(), "Exame"))
            {
                var itemExame = _AtendimentoHospitalarRepository.GetExamePorIdAtendimento(codItem);
                item = (new ItemAtendimentoFacturaViewModel()
                {
                    ItemId = itemExame.Codigo,
                    AuxId = itemExame.CodExame,
                    Data = itemExame.DataExame,
                    Facturar = itemExame.Facturado.ToLower().Contains("sim"),
                    PercentagemImposto = itemExame.ImpostoPercentagem.ToString(),
                    Imposto = (itemExame.Preco * (itemExame.ImpostoPercentagem / 100)).ToString("N2"),
                    Preco = itemExame.Preco.ToString("N2"),
                    Tipo = "Exame",
                    Nome =  itemExame.Descricao
                });
            }
            else if (Equals(tipo.Trim(), "Internamento"))
            {
                var itemInternamento = _AtendimentoHospitalarRepository.GetInternamentoPorIdAtendimento(codItem);
                if (Equals(itemInternamento, null))
                {
                    return null;
                }
                item = (new ItemAtendimentoFacturaViewModel()
                {
                    ItemId = itemInternamento.Codigo,
                    AuxId = itemInternamento.Codigo,
                    Data = itemInternamento.DataEntrada.ToShortDateString(),
                    Facturar = itemInternamento.Facturado.ToLower().Contains("sim"),
                    PercentagemImposto = itemInternamento.Percentagem.ToString(),
                    Imposto = (itemInternamento.Total * (itemInternamento.Percentagem / 100)).ToString("N2"),
                    Preco = itemInternamento.Total.ToString("N2"),
                    Tipo = "Internamento",
                    Nome = itemInternamento.Descricao
                });//1207162034826
            }

            return item;
        }
        public MotivoIsencao GetMotivoIsencao(string tipo, int codItem)
        {
            var motivo = new MotivoIsencao();
            if (Equals(tipo.Trim(), "Consulta"))
            {
                motivo = _AtendimentoHospitalarRepository.GetMotivoPorIdConsulta(codItem);
            }
            else if (Equals(tipo.Trim(), "Exame"))
            {
                motivo = _AtendimentoHospitalarRepository.GetMotivoPorIdExame(codItem);
            }
            else if (Equals(tipo.Trim(), "Internamento"))
            {
                motivo = _AtendimentoHospitalarRepository.GetMotivoPorIdInternamento(codItem);
            }

            return motivo;
        }
        public List<ExameViewModel> ListarExamesPorIdAtendimento(int atendimentoId)
        {
            return _AtendimentoHospitalarRepository.ListarExamesPorIdAtendimento(atendimentoId);
        }

        public List<ItemAtendimentoFacturaViewModel> ListarItensAtendimento(int atendimentoId)
        {
            List<ItemAtendimentoFacturaViewModel> listItensFacturar = new List<ItemAtendimentoFacturaViewModel>();

            var exames = ListarExamesPorIdAtendimento(atendimentoId);
            var consultas = ListasConsultasPorIdAtendimento(atendimentoId);
            var internamentos = _AtendimentoHospitalarRepository.ListarInternamentoPorIdAtendimento(atendimentoId);
            foreach (var item in consultas)
            {
                listItensFacturar.Add(new ItemAtendimentoFacturaViewModel()
                {
                    ItemId = item.Codigo,
                    Data = item.DataConsulta,
                    Facturar = item.Facturado.ToLower().Contains("sim"),
                    PercentagemImposto = item.ImpostoPercentagem.ToString(),
                    Imposto = (item.ValorConsulta * (item.ImpostoPercentagem /100)).ToString("N2"),
                    Preco = item.ValorConsulta.ToString("N2"),
                    Tipo = "Consulta",
                    Nome = item.TipoConsultasDescricao,
                    TipoImposto = item.TipoImposto,
                    CodImposto = item.CodImposto,
                    DescricaoImposto = item.DetalheImposto
                });
            }
            foreach (var item in exames)
            {
                listItensFacturar.Add(new ItemAtendimentoFacturaViewModel()
                {
                    ItemId = item.Codigo,
                    AuxId = item.CodExame,
                    Data = item.DataExame,
                    Facturar = item.Facturado.ToLower().Contains("sim"),
                    PercentagemImposto = item.ImpostoPercentagem.ToString(),
                    Imposto = (item.Preco * (item.ImpostoPercentagem / 100)).ToString("N2"),
                    Preco = item.Preco.ToString("N2"),
                    Tipo = "Exame",
                    Nome = item.Descricao,
                    TipoImposto = item.TipoImposto,
                    CodImposto = item.CodImposto,
                    DescricaoImposto = item.DetalheImposto
                }); 
            }
            foreach (var item in internamentos)
            {
                listItensFacturar.Add(new ItemAtendimentoFacturaViewModel()
                {
                    ItemId = item.Codigo,
                    AuxId = item.Codigo,
                    Data = item.DataEntrada.ToShortDateString(),
                    Facturar = item.Facturado.ToLower().Contains("sim"),
                    PercentagemImposto = item.Percentagem.ToString(),
                    Imposto = (item.Total * (item.Percentagem / 100)).ToString("N2"),
                    Preco = item.Total.ToString("N2"),
                    Tipo = "Internamento",
                    Nome = item.Descricao,
                    TipoImposto = item.TipoImposto,
                    CodImposto = item.CodImposto,
                    DescricaoImposto = item.DetalheImposto
                });
            }
            return listItensFacturar;
        }
        
        IEnumerable<AtendimentoHospitalarGraficViewModel> IAtendimentoHospitalarApp.TotalAtendimento(string dataInicial, string dataFinal, bool faturado)
        {
            return _AtendimentoHospitalarRepository.TotalAtendimento(dataInicial, dataFinal, faturado);
        }


        //____________________________________________
        public IEnumerable<PacienteInternado> ListarInternado(string paciente)
        {
            return (List<PacienteInternado>)_AtendimentoHospitalarRepository.ListarInternado(paciente);
        }

        public IEnumerable<TiposQuartosHospitalarViewModel> ListaTipoQuarto(string criterios)
        {
            return (List<TiposQuartosHospitalarViewModel>)_AtendimentoHospitalarRepository.ListaTipoQuarto(criterios);
        }

        public PacienteInternadoViewModel GravarInternado(PacienteInternadoViewModel paciente)
        {
            return _AtendimentoHospitalarRepository.GravarInternado(paciente);
        }

        public void DeleteInternado(PacienteInternado paciente)
        {
            _AtendimentoHospitalarRepository.DeleteInternado(paciente);
        }

        public IEnumerable<TarifaHospitalarViewModel> ListaTarifa(int criterios)
        {
            return (List<TarifaHospitalarViewModel>)_AtendimentoHospitalarRepository.ListaTarifa(criterios);
        }

        public IEnumerable<QuartosHospitalarViewModel> ListaQuarto(int criterios)
        {
            return (List<QuartosHospitalarViewModel>)_AtendimentoHospitalarRepository.ListaQuarto(criterios);
        }

        public List<CamasQuartosHospitalarViewModel> GetCamas(int codQuartos)
        {
            return _AtendimentoHospitalarRepository.GetCamas(codQuartos);
        }

        public IEnumerable<CamasQuartosHospitalarViewModel> ListaCama(int codQuartos)
        {
            return (List<CamasQuartosHospitalarViewModel>)_AtendimentoHospitalarRepository.ListaCama(codQuartos);
        }

        public decimal Total(string criterio)
        {
            return _AtendimentoHospitalarRepository.Total(criterio);
        }

        public void UpdatePaciente(PacienteInternado entity)
        {
            _AtendimentoHospitalarRepository.UpdatePaciente(entity);
        }
        public int GetCodLast(int criterio)
        {
            return (int)_AtendimentoHospitalarRepository.GetCodLast(criterio);
        }

        public int BuscarUltimoRegistro(int Codigo)
        {
            return (int)_AtendimentoHospitalarRepository.BuscarUltimoRegistro(Codigo);
        }

        public List<PacienteInternado> ListaNova(int Codigo)
        {
            return _AtendimentoHospitalarRepository.ListaNova(Codigo);
        }

        public List<PacienteInternado> DatasInternamento(DateTime Data)
        {
            return _AtendimentoHospitalarRepository.DatasInternamento(Data);
        }
        //
        public IEnumerable<PacienteInternado> ListarInternadoSemFiltro()
        {
            return _AtendimentoHospitalarRepository.ListarInternadoSemFiltro();
        }

        public IEnumerable<PacienteInternado> FiltrarPacienteInternado(string valor, string dtInicoEst, string dtFim)
        {
            return _AtendimentoHospitalarRepository.FiltrarPacienteInternado(valor, dtInicoEst ,dtFim);
        }
        //

        public IEnumerable<PacienteInternado> ListarTudo(string paciente)
        {
            return (List<PacienteInternado>)_AtendimentoHospitalarRepository.ListarTudo(paciente);
        }

        public void FecharAtendimento(AtendimentoHospitalar Dados)
        {
            _AtendimentoHospitalarRepository.FecharAtendimento(Dados);
        }

        public bool GetEstadoAtendimento(int codAtendimento)
        {
            return _AtendimentoHospitalarRepository.GetEstadoAtendimento(codAtendimento);
        }

        public bool TemItensPorFacturar(int codAtendimento)
        {
            var temConsulta = _AtendimentoHospitalarRepository.TemConsultasPorFacturar(codAtendimento);
            var temExame = _AtendimentoHospitalarRepository.TemExamesPorFacturar(codAtendimento);
            var temInternamento = _AtendimentoHospitalarRepository.TemInternamentoPorFacturar(codAtendimento);

            return (temConsulta || temExame || temInternamento);
        }

        public IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentosRecepcao(string CodPaciente)
        {
            return _AtendimentoHospitalarRepository.ListarAtendimentosRecepcao( CodPaciente);
        }
        public IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentosSemFiltro()
        {
            return _AtendimentoHospitalarRepository.ListarAtendimentosSemFiltro();
        }

        public IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentosComFiltro(string valor, string dtInicial, string dtFim)
        {
            return _AtendimentoHospitalarRepository.ListarAtendimentosComFiltro(valor, dtInicial, dtFim);
        }

        public IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentosSemFiltro(string valor, string dtInicial, string dtFim)
        {
            throw new NotImplementedException();
        }
    }
}
