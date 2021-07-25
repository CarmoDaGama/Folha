using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;
using Folha.Domain.Models.Financeiro;

namespace Folha.Driver.Application.Hospitalar
{
    public class InternamentoApp : IInternamentoApp
    {
        private readonly IInternamentoRepository _Repository;

        public InternamentoApp(IInternamentoRepository Repository)
        {
            _Repository = Repository;
        }
        public void Delete(MovHospitalar hospital)
        {
            _Repository.Delete(hospital);
        }
        public MovHospitalarViewModel GetById(int codigo)
        {
            return (MovHospitalarViewModel)_Repository.Get(new MovHospitalarViewModel() { Codigo = codigo });
        }
        public int GetCodigoMovHos(int codigo)
        {
            throw new NotImplementedException();
        }
        public MovHospitalarViewModel Gravar(MovHospitalarViewModel hospital)
        {
            return _Repository.Gravar(hospital);
        }
        public MovHospitalarViewModel LerMovHospi(MovHospitalarViewModel hospital)
        {
            return _Repository.LerMovHospi(hospital);
        }

        public IEnumerable<MovHospitalar> Listar(string criterios)
        {
            return (List<MovHospitalar>)_Repository.Listar(criterios);
        }

        public IEnumerable<TarifaHospitalarViewModel> ListaTarifa(int criterios)
        {
            return (List<TarifaHospitalarViewModel>)_Repository.ListaTarifa(criterios);
        }
        public IEnumerable<QuartosHospitalarViewModel> ListaQuarto(int criterios)
        {
            return (List<QuartosHospitalarViewModel>)_Repository.ListaQuarto(criterios);
        }
       
        public IEnumerable<TiposQuartosHospitalarViewModel> ListaTipoQuarto(string criterios)
        {
            return (List<TiposQuartosHospitalarViewModel>)_Repository.ListaTipoQuarto(criterios);
        }

        public List<CamasQuartosHospitalarViewModel> GetCamas(int codQuartos)
        {
            return _Repository.GetCamas(codQuartos);
        }
        public void DeleteInternado(PacienteInternado paciente)
        {
            _Repository.DeleteInternado(paciente);
        }
        public PacienteInternadoViewModel GravarInternado(PacienteInternadoViewModel paciente)
        {
            return _Repository.GravarInternado(paciente);
        }

        public IEnumerable<PacienteInternado> ListarInternado(string paciente)
        {
            return (List<PacienteInternado>)_Repository.ListarInternado(paciente);
        }
        public IEnumerable<PacienteInternado> ListarTudo(string paciente)
        {
            return (List<PacienteInternado>)_Repository.ListarTudo(paciente);
        }
        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return _Repository.VerificarDup(nomeTabela, dicionario);
        }
        public decimal Preco(string paciente)
        {
            return _Repository.Preco(paciente);
        }

        public IEnumerable<Pagamentos> Listarpagamentos(string documento)
        {
            return (List<Pagamentos>)_Repository.Listarpagamentos(documento);
        }

        public decimal Pago(string paciente)
        {
            return _Repository.Pago(paciente);
        }

        public void Update(PacienteInternado entity)
        {
            _Repository.Update(entity);
        }
    }

}
