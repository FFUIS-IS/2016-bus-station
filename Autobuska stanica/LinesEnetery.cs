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
    public partial class LinesEnetery : Form
    {
        public LinesEnetery()
        {
            InitializeComponent();
        }

        private void LinesEnetery_Load(object sender, EventArgs e)
        {
            SqlCeConnection Connection = DbConnection.Instance.Connection;
            SqlCeCommand command = Connection.CreateCommand();
            SqlCeCommand command1 = Connection.CreateCommand();

            command.CommandText = "SELECT * FROM from_the_city";
            command1.CommandText = "SELECT * FROM to_the_city";

            SqlCeDataReader rdr = command.ExecuteReader();
            SqlCeDataReader rdr1 = command1.ExecuteReader();

            while(rdr.Read())
            {
                comboBox1.Items.Add(rdr.GetString(1));

            }
            while (rdr1.Read())
            {
                comboBox2.Items.Add(rdr1.GetString(1));

            }



        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCeConnection Connection = DbConnection.Instance.Connection;


            SqlCeCommand command = Connection.CreateCommand();
            SqlCeCommand command1 = Connection.CreateCommand();
            

            command.CommandText = "SELECT ID FROM from_the_city WHERE name = '" + comboBox1.Text + "';";
            command1.CommandText = "SELECT ID FROM to_the_city WHERE name = '" + comboBox2.Text + "';";


            SqlCeDataReader rdr = command.ExecuteReader();
            rdr.Read();
            int d = rdr.GetInt32(0);

      

            SqlCeDataReader rdr1 = command.ExecuteReader();
            rdr1.Read();
            int f = rdr1.GetInt32(0);

            command.CommandText = "INSERT INTO lines (from_the_city_id,to_the_city_id, time_of_departure, time_of_arrival, price) VALUES (" + d + ", " + f + ",'" + textBox1.Text+"','"+textBox2.Text+"', " + Int32.Parse(priceTextBox.Text) + " );";

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void WorkersEntry_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


       
