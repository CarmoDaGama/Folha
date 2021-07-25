namespace Folha.Presentation.Desktop.Separadores.Principal
{
    partial class frmVerRelatorioOperacoes
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
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.tileLtOperacoes = new DevExpress.XtraEditors.TileItem();
            this.tileGrafOperacoes = new DevExpress.XtraEditors.TileItem();
            this.tilePeriodoMov = new DevExpress.XtraEditors.TileItem();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 29);
            this.panel1.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Relatórios de Operações";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tileControl1
            // 
            this.tileControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileControl1.Groups.Add(this.tileGroup2);
            this.tileControl1.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tileControl1.Location = new System.Drawing.Point(0, 29);
            this.tileControl1.MaxId = 5;
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileControl1.Size = new System.Drawing.Size(1364, 613);
            this.tileControl1.TabIndex = 54;
            this.tileControl1.Text = "tileControl1";
            this.tileControl1.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Top;
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.tileLtOperacoes);
            this.tileGroup2.Items.Add(this.tileGrafOperacoes);
            this.tileGroup2.Items.Add(this.tilePeriodoMov);
            this.tileGroup2.Name = "tileGroup2";
            // 
            // tileLtOperacoes
            // 
            this.tileLtOperacoes.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tileLtOperacoes.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileLtOperacoes.BorderVisibility = DevExpress.XtraEditors.TileItemBorderVisibility.Never;
            tileItemElement4.Text = "Listagem de Operações";
            tileItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tileLtOperacoes.Elements.Add(tileItemElement4);
            this.tileLtOperacoes.Id = 0;
            this.tileLtOperacoes.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileLtOperacoes.Name = "tileLtOperacoes";
            this.tileLtOperacoes.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileLtOperacoes_ItemClick);
            // 
            // tileGrafOperacoes
            // 
            this.tileGrafOperacoes.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tileGrafOperacoes.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileGrafOperacoes.BorderVisibility = DevExpress.XtraEditors.TileItemBorderVisibility.Never;
            tileItemElement5.Text = "Gráfico de Operações";
            tileItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tileGrafOperacoes.Elements.Add(tileItemElement5);
            this.tileGrafOperacoes.Id = 2;
            this.tileGrafOperacoes.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileGrafOperacoes.Name = "tileGrafOperacoes";
            this.tileGrafOperacoes.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileGrafOperacoes_ItemClick);
            // 
            // tilePeriodoMov
            // 
            this.tilePeriodoMov.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tilePeriodoMov.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tilePeriodoMov.BorderVisibility = DevExpress.XtraEditors.TileItemBorderVisibility.Never;
            tileItemElement6.Text = "Gráfico de Período de Movimentação";
            tileItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tilePeriodoMov.Elements.Add(tileItemElement6);
            this.tilePeriodoMov.Id = 4;
            this.tilePeriodoMov.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tilePeriodoMov.Name = "tilePeriodoMov";
            this.tilePeriodoMov.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tilePeriodoMov_ItemClick);
            // 
            // frmVerRelatorioOperacoes
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 642);
            this.Controls.Add(this.tileControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVerRelatorioOperacoes";
            this.Text = "FormVerRelatorioDocumentos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormVerRelatorioDocumentos_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileItem tileLtOperacoes;
        private DevExpress.XtraEditors.TileItem tileGrafOperacoes;
        private DevExpress.XtraEditors.TileItem tilePeriodoMov;
    }
}