namespace Folha.Presentation.Desktop.Reports.Hospitalar
{
    partial class RelGrafAtendimentoGrafico
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
            DevExpress.XtraCharts.Legend legend1 = new DevExpress.XtraCharts.Legend();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.SeriesKeyColorColorizer seriesKeyColorColorizer1 = new DevExpress.XtraCharts.SeriesKeyColorColorizer();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            this.objectDataSource2 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.lbfim = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbinicio = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbUsuario = new DevExpress.XtraReports.UI.XRLabel();
            this.lbUsuarioPlaceHolder = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport1});
            this.TopMargin.HeightF = 122.74F;
            this.TopMargin.Name = "TopMargin";
            // 
            // xrSubreport1
            // 
            this.xrSubreport1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.SizeF = new System.Drawing.SizeF(775F, 122.74F);
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 95.65672F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.HeightF = 28.4414F;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrChart1,
            this.lbfim,
            this.xrLabel3,
            this.lbinicio,
            this.xrLabel2,
            this.lbUsuario,
            this.lbUsuarioPlaceHolder,
            this.xrLabel4});
            this.ReportHeader.HeightF = 331.0035F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(508.875F, 0F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(266.125F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Este documento não serve de factura";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrChart1
            // 
            this.xrChart1.BorderColor = System.Drawing.Color.Black;
            this.xrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrChart1.DataSource = this.objectDataSource2;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.False;
            this.xrChart1.Diagram = xyDiagram1;
            this.xrChart1.Legend.Name = "Default Legend";
            this.xrChart1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            legend1.Name = "Legend1";
            this.xrChart1.Legends.AddRange(new DevExpress.XtraCharts.Legend[] {
            legend1});
            this.xrChart1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 133.4401F);
            this.xrChart1.Name = "xrChart1";
            series1.ArgumentDataMember = "Data";
            series1.Name = "Series 1";
            series1.ValueDataMembersSerializable = "Total";
            series1.View = lineSeriesView1;
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.xrChart1.SeriesTemplate.ArgumentDataMember = "Data";
            this.xrChart1.SeriesTemplate.SeriesColorizer = seriesKeyColorColorizer1;
            this.xrChart1.SeriesTemplate.ValueDataMembersSerializable = "Total";
            this.xrChart1.SizeF = new System.Drawing.SizeF(774.9999F, 197.5634F);
            // 
            // objectDataSource2
            // 
            this.objectDataSource2.DataSource = typeof(Folha.Domain.ViewModels.Hospitalar.AtendimentoHospitalarGraficViewModel);
            this.objectDataSource2.Name = "objectDataSource2";
            // 
            // lbfim
            // 
            this.lbfim.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfim.LocationFloat = new DevExpress.Utils.PointFloat(254.5352F, 23.56512F);
            this.lbfim.Multiline = true;
            this.lbfim.Name = "lbfim";
            this.lbfim.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbfim.SizeF = new System.Drawing.SizeF(118.4945F, 23F);
            this.lbfim.StylePriority.UseFont = false;
            this.lbfim.StylePriority.UseTextAlignment = false;
            this.lbfim.Text = "Data Final";
            this.lbfim.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(175.6241F, 23.56512F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(78.91115F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Data Final:";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbinicio
            // 
            this.lbinicio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbinicio.LocationFloat = new DevExpress.Utils.PointFloat(78.91015F, 23.56512F);
            this.lbinicio.Multiline = true;
            this.lbinicio.Name = "lbinicio";
            this.lbinicio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbinicio.SizeF = new System.Drawing.SizeF(96.7139F, 23F);
            this.lbinicio.StylePriority.UseFont = false;
            this.lbinicio.StylePriority.UseTextAlignment = false;
            this.lbinicio.Text = "Data Inicial:";
            this.lbinicio.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0.0001430511F, 23.56512F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(78.91F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Data Inicial:";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbUsuario
            // 
            this.lbUsuario.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lbUsuario.LocationFloat = new DevExpress.Utils.PointFloat(78.91014F, 0.5651474F);
            this.lbUsuario.Multiline = true;
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbUsuario.SizeF = new System.Drawing.SizeF(429.9648F, 23F);
            this.lbUsuario.StylePriority.UseFont = false;
            this.lbUsuario.StylePriority.UseTextAlignment = false;
            this.lbUsuario.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lbUsuarioPlaceHolder
            // 
            this.lbUsuarioPlaceHolder.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuarioPlaceHolder.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0.5651474F);
            this.lbUsuarioPlaceHolder.Multiline = true;
            this.lbUsuarioPlaceHolder.Name = "lbUsuarioPlaceHolder";
            this.lbUsuarioPlaceHolder.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbUsuarioPlaceHolder.SizeF = new System.Drawing.SizeF(78.91014F, 23F);
            this.lbUsuarioPlaceHolder.StylePriority.UseFont = false;
            this.lbUsuarioPlaceHolder.StylePriority.UseTextAlignment = false;
            this.lbUsuarioPlaceHolder.Text = "Usuário:";
            this.lbUsuarioPlaceHolder.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 16.75F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(196.4575F, 58.02345F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(406.9097F, 55.62501F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Total de atendimento";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(Folha.Domain.ViewModels.Hospitalar.AtendimentoHospitalarViewModel);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // RelGrafAtendimentoGrafico
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1,
            this.objectDataSource2});
            this.DataSource = this.objectDataSource2;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(38, 36, 123, 96);
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRSubreport xrSubreport1;
        private DevExpress.XtraReports.UI.XRLabel lbfim;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel lbinicio;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel lbUsuario;
        private DevExpress.XtraReports.UI.XRLabel lbUsuarioPlaceHolder;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.XRChart xrChart1;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
    }
}
