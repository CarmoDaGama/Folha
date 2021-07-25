namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    partial class frmContasBancarias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContasBancarias));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bntPrint = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.btnSelecionar = new DevExpress.XtraBars.BarButtonItem();
            this.btnNovo = new DevExpress.XtraBars.BarButtonItem();
            this.btnFechar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gradeBancos = new DevExpress.XtraGrid.GridControl();
            this.gridBancos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeBancos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBancos)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbonControl.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bntPrint,
            this.bsiRecordsCount,
            this.btnSelecionar,
            this.btnNovo,
            this.btnFechar,
            this.bbiRefresh,
            this.btnAdd,
            this.btnVoltar,
            this.btnEliminar});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 24;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl.Size = new System.Drawing.Size(864, 61);
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bntPrint
            // 
            this.bntPrint.Caption = "Imprimir";
            this.bntPrint.Id = 14;
            this.bntPrint.ImageOptions.ImageUri.Uri = "Preview";
            this.bntPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bntPrint.ImageOptions.SvgImage")));
            this.bntPrint.Name = "bntPrint";
            this.bntPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bntPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bntPrint_ItemClick);
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Caption = "Adicionar";
            this.btnSelecionar.Enabled = false;
            this.btnSelecionar.Id = 16;
            this.btnSelecionar.ImageOptions.ImageUri.Uri = "New";
            this.btnSelecionar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSelecionar.ImageOptions.SvgImage")));
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSelecionar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelecionar_ItemClick);
            // 
            // btnNovo
            // 
            this.btnNovo.Caption = "Novo";
            this.btnNovo.Id = 17;
            this.btnNovo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.ImageOptions.Image")));
            this.btnNovo.ImageOptions.ImageUri.Uri = "Edit";
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNovo_ItemClick);
            // 
            // btnFechar
            // 
            this.btnFechar.Caption = "Voltar";
            this.btnFechar.Id = 18;
            this.btnFechar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.ImageOptions.Image")));
            this.btnFechar.ImageOptions.ImageUri.Uri = "Delete";
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFechar_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "Refresh";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.ImageUri.Uri = "Refresh";
            this.bbiRefresh.Name = "bbiRefresh";
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Criar";
            this.btnAdd.Id = 20;
            this.btnAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAdd.ImageOptions.SvgImage")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Fechar";
            this.btnVoltar.Id = 21;
            this.btnVoltar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVoltar.ImageOptions.SvgImage")));
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVoltar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Id = 22;
            this.btnEliminar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEliminar.ImageOptions.SvgImage")));
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Opções";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSelecionar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAdd);
            this.ribbonPageGroup1.ItemLinks.Add(this.bntPrint);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup3.ItemLinks.Add(this.btnEliminar);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // gradeBancos
            // 
            this.gradeBancos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode2.RelationName = "Level1";
            this.gradeBancos.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gradeBancos.Location = new System.Drawing.Point(8, 77);
            this.gradeBancos.MainView = this.gridBancos;
            this.gradeBancos.Name = "gradeBancos";
            this.gradeBancos.Size = new System.Drawing.Size(842, 497);
            this.gradeBancos.TabIndex = 115;
            this.gradeBancos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridBancos});
            // 
            // gridBancos
            // 
            this.gridBancos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridBancos.GridControl = this.gradeBancos;
            this.gridBancos.Name = "gridBancos";
            this.gridBancos.OptionsBehavior.Editable = false;
            this.gridBancos.OptionsFind.AlwaysVisible = true;
            this.gridBancos.OptionsFind.FindNullPrompt = "Pesquisar...";
            this.gridBancos.OptionsFind.ShowClearButton = false;
            this.gridBancos.OptionsFind.ShowFindButton = false;
            this.gridBancos.OptionsView.ShowGroupPanel = false;
            this.gridBancos.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvBancos_RowClick);
            this.gridBancos.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvBancos_RowCellClick);
            this.gridBancos.DoubleClick += new System.EventHandler(this.gridBancos_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Código";
            this.gridColumn1.FieldName = "codigo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 58;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Número";
            this.gridColumn3.FieldName = "Numero";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 89;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Natureza";
            this.gridColumn4.FieldName = "Natureza";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 96;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Sequência";
            this.gridColumn2.FieldName = "Sequencia";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 106;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Banco";
            this.gridColumn5.FieldName = "Descricao";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 227;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Iban";
            this.gridColumn6.FieldName = "Iban";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 86;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Swift";
            this.gridColumn7.FieldName = "Swift";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 130;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Natureza";
            this.gridColumn8.FieldName = "Nat";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            this.gridColumn8.Width = 89;
            // 
            // frmContasBancarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 599);
            this.ControlBox = false;
            this.Controls.Add(this.gradeBancos);
            this.Controls.Add(this.ribbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmContasBancarias";
            this.Ribbon = this.ribbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contas Bancárias";
            this.Load += new System.EventHandler(this.frmContasBancarias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeBancos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBancos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bntPrint;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem btnSelecionar;
        private DevExpress.XtraBars.BarButtonItem btnNovo;
        private DevExpress.XtraBars.BarButtonItem btnFechar;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraGrid.GridControl gradeBancos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridBancos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        internal DevExpress.XtraBars.BarButtonItem btnVoltar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}