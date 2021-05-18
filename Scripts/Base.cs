using System;
using System.IO;
using System.Data.SQLite;
using System.Data;

namespace Base
{
    class DataBase
    {
        public void SignIn()
        {
            Console.WriteLine("SignIn");
            
            if (!File.Exists("Passwords.sqlite"))
                SQLiteConnection.CreateFile("Passwords.sqlite");

            try
            {
                SQLiteConnection MYCONN = new SQLiteConnection(@"Data Source=.\Passwords.sqlite;Version=3;");
                MYCONN.Open();

                SQLiteCommand MYCMD = new SQLiteCommand();
                MYCMD.Connection = MYCONN;
                MYCMD.CommandText = "CREATE TABLE IF NOT EXISTS Catalog (id INTEGER PRIMARY KEY AUTOINCREMENT, author TEXT, book TEXT)";                
                MYCMD.ExecuteNonQuery();

            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }          
        }
    }
}