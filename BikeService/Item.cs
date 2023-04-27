using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BikeService
{
    public partial class Item : Form
    {
        public Item()
        {
            InitializeComponent();
            showsitem();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KIIT\OneDrive\Documents\Bikeservice.mdf;Integrated Security=True;Connect Timeout=30");
        private void reset()
        {
            itemname.Text = " ";
            quantitytxt.Text = " ";
            approvedtxt.Text = "";
            takentxt.Text = " ";
            dateTimePicker.Text = "";
            timetxt.Text = "";

        }
        private void showsitem()
        {
            con.Open();
            string Query = "select *from item";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var sd = new DataSet();
            sda.Fill(sd);
            dataGridView1.DataSource = sd.Tables[0];
            con.Close();
        }

        public void error()
        {
            DateTimePicker dtp = new DateTimePicker();
            string day = dtp.Value.Day.ToString();
            if(day=="Saturday" || day=="Sunday")
            {
                MessageBox.Show("Today is weekend day!!");
            }
            
        }
        public void SetAdmin()
        {
            MessageBox.Show("approved by admin");
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTimePicker dtp = new DateTimePicker();
            string day = dtp.Value.Day.ToString();
            try
            {

                if(itemname.Text=="" || quantitytxt.Text==""|| approvedtxt.Text=="" || takentxt.Text=="" || dateTimePicker.Text=="" || timetxt.Text=="")
                {
                    MessageBox.Show("Missing Field !!!");
                }
                else
                {


                    if (approvedtxt.Text == "jimmy" || approvedtxt.Text=="ronny")
                    {
                        SetAdmin();

                        if(day=="Sunday" || day=="Saturday")
                        {
                            MessageBox.Show("today is weekend day!!");
                           
                        }
                        else
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("insert into item(itemname,quantity,approvedby,takenby,dateoftaken,time)values(@in,@iq,@ia,@itn,@dt,@it)", con);
                            cmd.Parameters.AddWithValue("@in", itemname.Text);
                            cmd.Parameters.AddWithValue("@iq", quantitytxt.Text);
                            cmd.Parameters.AddWithValue("@ia", approvedtxt.Text);
                            cmd.Parameters.AddWithValue("@itn", takentxt.Text);
                            cmd.Parameters.AddWithValue("@dt", dateTimePicker.Text);
                            cmd.Parameters.AddWithValue("@it", timetxt.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Item  Data save ");
                            con.Close();
                            showsitem();
                            reset();
                            // MessageBox.Show("Today is offday!!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Not approved by admin!!");
                    }
                       
                        
                    
                }

            }catch(Exception  messege )
            {
                MessageBox.Show(messege.Message);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }
    }
}
