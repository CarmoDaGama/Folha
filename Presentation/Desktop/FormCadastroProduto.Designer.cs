namespace Enterprise.Presentation.Desktop
{
    partial class FormCadastroProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastroProduto));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.buttonGravar = new DevExpress.XtraBars.BarButtonItem();
            this.buttonImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.buttonCancelar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.pageDadosGerais = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.buttonGravar,
            this.buttonImprimir,
            this.buttonCancelar});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ribbon.MaxItemId = 4;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(759, 157);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // buttonGravar
            // 
            this.buttonGravar.Caption = "Gravar";
            this.buttonGravar.Id = 1;
            this.buttonGravar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonGravar.ImageOptions.Image")));
            this.buttonGravar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonGravar.ImageOptions.LargeImage")));
            this.buttonGravar.Name = "buttonGravar";
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Caption = "Imprimir";
            this.buttonImprimir.Id = 2;
            this.buttonImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonImprimir.ImageOptions.Image")));
            this.buttonImprimir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonImprimir.ImageOptions.LargeImage")));
            this.buttonImprimir.Name = "buttonImprimir";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Caption = "Cancelar";
            this.buttonCancelar.Id = 3;
            this.buttonCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancelar.ImageOptions.Image")));
            this.buttonCancelar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("buttonCancelar.ImageOptions.LargeImage")));
            this.buttonCancelar.Name = "buttonCancelar";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.buttonGravar);
            this.ribbonPageGroup1.ItemLinks.Add(this.buttonImprimir);
            this.ribbonPageGroup1.ItemLinks.Add(this.buttonCancelar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 581);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(759, 22);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 157);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.pageDadosGerais;
            this.xtraTabControl1.Size = new System.Drawing.Size(759, 424);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageDadosGerais,
            this.xtraTabPage2,
            this.xtraTabPage1,
            this.xtraTabPage3,
            this.xtraTabPage4});
            // 
            // pageDadosGerais
            // 
            this.pageDadosGerais.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pageDadosGerais.Name = "pageDadosGerais";
            this.pageDadosGerais.Size = new System.Drawing.Size(757, 401);
            this.pageDadosGerais.Text = "Dados Gerais";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gridControl1);
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(757, 401);
            this.xtraTabPage2.Text = "Armazéms";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(757, 401);
            this.xtraTabPage1.Text = "Substituto";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(954, 483);
            this.xtraTabPage3.Text = "Fornecedores";
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(954, 483);
            this.xtraTabPage4.Text = "Composição";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(757, 401);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnId,
            this.gridColumnName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumnId
            // 
            this.gridColumnId.Caption = "Código";
            this.gridColumnId.Name = "gridColumnId";
            this.gridColumnId.Visible = true;
            this.gridColumnId.VisibleIndex = 0;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "Armazém";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 1;
            // 
            // FormCadastroProduto
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 603);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Font = new System.Drawing.Font("Yu Gothic UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormCadastroProduto";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FormCadastroProduto";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem buttonGravar;
        private DevExpress.XtraBars.BarButtonItem buttonImprimir;
        private DevExpress.XtraBars.BarButtonItem buttonCancelar;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage pageDadosGerais;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
    }
}