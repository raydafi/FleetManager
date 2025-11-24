using fleetmanager.Views;
using System;
using System.Windows.Forms;

namespace FleetManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Connexion());
        }
    }
}