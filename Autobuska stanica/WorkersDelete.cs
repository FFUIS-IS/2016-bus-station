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
using Autobuska_stanica;

namespace Autobuska_stanica
{
    public partial class WorkersDelete : Form
    {
        public WorkersDelete()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCeConnection Connection = DbConnection.Instance.Connection;

            SqlCeCommand command1 = Connection.CreateCommand();
            SqlCeCommand command2 = Connection.CreateCommand();

            try
            {
                command1.CommandText = "SELECT first_name FROM workers WHERE first_name='"+textBox1.Text+ "' ; " ;
                SqlCeDataReader dataReader = command1.ExecuteReader();
                dataReader.Read();
                command2.CommandText = "DELETE FROM workers WHERE first_name='" + dataReader.GetString(0) + "' ;";
                SqlCeDataReader dataReader1 = command2.ExecuteReader();
                dataReader1.Read();

                MessageBox.Show("Uspjesno ste izbrisali radnika!");


            }
            catch(Exception ee)
            {
                MessageBox.Show("Nepostojeci radnik\r Greska:" + ee.Message);
                textBox1.Clear();
                textBox1.Focus();

            }


        }
    }
}
