using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace Folha.Presentation.Desktop.Separadores.Sistema

{
    public partial class frmSplash : SplashScreen
    {
        public frmSplash()
        {
            InitializeComponent();
            this.balbeldata.Text = "Copyright © 2020-" + DateTime.Now.Year.ToString();
            timer1.Start();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

      

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Close();
        }

        private void frmActualizarBD_Load(object sender, EventArgs e)
        {
            this.Update();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }
    }
}