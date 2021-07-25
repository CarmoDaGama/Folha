namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    partial class frmMedicos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicos));
            this.gradeMedicos = new DevExpress.XtraGrid.GridControl();
            this.gridMedico = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSv = new DevExpress.XtraBars.BarButtonItem();
            this.btnSvFechar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem6 = new DevExpress.XtraBars.BarEditItem();
            this.btnNovo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSelecionar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.cboInternamento = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeMedicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMedico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboInternamento.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gradeMedicos
            // 
            this.gradeMedicos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradeMedicos.Location = new System.Drawing.Point(0, 61);
            this.gradeMedicos.MainView = this.gridMedico;
            this.gradeMedicos.Name = "gradeMedicos";
            this.gradeMedicos.Size = new System.Drawing.Size(552, 459);
            this.gradeMedicos.TabIndex = 118;
            this.gradeMedicos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridMedico});
            // 
            // gridMedico
            // 
            this.gridMedico.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCod,
            this.gridColumn3});
            this.gridMedico.GridControl = this.gradeMedicos;
            this.gridMedico.Name = "gridMedico";
            this.gridMedico.OptionsBehavior.Editable = false;
            this.gridMedico.OptionsFind.AlwaysVisible = true;
            this.gridMedico.OptionsFind.FindNullPrompt = "Pesquisar...";
            this.gridMedico.OptionsFind.ShowClearButton = false;
            this.gridMedico.OptionsFind.ShowFindButton = false;
            this.gridMedico.OptionsView.ShowGroupPanel = false;
            this.gridMedico.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridMedico_RowClick);
            this.gridMedico.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridMedico_RowCellClick);
            this.gridMedico.DoubleClick += new System.EventHandler(this.gridMedico_DoubleClick);
            // 
            // gridCod
            // 
            this.gridCod.Caption = "Código";
            this.gridCod.FieldName = "CodMedico";
            this.gridCod.Name = "gridCod";
            this.gridCod.OptionsColumn.AllowEdit = false;
            this.gridCod.OptionsColumn.AllowFocus = false;
            this.gridCod.OptionsColumn.FixedWidth = true;
            this.gridCod.Visible = true;
            this.gridCod.VisibleIndex = 0;
            this.gridCod.Width = 54;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Nome";
            this.gridColumn3.FieldName = "Nome";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 447;
            // 
            // ribbon
            // 
            this.ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbon.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnSv,
            this.btnSvFechar,
            this.barButtonItem4,
            this.barEditItem1,
            this.barEditItem2,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barEditItem6,
            this.btnNovo,
            this.barButtonItem8,
            this.barButtonItem9,
            this.barButtonItem11,
            this.btnImprimir,
            this.barButtonItem14,
            this.barButtonItem16,
            this.barButtonItem17,
            this.btnSelecionar,
            this.btnEliminar,
            this.btnVoltar});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 25;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(552, 61);
            // 
            // btnSv
            // 
            this.btnSv.Caption = "Salvar";
            this.btnSv.Enabled = false;
            this.btnSv.Id = 1;
            this.btnSv.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSv.ImageOptions.SvgImage")));
            this.btnSv.Name = "btnSv";
            // 
            // btnSvFechar
            // 
            this.btnSvFechar.Caption = "Salvar e Fechar";
            this.btnSvFechar.Enabled = false;
            this.btnSvFechar.Id = 2;
            this.btnSvFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSvFechar.ImageOptions.SvgImage")));
            this.btnSvFechar.Name = "btnSvFechar";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = null;
            this.barEditItem1.Id = 5;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // barEditItem2
            // 
            this.barEditItem2.AutoFillWidthInMenu = DevExpress.Utils.DefaultBoolean.True;
            this.barEditItem2.Edit = null;
            this.barEditItem2.Id = 6;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Adicionar";
            this.barButtonItem5.Id = 7;
            this.barButtonItem5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.Image")));
            this.barButtonItem5.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.LargeImage")));
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Canselar";
            this.barButtonItem6.Id = 8;
            this.barButtonItem6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.Image")));
            this.barButtonItem6.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.LargeImage")));
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barEditItem6
            // 
            this.barEditItem6.AutoFillWidthInMenu = DevExpress.Utils.DefaultBoolean.True;
            this.barEditItem6.Edit = null;
            this.barEditItem6.Id = 9;
            this.barEditItem6.Name = "barEditItem6";
            // 
            // btnNovo
            // 
            this.btnNovo.Caption = "Novo";
            this.btnNovo.Id = 10;
            this.btnNovo.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Addd_27px;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNovo_ItemClick);
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Id = 11;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Id = 12;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "barButtonItem11";
            this.barButtonItem11.Id = 14;
            this.barButtonItem11.Name = "barButtonItem11";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Caption = "Imprimir";
            this.btnImprimir.Id = 16;
            this.btnImprimir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnImprimir.ImageOptions.SvgImage")));
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimir_ItemClick);
            // 
            // barButtonItem14
            // 
            this.barButtonItem14.Id = 17;
            this.barButtonItem14.Name = "barButtonItem14";
            // 
            // barButtonItem16
            // 
            this.barButtonItem16.Id = 18;
            this.barButtonItem16.Name = "barButtonItem16";
            // 
            // barButtonItem17
            // 
            this.barButtonItem17.Caption = "barButtonItem17";
            this.barButtonItem17.Id = 19;
            this.barButtonItem17.Name = "barButtonItem17";
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Caption = "Selecionar";
            this.btnSelecionar.Id = 22;
            this.btnSelecionar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSelecionar.ImageOptions.SvgImage")));
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSelecionar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelecionar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Id = 23;
            this.btnEliminar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEliminar.ImageOptions.SvgImage")));
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Voltar";
            this.btnVoltar.Id = 24;
            this.btnVoltar.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Voltar;
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVoltar_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Opções";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnSelecionar);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnNovo);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnEliminar);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnImprimir);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Adicionar";
            // 
            // cboInternamento
            // 
            this.cboInternamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboInternamento.EditValue = "ACTIVOS";
            this.cboInternamento.Location = new System.Drawing.Point(427, 33);
            this.cboInternamento.MenuManager = this.ribbon;
            this.cboInternamento.Name = "cboInternamento";
            this.cboInternamento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInternamento.Properties.Appearance.Options.UseFont = true;
            this.cboInternamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboInternamento.Properties.Items.AddRange(new object[] {
            "ACTIVOS",
            "ELIMINADOS",
            "TODOS",
            ""});
            this.cboInternamento.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboInternamento.Size = new System.Drawing.Size(117, 22);
            this.cboInternamento.TabIndex = 212;
            this.cboInternamento.Visible = false;
            this.cboInternamento.SelectedIndexChanged += new System.EventHandler(this.cboInternamento_SelectedIndexChanged);
            // 
            // frmMedicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 520);
            this.Controls.Add(this.cboInternamento);
            this.Controls.Add(this.gradeMedicos);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMedicos";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Médicos";
            this.Load += new System.EventHandler(this.frmVerMedicos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradeMedicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMedico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboInternamento.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gradeMedicos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridMedico;
        private DevExpress.XtraGrid.Columns.GridColumn gridCod;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnSv;
        private DevExpress.XtraBars.BarButtonItem btnSvFechar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarEditItem barEditItem6;
        private DevExpress.XtraBars.BarButtonItem btnNovo;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        private DevExpress.XtraBars.BarButtonItem barButtonItem16;
        private DevExpress.XtraBars.BarButtonItem barButtonItem17;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        public DevExpress.XtraBars.BarButtonItem btnSelecionar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarButtonItem btnVoltar;
        private DevExpress.XtraEditors.ComboBoxEdit cboInternamento;
    }
}