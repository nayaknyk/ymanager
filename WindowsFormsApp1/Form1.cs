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
using OfficeOpenXml;
using System.IO;

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

        private void button8_Click(object sender, EventArgs e)
        {
            createExcel();
        }

        private DataSet GetData()
        {
            SqlCeConnection conn = new SqlCeConnection("Data Source=C:\\Users\\nikhil\\Documents\\github\\ymanager\\WindowsFormsApp1\\bin\\Debug\\containerinfo.sdf;Persist Security Info=False;");
            conn.Open();
            DataSet ds = new DataSet("Containers");
            SqlCeCommand cmd = conn.CreateCommand();
            for (int yardid = 1; yardid <= 6; yardid++)
            {
                DataTable dt = new DataTable(yardid.ToString());
                cmd.CommandText = "select * from container where yardnum='" + yardid + "'";
                SqlCeDataReader rd = cmd.ExecuteReader();
                if(rd.Read())
                {
                    dt.Load(rd);
                }
                ds.Tables.Add(dt);
            }
            conn.Close();
            return ds;
        }

        private void createExcel()
        {
            try
            {
                using (DataSet ds = GetData())
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        using (ExcelPackage xp = new ExcelPackage())
                        {
                            foreach (DataTable dt in ds.Tables)
                            {
                                ExcelWorksheet ws = xp.Workbook.Worksheets.Add(dt.TableName);

                                int rowstart = 2;
                                int colstart = 2;
                                int rowend = rowstart;
                                int colend = colstart + dt.Columns.Count;

                                ws.Cells[rowstart, colstart, rowend, colend].Merge = true;
                                ws.Cells[rowstart, colstart, rowend, colend].Value = dt.TableName;
                                ws.Cells[rowstart, colstart, rowend, colend].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                ws.Cells[rowstart, colstart, rowend, colend].Style.Font.Bold = true;
                                ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

                                rowstart += 2;
                                rowend = rowstart + dt.Rows.Count;
                                ws.Cells[rowstart, colstart].LoadFromDataTable(dt, true);
                                int i = 1;
                                foreach (DataColumn dc in dt.Columns)
                                {
                                    i++;
                                    if (dc.DataType == typeof(decimal))
                                        ws.Column(i).Style.Numberformat.Format = "#0.00";
                                }
                                ws.Cells[ws.Dimension.Address].AutoFitColumns();



                                ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Top.Style =
                                   ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Bottom.Style =
                                   ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Left.Style =
                                   ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                            }
                            using (FileStream aFile = new FileStream(@"D:\container.xlsx", FileMode.Create))
                            {
                                aFile.Seek(0, SeekOrigin.Begin);
                                xp.SaveAs(aFile);
                                aFile.Close();
                            }
                        }
                    }
                }
                MessageBox.Show("Report saved successfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
