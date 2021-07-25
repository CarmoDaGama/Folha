namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    partial class frmPagamentoViaBanco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagamentoViaBanco));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnFechar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodDoc = new DevExpress.XtraEditors.TextEdit();
            this.btnEntidade = new DevExpress.XtraEditors.SimpleButton();
            this.txtDoc = new DevExpress.XtraEditors.TextEdit();
            this.txtEntidade = new DevExpress.XtraEditors.TextEdit();
            this.txtCodEntidade = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.RichTextBox();
            this.timeData = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboContaBancaria = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtValor = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMoeda = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSaldo = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodDoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntidade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodEntidade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeData.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboContaBancaria.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoeda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bsiRecordsCount,
            this.btnSalvar,
            this.btnFechar,
            this.bbiRefresh});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 20;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl.Size = new System.Drawing.Size(550, 132);
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Caption = "Salvar e Fechar";
            this.btnSalvar.Id = 16;
            this.btnSalvar.ImageOptions.ImageUri.Uri = "New";
            this.btnSalvar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvar.ImageOptions.SvgImage")));
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvar_ItemClick);
            // 
            // btnFechar
            // 
            this.btnFechar.Caption = "Voltar";
            this.btnFechar.Id = 18;
            this.btnFechar.ImageOptions.LargeImage = global::Folha.Presentation.Desktop.Properties.Resources.Voltar;
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFechar_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "Refresh";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.ImageUri.Uri = "Refresh";
            this.bbiRefresh.Name = "bbiRefresh";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalvar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFechar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nº:";
            // 
            // txtCodDoc
            // 
            this.txtCodDoc.Enabled = false;
            this.txtCodDoc.Location = new System.Drawing.Point(114, 150);
            this.txtCodDoc.MenuManager = this.ribbonControl;
            this.txtCodDoc.Name = "txtCodDoc";
            this.txtCodDoc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodDoc.Properties.Appearance.Options.UseFont = true;
            this.txtCodDoc.Size = new System.Drawing.Size(86, 22);
            this.txtCodDoc.TabIndex = 3;
            // 
            // btnEntidade
            // 
            this.btnEntidade.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntidade.Appearance.Options.UseFont = true;
            this.btnEntidade.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEntidade.ImageOptions.SvgImage")));
            this.btnEntidade.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnEntidade.Location = new System.Drawing.Point(503, 178);
            this.btnEntidade.Name = "btnEntidade";
            this.btnEntidade.Size = new System.Drawing.Size(27, 23);
            this.btnEntidade.TabIndex = 4;
            this.btnEntidade.Click += new System.EventHandler(this.btnEntidade_Click);
            // 
            // txtDoc
            // 
            this.txtDoc.Location = new System.Drawing.Point(206, 150);
            this.txtDoc.MenuManager = this.ribbonControl;
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoc.Properties.Appearance.Options.UseFont = true;
            this.txtDoc.Size = new System.Drawing.Size(324, 22);
            this.txtDoc.TabIndex = 5;
            // 
            // txtEntidade
            // 
            this.txtEntidade.Location = new System.Drawing.Point(206, 178);
            this.txtEntidade.MenuManager = this.ribbonControl;
            this.txtEntidade.Name = "txtEntidade";
            this.txtEntidade.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntidade.Properties.Appearance.Options.UseFont = true;
            this.txtEntidade.Size = new System.Drawing.Size(291, 22);
            this.txtEntidade.TabIndex = 8;
            // 
            // txtCodEntidade
            // 
            this.txtCodEntidade.Enabled = false;
            this.txtCodEntidade.Location = new System.Drawing.Point(114, 178);
            this.txtCodEntidade.MenuManager = this.ribbonControl;
            this.txtCodEntidade.Name = "txtCodEntidade";
            this.txtCodEntidade.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodEntidade.Properties.Appearance.Options.UseFont = true;
            this.txtCodEntidade.Size = new System.Drawing.Size(86, 22);
            this.txtCodEntidade.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Entidade:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescricao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(114, 216);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(416, 77);
            this.txtDescricao.TabIndex = 10;
            this.txtDescricao.Text = "";
            // 
            // timeData
            // 
            this.timeData.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.timeData.EditValue = "23/01/2020";
            this.timeData.Location = new System.Drawing.Point(114, 314);
            this.timeData.Name = "timeData";
            this.timeData.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.timeData.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeData.Properties.Appearance.Options.UseBackColor = true;
            this.timeData.Properties.Appearance.Options.UseFont = true;
            this.timeData.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeData.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeData.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.timeData.Properties.ContextImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.icons8_Calendar_16px;
            this.timeData.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeData.Properties.EditFormat.FormatString = "";
            this.timeData.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeData.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.timeData.Size = new System.Drawing.Size(120, 22);
            this.timeData.TabIndex = 119;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 120;
            this.label4.Text = "Data:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 121;
            this.label5.Text = "Conta Bancária:";
            // 
            // cboContaBancaria
            // 
            this.cboContaBancaria.Location = new System.Drawing.Point(114, 342);
            this.cboContaBancaria.MenuManager = this.ribbonControl;
            this.cboContaBancaria.Name = "cboContaBancaria";
            this.cboContaBancaria.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboContaBancaria.Properties.Appearance.Options.UseFont = true;
            this.cboContaBancaria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboContaBancaria.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboContaBancaria.Size = new System.Drawing.Size(189, 22);
            this.cboContaBancaria.TabIndex = 122;
            this.cboContaBancaria.SelectedIndexChanged += new System.EventHandler(this.cboContaBancaria_SelectedIndexChanged);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(114, 370);
            this.txtValor.MenuManager = this.ribbonControl;
            this.txtValor.Name = "txtValor";
            this.txtValor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Properties.Appearance.Options.UseFont = true;
            this.txtValor.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtValor.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtValor.Properties.Mask.EditMask = "n";
            this.txtValor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtValor.Properties.MaxLength = 18;
            this.txtValor.Size = new System.Drawing.Size(120, 22);
            this.txtValor.TabIndex = 123;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 124;
            this.label6.Text = "Valor:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(314, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 126;
            this.label7.Text = "Moeda:";
            // 
            // cboMoeda
            // 
            this.cboMoeda.Location = new System.Drawing.Point(371, 370);
            this.cboMoeda.MenuManager = this.ribbonControl;
            this.cboMoeda.Name = "cboMoeda";
            this.cboMoeda.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoeda.Properties.Appearance.Options.UseFont = true;
            this.cboMoeda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoeda.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboMoeda.Size = new System.Drawing.Size(159, 22);
            this.cboMoeda.TabIndex = 127;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(314, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 18);
            this.label8.TabIndex = 130;
            this.label8.Text = "Saldo:";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Enabled = false;
            this.txtSaldo.Location = new System.Drawing.Point(371, 341);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.Properties.Appearance.Options.UseFont = true;
            this.txtSaldo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSaldo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSaldo.Properties.Mask.EditMask = "n";
            this.txtSaldo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSaldo.Size = new System.Drawing.Size(159, 22);
            this.txtSaldo.TabIndex = 129;
            // 
            // frmPagamentoViaBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 405);
            this.ControlBox = false;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.cboMoeda);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.cboContaBancaria);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.timeData);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEntidade);
            this.Controls.Add(this.txtCodEntidade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDoc);
            this.Controls.Add(this.btnEntidade);
            this.Controls.Add(this.txtCodDoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ribbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPagamentoViaBanco";
            this.Ribbon = this.ribbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagamento Via Banco";
            this.Load += new System.EventHandler(this.frmPagamentoViaBanco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodDoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntidade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodEntidade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeData.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboContaBancaria.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoeda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem btnSalvar;
        private DevExpress.XtraBars.BarButtonItem btnFechar;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtCodDoc;
        private DevExpress.XtraEditors.SimpleButton btnEntidade;
        private DevExpress.XtraEditors.TextEdit txtDoc;
        private DevExpress.XtraEditors.TextEdit txtEntidade;
        private DevExpress.XtraEditors.TextEdit txtCodEntidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtDescricao;
        private DevExpress.XtraEditors.DateEdit timeData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.ComboBoxEdit cboContaBancaria;
        private DevExpress.XtraEditors.TextEdit txtValor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.ComboBoxEdit cboMoeda;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtSaldo;
    }
}