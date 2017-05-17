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
                command.CommandText = "INSERT INTO test(name) VALUES(@name)";
                command.Parameters.AddWithValue("@name", "Nontachai");
                command.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                Console.WriteLine("Connect Database Unsuccessfull");
            }
        }
    }
}
