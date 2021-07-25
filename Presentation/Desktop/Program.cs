using System;
using Folha.Driver.Framework.IOC;
using SimpleInjector;
using System.Windows.Forms;
using Folha.Presentation.Desktop.Separadores.Principal;
using Folha.Domain.Helpers;
using Folha.Presentation.Desktop.Forms.Principal;

namespace Folha.Presentation.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            UtilidadesGenericas.ImagemVazia = Properties.Resources.Light_48px;
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(IOC.InjectForm<frmLogin>());


        }
}
}
