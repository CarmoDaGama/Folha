namespace Folha.Presentation.Desktop.Forms.Empresa
{
    partial class frmEmpresas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpresas));
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition4 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition5 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition6 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement5 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement6 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement7 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement8 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.tileViewColumn1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn2 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn3 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumn4 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNovo = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizar = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            this.btnLista = new DevExpress.XtraBars.BarButtonItem();
            this.btnGrade = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Gradempresa = new DevExpress.XtraGrid.GridControl();
            this.gridEmpresa = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Nome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NIF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Morada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationLista = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationGrade = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.gradeCartao = new DevExpress.XtraGrid.GridControl();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.tileViewColumn5 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gradempresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.navigationLista.SuspendLayout();
            this.navigationGrade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradeCartao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tileViewColumn1
            // 
            this.tileViewColumn1.Caption = "Logotipo";
            this.tileViewColumn1.FieldName = "Logotipo";
            this.tileViewColumn1.Name = "tileViewColumn1";
            this.tileViewColumn1.OptionsColumn.AllowEdit = false;
            this.tileViewColumn1.OptionsColumn.AllowFocus = false;
            this.tileViewColumn1.Visible = true;
            this.tileViewColumn1.VisibleIndex = 0;
            // 
            // tileViewColumn2
            // 
            this.tileViewColumn2.AppearanceCell.BackColor = System.Drawing.Color.Yellow;
            this.tileViewColumn2.AppearanceCell.Options.UseBackColor = true;
            this.tileViewColumn2.AppearanceHeader.BackColor = System.Drawing.Color.Fuchsia;
            this.tileViewColumn2.AppearanceHeader.Options.UseBackColor = true;
            this.tileViewColumn2.Caption = "Nome";
            this.tileViewColumn2.FieldName = "Nome";
            this.tileViewColumn2.Name = "tileViewColumn2";
            this.tileViewColumn2.Visible = true;
            this.tileViewColumn2.VisibleIndex = 1;
            // 
            // tileViewColumn3
            // 
            this.tileViewColumn3.AppearanceCell.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileViewColumn3.AppearanceCell.Options.UseFont = true;
            this.tileViewColumn3.AppearanceHeader.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileViewColumn3.AppearanceHeader.Options.UseFont = true;
            this.tileViewColumn3.Caption = "local";
            this.tileViewColumn3.FieldName = "Morada";
            this.tileViewColumn3.Name = "tileViewColumn3";
            this.tileViewColumn3.Visible = true;
            this.tileViewColumn3.VisibleIndex = 2;
            // 
            // tileViewColumn4
            // 
            this.tileViewColumn4.Caption = "codigo";
            this.tileViewColumn4.FieldName = "codigo";
            this.tileViewColumn4.Name = "tileViewColumn4";
            this.tileViewColumn4.Visible = true;
            this.tileViewColumn4.VisibleIndex = 3;
            // 
            // ribbon
            // 
            this.ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnNovo,
            this.btnEliminar,
            this.barButtonItem3,
            this.btnActualizar,
            this.barCheckItem1,
            this.btnVoltar,
            this.btnLista,
            this.btnGrade});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(880, 58);
            // 
            // btnNovo
            // 
            this.btnNovo.Caption = "Nova Empresa";
            this.btnNovo.Id = 1;
            this.btnNovo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNovo.ImageOptions.SvgImage")));
            this.btnNovo.Name = "btnNovo";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Id = 2;
            this.btnEliminar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEliminar.ImageOptions.SvgImage")));
            this.btnEliminar.Name = "btnEliminar";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Opções Avançada";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Caption = "Actualizar";
            this.btnActualizar.Id = 4;
            this.btnActualizar.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Refresh_27px;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActualizar_ItemClick);
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "barCheckItem1";
            this.barCheckItem1.Id = 5;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Voltar";
            this.btnVoltar.Id = 6;
            this.btnVoltar.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Voltar;
            this.btnVoltar.Name = "btnVoltar";
            // 
            // btnLista
            // 
            this.btnLista.Caption = "Lista";
            this.btnLista.Id = 7;
            this.btnLista.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLista.ImageOptions.SvgImage")));
            this.btnLista.Name = "btnLista";
            this.btnLista.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLista_ItemClick);
            // 
            // btnGrade
            // 
            this.btnGrade.Caption = "Grade";
            this.btnGrade.Id = 8;
            this.btnGrade.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGrade.ImageOptions.SvgImage")));
            this.btnGrade.Name = "btnGrade";
            this.btnGrade.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGrade_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNovo);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEliminar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnActualizar);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnLista);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnGrade);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // Gradempresa
            // 
            this.Gradempresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gradempresa.Location = new System.Drawing.Point(0, 0);
            this.Gradempresa.MainView = this.gridEmpresa;
            this.Gradempresa.MenuManager = this.ribbon;
            this.Gradempresa.Name = "Gradempresa";
            this.Gradempresa.Size = new System.Drawing.Size(880, 488);
            this.Gradempresa.TabIndex = 2;
            this.Gradempresa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridEmpresa});
            // 
            // gridEmpresa
            // 
            this.gridEmpresa.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.codigo,
            this.Nome,
            this.NIF,
            this.Morada});
            this.gridEmpresa.GridControl = this.Gradempresa;
            this.gridEmpresa.Name = "gridEmpresa";
            this.gridEmpresa.OptionsView.ShowGroupPanel = false;
            // 
            // codigo
            // 
            this.codigo.AppearanceCell.Options.UseTextOptions = true;
            this.codigo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.codigo.AppearanceHeader.Options.UseTextOptions = true;
            this.codigo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.codigo.Caption = "Codigo";
            this.codigo.FieldName = "codigo";
            this.codigo.Name = "codigo";
            this.codigo.Visible = true;
            this.codigo.VisibleIndex = 0;
            this.codigo.Width = 81;
            // 
            // Nome
            // 
            this.Nome.AppearanceCell.Options.UseTextOptions = true;
            this.Nome.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Nome.AppearanceHeader.Options.UseTextOptions = true;
            this.Nome.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Nome.Caption = "Empresa";
            this.Nome.FieldName = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.Visible = true;
            this.Nome.VisibleIndex = 1;
            this.Nome.Width = 259;
            // 
            // NIF
            // 
            this.NIF.AppearanceCell.Options.UseTextOptions = true;
            this.NIF.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.NIF.AppearanceHeader.Options.UseTextOptions = true;
            this.NIF.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.NIF.Caption = "Nif";
            this.NIF.FieldName = "NIF";
            this.NIF.Name = "NIF";
            this.NIF.Visible = true;
            this.NIF.VisibleIndex = 2;
            this.NIF.Width = 136;
            // 
            // Morada
            // 
            this.Morada.AppearanceCell.Options.UseTextOptions = true;
            this.Morada.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Morada.AppearanceHeader.Options.UseTextOptions = true;
            this.Morada.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Morada.Caption = "Localização";
            this.Morada.FieldName = "Morada";
            this.Morada.Name = "Morada";
            this.Morada.Visible = true;
            this.Morada.VisibleIndex = 3;
            this.Morada.Width = 386;
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.navigationLista);
            this.navigationFrame1.Controls.Add(this.navigationGrade);
            this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame1.Location = new System.Drawing.Point(0, 58);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationLista,
            this.navigationGrade});
            this.navigationFrame1.SelectedPage = this.navigationGrade;
            this.navigationFrame1.Size = new System.Drawing.Size(880, 488);
            this.navigationFrame1.TabIndex = 4;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationLista
            // 
            this.navigationLista.Controls.Add(this.Gradempresa);
            this.navigationLista.Name = "navigationLista";
            this.navigationLista.Size = new System.Drawing.Size(880, 488);
            // 
            // navigationGrade
            // 
            this.navigationGrade.Controls.Add(this.gradeCartao);
            this.navigationGrade.Name = "navigationGrade";
            this.navigationGrade.Size = new System.Drawing.Size(880, 488);
            // 
            // gradeCartao
            // 
            this.gradeCartao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradeCartao.Location = new System.Drawing.Point(0, 0);
            this.gradeCartao.MainView = this.tileView1;
            this.gradeCartao.MenuManager = this.ribbon;
            this.gradeCartao.Name = "gradeCartao";
            this.gradeCartao.Size = new System.Drawing.Size(880, 488);
            this.gradeCartao.TabIndex = 0;
            this.gradeCartao.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView1});
            // 
            // tileView1
            // 
            this.tileView1.Appearance.ItemNormal.BackColor = System.Drawing.Color.White;
            this.tileView1.Appearance.ItemNormal.BorderColor = System.Drawing.Color.Silver;
            this.tileView1.Appearance.ItemNormal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tileView1.Appearance.ItemNormal.Options.UseBackColor = true;
            this.tileView1.Appearance.ItemNormal.Options.UseBorderColor = true;
            this.tileView1.Appearance.ItemNormal.Options.UseForeColor = true;
            this.tileView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.tileView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tileViewColumn1,
            this.tileViewColumn2,
            this.tileViewColumn3,
            this.tileViewColumn4,
            this.tileViewColumn5});
            this.tileView1.GridControl = this.gradeCartao;
            this.tileView1.Name = "tileView1";
            this.tileView1.OptionsEditForm.EditFormColumnCount = 4;
            this.tileView1.OptionsTiles.IndentBetweenGroups = 26;
            this.tileView1.OptionsTiles.IndentBetweenItems = 25;
            this.tileView1.OptionsTiles.ItemPadding = new System.Windows.Forms.Padding(0);
            this.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(200, 236);
            this.tileView1.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.Kanban;
            this.tileView1.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileView1.OptionsTiles.Padding = new System.Windows.Forms.Padding(24);
            this.tileView1.OptionsTiles.RowCount = 0;
            this.tileView1.OptionsTiles.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Top;
            tableRowDefinition4.Length.Value = 201D;
            tableRowDefinition5.Length.Value = 21D;
            tableRowDefinition6.Length.Value = 18D;
            this.tileView1.TileRows.Add(tableRowDefinition4);
            this.tileView1.TileRows.Add(tableRowDefinition5);
            this.tileView1.TileRows.Add(tableRowDefinition6);
            tileViewItemElement5.Column = this.tileViewColumn1;
            tileViewItemElement5.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.fondo_oscuro_abstracto_desenfocado_1034_239;
            tileViewItemElement5.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement5.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement5.Text = "tileViewColumn1";
            tileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement6.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement6.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement6.Column = this.tileViewColumn2;
            tileViewItemElement6.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement6.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement6.RowIndex = 1;
            tileViewItemElement6.Text = "tileViewColumn2";
            tileViewItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            tileViewItemElement6.TextLocation = new System.Drawing.Point(10, -2);
            tileViewItemElement7.Column = this.tileViewColumn3;
            tileViewItemElement7.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement7.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement7.RowIndex = 2;
            tileViewItemElement7.Text = "tileViewColumn3";
            tileViewItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;
            tileViewItemElement7.TextLocation = new System.Drawing.Point(10, -3);
            tileViewItemElement8.Appearance.Normal.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement8.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement8.Column = this.tileViewColumn4;
            tileViewItemElement8.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement8.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement8.RowIndex = 1;
            tileViewItemElement8.Text = "tileViewColumn4";
            tileViewItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight;
            tileViewItemElement8.TextLocation = new System.Drawing.Point(-10, -2);
            this.tileView1.TileTemplate.Add(tileViewItemElement5);
            this.tileView1.TileTemplate.Add(tileViewItemElement6);
            this.tileView1.TileTemplate.Add(tileViewItemElement7);
            this.tileView1.TileTemplate.Add(tileViewItemElement8);
            // 
            // tileViewColumn5
            // 
            this.tileViewColumn5.Caption = "ID:";
            this.tileViewColumn5.Name = "tileViewColumn5";
            this.tileViewColumn5.Visible = true;
            this.tileViewColumn5.VisibleIndex = 4;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nif";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 136;
            // 
            // frmEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 546);
            this.Controls.Add(this.navigationFrame1);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEmpresas";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empresas";
            this.Load += new System.EventHandler(this.frmEmpresas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gradempresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.navigationLista.ResumeLayout(false);
            this.navigationGrade.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradeCartao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnNovo;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem btnActualizar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarButtonItem btnVoltar;
        private DevExpress.XtraBars.BarButtonItem btnLista;
        private DevExpress.XtraBars.BarButtonItem btnGrade;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraGrid.GridControl Gradempresa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn codigo;
        private DevExpress.XtraGrid.Columns.GridColumn Nome;
        private DevExpress.XtraGrid.Columns.GridColumn NIF;
        private DevExpress.XtraGrid.Columns.GridColumn Morada;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationLista;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationGrade;
        private DevExpress.XtraGrid.GridControl gradeCartao;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn1;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn3;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn4;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn5;
    }
}