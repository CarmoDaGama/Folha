using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
//using Folha.Domain.Strings.Rotulos;
using System.Threading;
using Folha.Domain.Models.Empresa;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Classe
{
    public static class Controle
    {
        /// <summary>
        /// Metodo para fixar o formulário no painel principal
        /// </summary>
        /// <param name="painel"></param>
        /// <param name="formulario"></param>
        /// 

        public static string RetornaValores;
        public static List<string> ValoresRetornados;
        public static Empresa CabecalhoEmpresa { get; set; }

        public static void Painel(Panel painel, Form formulario)
        {
            UtilidadesGenericas.showFormInPanel(painel, formulario);
        }

        public static void HabilitarBotao(params BarButtonItem[] botoes)
        {
            foreach (BarButtonItem b in botoes)
            { b.Enabled = true; }
        }
        public static void DesabilitarBotao(params BarButtonItem[] botoes)
        {
            foreach (BarButtonItem b in botoes) { b.Enabled = false; }
        }
        public static void DesabilitarControle(params Control[] controle)
        {
            foreach (Control b in controle) { b.Enabled = false; }
        }
        public static void HabilitarSimpleButton(params SimpleButton[] botoes)
        {
            foreach (SimpleButton b in botoes)
            {
                b.Enabled = true;
            }
        }
        public static void HabilitarControle(params Control[] texto)
        {
            foreach (Control t in texto)
            { t.Enabled = true; }
        }

        public static void LimpaControle(params Control[] controle)
        {
            foreach (Control b in controle) { b.Text = null; }
        }
        /// <summary> Campos do Unidade bancaria
        static TextEdit CodigoBancaria;
        static TextEdit DescricaoBancaria;

        public static void CamposBancarioG(TextEdit Cod, TextEdit Descricao)
        {
            Cod.Text = CodigoBancaria.Text;
            Descricao.Text = DescricaoBancaria.Text;
        }
        public static void CamposBancarioM(string cod,string descricao)
        {
            CodigoBancaria.Text = cod;
            DescricaoBancaria.Text = descricao;
        }

        #region RELATÓRIO HOSPITALAR
        public static void HabilitarHospitalar(int codigo,params Control[] controle)
        {
            foreach (Control b in controle)
            {
                if (codigo == 1)
                {
                    controle[0].Enabled = true;
                }
                if (codigo == 2)
                {
                    controle[1].Text = "Grupo Sanguineo:";
                    controle[2].Enabled = true;
                }
                if (codigo == 3)
                {
                    controle[4].Enabled = true;
                }
                if (codigo == 6)
                {
                    controle[1].Text = "Estado";
                    controle[1].Enabled = true;
                    controle[2].Enabled = true;
                    controle[3].Enabled = true;
                    controle[4].Enabled = true;
                }
                //Graficos
                if (codigo == 33)
                {
                    controle[3].Enabled = true;
                    controle[4].Enabled = true;
                    controle[5].Enabled = true;
                }

            }
        }
        public static void DesabilitarHospitalar(int codigo, params Control[] controle)
        {
            foreach (Control b in controle)
            {
                if (codigo == 1)
                {
                    controle[0].Enabled = false;
                }
                if (codigo == 2)
                {
                    controle[1].Text = "Grupo Sanguineo:";
                    controle[2].Enabled = false;
                }
                if (codigo == 3)
                {
                    controle[4].Enabled = false;
                }
                if (codigo == 6)
                {
                    controle[1].Text = "Estado:";
                    controle[1].Enabled = false;
                    controle[2].Enabled = false;
                    controle[3].Enabled = false;
                    controle[4].Enabled = false;
                }
                //Graficos
                if (codigo == 33)
                {
                    controle[3].Enabled = false;
                    controle[4].Enabled = false;
                    controle[5].Enabled = false;
                }

            }
        }
        #endregion


        /// </summary>


        public static void InvisivelControle(params Control[] controle)
        {
            foreach (Control b in controle) { b.Visible= false; }
        }
        public static void VisivelControle(params Control[] controle)
        {
            foreach (Control b in controle) { b.Visible = true; }
        }
        #region FORMULÁRIOS
        //public static frmCorreioEletronico CorreioE = new frmCorreioEletronico();
            
        #endregion
        //=========*Idioma*=========
        public static void Idioma(){
            //Form Utilitários e Configurações
            //CorreioE.lblAnexo.Text = Rotulos.Anexos;
            //CorreioE.lblConta.Text = Rotulos.Conta;
            //CorreioE.lblEntidade.Text = Rotulos.Entidade;
            //CorreioE.lblEnviarEmail.Text = Rotulos.EnviarEmail;
            //CorreioE.btnEnviarEmail.Text = Rotulos.EnviarEmail;
            //CorreioE.btnAnexos.Text = Rotulos.Anexos;
            //CorreioE.btnEnviar.Caption = Rotulos.Enviar; 
            //CorreioE.btnVoltar.Caption = Rotulos.Voltar;
            //CorreioE.btnInserir.Text = Rotulos.Inserir;
            //CorreioE.btnRemover.Text = Rotulos.Remover;

        }

        public static Thread threadProcessamento { get; set; }
        public static void AbortarThread()
        {
            //try
            //{
            //    if (!Equals(threadProcessamento, null))
            //    {
            //        threadProcessamento.Abort();
            //        threadProcessamento = null;
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }
        public static void Processamento()
        {
            //try
            //{
            //    threadProcessamento = null;
            //    threadProcessamento = new Thread(processarFormLoad);
            //    threadProcessamento.Start();
            //}
            //catch (Exception)
            //{
            //}
        }
        public static void processarFormLoad()
        {
            //try
            //{
            //    var formLoad = new frmSplash();
            //    formLoad.ShowDialog();
            //}
            //catch (Exception ex)
            //{

            //}
        }
    }
}
