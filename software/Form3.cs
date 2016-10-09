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
    public partial class Form3 : Form
    {
        string x, y, z;

        public Form3(string s,string t, string r)
        {
            InitializeComponent();
            textBox1.Text = s;
            textBox2.Text = t;
            textBox3.Text = r;
            x = s;
            y = t;
            z = r;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Font = new Font("Serif", 12, FontStyle.Regular);
            label2.Font = new Font("Serif", 12, FontStyle.Regular);
            label3.Font = new Font("Serif", 12, FontStyle.Regular);

            textBox1.Font = new Font("Serif", 12, FontStyle.Regular);
            textBox2.Font = new Font("Serif", 12, FontStyle.Regular);
            textBox3.Font = new Font("Serif", 12, FontStyle.Regular);

            button1.Font = new Font("Serif", 12, FontStyle.Regular);
            button2.Font = new Font("Serif", 12, FontStyle.Regular);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("server=.;initial catalog=soft;integrated security=true");                                                                

                //string SQL = String.Format("update stock set iunit = '{0}' istock='{1}' where iname = '{2}' ",textBox2.Text,textBox3.Text, textBox1.Text);
                SqlCommand comm = new SqlCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "update stock set [iunit]=@iunit,istock=@istock where [iname]=@iname";
                comm.Parameters.AddWithValue("@iname", textBox1.Text);
                comm.Parameters.AddWithValue("@iunit", textBox2.Text);
                comm.Parameters.AddWithValue("@istock", textBox3.Text);
                comm.Connection = con;
                con.Open();
                comm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated");
                this.Hide();
                Form1 ob = new Form1();
                ob.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ob = new Form1();
            ob.Show();
        }
    }
}
