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
using System.IO;
using System.Data.SqlTypes;



namespace Autobuska_stanica
{
    public partial class WorkersInformation : Form
    {
        public WorkersInformation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                
                 SqlCeConnection Connection = DbConnection.Instance.Connection;
           
                
            SqlCeCommand command = new SqlCeCommand("SELECT first_name, last_name FROM workers ", Connection);

            SqlCeDataReader dataReader = command.ExecuteReader();


                dataReader.Read();

                while (dataReader.Read())
             {
                    
                listBox1.Items.Add(dataReader.GetString(0) + "  " + dataReader.GetString(1));
             }
             dataReader.Close();
            }

            catch (Exception ee)
            {
                MessageBox.Show(" Greska: " + ee.Message);
                return;


            }







        }

        private void WorkersInformation_Load(object sender, EventArgs e)
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

                command.CommandText = "DELETE FROM workers WHERE first_name = '" + listBox1.SelectedItem + "'  ";
                command.ExecuteReader();

            }
            else if (dr == DialogResult.No)
            {

                this.Close();
                CarrierInformation CI = new CarrierInformation();
                CI.Show();

            }
        }
    }
    }

