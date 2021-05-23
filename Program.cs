using System;
using Base;


namespace PG
{
    class Program
    {
        private static DataBase Base = new DataBase();
        static void Main(string[] args)
        {
            // Base.SignIn("Jack","Brown");
            // Base.RemoveAccount("Jack", "Brown");
            // Base.SingUp("Jack","Brown");
            // Base.AddPassword("C://","Jack","Brown","Success!!!");
            // Base.RemoveAllRow("Jack","Brown");
            Base.SignIn("Jack","Brown");
            Base.AddPassword("C://","Josty","123456","cool");
            Console.WriteLine("Hello World!");
        }
    }
}