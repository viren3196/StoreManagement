using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace software
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label1.Font = new Font("Serif", 15, FontStyle.Regular);
            label2.Font = new Font("Serif", 15, FontStyle.Regular);
            label3.Font = new Font("Serif", 15, FontStyle.Regular);
            label4.Font = new Font("Serif", 15, FontStyle.Regular);
            label5.Font = new Font("Serif", 15, FontStyle.Regular);
            label6.Font = new Font("Serif", 15, FontStyle.Regular);
            label7.Font = new Font("Serif", 15, FontStyle.Regular);
            label8.Font = new Font("Serif", 15, FontStyle.Regular);
            label9.Font = new Font("Serif", 15, FontStyle.Regular);
            label10.Font = new Font("Serif", 15, FontStyle.Regular);

            button1.Font = new Font("Serif", 15, FontStyle.Regular);
            button2.Font = new Font("Serif", 15, FontStyle.Regular);
            
            textBox1.Font = new Font("Serif", 15, FontStyle.Regular);
            textBox2.Font = new Font("Serif", 15, FontStyle.Regular);
            textBox3.Font = new Font("Serif", 15, FontStyle.Regular);
            textBox4.Font = new Font("Serif", 15, FontStyle.Regular);
            textBox5.Font = new Font("Serif", 15, FontStyle.Regular);
            textBox6.Font = new Font("Serif", 15, FontStyle.Regular);
            textBox7.Font = new Font("Serif", 15, FontStyle.Regular);
            textBox8.Font = new Font("Serif", 15, FontStyle.Regular);
            textBox9.Font = new Font("Serif", 15, FontStyle.Regular);
            

            

            SqlConnection conn = new SqlConnection("server=.;initial catalog=soft;integrated security=true");
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("select * from collection", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "try");
            int grand = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            textBox1.Text = grand.ToString();
            textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
            textBox3.Text = ds.Tables[0].Rows[0][2].ToString();
            textBox4.Text = ds.Tables[0].Rows[0][3].ToString();
            textBox5.Text = ds.Tables[0].Rows[0][4].ToString();

            string k = DateTime.Now.Date.ToString();
                
            SqlDataAdapter ad2 = new SqlDataAdapter("select * from today where iday = '"+k+"'", conn);
            DataSet ds2 = new DataSet();
            ad2.Fill(ds2, "try");
            if (ds2.Tables[0].Rows.Count != 0)
            {
                textBox6.Text = ds2.Tables[0].Rows[0][1].ToString();
                textBox7.Text = ds2.Tables[0].Rows[0][2].ToString();
                textBox8.Text = ds2.Tables[0].Rows[0][3].ToString();
                textBox9.Text = ds2.Tables[0].Rows[0][4].ToString();
            }
            else
            {
                textBox6.Text = "0";
                textBox7.Text = "0";
                textBox8.Text = "0";
                textBox9.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ob = new Form1();
            ob.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Sure you want to reset?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection("server=.;initial catalog=soft;integrated security=true");
                SqlCommand comm1 = new SqlCommand();
                comm1.CommandType = CommandType.Text;
                comm1.CommandText = "update collection set [collect]=@collect,[resettime]=@date,[collect1]=@collect1,[collect2]=@collect2,[collect3]=@collect3";
                comm1.Parameters.AddWithValue("@collect", 0);
                comm1.Parameters.AddWithValue("@collect1", 0);
                comm1.Parameters.AddWithValue("@collect2", 0);
                comm1.Parameters.AddWithValue("@collect3", 0);
                comm1.Parameters.AddWithValue("@date",System.DateTime.Now.ToString());
                comm1.Connection = conn;
                conn.Open();
                comm1.ExecuteNonQuery();
                conn.Close();
                textBox1.Text = 0.ToString();
                textBox3.Text = 0.ToString();
                textBox4.Text = 0.ToString();
                textBox5.Text = 0.ToString();
                textBox2.Text = System.DateTime.Now.ToString(); 
            }
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            string k = monthCalendar1.SelectionRange.Start.Date.ToString();
            SqlConnection conn = new SqlConnection("server=.;initial catalog=soft;integrated security=true");
            conn.Open();
            SqlDataAdapter ad2 = new SqlDataAdapter("select * from today where iday = '" + k + "'", conn);
            DataSet ds2 = new DataSet();
            ad2.Fill(ds2, "try");
            if (ds2.Tables[0].Rows.Count != 0)
            {
                textBox6.Text = ds2.Tables[0].Rows[0][1].ToString();
                textBox7.Text = ds2.Tables[0].Rows[0][2].ToString();
                textBox8.Text = ds2.Tables[0].Rows[0][3].ToString();
                textBox9.Text = ds2.Tables[0].Rows[0][4].ToString();
            }
            else
            {
                textBox6.Text = "0";
                textBox7.Text = "0";
                textBox8.Text = "0";
                textBox9.Text = "0";
            }
        }
    }
}
