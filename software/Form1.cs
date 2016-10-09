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

    public partial class Form1 : Form
    {
        //public struct stud
        //{
        //    public
        //    string w, x, y, z;
        //};
        //stud[] arr = new stud[100];
        string x1, y1, z1;
        int k1;
        int i = 0;
        string []arr = new string[500];
        int add = 0,g=0;
        public Form1()
        {
            InitializeComponent();
            
            /*SqlConnection con = new SqlConnection("server=VIREN;initial catalog=soft;integrated security=true");
            con.Open();
            MessageBox.Show(comboBox1.Items.Count.ToString());
            if (comboBox1.Items.Count != 0)
            {
                string k = comboBox1.SelectedItem.ToString();
                string SQL = String.Format("select * from stock where iname = '{0}' ", k);
                SqlDataAdapter ad = new SqlDataAdapter(SQL, con);
                DataSet ds = new DataSet();
                ad.Fill(ds, "try");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    textBox1.Text = Convert.ToString(ds.Tables[0].Rows[0][1]);
                    textBox2.Text = Convert.ToString(ds.Tables[0].Rows[0][2]);
                }
            }*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {                                                                                                                       
            Form2 ob = new Form2();
            this.Hide();
            ob.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

            label1.Font = new Font("Serif", 24, FontStyle.Regular);
            label2.Font = new Font("Serif", 12, FontStyle.Regular);
            label3.Font = new Font("Serif", 12, FontStyle.Regular);
            label4.Font = new Font("Serif", 12, FontStyle.Regular);
            label5.Font = new Font("Serif", 12, FontStyle.Regular);
            label6.Font = new Font("Serif", 12, FontStyle.Regular);
            label7.Font = new Font("Serif", 12, FontStyle.Regular);
            label8.Font = new Font("Serif", 12, FontStyle.Regular);
            label9.Font = new Font("Serif", 12, FontStyle.Regular);

            button1.Font = new Font("Serif", 12, FontStyle.Regular);
            button2.Font = new Font("Serif", 12, FontStyle.Regular);
            button3.Font = new Font("Serif", 12, FontStyle.Regular);
            button4.Font = new Font("Serif", 12, FontStyle.Regular);
            button5.Font = new Font("Serif", 12, FontStyle.Regular);
            button6.Font = new Font("Serif", 12, FontStyle.Regular);
            button7.Font = new Font("Serif", 12, FontStyle.Regular);

            textBox1.Font = new Font("Serif", 12, FontStyle.Regular);
            textBox2.Font = new Font("Serif", 12, FontStyle.Regular);
            textBox3.Font = new Font("Serif", 12, FontStyle.Regular);
            textBox4.Font = new Font("Serif", 12, FontStyle.Regular);
            textBox5.Font = new Font("Serif", 12, FontStyle.Regular);
            textBox6.Font = new Font("Serif", 12, FontStyle.Regular);

            comboBox1.Font = new Font("Serif", 12, FontStyle.Regular);
            comboBox2.Font = new Font("Serif", 12, FontStyle.Regular);

            comboBox2.SelectedIndex = -1;
            

            SqlConnection con = new SqlConnection("server=.;initial catalog=soft;integrated security=true");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select iname from stock order by iname", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "iname";  
            comboBox1.DataSource = dt;
            for (int i = 1; i <= 20; i++)
                comboBox2.Items.Add(i);
            if (comboBox1.Items.Count != 0)
            {
                string k = comboBox1.SelectedValue.ToString();
                string SQL = String.Format("select * from stock where iname = '{0}' ", k);
                SqlDataAdapter ad = new SqlDataAdapter(SQL, con);
                DataSet ds = new DataSet();
                ad.Fill(ds, "try");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    textBox1.Text = Convert.ToString(ds.Tables[0].Rows[0][1]);
                    textBox2.Text = Convert.ToString(ds.Tables[0].Rows[0][2]);
                    textBox6.Text = ds.Tables[0].Rows[0][3].ToString();
                }
            }
            textBox4.Text = add.ToString();
            con.Close();
            button5.Enabled = false;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=.;initial catalog=soft;integrated security=true");
            con.Open();
            if (comboBox1.Items.Count != 0)
            {
                string k = comboBox1.SelectedValue.ToString();
                string SQL = String.Format("select * from stock where iname = '{0}' ", k);
                SqlDataAdapter ad = new SqlDataAdapter(SQL, con);
                DataSet ds = new DataSet();
                ad.Fill(ds, "try");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    textBox1.Text = Convert.ToString(ds.Tables[0].Rows[0][1]);
                    textBox2.Text = Convert.ToString(ds.Tables[0].Rows[0][2]);
                    textBox6.Text = ds.Tables[0].Rows[0][3].ToString();
                }
            }
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = comboBox1.SelectedValue.ToString();
            string t = textBox1.Text;
            string r = textBox2.Text;
            int k = Convert.ToInt32(comboBox2.SelectedItem);
            if (s.Equals(x1) && t.Equals(y1) && r.Equals(z1) && k1 == k)
            {
                MessageBox.Show("This item is already added!");
            }
            else
            {
                if (comboBox2.SelectedIndex.Equals(-1))
                    MessageBox.Show("select quantity");
                else if (k > Convert.ToInt32(textBox2.Text))
                {
                    MessageBox.Show("Check stock");
                }
                else
                {
                    textBox3.Text = (k * Convert.ToInt32(textBox1.Text)).ToString();
                    g += Convert.ToInt32(textBox3.Text);
                    textBox5.Text = g.ToString();
                    add++;
                    textBox4.Text = add.ToString();

                    arr[i] = comboBox1.SelectedValue.ToString();
                    arr[i + 1] = textBox1.Text;
                    arr[i + 2] = comboBox2.SelectedItem.ToString();
                    arr[i + 3] = textBox3.Text;
                    arr[i + 4] = textBox2.Text;
                    arr[i + 5] = textBox6.Text;
                    i += 6;
                }
                x1 = s;
                y1 = t;
                z1 = r;
                k1 = k;
            }
            button5.Enabled = true;
            comboBox2.SelectedIndex = -1;
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            add=0;
            g=0;
            i = 0;
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            button5.Enabled = false;
            comboBox2.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = comboBox1.SelectedValue.ToString();
            string t = textBox1.Text;
            string r = textBox2.Text;
            this.Hide();
            Form3 ob=new Form3(s,t,r);
            ob.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Sure?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string x = comboBox1.SelectedValue.ToString();
                SqlConnection con = new SqlConnection("server=.;initial catalog=soft;integrated security=true");

                //string SQL = String.Format("update stock set iunit = '{0}' istock='{1}' where iname = '{2}' ",textBox2.Text,textBox3.Text, textBox1.Text);
                SqlCommand comm = new SqlCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "delete from stock where iname=@iname";
                comm.Parameters.AddWithValue("@iname",x);
                comm.Connection = con;
                con.Open();
                comm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted");
                this.Hide();
                Form1 ob = new Form1();
                ob.Show();
            }
            else
            {
                ;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //pair<pair<string, string>, pair<string, string>> p;
            //Tuple<Tuple<string, string>, Tuple<string, string>>[] tup;
            //tup[0].Item1.Item1 = "abs";
            //tup[0].Item1.Item2.Equals("abc");
            //tup[0].Item2.Item1.Equals("abc");
            //tup[0].Item2.Item2.Equals("abc");
            this.Hide();
            Form4 ob = new Form4(arr,i,Convert.ToInt32(textBox5.Text));
            ob.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 ob = new Form5();
            ob.Show();
        }

    }
    
}
