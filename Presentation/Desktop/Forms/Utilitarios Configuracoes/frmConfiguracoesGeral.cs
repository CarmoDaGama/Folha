using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Admin;
using Folha.Domain.Models.Admin;
using Folha.Domain.Models.Administrador;
using Folha.Domain.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Utilitarios_Configuracoes
{
    public partial class frmConfiguracoesGeral : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private List<DefinicoesGeraisViewModel> Gerais;

        private DefinicoesGeraisViewModel EntityGeral { get; set; } = new DefinicoesGeraisViewModel();
      
        private DefinicoesGerais geral;

        private readonly IDefinicoesGeraisApp _DefinicoesGeraisApp;

        public frmConfiguracoesGeral(IDefinicoesGeraisApp DefinicoesGeraisApp)
        {
            InitializeComponent();
            _DefinicoesGeraisApp = DefinicoesGeraisApp;
            navigationFrame1.SelectedPage = navigationPagedados;
        }

    
        #region LISTA
        private void Listagem()
        {
            PopularDadosGeral(EntityGeral.codigo);
           
        }
        private void PopularDadosGeral(int Codigo)
        {
            if (Codigo > 0)
            {
                return;
            }
            else
            {
                Gerais = _DefinicoesGeraisApp.ListarGerais(null);
                CkVenderSemStock.Checked = Gerais[0].StateVenderSemStock;
                ChLucroPos.Checked = Gerais[0].StateLucroPos;
                chcliente.Checked = Gerais[0].StateCliente;
              
            }
        }
        #endregion
        #region UPDATE 
        private void UpdateGeral()
        {
            var geral = PopulaGeral();
            geral = _DefinicoesGeraisApp.GravarGeral(geral);
            
        }
        private DefinicoesGerais PopulaGeral()
        {
            geral = new DefinicoesGerais()
            {
                VenderSemStock = CkVenderSemStock.Checked,
                
                LucroPos = ChLucroPos.Checked,
                Cliente = chcliente.Checked
            };
            return geral;
        }
        #endregion

        private void frmConfiguracoesGeral_Load(object sender, EventArgs e)
        {
            Listagem();
        }
        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateGeral();
        }
        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
        private void btnSalvaFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            UpdateGeral();
            Close();
        }
    }
}