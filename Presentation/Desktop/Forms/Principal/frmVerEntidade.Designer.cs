namespace Folha.Presentation.Desktop.Separadores.Principal
{
    partial class frmVerEntidade
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
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerEntidade));
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.tileViewColumn1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn2 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn3 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.gradeEntidades = new DevExpress.XtraGrid.GridControl();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipoEntidade = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSelecionarEntity = new DevExpress.XtraBars.BarButtonItem();
            this.btnNova = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gradeEntidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoEntidade.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tileViewColumn1
            // 
            this.tileViewColumn1.Caption = "img";
            this.tileViewColumn1.FieldName = "Foto";
            this.tileViewColumn1.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.tileViewColumn1.Name = "tileViewColumn1";
            this.tileViewColumn1.OptionsColumn.AllowEdit = false;
            this.tileViewColumn1.OptionsColumn.AllowFocus = false;
            this.tileViewColumn1.Visible = true;
            this.tileViewColumn1.VisibleIndex = 0;
            // 
            // tileViewColumn2
            // 
            this.tileViewColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.tileViewColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tileViewColumn2.Caption = "Entidade";
            this.tileViewColumn2.FieldName = "Nome";
            this.tileViewColumn2.Name = "tileViewColumn2";
            this.tileViewColumn2.OptionsColumn.AllowEdit = false;
            this.tileViewColumn2.Visible = true;
            this.tileViewColumn2.VisibleIndex = 1;
            this.tileViewColumn2.Width = 823;
            // 
            // tileViewColumn3
            // 
            this.tileViewColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.tileViewColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tileViewColumn3.Caption = "Limite/Débito";
            this.tileViewColumn3.DisplayFormat.FormatString = "N2";
            this.tileViewColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.tileViewColumn3.FieldName = "Limite";
            this.tileViewColumn3.Name = "tileViewColumn3";
            this.tileViewColumn3.OptionsColumn.AllowEdit = false;
            this.tileViewColumn3.OptionsColumn.FixedWidth = true;
            this.tileViewColumn3.Visible = true;
            this.tileViewColumn3.VisibleIndex = 2;
            this.tileViewColumn3.Width = 93;
            // 
            // gradeEntidades
            // 
            this.gradeEntidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradeEntidades.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White;
            this.gradeEntidades.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.gradeEntidades.Location = new System.Drawing.Point(12, 16);
            this.gradeEntidades.MainView = this.tileView1;
            this.gradeEntidades.Name = "gradeEntidades";
            this.gradeEntidades.Size = new System.Drawing.Size(767, 462);
            this.gradeEntidades.TabIndex = 7;
            this.gradeEntidades.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView1,
            this.cardView1});
            this.gradeEntidades.Click += new System.EventHandler(this.gradeEntidades_Click);
            // 
            // tileView1
            // 
            this.tileView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tileViewColumn1,
            this.tileViewColumn2,
            this.tileViewColumn3});
            this.tileView1.GridControl = this.gradeEntidades;
            this.tileView1.Name = "tileView1";
            this.tileView1.OptionsEditForm.EditFormColumnCount = 5;
            this.tileView1.OptionsFind.AlwaysVisible = true;
            this.tileView1.OptionsFind.FindNullPrompt = "Pesquisar...";
            this.tileView1.OptionsFind.ShowClearButton = false;
            this.tileView1.OptionsFind.ShowFindButton = false;
            this.tileView1.OptionsSelection.MultiSelect = true;
            this.tileView1.OptionsTiles.IndentBetweenGroups = 88;
            this.tileView1.OptionsTiles.IndentBetweenItems = 18;
            this.tileView1.OptionsTiles.ItemPadding = new System.Windows.Forms.Padding(0);
            this.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(200, 246);
            this.tileView1.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileView1.OptionsTiles.Padding = new System.Windows.Forms.Padding(26);
            this.tileView1.OptionsTiles.RowCount = 0;
            tableRowDefinition1.Length.Value = 202D;
            tableRowDefinition2.Length.Value = 46D;
            tableRowDefinition2.PaddingTop = 5;
            this.tileView1.TileRows.Add(tableRowDefinition1);
            this.tileView1.TileRows.Add(tableRowDefinition2);
            tileViewItemElement1.Column = this.tileViewColumn1;
            tileViewItemElement1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            tileViewItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileViewItemElement1.Text = "tileViewColumn1";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.Column = this.tileViewColumn2;
            tileViewItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement2.RowIndex = 1;
            tileViewItemElement2.Text = "tileViewColumn2";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileViewItemElement2.TextLocation = new System.Drawing.Point(10, 2);
            tileViewItemElement3.Column = this.tileViewColumn3;
            tileViewItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement3.RowIndex = 1;
            tileViewItemElement3.Text = "tileViewColumn3";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
            tileViewItemElement3.TextLocation = new System.Drawing.Point(10, 20);
            this.tileView1.TileTemplate.Add(tileViewItemElement1);
            this.tileView1.TileTemplate.Add(tileViewItemElement2);
            this.tileView1.TileTemplate.Add(tileViewItemElement3);
            this.tileView1.ItemClick += new DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventHandler(this.tileView1_ItemClick);
            this.tileView1.DoubleClick += new System.EventHandler(this.tileView1_DoubleClick);
            // 
            // cardView1
            // 
            this.cardView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.cardView1.GridControl = this.gradeEntidades;
            this.cardView1.Name = "cardView1";
            this.cardView1.OptionsFind.AlwaysVisible = true;
            this.cardView1.OptionsFind.FindNullPrompt = "Pesquisar...";
            this.cardView1.OptionsFind.ShowClearButton = false;
            this.cardView1.OptionsFind.ShowFindButton = false;
            this.cardView1.OptionsSelection.MultiSelect = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "Foto";
            this.gridColumn2.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn3.Caption = "Entidade";
            this.gridColumn3.FieldName = "Nome";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 823;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn4.Caption = "Limite/Débito";
            this.gridColumn4.DisplayFormat.FormatString = "N2";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "Limite";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 93;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 29);
            this.panel1.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-14, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Entidades\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboTipoEntidade
            // 
            this.cboTipoEntidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoEntidade.Location = new System.Drawing.Point(587, 29);
            this.cboTipoEntidade.Name = "cboTipoEntidade";
            this.cboTipoEntidade.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboTipoEntidade.Properties.Appearance.Options.UseFont = true;
            this.cboTipoEntidade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoEntidade.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.cboTipoEntidade.Properties.Items.AddRange(new object[] {
            "Todos",
            "Pessoa Física",
            "Pessoa Juridica"});
            this.cboTipoEntidade.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTipoEntidade.Size = new System.Drawing.Size(174, 20);
            this.cboTipoEntidade.TabIndex = 91;
            this.cboTipoEntidade.SelectedIndexChanged += new System.EventHandler(this.cboTipoEntidade_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.ribbonControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(791, 31);
            this.panel2.TabIndex = 49;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbonControl1.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnSelecionarEntity,
            this.btnNova,
            this.btnDelete,
            this.btnImprimir,
            this.barButtonItem1,
            this.barButtonItem2});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(791, 31);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnSelecionarEntity
            // 
            this.btnSelecionarEntity.Caption = "Adicionar";
            this.btnSelecionarEntity.Id = 1;
            this.btnSelecionarEntity.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSelecionarEntity.ImageOptions.SvgImage")));
            this.btnSelecionarEntity.Name = "btnSelecionarEntity";
            this.btnSelecionarEntity.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSelecionarEntity.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelecionarEntity_ItemClick);
            // 
            // btnNova
            // 
            this.btnNova.Caption = "Criar";
            this.btnNova.Id = 2;
            this.btnNova.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNova.ImageOptions.SvgImage")));
            this.btnNova.Name = "btnNova";
            this.btnNova.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNova_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Eliminar";
            this.btnDelete.Id = 4;
            this.btnDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDelete.ImageOptions.SvgImage")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Caption = "Imprimir";
            this.btnImprimir.Id = 5;
            this.btnImprimir.ImageOptions.SvgImage = global::Folha.Presentation.Desktop.Properties.Resources.print1;
            this.btnImprimir.Name = "btnImprimir";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Modo Lista";
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Modo Cartão";
            this.barButtonItem2.Id = 9;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSelecionarEntity);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNova);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cboTipoEntidade);
            this.panel3.Controls.Add(this.gradeEntidades);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(791, 490);
            this.panel3.TabIndex = 52;
            // 
            // frmVerEntidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 550);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVerEntidade";
            this.Text = "FormVerEntidade";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerEntidade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradeEntidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoEntidade.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gradeEntidades;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipoEntidade;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnSelecionarEntity;
        private DevExpress.XtraBars.BarButtonItem btnNova;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn1;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn2;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
    }
}