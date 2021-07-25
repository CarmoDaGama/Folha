namespace Folha.Presentation.Desktop
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.tabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.navigationFrame = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.pageLogin = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.checkBoxVerSenha = new System.Windows.Forms.CheckBox();
            this.btnDefinicoes = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLogin = new DevExpress.XtraEditors.TextEdit();
            this.labeInfo = new System.Windows.Forms.Label();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.txtSenha = new DevExpress.XtraEditors.TextEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.btnEntrar = new DevExpress.XtraEditors.SimpleButton();
            this.pageServidor = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.btnFechar3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestarConexao = new DevExpress.XtraEditors.SimpleButton();
            this.btnbd = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.CboServidor = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtServidor = new DevExpress.XtraEditors.TextEdit();
            this.txtPortaBd = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).BeginInit();
            this.navigationFrame.SuspendLayout();
            this.pageLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSenha.Properties)).BeginInit();
            this.pageServidor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboServidor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServidor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortaBd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationFrame
            // 
            this.navigationFrame.Appearance.BackColor = System.Drawing.Color.White;
            this.navigationFrame.Appearance.Options.UseBackColor = true;
            this.navigationFrame.Controls.Add(this.pageLogin);
            this.navigationFrame.Controls.Add(this.pageServidor);
            this.navigationFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame.Name = "navigationFrame";
            this.navigationFrame.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.pageLogin,
            this.pageServidor});
            this.navigationFrame.SelectedPage = this.pageLogin;
            this.navigationFrame.Size = new System.Drawing.Size(776, 545);
            this.navigationFrame.TabIndex = 17;
            this.navigationFrame.Text = "navigationFrame2";
            this.navigationFrame.TransitionType = DevExpress.Utils.Animation.Transitions.Zoom;
            // 
            // pageLogin
            // 
            this.pageLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pageLogin.BackgroundImage")));
            this.pageLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pageLogin.Caption = "pageLogin";
            this.pageLogin.Controls.Add(this.checkBoxVerSenha);
            this.pageLogin.Controls.Add(this.btnDefinicoes);
            this.pageLogin.Controls.Add(this.panel1);
            this.pageLogin.Controls.Add(this.txtLogin);
            this.pageLogin.Controls.Add(this.labeInfo);
            this.pageLogin.Controls.Add(this.btnClose);
            this.pageLogin.Controls.Add(this.txtSenha);
            this.pageLogin.Controls.Add(this.label15);
            this.pageLogin.Controls.Add(this.btnEntrar);
            this.pageLogin.Name = "pageLogin";
            this.pageLogin.Size = new System.Drawing.Size(776, 545);
            // 
            // checkBoxVerSenha
            // 
            this.checkBoxVerSenha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxVerSenha.AutoSize = true;
            this.checkBoxVerSenha.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxVerSenha.Location = new System.Drawing.Point(246, 336);
            this.checkBoxVerSenha.Name = "checkBoxVerSenha";
            this.checkBoxVerSenha.Size = new System.Drawing.Size(75, 17);
            this.checkBoxVerSenha.TabIndex = 38;
            this.checkBoxVerSenha.Text = "Ver Senha";
            this.checkBoxVerSenha.UseVisualStyleBackColor = false;
            this.checkBoxVerSenha.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnDefinicoes
            // 
            this.btnDefinicoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefinicoes.Appearance.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefinicoes.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.btnDefinicoes.Appearance.Options.UseFont = true;
            this.btnDefinicoes.Appearance.Options.UseForeColor = true;
            this.btnDefinicoes.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDefinicoes.ImageOptions.SvgImage")));
            this.btnDefinicoes.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnDefinicoes.Location = new System.Drawing.Point(700, 502);
            this.btnDefinicoes.Name = "btnDefinicoes";
            this.btnDefinicoes.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnDefinicoes.Size = new System.Drawing.Size(29, 31);
            this.btnDefinicoes.TabIndex = 37;
            this.btnDefinicoes.Click += new System.EventHandler(this.btnDefinicoes_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(334, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(112, 116);
            this.panel1.TabIndex = 37;
            // 
            // txtLogin
            // 
            this.txtLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLogin.EditValue = "Usuario";
            this.txtLogin.Location = new System.Drawing.Point(246, 260);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(193)))), ((int)(((byte)(201)))));
            this.txtLogin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.Properties.Appearance.Options.UseBackColor = true;
            this.txtLogin.Properties.Appearance.Options.UseFont = true;
            this.txtLogin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtLogin.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtLogin.Properties.ContextImageOptions.SvgImage")));
            this.txtLogin.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.txtLogin.Properties.Padding = new System.Windows.Forms.Padding(1);
            this.txtLogin.Size = new System.Drawing.Size(276, 22);
            this.txtLogin.TabIndex = 0;
            this.txtLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenha_KeyDown);
            // 
            // labeInfo
            // 
            this.labeInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labeInfo.AutoSize = true;
            this.labeInfo.BackColor = System.Drawing.Color.Transparent;
            this.labeInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(193)))), ((int)(((byte)(201)))));
            this.labeInfo.Location = new System.Drawing.Point(284, 203);
            this.labeInfo.Name = "labeInfo";
            this.labeInfo.Size = new System.Drawing.Size(0, 14);
            this.labeInfo.TabIndex = 36;
            this.labeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnClose.Location = new System.Drawing.Point(735, 502);
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnClose.Size = new System.Drawing.Size(29, 31);
            this.btnClose.TabIndex = 34;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSenha.EditValue = "";
            this.txtSenha.Location = new System.Drawing.Point(246, 299);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(193)))), ((int)(((byte)(201)))));
            this.txtSenha.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Properties.Appearance.Options.UseBackColor = true;
            this.txtSenha.Properties.Appearance.Options.UseFont = true;
            this.txtSenha.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtSenha.Properties.ContextImageOptions.Image = global::Folha.Presentation.Desktop.Properties.Resources.icons8_Password_16px;
            this.txtSenha.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtSenha.Properties.ContextImageOptions.SvgImage")));
            this.txtSenha.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.txtSenha.Properties.NullText = "eeee";
            this.txtSenha.Properties.UseSystemPasswordChar = true;
            this.txtSenha.Size = new System.Drawing.Size(276, 20);
            this.txtSenha.TabIndex = 1;
            this.txtSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenha_KeyDown);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(193)))), ((int)(((byte)(201)))));
            this.label15.Location = new System.Drawing.Point(12, 523);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(142, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Copyright 2020 - Trevo Soft";
            // 
            // btnEntrar
            // 
            this.btnEntrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEntrar.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(193)))), ((int)(((byte)(201)))));
            this.btnEntrar.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.btnEntrar.Appearance.Options.UseBackColor = true;
            this.btnEntrar.Appearance.Options.UseFont = true;
            this.btnEntrar.Appearance.Options.UseForeColor = true;
            this.btnEntrar.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.btnEntrar.AppearanceDisabled.Options.UseForeColor = true;
            this.btnEntrar.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.btnEntrar.AppearanceHovered.Options.UseForeColor = true;
            this.btnEntrar.AppearancePressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.btnEntrar.AppearancePressed.Options.UseForeColor = true;
            this.btnEntrar.Location = new System.Drawing.Point(429, 363);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(93, 26);
            this.btnEntrar.TabIndex = 2;
            this.btnEntrar.Text = "Logar";
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // pageServidor
            // 
            this.pageServidor.Caption = "pageServidor";
            this.pageServidor.Controls.Add(this.btnVoltar);
            this.pageServidor.Controls.Add(this.btnFechar3);
            this.pageServidor.Controls.Add(this.btnTestarConexao);
            this.pageServidor.Controls.Add(this.btnbd);
            this.pageServidor.Controls.Add(this.groupControl1);
            this.pageServidor.Controls.Add(this.label6);
            this.pageServidor.Controls.Add(this.label7);
            this.pageServidor.Name = "pageServidor";
            this.pageServidor.Size = new System.Drawing.Size(776, 545);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVoltar.Appearance.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnVoltar.Appearance.Options.UseFont = true;
            this.btnVoltar.Location = new System.Drawing.Point(689, 397);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 47;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnFechar3
            // 
            this.btnFechar3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar3.Appearance.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar3.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.btnFechar3.Appearance.Options.UseFont = true;
            this.btnFechar3.Appearance.Options.UseForeColor = true;
            this.btnFechar3.Location = new System.Drawing.Point(636, 12);
            this.btnFechar3.Name = "btnFechar3";
            this.btnFechar3.Size = new System.Drawing.Size(128, 26);
            this.btnFechar3.TabIndex = 46;
            this.btnFechar3.Text = "FECHAR";
            this.btnFechar3.Click += new System.EventHandler(this.btnFechar3_Click);
            // 
            // btnTestarConexao
            // 
            this.btnTestarConexao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestarConexao.Appearance.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestarConexao.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.btnTestarConexao.Appearance.Options.UseFont = true;
            this.btnTestarConexao.Appearance.Options.UseForeColor = true;
            this.btnTestarConexao.Location = new System.Drawing.Point(522, 507);
            this.btnTestarConexao.Name = "btnTestarConexao";
            this.btnTestarConexao.Size = new System.Drawing.Size(129, 26);
            this.btnTestarConexao.TabIndex = 45;
            this.btnTestarConexao.Text = "TESTAR CONEXÃO";
            this.btnTestarConexao.Click += new System.EventHandler(this.btnTestarConexao_Click);
            // 
            // btnbd
            // 
            this.btnbd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbd.Appearance.Font = new System.Drawing.Font("Yu Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbd.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.btnbd.Appearance.Options.UseFont = true;
            this.btnbd.Appearance.Options.UseForeColor = true;
            this.btnbd.Location = new System.Drawing.Point(657, 507);
            this.btnbd.Name = "btnbd";
            this.btnbd.Size = new System.Drawing.Size(107, 26);
            this.btnbd.TabIndex = 44;
            this.btnbd.Text = "ACTUALIZAR BD";
            this.btnbd.Click += new System.EventHandler(this.btnbd_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.BackColor2 = System.Drawing.Color.White;
            this.groupControl1.Appearance.BorderColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Appearance.Options.UseBorderColor = true;
            this.groupControl1.Controls.Add(this.CboServidor);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label12);
            this.groupControl1.Controls.Add(this.comboBoxEdit1);
            this.groupControl1.Controls.Add(this.txtServidor);
            this.groupControl1.Controls.Add(this.txtPortaBd);
            this.groupControl1.Controls.Add(this.label8);
            this.groupControl1.Location = new System.Drawing.Point(20, 142);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(741, 220);
            this.groupControl1.TabIndex = 43;
            this.groupControl1.Text = "Configurações de base de dados";
            // 
            // CboServidor
            // 
            this.CboServidor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CboServidor.EditValue = "SQL SERVER";
            this.CboServidor.Location = new System.Drawing.Point(15, 80);
            this.CboServidor.Name = "CboServidor";
            this.CboServidor.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.CboServidor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.CboServidor.Properties.Appearance.Options.UseBackColor = true;
            this.CboServidor.Properties.Appearance.Options.UseFont = true;
            this.CboServidor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.CboServidor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CboServidor.Properties.Items.AddRange(new object[] {
            "MYSQL SERVER",
            "SQL SERVER",
            "ORACLE SERVER"});
            this.CboServidor.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CboServidor.Size = new System.Drawing.Size(714, 24);
            this.CboServidor.TabIndex = 43;
            this.CboServidor.SelectedIndexChanged += new System.EventHandler(this.CboServidor_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(15, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 35;
            this.label5.Text = "Servidor:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(200, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 18);
            this.label12.TabIndex = 42;
            this.label12.Text = "Idioma:";
            this.label12.Visible = false;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEdit1.Enabled = false;
            this.comboBoxEdit1.Location = new System.Drawing.Point(203, 167);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.comboBoxEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.comboBoxEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.comboBoxEdit1.Properties.Appearance.Options.UseFont = true;
            this.comboBoxEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(526, 24);
            this.comboBoxEdit1.TabIndex = 41;
            this.comboBoxEdit1.Visible = false;
            // 
            // txtServidor
            // 
            this.txtServidor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServidor.EditValue = "LOCALHOST";
            this.txtServidor.Location = new System.Drawing.Point(15, 110);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtServidor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtServidor.Properties.Appearance.Options.UseBackColor = true;
            this.txtServidor.Properties.Appearance.Options.UseFont = true;
            this.txtServidor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtServidor.Size = new System.Drawing.Size(714, 24);
            this.txtServidor.TabIndex = 36;
            // 
            // txtPortaBd
            // 
            this.txtPortaBd.EditValue = "1433";
            this.txtPortaBd.Location = new System.Drawing.Point(15, 167);
            this.txtPortaBd.Name = "txtPortaBd";
            this.txtPortaBd.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPortaBd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtPortaBd.Properties.Appearance.Options.UseBackColor = true;
            this.txtPortaBd.Properties.Appearance.Options.UseFont = true;
            this.txtPortaBd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtPortaBd.Size = new System.Drawing.Size(182, 24);
            this.txtPortaBd.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(15, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 18);
            this.label8.TabIndex = 38;
            this.label8.Text = "Porta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(12, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 29);
            this.label6.TabIndex = 34;
            this.label6.Text = "Servidor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(15, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 16);
            this.label7.TabIndex = 33;
            this.label7.Text = "Configuração de acesso a dados.";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 545);
            this.Controls.Add(this.navigationFrame);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame)).EndInit();
            this.navigationFrame.ResumeLayout(false);
            this.pageLogin.ResumeLayout(false);
            this.pageLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSenha.Properties)).EndInit();
            this.pageServidor.ResumeLayout(false);
            this.pageServidor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CboServidor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServidor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortaBd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame;
        private DevExpress.XtraBars.Navigation.NavigationPage pageLogin;
        private DevExpress.XtraBars.Navigation.NavigationPage pageServidor;
        private DevExpress.XtraEditors.SimpleButton btnEntrar;
        private DevExpress.XtraEditors.TextEdit txtLogin;
        private DevExpress.XtraEditors.TextEdit txtSenha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtPortaBd;
        private DevExpress.XtraEditors.TextEdit txtServidor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnTestarConexao;
        private DevExpress.XtraEditors.SimpleButton btnbd;
        private System.Windows.Forms.Label labeInfo;
        private DevExpress.XtraEditors.ComboBoxEdit CboServidor;
        private DevExpress.XtraEditors.SimpleButton btnFechar3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxVerSenha;
        private DevExpress.XtraEditors.SimpleButton btnDefinicoes;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
    }
}