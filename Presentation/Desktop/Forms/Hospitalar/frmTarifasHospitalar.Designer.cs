namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    partial class frmTarifasHospitalar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTarifasHospitalar));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnSalvarFechar = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.txtipoQuarto = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBuscaTipoQuarto = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTipoCama = new DevExpress.XtraEditors.TextEdit();
            this.btnBusacaTipoCama = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescricao = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValor = new DevExpress.XtraEditors.TextEdit();
            this.cboTarifa = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtImposto = new DevExpress.XtraEditors.TextEdit();
            this.btnBuscarImposto = new DevExpress.XtraEditors.SimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMotivoIsencao = new DevExpress.XtraEditors.TextEdit();
            this.btnBuscarIsento = new DevExpress.XtraEditors.SimpleButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTempoHora = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtipoQuarto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTarifa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImposto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotivoIsencao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTempoHora)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnSalvar,
            this.btnSalvarFechar,
            this.btnVoltar,
            this.barButtonItem4});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(495, 132);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Caption = "Salvar";
            this.btnSalvar.Id = 1;
            this.btnSalvar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvar.ImageOptions.SvgImage")));
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvar_ItemClick);
            // 
            // btnSalvarFechar
            // 
            this.btnSalvarFechar.Caption = "Salvar Fechar";
            this.btnSalvarFechar.Id = 2;
            this.btnSalvarFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvarFechar.ImageOptions.SvgImage")));
            this.btnSalvarFechar.Name = "btnSalvarFechar";
            this.btnSalvarFechar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvarFechar_ItemClick);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Voltar";
            this.btnVoltar.Id = 3;
            this.btnVoltar.ImageOptions.LargeImage = global::Folha.Presentation.Desktop.Properties.Resources.Voltar;
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVoltar_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.Name = "barButtonItem4";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalvar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalvarFechar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // txtipoQuarto
            // 
            this.txtipoQuarto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtipoQuarto.Enabled = false;
            this.txtipoQuarto.Location = new System.Drawing.Point(128, 182);
            this.txtipoQuarto.Name = "txtipoQuarto";
            this.txtipoQuarto.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtipoQuarto.Properties.Appearance.Options.UseFont = true;
            this.txtipoQuarto.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtipoQuarto.Size = new System.Drawing.Size(318, 22);
            this.txtipoQuarto.TabIndex = 211;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 16);
            this.label7.TabIndex = 212;
            this.label7.Text = "Tipo de Quartos:";
            // 
            // btnBuscaTipoQuarto
            // 
            this.btnBuscaTipoQuarto.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBuscaTipoQuarto.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaTipoQuarto.Appearance.Options.UseFont = true;
            this.btnBuscaTipoQuarto.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnBuscaTipoQuarto.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBuscaTipoQuarto.ImageOptions.SvgImage")));
            this.btnBuscaTipoQuarto.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnBuscaTipoQuarto.Location = new System.Drawing.Point(452, 182);
            this.btnBuscaTipoQuarto.Name = "btnBuscaTipoQuarto";
            this.btnBuscaTipoQuarto.Size = new System.Drawing.Size(31, 22);
            this.btnBuscaTipoQuarto.TabIndex = 213;
            this.btnBuscaTipoQuarto.Click += new System.EventHandler(this.btnBuscaTipoQuarto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 214;
            this.label1.Text = "Tipo de Camas:";
            // 
            // txtTipoCama
            // 
            this.txtTipoCama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipoCama.Enabled = false;
            this.txtTipoCama.Location = new System.Drawing.Point(128, 216);
            this.txtTipoCama.Name = "txtTipoCama";
            this.txtTipoCama.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCama.Properties.Appearance.Options.UseFont = true;
            this.txtTipoCama.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtTipoCama.Size = new System.Drawing.Size(318, 22);
            this.txtTipoCama.TabIndex = 215;
            // 
            // btnBusacaTipoCama
            // 
            this.btnBusacaTipoCama.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBusacaTipoCama.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusacaTipoCama.Appearance.Options.UseFont = true;
            this.btnBusacaTipoCama.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnBusacaTipoCama.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBusacaTipoCama.ImageOptions.SvgImage")));
            this.btnBusacaTipoCama.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnBusacaTipoCama.Location = new System.Drawing.Point(452, 216);
            this.btnBusacaTipoCama.Name = "btnBusacaTipoCama";
            this.btnBusacaTipoCama.Size = new System.Drawing.Size(31, 22);
            this.btnBusacaTipoCama.TabIndex = 216;
            this.btnBusacaTipoCama.Click += new System.EventHandler(this.btnBusacaTipoCama_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 218;
            this.label2.Text = "Tipo de Tarias:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(128, 148);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Properties.Appearance.Options.UseFont = true;
            this.txtCodigo.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtCodigo.Size = new System.Drawing.Size(76, 22);
            this.txtCodigo.TabIndex = 221;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 219;
            this.label3.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Location = new System.Drawing.Point(210, 148);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Properties.Appearance.Options.UseFont = true;
            this.txtDescricao.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtDescricao.Size = new System.Drawing.Size(273, 22);
            this.txtDescricao.TabIndex = 220;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 222;
            this.label4.Text = "Tempo(Hora):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(186, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 223;
            this.label5.Text = "Valor:";
            // 
            // txtValor
            // 
            this.txtValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValor.Location = new System.Drawing.Point(235, 364);
            this.txtValor.Name = "txtValor";
            this.txtValor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Properties.Appearance.Options.UseFont = true;
            this.txtValor.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtValor.Size = new System.Drawing.Size(248, 22);
            this.txtValor.TabIndex = 225;
            this.txtValor.EditValueChanged += new System.EventHandler(this.txtValor_EditValueChanged);
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // cboTarifa
            // 
            this.cboTarifa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboTarifa.EditValue = "POR DIA";
            this.cboTarifa.Location = new System.Drawing.Point(128, 248);
            this.cboTarifa.MenuManager = this.ribbon;
            this.cboTarifa.Name = "cboTarifa";
            this.cboTarifa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTarifa.Properties.Appearance.Options.UseFont = true;
            this.cboTarifa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTarifa.Properties.Items.AddRange(new object[] {
            "POR DIA",
            "POR HORA"});
            this.cboTarifa.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTarifa.Size = new System.Drawing.Size(355, 22);
            this.cboTarifa.TabIndex = 226;
            this.cboTarifa.SelectedIndexChanged += new System.EventHandler(this.cboTarifa_SelectedIndexChanged);
            // 
            // txtImposto
            // 
            this.txtImposto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImposto.Enabled = false;
            this.txtImposto.Location = new System.Drawing.Point(128, 287);
            this.txtImposto.Name = "txtImposto";
            this.txtImposto.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImposto.Properties.Appearance.Options.UseFont = true;
            this.txtImposto.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtImposto.Size = new System.Drawing.Size(318, 22);
            this.txtImposto.TabIndex = 231;
            // 
            // btnBuscarImposto
            // 
            this.btnBuscarImposto.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBuscarImposto.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarImposto.Appearance.Options.UseFont = true;
            this.btnBuscarImposto.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnBuscarImposto.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBuscarImposto.ImageOptions.SvgImage")));
            this.btnBuscarImposto.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnBuscarImposto.Location = new System.Drawing.Point(452, 287);
            this.btnBuscarImposto.Name = "btnBuscarImposto";
            this.btnBuscarImposto.Size = new System.Drawing.Size(31, 22);
            this.btnBuscarImposto.TabIndex = 232;
            this.btnBuscarImposto.Click += new System.EventHandler(this.btnBuscarImposto_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 16);
            this.label6.TabIndex = 230;
            this.label6.Text = "Tipo de Imposto:";
            // 
            // txtMotivoIsencao
            // 
            this.txtMotivoIsencao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMotivoIsencao.Enabled = false;
            this.txtMotivoIsencao.Location = new System.Drawing.Point(128, 321);
            this.txtMotivoIsencao.Name = "txtMotivoIsencao";
            this.txtMotivoIsencao.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivoIsencao.Properties.Appearance.Options.UseFont = true;
            this.txtMotivoIsencao.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtMotivoIsencao.Size = new System.Drawing.Size(318, 22);
            this.txtMotivoIsencao.TabIndex = 234;
            // 
            // btnBuscarIsento
            // 
            this.btnBuscarIsento.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBuscarIsento.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarIsento.Appearance.Options.UseFont = true;
            this.btnBuscarIsento.Enabled = false;
            this.btnBuscarIsento.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnBuscarIsento.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBuscarIsento.ImageOptions.SvgImage")));
            this.btnBuscarIsento.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnBuscarIsento.Location = new System.Drawing.Point(452, 321);
            this.btnBuscarIsento.Name = "btnBuscarIsento";
            this.btnBuscarIsento.Size = new System.Drawing.Size(31, 22);
            this.btnBuscarIsento.TabIndex = 235;
            this.btnBuscarIsento.Click += new System.EventHandler(this.btnBuscarIsento_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 16);
            this.label8.TabIndex = 233;
            this.label8.Text = "Motivo de Isenção:";
            // 
            // txtTempoHora
            // 
            this.txtTempoHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTempoHora.Enabled = false;
            this.txtTempoHora.Location = new System.Drawing.Point(128, 367);
            this.txtTempoHora.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.txtTempoHora.Name = "txtTempoHora";
            this.txtTempoHora.Size = new System.Drawing.Size(52, 21);
            this.txtTempoHora.TabIndex = 238;
            // 
            // frmTarifasHospitalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 398);
            this.Controls.Add(this.txtTempoHora);
            this.Controls.Add(this.txtMotivoIsencao);
            this.Controls.Add(this.btnBuscarIsento);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtImposto);
            this.Controls.Add(this.btnBuscarImposto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboTarifa);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTipoCama);
            this.Controls.Add(this.btnBusacaTipoCama);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtipoQuarto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnBuscaTipoQuarto);
            this.Controls.Add(this.ribbon);
            this.Name = "frmTarifasHospitalar";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarifa Hospitalar";
            this.Load += new System.EventHandler(this.frmTarifasHospitalar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtipoQuarto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTarifa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImposto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotivoIsencao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTempoHora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnSalvar;
        private DevExpress.XtraBars.BarButtonItem btnSalvarFechar;
        private DevExpress.XtraBars.BarButtonItem btnVoltar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.TextEdit txtipoQuarto;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.SimpleButton btnBuscaTipoQuarto;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtTipoCama;
        private DevExpress.XtraEditors.SimpleButton btnBusacaTipoCama;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtDescricao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtValor;
        private DevExpress.XtraEditors.ComboBoxEdit cboTarifa;
        private DevExpress.XtraEditors.TextEdit txtImposto;
        private DevExpress.XtraEditors.SimpleButton btnBuscarImposto;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtMotivoIsencao;
        private DevExpress.XtraEditors.SimpleButton btnBuscarIsento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown txtTempoHora;
    }
}