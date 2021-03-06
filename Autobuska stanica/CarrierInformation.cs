﻿using System;
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
    public partial class CarrierInformation : Form
    {
        public CarrierInformation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();

                SqlCeConnection Connection = DbConnection.Instance.Connection;


                SqlCeCommand command = new SqlCeCommand("SELECT Name, Address FROM Carrier ", Connection);

                SqlCeDataReader dataReader = command.ExecuteReader();


                //dataReader.Read();

                while (dataReader.Read())
                {

                    listBox1.Items.Add(dataReader.GetString(0));
                    listBox2.Items.Add(dataReader.GetString(1));
                }

                dataReader.Close();
            }

            catch (Exception ee)
            {
                MessageBox.Show(" Greska: " + ee.Message);
                return;


            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlCeConnection Connection = DbConnection.Instance.Connection;

            SqlCeCommand command = Connection.CreateCommand();

            DialogResult dr = MessageBox.Show("Da li želite da izbrišete ?", "Brisanje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                string name = listBox1.SelectedItem.ToString();

                command.CommandText = "DELETE FROM carrier WHERE name = '" + name + "';";

                command.ExecuteReader();

                listBox1.Items.Remove(listBox1.SelectedItem);
            }

            else if (dr == DialogResult.No) { }
        }

        private void CarrierInformation_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = listBox2.SelectedIndex;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            listBox2.SelectedIndex = listBox1.SelectedIndex;
        }
    }
}







