namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    partial class frmDadosContaBancaria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDadosContaBancaria));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSvFechar = new DevExpress.XtraBars.BarButtonItem();
            this.btnFechar = new DevExpress.XtraBars.BarButtonItem();
            this.btnVerLista = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.txtBanco = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodBanco = new DevExpress.XtraEditors.TextEdit();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNatureza = new DevExpress.XtraEditors.TextEdit();
            this.txtIban = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSequencia = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSwift = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.panelCampos = new System.Windows.Forms.Panel();
            this.txtCodConta = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBanco.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodBanco.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNatureza.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSequencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSwift.Properties)).BeginInit();
            this.panelCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodConta.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bbiPrintPreview,
            this.bsiRecordsCount,
            this.bbiEdit,
            this.btnVoltar,
            this.bbiRefresh,
            this.barButtonItem1,
            this.btnSvFechar,
            this.btnFechar,
            this.btnVerLista,
            this.barButtonItem3});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 25;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl.Size = new System.Drawing.Size(822, 61);
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "Print Preview";
            this.bbiPrintPreview.Id = 14;
            this.bbiPrintPreview.ImageOptions.ImageUri.Uri = "Preview";
            this.bbiPrintPreview.Name = "bbiPrintPreview";
            this.bbiPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrintPreview_ItemClick);
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "Edit";
            this.bbiEdit.Id = 17;
            this.bbiEdit.ImageOptions.ImageUri.Uri = "Edit";
            this.bbiEdit.Name = "bbiEdit";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Voltar";
            this.btnVoltar.Id = 18;
            this.btnVoltar.ImageOptions.ImageUri.Uri = "Delete";
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVoltar_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "Refresh";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.ImageUri.Uri = "Refresh";
            this.bbiRefresh.Name = "bbiRefresh";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Salvar e Fechar";
            this.barButtonItem1.Id = 20;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnSvFechar
            // 
            this.btnSvFechar.Caption = "Salvar";
            this.btnSvFechar.Id = 21;
            this.btnSvFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSvFechar.ImageOptions.SvgImage")));
            this.btnSvFechar.Name = "btnSvFechar";
            this.btnSvFechar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSvFechar_ItemClick);
            // 
            // btnFechar
            // 
            this.btnFechar.Caption = "Fechar";
            this.btnFechar.Id = 22;
            this.btnFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFechar.ImageOptions.SvgImage")));
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnFechar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFechar_ItemClick);
            // 
            // btnVerLista
            // 
            this.btnVerLista.Caption = "Ver Listagem";
            this.btnVerLista.Id = 23;
            this.btnVerLista.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVerLista.ImageOptions.SvgImage")));
            this.btnVerLista.Name = "btnVerLista";
            this.btnVerLista.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVerLista_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Limpar";
            this.barButtonItem3.Id = 24;
            this.barButtonItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem3.ImageOptions.SvgImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Opções";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSvFechar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVerLista);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFechar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // txtBanco
            // 
            this.txtBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBanco.EditValue = "";
            this.txtBanco.Location = new System.Drawing.Point(198, 21);
            this.txtBanco.MenuManager = this.ribbonControl;
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtBanco.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtBanco.Properties.ContextImageOptions.SvgImage")));
            this.txtBanco.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            this.txtBanco.Size = new System.Drawing.Size(574, 20);
            this.txtBanco.TabIndex = 111;
            this.txtBanco.Click += new System.EventHandler(this.txtBanco_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 110;
            this.label1.Text = "Banco";
            // 
            // txtCodBanco
            // 
            this.txtCodBanco.EditValue = "";
            this.txtCodBanco.Enabled = false;
            this.txtCodBanco.Location = new System.Drawing.Point(90, 21);
            this.txtCodBanco.MenuManager = this.ribbonControl;
            this.txtCodBanco.Name = "txtCodBanco";
            this.txtCodBanco.Size = new System.Drawing.Size(95, 20);
            this.txtCodBanco.TabIndex = 109;
            // 
            // txtNumero
            // 
            this.txtNumero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumero.EditValue = "";
            this.txtNumero.Location = new System.Drawing.Point(198, 58);
            this.txtNumero.MenuManager = this.ribbonControl;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.MaxLength = 25;
            this.txtNumero.Size = new System.Drawing.Size(574, 20);
            this.txtNumero.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 114;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 116;
            this.label3.Text = "Número";
            // 
            // txtNatureza
            // 
            this.txtNatureza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNatureza.EditValue = "";
            this.txtNatureza.Location = new System.Drawing.Point(90, 96);
            this.txtNatureza.MenuManager = this.ribbonControl;
            this.txtNatureza.Name = "txtNatureza";
            this.txtNatureza.Properties.MaxLength = 10;
            this.txtNatureza.Size = new System.Drawing.Size(682, 20);
            this.txtNatureza.TabIndex = 117;
            // 
            // txtIban
            // 
            this.txtIban.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIban.EditValue = "";
            this.txtIban.Location = new System.Drawing.Point(90, 165);
            this.txtIban.MenuManager = this.ribbonControl;
            this.txtIban.Name = "txtIban";
            this.txtIban.Properties.MaxLength = 25;
            this.txtIban.Size = new System.Drawing.Size(682, 20);
            this.txtIban.TabIndex = 118;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 119;
            this.label4.Text = "Natureza";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 120;
            this.label5.Text = "Sequência";
            // 
            // txtSequencia
            // 
            this.txtSequencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSequencia.EditValue = "";
            this.txtSequencia.Location = new System.Drawing.Point(90, 132);
            this.txtSequencia.MenuManager = this.ribbonControl;
            this.txtSequencia.Name = "txtSequencia";
            this.txtSequencia.Properties.MaxLength = 10;
            this.txtSequencia.Size = new System.Drawing.Size(682, 20);
            this.txtSequencia.TabIndex = 122;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 121;
            this.label6.Text = "Iban:";
            // 
            // txtSwift
            // 
            this.txtSwift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSwift.EditValue = "";
            this.txtSwift.Location = new System.Drawing.Point(90, 203);
            this.txtSwift.MenuManager = this.ribbonControl;
            this.txtSwift.Name = "txtSwift";
            this.txtSwift.Properties.MaxLength = 25;
            this.txtSwift.Size = new System.Drawing.Size(682, 20);
            this.txtSwift.TabIndex = 124;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 123;
            this.label7.Text = "Swift:";
            // 
            // panelCampos
            // 
            this.panelCampos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCampos.BackColor = System.Drawing.Color.White;
            this.panelCampos.Controls.Add(this.label1);
            this.panelCampos.Controls.Add(this.label2);
            this.panelCampos.Controls.Add(this.txtCodConta);
            this.panelCampos.Controls.Add(this.txtCodBanco);
            this.panelCampos.Controls.Add(this.txtSwift);
            this.panelCampos.Controls.Add(this.txtBanco);
            this.panelCampos.Controls.Add(this.label3);
            this.panelCampos.Controls.Add(this.label7);
            this.panelCampos.Controls.Add(this.txtNumero);
            this.panelCampos.Controls.Add(this.txtSequencia);
            this.panelCampos.Controls.Add(this.label6);
            this.panelCampos.Controls.Add(this.txtNatureza);
            this.panelCampos.Controls.Add(this.txtIban);
            this.panelCampos.Controls.Add(this.label4);
            this.panelCampos.Controls.Add(this.label5);
            this.panelCampos.Location = new System.Drawing.Point(15, 68);
            this.panelCampos.Name = "panelCampos";
            this.panelCampos.Size = new System.Drawing.Size(793, 249);
            this.panelCampos.TabIndex = 126;
            // 
            // txtCodConta
            // 
            this.txtCodConta.EditValue = "";
            this.txtCodConta.Enabled = false;
            this.txtCodConta.Location = new System.Drawing.Point(90, 58);
            this.txtCodConta.Name = "txtCodConta";
            this.txtCodConta.Size = new System.Drawing.Size(95, 20);
            this.txtCodConta.TabIndex = 109;
            // 
            // frmDadosContaBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 444);
            this.ControlBox = false;
            this.Controls.Add(this.panelCampos);
            this.Controls.Add(this.ribbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDadosContaBancaria";
            this.Ribbon = this.ribbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dados da Conta Bancária";
            this.Load += new System.EventHandler(this.frmDadosContaBancaria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBanco.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodBanco.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNatureza.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSequencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSwift.Properties)).EndInit();
            this.panelCampos.ResumeLayout(false);
            this.panelCampos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodConta.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiPrintPreview;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem btnVoltar;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraEditors.TextEdit txtBanco;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtCodBanco;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtNatureza;
        private DevExpress.XtraEditors.TextEdit txtIban;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtSequencia;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtSwift;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnSvFechar;
        private DevExpress.XtraBars.BarButtonItem btnFechar;
        private DevExpress.XtraBars.BarButtonItem btnVerLista;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.Panel panelCampos;
        private DevExpress.XtraEditors.TextEdit txtCodConta;
    }
}