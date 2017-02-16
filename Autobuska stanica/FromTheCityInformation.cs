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
    public partial class FromTheCityInformation : Form
    {
        public FromTheCityInformation()
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
                SqlCeCommand command = new SqlCeCommand("SELECT name FROM from_the_city ", Connection);

                SqlCeDataReader dataReader = command.ExecuteReader();


                //dataReader.Read();

                while (dataReader.Read())
                {

                    listBox1.Items.Add(dataReader.GetString(0));
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
