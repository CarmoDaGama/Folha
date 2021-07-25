namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    partial class frmQuartosHospilar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuartosHospilar));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnSalvarFechar = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.btnDadosGerais = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnCamas = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPageCama = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.gradeCamas = new DevExpress.XtraGrid.GridControl();
            this.gridCamas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.navigationDadosGeral = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTipoQuarto = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscaTipoQuarto = new DevExpress.XtraEditors.SimpleButton();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescricao = new DevExpress.XtraEditors.TextEdit();
            this.txtArea = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBuscaArea = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.navigationPageCama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradeCamas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCamas)).BeginInit();
            this.navigationDadosGeral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoQuarto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnSalvar,
            this.btnSalvarFechar,
            this.btnVoltar,
            this.barButtonItem4});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(553, 132);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Caption = "Salvar";
            this.btnSalvar.Id = 1;
            this.btnSalvar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvar.ImageOptions.SvgImage")));
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvar_ItemClick);
            // 
            // btnSalvarFechar
            // 
            this.btnSalvarFechar.Caption = "Salvar Fechar";
            this.btnSalvarFechar.Id = 2;
            this.btnSalvarFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvarFechar.ImageOptions.SvgImage")));
            this.btnSalvarFechar.Name = "btnSalvarFechar";
            this.btnSalvarFechar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvarFechar_ItemClick);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Voltar";
            this.btnVoltar.Id = 3;
            this.btnVoltar.ImageOptions.LargeImage = global::Folha.Presentation.Desktop.Properties.Resources.Voltar;
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVoltar_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.Name = "barButtonItem4";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalvar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalvarFechar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // accordionControl1
            // 
            this.accordionControl1.AllowHtmlText = false;
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btnDadosGerais,
            this.btnCamas});
            this.accordionControl1.ExpandElementMode = DevExpress.XtraBars.Navigation.ExpandElementMode.Multiple;
            this.accordionControl1.Location = new System.Drawing.Point(0, 132);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.OptionsFooter.ActiveGroupDisplayMode = DevExpress.XtraBars.Navigation.ActiveGroupDisplayMode.GroupHeaderAndContent;
            this.accordionControl1.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.True;
            this.accordionControl1.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
            this.accordionControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.accordionControl1.Size = new System.Drawing.Size(44, 233);
            this.accordionControl1.TabIndex = 102;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // btnDadosGerais
            // 
            this.btnDadosGerais.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl)});
            this.btnDadosGerais.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDadosGerais.ImageOptions.Image")));
            this.btnDadosGerais.Name = "btnDadosGerais";
            this.btnDadosGerais.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnDadosGerais.Text = "Dados Gerais";
            this.btnDadosGerais.Click += new System.EventHandler(this.btnDadosGerais_Click);
            // 
            // btnCamas
            // 
            this.btnCamas.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCamas.ImageOptions.SvgImage")));
            this.btnCamas.Name = "btnCamas";
            this.btnCamas.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnCamas.Text = "Camas";
            this.btnCamas.Click += new System.EventHandler(this.btnCamas_Click);
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.navigationPageCama);
            this.navigationFrame1.Controls.Add(this.navigationDadosGeral);
            this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame1.Location = new System.Drawing.Point(44, 132);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPageCama,
            this.navigationDadosGeral});
            this.navigationFrame1.SelectedPage = this.navigationDadosGeral;
            this.navigationFrame1.Size = new System.Drawing.Size(509, 233);
            this.navigationFrame1.TabIndex = 103;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPageCama
            // 
            this.navigationPageCama.Controls.Add(this.btnInserir);
            this.navigationPageCama.Controls.Add(this.btnEliminar);
            this.navigationPageCama.Controls.Add(this.gradeCamas);
            this.navigationPageCama.Controls.Add(this.panel1);
            this.navigationPageCama.Controls.Add(this.label2);
            this.navigationPageCama.Name = "navigationPageCama";
            this.navigationPageCama.Size = new System.Drawing.Size(509, 233);
            // 
            // btnInserir
            // 
            this.btnInserir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnInserir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnInserir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInserir.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserir.ForeColor = System.Drawing.Color.White;
            this.btnInserir.Location = new System.Drawing.Point(349, 205);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(71, 25);
            this.btnInserir.TabIndex = 221;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = false;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(426, 205);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(71, 25);
            this.btnEliminar.TabIndex = 220;
            this.btnEliminar.Text = "Remover";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // gradeCamas
            // 
            this.gradeCamas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.RelationName = "Level1";
            this.gradeCamas.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gradeCamas.Location = new System.Drawing.Point(12, 33);
            this.gradeCamas.MainView = this.gridCamas;
            this.gradeCamas.Name = "gradeCamas";
            this.gradeCamas.Size = new System.Drawing.Size(485, 167);
            this.gradeCamas.TabIndex = 219;
            this.gradeCamas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridCamas});
            // 
            // gridCamas
            // 
            this.gridCamas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn15,
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2});
            this.gridCamas.GridControl = this.gradeCamas;
            this.gridCamas.Name = "gridCamas";
            this.gridCamas.OptionsView.ShowGroupPanel = false;
            this.gridCamas.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridCamas_RowClick);
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Codigo";
            this.gridColumn15.FieldName = "Codigo";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            this.gridColumn15.Width = 80;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Cama";
            this.gridColumn6.FieldName = "Descricao";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 378;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tipo Cama";
            this.gridColumn1.FieldName = "Tipo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 108;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "CodCamas";
            this.gridColumn2.FieldName = "CodCamasHospitalar";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 101;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.Location = new System.Drawing.Point(12, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 1);
            this.panel1.TabIndex = 218;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(9, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 217;
            this.label2.Text = "Camas ";
            // 
            // navigationDadosGeral
            // 
            this.navigationDadosGeral.Controls.Add(this.panel3);
            this.navigationDadosGeral.Controls.Add(this.label17);
            this.navigationDadosGeral.Controls.Add(this.txtTipoQuarto);
            this.navigationDadosGeral.Controls.Add(this.label1);
            this.navigationDadosGeral.Controls.Add(this.btnBuscaTipoQuarto);
            this.navigationDadosGeral.Controls.Add(this.txtCodigo);
            this.navigationDadosGeral.Controls.Add(this.label3);
            this.navigationDadosGeral.Controls.Add(this.txtDescricao);
            this.navigationDadosGeral.Controls.Add(this.txtArea);
            this.navigationDadosGeral.Controls.Add(this.label7);
            this.navigationDadosGeral.Controls.Add(this.btnBuscaArea);
            this.navigationDadosGeral.Name = "navigationDadosGeral";
            this.navigationDadosGeral.Size = new System.Drawing.Size(509, 233);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel3.Location = new System.Drawing.Point(10, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(485, 1);
            this.panel3.TabIndex = 216;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label17.Location = new System.Drawing.Point(6, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 18);
            this.label17.TabIndex = 215;
            this.label17.Text = "Dados Gerais";
            // 
            // txtTipoQuarto
            // 
            this.txtTipoQuarto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipoQuarto.Enabled = false;
            this.txtTipoQuarto.Location = new System.Drawing.Point(123, 147);
            this.txtTipoQuarto.Name = "txtTipoQuarto";
            this.txtTipoQuarto.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoQuarto.Properties.Appearance.Options.UseFont = true;
            this.txtTipoQuarto.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtTipoQuarto.Size = new System.Drawing.Size(324, 22);
            this.txtTipoQuarto.TabIndex = 212;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 213;
            this.label1.Text = "Tipo de Quarto:";
            // 
            // btnBuscaTipoQuarto
            // 
            this.btnBuscaTipoQuarto.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBuscaTipoQuarto.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaTipoQuarto.Appearance.Options.UseFont = true;
            this.btnBuscaTipoQuarto.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnBuscaTipoQuarto.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBuscaTipoQuarto.ImageOptions.SvgImage")));
            this.btnBuscaTipoQuarto.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnBuscaTipoQuarto.Location = new System.Drawing.Point(453, 147);
            this.btnBuscaTipoQuarto.Name = "btnBuscaTipoQuarto";
            this.btnBuscaTipoQuarto.Size = new System.Drawing.Size(31, 22);
            this.btnBuscaTipoQuarto.TabIndex = 214;
            this.btnBuscaTipoQuarto.Click += new System.EventHandler(this.btnBuscaTipoQuarto_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(123, 57);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Properties.Appearance.Options.UseFont = true;
            this.txtCodigo.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtCodigo.Size = new System.Drawing.Size(82, 22);
            this.txtCodigo.TabIndex = 211;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 201;
            this.label3.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Location = new System.Drawing.Point(211, 57);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Properties.Appearance.Options.UseFont = true;
            this.txtDescricao.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtDescricao.Size = new System.Drawing.Size(273, 22);
            this.txtDescricao.TabIndex = 204;
            // 
            // txtArea
            // 
            this.txtArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArea.Enabled = false;
            this.txtArea.Location = new System.Drawing.Point(123, 100);
            this.txtArea.Name = "txtArea";
            this.txtArea.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArea.Properties.Appearance.Options.UseFont = true;
            this.txtArea.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtArea.Size = new System.Drawing.Size(324, 22);
            this.txtArea.TabIndex = 206;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 16);
            this.label7.TabIndex = 209;
            this.label7.Text = "Área Hospitalar:";
            // 
            // btnBuscaArea
            // 
            this.btnBuscaArea.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBuscaArea.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaArea.Appearance.Options.UseFont = true;
            this.btnBuscaArea.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnBuscaArea.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBuscaArea.ImageOptions.SvgImage")));
            this.btnBuscaArea.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnBuscaArea.Location = new System.Drawing.Point(453, 100);
            this.btnBuscaArea.Name = "btnBuscaArea";
            this.btnBuscaArea.Size = new System.Drawing.Size(31, 22);
            this.btnBuscaArea.TabIndex = 210;
            this.btnBuscaArea.Click += new System.EventHandler(this.btnBuscaArea_Click);
            // 
            // frmQuartosHospilar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 365);
            this.Controls.Add(this.navigationFrame1);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.ribbon);
            this.Name = "frmQuartosHospilar";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quartos Hospitalar";
            this.Load += new System.EventHandler(this.frmQuartosHospilar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.navigationPageCama.ResumeLayout(false);
            this.navigationPageCama.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradeCamas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCamas)).EndInit();
            this.navigationDadosGeral.ResumeLayout(false);
            this.navigationDadosGeral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoQuarto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnSalvar;
        private DevExpress.XtraBars.BarButtonItem btnSalvarFechar;
        private DevExpress.XtraBars.BarButtonItem btnVoltar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnDadosGerais;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnCamas;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageCama;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationDadosGeral;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtDescricao;
        private DevExpress.XtraEditors.TextEdit txtArea;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.SimpleButton btnBuscaArea;
        private DevExpress.XtraEditors.TextEdit txtTipoQuarto;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnBuscaTipoQuarto;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl gradeCamas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridCamas;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnEliminar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}