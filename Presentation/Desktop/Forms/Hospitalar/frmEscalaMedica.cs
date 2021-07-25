using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Models.Genericos;
using Folha.Domain.ViewModels.Genericos;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmEscalaMedica : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IEscalaApp _escala;
        private Escala escala;
        private EscalaViewModel Entity { get; set; }
        public int EscalaConfigID { get; private set; }

        private List<EscalaConfigViewModel> listaconfi;
        private int CodSemana;
        private int codDelete;
        private int indexconfig;

        public frmEscalaMedica(IEscalaApp escala)
        {
            InitializeComponent();
            _escala = escala;
        }
        #region Metodos de Inserir
        private Escala PopulaObjecto()
        {
            escala = new Escala()
            {
                Descricao = txtDescricao.Text,
                HorasSemanal = int.Parse(txtHoraSemana.Text),
                EscalaConfig = new List<EscalaConfigViewModel>()
            };

            if (!string.IsNullOrEmpty(txtCodigo.Text)) escala.Codigo = int.Parse(txtCodigo.Text);
            escala.EscalaConfig = null;
            escala.EscalaConfig = listaconfi;
            return escala;
        }
        private void PopularDadosEditar(int Codigo)
        {
            if (Codigo == 0) return;
            EscalaConfigID = Codigo;
            Entity = _escala.GetById(Codigo);
            txtDescricao.Text = Entity.Descricao;
            txtHoraSemana.Text = Entity.HorasSemanal.ToString();
            gradeDias.DataSource = listaconfi = _escala.GetEscalaConfig(Codigo);
        }
        #endregion
        #region VALIDAÇÃO
        private void messageShow(string message)
        {
            MessageBox.Show(
                message,
                "INFORMAÇÃO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        private bool isFieldsValid()
        {
            bool valid = true;

            if (txtDescricao.Text.Equals(string.Empty))
            {
                messageShow("Digite uma descrição");
                return false;
            }
            if (txtHoraSemana.Text.Equals(string.Empty))
            {
                messageShow("Digite uma Estivamativa de horas de trabalho");
                return false;
            }
            if (HoraEntrada.Text.Equals(string.Empty))
            {
                messageShow("Digite uma Hora");
                return false;
            }
            if (HoraSaida.Text.Equals(string.Empty))
            {
                messageShow("Digite uma Hora de saida");
                return false;
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Descricao", txtDescricao);

            if (txtCodigo.Text == "" && _escala.VerificarDup("Escala", d))
            {
                messageShow("Já Existe a Escala: "+ txtDescricao.Text+" Verifica nos Registros ");
                return false;
            }
            if (Equals(listaconfi, null) || listaconfi.Count == 0)
            {
                MessageBox.Show("adiciona um ou mais Dias de semanas");
                return false;
            }
            return valid;
        }
        #endregion

        private void Adicionar_Click(object sender, EventArgs e)
        {
            if (HoraEntrada.Text.Equals(string.Empty))
            {
                messageShow("Digite uma Hora de entrada");
                return ;
            }
            if (HoraSaida.Text.Equals(string.Empty))
            {
                messageShow("Digite uma Hora de saida");
                return ;
            }

            var form = IOC.InjectForm<frmDiasSemanas>();
            form.btnSelect.Visibility = BarItemVisibility.Always;

            var semana = form.GetSemana();
            if (Equals(semana, null) /*|| Equals(semana.IDDias, 0)*/)
            {
                return;
            }
            CodSemana = semana.IDDias;

            if (Equals(listaconfi, null))
            {
                listaconfi = new List<EscalaConfigViewModel>();
            }
            var newDiasSemanas = (new EscalaConfigViewModel()
            {
                CodDia = semana.IDDias,
                DiasSemana = semana,
                Checa = 1,
                Entrada = Convert.ToDateTime(HoraEntrada.EditValue).ToShortTimeString().ToString(),
                Saida = Convert.ToDateTime(HoraSaida.EditValue).ToShortTimeString().ToString(),
                Semanas = semana.DescricaoDias


            });
            if (listaconfi.Count > 0 && ContemNaListas(newDiasSemanas.CodDia))
            {
                MessageBox.Show("Já está Adicionado", "Erro ao Adicionar ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listaconfi.Add(newDiasSemanas);
            gradeDias.DataSource = null;
            gradeDias.DataSource = listaconfi;
        }
        private bool ContemNaListas(int id)
        {
            return listaconfi.Where(a => a.CodDia == id).FirstOrDefault() != null;
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            var prof = PopulaObjecto();
            prof = _escala.Gravar(prof);
            PopularDadosEditar(prof.Codigo);
            txtCodigo.Text = prof.Codigo.ToString();
            UtilidadesGenericas.Busca.Alterou = true;
        }

        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            var prof = PopulaObjecto();
            prof = _escala.Gravar(prof);
            PopularDadosEditar(prof.Codigo);
            txtCodigo.Text = prof.Codigo.ToString();
            UtilidadesGenericas.Busca.Alterou = true;
            Close();
            UtilidadesGenericas.Busca.Alterou = true;

        }

        private void frmEscalaMedica_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UtilidadesGenericas.Busca.Codigo))
            {
                txtCodigo.Text = UtilidadesGenericas.Busca.Codigo;
                int Codigo = int.Parse(txtCodigo.Text);
                var escala = _escala.GetById(Codigo);
                if (Codigo > 0) PopularDadosEditar(Codigo);
            }
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (codDelete > 0)
            {
                _escala.DeleteEscalaConfig(new EscalaConfigViewModel()
                {
                    Codigo = codDelete,
                });
                gradeDias.DataSource = null;
                gradeDias.DataSource = listaconfi = _escala.GetEscalaConfig(EscalaConfigID);

                MessageBox.Show("Registro Excluído ! ", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                listaconfi.RemoveAt(indexconfig);
                gradeDias.DataSource = null;
                gradeDias.DataSource = listaconfi;
            }
        }

        private void gridDias_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            codDelete = listaconfi[e.RowHandle].Codigo;
            indexconfig = e.RowHandle;
        }
    }
}