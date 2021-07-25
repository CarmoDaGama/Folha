namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    partial class frmIntenamentoFaturacao
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
            this.GradeIntermento = new DevExpress.XtraGrid.GridControl();
            this.gridInternados = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Estado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Codigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnIncluir = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteInter = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLiberar = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalTudo = new System.Windows.Forms.TextBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GradeIntermento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInternados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GradeIntermento
            // 
            this.GradeIntermento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GradeIntermento.Location = new System.Drawing.Point(7, 45);
            this.GradeIntermento.MainView = this.gridInternados;
            this.GradeIntermento.Name = "GradeIntermento";
            this.GradeIntermento.Size = new System.Drawing.Size(914, 424);
            this.GradeIntermento.TabIndex = 212;
            this.GradeIntermento.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridInternados});
            // 
            // gridInternados
            // 
            this.gridInternados.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn10,
            this.Ent,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn1,
            this.gridColumn15,
            this.Cama,
            this.Estado,
            this.Codigo});
            this.gridInternados.GridControl = this.GradeIntermento;
            this.gridInternados.Name = "gridInternados";
            this.gridInternados.OptionsFind.Condition = DevExpress.Data.Filtering.FilterCondition.Contains;
            this.gridInternados.OptionsFind.ShowClearButton = false;
            this.gridInternados.OptionsFind.ShowFindButton = false;
            this.gridInternados.OptionsView.ShowGroupPanel = false;
            this.gridInternados.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Quarto";
            this.gridColumn8.FieldName = "Quarto";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 114;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Tarifa";
            this.gridColumn10.FieldName = "Tarifa";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            this.gridColumn10.Width = 161;
            // 
            // Ent
            // 
            this.Ent.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ent.AppearanceCell.Options.UseFont = true;
            this.Ent.Caption = "Entrada";
            this.Ent.FieldName = "DataEntrada";
            this.Ent.Name = "Ent";
            this.Ent.OptionsColumn.AllowEdit = false;
            this.Ent.OptionsColumn.AllowFocus = false;
            this.Ent.Visible = true;
            this.Ent.VisibleIndex = 4;
            this.Ent.Width = 108;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.gridColumn13.AppearanceCell.Options.UseFont = true;
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn13.Caption = "Dias";
            this.gridColumn13.FieldName = "Dias";
            this.gridColumn13.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 3;
            this.gridColumn13.Width = 53;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn14.AppearanceCell.Options.UseFont = true;
            this.gridColumn14.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn14.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn14.Caption = "Preço";
            this.gridColumn14.FieldName = "Valor";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 6;
            this.gridColumn14.Width = 78;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Saida";
            this.gridColumn1.FieldName = "DataSaida";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 104;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn15.AppearanceCell.Options.UseFont = true;
            this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn15.Caption = "Total";
            this.gridColumn15.FieldName = "Total";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 7;
            this.gridColumn15.Width = 71;
            // 
            // Cama
            // 
            this.Cama.Caption = "Cama";
            this.Cama.FieldName = "Cama";
            this.Cama.Name = "Cama";
            this.Cama.OptionsColumn.AllowEdit = false;
            this.Cama.OptionsColumn.AllowFocus = false;
            this.Cama.Visible = true;
            this.Cama.VisibleIndex = 2;
            this.Cama.Width = 106;
            // 
            // Estado
            // 
            this.Estado.Caption = "Estado";
            this.Estado.FieldName = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.OptionsColumn.AllowEdit = false;
            this.Estado.OptionsColumn.AllowFocus = false;
            this.Estado.Visible = true;
            this.Estado.VisibleIndex = 8;
            this.Estado.Width = 92;
            // 
            // Codigo
            // 
            this.Codigo.Caption = "Código";
            this.Codigo.FieldName = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.OptionsColumn.AllowEdit = false;
            this.Codigo.OptionsColumn.AllowFocus = false;
            // 
            // btnIncluir
            // 
            this.btnIncluir.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnIncluir.Appearance.Options.UseFont = true;
            this.btnIncluir.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnIncluir.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnIncluir.Location = new System.Drawing.Point(99, 34);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(100, 26);
            this.btnIncluir.TabIndex = 257;
            this.btnIncluir.Text = "Adicionar";
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // btnDeleteInter
            // 
            this.btnDeleteInter.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteInter.Appearance.Options.UseFont = true;
            this.btnDeleteInter.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDeleteInter.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnDeleteInter.Location = new System.Drawing.Point(13, 33);
            this.btnDeleteInter.Name = "btnDeleteInter";
            this.btnDeleteInter.Size = new System.Drawing.Size(80, 26);
            this.btnDeleteInter.TabIndex = 244;
            this.btnDeleteInter.Text = "Eliminar";
            this.btnDeleteInter.Click += new System.EventHandler(this.btnDeleteInter_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel3.Location = new System.Drawing.Point(7, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(912, 1);
            this.panel3.TabIndex = 209;
            // 
            // btnLiberar
            // 
            this.btnLiberar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiberar.Appearance.Options.UseFont = true;
            this.btnLiberar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLiberar.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnLiberar.Location = new System.Drawing.Point(205, 34);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.Size = new System.Drawing.Size(111, 26);
            this.btnLiberar.TabIndex = 261;
            this.btnLiberar.Text = "Liberar Paciente";
            this.btnLiberar.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(670, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 264;
            this.label4.Text = "Total:";
            // 
            // txtTotalTudo
            // 
            this.txtTotalTudo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalTudo.Enabled = false;
            this.txtTotalTudo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalTudo.Location = new System.Drawing.Point(725, 33);
            this.txtTotalTudo.Name = "txtTotalTudo";
            this.txtTotalTudo.Size = new System.Drawing.Size(183, 22);
            this.txtTotalTudo.TabIndex = 263;
            this.txtTotalTudo.Text = "0,00";
            this.txtTotalTudo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnLiberar);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.btnIncluir);
            this.groupControl1.Controls.Add(this.btnDeleteInter);
            this.groupControl1.Controls.Add(this.txtTotalTudo);
            this.groupControl1.Location = new System.Drawing.Point(7, 475);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(916, 65);
            this.groupControl1.TabIndex = 261;
            this.groupControl1.Text = "Adicionar Intermento";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label17.Location = new System.Drawing.Point(12, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(177, 19);
            this.label17.TabIndex = 262;
            this.label17.Text = "Dados do Internamento";
            // 
            // frmIntenamentoFaturacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 552);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.GradeIntermento);
            this.Controls.Add(this.panel3);
            this.Name = "frmIntenamentoFaturacao";
            this.Text = "IntenamentoFaturacao";
            this.Load += new System.EventHandler(this.frmIntenamentoFaturacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GradeIntermento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInternados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GradeIntermento;
        private DevExpress.XtraGrid.Views.Grid.GridView gridInternados;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn Ent;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn Cama;
        private DevExpress.XtraEditors.SimpleButton btnIncluir;
        private DevExpress.XtraEditors.SimpleButton btnDeleteInter;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton btnLiberar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalTudo;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn Estado;
        private DevExpress.XtraGrid.Columns.GridColumn Codigo;
    }
}