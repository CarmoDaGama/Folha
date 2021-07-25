namespace Folha.Presentation.Desktop.Forms.Utilitarios_Configuracoes
{
    partial class frmConfiguracoesBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracoesBackup));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSalvaFechar = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPeriodo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.txtIntervalo = new DevExpress.XtraEditors.TextEdit();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCaminho = new DevExpress.XtraEditors.TextEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntervalo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaminho.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnSalvaFechar,
            this.btnVoltar,
            this.barButtonItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(649, 58);
            // 
            // btnSalvaFechar
            // 
            this.btnSalvaFechar.Caption = "Salvar";
            this.btnSalvaFechar.Id = 2;
            this.btnSalvaFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvaFechar.ImageOptions.SvgImage")));
            this.btnSalvaFechar.Name = "btnSalvaFechar";
            this.btnSalvaFechar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvaFechar_ItemClick);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Fechar";
            this.btnVoltar.Id = 3;
            this.btnVoltar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVoltar.ImageOptions.SvgImage")));
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnVoltar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVoltar_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Limpar";
            this.barButtonItem1.Id = 4;
            this.barButtonItem1.ImageOptions.SvgImage = global::Folha.Presentation.Desktop.Properties.Resources.limpar_sinza;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Opções";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalvaFechar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 210;
            this.label4.Text = "Periodo";
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.EditValue = "Semanal";
            this.cboPeriodo.Location = new System.Drawing.Point(161, 18);
            this.cboPeriodo.MenuManager = this.ribbon;
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodo.Properties.Appearance.Options.UseFont = true;
            this.cboPeriodo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPeriodo.Properties.Items.AddRange(new object[] {
            "Semanal",
            "Diario",
            "Mensal",
            "Trimestral",
            "Anual"});
            this.cboPeriodo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPeriodo.Size = new System.Drawing.Size(351, 22);
            this.cboPeriodo.TabIndex = 212;
            this.cboPeriodo.SelectedIndexChanged += new System.EventHandler(this.cboPeriodo_SelectedIndexChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(94, 18);
            this.txtCodigo.MenuManager = this.ribbon;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Properties.Appearance.Options.UseFont = true;
            this.txtCodigo.Size = new System.Drawing.Size(61, 22);
            this.txtCodigo.TabIndex = 217;
            // 
            // txtIntervalo
            // 
            this.txtIntervalo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIntervalo.EditValue = "7";
            this.txtIntervalo.Enabled = false;
            this.txtIntervalo.Location = new System.Drawing.Point(518, 20);
            this.txtIntervalo.MenuManager = this.ribbon;
            this.txtIntervalo.Name = "txtIntervalo";
            this.txtIntervalo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIntervalo.Properties.Appearance.Options.UseFont = true;
            this.txtIntervalo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIntervalo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIntervalo.Size = new System.Drawing.Size(93, 20);
            this.txtIntervalo.TabIndex = 219;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 224;
            this.label2.Text = "Local";
            // 
            // txtCaminho
            // 
            this.txtCaminho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaminho.Location = new System.Drawing.Point(94, 52);
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaminho.Properties.Appearance.Options.UseFont = true;
            this.txtCaminho.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtCaminho.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtCaminho.Properties.ContextImageOptions.SvgImage")));
            this.txtCaminho.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.txtCaminho.Properties.ReadOnly = true;
            this.txtCaminho.Properties.UseReadOnlyAppearance = false;
            this.txtCaminho.Size = new System.Drawing.Size(517, 22);
            this.txtCaminho.TabIndex = 222;
            this.txtCaminho.Click += new System.EventHandler(this.txtCaminho_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCaminho);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.cboPeriodo);
            this.panel1.Controls.Add(this.txtIntervalo);
            this.panel1.Location = new System.Drawing.Point(12, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 94);
            this.panel1.TabIndex = 226;
            // 
            // frmConfiguracoesBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 304);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfiguracoesBackup";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracões de cópia de segurança";
            this.Load += new System.EventHandler(this.frmConfiguracoesBackup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntervalo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCaminho.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnSalvaFechar;
        private DevExpress.XtraBars.BarButtonItem btnVoltar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.ComboBoxEdit cboPeriodo;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.TextEdit txtIntervalo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtCaminho;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.Panel panel1;
    }
}