namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    partial class frmBuscaPacientes
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaPacientes));
            this.tabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.gridControlBuscaPacientes = new DevExpress.XtraGrid.GridControl();
            this.gridViewBuscaPacientes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem6 = new DevExpress.XtraBars.BarEditItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSelecionar = new DevExpress.XtraBars.BarButtonItem();
            this.btnNovo = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBuscaPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBuscaPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlBuscaPacientes
            // 
            this.gridControlBuscaPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlBuscaPacientes.Location = new System.Drawing.Point(0, 61);
            this.gridControlBuscaPacientes.MainView = this.gridViewBuscaPacientes;
            this.gridControlBuscaPacientes.Name = "gridControlBuscaPacientes";
            this.gridControlBuscaPacientes.Size = new System.Drawing.Size(490, 444);
            this.gridControlBuscaPacientes.TabIndex = 124;
            this.gridControlBuscaPacientes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBuscaPacientes});
            // 
            // gridViewBuscaPacientes
            // 
            this.gridViewBuscaPacientes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCodigo,
            this.gridColumnDescricao});
            this.gridViewBuscaPacientes.GridControl = this.gridControlBuscaPacientes;
            this.gridViewBuscaPacientes.Name = "gridViewBuscaPacientes";
            this.gridViewBuscaPacientes.OptionsView.ShowGroupPanel = false;
            this.gridViewBuscaPacientes.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewBuscaPacientes_RowClick);
            this.gridViewBuscaPacientes.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridViewBuscaPacientes_RowCellClick);
            this.gridViewBuscaPacientes.DoubleClick += new System.EventHandler(this.gridViewBuscaPacientes_DoubleClick);
            // 
            // gridColumnCodigo
            // 
            this.gridColumnCodigo.Caption = "Código";
            this.gridColumnCodigo.FieldName = "Codigo";
            this.gridColumnCodigo.Name = "gridColumnCodigo";
            this.gridColumnCodigo.OptionsColumn.AllowEdit = false;
            this.gridColumnCodigo.OptionsColumn.AllowFocus = false;
            this.gridColumnCodigo.OptionsColumn.FixedWidth = true;
            this.gridColumnCodigo.Visible = true;
            this.gridColumnCodigo.VisibleIndex = 0;
            // 
            // gridColumnDescricao
            // 
            this.gridColumnDescricao.Caption = "Nome";
            this.gridColumnDescricao.FieldName = "Nome";
            this.gridColumnDescricao.Name = "gridColumnDescricao";
            this.gridColumnDescricao.OptionsColumn.AllowEdit = false;
            this.gridColumnDescricao.OptionsColumn.AllowFocus = false;
            this.gridColumnDescricao.Visible = true;
            this.gridColumnDescricao.VisibleIndex = 1;
            this.gridColumnDescricao.Width = 322;
            // 
            // ribbon
            // 
            this.ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbon.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.barButtonItem2,
            this.btnVoltar,
            this.barButtonItem4,
            this.barEditItem1,
            this.barEditItem2,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barEditItem6,
            this.barButtonItem8,
            this.barButtonItem9,
            this.barButtonItem11,
            this.barButtonItem14,
            this.barButtonItem16,
            this.barButtonItem17,
            this.btnSelecionar,
            this.btnNovo});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 22;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(490, 61);
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Salvar e Fechar";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Voltar";
            this.btnVoltar.Id = 3;
            this.btnVoltar.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Voltar;
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVoltar_ItemClick);
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
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Canselar";
            this.barButtonItem6.Id = 8;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barEditItem6
            // 
            this.barEditItem6.AutoFillWidthInMenu = DevExpress.Utils.DefaultBoolean.True;
            this.barEditItem6.Edit = null;
            this.barEditItem6.Id = 9;
            this.barEditItem6.Name = "barEditItem6";
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
            this.btnSelecionar.Id = 20;
            this.btnSelecionar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSelecionar.ImageOptions.SvgImage")));
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnSelecionar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelecionar_ItemClick);
            // 
            // btnNovo
            // 
            this.btnNovo.Caption = "Novo";
            this.btnNovo.Id = 21;
            this.btnNovo.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Addd_27px;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNovo_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Opções";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSelecionar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNovo);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // frmBuscaPacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 505);
            this.ControlBox = false;
            this.Controls.Add(this.gridControlBuscaPacientes);
            this.Controls.Add(this.ribbon);
            this.Name = "frmBuscaPacientes";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pacientes";
            this.Load += new System.EventHandler(this.frmBuscaPacientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBuscaPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBuscaPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView;
        private DevExpress.XtraGrid.GridControl gridControlBuscaPacientes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewBuscaPacientes;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescricao;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnVoltar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarEditItem barEditItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        private DevExpress.XtraBars.BarButtonItem barButtonItem16;
        private DevExpress.XtraBars.BarButtonItem barButtonItem17;
        private DevExpress.XtraBars.BarButtonItem btnSelecionar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnNovo;
    }
}