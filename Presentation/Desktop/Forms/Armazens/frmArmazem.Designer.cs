namespace Folha.Presentation.Desktop.Separadores.Armazens
{
    partial class frmArmazens
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArmazens));
            this.label1 = new System.Windows.Forms.Label();
            this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSarlvarFechar = new DevExpress.XtraBars.BarButtonItem();
            this.btnFechar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem6 = new DevExpress.XtraBars.BarEditItem();
            this.btnNovo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.txtDescricao = new DevExpress.XtraEditors.TextEdit();
            this.txtcodigo = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Descrição:";
            // 
            // barButtonItem15
            // 
            this.barButtonItem15.Id = 17;
            this.barButtonItem15.Name = "barButtonItem15";
            // 
            // ribbon
            // 
            this.ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnSarlvarFechar,
            this.btnFechar,
            this.barButtonItem4,
            this.barEditItem1,
            this.barEditItem2,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barEditItem6,
            this.btnNovo,
            this.barButtonItem8,
            this.barButtonItem9,
            this.barButtonItem10,
            this.barButtonItem11,
            this.barButtonItem12,
            this.barButtonItem13,
            this.barButtonItem14,
            this.barButtonItem16,
            this.barButtonItem17});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 20;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonCaptionAlignment = DevExpress.XtraBars.Ribbon.RibbonCaptionAlignment.Center;
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice;
            this.ribbon.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages;
            this.ribbon.Size = new System.Drawing.Size(547, 113);
            // 
            // btnSarlvarFechar
            // 
            this.btnSarlvarFechar.Caption = "Salvar e Fechar";
            this.btnSarlvarFechar.Id = 2;
            this.btnSarlvarFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSarlvarFechar.ImageOptions.SvgImage")));
            this.btnSarlvarFechar.Name = "btnSarlvarFechar";
            this.btnSarlvarFechar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSarlvarFechar_ItemClick);
            // 
            // btnFechar
            // 
            this.btnFechar.Caption = "Voltar";
            this.btnFechar.Id = 3;
            this.btnFechar.ImageOptions.LargeImage = global::Folha.Presentation.Desktop.Properties.Resources.Voltar;
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFechar_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = null;
            this.barEditItem1.Id = 5;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // barEditItem2
            // 
            this.barEditItem2.AutoFillWidthInMenu = DevExpress.Utils.DefaultBoolean.True;
            this.barEditItem2.Edit = null;
            this.barEditItem2.Id = 6;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Adicionar";
            this.barButtonItem5.Id = 7;
            this.barButtonItem5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.Image")));
            this.barButtonItem5.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.LargeImage")));
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Canselar";
            this.barButtonItem6.Id = 8;
            this.barButtonItem6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.Image")));
            this.barButtonItem6.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.LargeImage")));
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barEditItem6
            // 
            this.barEditItem6.AutoFillWidthInMenu = DevExpress.Utils.DefaultBoolean.True;
            this.barEditItem6.Edit = null;
            this.barEditItem6.Id = 9;
            this.barEditItem6.Name = "barEditItem6";
            // 
            // btnNovo
            // 
            this.btnNovo.Caption = "Novo";
            this.btnNovo.Id = 10;
            this.btnNovo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNovo.ImageOptions.SvgImage")));
            this.btnNovo.Name = "btnNovo";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Id = 11;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Id = 12;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "Editar";
            this.barButtonItem10.Id = 13;
            this.barButtonItem10.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem10.ImageOptions.SvgImage")));
            this.barButtonItem10.Name = "barButtonItem10";
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "barButtonItem11";
            this.barButtonItem11.Id = 14;
            this.barButtonItem11.Name = "barButtonItem11";
            // 
            // barButtonItem12
            // 
            this.barButtonItem12.Caption = "Eliminar";
            this.barButtonItem12.Id = 15;
            this.barButtonItem12.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem12.ImageOptions.SvgImage")));
            this.barButtonItem12.Name = "barButtonItem12";
            // 
            // barButtonItem13
            // 
            this.barButtonItem13.Caption = "Imprimir";
            this.barButtonItem13.Id = 16;
            this.barButtonItem13.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem13.ImageOptions.SvgImage")));
            this.barButtonItem13.Name = "barButtonItem13";
            // 
            // barButtonItem14
            // 
            this.barButtonItem14.Id = 17;
            this.barButtonItem14.Name = "barButtonItem14";
            // 
            // barButtonItem16
            // 
            this.barButtonItem16.Id = 18;
            this.barButtonItem16.Name = "barButtonItem16";
            // 
            // barButtonItem17
            // 
            this.barButtonItem17.Caption = "barButtonItem17";
            this.barButtonItem17.Id = 19;
            this.barButtonItem17.Name = "barButtonItem17";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSarlvarFechar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFechar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(187, 140);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Properties.Appearance.Options.UseFont = true;
            this.txtDescricao.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtDescricao.Size = new System.Drawing.Size(328, 22);
            this.txtDescricao.TabIndex = 11;
            // 
            // txtcodigo
            // 
            this.txtcodigo.Enabled = false;
            this.txtcodigo.Location = new System.Drawing.Point(88, 140);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigo.Properties.Appearance.Options.UseFont = true;
            this.txtcodigo.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtcodigo.Size = new System.Drawing.Size(93, 22);
            this.txtcodigo.TabIndex = 15;
            // 
            // frmArmazens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 238);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmArmazens";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Armazem";
            this.Load += new System.EventHandler(this.frmArmazens_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescricao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem15;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnSarlvarFechar;
        private DevExpress.XtraBars.BarButtonItem btnFechar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarEditItem barEditItem6;
        private DevExpress.XtraBars.BarButtonItem btnNovo;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        private DevExpress.XtraBars.BarButtonItem barButtonItem13;
        private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        private DevExpress.XtraBars.BarButtonItem barButtonItem16;
        private DevExpress.XtraBars.BarButtonItem barButtonItem17;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.TextEdit txtDescricao;
        private DevExpress.XtraEditors.TextEdit txtcodigo;
    }
}