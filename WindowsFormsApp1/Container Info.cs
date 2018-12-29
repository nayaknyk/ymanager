using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace WindowsFormsApp1
{
    public partial class container : Form
    {
        char col;
        int row;
        string yard;
        int yardid;
        public container(string yard1, char col1, int row1,int yardid1)
        {
            InitializeComponent();
            col = col1;
            row = row1;
            yard = yard1;
            yardid = yardid1;

            StringBuilder sb2 = new StringBuilder(label11.Text);
            sb2.Append(yard.ToString());
            label11.Text = sb2.ToString();

            StringBuilder sb = new StringBuilder(label9.Text);
            sb.Append(col.ToString());
            label9.Text = sb.ToString();

            StringBuilder sb1 = new StringBuilder(label10.Text);
            sb1.Append(row.ToString());
            label10.Text = sb1.ToString();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if ((yardid==2||yardid==4||yardid==6)&&(radioButton4.Checked == true))
            {
                MessageBox.Show("Can stack only 3 laden containers");
                radioButton4.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int position;
            if (this.radioButton1.Checked == true)
                position = 1;
            else if (this.radioButton2.Checked == true)
                position = 2;
            else if (this.radioButton3.Checked == true)
                position = 3;
            else
                position = 4;


            
            try
            {
                SqlCeConnection conn = new SqlCeConnection("Data Source=C:\\Users\\nikhil\\Documents\\github\\ymanager\\WindowsFormsApp1\\bin\\Debug\\containerinfo.sdf;Persist Security Info=False;");
                conn.Open();
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText="insert into container values('" + textBox1.Text + "','" + yardid.ToString() + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + col + "','" + row.ToString() + "','" + position.ToString() + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
