using System;
using System.IO;
using System.Data.SQLite;
using System.Data;

namespace Base
{
    class DataBase
    {
        public SQLiteCommand MYCMD = new SQLiteCommand();
        public SQLiteConnection MYCONN;
        private string TABLE;

        public string LOGIN;
        public string PASSWORD;

        private void OpenBD() // функция открытия бд
        {
            if (!File.Exists("Passwords.sqlite"))
                SQLiteConnection.CreateFile("Passwords.sqlite");

            try
            {
                MYCONN = new SQLiteConnection(@"Data Source=.\Passwords.sqlite;Version=3;");
                MYCONN.Open();

                MYCMD.Connection = MYCONN;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        public void SignIn(string LOGIN, string PASSWORD) // функция входа
        {
            OpenBD();
            TABLE = $"{LOGIN}{PASSWORD}".ToLower();
        }
        
        public void SingUp(string LOGIN, string PASSWORD) // добавление нового пользователя
        {
            OpenBD();
            MYCMD.CommandText = $"CREATE TABLE {LOGIN}{PASSWORD} (url, login, password, description)";
            MYCMD.CommandType = CommandType.Text;
            MYCMD.ExecuteNonQuery();
            SignIn(LOGIN, PASSWORD);
            TABLE = $"{LOGIN}{PASSWORD}".ToLower();
        }

        public void AddPassword(string URL = null, string LOGIN = null, string PASSWORD = null, string DESCRIPTION = null, string DATA = null) // добавление пароля для пользователя
        {
            MYCMD.CommandText = $"INSERT INTO {TABLE} (url, login, password, description) VALUES ('{URL}', '{LOGIN}', '{PASSWORD}', '{DESCRIPTION}', '{DATA}')";
            MYCMD.CommandType = CommandType.Text;
            MYCMD.ExecuteNonQuery();
        }

        public void RemoveAccount() // удаление пользователя
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

        public void EditData(string VALUE, int  ROWID) // редактирование значения
        {
            MYCMD.CommandText = $"UPDATE {TABLE} SET {VALUE} WHERE ROWID = {ROWID}";
            MYCMD.CommandType = CommandType.Text;
            MYCMD.ExecuteNonQuery();
        }

        public void LoadData(string REQUEST = "*") {
            MYCMD.CommandText = $"SELECT {REQUEST} FROM {TABLE}");
            MYCMD.CommandType = CommandType.Text;
            MYCMD.ExecuteNonQuery();
        }
    }
}