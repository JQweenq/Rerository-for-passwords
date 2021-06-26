using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PG
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }
        private void WindowMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
		private void Signin(object sender, RoutedEventArgs e)
		{
			((MainWindow)Application.Current.MainWindow).Login(LOGLINE.Text, PASSLINE.Text);
			Close();
		}
		private void Exit(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		private void LoglineChanged(object sender, TextChangedEventArgs e)
		{
			if (LOGLINE.Text != "Login" & LOGLINE.Text != "")
			{
				LOGLINE.Text = LOGLINE.Text;
			}
		}
        private void PasslineChanged(object sender, TextChangedEventArgs e){
            
			if (PASSLINE.Text != "Password" & PASSLINE.Text != "")
			{
				PASSLINE.Text = PASSLINE.Text;
			}
        }
    }
}
