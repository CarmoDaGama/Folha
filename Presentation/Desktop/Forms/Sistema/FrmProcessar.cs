﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Sistema
{
    public partial class FrmProcessar : Form
    {
        public Action Worker { get; set; }
        public FrmProcessar(Action worker)
        {
            InitializeComponent();
            if (worker == null) throw new ArgumentNullException();

            Worker = worker;
        }


        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => {
                this.Close(); }, 
                TaskScheduler.FromCurrentSynchronizationContext()
            );
        }
    }


}
