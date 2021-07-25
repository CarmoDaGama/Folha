using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using System.Collections.Generic;
using System;

namespace Folha.Driver.Application.Hospitalar
{
    public class ConsultaHospitalarApp : IConsultaHospitalarApp
    {
        private readonly IConsultaHospitalarRepository _ConsultaHospitalarRepository;

        public ConsultaHospitalarApp(IConsultaHospitalarRepository ConsultaHospitalarRepository)
        {
            _ConsultaHospitalarRepository = ConsultaHospitalarRepository;
        }

        public void FecharFacturar(ConsultaHospitalar Dados)
        {
            _ConsultaHospitalarRepository.FecharFacturar(Dados);
        }

        public void Insert(ConsultaHospitalar Dados)
        {
            _ConsultaHospitalarRepository.Insert(Dados);
        }

        public int LastCodConsulta()
        {
            return _ConsultaHospitalarRepository.LastCodConsulta();
        }

        public IEnumerable<ConsultaHospitalarViewModel> Listar(string CodAtendimento, string CodConsulta)
        {
            return _ConsultaHospitalarRepository.Listar(CodAtendimento, CodConsulta);
        }

        public IEnumerable<ConsultaHospitalarViewModel> ListarComFiltro(string valor, string dtInicoEst, string dtFim)
        {
            return _ConsultaHospitalarRepository.ListarComFiltro(valor, dtInicoEst, dtFim);
        }

        public IEnumerable<MarcacaoConsultaViewModel> ListarConsultaMedico(int Codigo , string Data, string DataFim)
        {
            return _ConsultaHospitalarRepository.ListarConsultaMedico(Codigo, Data , DataFim);
        }

        public IEnumerable<ConsultaHospitalarViewModel> ListarSemFiltro()
        {
            return _ConsultaHospitalarRepository.ListarSemFiltro();
        }

        public IEnumerable<MarcacaoConsultaViewModel> ListConsultaIndividual(string Codigo)
        {
            return _ConsultaHospitalarRepository.ListConsultaIndividual(Codigo);
        }

        public IEnumerable<MarcacaoConsultaViewModel> ListConsultaMarcadas(string CodAtendimento)
        {
            return _ConsultaHospitalarRepository.ListConsultaMarcadas(CodAtendimento);
        }

        public void Update(ConsultaHospitalar Dados)
        {
            _ConsultaHospitalarRepository.Update(Dados);
        }

        public void UpdateAtendimento(List<ConsultaHospitalar> Dados)
        {
            _ConsultaHospitalarRepository.UpdateAtendimento(Dados);
        }

        public void UpdateConsultorio(ConsultaHospitalar Dados)
        {
            _ConsultaHospitalarRepository.UpdateConsultorio(Dados);
         }      
    }
}
