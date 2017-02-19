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

            SqlCeCommand command = Connection.CreateCommand();

            DialogResult dr = MessageBox.Show("Da li želite da izbrišete ?", "Brisanje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {

                comboBox1.Items.Remove(comboBox1.SelectedItem);

                command.CommandText = "DELETE FROM lines WHERE from_the_city_id = '" + comboBox1.SelectedItem + "'  ";
                command.ExecuteReader();

            }
            else if (dr == DialogResult.No)
            {

                this.Close();
                LinesDelete CI = new LinesDelete();
                CI.Show();

            }
        }
    }
}
