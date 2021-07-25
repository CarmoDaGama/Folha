using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using Folha.Domain.ViewModels.Frame.Hospitalar;
using System.Collections.Generic;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Reports.Hospitalar
{
    public partial class RelFichaMedico : DevExpress.XtraReports.UI.XtraReport
    {
        public RelFichaMedico(RelMedicoViewModel Medico, List<MedicoEspecialidadeViewModel> LtEspecialidade)
        {
            InitializeComponent();

            lbMedico.Text = Medico.Nome;
            lbNascimento.Text = Medico.DataNascimento.ToShortDateString();
            lbSexo.Text = Medico.Sexo;
            lbNacionalidade.Text = Medico.Nacionalidade;
            lbEstadoCivil.Text = Medico.EstadoCivil;
            picImagem.Image = Imagens.Byte_Imagem(Medico.Foto);

            lbIdentificacao.Text = Medico.Contribuinte;
            lbMorada.Text = Medico.Morada;
            lbContacto1.Text = Medico.Contacto1;
            lbContacto2.Text = Medico.Contacto2;
            objectDataSource1.DataSource = LtEspecialidade;
            xrSubreport1.ReportSource = new RelCabecalho();
        }

    }
}
