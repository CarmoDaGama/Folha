namespace Folha.Presentation.Desktop.Reports.Documentos
{
    partial class RelGrafTotOperacoes
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
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lbfim = new DevExpress.XtraReports.UI.XRLabel();
            this.lbinicio = new DevExpress.XtraReports.UI.XRLabel();
            this.lbUsuario = new DevExpress.XtraReports.UI.XRLabel();
            this.lbCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.lbDataImprecaoRotolo = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDescricao = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrPanel2 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport1});
            this.TopMargin.HeightF = 188.0034F;
            this.TopMargin.Name = "TopMargin";
            // 
            // xrSubreport1
            // 
            this.xrSubreport1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 27.08333F);
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.SizeF = new System.Drawing.SizeF(775F, 160.92F);
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 44.92671F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel1});
            this.ReportHeader.HeightF = 165.06F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lbfim
            // 
            this.lbfim.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbfim.LocationFloat = new DevExpress.Utils.PointFloat(134.4105F, 22.99998F);
            this.lbfim.Multiline = true;
            this.lbfim.Name = "lbfim";
            this.lbfim.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbfim.SizeF = new System.Drawing.SizeF(112.8329F, 18.99999F);
            this.lbfim.StylePriority.UseFont = false;
            this.lbfim.StylePriority.UseForeColor = false;
            this.lbfim.StylePriority.UseTextAlignment = false;
            this.lbfim.Text = "Data Final";
            this.lbfim.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbinicio
            // 
            this.lbinicio.Font = new System.Drawing.Font("Consolas", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbinicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbinicio.LocationFloat = new DevExpress.Utils.PointFloat(8.999998F, 22.99989F);
            this.lbinicio.Multiline = true;
            this.lbinicio.Name = "lbinicio";
            this.lbinicio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbinicio.SizeF = new System.Drawing.SizeF(112.8329F, 18.99999F);
            this.lbinicio.StylePriority.UseFont = false;
            this.lbinicio.StylePriority.UseForeColor = false;
            this.lbinicio.StylePriority.UseTextAlignment = false;
            this.lbinicio.Text = "Data Inicial:";
            this.lbinicio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbUsuario
            // 
            this.lbUsuario.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.lbUsuario.LocationFloat = new DevExpress.Utils.PointFloat(508.9151F, 22.99989F);
            this.lbUsuario.Multiline = true;
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbUsuario.SizeF = new System.Drawing.SizeF(236.4637F, 19F);
            this.lbUsuario.StylePriority.UseFont = false;
            this.lbUsuario.StylePriority.UseForeColor = false;
            this.lbUsuario.StylePriority.UseTextAlignment = false;
            this.lbUsuario.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbCliente
            // 
            this.lbCliente.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbCliente.ForeColor = System.Drawing.Color.DimGray;
            this.lbCliente.LocationFloat = new DevExpress.Utils.PointFloat(261.1347F, 22.99989F);
            this.lbCliente.Multiline = true;
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbCliente.SizeF = new System.Drawing.SizeF(236.7912F, 18.99998F);
            this.lbCliente.StylePriority.UseFont = false;
            this.lbCliente.StylePriority.UseForeColor = false;
            this.lbCliente.StylePriority.UseTextAlignment = false;
            this.lbCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrChart1});
            this.PageHeader.HeightF = 292.1667F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Angle = 90F;
            this.xrLabel4.Font = new System.Drawing.Font("Consolas", 12F);
            this.xrLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0.0001430511F, 0F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(31.24986F, 254.7916F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseForeColor = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Total";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
            this.xrChart1.LocationFloat = new DevExpress.Utils.PointFloat(31.24998F, 0F);
            this.xrChart1.Name = "xrChart1";
            this.xrChart1.PaletteName = "Blue Green";
            series1.ArgumentDataMember = "Documento";
            series1.Name = "Total";
            series1.QualitativeSummaryOptions.SummaryFunction = "SUM([Total])";
            series1.ValueDataMembersSerializable = "Total";
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.xrChart1.SizeF = new System.Drawing.SizeF(743.75F, 254.79F);
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(Folha.Domain.ViewModels.Report.RelOpercoesViewModel);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbDataImprecaoRotolo,
            this.lblDescricao});
            this.ReportFooter.HeightF = 72.01004F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // lbDataImprecaoRotolo
            // 
            this.lbDataImprecaoRotolo.BorderColor = System.Drawing.Color.DimGray;
            this.lbDataImprecaoRotolo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDataImprecaoRotolo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbDataImprecaoRotolo.LocationFloat = new DevExpress.Utils.PointFloat(281.645F, 20.04166F);
            this.lbDataImprecaoRotolo.Multiline = true;
            this.lbDataImprecaoRotolo.Name = "lbDataImprecaoRotolo";
            this.lbDataImprecaoRotolo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbDataImprecaoRotolo.SizeF = new System.Drawing.SizeF(175.604F, 12.58335F);
            this.lbDataImprecaoRotolo.StylePriority.UseBorderColor = false;
            this.lbDataImprecaoRotolo.StylePriority.UseFont = false;
            this.lbDataImprecaoRotolo.StylePriority.UseForeColor = false;
            this.lbDataImprecaoRotolo.Text = " Data Impressão 10/09/2020";
            // 
            // lblDescricao
            // 
            this.lblDescricao.BorderColor = System.Drawing.Color.DimGray;
            this.lblDescricao.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescricao.LocationFloat = new DevExpress.Utils.PointFloat(134.6361F, 32.62501F);
            this.lblDescricao.Multiline = true;
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDescricao.SizeF = new System.Drawing.SizeF(426.8195F, 12.58335F);
            this.lblDescricao.StylePriority.UseBorderColor = false;
            this.lblDescricao.StylePriority.UseFont = false;
            this.lblDescricao.StylePriority.UseForeColor = false;
            this.lblDescricao.Text = "Processado por programa certificado nº 0000/AGT/2020  FOLHA SOFTWARE";
            // 
            // xrPanel1
            // 
            this.xrPanel1.BorderColor = System.Drawing.Color.DarkGray;
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.xrLabel10,
            this.xrPanel2});
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(10.00004F, 10.00001F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(759F, 129F);
            this.xrPanel1.StylePriority.UseBorderColor = false;
            this.xrPanel1.StylePriority.UseBorderDashStyle = false;
            this.xrPanel1.StylePriority.UseBorders = false;
            // 
            // xrPanel2
            // 
            this.xrPanel2.BackColor = System.Drawing.Color.White;
            this.xrPanel2.BorderColor = System.Drawing.Color.DarkGray;
            this.xrPanel2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.xrPanel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbUsuario,
            this.lbCliente,
            this.lbfim,
            this.lbinicio,
            this.xrLabel9,
            this.xrLabel26,
            this.xrLabel13,
            this.xrLabel11});
            this.xrPanel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 83.80302F);
            this.xrPanel2.Name = "xrPanel2";
            this.xrPanel2.SizeF = new System.Drawing.SizeF(759F, 45.19702F);
            this.xrPanel2.StylePriority.UseBackColor = false;
            this.xrPanel2.StylePriority.UseBorderColor = false;
            this.xrPanel2.StylePriority.UseBorderDashStyle = false;
            this.xrPanel2.StylePriority.UseBorders = false;
            // 
            // xrLabel9
            // 
            this.xrLabel9.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel9.Font = new System.Drawing.Font("Consolas", 7F);
            this.xrLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(508.9151F, 4.999954F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(236.4637F, 17.99999F);
            this.xrLabel9.StylePriority.UseBorderColor = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseForeColor = false;
            this.xrLabel9.Text = "CAIXA";
            // 
            // xrLabel26
            // 
            this.xrLabel26.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel26.Font = new System.Drawing.Font("Consolas", 7F);
            this.xrLabel26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(261.1347F, 4.999924F);
            this.xrLabel26.Multiline = true;
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(236.7911F, 18F);
            this.xrLabel26.StylePriority.UseBorderColor = false;
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseForeColor = false;
            this.xrLabel26.Text = "ENTIDADE";
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
            this.xrLabel13.Text = "DATA FINAL";
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
            // xrLabel10
            // 
            this.xrLabel10.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel10.Font = new System.Drawing.Font("Consolas", 12F);
            this.xrLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(8.999998F, 10F);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(253.2918F, 23F);
            this.xrLabel10.StylePriority.UseBorderColor = false;
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseForeColor = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Totalizadores de Documento";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(8.999998F, 33.00002F);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(282.7917F, 23F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseForeColor = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Este documento não serve de factura";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // RelGrafTotOperacoes
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(38, 36, 188, 45);
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRSubreport xrSubreport1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel lbfim;
        private DevExpress.XtraReports.UI.XRLabel lbinicio;
        private DevExpress.XtraReports.UI.XRLabel lbUsuario;
        private DevExpress.XtraReports.UI.XRLabel lbCliente;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRChart xrChart1;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel lbDataImprecaoRotolo;
        private DevExpress.XtraReports.UI.XRLabel lblDescricao;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRPanel xrPanel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel26;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
    }
}
