namespace Folha.Presentation.Desktop.Forms.Armazens
{
    partial class FrmEditArmazens
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditArmazens));
            this.label24 = new System.Windows.Forms.Label();
            this.txtstockmax = new DevExpress.XtraEditors.TextEdit();
            this.txtstockmin = new DevExpress.XtraEditors.TextEdit();
            this.label22 = new System.Windows.Forms.Label();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnFechar = new DevExpress.XtraBars.BarButtonItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtstockmax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtstockmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.label24.Location = new System.Drawing.Point(11, 79);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(36, 16);
            this.label24.TabIndex = 215;
            this.label24.Text = "Max:";
            // 
            // txtstockmax
            // 
            this.txtstockmax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtstockmax.EditValue = "0";
            this.txtstockmax.Location = new System.Drawing.Point(62, 73);
            this.txtstockmax.Name = "txtstockmax";
            this.txtstockmax.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstockmax.Properties.Appearance.Options.UseFont = true;
            this.txtstockmax.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtstockmax.Size = new System.Drawing.Size(220, 22);
            this.txtstockmax.TabIndex = 212;
            // 
            // txtstockmin
            // 
            this.txtstockmin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtstockmin.EditValue = "0";
            this.txtstockmin.Location = new System.Drawing.Point(62, 33);
            this.txtstockmin.Name = "txtstockmin";
            this.txtstockmin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstockmin.Properties.Appearance.Options.UseFont = true;
            this.txtstockmin.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtstockmin.Size = new System.Drawing.Size(220, 22);
            this.txtstockmin.TabIndex = 211;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.label22.Location = new System.Drawing.Point(10, 36);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(33, 16);
            this.label22.TabIndex = 214;
            this.label22.Text = "Min:";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnSalvar,
            this.btnFechar,
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(325, 61);
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFechar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Caption = "Salvar e Fechar";
            this.btnSalvar.Id = 1;
            this.btnSalvar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvar.ImageOptions.SvgImage")));
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvar_ItemClick);
            // 
            // btnFechar
            // 
            this.btnFechar.Caption = "Fechar";
            this.btnFechar.Id = 2;
            this.btnFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFechar.ImageOptions.SvgImage")));
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFechar_ItemClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtstockmin);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.txtstockmax);
            this.panel1.Location = new System.Drawing.Point(13, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 141);
            this.panel1.TabIndex = 219;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // FrmEditArmazens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 224);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmEditArmazens";
            this.Ribbon = this.ribbonControl1;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Armazens";
            ((System.ComponentModel.ISupportInitialize)(this.txtstockmax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtstockmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label24;
        private DevExpress.XtraEditors.TextEdit txtstockmax;
        private DevExpress.XtraEditors.TextEdit txtstockmin;
        private System.Windows.Forms.Label label22;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnSalvar;
        private DevExpress.XtraBars.BarButtonItem btnFechar;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}