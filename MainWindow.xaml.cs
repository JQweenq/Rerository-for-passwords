using System;
using System.Collections.Generic;
using System.ComponentModel;
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

using Base;
using PG.Models;
using PG.Services;

namespace PG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<Model> Data;
        private IOService Service;

        private DataBase DB;

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Service = new IOService();
            /*
             Data = Service.LoadData();
             */
            Data = new BindingList<Model>()
            {
                new Model(){Num=0},
                new Model(){Num=1},
                new Model(){Num=2}
            };
            LIST.ItemsSource = Data;
            Data.ListChanged += Data_ListChanged;
        }

        private void Data_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded: //
                    /*
                     Service.SaveData(sender);
                     */
                    break;
                case ListChangedType.ItemDeleted: //


                    break;
                case ListChangedType.ItemChanged: //
                    break;
            }
        }
        public void Login(string LOGIN, string PASSWORD){
            DB = new DataBase();
            DB.SignIn(LOGIN, PASSWORD);
        }
        public void Register(string LOGIN, string PASSWORD)
		{
			DB = new DataBase();
            DB.SingUp(LOGIN, PASSWORD);
        }
    }
}