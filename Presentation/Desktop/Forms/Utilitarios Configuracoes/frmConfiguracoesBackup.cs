using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.ViewModels.UtilitariosConfiguracoes;
using Folha.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Utilitarios_Configuracoes
{
    public partial class frmConfiguracoesBackup : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IPeriodoBackupApp _perido;
        private PeriodoBackupViewModel Entity { get; set; }
        public string DataHoje { get; private set; }
        public string DataBackup { get; private set; }
        private PeriodoBackup Periodo;
        List<PeriodoBackup> lista;

        public string CaminhoPadrao { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\BACKUP TREVO Folha\";

        public frmConfiguracoesBackup(IPeriodoBackupApp perido)
        {
            InitializeComponent();
            _perido = perido;
        }

        private void frmConfiguracoesBackup_Load(object sender, EventArgs e)
        {
            lista = (List<PeriodoBackup>)_perido.Listar();
            if (UtilidadesGenericas.ListaNula(lista))
            {
                return;
            }
            else
            {
                txtCodigo.Text = lista[0].Codigo.ToString();
                cboPeriodo.Text = lista[0].Periodo;
                txtIntervalo.Text = lista[0].Intervalo.ToString();
                txtCaminho.Text = lista[0].Caminho.ToString();

            }
        }
        
      
        private void cboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboPeriodo.Text == "Semanal")
            {
                txtIntervalo.Text = "7";
            }
            else if (cboPeriodo.Text == "Mensal")
            {
                txtIntervalo.Text = "30";
            }
            else if (cboPeriodo.Text == "Trimestral")
            {
                txtIntervalo.Text = "90";
            }
            else if (cboPeriodo.Text == "Anual")
            {
                txtIntervalo.Text = "365";
            }
            else if (cboPeriodo.Text == "Diario")
            {
                txtIntervalo.Text = "1";
            }
        }
        private PeriodoBackup PopulaObjecto()
        {
            Periodo = new PeriodoBackup()
            {
               Periodo = cboPeriodo.Text,
               Intervalo = int.Parse(txtIntervalo.Text),
               Data = DateTime.Now,
               Caminho = txtCaminho.Text

            };
            if (!string.IsNullOrEmpty(txtCodigo.Text)) Periodo.Codigo = int.Parse(txtCodigo.Text);
            return Periodo;
        }
        private void btnSalvaFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            var perido = PopulaObjecto();
            perido = _perido.Gravar(perido);
            UtilidadesGenericas.Busca.Alterou = true;
            Close();
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnBuscarCaminho_Click(object sender, EventArgs e)
        {
            
        }

        private void txtCaminho_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.SelectedPath = CaminhoPadrao;
            folder.ShowDialog();
            if (!string.IsNullOrEmpty(folder.SelectedPath))
            {
                txtCaminho.Text = folder.SelectedPath;
                CaminhoPadrao = folder.SelectedPath;
            }
        }
    }
}