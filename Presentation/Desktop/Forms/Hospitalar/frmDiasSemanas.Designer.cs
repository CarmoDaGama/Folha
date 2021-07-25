namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    partial class frmDiasSemanas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiasSemanas));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSelect = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gradeDias = new DevExpress.XtraGrid.GridControl();
            this.gridDias = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Dias = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDias)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnSelect});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 2;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(355, 61);
            // 
            // btnSelect
            // 
            this.btnSelect.Caption = "Selecionar";
            this.btnSelect.Id = 1;
            this.btnSelect.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSelect.ImageOptions.SvgImage")));
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelect_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSelect);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // gradeDias
            // 
            this.gradeDias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradeDias.Location = new System.Drawing.Point(0, 61);
            this.gradeDias.MainView = this.gridDias;
            this.gradeDias.MenuManager = this.ribbon;
            this.gradeDias.Name = "gradeDias";
            this.gradeDias.Size = new System.Drawing.Size(355, 230);
            this.gradeDias.TabIndex = 2;
            this.gradeDias.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridDias});
            // 
            // gridDias
            // 
            this.gridDias.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Codigo,
            this.Dias});
            this.gridDias.GridControl = this.gradeDias;
            this.gridDias.Name = "gridDias";
            this.gridDias.OptionsView.ShowGroupPanel = false;
            this.gridDias.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridDias_RowClick);
            this.gridDias.DoubleClick += new System.EventHandler(this.gridDias_DoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Codigo";
            this.Codigo.FieldName = "IDDias";
            this.Codigo.Name = "Codigo";
            this.Codigo.OptionsColumn.AllowEdit = false;
            this.Codigo.OptionsColumn.AllowFocus = false;
            this.Codigo.Visible = true;
            this.Codigo.VisibleIndex = 0;
            this.Codigo.Width = 70;
            // 
            // Dias
            // 
            this.Dias.Caption = "Dias de Semana";
            this.Dias.FieldName = "DescricaoDias";
            this.Dias.Name = "Dias";
            this.Dias.OptionsColumn.AllowEdit = false;
            this.Dias.OptionsColumn.AllowFocus = false;
            this.Dias.Visible = true;
            this.Dias.VisibleIndex = 1;
            this.Dias.Width = 342;
            // 
            // frmDiasSemanas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 291);
            this.Controls.Add(this.gradeDias);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDiasSemanas";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dias da Semana";
            this.Load += new System.EventHandler(this.frmDiasSemanas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        public DevExpress.XtraBars.BarButtonItem btnSelect;
        private DevExpress.XtraGrid.GridControl gradeDias;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDias;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
        private DevExpress.XtraGrid.Columns.GridColumn Dias;
    }
}