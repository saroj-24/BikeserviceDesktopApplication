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

namespace BikeService
{
    public partial class adminform : Form
    {
        public adminform()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            login obj1 = new login();
            obj1.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KIIT\OneDrive\Documents\Bikeservice.mdf;Integrated Security=True;Connect Timeout=30");

        private void loginbtn_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*)from admin where name='" + usertxt.Text + "' and pw='" + adminpwtext.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                BikeService bk = new BikeService();
                bk.Show();
                this.Hide();
                con.Close();
            }
            else
            {
                MessageBox.Show("Username and password wrong!!");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
