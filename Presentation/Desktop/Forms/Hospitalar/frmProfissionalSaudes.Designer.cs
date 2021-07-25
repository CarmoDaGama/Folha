namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    partial class frmProfissionalSaudes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfissionalSaudes));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSelecionar = new DevExpress.XtraBars.BarButtonItem();
            this.btnNovo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.GradeProfissional = new DevExpress.XtraGrid.GridControl();
            this.gridProfissional = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GradeProfissional)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProfissional)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnSelecionar,
            this.btnNovo,
            this.barButtonItem3,
            this.btnEliminar,
            this.btnPrint,
            this.barButtonItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(623, 61);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Caption = "Selecionar";
            this.btnSelecionar.Id = 1;
            this.btnSelecionar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSelecionar.ImageOptions.SvgImage")));
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSelecionar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelecionar_ItemClick);
            // 
            // btnNovo
            // 
            this.btnNovo.Caption = "Novo";
            this.btnNovo.Id = 2;
            this.btnNovo.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Addd_27px;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNovo_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Voltar";
            this.barButtonItem3.Id = 5;
            this.barButtonItem3.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Voltar;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Id = 6;
            this.btnEliminar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEliminar.ImageOptions.SvgImage")));
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "Imprimir";
            this.btnPrint.Id = 7;
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.Name = "btnPrint";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSelecionar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNovo);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEliminar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPrint);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // GradeProfissional
            // 
            this.GradeProfissional.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GradeProfissional.Location = new System.Drawing.Point(0, 61);
            this.GradeProfissional.MainView = this.gridProfissional;
            this.GradeProfissional.Name = "GradeProfissional";
            this.GradeProfissional.Size = new System.Drawing.Size(623, 478);
            this.GradeProfissional.TabIndex = 14;
            this.GradeProfissional.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridProfissional});
            // 
            // gridProfissional
            // 
            this.gridProfissional.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridProfissional.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridProfissional.GridControl = this.GradeProfissional;
            this.gridProfissional.Name = "gridProfissional";
            this.gridProfissional.OptionsFind.AlwaysVisible = true;
            this.gridProfissional.OptionsFind.FindNullPrompt = "Pesquisar...";
            this.gridProfissional.OptionsFind.ShowClearButton = false;
            this.gridProfissional.OptionsFind.ShowFindButton = false;
            this.gridProfissional.OptionsView.ShowGroupPanel = false;
            this.gridProfissional.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridProfissional_RowClick);
            this.gridProfissional.DoubleClick += new System.EventHandler(this.gridProfissional_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Código";
            this.gridColumn1.FieldName = "Codigo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 60;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Descrição";
            this.gridColumn2.FieldName = "Nome";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 415;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Especilidade";
            this.gridColumn3.FieldName = "Descricao";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 124;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Actualizar";
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // frmProfissionalSaudes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 539);
            this.Controls.Add(this.GradeProfissional);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmProfissionalSaudes";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profissionais de Saude";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GradeProfissional)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProfissional)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        public DevExpress.XtraBars.BarButtonItem btnSelecionar;
        private DevExpress.XtraGrid.GridControl GradeProfissional;
        private DevExpress.XtraGrid.Views.Grid.GridView gridProfissional;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraBars.BarButtonItem btnNovo;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}