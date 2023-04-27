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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void adminlabel_Click(object sender, EventArgs e)
        {
            adminform obj = new adminform();
            obj.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KIIT\OneDrive\Documents\Bikeservice.mdf;Integrated Security=True;Connect Timeout=30");
        private void loginbtn_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*)from staff where name='"+usertxt.Text+"' and phone='"+pwtext.Text+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString() =="1")
            {
                Item stf = new Item();
                stf.Show();
                this.Hide();
                con.Close();
            }
            else
            {
                MessageBox.Show("Username and password wrong!!");
            }
                 
        }
    }
}
