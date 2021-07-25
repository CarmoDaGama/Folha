namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    partial class frmAtendimentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAtendimentos));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNovo = new DevExpress.XtraBars.BarButtonItem();
            this.btnFecharTurno = new DevExpress.XtraBars.BarButtonItem();
            this.btnAbrirTurno = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtfim = new DevExpress.XtraEditors.DateEdit();
            this.dtinicio = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnEntidade = new DevExpress.XtraEditors.SimpleButton();
            this.txtNomeEntidade = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodEntidade = new DevExpress.XtraEditors.TextEdit();
            this.gradeAtendimentos = new DevExpress.XtraGrid.GridControl();
            this.gridAtendimentos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtfim.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtinicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtinicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomeEntidade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodEntidade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeAtendimentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAtendimentos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.BackColor = System.Drawing.SystemColors.Control;
            this.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbonControl1.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnNovo,
            this.btnFecharTurno,
            this.btnAbrirTurno,
            this.btnImprimir,
            this.btnEliminar,
            this.btnPrint,
            this.btnVoltar});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 29);
            this.ribbonControl1.MaxItemId = 9;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(1120, 31);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnNovo
            // 
            this.btnNovo.Caption = "Novo";
            this.btnNovo.Id = 1;
            this.btnNovo.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Addd_27px;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNovo_ItemClick);
            // 
            // btnFecharTurno
            // 
            this.btnFecharTurno.Caption = "Fechar Turno";
            this.btnFecharTurno.Id = 3;
            this.btnFecharTurno.ImageOptions.SvgImage = global::Folha.Presentation.Desktop.Properties.Resources.close;
            this.btnFecharTurno.Name = "btnFecharTurno";
            // 
            // btnAbrirTurno
            // 
            this.btnAbrirTurno.Caption = "Abrir Turno";
            this.btnAbrirTurno.Id = 4;
            this.btnAbrirTurno.Name = "btnAbrirTurno";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Caption = "Imprimir";
            this.btnImprimir.Id = 5;
            this.btnImprimir.ImageOptions.SvgImage = global::Folha.Presentation.Desktop.Properties.Resources.print1;
            this.btnImprimir.Name = "btnImprimir";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Id = 6;
            this.btnEliminar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEliminar.ImageOptions.SvgImage")));
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "Imprimir";
            this.btnPrint.Id = 7;
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.Name = "btnPrint";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Voltar";
            this.btnVoltar.Id = 8;
            this.btnVoltar.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Voltar;
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVoltar_ItemClick);
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNovo);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEliminar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPrint);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.btnActualizar);
            this.panel4.Controls.Add(this.labelControl4);
            this.panel4.Controls.Add(this.dtfim);
            this.panel4.Controls.Add(this.dtinicio);
            this.panel4.Controls.Add(this.labelControl3);
            this.panel4.Controls.Add(this.btnEntidade);
            this.panel4.Controls.Add(this.txtNomeEntidade);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtCodEntidade);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1120, 30);
            this.panel4.TabIndex = 158;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnActualizar.Appearance.Options.UseBackColor = true;
            this.btnActualizar.Appearance.Options.UseBorderColor = true;
            this.btnActualizar.Appearance.Options.UseFont = true;
            this.btnActualizar.Appearance.Options.UseForeColor = true;
            this.btnActualizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.ImageOptions.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(1004, 3);
            this.btnActualizar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.btnActualizar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(110, 23);
            this.btnActualizar.TabIndex = 146;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(623, 8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(89, 16);
            this.labelControl4.TabIndex = 144;
            this.labelControl4.Text = "Data Terminar:";
            // 
            // dtfim
            // 
            this.dtfim.EditValue = new System.DateTime(2020, 1, 23, 0, 0, 0, 0);
            this.dtfim.Location = new System.Drawing.Point(718, 4);
            this.dtfim.Name = "dtfim";
            this.dtfim.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtfim.Properties.Appearance.Options.UseFont = true;
            this.dtfim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtfim.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtfim.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.dtfim.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtfim.Properties.EditFormat.FormatString = "";
            this.dtfim.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtfim.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.dtfim.Size = new System.Drawing.Size(112, 22);
            this.dtfim.TabIndex = 143;
            this.dtfim.EditValueChanged += new System.EventHandler(this.dtfim_EditValueChanged);
            // 
            // dtinicio
            // 
            this.dtinicio.EditValue = new System.DateTime(2020, 1, 23, 0, 0, 0, 0);
            this.dtinicio.Location = new System.Drawing.Point(494, 4);
            this.dtinicio.Name = "dtinicio";
            this.dtinicio.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtinicio.Properties.Appearance.Options.UseFont = true;
            this.dtinicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtinicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtinicio.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.dtinicio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtinicio.Properties.EditFormat.FormatString = "";
            this.dtinicio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtinicio.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.dtinicio.Size = new System.Drawing.Size(112, 22);
            this.dtinicio.TabIndex = 143;
            this.dtinicio.EditValueChanged += new System.EventHandler(this.dtinicio_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(418, 7);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 16);
            this.labelControl3.TabIndex = 142;
            this.labelControl3.Text = "Data inicio:";
            // 
            // btnEntidade
            // 
            this.btnEntidade.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntidade.Appearance.Options.UseFont = true;
            this.btnEntidade.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEntidade.ImageOptions.SvgImage")));
            this.btnEntidade.ImageOptions.SvgImageSize = new System.Drawing.Size(17, 17);
            this.btnEntidade.Location = new System.Drawing.Point(374, 5);
            this.btnEntidade.Name = "btnEntidade";
            this.btnEntidade.Size = new System.Drawing.Size(25, 21);
            this.btnEntidade.TabIndex = 141;
            this.btnEntidade.Click += new System.EventHandler(this.btnEntidade_Click_1);
            // 
            // txtNomeEntidade
            // 
            this.txtNomeEntidade.Enabled = false;
            this.txtNomeEntidade.Location = new System.Drawing.Point(117, 5);
            this.txtNomeEntidade.Name = "txtNomeEntidade";
            this.txtNomeEntidade.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeEntidade.Properties.Appearance.Options.UseFont = true;
            this.txtNomeEntidade.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtNomeEntidade.Size = new System.Drawing.Size(252, 22);
            this.txtNomeEntidade.TabIndex = 140;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 139;
            this.label1.Text = "Paciente:";
            // 
            // txtCodEntidade
            // 
            this.txtCodEntidade.Enabled = false;
            this.txtCodEntidade.Location = new System.Drawing.Point(74, 5);
            this.txtCodEntidade.Name = "txtCodEntidade";
            this.txtCodEntidade.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodEntidade.Properties.Appearance.Options.UseFont = true;
            this.txtCodEntidade.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtCodEntidade.Size = new System.Drawing.Size(39, 22);
            this.txtCodEntidade.TabIndex = 138;
            // 
            // gradeAtendimentos
            // 
            this.gradeAtendimentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradeAtendimentos.Location = new System.Drawing.Point(0, 90);
            this.gradeAtendimentos.MainView = this.gridAtendimentos;
            this.gradeAtendimentos.Name = "gradeAtendimentos";
            this.gradeAtendimentos.Size = new System.Drawing.Size(1120, 475);
            this.gradeAtendimentos.TabIndex = 159;
            this.gradeAtendimentos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridAtendimentos});
            // 
            // gridAtendimentos
            // 
            this.gridAtendimentos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridAtendimentos.GridControl = this.gradeAtendimentos;
            this.gridAtendimentos.Name = "gridAtendimentos";
            this.gridAtendimentos.OptionsBehavior.Editable = false;
            this.gridAtendimentos.OptionsFind.AlwaysVisible = true;
            this.gridAtendimentos.OptionsFind.FindNullPrompt = "Pesquisar...";
            this.gridAtendimentos.OptionsFind.ShowClearButton = false;
            this.gridAtendimentos.OptionsFind.ShowFindButton = false;
            this.gridAtendimentos.OptionsView.ShowGroupPanel = false;
            this.gridAtendimentos.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridAtendimentos_RowClick);
            this.gridAtendimentos.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridAtendimentos_RowCellClick);
            this.gridAtendimentos.DoubleClick += new System.EventHandler(this.gridAtendimentos_DoubleClick);
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Código";
            this.gridColumn12.FieldName = "Codigo";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.FixedWidth = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 55;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nome do Paciente";
            this.gridColumn1.FieldName = "Nome";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 502;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Fechado";
            this.gridColumn3.FieldName = "Facturado";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 105;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Total";
            this.gridColumn4.DisplayFormat.FormatString = "N2";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn4.FieldName = "Total";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 113;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Data";
            this.gridColumn5.FieldName = "Data";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 126;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Recepção";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1120, 29);
            this.panel1.TabIndex = 119;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // frmAtendimentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 565);
            this.ControlBox = false;
            this.Controls.Add(this.gradeAtendimentos);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAtendimentos";
            this.Text = "frmAtendimentos";
            this.Load += new System.EventHandler(this.frmAtendimentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtfim.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtinicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtinicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomeEntidade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodEntidade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradeAtendimentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAtendimentos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnNovo;
        private DevExpress.XtraBars.BarButtonItem btnFecharTurno;
        private DevExpress.XtraBars.BarButtonItem btnAbrirTurno;
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraGrid.GridControl gradeAtendimentos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridAtendimentos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dtinicio;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnEntidade;
        private DevExpress.XtraEditors.TextEdit txtNomeEntidade;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtCodEntidade;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraEditors.DateEdit dtfim;
        private DevExpress.XtraBars.BarButtonItem btnVoltar;
    }
}