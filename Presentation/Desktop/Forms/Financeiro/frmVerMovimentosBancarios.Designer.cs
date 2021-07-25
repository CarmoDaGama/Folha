namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    partial class frmVerMovimentosBancarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerMovimentosBancarios));
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtfim = new DevExpress.XtraEditors.DateEdit();
            this.dtinicio = new DevExpress.XtraEditors.DateEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cboTipos = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.cboContas = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.gvGradeProdutos = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.GradeProdutos = new DevExpress.XtraGrid.GridControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelOperacao = new System.Windows.Forms.Label();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtSaldoTotalcx = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtfim.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtinicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtinicio.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboContas.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGradeProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GradeProdutos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoTotalcx.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtSaldoTotalcx);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtTotal);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(936, 33);
            this.panel3.TabIndex = 30;
            // 
            // dtfim
            // 
            this.dtfim.EditValue = new System.DateTime(2020, 1, 23, 0, 0, 0, 0);
            this.dtfim.Location = new System.Drawing.Point(682, 5);
            this.dtfim.Name = "dtfim";
            this.dtfim.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtfim.Properties.Appearance.Options.UseFont = true;
            this.dtfim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtfim.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtfim.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.dtfim.Properties.ContextImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.icons8_Calendar_16px;
            this.dtfim.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtfim.Properties.EditFormat.FormatString = "";
            this.dtfim.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtfim.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.dtfim.Size = new System.Drawing.Size(113, 20);
            this.dtfim.TabIndex = 137;
            // 
            // dtinicio
            // 
            this.dtinicio.EditValue = new System.DateTime(2020, 1, 23, 0, 0, 0, 0);
            this.dtinicio.Location = new System.Drawing.Point(564, 5);
            this.dtinicio.Name = "dtinicio";
            this.dtinicio.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtinicio.Properties.Appearance.Options.UseFont = true;
            this.dtinicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtinicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtinicio.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.dtinicio.Properties.ContextImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.icons8_Calendar_16px;
            this.dtinicio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtinicio.Properties.EditFormat.FormatString = "";
            this.dtinicio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtinicio.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.dtinicio.Size = new System.Drawing.Size(112, 20);
            this.dtinicio.TabIndex = 135;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dtfim);
            this.panel2.Controls.Add(this.labelControl1);
            this.panel2.Controls.Add(this.dtinicio);
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.cboTipos);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cboContas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(936, 30);
            this.panel2.TabIndex = 29;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 29);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(936, 1);
            this.panel5.TabIndex = 147;
            // 
            // cboTipos
            // 
            this.cboTipos.EditValue = "";
            this.cboTipos.Location = new System.Drawing.Point(372, 4);
            this.cboTipos.Name = "cboTipos";
            this.cboTipos.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipos.Properties.Appearance.Options.UseFont = true;
            this.cboTipos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipos.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTipos.Size = new System.Drawing.Size(103, 20);
            this.cboTipos.TabIndex = 135;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 133;
            this.label6.Text = "Conta";
            // 
            // cboContas
            // 
            this.cboContas.AllowDrop = true;
            this.cboContas.EditValue = "";
            this.cboContas.Location = new System.Drawing.Point(47, 4);
            this.cboContas.Name = "cboContas";
            this.cboContas.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.cboContas.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboContas.Properties.Appearance.Options.UseFont = true;
            this.cboContas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboContas.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboContas.Size = new System.Drawing.Size(319, 20);
            this.cboContas.TabIndex = 132;
            this.cboContas.SelectedIndexChanged += new System.EventHandler(this.cboContas_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.GradeProdutos);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 92);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(936, 466);
            this.panel4.TabIndex = 32;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.EditValue = "0,00";
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(725, 4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(187)))), ((int)(((byte)(166)))));
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.Properties.Appearance.Options.UseForeColor = true;
            this.txtTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtTotal.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtTotal.Size = new System.Drawing.Size(205, 24);
            this.txtTotal.TabIndex = 141;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(688, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 140;
            this.label3.Text = "Total";
            // 
            // gvGradeProdutos
            // 
            this.gvGradeProdutos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gvGradeProdutos.GridControl = this.GradeProdutos;
            this.gvGradeProdutos.Name = "gvGradeProdutos";
            this.gvGradeProdutos.OptionsBehavior.Editable = false;
            this.gvGradeProdutos.OptionsFind.AlwaysVisible = true;
            this.gvGradeProdutos.OptionsFind.FindNullPrompt = "Pesquisar..";
            this.gvGradeProdutos.OptionsFind.ShowClearButton = false;
            this.gvGradeProdutos.OptionsFind.ShowFindButton = false;
            this.gvGradeProdutos.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.Caption = "Código";
            this.gridColumn1.FieldName = "Codigo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 63;
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
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 51;
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
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 50;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Descricão";
            this.gridColumn4.FieldName = "Descricao";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 143;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Entidade";
            this.gridColumn5.FieldName = "Entidade";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 140;
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
            this.gridColumn6.OptionsColumn.FixedWidth = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 66;
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
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 55;
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
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 53;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Banco";
            this.gridColumn9.FieldName = "Banco";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            this.gridColumn9.Width = 187;
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
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 77;
            // 
            // GradeProdutos
            // 
            this.GradeProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GradeProdutos.Location = new System.Drawing.Point(12, 10);
            this.GradeProdutos.MainView = this.gvGradeProdutos;
            this.GradeProdutos.Name = "GradeProdutos";
            this.GradeProdutos.Size = new System.Drawing.Size(912, 444);
            this.GradeProdutos.TabIndex = 33;
            this.GradeProdutos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGradeProdutos});
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.panel1.Controls.Add(this.labelOperacao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 29);
            this.panel1.TabIndex = 34;
            // 
            // labelOperacao
            // 
            this.labelOperacao.AutoSize = true;
            this.labelOperacao.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOperacao.ForeColor = System.Drawing.Color.White;
            this.labelOperacao.Location = new System.Drawing.Point(6, 6);
            this.labelOperacao.Name = "labelOperacao";
            this.labelOperacao.Size = new System.Drawing.Size(217, 14);
            this.labelOperacao.TabIndex = 16;
            this.labelOperacao.Text = "Movimentos de Contas Bancárias";
            this.labelOperacao.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnActualizar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnActualizar.ImageOptions.SvgImage")));
            this.btnActualizar.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnActualizar.Location = new System.Drawing.Point(901, 0);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnActualizar.Size = new System.Drawing.Size(35, 29);
            this.btnActualizar.TabIndex = 148;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(505, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 13);
            this.labelControl1.TabIndex = 149;
            this.labelControl1.Text = "Intervalo";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 32);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(936, 1);
            this.panel6.TabIndex = 148;
            // 
            // txtSaldoTotalcx
            // 
            this.txtSaldoTotalcx.EditValue = "0,00";
            this.txtSaldoTotalcx.Enabled = false;
            this.txtSaldoTotalcx.Location = new System.Drawing.Point(47, 6);
            this.txtSaldoTotalcx.Name = "txtSaldoTotalcx";
            this.txtSaldoTotalcx.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSaldoTotalcx.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.txtSaldoTotalcx.Properties.Appearance.Options.UseBackColor = true;
            this.txtSaldoTotalcx.Properties.Appearance.Options.UseFont = true;
            this.txtSaldoTotalcx.Properties.Appearance.Options.UseTextOptions = true;
            this.txtSaldoTotalcx.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtSaldoTotalcx.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtSaldoTotalcx.Size = new System.Drawing.Size(319, 20);
            this.txtSaldoTotalcx.TabIndex = 150;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 149;
            this.label4.Text = "Saldo ";
            // 
            // frmVerMovimentosBancarios
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 558);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVerMovimentosBancarios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVerMovimentosBancarios_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtfim.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtinicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtinicio.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboContas.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGradeProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GradeProdutos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoTotalcx.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.DateEdit dtfim;
        private DevExpress.XtraEditors.DateEdit dtinicio;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipos;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.ComboBoxEdit cboContas;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGradeProdutos;
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
        private DevExpress.XtraGrid.GridControl GradeProdutos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelOperacao;
        private System.Windows.Forms.Panel panel5;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel6;
        private DevExpress.XtraEditors.TextEdit txtSaldoTotalcx;
        private System.Windows.Forms.Label label4;
    }
}