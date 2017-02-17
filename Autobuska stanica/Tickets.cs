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
            SqlCeCommand command2 = Connection.CreateCommand();



            command.CommandText = "SELECT ID FROM carrire WHERE name = '" + carrierComboBox.Text + "';";
            command1.CommandText= "SELECT ID FROM workers WHERE first_name  ='" + workersComboBox.Text+ "'; ";
            command2.CommandText = "SELECT ID FROM lines WHERE from_the_city_id = '" + linesComboBox.Text + "';";

  

            SqlCeDataReader rdr = command.ExecuteReader();
            rdr.Read();
            int d = rdr.GetInt32(0);


            SqlCeDataReader rdr1 = command1.ExecuteReader();
            rdr1.Read();
            int j = rdr1.GetInt32(0);

            SqlCeDataReader rdr2 = command2.ExecuteReader();
            rdr2.Read();
            int k = rdr2.GetInt32(0);


            command.CommandText = "INSERT INTO tickets (carrier, workers, lines) VALUES (" + d + " , " + j + ", " + k + " );";

            try
            {
                command.ExecuteNonQuery();
            }

            catch (Exception ee)
            {


                MessageBox.Show("Unos nije uspio! \r Greska: " + ee.Message);
                return;
            }


            if (carrierComboBox.Text == "")
            { MessageBox.Show("Niste unijeli grad polaska!"); }

            else if (carrierComboBox.Text == "")
            { MessageBox.Show("Niste unijeli grad dolaska!"); }

            else
            {
                MessageBox.Show("Unos je uspio!");

                carrierComboBox.Focus();
            }

        }

        private void Tickets_Load(object sender, EventArgs e)
        {
            SqlCeConnection Connection = DbConnection.Instance.Connection;


            SqlCeCommand command = Connection.CreateCommand();
            SqlCeCommand command1 = Connection.CreateCommand();
            SqlCeCommand command2 = Connection.CreateCommand();



           
            command.CommandText = "SELECT * FROM carrier";
            command1.CommandText = "SELECT * FROM workers";
            command2.CommandText = "SELECT * FROM lines";

            SqlCeDataReader rdr = command.ExecuteReader();
            SqlCeDataReader rdr1 = command1.ExecuteReader();
            SqlCeDataReader rdr2 = command2.ExecuteReader();


          

            while (rdr.Read())
            {
                carrierComboBox.Items.Add(rdr.GetString(1));

            }
            while (rdr1.Read())
            {
                workersComboBox.Items.Add(rdr1.GetString(1)+" "+rdr1.GetString(2));
            
            }

            while(rdr2.Read())
            {
                linesComboBox.Items.Add(rdr2.GetString(1)+ "-"+ rdr2.GetString(2));
            }

                

                }

              
                 
        

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
