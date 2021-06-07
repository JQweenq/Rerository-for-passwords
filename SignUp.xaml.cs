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
    /// Логика взаимодействия для SugnUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }
        private void WindowMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void LoglineChanged(object sender, TextChangedEventArgs e){
            if(LOGLINE.Text != "Login" & LOGLINE.Text != ""){
                LOGLINE.Text = LOGLINE.Text;
            }
        }

		private void PasslineChanged(object sender, TextChangedEventArgs e)
		{

			if (PASSLINE.Text != "Password" & PASSLINE.Text != "")
			{
                PASSLINE2.Text = PASSLINE.Text;

			}

		}
        private void Passline2Changed(object sender, TextChangedEventArgs e){

            if (PASSLINE2.Text != "Password" & PASSLINE2.Text != ""){
                PASSLINE.Text = PASSLINE2.Text;
            }
        }
		private void Exit(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		private void Register(object sender, RoutedEventArgs e)
		{
			MessageBox.Show($"{LOGLINE.Text}\n{PASSLINE.Text}");
		}
    }
}
