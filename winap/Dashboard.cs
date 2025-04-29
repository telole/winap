using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace winap
{
    public partial class Dashboard: Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //this.BackColor = Color.FromArgb(255, 202, 8); 

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            using(MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    string Day = "SELECT COUNT(*) FROM peminjaman WHERE tanggal_pinjam = CURDATE()";
                    MySqlCommand cmd = new MySqlCommand(Day, conn);
                    int onDay = Convert.ToInt32(cmd.ExecuteScalar());
                    label7.Text = $"{onDay}";

                    string Week = "SELECT COUNT(*) FROM peminjaman WHERE tanggal_pinjam >= CURDATE() - INTERVAL 7 DAY";
                    MySqlCommand cmd2 = new MySqlCommand(Week, conn);
                    int onWeek = Convert.ToInt32(cmd2.ExecuteScalar());
                    label6.Text = $"{onWeek}";

                    string Month = "SELECT COUNT(*) FROM peminjaman WHERE tanggal_pinjam >= CURDATE() - INTERVAL 30 DAY";
                    MySqlCommand cmd3 = new MySqlCommand(Month, conn);
                    int onMonth = Convert.ToInt32(cmd3.ExecuteScalar());
                    label5.Text = $"{onMonth}";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }


                try
                {
                    chart1.Series.Clear();
                    chart1.Titles.Clear();
                    chart1.Legends.Clear(); 

                    chart1.Titles.Add("Grafik Peminjaman 7 Hari Terakhir");

                    Series series = new Series("Jumlah Peminjaman");
                    series.ChartType = SeriesChartType.Column; 
                    series.Color = Color.FromArgb(180, Color.DodgerBlue); 
                    series.BorderWidth = 0;

                    chart1.Series.Add(series);

                    Legend legend = new Legend();
                    legend.Docking = Docking.Right;
                    chart1.Legends.Add(legend);

                    string query = @"SELECT DATE(tanggal_pinjam) AS tanggal, COUNT(*) AS jumlah 
                                   FROM peminjaman 
                                   WHERE tanggal_pinjam >= CURDATE() - INTERVAL 6 DAY 
                                   GROUP BY DATE(tanggal_pinjam) 
                                   ORDER BY tanggal ASC;";

                    using (MySqlConnection conns = db.GetConnection())
                    {
                        conns.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conns);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string tanggal = Convert.ToDateTime(reader["tanggal"]).ToString("dd MMM");
                            int jumlah = Convert.ToInt32(reader["jumlah"]);
                            series.Points.AddXY(tanggal, jumlah);
                        }
                    }

                    chart1.ChartAreas[0].AxisX.Title = "Tanggal";
                    chart1.ChartAreas[0].AxisY.Title = "Jumlah Peminjaman";

                    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 0; 
                    chart1.ChartAreas[0].AxisX.Interval = 1;

                    chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                    chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //string input = Microsoft InputBox(
            //    "Masukkan password:", 
            //    "Password Required",
            //    "");    
            
            // Default text kosong

            string input = Interaction.InputBox(
                "Masukkan password:", 
                "Password Required",
                "");   

            if (input == "545454")
            {
                MessageBox.Show("Password benar!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
