using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        MySqlConnection connection;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
