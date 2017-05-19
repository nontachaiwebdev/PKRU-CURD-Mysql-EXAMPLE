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


namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        string value1, value2;
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Console.WriteLine(row.ToString());
                value1 = row.Cells[0].Value.ToString();
                value2 = row.Cells[1].Value.ToString();
                Console.WriteLine(row.Cells[0].Value.ToString());
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
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
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM test";
                MySqlDataAdapter adt = new MySqlDataAdapter();
                adt.SelectCommand = command;
                DataTable dataset = new DataTable();
                adt.Fill(dataset);
                BindingSource source = new BindingSource();
                source.DataSource = dataset;
                dataGridView1.DataSource = source;
                adt.Update(dataset);
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
