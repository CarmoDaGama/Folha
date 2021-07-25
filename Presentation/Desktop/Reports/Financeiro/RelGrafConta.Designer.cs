namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    partial class RelGrafConta
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel3 = new DevExpress.XtraReports.UI.XRPanel();
            this.lbUsuario = new DevExpress.XtraReports.UI.XRLabel();
            this.lbfim = new DevExpress.XtraReports.UI.XRLabel();
            this.lbinicio = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.LbPagina = new DevExpress.XtraReports.UI.XRPageInfo();
            this.lblDescricao = new DevExpress.XtraReports.UI.XRLabel();
            this.lbDataImprecaoRotolo = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport1});
            this.TopMargin.HeightF = 117.17F;
            this.TopMargin.Name = "TopMargin";
            // 
            // xrSubreport1
            // 
            this.xrSubreport1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.SizeF = new System.Drawing.SizeF(775F, 117.17F);
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.LbPagina,
            this.lblDescricao,
            this.lbDataImprecaoRotolo});
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            // 
            // xrChart1
            // 
            this.xrChart1.BorderColor = System.Drawing.Color.Black;
            this.xrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.False;
            this.xrChart1.Diagram = xyDiagram1;
            this.xrChart1.Legend.Name = "Default Legend";
            this.xrChart1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrChart1.Name = "xrChart1";
            series1.ArgumentDataMember = "Conta";
            series1.Name = "Saldo";
            series1.ValueDataMembersSerializable = "Saldo";
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.xrChart1.SizeF = new System.Drawing.SizeF(774.9999F, 280.8567F);
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel1});
            this.ReportHeader.HeightF = 152.2067F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(Folha.Domain.ViewModels.Report.SaldoBancoViewModel);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrChart1});
            this.PageHeader.HeightF = 321.5417F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrPanel1
            // 
            this.xrPanel1.BorderColor = System.Drawing.Color.DarkGray;
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3,
            this.xrLabel12,
            this.xrPanel3});
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(10.00004F, 10.00001F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(759F, 129F);
            this.xrPanel1.StylePriority.UseBorderColor = false;
            this.xrPanel1.StylePriority.UseBorderDashStyle = false;
            this.xrPanel1.StylePriority.UseBorders = false;
            // 
            // xrTable3
            // 
            this.xrTable3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(142)))), ((int)(((byte)(217)))));
            this.xrTable3.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.xrTable3.ForeColor = System.Drawing.Color.White;
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(10F, 10.00003F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable3.SizeF = new System.Drawing.SizeF(253.2918F, 23F);
            this.xrTable3.StylePriority.UseBackColor = false;
            this.xrTable3.StylePriority.UseBorderColor = false;
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            this.xrTable3.StylePriority.UseForeColor = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell4.BorderColor = System.Drawing.Color.Transparent;
            this.xrTableCell4.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell4.Font = new System.Drawing.Font("Consolas", 12F);
            this.xrTableCell4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseBackColor = false;
            this.xrTableCell4.StylePriority.UseBorderColor = false;
            this.xrTableCell4.StylePriority.UseBorders = false;
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseForeColor = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "Evolução de Contas bancárias";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell4.Weight = 174.13988526255D;
            // 
            // xrLabel12
            // 
            this.xrLabel12.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel12.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(8.999998F, 33.00002F);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(282.7917F, 23F);
            this.xrLabel12.StylePriority.UseBorderColor = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseForeColor = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Este documento não serve de factura";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPanel3
            // 
            this.xrPanel3.BackColor = System.Drawing.Color.White;
            this.xrPanel3.BorderColor = System.Drawing.Color.DarkGray;
            this.xrPanel3.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrPanel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbUsuario,
            this.lbfim,
            this.lbinicio,
            this.xrLabel9,
            this.xrLabel13,
            this.xrLabel11});
            this.xrPanel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 83.80302F);
            this.xrPanel3.Name = "xrPanel3";
            this.xrPanel3.SizeF = new System.Drawing.SizeF(759F, 45.19702F);
            this.xrPanel3.StylePriority.UseBackColor = false;
            this.xrPanel3.StylePriority.UseBorderColor = false;
            this.xrPanel3.StylePriority.UseBorderDashStyle = false;
            this.xrPanel3.StylePriority.UseBorders = false;
            // 
            // lbUsuario
            // 
            this.lbUsuario.BorderColor = System.Drawing.Color.Transparent;
            this.lbUsuario.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbUsuario.LocationFloat = new DevExpress.Utils.PointFloat(262.0401F, 22.99995F);
            this.lbUsuario.Multiline = true;
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbUsuario.SizeF = new System.Drawing.SizeF(483.3387F, 19F);
            this.lbUsuario.StylePriority.UseBorderColor = false;
            this.lbUsuario.StylePriority.UseFont = false;
            this.lbUsuario.StylePriority.UseForeColor = false;
            this.lbUsuario.StylePriority.UseTextAlignment = false;
            this.lbUsuario.Text = "Usuário:";
            this.lbUsuario.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbfim
            // 
            this.lbfim.BorderColor = System.Drawing.Color.Transparent;
            this.lbfim.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbfim.LocationFloat = new DevExpress.Utils.PointFloat(134.4104F, 22.99997F);
            this.lbfim.Multiline = true;
            this.lbfim.Name = "lbfim";
            this.lbfim.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbfim.SizeF = new System.Drawing.SizeF(112.8329F, 18.99999F);
            this.lbfim.StylePriority.UseBorderColor = false;
            this.lbfim.StylePriority.UseFont = false;
            this.lbfim.StylePriority.UseForeColor = false;
            this.lbfim.StylePriority.UseTextAlignment = false;
            this.lbfim.Text = "Data Final";
            this.lbfim.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbinicio
            // 
            this.lbinicio.BorderColor = System.Drawing.Color.Transparent;
            this.lbinicio.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbinicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbinicio.LocationFloat = new DevExpress.Utils.PointFloat(8.999998F, 22.99997F);
            this.lbinicio.Multiline = true;
            this.lbinicio.Name = "lbinicio";
            this.lbinicio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbinicio.SizeF = new System.Drawing.SizeF(112.8329F, 18.99999F);
            this.lbinicio.StylePriority.UseBorderColor = false;
            this.lbinicio.StylePriority.UseFont = false;
            this.lbinicio.StylePriority.UseForeColor = false;
            this.lbinicio.StylePriority.UseTextAlignment = false;
            this.lbinicio.Text = "Data Inicial:";
            this.lbinicio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel9.Font = new System.Drawing.Font("Consolas", 7F);
            this.xrLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(262.0401F, 4.999954F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(483.3387F, 17.99999F);
            this.xrLabel9.StylePriority.UseBorderColor = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseForeColor = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "CAIXA";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel13.Font = new System.Drawing.Font("Consolas", 7F);
            this.xrLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(134.4105F, 5.000015F);
            this.xrLabel13.Multiline = true;
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(112.8329F, 17.99997F);
            this.xrLabel13.StylePriority.UseBorderColor = false;
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseForeColor = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "DATA FINAL";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel11.Font = new System.Drawing.Font("Consolas", 7F);
            this.xrLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(9.000013F, 5.000015F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(112.8329F, 17.99997F);
            this.xrLabel11.StylePriority.UseBorderColor = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseForeColor = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "DATA INICIAL";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // LbPagina
            // 
            this.LbPagina.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbPagina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LbPagina.LocationFloat = new DevExpress.Utils.PointFloat(680.1625F, 18.5833F);
            this.LbPagina.Name = "LbPagina";
            this.LbPagina.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LbPagina.SizeF = new System.Drawing.SizeF(94.83752F, 13.00004F);
            this.LbPagina.StylePriority.UseFont = false;
            this.LbPagina.StylePriority.UseForeColor = false;
            this.LbPagina.StylePriority.UseTextAlignment = false;
            this.LbPagina.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblDescricao
            // 
            this.lblDescricao.BorderColor = System.Drawing.Color.DimGray;
            this.lblDescricao.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescricao.LocationFloat = new DevExpress.Utils.PointFloat(0F, 31.58328F);
            this.lblDescricao.Multiline = true;
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDescricao.SizeF = new System.Drawing.SizeF(775.9999F, 12.58335F);
            this.lblDescricao.StylePriority.UseBorderColor = false;
            this.lblDescricao.StylePriority.UseFont = false;
            this.lblDescricao.StylePriority.UseForeColor = false;
            this.lblDescricao.StylePriority.UseTextAlignment = false;
            this.lblDescricao.Text = "Processado por programa certificado nº 0000/AGT/2020  FOLHA SOFTWARE";
            this.lblDescricao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbDataImprecaoRotolo
            // 
            this.lbDataImprecaoRotolo.BorderColor = System.Drawing.Color.DimGray;
            this.lbDataImprecaoRotolo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDataImprecaoRotolo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbDataImprecaoRotolo.LocationFloat = new DevExpress.Utils.PointFloat(295.8236F, 18.99999F);
            this.lbDataImprecaoRotolo.Multiline = true;
            this.lbDataImprecaoRotolo.Name = "lbDataImprecaoRotolo";
            this.lbDataImprecaoRotolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbDataImprecaoRotolo.SizeF = new System.Drawing.SizeF(182.8956F, 12.58335F);
            this.lbDataImprecaoRotolo.StylePriority.UseBorderColor = false;
            this.lbDataImprecaoRotolo.StylePriority.UseFont = false;
            this.lbDataImprecaoRotolo.StylePriority.UseForeColor = false;
            this.lbDataImprecaoRotolo.StylePriority.UseTextAlignment = false;
            this.lbDataImprecaoRotolo.Text = " Data Impressão 10/09/2020";
            this.lbDataImprecaoRotolo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // RelGrafConta
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader,
            this.PageHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(38, 36, 117, 100);
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRSubreport xrSubreport1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRChart xrChart1;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRTable xrTable3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRPanel xrPanel3;
        private DevExpress.XtraReports.UI.XRLabel lbUsuario;
        private DevExpress.XtraReports.UI.XRLabel lbfim;
        private DevExpress.XtraReports.UI.XRLabel lbinicio;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRPageInfo LbPagina;
        private DevExpress.XtraReports.UI.XRLabel lblDescricao;
        private DevExpress.XtraReports.UI.XRLabel lbDataImprecaoRotolo;
    }
}
