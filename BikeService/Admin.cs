using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeService
{
    public partial class BikeService : Form
    {
        public BikeService()
        {
            InitializeComponent();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Inventory obj2 = new Inventory();
            obj2.Show();
            //obj2.Hide()
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Staff obj = new Staff();
            obj.Show();
           // this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Item obj = new Item();
            obj.Show();
            //this.Hide();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
          

           /* chartinventory.Series["Inventory Item"].Points.Add(100);
            chartinventory.Series["Inventory Item"].Points[0].Color = Color.Cyan;
            chartinventory.Series["Inventory Item"].Points[0].AxisLabel = "Engine oil";
            chartinventory.Series["Inventory Item"].Points[0].LegendText = "Engine oil";
            chartinventory.Series["Inventory Item"].Points[0].Label = "100";*/


            chartinventory.Series["Inventory Item"].Points.AddXY("Wheel", 10);
            chartinventory.Series["Inventory Item"].Points.AddXY("Brake pads", 40);
            chartinventory.Series["Inventory Item"].Points.AddXY("Screw", 50);
            chartinventory.Series["Inventory Item"].Points.AddXY("Engine oil", 100);
            chartinventory.Series["Inventory Item"].Points.AddXY("Arrow screw", 70);

        }
    }
}
