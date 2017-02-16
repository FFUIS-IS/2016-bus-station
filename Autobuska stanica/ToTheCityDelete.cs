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
    public partial class ToTheCityDelete : Form
    {
        public ToTheCityDelete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCeConnection Connection = DbConnection.Instance.Connection;

            SqlCeCommand command1 = Connection.CreateCommand();
         

            try
            {
                command1.CommandText = "SELECT name FROM to_the_city WHERE name='" + textBox1.Text + "' ; ";
                SqlCeDataReader dataReader = command1.ExecuteReader();
                dataReader.Read();
               

                MessageBox.Show("Uspjesno ste izbrisali grad!");


            }
            catch (Exception ee)
            {
                MessageBox.Show("Nepostojeci grad\r Greska:" + ee.Message);
                textBox1.Clear();
                textBox1.Focus();

            }


        }
    }
}

        
