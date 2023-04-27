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
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
            showstaff();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KIIT\OneDrive\Documents\Bikeservice.mdf;Integrated Security=True;Connect Timeout=30");
        private void reset()
        {
            nametxt.Text = " ";
            phonetxt.Text = " ";
            comboBox1.SelectedIndex = -1;
            addresstxt.Text = " ";

        }
        private void showstaff()
        {
            con.Open();
            string Query = "select *from staff";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var sd = new DataSet();
            sda.Fill(sd);
            dataGridView1.DataSource = sd.Tables[0];
            con.Close();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {

                if(nametxt.Text==" " || phonetxt.Text==" " || comboBox1.SelectedIndex==-1 || addresstxt.Text==" ")
                {
                    MessageBox.Show("Textfield is missing!!");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into staff(name,phone,gender,address)values(@sn,@sp,@sg,@sa)",con);
                    cmd.Parameters.AddWithValue("@sn",nametxt.Text);
                    cmd.Parameters.AddWithValue("@sp", phonetxt.Text);
                    cmd.Parameters.AddWithValue("@sg", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@sa", addresstxt.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff Data save ");
                    con.Close();
                    showstaff();
                    reset();
                   
                }

            }catch(Exception messege )
            {
                MessageBox.Show(messege.Message);
            }
        }

        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             nametxt.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
             phonetxt.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
             comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
             addresstxt.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            if(nametxt.Text==" ")
            { 
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if(key==0)
            {
                MessageBox.Show("select staff!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from staff where name= @name",con);
                cmd.Parameters.AddWithValue("@name",key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff record delete!");
                con.Close();
                showstaff();
                reset();
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {

            try
            {

                if (nametxt.Text == " " || phonetxt.Text == " " || comboBox1.SelectedIndex == -1 || addresstxt.Text == " ")
                {
                    MessageBox.Show("Textfield is missing!!");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into staff(name,phone,gender,address)values(@sn,@sp,@sg,@sa)", con);
                    cmd.Parameters.AddWithValue("@sn", nametxt.Text);
                    cmd.Parameters.AddWithValue("@sp", phonetxt.Text);
                    cmd.Parameters.AddWithValue("@sg", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@sa", addresstxt.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff Data Updated!!");
                    con.Close();
                    showstaff();
                    reset();

                }

            }
            catch (Exception messege)
            {
                MessageBox.Show(messege.Message);
            }
        }
    }
}
