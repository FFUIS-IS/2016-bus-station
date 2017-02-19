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


                /*onaj prvi red */
                 SqlCeConnection Connection = DbConnection.Instance.Connection;
           
                /*onaj drugi red*/
            SqlCeCommand command = new SqlCeCommand("SELECT first_name, last_name, jmbg, contact, address  FROM workers ", Connection);

            SqlCeDataReader dataReader = command.ExecuteReader();


                //dataReader.Read();

                while (dataReader.Read())
             {
                    
                listBox1.Items.Add(dataReader.GetString(0) + "  " + dataReader.GetString(1)+" "+ dataReader.GetString(2)+ " "+ dataReader.GetString(3) +" "+ dataReader.GetString(4));
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
    }
    }

