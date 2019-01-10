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
                SqlCeConnection conn = new SqlCeConnection("Data Source=D:\\containerinfo.sdf;Persist Security Info=False;");
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


        private void button1_Click(object sender, EventArgs e)
        {                
            try
            {
                int position = getpos(yardid);
                if (position == 0)
                    return;

                SqlCeConnection conn = new SqlCeConnection("Data Source=D:\\containerinfo.sdf;Persist Security Info=False;");
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
            bool flag = true;
            try
            {
                SqlCeConnection conn = new SqlCeConnection("Data Source=D:\\containerinfo.sdf;Persist Security Info=False;");
                conn.Open();
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select count(position) from container where containerid='" + textBox1.Text + "'";
                SqlCeDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    if ((int)rd[0] == 0)
                    {
                        MessageBox.Show("Container does not exist");
                        flag = false;
                    }
                }
                if (flag)
                {
                    cmd.CommandText = "delete from container where containerid='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    label14.Text = "Container deleted successfully!";
                }

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
            bool flag = true;
            try
            {
                SqlCeConnection conn = new SqlCeConnection("Data Source=D:\\containerinfo.sdf;Persist Security Info=False;");
                conn.Open();
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select count(position) from container where containerid='" + textBox1.Text + "'";
                SqlCeDataReader rd = cmd.ExecuteReader();
                if(rd.Read())
                { if ((int)rd[0] == 0)
                    {
                        MessageBox.Show("Container does not exist");
                        flag = false;
                    }
                }

                if (flag)
                {
                    cmd.CommandText = "update container set vesselnum='" + textBox3.Text + "', voyagenum='" + textBox4.Text + "', containersize='" + textBox6.Text + "', agent='" + textBox2.Text + "', containertype='" + textBox5.Text + "' where containerid='"+textBox1.Text+"'";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int getpos(int yardid)
        {
            int position=0, max, count;
            if (yardid == 2 || yardid == 3 || yardid == 4 || yardid == 6)
                max = 3;
            else max = 4;

            SqlCeConnection conn = new SqlCeConnection("Data Source=D:\\containerinfo.sdf;Persist Security Info=False;");
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select count(position) from container where yardnum='" + yardid + "' and col='"+col+"' and rowid='"+row+"'";
            SqlCeDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                count = (int)rd[0];
                conn.Close();

                if (count < max)
                    position = count+1;
                else
                {
                    MessageBox.Show("Cannot stack more containers, please place container in another slot");
                }
                return position;
            }
            return position;
        }
    }
}
