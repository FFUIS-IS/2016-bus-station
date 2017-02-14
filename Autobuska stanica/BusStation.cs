using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autobuska_stanica
{
    public partial class Bus_station : Form
    {
        public Bus_station()
        {
            InitializeComponent();
        }
        public string GetHomeDirectory()
        {
            return Directory.GetCurrentDirectory().ToString(); ;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pregledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form a = new LinesINFO();
            a.Show();
        }

        private void unosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form b = new LinesEnetery();
            b.Show();

        }

        private void unosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form c = new CarrierEntry();

            c.Show();

        }
           

        private void dataEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form d = new WorkersEntry();
            d.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form d1 = new WorkersInformation();
            d1.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form d2 = new WorkersDelete();
            d2.Show();

        }

        private void pregledToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form d3 = new CarrierInformation();
                d3.Show();

        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form d4 = new CarrierDelete();
            d4.Show();

        }

        private void pricelistToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

      

        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void issuingTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form d7 = new Tickets();
            d7.Show();

        }

        private void fromTheCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form d5 = new FromTheCity();
            d5.Show();
        }

        private void toTheCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form d6 = new ToTheCity();
            d6.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
