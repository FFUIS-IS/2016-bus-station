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
    public partial class LinesINFO : Form
    {
        public LinesINFO()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
         //   try
           // {
                
                SqlCeConnection Connection = DbConnection.Instance.Connection;

                SqlCeCommand command = new SqlCeCommand("SELECT from_the_city_id, to_the_city_id, time_of_departure, time_of_arrival FROM lines;", Connection);


                SqlCeDataReader dataReader = command.ExecuteReader();
            SqlCeDataReader reserveReader;
            string info;

            while (dataReader.Read())
            {
                int from = dataReader.GetInt32(0);
                int toCity = dataReader.GetInt32(1);

                command.CommandText = "SELECT name FROM from_the_city WHERE id = " + from + ";";

                reserveReader = command.ExecuteReader();
                reserveReader.Read();

                info = reserveReader.GetString(0);
                command.CommandText = "SELECT name FROM to_the_city WHERE id = " + toCity + ";";

                reserveReader = command.ExecuteReader();
                reserveReader.Read();

                info += " - " + reserveReader.GetString(0);
                info += "\tTime of travel: " + dataReader.GetString(2) + "-" + dataReader.GetString(3);
                listBox1.Items.Add(info);

            }
            


            dataReader.Close();
        //}

          //  catch (Exception ee)
            //{
              //  MessageBox.Show(" Greska: " + ee.Message);
               // return;


//            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LinesINFO_Load(object sender, EventArgs e)
        {

        }

       
    }
}
