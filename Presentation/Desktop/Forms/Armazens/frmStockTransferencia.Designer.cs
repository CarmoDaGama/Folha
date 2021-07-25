using System;

namespace Folha.Presentation.Desktop.Separadores.Armazens
{
    partial class frmStockTransferencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockTransferencia));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            this.btnBusacarProdutos = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDestino = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtdata = new DevExpress.XtraEditors.DateEdit();
            this.txtcodigo = new DevExpress.XtraEditors.TextEdit();
            this.cboOrigem = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLancar = new DevExpress.XtraEditors.SimpleButton();
            this.txtStock = new DevExpress.XtraEditors.TextEdit();
            this.txtdescricao = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuant = new DevExpress.XtraEditors.TextEdit();
            this.txtdoc = new DevExpress.XtraEditors.TextEdit();
            this.gradeTrans = new DevExpress.XtraGrid.GridControl();
            this.gridTrans = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDestino.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdata.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdata.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOrigem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdescricao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrans)).BeginInit();
            this.fluentDesignFormContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bsiRecordsCount,
            this.btnSalvar,
            this.btnEliminar,
            this.btnVoltar,
            this.btnBusacarProdutos,
            this.barButtonItem1});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 4;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl.Size = new System.Drawing.Size(880, 61);
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Caption = "Fechar a Transfêrencia";
            this.btnSalvar.Id = 17;
            this.btnSalvar.ImageOptions.ImageUri.Uri = "Edit";
            this.btnSalvar.ImageOptions.SvgImage = global::Folha.Presentation.Desktop.Properties.Resources.save;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvar_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Id = 18;
            this.btnEliminar.ImageOptions.ImageUri.Uri = "Delete";
            this.btnEliminar.ImageOptions.SvgImage = global::Folha.Presentation.Desktop.Properties.Resources.actions_trash;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Fechar";
            this.btnVoltar.Id = 1;
            this.btnVoltar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVoltar.ImageOptions.SvgImage")));
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVoltar_ItemClick);
            // 
            // btnBusacarProdutos
            // 
            this.btnBusacarProdutos.Caption = "Buscar Artigos";
            this.btnBusacarProdutos.Id = 2;
            this.btnBusacarProdutos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBusacarProdutos.ImageOptions.Image")));
            this.btnBusacarProdutos.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBusacarProdutos.ImageOptions.LargeImage")));
            this.btnBusacarProdutos.Name = "btnBusacarProdutos";
            this.btnBusacarProdutos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNovo_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Limpar";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Opções";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalvar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnBusacarProdutos);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnEliminar);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cboDestino);
            this.panel1.Controls.Add(this.txtdata);
            this.panel1.Controls.Add(this.txtcodigo);
            this.panel1.Controls.Add(this.cboOrigem);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnLancar);
            this.panel1.Controls.Add(this.txtStock);
            this.panel1.Controls.Add(this.txtdescricao);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtQuant);
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 228);
            this.panel1.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 122;
            this.label7.Text = "Artigo";
            // 
            // cboDestino
            // 
            this.cboDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cboDestino.EditValue = "";
            this.cboDestino.Location = new System.Drawing.Point(102, 81);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDestino.Properties.Appearance.Options.UseFont = true;
            this.cboDestino.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDestino.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboDestino.Size = new System.Drawing.Size(728, 22);
            this.cboDestino.TabIndex = 121;
            // 
            // txtdata
            // 
            this.txtdata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdata.EditValue = "1/23/2020 ";
            this.txtdata.Enabled = false;
            this.txtdata.Location = new System.Drawing.Point(102, 10);
            this.txtdata.Name = "txtdata";
            this.txtdata.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdata.Properties.Appearance.Options.UseFont = true;
            this.txtdata.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtdata.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtdata.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtdata.Properties.ContextImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.icons8_Calendar_16px;
            this.txtdata.Properties.DisplayFormat.FormatString = "";
            this.txtdata.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtdata.Properties.EditFormat.FormatString = "";
            this.txtdata.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtdata.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txtdata.Properties.Mask.EditMask = "T";
            this.txtdata.Size = new System.Drawing.Size(728, 22);
            this.txtdata.TabIndex = 119;
            // 
            // txtcodigo
            // 
            this.txtcodigo.Enabled = false;
            this.txtcodigo.Location = new System.Drawing.Point(102, 117);
            this.txtcodigo.MenuManager = this.ribbonControl;
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(102, 20);
            this.txtcodigo.TabIndex = 7;
            // 
            // cboOrigem
            // 
            this.cboOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cboOrigem.EditValue = "";
            this.cboOrigem.Location = new System.Drawing.Point(102, 49);
            this.cboOrigem.Name = "cboOrigem";
            this.cboOrigem.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOrigem.Properties.Appearance.Options.UseFont = true;
            this.cboOrigem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboOrigem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboOrigem.Size = new System.Drawing.Size(728, 22);
            this.cboOrigem.TabIndex = 120;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(270, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Código:";
            // 
            // btnLancar
            // 
            this.btnLancar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLancar.Location = new System.Drawing.Point(740, 188);
            this.btnLancar.Name = "btnLancar";
            this.btnLancar.Size = new System.Drawing.Size(90, 26);
            this.btnLancar.TabIndex = 6;
            this.btnLancar.Text = "Transferir";
            this.btnLancar.Click += new System.EventHandler(this.btnLancar_Click);
            this.btnLancar.Enter += new System.EventHandler(this.btnLancar_Enter);
            // 
            // txtStock
            // 
            this.txtStock.Enabled = false;
            this.txtStock.Location = new System.Drawing.Point(102, 151);
            this.txtStock.MenuManager = this.ribbonControl;
            this.txtStock.Name = "txtStock";
            this.txtStock.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txtStock.Properties.Appearance.Options.UseFont = true;
            this.txtStock.Size = new System.Drawing.Size(102, 20);
            this.txtStock.TabIndex = 9;
            // 
            // txtdescricao
            // 
            this.txtdescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdescricao.Enabled = false;
            this.txtdescricao.Location = new System.Drawing.Point(223, 117);
            this.txtdescricao.MenuManager = this.ribbonControl;
            this.txtdescricao.Name = "txtdescricao";
            this.txtdescricao.Size = new System.Drawing.Size(607, 20);
            this.txtdescricao.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Destino";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Quantidade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Origem";
            // 
            // txtQuant
            // 
            this.txtQuant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuant.Location = new System.Drawing.Point(223, 152);
            this.txtQuant.MenuManager = this.ribbonControl;
            this.txtQuant.Name = "txtQuant";
            this.txtQuant.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.txtQuant.Properties.Appearance.Options.UseFont = true;
            this.txtQuant.Properties.Mask.EditMask = "n2";
            this.txtQuant.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtQuant.Size = new System.Drawing.Size(607, 20);
            this.txtQuant.TabIndex = 11;
            // 
            // txtdoc
            // 
            this.txtdoc.Enabled = false;
            this.txtdoc.Location = new System.Drawing.Point(1001, 35);
            this.txtdoc.MenuManager = this.ribbonControl;
            this.txtdoc.Name = "txtdoc";
            this.txtdoc.Size = new System.Drawing.Size(89, 20);
            this.txtdoc.TabIndex = 122;
            this.txtdoc.Visible = false;
            // 
            // gradeTrans
            // 
            this.gradeTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradeTrans.Location = new System.Drawing.Point(17, 261);
            this.gradeTrans.MainView = this.gridTrans;
            this.gradeTrans.Name = "gradeTrans";
            this.gradeTrans.Size = new System.Drawing.Size(851, 227);
            this.gradeTrans.TabIndex = 5;
            this.gradeTrans.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridTrans});
            // 
            // gridTrans
            // 
            this.gridTrans.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridTrans.GridControl = this.gradeTrans;
            this.gridTrans.Name = "gridTrans";
            this.gridTrans.OptionsFind.AlwaysVisible = true;
            this.gridTrans.OptionsFind.FindNullPrompt = "Pesquisar...";
            this.gridTrans.OptionsFind.ShowClearButton = false;
            this.gridTrans.OptionsFind.ShowFindButton = false;
            this.gridTrans.OptionsView.ShowGroupPanel = false;
            this.gridTrans.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Código";
            this.gridColumn1.FieldName = "Codigo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 65;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Descrição";
            this.gridColumn2.FieldName = "Descricao";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 434;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Quantidade";
            this.gridColumn3.FieldName = "Quantidade";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 70;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Origem";
            this.gridColumn4.FieldName = "Origem";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 88;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Destino";
            this.gridColumn5.FieldName = "Destino";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 106;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "CodProduto";
            this.gridColumn6.FieldName = "CodProduto";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "CodDocumento";
            this.gridColumn7.FieldName = "CodDocumento";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Controls.Add(this.panel1);
            this.fluentDesignFormContainer1.Controls.Add(this.gradeTrans);
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(0, 61);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(880, 500);
            this.fluentDesignFormContainer1.TabIndex = 26;
            // 
            // frmStockTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 561);
            this.Controls.Add(this.txtdoc);
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.ribbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmStockTransferencia";
            this.Ribbon = this.ribbonControl;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferência de Artigos  ";
            this.Load += new System.EventHandler(this.frmStockTransferencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDestino.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdata.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdata.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOrigem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdescricao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrans)).EndInit();
            this.fluentDesignFormContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem btnSalvar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gradeTrans;
        private DevExpress.XtraGrid.Views.Grid.GridView gridTrans;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtQuant;
        private DevExpress.XtraEditors.TextEdit txtStock;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtcodigo;
        private DevExpress.XtraEditors.SimpleButton btnLancar;
        private DevExpress.XtraEditors.TextEdit txtdescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.DateEdit txtdata;
        private DevExpress.XtraEditors.ComboBoxEdit cboOrigem;
        private DevExpress.XtraEditors.ComboBoxEdit cboDestino;
        private DevExpress.XtraEditors.TextEdit txtdoc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraBars.BarButtonItem btnVoltar;
        private DevExpress.XtraBars.BarButtonItem btnBusacarProdutos;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}