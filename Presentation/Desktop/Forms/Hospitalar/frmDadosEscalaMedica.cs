using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Folha.Domain.Helpers;
using Folha.Domain.Enuns.Genericos;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Models.Genericos;
using Folha.Domain.ViewModels.Genericos;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmDadosEscalaMedica : RibbonForm
    {
        private readonly IEscalaApp _escalaApp;

        private List<DiasSemana01ViewModel> ListaDiasSemana { get; set; }

        public frmDadosEscalaMedica(IEscalaApp escalaApp)
        {
            InitializeComponent();
            _escalaApp = escalaApp;
            ValidacaoControles.InserirEnventosDeValidacao(txtDescricao, TipoValidacao.Nome);
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ComposValidos())
            {

                UtilidadesGenericas.Busca.Alterou = true;
                Close();
            }
        }

        private bool ComposValidos()
        {
            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                UtilidadesGenericas.MsgShow("Preencha o campo Descrição!", MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtHoraEntrada.Text))
            {
                UtilidadesGenericas.MsgShow("Preencha o campo Hora De Entrada!", MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtHoraSaida.Text))
            {
                UtilidadesGenericas.MsgShow("Preencha o campo Hora De Saida!", MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void frmDadosEscalaMedica_Load(object sender, EventArgs e)
        {
            carregarDias();
        }

        private void carregarDias()
        {
            ListaDiasSemana = _escalaApp.CarregarDiasSemana();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}