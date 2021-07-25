namespace Folha.Presentation.Desktop.Forms.Financeiro
{
    partial class frmReceberPagamentos
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
            this.gridPagamentos = new DevExpress.XtraGrid.GridControl();
            this.gridViewPagamentos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesc = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.txtCodEntidade = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEntidade = new DevExpress.XtraEditors.TextEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.cboMoedas = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtDesconto = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValorEntrego = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConcluir = new DevExpress.XtraEditors.SimpleButton();
            this.txtTroco = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridPagamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPagamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodEntidade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntidade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoedas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesconto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorEntrego.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTroco.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPagamentos
            // 
            this.gridPagamentos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gridPagamentos.Location = new System.Drawing.Point(12, 122);
            this.gridPagamentos.MainView = this.gridViewPagamentos;
            this.gridPagamentos.Name = "gridPagamentos";
            this.gridPagamentos.Size = new System.Drawing.Size(702, 145);
            this.gridPagamentos.TabIndex = 6;
            this.gridPagamentos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPagamentos});
            // 
            // gridViewPagamentos
            // 
            this.gridViewPagamentos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridViewPagamentos.GridControl = this.gridPagamentos;
            this.gridViewPagamentos.Name = "gridViewPagamentos";
            this.gridViewPagamentos.OptionsBehavior.Editable = false;
            this.gridViewPagamentos.OptionsView.ShowGroupPanel = false;
            this.gridViewPagamentos.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridViewPagamentos_RowCellClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nº";
            this.gridColumn1.FieldName = "codigo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 53;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Forma";
            this.gridColumn2.FieldName = "descricao";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 525;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Valor";
            this.gridColumn3.DisplayFormat.FormatString = "N3";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "Valor";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 170;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.txtDesc);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.txtTotal);
            this.panelControl1.Controls.Add(this.txtCodEntidade);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.txtEntidade);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(753, 116);
            this.panelControl1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 14);
            this.label4.TabIndex = 126;
            this.label4.Text = "Ordem";
            // 
            // txtDesc
            // 
            this.txtDesc.Enabled = false;
            this.txtDesc.Location = new System.Drawing.Point(98, 78);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtDesc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Properties.Appearance.Options.UseBackColor = true;
            this.txtDesc.Properties.Appearance.Options.UseFont = true;
            this.txtDesc.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtDesc.Size = new System.Drawing.Size(618, 20);
            this.txtDesc.TabIndex = 125;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 124;
            this.label3.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.EditValue = "0,000";
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(98, 45);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Properties.Appearance.Options.UseBackColor = true;
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(618, 24);
            this.txtTotal.TabIndex = 100;
            // 
            // txtCodEntidade
            // 
            this.txtCodEntidade.Enabled = false;
            this.txtCodEntidade.Location = new System.Drawing.Point(98, 13);
            this.txtCodEntidade.Name = "txtCodEntidade";
            this.txtCodEntidade.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtCodEntidade.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodEntidade.Properties.Appearance.Options.UseBackColor = true;
            this.txtCodEntidade.Properties.Appearance.Options.UseFont = true;
            this.txtCodEntidade.Size = new System.Drawing.Size(72, 20);
            this.txtCodEntidade.TabIndex = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 97;
            this.label1.Text = "Entidade";
            // 
            // txtEntidade
            // 
            this.txtEntidade.Enabled = false;
            this.txtEntidade.Location = new System.Drawing.Point(176, 13);
            this.txtEntidade.Name = "txtEntidade";
            this.txtEntidade.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtEntidade.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntidade.Properties.Appearance.Options.UseBackColor = true;
            this.txtEntidade.Properties.Appearance.Options.UseFont = true;
            this.txtEntidade.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtEntidade.Size = new System.Drawing.Size(540, 20);
            this.txtEntidade.TabIndex = 92;
            this.txtEntidade.Click += new System.EventHandler(this.txtEntidade_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(530, 113);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 32);
            this.btnClose.TabIndex = 102;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboMoedas
            // 
            this.cboMoedas.EditValue = "AKZ";
            this.cboMoedas.Enabled = false;
            this.cboMoedas.Location = new System.Drawing.Point(64, 119);
            this.cboMoedas.Name = "cboMoedas";
            this.cboMoedas.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoedas.Properties.Appearance.Options.UseFont = true;
            this.cboMoedas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoedas.Properties.Items.AddRange(new object[] {
            "AKZ",
            "USD"});
            this.cboMoedas.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboMoedas.Size = new System.Drawing.Size(113, 22);
            this.cboMoedas.TabIndex = 8;
            this.cboMoedas.SelectedIndexChanged += new System.EventHandler(this.cboMoedas_SelectedIndexChanged);
            // 
            // txtDesconto
            // 
            this.txtDesconto.EditValue = "0,000";
            this.txtDesconto.Enabled = false;
            this.txtDesconto.Location = new System.Drawing.Point(520, 65);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesconto.Properties.Appearance.Options.UseFont = true;
            this.txtDesconto.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDesconto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDesconto.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtDesconto.Size = new System.Drawing.Size(165, 24);
            this.txtDesconto.TabIndex = 104;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 104;
            this.label2.Text = "Moeda";
            // 
            // txtValorEntrego
            // 
            this.txtValorEntrego.EditValue = "0,000";
            this.txtValorEntrego.Enabled = false;
            this.txtValorEntrego.Location = new System.Drawing.Point(131, 30);
            this.txtValorEntrego.Name = "txtValorEntrego";
            this.txtValorEntrego.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorEntrego.Properties.Appearance.Options.UseFont = true;
            this.txtValorEntrego.Properties.Appearance.Options.UseTextOptions = true;
            this.txtValorEntrego.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtValorEntrego.Size = new System.Drawing.Size(554, 24);
            this.txtValorEntrego.TabIndex = 104;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 14);
            this.label5.TabIndex = 104;
            this.label5.Text = "Valor Pago";
            // 
            // btnConcluir
            // 
            this.btnConcluir.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.btnConcluir.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConcluir.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnConcluir.Appearance.Options.UseBackColor = true;
            this.btnConcluir.Appearance.Options.UseFont = true;
            this.btnConcluir.Appearance.Options.UseForeColor = true;
            this.btnConcluir.Enabled = false;
            this.btnConcluir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnConcluir.Location = new System.Drawing.Point(578, 113);
            this.btnConcluir.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.btnConcluir.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(107, 31);
            this.btnConcluir.TabIndex = 123;
            this.btnConcluir.Text = "Concluir";
            this.btnConcluir.Click += new System.EventHandler(this.btnConcluir_Click);
            // 
            // txtTroco
            // 
            this.txtTroco.EditValue = "0,000";
            this.txtTroco.Enabled = false;
            this.txtTroco.Location = new System.Drawing.Point(131, 64);
            this.txtTroco.Name = "txtTroco";
            this.txtTroco.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTroco.Properties.Appearance.Options.UseFont = true;
            this.txtTroco.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTroco.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTroco.Size = new System.Drawing.Size(383, 24);
            this.txtTroco.TabIndex = 104;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 14);
            this.label6.TabIndex = 104;
            this.label6.Text = "Troco/ Desconto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtValorEntrego);
            this.groupBox1.Controls.Add(this.cboMoedas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnConcluir);
            this.groupBox1.Controls.Add(this.txtDesconto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTroco);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 159);
            this.groupBox1.TabIndex = 125;
            this.groupBox1.TabStop = false;
            // 
            // frmReceberPagamentos
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 460);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridPagamentos);
            this.Controls.Add(this.panelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReceberPagamentos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receber Pagamentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReceberPagamentos_FormClosing);
            this.Load += new System.EventHandler(this.frmReceberPagamentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPagamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPagamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodEntidade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntidade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoedas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesconto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorEntrego.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTroco.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridPagamentos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPagamentos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.TextEdit txtCodEntidade;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtEntidade;
        private DevExpress.XtraEditors.ComboBoxEdit cboMoedas;
        private DevExpress.XtraEditors.TextEdit txtDesconto;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtValorEntrego;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton btnConcluir;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtTroco;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtDesc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
    }
}