using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;


namespace Autobuska_stanica
{
    public partial class CarrierEntry : Form
    {
        public CarrierEntry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Niste unijeli naziv prevoznika!");
            }

            else if (textBox2.Text == "")
            {
                MessageBox.Show("Niste unijeli adresu!");
            }

            else
            {

                SqlCeConnection Connection = DbConnection.Instance.Connection;

                SqlCeCommand command = new SqlCeCommand("INSERT INTO Carrier ([Name],[Address]) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "'); ", Connection);

                try
                {


                    command.ExecuteNonQuery();
                    MessageBox.Show("Unos je uspio!");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }



                catch (Exception ee)
                {


                    MessageBox.Show("Unos nije uspio! \r Greska: " + ee.Message);
                    return;

                }


            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarrierEntry_Load(object sender, EventArgs e)
        {

        }
    }
}

