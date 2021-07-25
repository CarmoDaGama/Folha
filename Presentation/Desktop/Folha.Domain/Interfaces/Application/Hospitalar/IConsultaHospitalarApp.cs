using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Hospitalar
{
    public interface IConsultaHospitalarApp
    {
        void FecharFacturar(ConsultaHospitalar Dados);
        void Insert(ConsultaHospitalar Dados);
        void UpdateAtendimento(List<ConsultaHospitalar> Lista);
        void Update(ConsultaHospitalar Dados);
        void UpdateConsultorio(ConsultaHospitalar Dados);

        int LastCodConsulta();
        IEnumerable<MarcacaoConsultaViewModel> ListConsultaMarcadas(string CodAtendimento);
        IEnumerable<ConsultaHospitalarViewModel> Listar(string CodAtendimento, string CodConsulta);
        IEnumerable<MarcacaoConsultaViewModel> ListarConsultaMedico(int Codigo, string Data, string DataFim);

        //
        IEnumerable<ConsultaHospitalarViewModel> ListarSemFiltro();
        IEnumerable<ConsultaHospitalarViewModel> ListarComFiltro(string valor, string dtInicoEst, string dtFim);
        IEnumerable<MarcacaoConsultaViewModel> ListConsultaIndividual(string Codigo);

        //
    }
}
