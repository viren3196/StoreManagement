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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string x = "";
            if (textBox1.Text.Equals(x) || textBox2.Text.Equals(x) || textBox3.Text.Equals(x))
                MessageBox.Show("Enter all fields");
            else if (comboBox1.SelectedIndex.Equals(-1))
                MessageBox.Show("select category");
            else
            {
                SqlConnection con = new SqlConnection("server=.;initial catalog=soft;integrated security=true");
                con.Open();
                SqlCommand insert = new SqlCommand("Insert into stock(iname,iunit,istock,icategory) values (@iname,@iunit,@istock,@icategory)", con);
                insert.Parameters.AddWithValue("iname", textBox1.Text);
                insert.Parameters.AddWithValue("iunit",Convert.ToInt32(textBox2.Text));
                insert.Parameters.AddWithValue("istock",Convert.ToInt32(textBox3.Text));
                insert.Parameters.AddWithValue("icategory", comboBox1.SelectedItem.ToString());
                insert.ExecuteNonQuery();

                con.Close();
                this.Hide();
                MessageBox.Show("Record Inserted!");
                this.Hide();
                Form1 o = new Form1 ();
                o.Show();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Font = new Font("Serif", 12, FontStyle.Regular);
            label2.Font = new Font("Serif", 12, FontStyle.Regular);
            label3.Font = new Font("Serif", 12, FontStyle.Regular);
            label4.Font = new Font("Serif", 12, FontStyle.Regular);

            textBox1.Font = new Font("Serif", 12, FontStyle.Regular);
            textBox2.Font = new Font("Serif", 12, FontStyle.Regular);
            textBox3.Font = new Font("Serif", 12, FontStyle.Regular);

            button1.Font = new Font("Serif", 12, FontStyle.Regular);
            button2.Font = new Font("Serif", 12, FontStyle.Regular);

            comboBox1.Font = new Font("Serif", 12, FontStyle.Regular);
            comboBox1.Items.Add("Cosmetics");
            comboBox1.Items.Add("Food");
            comboBox1.Items.Add("Others");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 o = new Form1();
            o.Show();
        }
    }
}
