namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    partial class frmDadosTipoConsultas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDadosTipoConsultas));
            this.txtDescricao = new DevExpress.XtraEditors.TextEdit();
            this.txtValor = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSalvarFechar = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.timeHora = new DevExpress.XtraEditors.TimeEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValorIva = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImposto = new DevExpress.XtraEditors.TextEdit();
            this.btnImposto = new DevExpress.XtraEditors.SimpleButton();
            this.btnMotivoIsencao = new DevExpress.XtraEditors.SimpleButton();
            this.txtMotivoIsencao = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.labelPermitirVenda = new System.Windows.Forms.Label();
            this.btnEspecialidade = new DevExpress.XtraEditors.SimpleButton();
            this.txtEspecialidade = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeHora.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorIva.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImposto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotivoIsencao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEspecialidade.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Location = new System.Drawing.Point(133, 68);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Properties.Appearance.Options.UseFont = true;
            this.txtDescricao.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtDescricao.Size = new System.Drawing.Size(327, 22);
            this.txtDescricao.TabIndex = 27;
            // 
            // txtValor
            // 
            this.txtValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValor.Location = new System.Drawing.Point(134, 262);
            this.txtValor.Name = "txtValor";
            this.txtValor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Properties.Appearance.Options.UseFont = true;
            this.txtValor.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtValor.Properties.Mask.EditMask = "\\d+";
            this.txtValor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtValor.Size = new System.Drawing.Size(327, 22);
            this.txtValor.TabIndex = 29;
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "Descrição:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Preço:";
            // 
            // ribbon
            // 
            this.ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbon.CommandLayout = DevExpress.XtraBars.Ribbon.CommandLayout.Simplified;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnSalvarFechar,
            this.btnClose,
            this.barButtonItem4});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(468, 61);
            // 
            // btnSalvarFechar
            // 
            this.btnSalvarFechar.Caption = "Salvar e Fechar";
            this.btnSalvarFechar.Id = 2;
            this.btnSalvarFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvarFechar.ImageOptions.SvgImage")));
            this.btnSalvarFechar.Name = "btnSalvarFechar";
            this.btnSalvarFechar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvarFechar_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Voltar";
            this.btnClose.Id = 3;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Name = "btnClose";
            this.btnClose.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Clo_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Imprimir e Exportar";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem4.ImageOptions.SvgImage")));
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Opções";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalvarFechar);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // timeHora
            // 
            this.timeHora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeHora.EditValue = "";
            this.timeHora.Location = new System.Drawing.Point(134, 202);
            this.timeHora.MenuManager = this.ribbon;
            this.timeHora.Name = "timeHora";
            this.timeHora.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeHora.Properties.DisplayFormat.FormatString = "t";
            this.timeHora.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeHora.Properties.EditFormat.FormatString = "t";
            this.timeHora.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeHora.Properties.Mask.EditMask = "t";
            this.timeHora.Size = new System.Drawing.Size(327, 20);
            this.timeHora.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "Duração:";
            // 
            // txtValorIva
            // 
            this.txtValorIva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorIva.Enabled = false;
            this.txtValorIva.Location = new System.Drawing.Point(133, 231);
            this.txtValorIva.Name = "txtValorIva";
            this.txtValorIva.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorIva.Properties.Appearance.Options.UseFont = true;
            this.txtValorIva.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtValorIva.Properties.Mask.EditMask = "\\d+";
            this.txtValorIva.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtValorIva.Size = new System.Drawing.Size(327, 22);
            this.txtValorIva.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "Valor IVA:";
            // 
            // txtImposto
            // 
            this.txtImposto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImposto.Enabled = false;
            this.txtImposto.Location = new System.Drawing.Point(133, 99);
            this.txtImposto.Name = "txtImposto";
            this.txtImposto.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImposto.Properties.Appearance.Options.UseFont = true;
            this.txtImposto.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtImposto.Size = new System.Drawing.Size(299, 22);
            this.txtImposto.TabIndex = 181;
            // 
            // btnImposto
            // 
            this.btnImposto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImposto.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImposto.Appearance.Options.UseFont = true;
            this.btnImposto.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnImposto.ImageOptions.SvgImage")));
            this.btnImposto.ImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.btnImposto.Location = new System.Drawing.Point(438, 99);
            this.btnImposto.Name = "btnImposto";
            this.btnImposto.Size = new System.Drawing.Size(22, 22);
            this.btnImposto.TabIndex = 180;
            this.btnImposto.Click += new System.EventHandler(this.btnImposto_Click);
            // 
            // btnMotivoIsencao
            // 
            this.btnMotivoIsencao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMotivoIsencao.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMotivoIsencao.Appearance.Options.UseFont = true;
            this.btnMotivoIsencao.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMotivoIsencao.ImageOptions.SvgImage")));
            this.btnMotivoIsencao.ImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.btnMotivoIsencao.Location = new System.Drawing.Point(438, 134);
            this.btnMotivoIsencao.Name = "btnMotivoIsencao";
            this.btnMotivoIsencao.Size = new System.Drawing.Size(22, 22);
            this.btnMotivoIsencao.TabIndex = 179;
            this.btnMotivoIsencao.Click += new System.EventHandler(this.btnMotivoIsencao_Click);
            // 
            // txtMotivoIsencao
            // 
            this.txtMotivoIsencao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMotivoIsencao.Enabled = false;
            this.txtMotivoIsencao.Location = new System.Drawing.Point(133, 134);
            this.txtMotivoIsencao.Name = "txtMotivoIsencao";
            this.txtMotivoIsencao.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivoIsencao.Properties.Appearance.Options.UseFont = true;
            this.txtMotivoIsencao.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtMotivoIsencao.Size = new System.Drawing.Size(299, 22);
            this.txtMotivoIsencao.TabIndex = 175;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 177;
            this.label5.Text = "Imposto:";
            // 
            // labelPermitirVenda
            // 
            this.labelPermitirVenda.AutoSize = true;
            this.labelPermitirVenda.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPermitirVenda.Location = new System.Drawing.Point(8, 137);
            this.labelPermitirVenda.Name = "labelPermitirVenda";
            this.labelPermitirVenda.Size = new System.Drawing.Size(116, 16);
            this.labelPermitirVenda.TabIndex = 176;
            this.labelPermitirVenda.Text = "Motivo de Isenção:";
            // 
            // btnEspecialidade
            // 
            this.btnEspecialidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEspecialidade.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEspecialidade.Appearance.Options.UseFont = true;
            this.btnEspecialidade.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEspecialidade.ImageOptions.SvgImage")));
            this.btnEspecialidade.ImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.btnEspecialidade.Location = new System.Drawing.Point(438, 167);
            this.btnEspecialidade.Name = "btnEspecialidade";
            this.btnEspecialidade.Size = new System.Drawing.Size(22, 22);
            this.btnEspecialidade.TabIndex = 184;
            this.btnEspecialidade.Click += new System.EventHandler(this.btnEspecialidade_Click);
            // 
            // txtEspecialidade
            // 
            this.txtEspecialidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEspecialidade.Enabled = false;
            this.txtEspecialidade.Location = new System.Drawing.Point(133, 167);
            this.txtEspecialidade.Name = "txtEspecialidade";
            this.txtEspecialidade.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEspecialidade.Properties.Appearance.Options.UseFont = true;
            this.txtEspecialidade.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtEspecialidade.Size = new System.Drawing.Size(299, 22);
            this.txtEspecialidade.TabIndex = 182;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 183;
            this.label6.Text = "Especialidade:";
            // 
            // frmDadosTipoConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 293);
            this.Controls.Add(this.btnEspecialidade);
            this.Controls.Add(this.txtEspecialidade);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtImposto);
            this.Controls.Add(this.btnImposto);
            this.Controls.Add(this.btnMotivoIsencao);
            this.Controls.Add(this.txtMotivoIsencao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelPermitirVenda);
            this.Controls.Add(this.txtValorIva);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timeHora);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDadosTipoConsultas";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo Consulta";
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeHora.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorIva.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImposto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotivoIsencao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEspecialidade.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDescricao;
        private DevExpress.XtraEditors.TextEdit txtValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnSalvarFechar;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.TimeEdit timeHora;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtValorIva;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtImposto;
        private DevExpress.XtraEditors.SimpleButton btnImposto;
        private DevExpress.XtraEditors.SimpleButton btnMotivoIsencao;
        private DevExpress.XtraEditors.TextEdit txtMotivoIsencao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelPermitirVenda;
        private DevExpress.XtraEditors.SimpleButton btnEspecialidade;
        private DevExpress.XtraEditors.TextEdit txtEspecialidade;
        private System.Windows.Forms.Label label6;
    }
}