using System;
using System.IO;
using System.Data.SQLite;
using System.Data;

namespace Base
{
    class DataBase
    {
        // private string TABLE = ;
        private SQLiteCommand MYCMD = new SQLiteCommand();
        private SQLiteConnection MYCONN;
        private string TABLE;
        private void OpenBD()
        {
            if (!File.Exists("Passwords.sqlite"))
                SQLiteConnection.CreateFile("Passwords.sqlite");

            try
            {
                MYCONN = new SQLiteConnection(@"Data Source=.\Passwords.sqlite;Version=3;");
                MYCONN.Open();

                /*
                SQLiteCommand MYCMD = new SQLiteCommand();
                MYCMD.Connection = MYCONN;
                */
                
                MYCMD.Connection = MYCONN;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        public void SignIn(string LOGIN, string PASSWORD) // тестовая функция
        {
            OpenBD();
            TABLE = $"{LOGIN}{PASSWORD}".ToLower();
        }
        
        public void SingUp(string LOGIN, string PASSWORD) // добавление нового пользователя
        {
            MYCMD.CommandText = $"CREATE TABLE {LOGIN}{PASSWORD} (url, login, password, description)";
            MYCMD.CommandType = CommandType.Text;
            MYCMD.ExecuteNonQuery();
        }

        public void AddPassword(string URL, string LOGIN, string PASSWORD, string DESCRIPTION = null) // добавление пароля для пользователя
        {
            MYCMD.CommandText = $"INSERT INTO {TABLE} (url, login, password, description) VALUES ('{URL}', '{LOGIN}', '{PASSWORD}', '{DESCRIPTION}')";
            MYCMD.CommandType = CommandType.Text;
            MYCMD.ExecuteNonQuery();
        }

        public void RemoveAccount()
        {
            try
            {
                MYCMD.CommandText = $"DROP TABLE {TABLE}";
                MYCMD.CommandType = CommandType.Text;
                MYCMD.ExecuteNonQuery();
            }
            catch (SQLiteException)
            {
                Console.WriteLine("Error: {\n\tТакого аккаунта не существует\n}");
            }
        }
        public void RemoveRow(int ROW = 1) // удаление строки
        {
            MYCMD.CommandText = $"DELETE FROM {TABLE} WHERE {ROW}";
            MYCMD.CommandType = CommandType.Text;
            MYCMD.ExecuteNonQuery();
        }

        public void RemoveAllRow()  // удаление всех строк
        {
            MYCMD.CommandText = $"DELETE FROM {TABLE}";
            MYCMD.CommandType = CommandType.Text;
            MYCMD.ExecuteNonQuery();
        }
    }
}