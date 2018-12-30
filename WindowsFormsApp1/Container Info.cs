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

            label14.Text = " ";

            try
            {
                SqlCeConnection conn = new SqlCeConnection("Data Source=C:\\Users\\nikhil\\Documents\\github\\ymanager\\WindowsFormsApp1\\bin\\Debug\\containerinfo.sdf;Persist Security Info=False;");
                conn.Open();
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from container where yardnum='"+yardid+"' and col='"+col+"' and rowid='"+row+"'";
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
            int position = getpos();
            try
            {
                SqlCeConnection conn = new SqlCeConnection("Data Source=C:\\Users\\nikhil\\Documents\\github\\ymanager\\WindowsFormsApp1\\bin\\Debug\\containerinfo.sdf;Persist Security Info=False;");
                conn.Open();
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText="insert into container values('" + textBox1.Text + "','" + yardid.ToString() + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + col + "','" + position.ToString() + "','" + row.ToString() + "')";
                cmd.ExecuteNonQuery();
                label14.Text = "Container added successfully!";

                cmd.CommandText = "select * from container where yardnum='" + yardid + "' and col='" + col + "' and rowid='" + row + "'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCeConnection conn = new SqlCeConnection("Data Source=C:\\Users\\nikhil\\Documents\\github\\ymanager\\WindowsFormsApp1\\bin\\Debug\\containerinfo.sdf;Persist Security Info=False;");
                conn.Open();
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "delete from container where containerid='"+textBox1.Text+"'";
                cmd.ExecuteNonQuery();
                label14.Text = "Container deleted successfully!";

                cmd.CommandText = "select * from container where yardnum='" + yardid + "' and col='" + col + "' and rowid='" + row + "'";
                cmd.ExecuteNonQuery();
                SqlCeDataAdapter sd = new SqlCeDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int position = getpos();
                SqlCeConnection conn = new SqlCeConnection("Data Source=C:\\Users\\nikhil\\Documents\\github\\ymanager\\WindowsFormsApp1\\bin\\Debug\\containerinfo.sdf;Persist Security Info=False;");
                conn.Open();
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update container set containerid='" + textBox1.Text + "', yardnum='" + yardid.ToString() + "', vesselnum='" + textBox3.Text + "', voyagenum='" + textBox4.Text + "', containersize='" + textBox6.Text + "', agent='" + textBox2.Text + "', containertype='" + textBox5.Text + "', col='" + col + "', position='" + position.ToString() + "', rowid='" + row.ToString() + "' ";
                cmd.ExecuteNonQuery();
                label14.Text = "Stack updated successfully!";

                cmd.CommandText = "select * from container where yardnum='" + yardid + "' and col='" + col + "' and rowid='" + row + "'";
                cmd.ExecuteNonQuery();
                SqlCeDataAdapter sd = new SqlCeDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int getpos()
        {
            int position;
            if (radioButton1.Checked == true)
                position = 1;
            else if (radioButton2.Checked == true)
                position = 2;
            else if (radioButton3.Checked == true)
                position = 3;
            else
                position = 4;
            return position;
        }
    }
}
