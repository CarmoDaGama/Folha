namespace Folha.Presentation.Desktop.Forms.Sistema
{
    partial class FrmProcessar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProcessar));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNomeEmpresa = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // progressPanel1
            // 
            this.progressPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(202)))), ((int)(((byte)(224)))));
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.Appearance.Options.UseForeColor = true;
            this.progressPanel1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(202)))), ((int)(((byte)(224)))));
            this.progressPanel1.AppearanceCaption.Options.UseForeColor = true;
            this.progressPanel1.AppearanceDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(83)))), ((int)(((byte)(99)))));
            this.progressPanel1.AppearanceDescription.Options.UseForeColor = true;
            this.progressPanel1.BarAnimationElementThickness = 2;
            this.progressPanel1.Caption = "Aguarde por favor";
            this.progressPanel1.Description = "Carregando...";
            this.progressPanel1.FrameCount = 28000;
            this.progressPanel1.FrameInterval = 650;
            this.progressPanel1.LineAnimationElementType = DevExpress.Utils.Animation.LineAnimationElementType.Triangle;
            this.progressPanel1.Location = new System.Drawing.Point(269, 195);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(246, 66);
            this.progressPanel1.TabIndex = 54;
            this.progressPanel1.Text = "progressPanel1";
            this.progressPanel1.WaitAnimationType = DevExpress.Utils.Animation.WaitingAnimatorType.Ring;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(612, 463);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 15);
            this.panel2.TabIndex = 55;
            // 
            // btnNomeEmpresa
            // 
            this.btnNomeEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNomeEmpresa.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnNomeEmpresa.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(202)))), ((int)(((byte)(224)))));
            this.btnNomeEmpresa.Appearance.Options.UseFont = true;
            this.btnNomeEmpresa.Appearance.Options.UseForeColor = true;
            this.btnNomeEmpresa.Location = new System.Drawing.Point(633, 463);
            this.btnNomeEmpresa.Name = "btnNomeEmpresa";
            this.btnNomeEmpresa.Size = new System.Drawing.Size(112, 13);
            this.btnNomeEmpresa.TabIndex = 56;
            this.btnNomeEmpresa.Text = "Folha ERP |  Trevo Soft";
            // 
            // FrmProcessar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(749, 485);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNomeEmpresa);
            this.Controls.Add(this.progressPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmProcessar";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl btnNomeEmpresa;
    }
}