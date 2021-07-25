namespace Folha.Presentation.Desktop.Separadores.Recursos_Humanos
{
    partial class frmFerias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFerias));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.buttonNovaFeria = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControlVendas = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnNome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPreco = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDesconto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnImposto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnArmazem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQtdade = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.buttonNovaFeria,
            this.barButtonItem2});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(931, 146);
            // 
            // buttonNovaFeria
            // 
            this.buttonNovaFeria.Caption = "Novo";
            this.buttonNovaFeria.Id = 1;
            this.buttonNovaFeria.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.buttonNovaFeria.Name = "buttonNovaFeria";
            this.buttonNovaFeria.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.buttonNovaFeria_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Eliminar";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.buttonNovaFeria);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // gridControlVendas
            // 
            this.gridControlVendas.Location = new System.Drawing.Point(0, 159);
            this.gridControlVendas.MainView = this.gridView;
            this.gridControlVendas.Name = "gridControlVendas";
            this.gridControlVendas.Size = new System.Drawing.Size(931, 480);
            this.gridControlVendas.TabIndex = 4;
            this.gridControlVendas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCodigo,
            this.gridColumnNome,
            this.gridColumnPreco,
            this.gridColumnDesconto,
            this.gridColumnImposto,
            this.gridColumnArmazem,
            this.gridColumnQtdade,
            this.gridColumnTotal});
            this.gridView.GridControl = this.gridControlVendas;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsFind.AlwaysVisible = true;
            // 
            // gridColumnCodigo
            // 
            this.gridColumnCodigo.Caption = "Código";
            this.gridColumnCodigo.FieldName = "Codigo";
            this.gridColumnCodigo.FieldNameSortGroup = "Codigo";
            this.gridColumnCodigo.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumnCodigo.Name = "gridColumnCodigo";
            this.gridColumnCodigo.Visible = true;
            this.gridColumnCodigo.VisibleIndex = 0;
            this.gridColumnCodigo.Width = 81;
            // 
            // gridColumnNome
            // 
            this.gridColumnNome.Caption = "Nome";
            this.gridColumnNome.FieldName = "Nome";
            this.gridColumnNome.FieldNameSortGroup = "Nome";
            this.gridColumnNome.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumnNome.Name = "gridColumnNome";
            this.gridColumnNome.Visible = true;
            this.gridColumnNome.VisibleIndex = 1;
            this.gridColumnNome.Width = 457;
            // 
            // gridColumnPreco
            // 
            this.gridColumnPreco.Caption = "Preço Un";
            this.gridColumnPreco.Name = "gridColumnPreco";
            this.gridColumnPreco.Visible = true;
            this.gridColumnPreco.VisibleIndex = 2;
            this.gridColumnPreco.Width = 59;
            // 
            // gridColumnDesconto
            // 
            this.gridColumnDesconto.Caption = "Desconto (%)";
            this.gridColumnDesconto.Name = "gridColumnDesconto";
            this.gridColumnDesconto.Visible = true;
            this.gridColumnDesconto.VisibleIndex = 3;
            this.gridColumnDesconto.Width = 79;
            // 
            // gridColumnImposto
            // 
            this.gridColumnImposto.Caption = "Imposto";
            this.gridColumnImposto.Name = "gridColumnImposto";
            this.gridColumnImposto.Visible = true;
            this.gridColumnImposto.VisibleIndex = 4;
            this.gridColumnImposto.Width = 48;
            // 
            // gridColumnArmazem
            // 
            this.gridColumnArmazem.Caption = "Armazem";
            this.gridColumnArmazem.Name = "gridColumnArmazem";
            this.gridColumnArmazem.Visible = true;
            this.gridColumnArmazem.VisibleIndex = 5;
            this.gridColumnArmazem.Width = 57;
            // 
            // gridColumnQtdade
            // 
            this.gridColumnQtdade.Caption = "Qtdade";
            this.gridColumnQtdade.Name = "gridColumnQtdade";
            this.gridColumnQtdade.Visible = true;
            this.gridColumnQtdade.VisibleIndex = 6;
            this.gridColumnQtdade.Width = 49;
            // 
            // gridColumnTotal
            // 
            this.gridColumnTotal.Caption = "Total";
            this.gridColumnTotal.Name = "gridColumnTotal";
            this.gridColumnTotal.Visible = true;
            this.gridColumnTotal.VisibleIndex = 7;
            this.gridColumnTotal.Width = 63;
            // 
            // frmFerias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 639);
            this.Controls.Add(this.gridControlVendas);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmFerias";
            this.Text = "FERIAS";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem buttonNovaFeria;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraGrid.GridControl gridControlVendas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNome;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPreco;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDesconto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnImposto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnArmazem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQtdade;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotal;
    }
}