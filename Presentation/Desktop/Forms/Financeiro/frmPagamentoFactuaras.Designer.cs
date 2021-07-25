namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    partial class frmFacturaRecibo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturaRecibo));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnPagar = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.txtCodEntidade = new DevExpress.XtraEditors.TextEdit();
            this.txtdata = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.labelFamilia = new System.Windows.Forms.Label();
            this.txtDoc = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.gridDoc = new DevExpress.XtraGrid.GridControl();
            this.gridViewDoc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEntidade = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodEntidade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdata.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdata.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntidade.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Controls.Add(this.txtEntidade);
            this.panelControl1.Controls.Add(this.btnPagar);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.txtCodEntidade);
            this.panelControl1.Controls.Add(this.txtdata);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.labelFamilia);
            this.panelControl1.Controls.Add(this.txtDoc);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(847, 169);
            this.panelControl1.TabIndex = 0;
            // 
            // btnPagar
            // 
            this.btnPagar.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Appearance.Options.UseFont = true;
            this.btnPagar.Enabled = false;
            this.btnPagar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPagar.ImageOptions.Image")));
            this.btnPagar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnPagar.Location = new System.Drawing.Point(12, 7);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(59, 50);
            this.btnPagar.TabIndex = 104;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(786, 19);
            this.label4.TabIndex = 103;
            this.label4.Text = "Liquidação de Documentos";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(792, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 38);
            this.btnClose.TabIndex = 102;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtCodEntidade
            // 
            this.txtCodEntidade.Enabled = false;
            this.txtCodEntidade.Location = new System.Drawing.Point(108, 137);
            this.txtCodEntidade.Name = "txtCodEntidade";
            this.txtCodEntidade.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodEntidade.Properties.Appearance.Options.UseFont = true;
            this.txtCodEntidade.Size = new System.Drawing.Size(91, 22);
            this.txtCodEntidade.TabIndex = 99;
            // 
            // txtdata
            // 
            this.txtdata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdata.EditValue = "23/01/2020";
            this.txtdata.Enabled = false;
            this.txtdata.Location = new System.Drawing.Point(668, 106);
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
            this.txtdata.Size = new System.Drawing.Size(167, 22);
            this.txtdata.TabIndex = 98;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 97;
            this.label1.Text = "Entidade:";
            // 
            // labelFamilia
            // 
            this.labelFamilia.AutoSize = true;
            this.labelFamilia.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFamilia.Location = new System.Drawing.Point(12, 109);
            this.labelFamilia.Name = "labelFamilia";
            this.labelFamilia.Size = new System.Drawing.Size(77, 16);
            this.labelFamilia.TabIndex = 96;
            this.labelFamilia.Text = "Documento:";
            // 
            // txtDoc
            // 
            this.txtDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDoc.Enabled = false;
            this.txtDoc.Location = new System.Drawing.Point(108, 106);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoc.Properties.Appearance.Options.UseFont = true;
            this.txtDoc.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtDoc.Size = new System.Drawing.Size(554, 22);
            this.txtDoc.TabIndex = 93;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(553, 495);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 101;
            this.label2.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.EditValue = "0,00";
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(610, 490);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(225, 26);
            this.txtTotal.TabIndex = 100;
            // 
            // gridDoc
            // 
            this.gridDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDoc.Location = new System.Drawing.Point(12, 175);
            this.gridDoc.MainView = this.gridViewDoc;
            this.gridDoc.Name = "gridDoc";
            this.gridDoc.Size = new System.Drawing.Size(823, 309);
            this.gridDoc.TabIndex = 4;
            this.gridDoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDoc});
            this.gridDoc.Click += new System.EventHandler(this.gridDoc_Click);
            this.gridDoc.DoubleClick += new System.EventHandler(this.gridDoc_DoubleClick);
            // 
            // gridViewDoc
            // 
            this.gridViewDoc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gridViewDoc.GridControl = this.gridDoc;
            this.gridViewDoc.Name = "gridViewDoc";
            this.gridViewDoc.OptionsBehavior.Editable = false;
            this.gridViewDoc.OptionsSelection.MultiSelect = true;
            this.gridViewDoc.OptionsView.ShowGroupPanel = false;
            this.gridViewDoc.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewDoc_RowClick);
            this.gridViewDoc.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridViewDoc_RowCellClick);
            this.gridViewDoc.DoubleClick += new System.EventHandler(this.gridViewDoc_DoubleClick_1);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Código";
            this.gridColumn1.FieldName = "Codigo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 49;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.Caption = "Data";
            this.gridColumn2.FieldName = "Data";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 72;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.Caption = "Hora";
            this.gridColumn3.FieldName = "Hora";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 44;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Documento";
            this.gridColumn4.FieldName = "Documento";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 213;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Total";
            this.gridColumn5.DisplayFormat.FormatString = "N2";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn5.FieldName = "Total";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 98;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Cod. Entidade";
            this.gridColumn6.FieldName = "CodEntidade";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Width = 80;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Entidade";
            this.gridColumn7.FieldName = "Entidade";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 182;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(326, 526);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 16);
            this.label3.TabIndex = 98;
            this.label3.Text = "Duplo clique para liquidar documento. ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtEntidade
            // 
            this.txtEntidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntidade.Location = new System.Drawing.Point(205, 137);
            this.txtEntidade.Name = "txtEntidade";
            this.txtEntidade.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtEntidade.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntidade.Properties.Appearance.Options.UseBackColor = true;
            this.txtEntidade.Properties.Appearance.Options.UseFont = true;
            this.txtEntidade.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtEntidade.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("textHabilitacao.Properties.ContextImageOptions.SvgImage")));
            this.txtEntidade.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.txtEntidade.Properties.ReadOnly = true;
            this.txtEntidade.Properties.UseReadOnlyAppearance = false;
            this.txtEntidade.Size = new System.Drawing.Size(630, 22);
            this.txtEntidade.TabIndex = 105;
            this.txtEntidade.Click += new System.EventHandler(this.btnEntidade_Click);
            // 
            // frmFacturaRecibo
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 551);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridDoc);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFacturaRecibo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidação de Documentos";
            this.Load += new System.EventHandler(this.frmReceberPagamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodEntidade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdata.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdata.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntidade.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridDoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDoc;
        private DevExpress.XtraEditors.TextEdit txtDoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelFamilia;
        private DevExpress.XtraEditors.DateEdit txtdata;
        private DevExpress.XtraEditors.TextEdit txtCodEntidade;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btnPagar;
        private DevExpress.XtraEditors.TextEdit txtEntidade;
    }
}