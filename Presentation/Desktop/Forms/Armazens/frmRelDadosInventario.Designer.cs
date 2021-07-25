namespace Folha.Presentation.Desktop.Forms.Armazens
{
    partial class frmRelDadosInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelDadosInventario));
            this.dtFim = new DevExpress.XtraEditors.DateEdit();
            this.dtInicio = new DevExpress.XtraEditors.DateEdit();
            this.lbDtInicial = new System.Windows.Forms.Label();
            this.lbDtFinal = new System.Windows.Forms.Label();
            this.lblTipoStock = new System.Windows.Forms.Label();
            this.cboTipoStock = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblArmazem = new System.Windows.Forms.Label();
            this.cboArmazem = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblPreco = new System.Windows.Forms.Label();
            this.cboPreco = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem3 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem4 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem5 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem6 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem7 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem8 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem9 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem10 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem11 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem12 = new DevExpress.XtraBars.BarEditItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.cboFiltar = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbRelatorio = new System.Windows.Forms.Label();
            this.pnlData = new System.Windows.Forms.Panel();
            this.pnlArmazem = new System.Windows.Forms.Panel();
            this.pnlPreco = new System.Windows.Forms.Panel();
            this.pnlTipoStock = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtFim.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArmazem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPreco.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.pnlFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFiltar.Properties)).BeginInit();
            this.pnlData.SuspendLayout();
            this.pnlArmazem.SuspendLayout();
            this.pnlPreco.SuspendLayout();
            this.pnlTipoStock.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtFim
            // 
            this.dtFim.EditValue = new System.DateTime(2020, 1, 23, 0, 0, 0, 0);
            this.dtFim.Location = new System.Drawing.Point(373, 3);
            this.dtFim.Name = "dtFim";
            this.dtFim.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.dtFim.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFim.Properties.Appearance.Options.UseBackColor = true;
            this.dtFim.Properties.Appearance.Options.UseFont = true;
            this.dtFim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFim.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFim.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.dtFim.Properties.ContextImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.icons8_Calendar_16px;
            this.dtFim.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtFim.Properties.EditFormat.FormatString = "";
            this.dtFim.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFim.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.dtFim.Size = new System.Drawing.Size(174, 22);
            this.dtFim.TabIndex = 280;
            // 
            // dtInicio
            // 
            this.dtInicio.EditValue = new System.DateTime(2020, 1, 23, 0, 0, 0, 0);
            this.dtInicio.Location = new System.Drawing.Point(100, 4);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.dtInicio.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInicio.Properties.Appearance.Options.UseBackColor = true;
            this.dtInicio.Properties.Appearance.Options.UseFont = true;
            this.dtInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.dtInicio.Properties.ContextImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.icons8_Calendar_16px;
            this.dtInicio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtInicio.Properties.EditFormat.FormatString = "";
            this.dtInicio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtInicio.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.dtInicio.Size = new System.Drawing.Size(154, 22);
            this.dtInicio.TabIndex = 279;
            // 
            // lbDtInicial
            // 
            this.lbDtInicial.AutoSize = true;
            this.lbDtInicial.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDtInicial.Location = new System.Drawing.Point(6, 7);
            this.lbDtInicial.Name = "lbDtInicial";
            this.lbDtInicial.Size = new System.Drawing.Size(76, 16);
            this.lbDtInicial.TabIndex = 278;
            this.lbDtInicial.Text = "Data Inicial:";
            // 
            // lbDtFinal
            // 
            this.lbDtFinal.AutoSize = true;
            this.lbDtFinal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDtFinal.Location = new System.Drawing.Point(296, 6);
            this.lbDtFinal.Name = "lbDtFinal";
            this.lbDtFinal.Size = new System.Drawing.Size(70, 16);
            this.lbDtFinal.TabIndex = 276;
            this.lbDtFinal.Text = "Data Final:";
            // 
            // lblTipoStock
            // 
            this.lblTipoStock.AutoSize = true;
            this.lblTipoStock.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoStock.Location = new System.Drawing.Point(5, 6);
            this.lblTipoStock.Name = "lblTipoStock";
            this.lblTipoStock.Size = new System.Drawing.Size(91, 16);
            this.lblTipoStock.TabIndex = 288;
            this.lblTipoStock.Text = "Tipo de Stock:";
            // 
            // cboTipoStock
            // 
            this.cboTipoStock.Location = new System.Drawing.Point(100, 5);
            this.cboTipoStock.Name = "cboTipoStock";
            this.cboTipoStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoStock.Properties.Items.AddRange(new object[] {
            "Todos",
            "Controlo de Stock",
            "Sem Controlo de Stock"});
            this.cboTipoStock.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTipoStock.Size = new System.Drawing.Size(154, 20);
            this.cboTipoStock.TabIndex = 287;
            // 
            // lblArmazem
            // 
            this.lblArmazem.AutoSize = true;
            this.lblArmazem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArmazem.Location = new System.Drawing.Point(6, 6);
            this.lblArmazem.Name = "lblArmazem";
            this.lblArmazem.Size = new System.Drawing.Size(68, 16);
            this.lblArmazem.TabIndex = 286;
            this.lblArmazem.Text = "Armazém:";
            // 
            // cboArmazem
            // 
            this.cboArmazem.Location = new System.Drawing.Point(100, 5);
            this.cboArmazem.Name = "cboArmazem";
            this.cboArmazem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboArmazem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboArmazem.Size = new System.Drawing.Size(154, 20);
            this.cboArmazem.TabIndex = 285;
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreco.Location = new System.Drawing.Point(6, 7);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(45, 16);
            this.lblPreco.TabIndex = 284;
            this.lblPreco.Text = "Preço:";
            // 
            // cboPreco
            // 
            this.cboPreco.Location = new System.Drawing.Point(100, 5);
            this.cboPreco.Name = "cboPreco";
            this.cboPreco.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPreco.Properties.Items.AddRange(new object[] {
            "Preco1",
            "Preco2",
            "Preco3"});
            this.cboPreco.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPreco.Size = new System.Drawing.Size(154, 20);
            this.cboPreco.TabIndex = 283;
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Opções";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnImprimir);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Caption = "Previsualizar";
            this.btnImprimir.Id = 18;
            this.btnImprimir.ImageOptions.SvgImage = global::Folha.Presentation.Desktop.Properties.Resources.print5;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimir_ItemClick);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Fechar";
            this.btnVoltar.Id = 21;
            this.btnVoltar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVoltar.ImageOptions.SvgImage")));
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVoltar_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Pacientes";
            this.barSubItem1.Id = 2;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "Pacientes";
            this.barEditItem1.Edit = null;
            this.barEditItem1.EditWidth = 100;
            this.barEditItem1.Id = 3;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "Preço";
            this.barEditItem2.Edit = null;
            this.barEditItem2.EditWidth = 80;
            this.barEditItem2.Id = 4;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // barEditItem3
            // 
            this.barEditItem3.Caption = "barEditItem3";
            this.barEditItem3.Edit = null;
            this.barEditItem3.EditWidth = 100;
            this.barEditItem3.Id = 5;
            this.barEditItem3.Name = "barEditItem3";
            // 
            // barEditItem4
            // 
            this.barEditItem4.Caption = "Pacientes";
            this.barEditItem4.Edit = null;
            this.barEditItem4.EditWidth = 100;
            this.barEditItem4.Id = 6;
            this.barEditItem4.Name = "barEditItem4";
            // 
            // barEditItem5
            // 
            this.barEditItem5.Caption = "Preço";
            this.barEditItem5.Edit = null;
            this.barEditItem5.EditWidth = 80;
            this.barEditItem5.Id = 7;
            this.barEditItem5.Name = "barEditItem5";
            // 
            // barEditItem6
            // 
            this.barEditItem6.Edit = null;
            this.barEditItem6.EditWidth = 180;
            this.barEditItem6.Id = 8;
            this.barEditItem6.Name = "barEditItem6";
            // 
            // barEditItem7
            // 
            this.barEditItem7.Caption = "barEditItem7";
            this.barEditItem7.Edit = null;
            this.barEditItem7.Id = 9;
            this.barEditItem7.Name = "barEditItem7";
            // 
            // barEditItem8
            // 
            this.barEditItem8.Caption = "barEditItem8";
            this.barEditItem8.Edit = null;
            this.barEditItem8.Id = 10;
            this.barEditItem8.Name = "barEditItem8";
            // 
            // barEditItem9
            // 
            this.barEditItem9.Caption = "Preço";
            this.barEditItem9.Edit = null;
            this.barEditItem9.EditWidth = 80;
            this.barEditItem9.Id = 11;
            this.barEditItem9.Name = "barEditItem9";
            // 
            // barEditItem10
            // 
            this.barEditItem10.Caption = "Pacientes";
            this.barEditItem10.Edit = null;
            this.barEditItem10.EditWidth = 100;
            this.barEditItem10.Id = 12;
            this.barEditItem10.Name = "barEditItem10";
            // 
            // barEditItem11
            // 
            this.barEditItem11.Caption = "Familia:";
            this.barEditItem11.Edit = null;
            this.barEditItem11.EditWidth = 80;
            this.barEditItem11.Id = 13;
            this.barEditItem11.Name = "barEditItem11";
            // 
            // barEditItem12
            // 
            this.barEditItem12.Caption = "Pesquisar";
            this.barEditItem12.Edit = null;
            this.barEditItem12.EditWidth = 120;
            this.barEditItem12.Id = 14;
            this.barEditItem12.Name = "barEditItem12";
            // 
            // ribbon
            // 
            this.ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.barSubItem1,
            this.barEditItem1,
            this.barEditItem2,
            this.barEditItem3,
            this.barEditItem4,
            this.barEditItem5,
            this.barEditItem6,
            this.barEditItem7,
            this.barEditItem8,
            this.barEditItem9,
            this.barEditItem10,
            this.barEditItem11,
            this.barEditItem12,
            this.btnImprimir,
            this.btnVoltar});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 23;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(568, 31);
            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Controls.Add(this.cboFiltar);
            this.pnlFiltro.Controls.Add(this.label1);
            this.pnlFiltro.Controls.Add(this.panel3);
            this.pnlFiltro.Controls.Add(this.lbRelatorio);
            this.pnlFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltro.Location = new System.Drawing.Point(0, 31);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(568, 37);
            this.pnlFiltro.TabIndex = 291;
            // 
            // cboFiltar
            // 
            this.cboFiltar.EditValue = "Todos";
            this.cboFiltar.Location = new System.Drawing.Point(459, 3);
            this.cboFiltar.Name = "cboFiltar";
            this.cboFiltar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFiltar.Properties.Appearance.Options.UseFont = true;
            this.cboFiltar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFiltar.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.cboFiltar.Properties.Items.AddRange(new object[] {
            "Todos",
            "Filtrar"});
            this.cboFiltar.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboFiltar.Size = new System.Drawing.Size(88, 22);
            this.cboFiltar.TabIndex = 274;
            this.cboFiltar.SelectedIndexChanged += new System.EventHandler(this.cboFiltar_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(390, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 275;
            this.label1.Text = "Filtragem:";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Location = new System.Drawing.Point(3, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(542, 1);
            this.panel3.TabIndex = 277;
            // 
            // lbRelatorio
            // 
            this.lbRelatorio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRelatorio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.lbRelatorio.Location = new System.Drawing.Point(0, 8);
            this.lbRelatorio.Name = "lbRelatorio";
            this.lbRelatorio.Size = new System.Drawing.Size(374, 19);
            this.lbRelatorio.TabIndex = 281;
            this.lbRelatorio.Text = "Filtragem De Dados (Relatório)";
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.dtFim);
            this.pnlData.Controls.Add(this.lbDtFinal);
            this.pnlData.Controls.Add(this.lbDtInicial);
            this.pnlData.Controls.Add(this.dtInicio);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 68);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(568, 30);
            this.pnlData.TabIndex = 292;
            this.pnlData.Visible = false;
            // 
            // pnlArmazem
            // 
            this.pnlArmazem.Controls.Add(this.cboArmazem);
            this.pnlArmazem.Controls.Add(this.lblArmazem);
            this.pnlArmazem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlArmazem.Location = new System.Drawing.Point(0, 98);
            this.pnlArmazem.Name = "pnlArmazem";
            this.pnlArmazem.Size = new System.Drawing.Size(568, 30);
            this.pnlArmazem.TabIndex = 293;
            this.pnlArmazem.Visible = false;
            // 
            // pnlPreco
            // 
            this.pnlPreco.Controls.Add(this.cboPreco);
            this.pnlPreco.Controls.Add(this.lblPreco);
            this.pnlPreco.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPreco.Location = new System.Drawing.Point(0, 128);
            this.pnlPreco.Name = "pnlPreco";
            this.pnlPreco.Size = new System.Drawing.Size(568, 29);
            this.pnlPreco.TabIndex = 294;
            this.pnlPreco.Visible = false;
            // 
            // pnlTipoStock
            // 
            this.pnlTipoStock.Controls.Add(this.cboTipoStock);
            this.pnlTipoStock.Controls.Add(this.lblTipoStock);
            this.pnlTipoStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTipoStock.Location = new System.Drawing.Point(0, 157);
            this.pnlTipoStock.Name = "pnlTipoStock";
            this.pnlTipoStock.Size = new System.Drawing.Size(568, 32);
            this.pnlTipoStock.TabIndex = 295;
            this.pnlTipoStock.Visible = false;
            // 
            // frmRelDadosInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(568, 208);
            this.ControlBox = false;
            this.Controls.Add(this.pnlTipoStock);
            this.Controls.Add(this.pnlPreco);
            this.Controls.Add(this.pnlArmazem);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlFiltro);
            this.Controls.Add(this.ribbon);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRelDadosInventario";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtragem";
            this.Load += new System.EventHandler(this.frmRelDadosInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtFim.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArmazem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPreco.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFiltar.Properties)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.pnlArmazem.ResumeLayout(false);
            this.pnlArmazem.PerformLayout();
            this.pnlPreco.ResumeLayout(false);
            this.pnlPreco.PerformLayout();
            this.pnlTipoStock.ResumeLayout(false);
            this.pnlTipoStock.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.DateEdit dtFim;
        private DevExpress.XtraEditors.DateEdit dtInicio;
        private System.Windows.Forms.Label lbDtInicial;
        private System.Windows.Forms.Label lbDtFinal;
        private System.Windows.Forms.Label lblTipoStock;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipoStock;
        private System.Windows.Forms.Label lblArmazem;
        private DevExpress.XtraEditors.ComboBoxEdit cboArmazem;
        private System.Windows.Forms.Label lblPreco;
        private DevExpress.XtraEditors.ComboBoxEdit cboPreco;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private DevExpress.XtraBars.BarButtonItem btnVoltar;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraBars.BarEditItem barEditItem3;
        private DevExpress.XtraBars.BarEditItem barEditItem4;
        private DevExpress.XtraBars.BarEditItem barEditItem5;
        private DevExpress.XtraBars.BarEditItem barEditItem6;
        private DevExpress.XtraBars.BarEditItem barEditItem7;
        private DevExpress.XtraBars.BarEditItem barEditItem8;
        private DevExpress.XtraBars.BarEditItem barEditItem9;
        private DevExpress.XtraBars.BarEditItem barEditItem10;
        private DevExpress.XtraBars.BarEditItem barEditItem11;
        private DevExpress.XtraBars.BarEditItem barEditItem12;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private System.Windows.Forms.Panel pnlFiltro;
        private DevExpress.XtraEditors.ComboBoxEdit cboFiltar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbRelatorio;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Panel pnlArmazem;
        private System.Windows.Forms.Panel pnlPreco;
        private System.Windows.Forms.Panel pnlTipoStock;
    }
}