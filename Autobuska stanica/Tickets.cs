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
    public partial class Tickets : Form
    {
        public Tickets()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCeConnection Connection = DbConnection.Instance.Connection;


            SqlCeCommand command = Connection.CreateCommand();
            SqlCeCommand command1 = Connection.CreateCommand();



            command.CommandText = "SELECT ID FROM carrire WHERE name = '" + comboBox1.Text + "';";
            command1.CommandText= "SELECT ID FROM workers WHERE first_name ='" + comboBox3.Text+ "'; ";


            SqlCeDataReader rdr = command.ExecuteReader();
            rdr.Read();
            int d = rdr.GetInt32(0);


            SqlCeDataReader rdr1 = command.ExecuteReader();
            rdr1.Read();
            int j = rdr1.GetInt32(0);



            command.CommandText = "INSERT INTO tickets (carrier, workers) VALUES (" + d + " , " + j + ");";

            try
            {
                command.ExecuteNonQuery();
            }

            catch (Exception ee)
            {


                MessageBox.Show("Unos nije uspio! \r Greska: " + ee.Message);
                return;
            }


            if (comboBox1.Text == "")
            { MessageBox.Show("Niste unijeli grad polaska!"); }

            else if (comboBox1.Text == "")
            { MessageBox.Show("Niste unijeli grad dolaska!"); }

            else
            {
                MessageBox.Show("Unos je uspio!");

                comboBox1.Focus();
            }

        }

        private void Tickets_Load(object sender, EventArgs e)
        {
            SqlCeConnection Connection = DbConnection.Instance.Connection;


            SqlCeCommand command = Connection.CreateCommand();
            SqlCeCommand command1 = Connection.CreateCommand();


           
            command.CommandText = "SELECT * FROM carrier";
            command1.CommandText = "SELECT * FROM workers";

            SqlCeDataReader rdr = command.ExecuteReader();
            SqlCeDataReader rdr1 = command.ExecuteReader();


            while (rdr.Read())
            {
                comboBox1.Items.Add(rdr.GetString(1));

            }
            while (rdr1.Read())
            {
                comboBox3.Items.Add(rdr1.GetString(1));

            }


        }
    }
}
