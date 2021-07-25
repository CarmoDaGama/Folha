using System;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    partial class frmFacturacaoHospitalar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturacaoHospitalar));
            this.ItemCheckFacturar = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.label31 = new System.Windows.Forms.Label();
            this.cboTipoItem = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblTituloFacturacao = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.btnVerDocumento = new System.Windows.Forms.Button();
            this.btnFactura = new System.Windows.Forms.Button();
            this.btnFacturaRecibo = new System.Windows.Forms.Button();
            this.gradeDocumentos = new DevExpress.XtraGrid.GridControl();
            this.gridDocumentos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gradeItens = new DevExpress.XtraGrid.GridControl();
            this.gridItens = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.navigationTiposItem = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.pageItensSemDoc = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.pageItensFR = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.gradeItensFR = new DevExpress.XtraGrid.GridControl();
            this.gridItensFR = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CboItemComDoc = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ItemCheckComDoc = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelItens = new System.Windows.Forms.Panel();
            this.accordionControlTipoDoc = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.btnItensSemDoc = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnItensComDoc = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnHospedagem = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckFacturar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItens)).BeginInit();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationTiposItem)).BeginInit();
            this.navigationTiposItem.SuspendLayout();
            this.pageItensSemDoc.SuspendLayout();
            this.pageItensFR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradeItensFR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItensFR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboItemComDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckComDoc)).BeginInit();
            this.panelItens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControlTipoDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemCheckFacturar
            // 
            this.ItemCheckFacturar.AutoHeight = false;
            this.ItemCheckFacturar.Name = "ItemCheckFacturar";
            this.ItemCheckFacturar.CheckedChanged += new System.EventHandler(this.ItemCheckFacturar_CheckedChanged);
            this.ItemCheckFacturar.Click += new System.EventHandler(this.ItemCheckFacturar_CheckedChanged);
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label31.Location = new System.Drawing.Point(643, 41);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(105, 14);
            this.label31.TabIndex = 179;
            this.label31.Text = "Itens por Facturar";
            // 
            // cboTipoItem
            // 
            this.cboTipoItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoItem.EditValue = "Todos";
            this.cboTipoItem.Location = new System.Drawing.Point(754, 39);
            this.cboTipoItem.Name = "cboTipoItem";
            this.cboTipoItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoItem.Properties.Items.AddRange(new object[] {
            "Todos",
            "Facturados",
            "Não Facturados"});
            this.cboTipoItem.Size = new System.Drawing.Size(205, 20);
            this.cboTipoItem.TabIndex = 188;
            this.cboTipoItem.SelectedIndexChanged += new System.EventHandler(this.cboTipoItem_SelectedIndexChanged);
            // 
            // lblTituloFacturacao
            // 
            this.lblTituloFacturacao.AutoSize = true;
            this.lblTituloFacturacao.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloFacturacao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblTituloFacturacao.Location = new System.Drawing.Point(6, 297);
            this.lblTituloFacturacao.Name = "lblTituloFacturacao";
            this.lblTituloFacturacao.Size = new System.Drawing.Size(148, 19);
            this.lblTituloFacturacao.TabIndex = 180;
            this.lblTituloFacturacao.Text = "Itens De Facturação";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label29.Location = new System.Drawing.Point(3, 39);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(97, 19);
            this.label29.TabIndex = 181;
            this.label29.Text = "Documentos";
            this.label29.Click += new System.EventHandler(this.label29_Click);
            // 
            // btnVerDocumento
            // 
            this.btnVerDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVerDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerDocumento.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDocumento.ForeColor = System.Drawing.Color.White;
            this.btnVerDocumento.Location = new System.Drawing.Point(629, 518);
            this.btnVerDocumento.Name = "btnVerDocumento";
            this.btnVerDocumento.Size = new System.Drawing.Size(128, 28);
            this.btnVerDocumento.TabIndex = 187;
            this.btnVerDocumento.Text = "Ver Documento";
            this.btnVerDocumento.UseVisualStyleBackColor = false;
            this.btnVerDocumento.Click += new System.EventHandler(this.btnVerDocumento_Click);
            // 
            // btnFactura
            // 
            this.btnFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFactura.Enabled = false;
            this.btnFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFactura.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFactura.ForeColor = System.Drawing.Color.White;
            this.btnFactura.Location = new System.Drawing.Point(870, 518);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(91, 28);
            this.btnFactura.TabIndex = 186;
            this.btnFactura.Text = "Factura";
            this.btnFactura.UseVisualStyleBackColor = false;
            this.btnFactura.Click += new System.EventHandler(this.btnFactura_Click);
            // 
            // btnFacturaRecibo
            // 
            this.btnFacturaRecibo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFacturaRecibo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFacturaRecibo.Enabled = false;
            this.btnFacturaRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturaRecibo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturaRecibo.ForeColor = System.Drawing.Color.White;
            this.btnFacturaRecibo.Location = new System.Drawing.Point(758, 518);
            this.btnFacturaRecibo.Name = "btnFacturaRecibo";
            this.btnFacturaRecibo.Size = new System.Drawing.Size(111, 28);
            this.btnFacturaRecibo.TabIndex = 185;
            this.btnFacturaRecibo.Text = "Factura Recibo";
            this.btnFacturaRecibo.UseVisualStyleBackColor = false;
            this.btnFacturaRecibo.Click += new System.EventHandler(this.btnFacturaRecibo_Click);
            // 
            // gradeDocumentos
            // 
            this.gradeDocumentos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradeDocumentos.Location = new System.Drawing.Point(7, 64);
            this.gradeDocumentos.MainView = this.gridDocumentos;
            this.gradeDocumentos.Name = "gradeDocumentos";
            this.gradeDocumentos.Size = new System.Drawing.Size(952, 227);
            this.gradeDocumentos.TabIndex = 183;
            this.gradeDocumentos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridDocumentos});
            // 
            // gridDocumentos
            // 
            this.gridDocumentos.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridDocumentos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn6,
            this.gridColumn20});
            this.gridDocumentos.GridControl = this.gradeDocumentos;
            this.gridDocumentos.Name = "gridDocumentos";
            this.gridDocumentos.OptionsBehavior.Editable = false;
            this.gridDocumentos.OptionsView.ShowGroupPanel = false;
            this.gridDocumentos.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridDocumentos_RowClick);
            this.gridDocumentos.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridDocumentos_RowCellClick);
            this.gridDocumentos.DoubleClick += new System.EventHandler(this.gridDocumentos_DoubleClick);
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Código";
            this.gridColumn12.FieldName = "Codigo";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 90;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Número";
            this.gridColumn13.FieldName = "Numero";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            this.gridColumn13.Width = 225;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Tipo";
            this.gridColumn14.FieldName = "Documento";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 225;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Total";
            this.gridColumn15.DisplayFormat.FormatString = "N2";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn15.FieldName = "Total";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 3;
            this.gridColumn15.Width = 230;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Estado";
            this.gridColumn6.FieldName = "Estado";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Data";
            this.gridColumn20.DisplayFormat.FormatString = "d";
            this.gridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn20.FieldName = "Data";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 5;
            // 
            // gradeItens
            // 
            this.gradeItens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradeItens.Location = new System.Drawing.Point(0, 0);
            this.gradeItens.MainView = this.gridItens;
            this.gradeItens.Name = "gradeItens";
            this.gradeItens.Size = new System.Drawing.Size(908, 193);
            this.gradeItens.TabIndex = 184;
            this.gradeItens.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItens});
            this.gradeItens.Click += new System.EventHandler(this.gradeItens_Click);
            // 
            // gridItens
            // 
            this.gridItens.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridItens.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn17,
            this.gridColumn5,
            this.gridColumn16,
            this.gridColumn19});
            this.gridItens.GridControl = this.gradeItens;
            this.gridItens.Name = "gridItens";
            this.gridItens.OptionsSelection.MultiSelect = true;
            this.gridItens.OptionsView.ShowGroupPanel = false;
            this.gridItens.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridItens_RowClick);
            this.gridItens.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridItens_RowCellClick);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Código";
            this.gridColumn7.FieldName = "ItemId";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 80;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Tipo";
            this.gridColumn9.FieldName = "Tipo";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 100;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Data";
            this.gridColumn10.DisplayFormat.FormatString = "d";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn10.FieldName = "Data";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 93;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Imposto";
            this.gridColumn11.DisplayFormat.FormatString = "N2";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "Imposto";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 4;
            this.gridColumn11.Width = 99;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Name = "gridColumn17";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Preço";
            this.gridColumn5.DisplayFormat.FormatString = "n2";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "Preco";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 81;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Facturado";
            this.gridColumn16.FieldName = "Facturado";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 6;
            this.gridColumn16.Width = 92;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Nome";
            this.gridColumn19.FieldName = "Nome";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 1;
            this.gridColumn19.Width = 338;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel12.Controls.Add(this.label27);
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(966, 33);
            this.panel12.TabIndex = 182;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label27.Location = new System.Drawing.Point(3, 6);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(84, 19);
            this.label27.TabIndex = 157;
            this.label27.Text = "Facturação";
            // 
            // panel13
            // 
            this.panel13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel13.Location = new System.Drawing.Point(7, 26);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(952, 2);
            this.panel13.TabIndex = 13;
            // 
            // navigationTiposItem
            // 
            this.navigationTiposItem.Controls.Add(this.pageItensSemDoc);
            this.navigationTiposItem.Controls.Add(this.pageItensFR);
            this.navigationTiposItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationTiposItem.Location = new System.Drawing.Point(44, 0);
            this.navigationTiposItem.Name = "navigationTiposItem";
            this.navigationTiposItem.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.pageItensSemDoc,
            this.pageItensFR});
            this.navigationTiposItem.SelectedPage = this.pageItensSemDoc;
            this.navigationTiposItem.Size = new System.Drawing.Size(908, 193);
            this.navigationTiposItem.TabIndex = 191;
            this.navigationTiposItem.Text = "navigationFrame1";
            // 
            // pageItensSemDoc
            // 
            this.pageItensSemDoc.Caption = "pageItensSemDoc";
            this.pageItensSemDoc.Controls.Add(this.gradeItens);
            this.pageItensSemDoc.Name = "pageItensSemDoc";
            this.pageItensSemDoc.Size = new System.Drawing.Size(908, 193);
            // 
            // pageItensFR
            // 
            this.pageItensFR.Caption = "pageItensFR";
            this.pageItensFR.Controls.Add(this.gradeItensFR);
            this.pageItensFR.Name = "pageItensFR";
            this.pageItensFR.Size = new System.Drawing.Size(908, 193);
            // 
            // gradeItensFR
            // 
            this.gradeItensFR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradeItensFR.Location = new System.Drawing.Point(0, 0);
            this.gradeItensFR.MainView = this.gridItensFR;
            this.gradeItensFR.Name = "gradeItensFR";
            this.gradeItensFR.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.CboItemComDoc,
            this.ItemCheckComDoc});
            this.gradeItensFR.Size = new System.Drawing.Size(908, 193);
            this.gradeItensFR.TabIndex = 185;
            this.gradeItensFR.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItensFR});
            // 
            // gridItensFR
            // 
            this.gridItensFR.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridItensFR.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn18,
            this.gridColumn21});
            this.gridItensFR.GridControl = this.gradeItensFR;
            this.gridItensFR.Name = "gridItensFR";
            this.gridItensFR.OptionsView.ShowGroupPanel = false;
            this.gridItensFR.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridItensFR_RowClick);
            this.gridItensFR.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridItensFR_RowCellClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Código";
            this.gridColumn1.FieldName = "ItemId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 87;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tipo";
            this.gridColumn2.FieldName = "Tipo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 219;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Data";
            this.gridColumn3.DisplayFormat.FormatString = "d";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "Data";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 219;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Imposto";
            this.gridColumn4.DisplayFormat.FormatString = "N2";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "Imposto";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 197;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Preço";
            this.gridColumn18.DisplayFormat.FormatString = "n2";
            this.gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn18.FieldName = "Preco";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 5;
            this.gridColumn18.Width = 86;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Nome";
            this.gridColumn21.FieldName = "Nome";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 1;
            // 
            // CboItemComDoc
            // 
            this.CboItemComDoc.AutoHeight = false;
            this.CboItemComDoc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CboItemComDoc.Name = "CboItemComDoc";
            // 
            // ItemCheckComDoc
            // 
            this.ItemCheckComDoc.AutoHeight = false;
            this.ItemCheckComDoc.Name = "ItemCheckComDoc";
            this.ItemCheckComDoc.CheckedChanged += new System.EventHandler(this.ItemCheckComDoc_CheckedChanged);
            // 
            // panelItens
            // 
            this.panelItens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelItens.Controls.Add(this.navigationTiposItem);
            this.panelItens.Controls.Add(this.accordionControlTipoDoc);
            this.panelItens.Location = new System.Drawing.Point(7, 320);
            this.panelItens.Name = "panelItens";
            this.panelItens.Size = new System.Drawing.Size(952, 193);
            this.panelItens.TabIndex = 3;
            // 
            // accordionControlTipoDoc
            // 
            this.accordionControlTipoDoc.AllowHtmlText = false;
            this.accordionControlTipoDoc.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControlTipoDoc.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btnItensSemDoc,
            this.btnItensComDoc});
            this.accordionControlTipoDoc.ExpandElementMode = DevExpress.XtraBars.Navigation.ExpandElementMode.Multiple;
            this.accordionControlTipoDoc.Location = new System.Drawing.Point(0, 0);
            this.accordionControlTipoDoc.Name = "accordionControlTipoDoc";
            this.accordionControlTipoDoc.OptionsFooter.ActiveGroupDisplayMode = DevExpress.XtraBars.Navigation.ActiveGroupDisplayMode.GroupHeaderAndContent;
            this.accordionControlTipoDoc.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.True;
            this.accordionControlTipoDoc.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
            this.accordionControlTipoDoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.accordionControlTipoDoc.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.accordionControlTipoDoc.Size = new System.Drawing.Size(44, 193);
            this.accordionControlTipoDoc.TabIndex = 161;
            this.accordionControlTipoDoc.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // btnItensSemDoc
            // 
            this.btnItensSemDoc.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Page_Overview_3_30px;
            this.btnItensSemDoc.Name = "btnItensSemDoc";
            this.btnItensSemDoc.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnItensSemDoc.Text = "Itens Sem Documento";
            this.btnItensSemDoc.Click += new System.EventHandler(this.btnItensSemDoc_Click);
            // 
            // btnItensComDoc
            // 
            this.btnItensComDoc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnItensComDoc.ImageOptions.Image")));
            this.btnItensComDoc.Name = "btnItensComDoc";
            this.btnItensComDoc.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnItensComDoc.Text = "Itens Com Documento";
            this.btnItensComDoc.Click += new System.EventHandler(this.btnItensFR_Click);
            // 
            // btnHospedagem
            // 
            this.btnHospedagem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHospedagem.ImageOptions.Image")));
            this.btnHospedagem.Name = "btnHospedagem";
            this.btnHospedagem.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnHospedagem.Text = "Hopedagens";
            this.btnHospedagem.Visible = false;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement1.ImageOptions.Image")));
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement1.Text = "Itens Factura Recibo";
            this.accordionControlElement1.Visible = false;
            // 
            // frmFacturacaoHospitalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 552);
            this.Controls.Add(this.panelItens);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.cboTipoItem);
            this.Controls.Add(this.lblTituloFacturacao);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.btnVerDocumento);
            this.Controls.Add(this.btnFactura);
            this.Controls.Add(this.btnFacturaRecibo);
            this.Controls.Add(this.gradeDocumentos);
            this.Controls.Add(this.panel12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFacturacaoHospitalar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmFacturacaoHospitalar";
            this.Load += new System.EventHandler(this.frmFacturacaoHospitalar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckFacturar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItens)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationTiposItem)).EndInit();
            this.navigationTiposItem.ResumeLayout(false);
            this.pageItensSemDoc.ResumeLayout(false);
            this.pageItensFR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradeItensFR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItensFR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboItemComDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheckComDoc)).EndInit();
            this.panelItens.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControlTipoDoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label31;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipoItem;
        private System.Windows.Forms.Label lblTituloFacturacao;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnVerDocumento;
        private System.Windows.Forms.Button btnFactura;
        private System.Windows.Forms.Button btnFacturaRecibo;
        private DevExpress.XtraGrid.GridControl gradeDocumentos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDocumentos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.GridControl gradeItens;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItens;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel panel13;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckFacturar;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationTiposItem;
        private DevExpress.XtraBars.Navigation.NavigationPage pageItensSemDoc;
        private DevExpress.XtraBars.Navigation.NavigationPage pageItensFR;
        private DevExpress.XtraGrid.GridControl gradeItensFR;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItensFR;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private System.Windows.Forms.Panel panelItens;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControlTipoDoc;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnItensSemDoc;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnItensComDoc;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnHospedagem;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox CboItemComDoc;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheckComDoc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
    }
}