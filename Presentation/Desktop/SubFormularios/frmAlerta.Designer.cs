namespace Folha.Presentation.Desktop.SubFormularios
{
    partial class frmAlerta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlerta));
            this.pictureErro = new System.Windows.Forms.PictureBox();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelConfirma = new System.Windows.Forms.Panel();
            this.btnConfimar = new DevExpress.XtraEditors.SimpleButton();
            this.panelCancelar = new System.Windows.Forms.Panel();
            this.btnCanscelar = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbMensagem = new System.Windows.Forms.Label();
            this.pictureQuestao = new System.Windows.Forms.PictureBox();
            this.pictureInformacao = new System.Windows.Forms.PictureBox();
            this.pictureSucesso = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureErro)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelConfirma.SuspendLayout();
            this.panelCancelar.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureQuestao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureInformacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSucesso)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureErro
            // 
            this.pictureErro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureErro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureErro.BackgroundImage")));
            this.pictureErro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureErro.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureErro.InitialImage")));
            this.pictureErro.Location = new System.Drawing.Point(14, 11);
            this.pictureErro.Name = "pictureErro";
            this.pictureErro.Size = new System.Drawing.Size(91, 88);
            this.pictureErro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureErro.TabIndex = 0;
            this.pictureErro.TabStop = false;
            this.pictureErro.Visible = false;
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbTitulo.Location = new System.Drawing.Point(127, 11);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(139, 19);
            this.lbTitulo.TabIndex = 1;
            this.lbTitulo.Text = "Erro ao cadastrar !";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelConfirma);
            this.panel1.Controls.Add(this.panelCancelar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 41);
            this.panel1.TabIndex = 2;
            // 
            // panelConfirma
            // 
            this.panelConfirma.Controls.Add(this.btnConfimar);
            this.panelConfirma.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelConfirma.Location = new System.Drawing.Point(215, 0);
            this.panelConfirma.Name = "panelConfirma";
            this.panelConfirma.Size = new System.Drawing.Size(99, 41);
            this.panelConfirma.TabIndex = 5;
            this.panelConfirma.Visible = false;
            // 
            // btnConfimar
            // 
            this.btnConfimar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfimar.Location = new System.Drawing.Point(21, 9);
            this.btnConfimar.Name = "btnConfimar";
            this.btnConfimar.Size = new System.Drawing.Size(75, 23);
            this.btnConfimar.TabIndex = 5;
            this.btnConfimar.Text = "Confimar";
            // 
            // panelCancelar
            // 
            this.panelCancelar.Controls.Add(this.btnCanscelar);
            this.panelCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelCancelar.Location = new System.Drawing.Point(314, 0);
            this.panelCancelar.Name = "panelCancelar";
            this.panelCancelar.Size = new System.Drawing.Size(87, 41);
            this.panelCancelar.TabIndex = 4;
            this.panelCancelar.Visible = false;
            // 
            // btnCanscelar
            // 
            this.btnCanscelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCanscelar.Location = new System.Drawing.Point(6, 9);
            this.btnCanscelar.Name = "btnCanscelar";
            this.btnCanscelar.Size = new System.Drawing.Size(75, 23);
            this.btnCanscelar.TabIndex = 4;
            this.btnCanscelar.Text = "Cancelar";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureSucesso);
            this.panel2.Controls.Add(this.pictureInformacao);
            this.panel2.Controls.Add(this.pictureQuestao);
            this.panel2.Controls.Add(this.pictureErro);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 110);
            this.panel2.TabIndex = 3;
            // 
            // lbMensagem
            // 
            this.lbMensagem.AutoSize = true;
            this.lbMensagem.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lbMensagem.Location = new System.Drawing.Point(127, 41);
            this.lbMensagem.Name = "lbMensagem";
            this.lbMensagem.Size = new System.Drawing.Size(262, 28);
            this.lbMensagem.TabIndex = 4;
            this.lbMensagem.Text = "O campo \"Descrição\" não cotem valor porfavor\r\ninsira um valor para continuar";
            // 
            // pictureQuestao
            // 
            this.pictureQuestao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureQuestao.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureQuestao.BackgroundImage")));
            this.pictureQuestao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureQuestao.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureQuestao.InitialImage")));
            this.pictureQuestao.Location = new System.Drawing.Point(14, 11);
            this.pictureQuestao.Name = "pictureQuestao";
            this.pictureQuestao.Size = new System.Drawing.Size(91, 88);
            this.pictureQuestao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureQuestao.TabIndex = 1;
            this.pictureQuestao.TabStop = false;
            this.pictureQuestao.Visible = false;
            // 
            // pictureInformacao
            // 
            this.pictureInformacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureInformacao.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureInformacao.BackgroundImage")));
            this.pictureInformacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureInformacao.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureInformacao.InitialImage")));
            this.pictureInformacao.Location = new System.Drawing.Point(14, 11);
            this.pictureInformacao.Name = "pictureInformacao";
            this.pictureInformacao.Size = new System.Drawing.Size(91, 88);
            this.pictureInformacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureInformacao.TabIndex = 2;
            this.pictureInformacao.TabStop = false;
            this.pictureInformacao.Visible = false;
            // 
            // pictureSucesso
            // 
            this.pictureSucesso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureSucesso.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureSucesso.BackgroundImage")));
            this.pictureSucesso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureSucesso.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureSucesso.InitialImage")));
            this.pictureSucesso.Location = new System.Drawing.Point(14, 11);
            this.pictureSucesso.Name = "pictureSucesso";
            this.pictureSucesso.Size = new System.Drawing.Size(91, 88);
            this.pictureSucesso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureSucesso.TabIndex = 3;
            this.pictureSucesso.TabStop = false;
            this.pictureSucesso.WaitOnLoad = true;
            // 
            // frmAlerta
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 151);
            this.Controls.Add(this.lbMensagem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAlerta";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notificação";
            ((System.ComponentModel.ISupportInitialize)(this.pictureErro)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelConfirma.ResumeLayout(false);
            this.panelCancelar.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureQuestao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureInformacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSucesso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureErro;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelConfirma;
        private System.Windows.Forms.Panel panelCancelar;
        private DevExpress.XtraEditors.SimpleButton btnConfimar;
        private System.Windows.Forms.Label lbMensagem;
        private DevExpress.XtraEditors.SimpleButton btnCanscelar;
        private System.Windows.Forms.PictureBox pictureSucesso;
        private System.Windows.Forms.PictureBox pictureInformacao;
        private System.Windows.Forms.PictureBox pictureQuestao;
    }
}