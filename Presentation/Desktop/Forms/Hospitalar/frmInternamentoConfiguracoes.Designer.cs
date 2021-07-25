namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    partial class frmInternamentoConfiguracoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInternamentoConfiguracoes));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnAdiconar = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.cboTarifa = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboTipoQuarto = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCama = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.cboQuarto = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtValorTarifa = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTarifa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoQuarto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQuarto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnAdiconar,
            this.btnVoltar});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 3;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(530, 61);
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // btnAdiconar
            // 
            this.btnAdiconar.Caption = "Adicionar";
            this.btnAdiconar.Id = 1;
            this.btnAdiconar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAdiconar.ImageOptions.SvgImage")));
            this.btnAdiconar.Name = "btnAdiconar";
            this.btnAdiconar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Voltar";
            this.btnVoltar.Id = 2;
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnAdiconar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // cboTarifa
            // 
            this.cboTarifa.Location = new System.Drawing.Point(344, 82);
            this.cboTarifa.Name = "cboTarifa";
            this.cboTarifa.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTarifa.Properties.Appearance.Options.UseFont = true;
            this.cboTarifa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTarifa.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTarifa.Size = new System.Drawing.Size(170, 22);
            this.cboTarifa.TabIndex = 262;
            this.cboTarifa.SelectedIndexChanged += new System.EventHandler(this.cboTarifa_SelectedIndexChanged);
            // 
            // cboTipoQuarto
            // 
            this.cboTipoQuarto.Location = new System.Drawing.Point(97, 82);
            this.cboTipoQuarto.Name = "cboTipoQuarto";
            this.cboTipoQuarto.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoQuarto.Properties.Appearance.Options.UseFont = true;
            this.cboTipoQuarto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoQuarto.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTipoQuarto.Size = new System.Drawing.Size(178, 22);
            this.cboTipoQuarto.TabIndex = 260;
            this.cboTipoQuarto.SelectedIndexChanged += new System.EventHandler(this.cboTipoQuarto_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(285, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 14);
            this.label10.TabIndex = 261;
            this.label10.Text = "Tarifa:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 259;
            this.label8.Text = "Tipo Quarto:";
            // 
            // cboCama
            // 
            this.cboCama.Location = new System.Drawing.Point(344, 128);
            this.cboCama.Name = "cboCama";
            this.cboCama.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCama.Properties.Appearance.Options.UseFont = true;
            this.cboCama.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCama.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboCama.Size = new System.Drawing.Size(170, 22);
            this.cboCama.TabIndex = 267;
            this.cboCama.SelectedIndexChanged += new System.EventHandler(this.cboCama_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 14);
            this.label1.TabIndex = 266;
            this.label1.Text = "Camas:";
            // 
            // cboQuarto
            // 
            this.cboQuarto.Location = new System.Drawing.Point(97, 124);
            this.cboQuarto.Name = "cboQuarto";
            this.cboQuarto.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboQuarto.Properties.Appearance.Options.UseFont = true;
            this.cboQuarto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboQuarto.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboQuarto.Size = new System.Drawing.Size(178, 22);
            this.cboQuarto.TabIndex = 265;
            this.cboQuarto.SelectedIndexChanged += new System.EventHandler(this.cboQuarto_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 14);
            this.label9.TabIndex = 264;
            this.label9.Text = "Quartos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 14);
            this.label2.TabIndex = 268;
            this.label2.Text = "Dias:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(289, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 270;
            this.label4.Text = "Valor:";
            // 
            // txtValorTarifa
            // 
            this.txtValorTarifa.Enabled = false;
            this.txtValorTarifa.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTarifa.Location = new System.Drawing.Point(344, 172);
            this.txtValorTarifa.Name = "txtValorTarifa";
            this.txtValorTarifa.Size = new System.Drawing.Size(170, 22);
            this.txtValorTarifa.TabIndex = 269;
            this.txtValorTarifa.Text = "0,00";
            this.txtValorTarifa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.Location = new System.Drawing.Point(97, 172);
            this.txtQuantidade.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.txtQuantidade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(178, 22);
            this.txtQuantidade.TabIndex = 273;
            this.txtQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmInternamentoConfiguracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 220);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtValorTarifa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCama);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboQuarto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboTarifa);
            this.Controls.Add(this.cboTipoQuarto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInternamentoConfiguracoes";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalhes de Internamento";
            this.Load += new System.EventHandler(this.frmInternamentoConfiguracoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTarifa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoQuarto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQuarto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnAdiconar;
        private DevExpress.XtraEditors.ComboBoxEdit cboTarifa;
        private DevExpress.XtraEditors.ComboBoxEdit cboTipoQuarto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.ComboBoxEdit cboCama;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit cboQuarto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValorTarifa;
        private DevExpress.XtraBars.BarButtonItem btnVoltar;
        private System.Windows.Forms.NumericUpDown txtQuantidade;
    }
}