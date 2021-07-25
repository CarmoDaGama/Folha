namespace Folha.Presentation.Desktop.Separadores.Gestao_Escolar
{
    partial class frmAlunos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlunos));
            this.gradeAlunos = new DevExpress.XtraGrid.GridControl();
            this.gridAlunos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNovoAluno = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizar = new DevExpress.XtraBars.BarButtonItem();
            this.btnFecharTurno = new DevExpress.XtraBars.BarButtonItem();
            this.btnAbrirTurno = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dtAno = new DevExpress.XtraEditors.TimeEdit();
            this.cboEstados = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSelecionar = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.gradeAlunos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlunos)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEstados.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gradeAlunos
            // 
            this.gradeAlunos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradeAlunos.Location = new System.Drawing.Point(0, 31);
            this.gradeAlunos.MainView = this.gridAlunos;
            this.gradeAlunos.Name = "gradeAlunos";
            this.gradeAlunos.Size = new System.Drawing.Size(684, 427);
            this.gradeAlunos.TabIndex = 37;
            this.gradeAlunos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridAlunos});
            // 
            // gridAlunos
            // 
            this.gridAlunos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridAlunos.GridControl = this.gradeAlunos;
            this.gridAlunos.Name = "gridAlunos";
            this.gridAlunos.OptionsBehavior.Editable = false;
            this.gridAlunos.OptionsFind.AlwaysVisible = true;
            this.gridAlunos.OptionsFind.FindNullPrompt = "Pesquisar...";
            this.gridAlunos.OptionsFind.ShowClearButton = false;
            this.gridAlunos.OptionsFind.ShowFindButton = false;
            this.gridAlunos.OptionsView.ShowGroupPanel = false;
            this.gridAlunos.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridAlunos_RowClick);
            this.gridAlunos.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridAlunos_RowCellClick);
            this.gridAlunos.DoubleClick += new System.EventHandler(this.gridAlunos_DoubleClick);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Código";
            this.gridColumn4.FieldName = "Codigo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 67;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nome";
            this.gridColumn1.FieldName = "Nome";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 966;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Data de nascimento";
            this.gridColumn2.FieldName = "Data";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 109;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Gênero";
            this.gridColumn3.FieldName = "Sexo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 108;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtTotal);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 458);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(684, 33);
            this.panel4.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(361, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 142;
            this.label1.Text = "Total de alunos:";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(468, 7);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtTotal.Size = new System.Drawing.Size(205, 22);
            this.txtTotal.TabIndex = 141;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(352, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 133;
            this.label6.Text = "Ano de Registro:";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbonControl1.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnNovoAluno,
            this.btnActualizar,
            this.btnFecharTurno,
            this.btnAbrirTurno,
            this.btnImprimir,
            this.btnSelecionar,
            this.btnVoltar});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 9;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(684, 31);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnNovoAluno
            // 
            this.btnNovoAluno.Caption = "Novo Aluno";
            this.btnNovoAluno.Id = 1;
            this.btnNovoAluno.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Addd_27px;
            this.btnNovoAluno.Name = "btnNovoAluno";
            this.btnNovoAluno.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNovoAluno_ItemClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Caption = "Actualizar";
            this.btnActualizar.Id = 2;
            this.btnActualizar.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Refresh_27px;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActualizar_ItemClick);
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
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSelecionar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNovoAluno);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnActualizar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // dtAno
            // 
            this.dtAno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtAno.EditValue = new System.DateTime(2020, 9, 5, 0, 0, 0, 0);
            this.dtAno.Location = new System.Drawing.Point(464, 4);
            this.dtAno.MenuManager = this.ribbonControl1;
            this.dtAno.Name = "dtAno";
            this.dtAno.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtAno.Properties.Appearance.Options.UseFont = true;
            this.dtAno.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtAno.Properties.DisplayFormat.FormatString = "yyyy";
            this.dtAno.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtAno.Properties.EditFormat.FormatString = "yyyy";
            this.dtAno.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtAno.Properties.Mask.EditMask = "yyyy";
            this.dtAno.Size = new System.Drawing.Size(86, 22);
            this.dtAno.TabIndex = 135;
            // 
            // cboEstados
            // 
            this.cboEstados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEstados.Location = new System.Drawing.Point(562, 4);
            this.cboEstados.Name = "cboEstados";
            this.cboEstados.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEstados.Properties.Items.AddRange(new object[] {
            "Activos",
            "Inactivos",
            "Todos"});
            this.cboEstados.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboEstados.Size = new System.Drawing.Size(113, 20);
            this.cboEstados.TabIndex = 137;
            this.cboEstados.SelectedIndexChanged += new System.EventHandler(this.cboEstados_SelectedIndexChanged);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Caption = "Selecionar";
            this.btnSelecionar.Id = 7;
            this.btnSelecionar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSelecionar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelecionar_ItemClick);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Voltar";
            this.btnVoltar.Id = 8;
            this.btnVoltar.ImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.Voltar;
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnVoltar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVoltar_ItemClick);
            // 
            // frmAlunos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 491);
            this.ControlBox = false;
            this.Controls.Add(this.cboEstados);
            this.Controls.Add(this.dtAno);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gradeAlunos);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.ribbonControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAlunos";
            this.ShowIcon = false;
            this.Text = "Alunos";
            this.Load += new System.EventHandler(this.frmVerAlunos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradeAlunos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlunos)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEstados.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gradeAlunos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridAlunos;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnNovoAluno;
        private DevExpress.XtraBars.BarButtonItem btnActualizar;
        private DevExpress.XtraBars.BarButtonItem btnFecharTurno;
        private DevExpress.XtraBars.BarButtonItem btnAbrirTurno;
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.TimeEdit dtAno;
        private DevExpress.XtraEditors.ComboBoxEdit cboEstados;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraBars.BarButtonItem btnSelecionar;
        private DevExpress.XtraBars.BarButtonItem btnVoltar;
    }
}