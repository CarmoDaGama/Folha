namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    partial class frmVerMovimentosCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerMovimentosCaixa));
            this.gradeMovimentoCaixa = new DevExpress.XtraGrid.GridControl();
            this.gvCaixa = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtSaldo = new DevExpress.XtraEditors.TextEdit();
            this.txtSaldoTotalcx = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtfim = new DevExpress.XtraEditors.DateEdit();
            this.dtinicio = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCaixas = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelOperacao = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gradeMovimentoCaixa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCaixa)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoTotalcx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfim.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtinicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtinicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipo.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCaixas.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradeMovimentoCaixa
            // 
            this.gradeMovimentoCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradeMovimentoCaixa.Location = new System.Drawing.Point(12, 10);
            this.gradeMovimentoCaixa.MainView = this.gvCaixa;
            this.gradeMovimentoCaixa.Name = "gradeMovimentoCaixa";
            this.gradeMovimentoCaixa.Size = new System.Drawing.Size(957, 445);
            this.gradeMovimentoCaixa.TabIndex = 27;
            this.gradeMovimentoCaixa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCaixa});
            // 
            // gvCaixa
            // 
            this.gvCaixa.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gvCaixa.GridControl = this.gradeMovimentoCaixa;
            this.gvCaixa.Name = "gvCaixa";
            this.gvCaixa.OptionsBehavior.Editable = false;
            this.gvCaixa.OptionsFind.AlwaysVisible = true;
            this.gvCaixa.OptionsFind.FindNullPrompt = "Pesquisar...";
            this.gvCaixa.OptionsFind.ShowClearButton = false;
            this.gvCaixa.OptionsFind.ShowFindButton = false;
            this.gvCaixa.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Código";
            this.gridColumn1.FieldName = "Codigo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 46;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Data";
            this.gridColumn2.FieldName = "Data";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 88;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Hora";
            this.gridColumn3.FieldName = "Hora";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 50;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Descrição";
            this.gridColumn4.FieldName = "Descricao";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 117;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Entidade";
            this.gridColumn5.FieldName = "Entidade";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 107;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn6.Caption = "Valor";
            this.gridColumn6.DisplayFormat.FormatString = "N2";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn6.FieldName = "Valor";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.FixedWidth = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 70;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "Moeda";
            this.gridColumn7.FieldName = "Sigla";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.FixedWidth = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 57;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Tipo";
            this.gridColumn8.FieldName = "Tipo";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.FixedWidth = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 85;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Caixa";
            this.gridColumn9.FieldName = "Caixa";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.FixedWidth = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            this.gridColumn9.Width = 161;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "Estado";
            this.gridColumn10.FieldName = "Estado";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.FixedWidth = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 132;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.txtSaldo);
            this.panel3.Controls.Add(this.txtSaldoTotalcx);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(981, 33);
            this.panel3.TabIndex = 26;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 32);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(981, 1);
            this.panel6.TabIndex = 147;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaldo.EditValue = "0,00";
            this.txtSaldo.Enabled = false;
            this.txtSaldo.Location = new System.Drawing.Point(813, 3);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSaldo.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.txtSaldo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(187)))), ((int)(((byte)(166)))));
            this.txtSaldo.Properties.Appearance.Options.UseBackColor = true;
            this.txtSaldo.Properties.Appearance.Options.UseFont = true;
            this.txtSaldo.Properties.Appearance.Options.UseForeColor = true;
            this.txtSaldo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSaldo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtSaldo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtSaldo.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtSaldo.Size = new System.Drawing.Size(156, 24);
            this.txtSaldo.TabIndex = 139;
            // 
            // txtSaldoTotalcx
            // 
            this.txtSaldoTotalcx.EditValue = "0,00";
            this.txtSaldoTotalcx.Enabled = false;
            this.txtSaldoTotalcx.Location = new System.Drawing.Point(56, 7);
            this.txtSaldoTotalcx.Name = "txtSaldoTotalcx";
            this.txtSaldoTotalcx.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSaldoTotalcx.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.txtSaldoTotalcx.Properties.Appearance.Options.UseBackColor = true;
            this.txtSaldoTotalcx.Properties.Appearance.Options.UseFont = true;
            this.txtSaldoTotalcx.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSaldoTotalcx.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtSaldoTotalcx.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtSaldoTotalcx.Size = new System.Drawing.Size(319, 20);
            this.txtSaldoTotalcx.TabIndex = 141;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 140;
            this.label4.Text = "Saldo ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(770, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 139;
            this.label3.Text = "Total";
            // 
            // dtfim
            // 
            this.dtfim.EditValue = "23/01/2020";
            this.dtfim.Location = new System.Drawing.Point(684, 5);
            this.dtfim.Name = "dtfim";
            this.dtfim.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 8F);
            this.dtfim.Properties.Appearance.Options.UseFont = true;
            this.dtfim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtfim.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtfim.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.dtfim.Properties.ContextImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.icons8_Calendar_16px;
            this.dtfim.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.dtfim.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtfim.Properties.EditFormat.FormatString = "";
            this.dtfim.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtfim.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.dtfim.Size = new System.Drawing.Size(113, 20);
            this.dtfim.TabIndex = 137;
            // 
            // dtinicio
            // 
            this.dtinicio.EditValue = "23/01/2020";
            this.dtinicio.Location = new System.Drawing.Point(565, 5);
            this.dtinicio.Name = "dtinicio";
            this.dtinicio.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 8F);
            this.dtinicio.Properties.Appearance.Options.UseFont = true;
            this.dtinicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtinicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtinicio.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.dtinicio.Properties.ContextImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.icons8_Calendar_16px;
            this.dtinicio.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.dtinicio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtinicio.Properties.EditFormat.FormatString = "";
            this.dtinicio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtinicio.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.dtinicio.Size = new System.Drawing.Size(113, 20);
            this.dtinicio.TabIndex = 135;
            this.dtinicio.TextChanged += new System.EventHandler(this.dtinicio_TextChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(515, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 13);
            this.labelControl3.TabIndex = 134;
            this.labelControl3.Text = "Intervalo";
            // 
            // cboTipo
            // 
            this.cboTipo.EditValue = "";
            this.cboTipo.Location = new System.Drawing.Point(386, 5);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTipo.Size = new System.Drawing.Size(103, 20);
            this.cboTipo.TabIndex = 129;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.dtfim);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.dtinicio);
            this.panel2.Controls.Add(this.labelControl3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cboCaixas);
            this.panel2.Controls.Add(this.cboTipo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(981, 30);
            this.panel2.TabIndex = 25;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnActualizar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnActualizar.ImageOptions.SvgImage")));
            this.btnActualizar.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnActualizar.Location = new System.Drawing.Point(946, 0);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnActualizar.Size = new System.Drawing.Size(35, 29);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 29);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(981, 1);
            this.panel5.TabIndex = 146;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(6, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 133;
            this.label6.Text = "Caixa";
            // 
            // cboCaixas
            // 
            this.cboCaixas.EditValue = "";
            this.cboCaixas.Location = new System.Drawing.Point(56, 5);
            this.cboCaixas.Name = "cboCaixas";
            this.cboCaixas.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.cboCaixas.Properties.Appearance.Options.UseFont = true;
            this.cboCaixas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCaixas.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboCaixas.Size = new System.Drawing.Size(319, 20);
            this.cboCaixas.TabIndex = 132;
            this.cboCaixas.SelectedIndexChanged += new System.EventHandler(this.cboCaixas_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.panel1.Controls.Add(this.labelOperacao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 29);
            this.panel1.TabIndex = 24;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // labelOperacao
            // 
            this.labelOperacao.AutoSize = true;
            this.labelOperacao.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOperacao.ForeColor = System.Drawing.Color.White;
            this.labelOperacao.Location = new System.Drawing.Point(6, 6);
            this.labelOperacao.Name = "labelOperacao";
            this.labelOperacao.Size = new System.Drawing.Size(140, 14);
            this.labelOperacao.TabIndex = 16;
            this.labelOperacao.Text = "Movimentos de Caixa";
            this.labelOperacao.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gradeMovimentoCaixa);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 92);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(981, 466);
            this.panel4.TabIndex = 142;
            // 
            // frmVerMovimentosCaixa
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 558);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVerMovimentosCaixa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerMovimentosCaixa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradeMovimentoCaixa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCaixa)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoTotalcx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfim.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtinicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtinicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipo.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCaixas.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gradeMovimentoCaixa;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCaixa;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.ComboBoxEdit cboCaixas;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.DateEdit dtfim;
        private DevExpress.XtraEditors.DateEdit dtinicio;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.TextEdit txtSaldo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtSaldoTotalcx;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelOperacao;
        private System.Windows.Forms.Panel panel5;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private System.Windows.Forms.Panel panel6;
    }
}