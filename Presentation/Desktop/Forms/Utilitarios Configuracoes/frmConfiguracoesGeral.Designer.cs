namespace Folha.Presentation.Desktop.Forms.Utilitarios_Configuracoes
{
    partial class frmConfiguracoesGeral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracoesGeral));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnSalvaFechar = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPagedados = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CkVenderSemStock = new DevExpress.XtraEditors.CheckEdit();
            this.ChLucroPos = new DevExpress.XtraEditors.CheckEdit();
            this.chcliente = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.navigationPagedados.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CkVenderSemStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChLucroPos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chcliente.Properties)).BeginInit();
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
            this.btnSalvaFechar,
            this.btnVoltar});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 4;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(918, 61);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Caption = "Salvar";
            this.btnSalvar.Id = 1;
            this.btnSalvar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvar.ImageOptions.SvgImage")));
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvar_ItemClick);
            // 
            // btnSalvaFechar
            // 
            this.btnSalvaFechar.Caption = "Salvar";
            this.btnSalvaFechar.Id = 2;
            this.btnSalvaFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvaFechar.ImageOptions.SvgImage")));
            this.btnSalvaFechar.Name = "btnSalvaFechar";
            this.btnSalvaFechar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Opções";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalvar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalvaFechar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Appearance.BackColor = System.Drawing.Color.White;
            this.navigationFrame1.Appearance.Options.UseBackColor = true;
            this.navigationFrame1.Controls.Add(this.navigationPagedados);
            this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame1.Location = new System.Drawing.Point(0, 61);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPagedados});
            this.navigationFrame1.SelectedPage = this.navigationPagedados;
            this.navigationFrame1.Size = new System.Drawing.Size(918, 527);
            this.navigationFrame1.TabIndex = 31;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPagedados
            // 
            this.navigationPagedados.Controls.Add(this.groupBox2);
            this.navigationPagedados.Controls.Add(this.groupBox1);
            this.navigationPagedados.Name = "navigationPagedados";
            this.navigationPagedados.Size = new System.Drawing.Size(918, 527);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkEdit1);
            this.groupBox2.Controls.Add(this.checkEdit2);
            this.groupBox2.Controls.Add(this.checkEdit3);
            this.groupBox2.Location = new System.Drawing.Point(26, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(864, 177);
            this.groupBox2.TabIndex = 154;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Outras configurações futuras";
            this.groupBox2.Visible = false;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(31, 30);
            this.checkEdit1.MenuManager = this.ribbon;
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.Caption = "Permitir vendas de produtos com insuficiencia de Stock";
            this.checkEdit1.Size = new System.Drawing.Size(359, 20);
            this.checkEdit1.TabIndex = 20;
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(31, 63);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit2.Properties.Appearance.Options.UseFont = true;
            this.checkEdit2.Properties.Caption = "Lançar credito do cliente";
            this.checkEdit2.Size = new System.Drawing.Size(255, 20);
            this.checkEdit2.TabIndex = 17;
            // 
            // checkEdit3
            // 
            this.checkEdit3.Location = new System.Drawing.Point(31, 100);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit3.Properties.Appearance.Options.UseFont = true;
            this.checkEdit3.Properties.Caption = "Permitir Imprimir o  Nome de Cliente na Factura ";
            this.checkEdit3.Size = new System.Drawing.Size(359, 20);
            this.checkEdit3.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.CkVenderSemStock);
            this.groupBox1.Controls.Add(this.ChLucroPos);
            this.groupBox1.Controls.Add(this.chcliente);
            this.groupBox1.Location = new System.Drawing.Point(26, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(864, 177);
            this.groupBox1.TabIndex = 153;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vendas";
            // 
            // CkVenderSemStock
            // 
            this.CkVenderSemStock.Location = new System.Drawing.Point(31, 38);
            this.CkVenderSemStock.MenuManager = this.ribbon;
            this.CkVenderSemStock.Name = "CkVenderSemStock";
            this.CkVenderSemStock.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CkVenderSemStock.Properties.Appearance.Options.UseFont = true;
            this.CkVenderSemStock.Properties.Caption = "Permitir vendas de produtos com insuficiencia de Stock";
            this.CkVenderSemStock.Size = new System.Drawing.Size(359, 20);
            this.CkVenderSemStock.TabIndex = 20;
            // 
            // ChLucroPos
            // 
            this.ChLucroPos.Location = new System.Drawing.Point(31, 71);
            this.ChLucroPos.Name = "ChLucroPos";
            this.ChLucroPos.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChLucroPos.Properties.Appearance.Options.UseFont = true;
            this.ChLucroPos.Properties.Caption = "Lançar credito do cliente";
            this.ChLucroPos.Size = new System.Drawing.Size(255, 20);
            this.ChLucroPos.TabIndex = 17;
            // 
            // chcliente
            // 
            this.chcliente.Location = new System.Drawing.Point(31, 108);
            this.chcliente.Name = "chcliente";
            this.chcliente.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcliente.Properties.Appearance.Options.UseFont = true;
            this.chcliente.Properties.Caption = "Permitir Imprimir o  Nome de Cliente na Factura ";
            this.chcliente.Size = new System.Drawing.Size(359, 20);
            this.chcliente.TabIndex = 15;
            // 
            // frmConfiguracoesGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 588);
            this.Controls.Add(this.navigationFrame1);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfiguracoesGeral";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracões Geral";
            this.Load += new System.EventHandler(this.frmConfiguracoesGeral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.navigationPagedados.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CkVenderSemStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChLucroPos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chcliente.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnSalvar;
        private DevExpress.XtraBars.BarButtonItem btnSalvaFechar;
        private DevExpress.XtraBars.BarButtonItem btnVoltar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPagedados;
        private DevExpress.XtraEditors.CheckEdit chcliente;
        private DevExpress.XtraEditors.CheckEdit ChLucroPos;
        private DevExpress.XtraEditors.CheckEdit CkVenderSemStock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
    }
}