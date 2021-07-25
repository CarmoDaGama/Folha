namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    partial class frmLaboratorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLaboratorio));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSalvar = new DevExpress.XtraBars.BarButtonItem();
            this.btnSalvarFechar = new DevExpress.XtraBars.BarButtonItem();
            this.btnVoltar = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.txtPaciente = new DevExpress.XtraEditors.TextEdit();
            this.btnBusca = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtMedico = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProcesso = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTipoResultado = new DevExpress.XtraEditors.TextEdit();
            this.txtData = new DevExpress.XtraEditors.TextEdit();
            this.txtExame = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAmostra = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtReferencia = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtunidade = new DevExpress.XtraEditors.TextEdit();
            this.cboResultadoD = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtResultadoPerc = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTecnico = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.txtResultDescricao = new DevExpress.XtraEditors.MemoEdit();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaciente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMedico.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcesso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoResultado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExame.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmostra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtunidade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboResultadoD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResultadoPerc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTecnico.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResultDescricao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
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
            this.btnSalvarFechar,
            this.btnVoltar,
            this.btnPrint});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(778, 132);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Caption = "Salvar";
            this.btnSalvar.Id = 1;
            this.btnSalvar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvar.ImageOptions.SvgImage")));
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSalvar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvar_ItemClick);
            // 
            // btnSalvarFechar
            // 
            this.btnSalvarFechar.Caption = "Salvar e Fechar";
            this.btnSalvarFechar.Id = 2;
            this.btnSalvarFechar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvarFechar.ImageOptions.SvgImage")));
            this.btnSalvarFechar.Name = "btnSalvarFechar";
            this.btnSalvarFechar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalvarFechar_ItemClick);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Caption = "Fechar";
            this.btnVoltar.Id = 3;
            this.btnVoltar.ImageOptions.LargeImage = global::Folha.Presentation.Desktop.Properties.Resources.Voltar;
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVoltar_ItemClick_1);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "Imprimir";
            this.btnPrint.Id = 4;
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSalvarFechar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPrint);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnVoltar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tarefas";
            // 
            // txtPaciente
            // 
            this.txtPaciente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaciente.Enabled = false;
            this.txtPaciente.Location = new System.Drawing.Point(227, 39);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaciente.Properties.Appearance.Options.UseFont = true;
            this.txtPaciente.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtPaciente.Size = new System.Drawing.Size(510, 22);
            this.txtPaciente.TabIndex = 187;
            // 
            // btnBusca
            // 
            this.btnBusca.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBusca.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusca.Appearance.Options.UseFont = true;
            this.btnBusca.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnBusca.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBusca.ImageOptions.SvgImage")));
            this.btnBusca.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnBusca.Location = new System.Drawing.Point(710, 36);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(27, 22);
            this.btnBusca.TabIndex = 188;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtMedico);
            this.groupControl1.Controls.Add(this.label11);
            this.groupControl1.Controls.Add(this.txtProcesso);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.txtTipoResultado);
            this.groupControl1.Controls.Add(this.txtData);
            this.groupControl1.Controls.Add(this.txtExame);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.txtPaciente);
            this.groupControl1.Location = new System.Drawing.Point(12, 142);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(754, 207);
            this.groupControl1.TabIndex = 191;
            this.groupControl1.Text = "Infomações Geral";
            // 
            // txtMedico
            // 
            this.txtMedico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMedico.Enabled = false;
            this.txtMedico.Location = new System.Drawing.Point(116, 178);
            this.txtMedico.Name = "txtMedico";
            this.txtMedico.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedico.Properties.Appearance.Options.UseFont = true;
            this.txtMedico.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtMedico.Size = new System.Drawing.Size(621, 22);
            this.txtMedico.TabIndex = 206;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 16);
            this.label11.TabIndex = 205;
            this.label11.Text = "Requerente:";
            // 
            // txtProcesso
            // 
            this.txtProcesso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcesso.Enabled = false;
            this.txtProcesso.Location = new System.Drawing.Point(116, 39);
            this.txtProcesso.Name = "txtProcesso";
            this.txtProcesso.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcesso.Properties.Appearance.Options.UseFont = true;
            this.txtProcesso.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtProcesso.Size = new System.Drawing.Size(105, 22);
            this.txtProcesso.TabIndex = 202;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 200;
            this.label6.Text = "Paciente:";
            // 
            // txtTipoResultado
            // 
            this.txtTipoResultado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTipoResultado.Enabled = false;
            this.txtTipoResultado.Location = new System.Drawing.Point(116, 145);
            this.txtTipoResultado.Name = "txtTipoResultado";
            this.txtTipoResultado.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoResultado.Properties.Appearance.Options.UseFont = true;
            this.txtTipoResultado.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtTipoResultado.Size = new System.Drawing.Size(621, 22);
            this.txtTipoResultado.TabIndex = 199;
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Enabled = false;
            this.txtData.Location = new System.Drawing.Point(116, 106);
            this.txtData.Name = "txtData";
            this.txtData.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Properties.Appearance.Options.UseFont = true;
            this.txtData.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtData.Size = new System.Drawing.Size(621, 22);
            this.txtData.TabIndex = 197;
            // 
            // txtExame
            // 
            this.txtExame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExame.Enabled = false;
            this.txtExame.Location = new System.Drawing.Point(116, 72);
            this.txtExame.Name = "txtExame";
            this.txtExame.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExame.Properties.Appearance.Options.UseFont = true;
            this.txtExame.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtExame.Size = new System.Drawing.Size(621, 22);
            this.txtExame.TabIndex = 196;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 194;
            this.label3.Text = "Tipo Resultado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 193;
            this.label1.Text = "Colheita :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 192;
            this.label2.Text = "Exame de:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 204;
            this.label7.Text = "Nº Amostra:";
            // 
            // txtAmostra
            // 
            this.txtAmostra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmostra.Location = new System.Drawing.Point(116, 72);
            this.txtAmostra.Name = "txtAmostra";
            this.txtAmostra.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmostra.Properties.Appearance.Options.UseFont = true;
            this.txtAmostra.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtAmostra.Size = new System.Drawing.Size(621, 22);
            this.txtAmostra.TabIndex = 203;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtReferencia);
            this.groupControl2.Controls.Add(this.label9);
            this.groupControl2.Controls.Add(this.label7);
            this.groupControl2.Controls.Add(this.label8);
            this.groupControl2.Controls.Add(this.txtAmostra);
            this.groupControl2.Controls.Add(this.txtunidade);
            this.groupControl2.Controls.Add(this.cboResultadoD);
            this.groupControl2.Controls.Add(this.txtResultadoPerc);
            this.groupControl2.Controls.Add(this.label5);
            this.groupControl2.Controls.Add(this.txtTecnico);
            this.groupControl2.Controls.Add(this.label10);
            this.groupControl2.Controls.Add(this.btnBusca);
            this.groupControl2.Controls.Add(this.txtResultDescricao);
            this.groupControl2.Location = new System.Drawing.Point(12, 355);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(754, 272);
            this.groupControl2.TabIndex = 192;
            this.groupControl2.Text = "Resultado do Exame";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReferencia.Location = new System.Drawing.Point(118, 144);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferencia.Properties.Appearance.Options.UseFont = true;
            this.txtReferencia.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtReferencia.Size = new System.Drawing.Size(619, 22);
            this.txtReferencia.TabIndex = 208;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 16);
            this.label9.TabIndex = 207;
            this.label9.Text = "V Refencia:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 206;
            this.label8.Text = "Unidade:";
            // 
            // txtunidade
            // 
            this.txtunidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtunidade.Location = new System.Drawing.Point(116, 109);
            this.txtunidade.Name = "txtunidade";
            this.txtunidade.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtunidade.Properties.Appearance.Options.UseFont = true;
            this.txtunidade.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtunidade.Size = new System.Drawing.Size(621, 22);
            this.txtunidade.TabIndex = 205;
            // 
            // cboResultadoD
            // 
            this.cboResultadoD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboResultadoD.Enabled = false;
            this.cboResultadoD.Location = new System.Drawing.Point(118, 176);
            this.cboResultadoD.MenuManager = this.ribbon;
            this.cboResultadoD.Name = "cboResultadoD";
            this.cboResultadoD.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboResultadoD.Properties.Appearance.Options.UseFont = true;
            this.cboResultadoD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboResultadoD.Properties.Items.AddRange(new object[] {
            "POSITIVO",
            "NEGATIVO"});
            this.cboResultadoD.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboResultadoD.Size = new System.Drawing.Size(619, 22);
            this.cboResultadoD.TabIndex = 201;
            // 
            // txtResultadoPerc
            // 
            this.txtResultadoPerc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultadoPerc.Enabled = false;
            this.txtResultadoPerc.Location = new System.Drawing.Point(118, 176);
            this.txtResultadoPerc.Name = "txtResultadoPerc";
            this.txtResultadoPerc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultadoPerc.Properties.Appearance.Options.UseFont = true;
            this.txtResultadoPerc.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtResultadoPerc.Size = new System.Drawing.Size(619, 22);
            this.txtResultadoPerc.TabIndex = 198;
            this.txtResultadoPerc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtResultadoPerc_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 196;
            this.label5.Text = "Tecnico:";
            // 
            // txtTecnico
            // 
            this.txtTecnico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTecnico.Enabled = false;
            this.txtTecnico.Location = new System.Drawing.Point(116, 36);
            this.txtTecnico.Name = "txtTecnico";
            this.txtTecnico.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTecnico.Properties.Appearance.Options.UseFont = true;
            this.txtTecnico.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtTecnico.Size = new System.Drawing.Size(588, 22);
            this.txtTecnico.TabIndex = 190;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 16);
            this.label10.TabIndex = 197;
            this.label10.Text = "Resultado:";
            // 
            // txtResultDescricao
            // 
            this.txtResultDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultDescricao.Enabled = false;
            this.txtResultDescricao.Location = new System.Drawing.Point(118, 178);
            this.txtResultDescricao.Name = "txtResultDescricao";
            this.txtResultDescricao.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultDescricao.Properties.Appearance.Options.UseFont = true;
            this.txtResultDescricao.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtResultDescricao.Size = new System.Drawing.Size(619, 77);
            this.txtResultDescricao.TabIndex = 201;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(706, 98);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Properties.Appearance.Options.UseFont = true;
            this.txtCodigo.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txtCodigo.Size = new System.Drawing.Size(43, 22);
            this.txtCodigo.TabIndex = 207;
            this.txtCodigo.Visible = false;
            // 
            // frmLaboratorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 639);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLaboratorio";
            this.Ribbon = this.ribbon;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Laboratorio";
            this.Load += new System.EventHandler(this.frmLaboratorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaciente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMedico.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcesso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoResultado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExame.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmostra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReferencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtunidade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboResultadoD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResultadoPerc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTecnico.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResultDescricao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnSalvar;
        private DevExpress.XtraBars.BarButtonItem btnSalvarFechar;
        private DevExpress.XtraBars.BarButtonItem btnVoltar;
        private DevExpress.XtraEditors.TextEdit txtPaciente;
        private DevExpress.XtraEditors.SimpleButton btnBusca;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtTecnico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtResultadoPerc;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.TextEdit txtTipoResultado;
        private DevExpress.XtraEditors.TextEdit txtData;
        private DevExpress.XtraEditors.TextEdit txtExame;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.ComboBoxEdit cboResultadoD;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraEditors.MemoEdit txtResultDescricao;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtAmostra;
        private DevExpress.XtraEditors.TextEdit txtProcesso;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtunidade;
        private DevExpress.XtraEditors.TextEdit txtReferencia;
        private DevExpress.XtraEditors.TextEdit txtMedico;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
    }
}