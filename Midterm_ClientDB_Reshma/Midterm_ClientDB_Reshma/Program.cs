using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Midterm_ClientDB_Reshma.GUI;

namespace Midterm_ClientDB_Reshma
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            FormCLient formclient = new FormCLient();
            formclient.ShowDialog();
        }
    }
}
