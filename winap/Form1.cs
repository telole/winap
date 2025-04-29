using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;


namespace winap
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            using (MySqlConnection conn = db.GetConnection())
            {
                //try
                //{
                //    conn.Open();
                //    MessageBox.Show("Connected to database");
                //}
                //catch (MySqlException ex)
                //{
                //    MessageBox.Show("Error: " + ex.Message);
                //}
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {

            using (MySqlConnection conn =db.GetConnection())
            {
                //string usn = textBox1.Text;
                //string pw = textBox2.Text;

                //string query = "SELECT * FROM admin WHERE username = @username AND password = @password";
                //MySqlCommand cmd = new MySqlCommand(query, conn);

                //cmd.Parameters.AddWithValue("@username", usn);
                //cmd.Parameters.AddWithValue("@password", pw);

                //conn.Open();
                //MySqlDataReader reader = cmd.ExecuteReader();

                //if (reader.HasRows)
                //{
                //    MessageBox.Show("Login successful");
                //    Dashboard form2 = new Dashboard();
                //    form2.Show();
                //    this.Hide();
                //}
                //else
                //{
                //    MessageBox.Show("Invalid username or password");
                //}

            Dashboard form2 = new Dashboard();
            form2.Show();
            this.Hide();


        }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
