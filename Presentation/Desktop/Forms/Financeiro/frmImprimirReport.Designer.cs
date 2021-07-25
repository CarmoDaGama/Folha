using System;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Inventario;

namespace Folha.Presentation.Desktop.Forms.Financeiro
{
    partial class frmImprimirReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImprimirReport));
            this.cboForamato = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.cboMoeda = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblMoeda = new System.Windows.Forms.Label();
            this.btnVisualizar = new DevExpress.XtraEditors.SimpleButton();
            this.cboImpressora = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cboForamato.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoeda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboImpressora.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboForamato
            // 
            this.cboForamato.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboForamato.EditValue = "Papel A4";
            this.cboForamato.Location = new System.Drawing.Point(89, 12);
            this.cboForamato.Name = "cboForamato";
            this.cboForamato.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboForamato.Properties.Appearance.Options.UseFont = true;
            this.cboForamato.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboForamato.Properties.Items.AddRange(new object[] {
            "Papel A4",
            "Ticket"});
            this.cboForamato.Properties.Padding = new System.Windows.Forms.Padding(2);
            this.cboForamato.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboForamato.Size = new System.Drawing.Size(346, 26);
            this.cboForamato.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Papel ";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImprimir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnImprimir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnImprimir.ImageOptions.SvgImage")));
            this.btnImprimir.ImageOptions.SvgImageSize = new System.Drawing.Size(22, 22);
            this.btnImprimir.Location = new System.Drawing.Point(221, 145);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(42, 38);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.ToolTipTitle = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnCancelar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancelar.ImageOptions.SvgImage")));
            this.btnCancelar.ImageOptions.SvgImageSize = new System.Drawing.Size(22, 22);
            this.btnCancelar.Location = new System.Drawing.Point(269, 145);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(42, 38);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // cboMoeda
            // 
            this.cboMoeda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMoeda.EditValue = "AKZ";
            this.cboMoeda.Location = new System.Drawing.Point(89, 113);
            this.cboMoeda.Name = "cboMoeda";
            this.cboMoeda.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMoeda.Properties.Appearance.Options.UseFont = true;
            this.cboMoeda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoeda.Properties.Items.AddRange(new object[] {
            "AKZ",
            "USD"});
            this.cboMoeda.Properties.Padding = new System.Windows.Forms.Padding(2);
            this.cboMoeda.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboMoeda.Size = new System.Drawing.Size(348, 26);
            this.cboMoeda.TabIndex = 0;
            this.cboMoeda.Visible = false;
            this.cboMoeda.SelectedIndexChanged += new System.EventHandler(this.cboMoeda_SelectedIndexChanged);
            // 
            // lblMoeda
            // 
            this.lblMoeda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMoeda.AutoSize = true;
            this.lblMoeda.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoeda.Location = new System.Drawing.Point(9, 120);
            this.lblMoeda.Name = "lblMoeda";
            this.lblMoeda.Size = new System.Drawing.Size(46, 16);
            this.lblMoeda.TabIndex = 1;
            this.lblMoeda.Text = "Moeda";
            this.lblMoeda.Visible = false;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnVisualizar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnVisualizar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVisualizar.ImageOptions.SvgImage")));
            this.btnVisualizar.ImageOptions.SvgImageSize = new System.Drawing.Size(22, 22);
            this.btnVisualizar.Location = new System.Drawing.Point(173, 145);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(42, 38);
            this.btnVisualizar.TabIndex = 4;
            this.btnVisualizar.ToolTipTitle = "Visualizar";
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // cboImpressora
            // 
            this.cboImpressora.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboImpressora.EditValue = "Impressora Padrão";
            this.cboImpressora.Location = new System.Drawing.Point(89, 64);
            this.cboImpressora.Name = "cboImpressora";
            this.cboImpressora.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboImpressora.Properties.Appearance.Options.UseFont = true;
            this.cboImpressora.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboImpressora.Properties.Items.AddRange(new object[] {
            "Papel A4",
            "Ticket"});
            this.cboImpressora.Properties.Padding = new System.Windows.Forms.Padding(2);
            this.cboImpressora.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboImpressora.Size = new System.Drawing.Size(346, 26);
            this.cboImpressora.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Impressora:";
            // 
            // frmImprimirReport
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 195);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblMoeda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboMoeda);
            this.Controls.Add(this.cboImpressora);
            this.Controls.Add(this.cboForamato);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmImprimirReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir ";
            this.Load += new System.EventHandler(this.frmImprimirReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboForamato.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoeda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboImpressora.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cboForamato;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.ComboBoxEdit cboMoeda;
        private System.Windows.Forms.Label lblMoeda;
        private DevExpress.XtraEditors.SimpleButton btnVisualizar;
        private DevExpress.XtraEditors.ComboBoxEdit cboImpressora;
        private System.Windows.Forms.Label label1;
    }
}