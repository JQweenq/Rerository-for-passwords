using System;
using System.IO;
using System.Data.SQLite;
using System.Data;

namespace Base
{
    class DataBase
    {
        private SQLiteConnection OpenBD()
        {
            if (!File.Exists("Passwords.sqlite"))
                SQLiteConnection.CreateFile("Passwords.sqlite");

            try
            {
                SQLiteConnection MYCONN;
                MYCONN = new SQLiteConnection(@"Data Source=.\Passwords.sqlite;Version=3;");
                MYCONN.Open();

                /*
                SQLiteCommand MYCMD = new SQLiteCommand();
                MYCMD.Connection = MYCONN;
                */

                return MYCONN;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return null;
        }

        public void SignIn() // тестовая функция
        {
            
        }

        
        
        public void SingUp(string LOGIN, string PASSWORD) // добавление нового пользователя
        {
            Console.WriteLine("SignUp");
            SQLiteCommand MYCMD = new SQLiteCommand();
            MYCMD.Connection = OpenBD();

            MYCMD.CommandText = $"CREATE TABLE {LOGIN}{PASSWORD} (number, url, login, password, description)";
            MYCMD.CommandType = CommandType.Text;
            MYCMD.ExecuteNonQuery();
        }

        public void AddPassword(string URL, string LOGIN, string PASSWORD, string DESCRIPTION = null) // добавление пароля для пользователя
        {
            Console.WriteLine("SignIn");
            
            SQLiteCommand MYCMD = new SQLiteCommand();
            MYCMD.Connection = OpenBD();
            MYCMD.CommandText = $"INSERT INTO {LOGIN}{PASSWORD} (url, login, password, description) VALUES ('{URL}', '{LOGIN}', '{PASSWORD}', '{DESCRIPTION}')";
            MYCMD.CommandType = CommandType.Text;
            MYCMD.ExecuteNonQuery();
        }
    }
}