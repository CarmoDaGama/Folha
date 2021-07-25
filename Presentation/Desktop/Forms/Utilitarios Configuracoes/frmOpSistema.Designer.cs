namespace Folha.Presentation.Desktop.Separadores.Utilitarios_Configuracoes
{
    partial class frmOpSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpSistema));
            this.gradeOperacoes = new DevExpress.XtraGrid.GridControl();
            this.gridOperacoes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnSalvarFechar = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem6 = new DevExpress.XtraBars.BarEditItem();
            this.btnNovo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.btnEditar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.textEditNome = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.textEdit9 = new DevExpress.XtraEditors.TextEdit();
            this.groupControlDadosOperacao = new DevExpress.XtraEditors.GroupControl();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMStock = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboMFinanceiro = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEntidade = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtNome = new DevExpress.XtraEditors.TextEdit();
            this.txtCod = new DevExpress.XtraEditors.TextEdit();
            this.labelTipoStock = new System.Windows.Forms.Label();
            this.rtxtObs = new DevExpress.XtraEditors.MemoEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gradeOperacoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOperacoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNome.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDadosOperacao)).BeginInit();
            this.groupControlDadosOperacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMFinanceiro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEntidade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNome.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtObs.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradeOperacoes
            // 
            this.gradeOperacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradeOperacoes.Location = new System.Drawing.Point(12, 16);
            this.gradeOperacoes.MainView = this.gridOperacoes;
            this.gradeOperacoes.Name = "gradeOperacoes";
            this.gradeOperacoes.Size = new System.Drawing.Size(864, 273);
            this.gradeOperacoes.TabIndex = 100;
            this.gradeOperacoes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridOperacoes});
            // 
            // gridOperacoes
            // 
            this.gridOperacoes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridOperacoes.GridControl = this.gradeOperacoes;
            this.gridOperacoes.Name = "gridOperacoes";
            this.gridOperacoes.OptionsFind.AlwaysVisible = true;
            this.gridOperacoes.OptionsFind.FindNullPrompt = "Pesquisar... ";
            this.gridOperacoes.OptionsFind.ShowClearButton = false;
            this.gridOperacoes.OptionsFind.ShowFindButton = false;
            this.gridOperacoes.OptionsView.ShowGroupPanel = false;
            this.gridOperacoes.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridOperacoes_RowClick);
            this.gridOperacoes.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridOperacoes_RowCellClick);
            this.gridOperacoes.DoubleClick += new System.EventHandler(this.gridOperacoes_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.Caption = "Código";
            this.gridColumn1.FieldName = "codigo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 66;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Nome";
            this.gridColumn2.FieldName = "Nome";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 214;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Inventário";
            this.gridColumn3.FieldName = "MovStk";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 79;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Finanças";
            this.gridColumn4.FieldName = "MovFin";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 78;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Entidade";
            this.gridColumn5.FieldName = "Entidade";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 153;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "APP";
            this.gridColumn6.FieldName = "APP";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 70;
            // 
            // ribbon
            // 
            this.ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbon.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnSalvar,
            this.btnSalvarFechar,
            this.btnVoltar,
            this.barButtonItem4,
            this.barEditItem1,
            this.barEditItem2,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barEditItem6,
            this.btnNovo,
            this.barButtonItem8,
            this.barButtonItem9,
            this.btnEditar,
            this.barButtonItem11,
            this.btnEliminar,
            this.btnImprimir,
            this.barButtonItem17});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 22;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(888, 61);
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Caption = "Salvar";
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Id = 1;
            this.btnSalvar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvar.ImageOptions.SvgImage")));
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvar_ItemClick);
            // 
            // btnSalvarFechar
            // 
            this.btnSalvarFechar.Caption = "Salvar e Fechar";
            this.btnSalvarFechar.Enabled = false;
            this.btnSalvarFechar.Id = 2;
            this.btnSalvarFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvarFechar.ImageOptions.SvgImage")));
            this.btnSalvarFechar.Name = "btnSalvarFechar";
            this.btnSalvarFechar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSalvarFechar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvarFechar_ItemClick);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Fechar";
            this.btnVoltar.Id = 3;
            this.btnVoltar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVoltar.ImageOptions.SvgImage")));
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnVoltar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFechar_ItemClick);
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
            this.barButtonItem5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.Image")));
            this.barButtonItem5.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.LargeImage")));
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Canselar";
            this.barButtonItem6.Id = 8;
            this.barButtonItem6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.Image")));
            this.barButtonItem6.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.LargeImage")));
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
            this.btnNovo.Caption = "Novo";
            this.btnNovo.Id = 10;
            this.btnNovo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNovo.ImageOptions.SvgImage")));
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            // btnEditar
            // 
            this.btnEditar.Caption = "Editar";
            this.btnEditar.Id = 13;
            this.btnEditar.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Check_Book_48px1;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnEditar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEditar_ItemClick);
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "barButtonItem11";
            this.barButtonItem11.Id = 14;
            this.barButtonItem11.Name = "barButtonItem11";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Id = 15;
            this.btnEliminar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEliminar.ImageOptions.SvgImage")));
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Caption = "Imprimir";
            this.btnImprimir.Id = 16;
            this.btnImprimir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnImprimir.ImageOptions.SvgImage")));
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimir_ItemClick);
            // 
            // barButtonItem17
            // 
            this.barButtonItem17.Caption = "barButtonItem17";
            this.barButtonItem17.Id = 19;
            this.barButtonItem17.Name = "barButtonItem17";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalvar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalvarFechar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEditar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnImprimir);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnEliminar);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // textEditNome
            // 
            this.textEditNome.Location = new System.Drawing.Point(-202, -49);
            this.textEditNome.Name = "textEditNome";
            this.textEditNome.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditNome.Properties.Appearance.Options.UseFont = true;
            this.textEditNome.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.textEditNome.Properties.ContextImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.icons8_Name_16px;
            this.textEditNome.Size = new System.Drawing.Size(745, 22);
            this.textEditNome.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-342, -46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 63;
            this.label1.Text = "Nome:";
            // 
            // textEdit9
            // 
            this.textEdit9.Enabled = false;
            this.textEdit9.Location = new System.Drawing.Point(-238, -49);
            this.textEdit9.Name = "textEdit9";
            this.textEdit9.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit9.Properties.Appearance.Options.UseFont = true;
            this.textEdit9.Size = new System.Drawing.Size(30, 22);
            this.textEdit9.TabIndex = 92;
            // 
            // groupControlDadosOperacao
            // 
            this.groupControlDadosOperacao.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControlDadosOperacao.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(210)))), ((int)(((byte)(214)))));
            this.groupControlDadosOperacao.Appearance.Options.UseBackColor = true;
            this.groupControlDadosOperacao.Appearance.Options.UseBorderColor = true;
            this.groupControlDadosOperacao.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlDadosOperacao.AppearanceCaption.Options.UseFont = true;
            this.groupControlDadosOperacao.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlDadosOperacao.Controls.Add(this.label7);
            this.groupControlDadosOperacao.Controls.Add(this.cboMStock);
            this.groupControlDadosOperacao.Controls.Add(this.cboMFinanceiro);
            this.groupControlDadosOperacao.Controls.Add(this.label5);
            this.groupControlDadosOperacao.Controls.Add(this.label4);
            this.groupControlDadosOperacao.Controls.Add(this.label3);
            this.groupControlDadosOperacao.Controls.Add(this.cboEntidade);
            this.groupControlDadosOperacao.Controls.Add(this.txtNome);
            this.groupControlDadosOperacao.Controls.Add(this.txtCod);
            this.groupControlDadosOperacao.Controls.Add(this.textEdit9);
            this.groupControlDadosOperacao.Controls.Add(this.labelTipoStock);
            this.groupControlDadosOperacao.Controls.Add(this.label1);
            this.groupControlDadosOperacao.Controls.Add(this.textEditNome);
            this.groupControlDadosOperacao.Controls.Add(this.rtxtObs);
            this.groupControlDadosOperacao.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlDadosOperacao.Location = new System.Drawing.Point(0, 61);
            this.groupControlDadosOperacao.Name = "groupControlDadosOperacao";
            this.groupControlDadosOperacao.Size = new System.Drawing.Size(888, 271);
            this.groupControlDadosOperacao.TabIndex = 99;
            this.groupControlDadosOperacao.Visible = false;
            this.groupControlDadosOperacao.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 153;
            this.label7.Text = "Observação";
            // 
            // cboMStock
            // 
            this.cboMStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMStock.EditValue = "CREDITO";
            this.cboMStock.Location = new System.Drawing.Point(107, 75);
            this.cboMStock.Name = "cboMStock";
            this.cboMStock.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMStock.Properties.Appearance.Options.UseFont = true;
            this.cboMStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMStock.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.cboMStock.Properties.Items.AddRange(new object[] {
            "CREDITO",
            "DEBITO",
            "ISENTO"});
            this.cboMStock.Size = new System.Drawing.Size(756, 22);
            this.cboMStock.TabIndex = 109;
            // 
            // cboMFinanceiro
            // 
            this.cboMFinanceiro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMFinanceiro.EditValue = "CREDITO";
            this.cboMFinanceiro.Location = new System.Drawing.Point(107, 112);
            this.cboMFinanceiro.Name = "cboMFinanceiro";
            this.cboMFinanceiro.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMFinanceiro.Properties.Appearance.Options.UseFont = true;
            this.cboMFinanceiro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMFinanceiro.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.cboMFinanceiro.Properties.Items.AddRange(new object[] {
            "CREDITO",
            "DEBITO",
            "ISENTO"});
            this.cboMFinanceiro.Size = new System.Drawing.Size(756, 22);
            this.cboMFinanceiro.TabIndex = 108;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 107;
            this.label5.Text = "Entidade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 106;
            this.label4.Text = "Finanças";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 105;
            this.label3.Text = "Inventario";
            // 
            // cboEntidade
            // 
            this.cboEntidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEntidade.EditValue = "CLIENTE";
            this.cboEntidade.Location = new System.Drawing.Point(107, 151);
            this.cboEntidade.Name = "cboEntidade";
            this.cboEntidade.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEntidade.Properties.Appearance.Options.UseFont = true;
            this.cboEntidade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEntidade.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.cboEntidade.Properties.Items.AddRange(new object[] {
            "CLIENTE",
            "FORNECEDOR",
            "FUNCIONARIO",
            "ISENTO"});
            this.cboEntidade.Size = new System.Drawing.Size(756, 22);
            this.cboEntidade.TabIndex = 104;
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.EditValue = "";
            this.txtNome.Location = new System.Drawing.Point(217, 36);
            this.txtNome.Name = "txtNome";
            this.txtNome.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Properties.Appearance.Options.UseFont = true;
            this.txtNome.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtNome.Size = new System.Drawing.Size(646, 22);
            this.txtNome.TabIndex = 102;
            // 
            // txtCod
            // 
            this.txtCod.EditValue = "";
            this.txtCod.Enabled = false;
            this.txtCod.Location = new System.Drawing.Point(107, 36);
            this.txtCod.Name = "txtCod";
            this.txtCod.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCod.Properties.Appearance.Options.UseFont = true;
            this.txtCod.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtCod.Size = new System.Drawing.Size(104, 22);
            this.txtCod.TabIndex = 97;
            // 
            // labelTipoStock
            // 
            this.labelTipoStock.AutoSize = true;
            this.labelTipoStock.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoStock.Location = new System.Drawing.Point(21, 39);
            this.labelTipoStock.Name = "labelTipoStock";
            this.labelTipoStock.Size = new System.Drawing.Size(63, 16);
            this.labelTipoStock.TabIndex = 67;
            this.labelTipoStock.Text = "Operação";
            // 
            // rtxtObs
            // 
            this.rtxtObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtObs.Location = new System.Drawing.Point(107, 187);
            this.rtxtObs.MenuManager = this.ribbon;
            this.rtxtObs.Name = "rtxtObs";
            this.rtxtObs.Size = new System.Drawing.Size(756, 69);
            this.rtxtObs.TabIndex = 154;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.gradeOperacoes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 332);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 323);
            this.panel1.TabIndex = 102;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 101;
            this.label2.Text = "Duplo click para Editar";
            // 
            // frmOpSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 655);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupControlDadosOperacao);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmOpSistema";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operação de Sistema";
            this.Load += new System.EventHandler(this.frmOpSistema_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradeOperacoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOperacoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNome.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDadosOperacao)).EndInit();
            this.groupControlDadosOperacao.ResumeLayout(false);
            this.groupControlDadosOperacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMFinanceiro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEntidade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNome.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtObs.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gradeOperacoes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridOperacoes;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnSalvar;
        private DevExpress.XtraBars.BarButtonItem btnSalvarFechar;
        private DevExpress.XtraBars.BarButtonItem btnVoltar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarEditItem barEditItem6;
        private DevExpress.XtraBars.BarButtonItem btnNovo;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem btnEditar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private DevExpress.XtraBars.BarButtonItem barButtonItem17;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.TextEdit textEditNome;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit textEdit9;
        private DevExpress.XtraEditors.GroupControl groupControlDadosOperacao;
        private DevExpress.XtraEditors.ComboBoxEdit cboMStock;
        private DevExpress.XtraEditors.ComboBoxEdit cboMFinanceiro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.ComboBoxEdit cboEntidade;
        private DevExpress.XtraEditors.TextEdit txtNome;
        private DevExpress.XtraEditors.TextEdit txtCod;
        private System.Windows.Forms.Label labelTipoStock;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraEditors.MemoEdit rtxtObs;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel panel1;
    }
}