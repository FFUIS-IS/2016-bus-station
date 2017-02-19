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
                SqlCeCommand command = new SqlCeCommand("SELECT name FROM from_the_city;", Connection);

                SqlCeDataReader dataReader = command.ExecuteReader();

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


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlCeConnection Connection = DbConnection.Instance.Connection;

            SqlCeCommand command = Connection.CreateCommand();

            DialogResult dr = MessageBox.Show("Da li želite da izbrišete ?", "Brisanje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {

                listBox1.Items.Remove(listBox1.SelectedItem);

                command.CommandText = "DELETE FROM from_the_city WHERE name = '" + listBox1.SelectedItem + "'  ";
                command.ExecuteReader();

            }
            else if (dr == DialogResult.No)
            {

                this.Close();
                FromTheCityInformation CI = new FromTheCityInformation();
                CI.Show();

            }
        }
    }
}
