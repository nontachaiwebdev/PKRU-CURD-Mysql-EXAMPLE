using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection connection;
            string server = "localhost";
            string database = "pkru";
            string uid = "root";
            string password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            connection.Open();
            if (connection != null)
            {
                Console.WriteLine("Connect Database Successfull");
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM test";
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("id : {0} , name : {1}",reader[0],reader[1]);
                }
                connection.Close();
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Connect Database Unsuccessfull");
                Console.ReadLine();
            }
        }
    }
}
