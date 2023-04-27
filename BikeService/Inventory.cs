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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
            showsitem();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KIIT\OneDrive\Documents\Bikeservice.mdf;Integrated Security=True;Connect Timeout=30");

        private void reset()
        {
            itemname.Text = " ";
            quantitytxt.Text = " ";

        }
        private void showsitem()
        {
            con.Open();
            string Query = "select *from inventory";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var sd = new DataSet();
            sda.Fill(sd);
            dataGridView1.DataSource = sd.Tables[0];
            con.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            chart1.Series["Inventory Item"].Points.AddXY("Wheel", 10);
            chart1.Series["Inventory Item"].Points.AddXY("Brake pads", 40);
            chart1.Series["Inventory Item"].Points.AddXY("Screw", 50);
            chart1.Series["Inventory Item"].Points.AddXY("Engine oil", 100);
            chart1.Series["Inventory Item"].Points.AddXY("Arrow screw", 70);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(itemname.Text=="" || quantitytxt.Text=="" || dateTimePicker1.Value==null)
                {
                    MessageBox.Show("Textfield misssing!!");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into inventory(item,quantity,takentime)values(@sn,@sp,@sg)", con);
                    cmd.Parameters.AddWithValue("@sn", itemname.Text);
                    cmd.Parameters.AddWithValue("@sp", quantitytxt.Text);
                    cmd.Parameters.AddWithValue("@sg", dateTimePicker1.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff Data save ");
                    con.Close();
                    showsitem();
                    reset();
                }
            }catch(Exception message)
            {
                MessageBox.Show(message.Message);
            }
        }

        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            itemname.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            quantitytxt.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            if (itemname.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
