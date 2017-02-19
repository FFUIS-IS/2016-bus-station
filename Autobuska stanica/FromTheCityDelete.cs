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
    public partial class FromTheCityDelete : Form
    {
        public FromTheCityDelete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCeConnection Connection = DbConnection.Instance.Connection;

            SqlCeCommand command1 = Connection.CreateCommand();
            SqlCeCommand command2 = Connection.CreateCommand();

            try
            {
                command1.CommandText = "SELECT Name FROM from_the_city WHERE name ='" + comboBox1.Text + "' ; ";
                SqlCeDataReader dataReader = command1.ExecuteReader();
                dataReader.Read();
                command2.CommandText = "DELETE FROM from_the_city WHERE name =  "+ dataReader.GetInt32(0) + ";";
                SqlCeDataReader dataReader1 = command2.ExecuteReader();
                dataReader1.Read();


                MessageBox.Show("Uspjesno ste izbrisali grad polaska!");


            }
            catch (Exception ee)
            {
                MessageBox.Show("Nepostojeci grad \r Greska:" + ee.Message);
                
              }
            
        }

        private void FromTheCityDelete_Load(object sender, EventArgs e)
        {
            SqlCeConnection Connection = DbConnection.Instance.Connection;
            SqlCeCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT * FROM from_the_city";
            SqlCeDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                comboBox1.Items.Add(rdr.GetString(1));

            }
            
        }
    }
}
