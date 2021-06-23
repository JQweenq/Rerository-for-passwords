using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Base;

namespace PG
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /* private DataBase db = new DataBase();
        private MainWindow main = new MainWindow();
        private SignIn signin = new SignIn();
        private SignUp signup = new SignUp(); */
		private void StartUp(object sender, StartupEventArgs e)
		{
			Console.WriteLine("Startup");
        }
    }
}