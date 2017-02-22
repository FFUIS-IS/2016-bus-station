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
    public partial class ToTheCity: Form
    {
        public ToTheCity()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            { MessageBox.Show("Niste unijeli ime grada!"); }


            else
            {


                SqlCeConnection Connection = DbConnection.Instance.Connection;

                SqlCeCommand command = new SqlCeCommand("INSERT INTO to_the_city ([Name]) VALUES ('" + textBox1.Text + "'); ", Connection);

                try
                {

                    command.ExecuteNonQuery();
                    MessageBox.Show("Unos je uspio!");
                    textBox1.Clear();
                    textBox1.Focus();


                }

                catch (Exception ee)
                {


                    MessageBox.Show("Unos nije uspio! \r Greska: " + ee.Message);
                    return;

                }



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToTheCity_Load(object sender, EventArgs e)
        {

        }
    }
}
