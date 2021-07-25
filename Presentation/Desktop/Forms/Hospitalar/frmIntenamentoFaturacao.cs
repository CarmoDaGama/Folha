using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{

    public partial class frmIntenamentoFaturacao : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IAtendimentoHospitalarApp _AtendiApp;
        private readonly ICamasHospitalarApp _cama;
        private PacienteInternadoViewModel Internado;
        public List<PacienteInternado> ListaInternado { get; private set; }
        public List<PacienteInternado> ListaNova { get; private set; }

        //private int codInternado;
        private int CodCama;
        private int CodQuarto;
        private int CodTarifa;
        private int Quantidade;
        private decimal ValorTarifa;
        private int codAtendimento;
        private int codPacienteNovo;
        private int codTipoConsultaNovo;

        private int CodAtendimento { get; set; }
        public int LastCodAtendimento { get; private set; }
        public int LastCodConsulta { get; private set; }
        public decimal Total { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public DateTime DataSaida { get; private set; }
        public int UltimoCodigo { get; private set; }
        public int UltimoRegistro { get; private set; }
        public DateTime DataHoje { get; private set; }
        public bool EstadoRecepcao { get; private set; }

        public decimal TotalText;
        private int codInternadoNovo;
        private int indexInternado;
        int usuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private readonly IGenericoApp _GenericoApp;

        public frmIntenamentoFaturacao(IAtendimentoHospitalarApp AtendiApp,ICamasHospitalarApp cama,IGenericoApp GenericoApp)
        {
            InitializeComponent();
            _AtendiApp = AtendiApp;
            _cama = cama;
            _GenericoApp = GenericoApp;
            Permicao();
        }
        #region Permicao de Acesso

        private void Permicao()
        {
            if (usuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Internamento#Criar") == false) { btnIncluir.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Internamento#Eliminar") == false) { btnDeleteInter.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Internamento#Liberar") == false) { btnDeleteInter.Enabled = false; }

            }

        }
        #endregion



    public frmIntenamentoFaturacao FacturarDocumento(int codAtendimento, int CodPaciente,int CodTipoConsulta  )
        {
            CodAtendimento = codAtendimento;
            codPacienteNovo = CodPaciente;
            codTipoConsultaNovo = CodTipoConsulta;
            return this;
        }

        #region Inserir Internamento
        //Gravar------------------------------------------------------------
        private void GravarAtentimento()
        {
            _AtendiApp.Insert(new AtendimentoHospitalar()
            {
                CodPaciente = codPacienteNovo,
                Data = DateTime.Now.Date,
                Facturado = "Não",
                status = 1,
                CodTipoConsulta = codTipoConsultaNovo,
                CodUsuario = UtilidadesGenericas.UsuarioCodigo
            });

            LastCodAtendimento = _GenericoApp.LastCodGeral("AtendimentoHospitalar");
            codAtendimento = LastCodAtendimento;
            LastCodConsulta = _GenericoApp.LastCodGeral("ConsultaHospitalar");
        }
        private void PassagemDados()
        {
            var form = IOC.InjectForm<frmInternamentoConfiguracoes>();
            form.ShowDialog();
            CodCama = UtilidadesGenericas.Busca.CodCamaHospitalar;
            CodQuarto = UtilidadesGenericas.Busca.CodQuartoHospitalar;
            CodTarifa = UtilidadesGenericas.Busca.CodTarifaHospitalar;
            if (UtilidadesGenericas.Busca.QuantidadeHospitalar == null)
            {
                return;
            }
            Quantidade = int.Parse(UtilidadesGenericas.Busca.QuantidadeHospitalar);
            ValorTarifa = UtilidadesGenericas.Busca.ValorTarifa;
        }
        private PacienteInternadoViewModel PopulaObjecto()
        {
            Total = ValorTarifa * Quantidade;
            DataEntrada = DateTime.Now;
            DataSaida = DateTime.Now.AddDays(Quantidade);

            Internado = new PacienteInternadoViewModel()
            {
                CodQuartosHospitalar = CodQuarto,
                CodCamasHospitalar = CodCama,
                CodTarifaHospitalar = CodTarifa,
                CodAtendimentoHospitalar = CodAtendimento,
                Dias = Quantidade,
                Valor = ValorTarifa,
                DataEntrada = DataEntrada,
                DataSaida = DataSaida,
                Total = Total,
                Estado ="INTERNADO",
                Facturado ="Não"
            };
            return Internado;
        }
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            PassagemDados();
           
            if (CodAtendimento <= 0)
            {
                GravarAtentimento();
            }
            if (CodQuarto <= 0 && CodCama <= 0)
            {
                return;
            }
            else
            {
                var inter = PopulaObjecto();
                inter = _AtendiApp.GravarInternado(inter);
                MostrarIntemento();
                EditarCama();
                TotalText = _AtendiApp.Total(CodAtendimento.ToString());
                txtTotalTudo.Text = TotalText.ToString();
            }

        }
        private void EditarCama()
        {
            _cama.Update(new CamasHospitalar()
            {
                Codigo = CodCama,
                Ocupado = "Sim"
            }
            );
        }
        public void NovoIntenamento()
        {
            DataHoje = DateTime.Now;
            DataHoje.ToShortDateString();
            ListaNova = (List<PacienteInternado>)_AtendiApp.DatasInternamento(DataHoje);

            foreach (var item in ListaNova)
            {
                _AtendiApp.UpdatePaciente(new PacienteInternado()
                {
                    Codigo = item.Codigo,
                    Estado = "LIBERADO",
                    Facturado = item.Facturado
                });
                _cama.Update(new CamasHospitalar()
                {
                    Codigo = item.CodCamasHospitalar,
                    Ocupado = "Não"
                });

                int intervalo = UtilidadesGenericas.GetIntervaloDeDia(item.DataSaida, DataHoje);
                DataEntrada = DateTime.Now;
                DataSaida = DateTime.Now.AddDays(1);

                _AtendiApp.GravarInternado(new PacienteInternadoViewModel()
                {
                    CodQuartosHospitalar = item.CodQuartosHospitalar,
                    CodCamasHospitalar = item.CodCamasHospitalar,
                    CodTarifaHospitalar = item.CodTarifaHospitalar,
                    CodAtendimentoHospitalar = item.CodAtendimentoHospitalar,
                    Dias = intervalo,
                    Valor = item.Valor,
                    DataEntrada = DataEntrada,
                    DataSaida = DataSaida,
                    Total = item.Valor * intervalo,
                    Estado = "INTERNADO",
                    Facturado = "Não"
                });
            }
        }
      
        #endregion

        public void MostrarIntemento()
        {
            if (!Equals(CodAtendimento, null))
            {
                ListaInternado = (List<PacienteInternado>)_AtendiApp.ListarInternado(CodAtendimento.ToString());
                GradeIntermento.DataSource = ListaInternado;
            }
            if (UtilidadesGenericas.ListaNula(ListaInternado))
            {
                return;
            }
            TotalText = _AtendiApp.Total(CodAtendimento.ToString());
            txtTotalTudo.Text = TotalText.ToString();
        }

        private void frmIntenamentoFaturacao_Load(object sender, EventArgs e)
        {
            VerificarEstadoRecepcao();
            MostrarIntemento();
            if (UtilidadesGenericas.ListaNula(ListaInternado))
            {
                return;
            }
        }

        private void VerificarEstadoRecepcao()
        {
        //    if (CodAtendimento > 0)
        //    {
        //        EstadoRecepcao = _AtendiApp.GetEstadoAtendimento(codAtendimento);
        //        if (!EstadoRecepcao)
        //        {
        //            btnDeleteInter.Enabled = false;
        //            btnIncluir.Enabled = false;
        //            btnLiberar.Enabled = false;
        //        }
        //    }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (ListaInternado[indexInternado].Estado == "LIBERADO")
            {
                MessageBox.Show("O já foi liberado", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _AtendiApp.UpdatePaciente(new PacienteInternado()
            {
                Codigo = codInternadoNovo,
                Estado = "LIBERADO",
                Facturado = "Não"
            });
            _cama.Update(new CamasHospitalar()
            {
                Codigo = ListaInternado[indexInternado].CodCamasHospitalar,
                Ocupado = "Não"
            });
            MostrarIntemento();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            codInternadoNovo = int.Parse(gridInternados.GetRowCellValue(e.RowHandle, "Codigo").ToString());
            indexInternado = e.RowHandle;
        }

        private void btnDeleteInter_Click(object sender, EventArgs e)
        {
            if (ListaInternado[indexInternado].Estado == "LIBERADO")
            {
                MessageBox.Show("Não é possivel Apagar o Paciente, porque já foi liberado ", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DialogResult.Yes == (MessageBox.Show("Deseja Eliminar Registo?", "AVISO!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)))
            {
                try
                {
                    _AtendiApp.DeleteInternado(new PacienteInternado()
                    {
                        Codigo = codInternadoNovo,
                    });
                    MostrarIntemento();
                }
                catch (Exception)
                {
                    throw new Exception("Erro ao Deletar\n");
                }
            }
        }
    }
}