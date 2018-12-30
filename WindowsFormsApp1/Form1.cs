using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlServerCe;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yard5 y5 = new yard5();
            y5.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yard2 y2 = new yard2();
            y2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yard3 y3 = new yard3();
            y3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yard4 y4 = new yard4();
            y4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            yard1 y1 = new yard1();
            y1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            yard6 y6 = new yard6();
            y6.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            if (s.Length>11)
            {
                MessageBox.Show("Invalid Container number");
                textBox1.Clear();
            }
            try
            {
                SqlCeConnection conn = new SqlCeConnection("Data Source=C:\\Users\\nikhil\\Documents\\github\\ymanager\\WindowsFormsApp1\\bin\\Debug\\containerinfo.sdf;Persist Security Info=False;");
                conn.Open();
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select containerid,yardnum,col,rowid,position from container where containerid='"+s+"'";
                cmd.ExecuteNonQuery();
                SqlCeDataAdapter sd = new SqlCeDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
