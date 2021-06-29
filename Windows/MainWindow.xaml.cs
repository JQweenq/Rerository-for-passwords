using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
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
        private int ROWSELECTED;
        private Model List;

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
            /*if (LIST.SelectedIndex < 0) return;
            ROWSELECTED = LIST.SelectedIndex;*/
            
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded: //
                    DB.AddPassword();
                    break;

                case ListChangedType.ItemDeleted: //

                    DB.RemoveRow(ROWSELECTED + 1);
                    DATA = DB.LoadData();
                    LIST.ItemsSource = DATA;
                    break;

                case ListChangedType.ItemChanged: //
                    
                    List = DATA[ROWSELECTED];
                    /*MessageBox.Show(ROWSELECTED.ToString() + "\n" + List.Password);*/
                    
                    string VALUES = $"url='{List.Url}', login='{List.Login}', password='{List.Password}', description='{List.Description}', date='{List.Date}'";

                    DB.EditData(VALUES, ROWSELECTED + 1);
                    break;
            }
        }
        public void Login(string LOGIN, string PASSWORD){
            try
            {
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
            catch (SQLiteException)
            {
                MessageBox.Show("Ошибка при входе. Проверьте правильность написания логина и пароля.");
            }
        }
        public void Register(string LOGIN, string PASSWORD)
		{
            try
            {
                DB = new DataBase
                {
                    LOGIN = LOGIN, // инициализация переменной
                    PASSWORD = PASSWORD // инициализация переменной
                }; // создание бд
                DB.SingUp(); // регистрация + вход
                DATA = DB.LoadData();
                LIST.ItemsSource = DATA; // заполнение формы
                DATA.ListChanged += Data_ListChanged; // присоединение к отслеживанию событий
                LINELOGIN.Text = LOGIN; // изменение логина на превью
            }
            catch (SQLiteException)
            {
                MessageBox.Show("Такой аккаунт уже зарегистрирован.");
            }
        }

        private void LIST_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LIST.SelectedIndex < 0 | LIST.SelectedIndex == ROWSELECTED) return;
            ROWSELECTED = LIST.SelectedIndex;
        }

        private void LIST_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (LIST.SelectedIndex < 0 | LIST.SelectedIndex == ROWSELECTED) return;
            ROWSELECTED = LIST.SelectedIndex;
        }
    }
}