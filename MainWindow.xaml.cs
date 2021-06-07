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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void WindowMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void OpenWindowSignIn(object sender, RoutedEventArgs e)
        {

            Window WindowSignIn = new SignIn();
            WindowSignIn.Top = this.Top + (this.Height / 2) - (WindowSignIn.Height / 2);
            WindowSignIn.Left = this.Left + (this.Width / 2) - (WindowSignIn.Width / 2);
            WindowSignIn.ShowDialog();
        }
        private void OpenWindowSignUp(object sender, RoutedEventArgs e)
        {

            Window WindowSignUp = new SignUp();
            WindowSignUp.Top = this.Top + (this.Height / 2) - (WindowSignUp.Height / 2);
            WindowSignUp.Left = this.Left + (this.Width / 2) - (WindowSignUp.Width / 2);
            WindowSignUp.ShowDialog();
        }
    }
}