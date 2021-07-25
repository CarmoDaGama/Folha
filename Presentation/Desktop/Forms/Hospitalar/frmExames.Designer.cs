namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    partial class frmExames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExames));
            this.gradeExames = new DevExpress.XtraGrid.GridControl();
            this.gridExames = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSv = new DevExpress.XtraBars.BarButtonItem();
            this.btnSvFechar = new DevExpress.XtraBars.BarButtonItem();
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
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.bntPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSelecionar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.lbTipoResultado = new System.Windows.Forms.Label();
            this.cboTipoResultado = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtMedico = new DevExpress.XtraEditors.TextEdit();
            this.btnBusca = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gradeExames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoResultado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMedico.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gradeExames
            // 
            this.gradeExames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradeExames.Location = new System.Drawing.Point(0, 128);
            this.gradeExames.MainView = this.gridExames;
            this.gradeExames.Name = "gradeExames";
            this.gradeExames.Size = new System.Drawing.Size(552, 392);
            this.gradeExames.TabIndex = 124;
            this.gradeExames.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridExames});
            // 
            // gridExames
            // 
            this.gridExames.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCod,
            this.gridColumn3,
            this.gridColumn1});
            this.gridExames.GridControl = this.gradeExames;
            this.gridExames.Name = "gridExames";
            this.gridExames.OptionsBehavior.Editable = false;
            this.gridExames.OptionsView.ShowGroupPanel = false;
            this.gridExames.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridExames_RowClick);
            this.gridExames.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridExames_RowCellClick);
            this.gridExames.DoubleClick += new System.EventHandler(this.gridExames_DoubleClick);
            // 
            // gridCod
            // 
            this.gridCod.Caption = "Código";
            this.gridCod.FieldName = "CodExame";
            this.gridCod.Name = "gridCod";
            this.gridCod.OptionsColumn.AllowEdit = false;
            this.gridCod.OptionsColumn.AllowFocus = false;
            this.gridCod.OptionsColumn.FixedWidth = true;
            this.gridCod.Visible = true;
            this.gridCod.VisibleIndex = 0;
            this.gridCod.Width = 45;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Descricão";
            this.gridColumn3.FieldName = "Descricao";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 351;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.Caption = "Preço";
            this.gridColumn1.DisplayFormat.FormatString = "N2";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn1.FieldName = "Preco";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 105;
            // 
            // ribbon
            // 
            this.ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbon.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnSv,
            this.btnSvFechar,
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
            this.barButtonItem11,
            this.btnEliminar,
            this.bntPrint,
            this.barButtonItem14,
            this.barButtonItem16,
            this.barButtonItem17,
            this.btnSelecionar});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 21;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(552, 61);
            // 
            // btnSv
            // 
            this.btnSv.Caption = "Salvar";
            this.btnSv.Enabled = false;
            this.btnSv.Id = 1;
            this.btnSv.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSv.ImageOptions.SvgImage")));
            this.btnSv.Name = "btnSv";
            // 
            // btnSvFechar
            // 
            this.btnSvFechar.Caption = "Salvar e Fechar";
            this.btnSvFechar.Enabled = false;
            this.btnSvFechar.Id = 2;
            this.btnSvFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSvFechar.ImageOptions.SvgImage")));
            this.btnSvFechar.Name = "btnSvFechar";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Voltar";
            this.btnVoltar.Id = 3;
            this.btnVoltar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.ImageOptions.Image")));
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVoltar_ItemClick);
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
            this.btnNovo.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Addd_27px1;
            this.btnNovo.Name = "btnNovo";
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
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Id = 15;
            this.btnEliminar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEliminar.ImageOptions.SvgImage")));
            this.btnEliminar.Name = "btnEliminar";
            // 
            // bntPrint
            // 
            this.bntPrint.Caption = "Imprimir";
            this.bntPrint.Id = 16;
            this.bntPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bntPrint.ImageOptions.SvgImage")));
            this.bntPrint.Name = "bntPrint";
            this.bntPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bntPrint_ItemClick);
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
            // btnSelecionar
            // 
            this.btnSelecionar.Caption = "Selecionar";
            this.btnSelecionar.Enabled = false;
            this.btnSelecionar.Id = 20;
            this.btnSelecionar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSelecionar.ImageOptions.SvgImage")));
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelecionar_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Opções";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnSelecionar);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnNovo);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnEliminar);
            this.ribbonPageGroup3.ItemLinks.Add(this.bntPrint);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Adicionar";
            // 
            // lbTipoResultado
            // 
            this.lbTipoResultado.AutoSize = true;
            this.lbTipoResultado.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTipoResultado.Location = new System.Drawing.Point(12, 70);
            this.lbTipoResultado.Name = "lbTipoResultado";
            this.lbTipoResultado.Size = new System.Drawing.Size(116, 16);
            this.lbTipoResultado.TabIndex = 173;
            this.lbTipoResultado.Text = "Tipo de Resultado:";
            // 
            // cboTipoResultado
            // 
            this.cboTipoResultado.Enabled = false;
            this.cboTipoResultado.Location = new System.Drawing.Point(134, 67);
            this.cboTipoResultado.Name = "cboTipoResultado";
            this.cboTipoResultado.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoResultado.Properties.Appearance.Options.UseFont = true;
            this.cboTipoResultado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoResultado.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.cboTipoResultado.Properties.Items.AddRange(new object[] {
            "DESCRIÇÃO",
            "POSITIVO/NEGATIVO",
            "PERCENTAGEM"});
            this.cboTipoResultado.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTipoResultado.Size = new System.Drawing.Size(406, 22);
            this.cboTipoResultado.TabIndex = 172;
            // 
            // txtMedico
            // 
            this.txtMedico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMedico.Enabled = false;
            this.txtMedico.Location = new System.Drawing.Point(134, 97);
            this.txtMedico.Name = "txtMedico";
            this.txtMedico.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedico.Properties.Appearance.Options.UseFont = true;
            this.txtMedico.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtMedico.Size = new System.Drawing.Size(369, 22);
            this.txtMedico.TabIndex = 192;
            // 
            // btnBusca
            // 
            this.btnBusca.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBusca.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusca.Appearance.Options.UseFont = true;
            this.btnBusca.Enabled = false;
            this.btnBusca.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnBusca.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBusca.ImageOptions.SvgImage")));
            this.btnBusca.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnBusca.Location = new System.Drawing.Point(509, 97);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(31, 22);
            this.btnBusca.TabIndex = 191;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 193;
            this.label1.Text = "Medico Requesitou:";
            // 
            // frmExames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 520);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMedico);
            this.Controls.Add(this.btnBusca);
            this.Controls.Add(this.lbTipoResultado);
            this.Controls.Add(this.cboTipoResultado);
            this.Controls.Add(this.gradeExames);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmExames";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exames";
            this.Load += new System.EventHandler(this.frmExames_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradeExames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoResultado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMedico.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gradeExames;
        private DevExpress.XtraGrid.Views.Grid.GridView gridExames;
        private DevExpress.XtraGrid.Columns.GridColumn gridCod;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnSv;
        private DevExpress.XtraBars.BarButtonItem btnSvFechar;
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
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraBars.BarButtonItem bntPrint;
        private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        private DevExpress.XtraBars.BarButtonItem barButtonItem16;
        private DevExpress.XtraBars.BarButtonItem barButtonItem17;
        internal DevExpress.XtraBars.BarButtonItem btnSelecionar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private System.Windows.Forms.Label lbTipoResultado;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipoResultado;
        private DevExpress.XtraEditors.TextEdit txtMedico;
        private DevExpress.XtraEditors.SimpleButton btnBusca;
        private System.Windows.Forms.Label label1;
    }
}