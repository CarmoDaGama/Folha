namespace Folha.Presentation.Desktop.Forms.Documentos
{
    partial class frmCopiarLinha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopiarLinha));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
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
            this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
            this.btnCloser = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panelSave = new System.Windows.Forms.Panel();
            this.DtInicio = new DevExpress.XtraEditors.DateEdit();
            this.cboOperacoes = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboCodigo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtCliente = new DevExpress.XtraEditors.TextEdit();
            this.panelList = new System.Windows.Forms.Panel();
            this.gridControlMovArtigos = new DevExpress.XtraGrid.GridControl();
            this.gridMovArtigos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFechar = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.panelSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOperacoes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).BeginInit();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMovArtigos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovArtigos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.barButtonItem14,
            this.barButtonItem16,
            this.barButtonItem17,
            this.btnCloser,
            this.btnActualizar});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 24;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(921, 61);
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Salvar e Fechar";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
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
            // btnNovo
            // 
            this.btnNovo.Caption = "Copiar";
            this.btnNovo.Id = 10;
            this.btnNovo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNovo.ImageOptions.SvgImage")));
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
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
            // btnCloser
            // 
            this.btnCloser.Caption = "Fechar";
            this.btnCloser.Id = 21;
            this.btnCloser.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCloser.ImageOptions.SvgImage")));
            this.btnCloser.Name = "btnCloser";
            this.btnCloser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCloser_ItemClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Caption = "Carregar";
            this.btnActualizar.Id = 23;
            this.btnActualizar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnActualizar.ImageOptions.SvgImage")));
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActualizar_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Opções";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNovo);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnActualizar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCloser);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // panelSave
            // 
            this.panelSave.BackColor = System.Drawing.Color.White;
            this.panelSave.Controls.Add(this.DtInicio);
            this.panelSave.Controls.Add(this.cboOperacoes);
            this.panelSave.Controls.Add(this.cboCodigo);
            this.panelSave.Controls.Add(this.label2);
            this.panelSave.Controls.Add(this.label4);
            this.panelSave.Controls.Add(this.txtCodCliente);
            this.panelSave.Controls.Add(this.txtCliente);
            this.panelSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSave.Location = new System.Drawing.Point(0, 61);
            this.panelSave.Name = "panelSave";
            this.panelSave.Size = new System.Drawing.Size(921, 66);
            this.panelSave.TabIndex = 125;
            // 
            // DtInicio
            // 
            this.DtInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DtInicio.EditValue = new System.DateTime(2020, 1, 23, 0, 0, 0, 0);
            this.DtInicio.Location = new System.Drawing.Point(773, 33);
            this.DtInicio.Name = "DtInicio";
            this.DtInicio.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtInicio.Properties.Appearance.Options.UseFont = true;
            this.DtInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DtInicio.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.DtInicio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DtInicio.Properties.EditFormat.FormatString = "";
            this.DtInicio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DtInicio.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.DtInicio.Size = new System.Drawing.Size(136, 22);
            this.DtInicio.TabIndex = 148;
            this.DtInicio.Visible = false;
            // 
            // cboOperacoes
            // 
            this.cboOperacoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOperacoes.Location = new System.Drawing.Point(125, 9);
            this.cboOperacoes.Name = "cboOperacoes";
            this.cboOperacoes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboOperacoes.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboOperacoes.Size = new System.Drawing.Size(642, 20);
            this.cboOperacoes.TabIndex = 124;
            this.cboOperacoes.SelectedIndexChanged += new System.EventHandler(this.cboOperacoes_SelectedIndexChanged);
            // 
            // cboCodigo
            // 
            this.cboCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCodigo.Location = new System.Drawing.Point(773, 10);
            this.cboCodigo.MenuManager = this.ribbon;
            this.cboCodigo.Name = "cboCodigo";
            this.cboCodigo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCodigo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboCodigo.Size = new System.Drawing.Size(136, 20);
            this.cboCodigo.TabIndex = 124;
            this.cboCodigo.SelectedIndexChanged += new System.EventHandler(this.cboCodigo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 123;
            this.label2.Text = "Documento / Nº";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 123;
            this.label4.Text = "Entidade";
            this.label4.Visible = false;
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Enabled = false;
            this.txtCodCliente.Location = new System.Drawing.Point(125, 33);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtCodCliente.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCliente.Properties.Appearance.Options.UseBackColor = true;
            this.txtCodCliente.Properties.Appearance.Options.UseFont = true;
            this.txtCodCliente.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtCodCliente.Properties.MaxLength = 100;
            this.txtCodCliente.Size = new System.Drawing.Size(73, 22);
            this.txtCodCliente.TabIndex = 122;
            this.txtCodCliente.Visible = false;
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.Location = new System.Drawing.Point(204, 33);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtCliente.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Properties.Appearance.Options.UseBackColor = true;
            this.txtCliente.Properties.Appearance.Options.UseFont = true;
            this.txtCliente.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtCliente.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtCliente.Properties.ContextImageOptions.SvgImage")));
            this.txtCliente.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.txtCliente.Properties.MaxLength = 100;
            this.txtCliente.Properties.ReadOnly = true;
            this.txtCliente.Properties.UseReadOnlyAppearance = false;
            this.txtCliente.Size = new System.Drawing.Size(563, 22);
            this.txtCliente.TabIndex = 122;
            this.txtCliente.Visible = false;
            this.txtCliente.Click += new System.EventHandler(this.txtCliente_Click);
            // 
            // panelList
            // 
            this.panelList.BackColor = System.Drawing.Color.White;
            this.panelList.Controls.Add(this.gridControlMovArtigos);
            this.panelList.Controls.Add(this.panel1);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(0, 127);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(921, 425);
            this.panelList.TabIndex = 126;
            // 
            // gridControlMovArtigos
            // 
            this.gridControlMovArtigos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlMovArtigos.Location = new System.Drawing.Point(12, 14);
            this.gridControlMovArtigos.MainView = this.gridMovArtigos;
            this.gridControlMovArtigos.Name = "gridControlMovArtigos";
            this.gridControlMovArtigos.Size = new System.Drawing.Size(894, 364);
            this.gridControlMovArtigos.TabIndex = 122;
            this.gridControlMovArtigos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridMovArtigos});
            // 
            // gridMovArtigos
            // 
            this.gridMovArtigos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29});
            this.gridMovArtigos.GridControl = this.gridControlMovArtigos;
            this.gridMovArtigos.Name = "gridMovArtigos";
            this.gridMovArtigos.OptionsSelection.MultiSelect = true;
            this.gridMovArtigos.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Codigo";
            this.gridColumn24.FieldName = "CODIGO";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 0;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Descrição";
            this.gridColumn25.FieldName = "NOME";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 1;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Retenção";
            this.gridColumn26.FieldName = "Retencao";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 2;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Preço";
            this.gridColumn27.FieldName = "PRECO";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowEdit = false;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 3;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Qtdade";
            this.gridColumn28.FieldName = "QTDADE";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowEdit = false;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 4;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Total";
            this.gridColumn29.DisplayFormat.FormatString = "N2";
            this.gridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn29.FieldName = "TOTAL";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowEdit = false;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 390);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(921, 35);
            this.panel1.TabIndex = 123;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(218, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Precione Ctrl para selecionar varias linhas...";
            // 
            // btnFechar
            // 
            this.btnFechar.Caption = "Fechar";
            this.btnFechar.Id = 3;
            this.btnFechar.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Voltar;
            this.btnFechar.Name = "btnFechar";
            // 
            // frmCopiarLinha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 552);
            this.ControlBox = false;
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.panelSave);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCopiarLinha";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copiar Linhas";
            this.Load += new System.EventHandler(this.frmCopiarLinha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.panelSave.ResumeLayout(false);
            this.panelSave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOperacoes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).EndInit();
            this.panelList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMovArtigos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovArtigos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
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
        private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        private DevExpress.XtraBars.BarButtonItem barButtonItem16;
        private DevExpress.XtraBars.BarButtonItem barButtonItem17;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.Panel panelSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelList;
        internal DevExpress.XtraBars.BarButtonItem btnFechar;
        internal DevExpress.XtraBars.BarButtonItem btnCloser;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.ComboBoxEdit cboCodigo;
        private DevExpress.XtraGrid.GridControl gridControlMovArtigos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridMovArtigos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraEditors.DateEdit DtInicio;
        private DevExpress.XtraEditors.TextEdit txtCliente;
        private DevExpress.XtraEditors.TextEdit txtCodCliente;
        private DevExpress.XtraEditors.ComboBoxEdit cboOperacoes;
        private DevExpress.XtraBars.BarButtonItem btnActualizar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
    }
}