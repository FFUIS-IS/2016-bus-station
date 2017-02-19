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
    public partial class LinesDelete : Form
    {
        public LinesDelete()
        {
            InitializeComponent();
        }

        private void LinesDelete_Load(object sender, EventArgs e)
        {
            SqlCeConnection Connection = DbConnection.Instance.Connection;

            SqlCeCommand command = Connection.CreateCommand();

            command.CommandText = "SELECT * FROM LINES";


            SqlCeDataReader rdr = command.ExecuteReader();


            while (rdr.Read())
            {
                
                
                    SqlCeDataReader reserveReader;
                    string info;

                    int from = rdr.GetInt32(1);
                    int toCity = rdr.GetInt32(2);

                    command.CommandText = "SELECT name FROM from_the_city WHERE id = " + from + ";";

                    reserveReader = command.ExecuteReader();
                    reserveReader.Read();

                    info = reserveReader.GetString(0);
                    command.CommandText = "SELECT name FROM to_the_city WHERE id = " + toCity + ";";

                    reserveReader = command.ExecuteReader();
                    reserveReader.Read();

                    info += " - " + reserveReader.GetString(0);
                   comboBox1.Items.Add(rdr.GetInt32(0) + " " + info);
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCeConnection Connection = DbConnection.Instance.Connection;

            SqlCeCommand command1 = Connection.CreateCommand();
            SqlCeCommand command2 = Connection.CreateCommand();

            try
            {
                int indexOfLine = Int32.Parse(comboBox1.SelectedItem.ToString().Substring(0, comboBox1.SelectedItem.ToString().IndexOf(' ')));

                command1.CommandText = "SELECT from_the_citiy_id, to_the_city_id FROM lines WHERE from_the_city_id='" + comboBox1.Text + "' ; ";
                SqlCeDataReader dataReader = command1.ExecuteReader();
                dataReader.Read();
                command2.CommandText = "DELETE FROM lines  WHERE to_the_city_id=" + dataReader.GetInt32(0) + " ;";
                SqlCeDataReader dataReader1 = command2.ExecuteReader();
                dataReader1.Read();

                MessageBox.Show("Uspjesno ste izbrisali radnika!");


            }
            catch (Exception ee)
            {
                MessageBox.Show("Nepostojeca linija prevoza\r Greska:" + ee.Message);
                
            }
        }
    }
}
