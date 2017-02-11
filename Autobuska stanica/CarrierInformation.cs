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
    public partial class CarrierInformation : Form
    {
        public CarrierInformation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                /*onaj prvi red */
                SqlCeConnection Connection = DbConnection.Instance.Connection;

                /*onaj drugi red*/
                SqlCeCommand command = new SqlCeCommand("SELECT Name, Address FROM Carrier ", Connection);

                SqlCeDataReader dataReader = command.ExecuteReader();


                //dataReader.Read();

                while (dataReader.Read())
                {

                    listBox1.Items.Add(dataReader.GetString(0) + "  " + dataReader.GetString(1));
                }
                dataReader.Close();
            }

            catch (Exception ee)
            {
                MessageBox.Show(" Greska: " + ee.Message);
                return;


            }

        }
    }
}
