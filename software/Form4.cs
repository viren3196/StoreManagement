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
    public partial class Form4 : Form
    {
        int z = 0,total2;
        string []str;
        public Form4(string []a,int i,int total)
        {
            InitializeComponent();
            int j = 0;
            z = i;
            str = a;
            total2 = total;
            while (j < i)
            {
                this.dataGridView1.Rows.Add(a[j],a[j+1],a[j+2],a[j+3]);
                SqlConnection con = new SqlConnection("server=.;initial catalog=soft;integrated security=true");
                /*int stock = Convert.ToInt32(a[j + 4].ToString()) - Convert.ToInt32(a[j+2].ToString());
               
                SqlCommand comm = new SqlCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "update stock set [istock]=@istock where [iname]=@iname";
                comm.Parameters.AddWithValue("@iname", a[j]);
                comm.Parameters.AddWithValue("@istock", stock.ToString());
                comm.Connection = con;
                con.Open();
                comm.ExecuteNonQuery();
                con.Close();*/
                j += 6;                     
            }
            this.dataGridView1.Rows.Add("", "", "", "");
            this.dataGridView1.Rows.Add("", "", "Grand Total", total);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }


        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.Font = new Font("Serif", 12, FontStyle.Regular);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button2.Enabled == true)
            {
                DialogResult dr = MessageBox.Show("Sure you want to cancel the Bill?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.Hide();
                    Form1 ob1 = new Form1();
                    ob1.Show();
                }
            }
            else
            {
                this.Hide();
                Form1 ob1 = new Form1();
                ob1.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int j = 0;

            SqlConnection con = new SqlConnection("server=.;initial catalog=soft;integrated security=true");
            con.Open();
            string k = DateTime.Now.Date.ToString();
            SqlDataAdapter ad3 = new SqlDataAdapter("select * from today where iday = '" + k + "' ", con);
            DataSet ds3 = new DataSet();
            ad3.Fill(ds3, "try");
            if (ds3.Tables[0].Rows.Count == 0)
            {
                SqlCommand comm1 = new SqlCommand();
                comm1.CommandType = CommandType.Text;

                comm1.CommandText = "insert into today(iday,collect1,collect2,collect3,collect4) values ('" + k + "','0','0','0','0');";
                comm1.Connection = con;
                comm1.ExecuteNonQuery();
            }

            while (j < z)
            {
                //this.dataGridView1.Rows.Add(a[j], a[j + 1], a[j + 2], a[j + 3]);
                
                int stock = Convert.ToInt32(str[j + 4].ToString()) - Convert.ToInt32(str[j + 2].ToString());

                SqlCommand comm = new SqlCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = "update stock set [istock]=@istock where [iname]=@iname";
                comm.Parameters.AddWithValue("@iname", str[j]);
                comm.Parameters.AddWithValue("@istock", stock.ToString());
                comm.Connection = con;
                comm.ExecuteNonQuery();

                
                
                if (str[j + 5].Equals("Cosmetics"))
                {                   
                    SqlConnection conn = new SqlConnection("server=.;initial catalog=soft;integrated security=true");
                    conn.Open();
                    SqlDataAdapter ad = new SqlDataAdapter("select * from collection", conn);
                    DataSet ds = new DataSet();
                    ad.Fill(ds, "try");
                    int grand = Convert.ToInt32(ds.Tables[0].Rows[0][2]);

                    SqlCommand comm1 = new SqlCommand();
                    comm1.CommandText = "update today set [collect1]=[collect1] + @collect1, [collect2]= [collect2]+ @collect2 where iday='" + k + "' ";
                    comm1.Parameters.AddWithValue("@collect1",Convert.ToInt32(str[j+3]));
                    comm1.Parameters.AddWithValue("@collect2",Convert.ToInt32(str[j+3]));
                    comm1.Connection = conn;
                    comm1.ExecuteNonQuery();


                    SqlCommand comm3 = new SqlCommand();
                    comm3.CommandText = "update collection set [collect1]= @icollect";
                    int cx = Convert.ToInt32(str[j+1]) * Convert.ToInt32(str[j+2]);
                    cx += grand;
                    comm3.Parameters.AddWithValue("@icollect", cx);
                    comm3.Connection = conn;
                    comm3.ExecuteNonQuery();
                    conn.Close();
                }
                else if (str[j + 5].Equals("Food"))
                {
                    SqlConnection conn = new SqlConnection("server=.;initial catalog=soft;integrated security=true");
                    conn.Open();
                    SqlDataAdapter ad = new SqlDataAdapter("select * from collection", conn);
                    DataSet ds = new DataSet();
                    ad.Fill(ds, "try");
                    int grand = Convert.ToInt32(ds.Tables[0].Rows[0][3]);

                    SqlCommand comm1 = new SqlCommand();
                    comm1.CommandText = "update today set [collect1]=[collect1] + @collect1, [collect3]= [collect3]+ @collect3 where iday='" + k + "' ";
                    comm1.Parameters.AddWithValue("@collect1", Convert.ToInt32(str[j + 3]));
                    comm1.Parameters.AddWithValue("@collect3", Convert.ToInt32(str[j + 3]));
                    comm1.Connection = conn;
                    comm1.ExecuteNonQuery();

                    SqlCommand comm3 = new SqlCommand();
                    comm3.CommandText = "update collection set [collect2]= @icollect";
                    int cx = Convert.ToInt32(str[j + 1]) * Convert.ToInt32(str[j + 2]);
                    cx += grand;
                    comm3.Parameters.AddWithValue("@icollect", cx);
                    comm3.Connection = conn;
                    comm3.ExecuteNonQuery();
                    conn.Close();
                }
                else if (str[j + 5].Equals("Others"))
                {
                    SqlConnection conn = new SqlConnection("server=.;initial catalog=soft;integrated security=true");
                    conn.Open();
                    SqlDataAdapter ad = new SqlDataAdapter("select * from collection", conn);
                    DataSet ds = new DataSet();
                    ad.Fill(ds, "try");
                    int grand = Convert.ToInt32(ds.Tables[0].Rows[0][4]);
                    

                    SqlCommand comm1 = new SqlCommand();
                    comm1.CommandText = "update today set [collect1]=[collect1] + @collect1, [collect4]= [collect4]+ @collect4 where iday='" + k + "' ";
                    comm1.Parameters.AddWithValue("@collect1", Convert.ToInt32(str[j + 3]));
                    comm1.Parameters.AddWithValue("@collect4", Convert.ToInt32(str[j + 3]));
                    comm1.Connection = conn;
                    comm1.ExecuteNonQuery();

                    SqlCommand comm3 = new SqlCommand();
                    comm3.CommandText = "update collection set [collect3]=@icollect";
                    int cx = Convert.ToInt32(str[j + 1]) * Convert.ToInt32(str[j + 2]);
                    cx += grand;
                    comm3.Parameters.AddWithValue("@icollect", cx);
                    comm3.Connection = conn;
                    comm3.ExecuteNonQuery();
                    conn.Close();
                }
              
                j += 6;
            }
            SqlConnection conn2 = new SqlConnection("server=.;initial catalog=soft;integrated security=true");
            conn2.Open();
            SqlDataAdapter ad2 = new SqlDataAdapter("select * from collection", conn2);
            DataSet ds2 = new DataSet();
            ad2.Fill(ds2, "try");
            int grand2 = Convert.ToInt32(ds2.Tables[0].Rows[0][0]);
            conn2.Close();
            grand2 += total2;

            SqlCommand comm4 = new SqlCommand();
            comm4.CommandType = CommandType.Text;
            comm4.CommandText = "update collection set [collect]=@collect";
            comm4.Parameters.AddWithValue("@collect", grand2);
            comm4.Connection = conn2;
            conn2.Open();
            comm4.ExecuteNonQuery();
            button2.Enabled = false;

            

            
        }
    }
}
