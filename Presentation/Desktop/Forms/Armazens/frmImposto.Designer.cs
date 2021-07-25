namespace Folha.Presentation.Desktop.Forms.Armazens
{
    partial class frmImposto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImposto));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSelecionar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.btnElimanr = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.btnNovo = new DevExpress.XtraBars.BarButtonItem();
            this.btnsalvarFechar = new DevExpress.XtraBars.BarButtonItem();
            this.btnFechar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnverListagem = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPercentagem = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSigla = new DevExpress.XtraEditors.TextEdit();
            this.lbl = new System.Windows.Forms.Label();
            this.txtTipo = new DevExpress.XtraEditors.TextEdit();
            this.txtCodTipo = new DevExpress.XtraEditors.TextEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentagem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSigla.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodTipo.Properties)).BeginInit();
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
            this.btnSelecionar,
            this.barButtonItem2,
            this.barButtonItem4,
            this.btnElimanr,
            this.barButtonItem6,
            this.barButtonItem7,
            this.btnNovo,
            this.btnsalvarFechar,
            this.btnFechar,
            this.barButtonItem1,
            this.btnverListagem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 13;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages;
            this.ribbon.Size = new System.Drawing.Size(833, 61);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Caption = "Selecionar";
            this.btnSelecionar.Id = 1;
            this.btnSelecionar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSelecionar.ImageOptions.SvgImage")));
            this.btnSelecionar.Name = "btnSelecionar";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Novo";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Editar";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem4.ImageOptions.SvgImage")));
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // btnElimanr
            // 
            this.btnElimanr.Caption = "Eliminar";
            this.btnElimanr.Id = 5;
            this.btnElimanr.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnElimanr.ImageOptions.SvgImage")));
            this.btnElimanr.Name = "btnElimanr";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Imprimir";
            this.barButtonItem6.Id = 6;
            this.barButtonItem6.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.LargeImage")));
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Imprimir";
            this.barButtonItem7.Id = 7;
            this.barButtonItem7.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem7.ImageOptions.SvgImage")));
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // btnNovo
            // 
            this.btnNovo.Caption = "Novo";
            this.btnNovo.Id = 8;
            this.btnNovo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNovo.ImageOptions.SvgImage")));
            this.btnNovo.Name = "btnNovo";
            // 
            // btnsalvarFechar
            // 
            this.btnsalvarFechar.Caption = "Salvar ";
            this.btnsalvarFechar.Id = 9;
            this.btnsalvarFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnsalvarFechar.ImageOptions.SvgImage")));
            this.btnsalvarFechar.Name = "btnsalvarFechar";
            this.btnsalvarFechar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnsalvarFechar_ItemClick);
            // 
            // btnFechar
            // 
            this.btnFechar.Caption = "Fechar";
            this.btnFechar.Id = 10;
            this.btnFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFechar.ImageOptions.SvgImage")));
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFechar_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Limpar";
            this.barButtonItem1.Id = 11;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnverListagem
            // 
            this.btnverListagem.Caption = "Ver Listagem";
            this.btnverListagem.Id = 12;
            this.btnverListagem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem3.ImageOptions.SvgImage")));
            this.btnverListagem.Name = "btnverListagem";
            this.btnverListagem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnverListagem_ItemClick);
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnsalvarFechar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnverListagem);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFechar);
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
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(135, 33);
            this.txtCodigo.MenuManager = this.ribbon;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Properties.Appearance.Options.UseBackColor = true;
            this.txtCodigo.Properties.Appearance.Options.UseFont = true;
            this.txtCodigo.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtCodigo.Size = new System.Drawing.Size(73, 20);
            this.txtCodigo.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Location = new System.Drawing.Point(224, 33);
            this.txtDescricao.MenuManager = this.ribbon;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtDescricao.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Properties.Appearance.Options.UseBackColor = true;
            this.txtDescricao.Properties.Appearance.Options.UseFont = true;
            this.txtDescricao.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtDescricao.Size = new System.Drawing.Size(551, 20);
            this.txtDescricao.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Percentagem";
            // 
            // txtPercentagem
            // 
            this.txtPercentagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercentagem.Location = new System.Drawing.Point(135, 168);
            this.txtPercentagem.MenuManager = this.ribbon;
            this.txtPercentagem.Name = "txtPercentagem";
            this.txtPercentagem.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPercentagem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPercentagem.Properties.Appearance.Options.UseBackColor = true;
            this.txtPercentagem.Properties.Appearance.Options.UseFont = true;
            this.txtPercentagem.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtPercentagem.Properties.Mask.EditMask = "n2";
            this.txtPercentagem.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPercentagem.Properties.MaxLength = 50;
            this.txtPercentagem.Size = new System.Drawing.Size(640, 20);
            this.txtPercentagem.TabIndex = 36;
            this.txtPercentagem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPercentagem_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Sigla";
            // 
            // txtSigla
            // 
            this.txtSigla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSigla.Location = new System.Drawing.Point(135, 122);
            this.txtSigla.Name = "txtSigla";
            this.txtSigla.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSigla.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSigla.Properties.Appearance.Options.UseBackColor = true;
            this.txtSigla.Properties.Appearance.Options.UseFont = true;
            this.txtSigla.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtSigla.Properties.MaxLength = 50;
            this.txtSigla.Size = new System.Drawing.Size(640, 20);
            this.txtSigla.TabIndex = 36;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(30, 78);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(27, 13);
            this.lbl.TabIndex = 31;
            this.lbl.Text = "Tipo";
            // 
            // txtTipo
            // 
            this.txtTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipo.Enabled = false;
            this.txtTipo.Location = new System.Drawing.Point(224, 75);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtTipo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo.Properties.Appearance.Options.UseBackColor = true;
            this.txtTipo.Properties.Appearance.Options.UseFont = true;
            this.txtTipo.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtTipo.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtTipo.Properties.ContextImageOptions.SvgImage")));
            this.txtTipo.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.txtTipo.Properties.MaxLength = 50;
            this.txtTipo.Properties.ReadOnly = true;
            this.txtTipo.Properties.UseReadOnlyAppearance = false;
            this.txtTipo.Size = new System.Drawing.Size(551, 20);
            this.txtTipo.TabIndex = 36;
            this.txtTipo.EditValueChanged += new System.EventHandler(this.txtTipo_EditValueChanged);
            this.txtTipo.Click += new System.EventHandler(this.txtTipo_Click);
            this.txtTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPercentagem_KeyPress);
            // 
            // txtCodTipo
            // 
            this.txtCodTipo.Enabled = false;
            this.txtCodTipo.Location = new System.Drawing.Point(135, 75);
            this.txtCodTipo.Name = "txtCodTipo";
            this.txtCodTipo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtCodTipo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodTipo.Properties.Appearance.Options.UseBackColor = true;
            this.txtCodTipo.Properties.Appearance.Options.UseFont = true;
            this.txtCodTipo.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtCodTipo.Size = new System.Drawing.Size(73, 20);
            this.txtCodTipo.TabIndex = 34;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTipo);
            this.panel1.Controls.Add(this.txtSigla);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPercentagem);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.txtCodTipo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.lbl);
            this.panel1.Location = new System.Drawing.Point(12, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 235);
            this.panel1.TabIndex = 204;
            // 
            // frmImposto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 517);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmImposto";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imposto";
            this.Load += new System.EventHandler(this.frmImposto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentagem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSigla.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodTipo.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnSelecionar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem btnElimanr;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem btnNovo;
        private DevExpress.XtraBars.BarButtonItem btnsalvarFechar;
        private DevExpress.XtraBars.BarButtonItem btnFechar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtDescricao;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtPercentagem;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtSigla;
        private System.Windows.Forms.Label lbl;
        private DevExpress.XtraEditors.TextEdit txtTipo;
        private DevExpress.XtraEditors.TextEdit txtCodTipo;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnverListagem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.Panel panel1;
    }
}