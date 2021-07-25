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

namespace Folha.Presentation.Desktop.Forms.Fiscalisacao
{
    using Folha.Domain.Interfaces.Application.Ficalizacao;
    using Folha.Domain.Helpers;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    public partial class frmGerarSaft : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ISaftApp _saftApp;
        public string CaminhoPadrao { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SAFT TREVO Folha\";
        public frmGerarSaft(ISaftApp saftApp)
        {
            InitializeComponent();
            _saftApp = saftApp;
        }

        private bool ValidarField()
        {
            bool validado = true;
            if (txtCaminho.Text.Equals(string.Empty))
            {
                UtilidadesGenericas.MsgShow("Selecione uma pasta para pader salvar o ficheiro SAFT", MessageBoxIcon.Stop);
                return false;
            }
            int intervalosDias = UtilidadesGenericas.GetIntervaloDeDia(Convert.ToDateTime(dateInicio.Text), Convert.ToDateTime(dateFim.Text));
            if (intervalosDias < 1)
            {
                UtilidadesGenericas.MsgShow("O intervalo das datas são invalido!", MessageBoxIcon.Stop);
                return false;
            }
            return validado;
        }
        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        { 
            Close();
        }

        private void btnBuscarCaminho_Click(object sender, EventArgs e)
        {
            
        }

        private void frmGerarSaft_Load(object sender, EventArgs e)
        {
            dateInicio.Text = DateTime.Now.ToShortDateString();
            dateFim.Text = DateTime.Now.ToShortDateString();
            dateInicio.Properties.MaxValue =  DateTime.Now;
            //dateInicio.Properties.MinValue = new DateTime(2021, 01, 01);
            dateFim.Properties.MaxValue = DateTime.Now;
            if (!Directory.Exists(CaminhoPadrao))
            {
                Directory.CreateDirectory(CaminhoPadrao);
            }
            txtCaminho.Text = CaminhoPadrao;
        }

        private void buttonSaveClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ValidarField())
            {
                _saftApp.GerarSaft(Convert.ToDateTime(dateInicio.EditValue), Convert.ToDateTime(dateFim.EditValue), txtCaminho.Text, GetNomeFicheiro());
                UtilidadesGenericas.MsgShow("Ficheiro Gerado com sucesso!", MessageBoxIcon.Information);
                var caminhoCompleto = CaminhoPadrao + GetNomeFicheiro() + ".xml";
                if (File.Exists(CaminhoPadrao + GetNomeFicheiro()+".xml")){
                    btnAbrirSaft.Enabled = true;
                    //txtCaminho.Text = CaminhoPadrao + GetNomeFicheiro() + ".xml";
                }
                else
                {
                    btnAbrirSaft.Enabled = false;
                }
            }
        }

        private string GetNomeFicheiro()
        {
            var nome = "SaftTrevoFolha";
            var data = DateTime.Now.ToString("yyyy-MM-ddThh").Replace("-", "_").Replace(":", string.Empty);
            return nome+data;
        }

        private void btnAbrirSaft_ItemClick(object sender, ItemClickEventArgs e)
        {
            //File.Open(CaminhoPadrao + GetNomeFicheiro() + ".xml", FileMode.Open);
            Process.Start(CaminhoPadrao + GetNomeFicheiro() + ".xml");
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