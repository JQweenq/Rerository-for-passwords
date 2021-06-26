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

namespace PG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DataBase DB;
        private BindingList<Model> DATA;

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

        private void Data_ListChanged(object sender, ListChangedEventArgs e)
        {

            Model List;
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded: //
                    DB.AddPassword();
                    

                    break;
                case ListChangedType.ItemDeleted: //
                    if (LIST.SelectedIndex < 0) break;
                    List = DATA[LIST.SelectedIndex];

                    DB.RemoveRow(LIST.SelectedIndex + 1);
                    break;

                case ListChangedType.ItemChanged: //
                    if (LIST.SelectedIndex < 0) break;
                    List = DATA[LIST.SelectedIndex];

                    string VALUES = $"url='{List.Url}', login='{List.Login}', password='{List.Password}', description='{List.Description}'";

                    DB.EditData(VALUES, LIST.SelectedIndex+1);
                    break;
            }
        }
        public void Login(string LOGIN, string PASSWORD){
            DB = new DataBase
            {
                LOGIN = LOGIN, // инициализация переменной
                PASSWORD = PASSWORD // инициализация переменной
            }; // создание бд
            DB.SignIn(); // вход
            LINELOGIN.Text = LOGIN;// изменение логина на превью
            DATA = DB.LoadData();
            LIST.ItemsSource = DATA; // заполнение формы
            DATA.ListChanged += Data_ListChanged; // присоединение к отслеживанию событий
            

        }
        public void Register(string LOGIN, string PASSWORD)
		{
            DB = new DataBase
            {
                LOGIN = LOGIN, // инициализация переменной
                PASSWORD = PASSWORD // инициализация переменной
            }; // создание бд
            DB.SingUp(); // регистрация + вход
            DATA = DB.LoadData();
            LINELOGIN.Text = LOGIN; // изменение логина на превью
        }
    }
}