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

            Boolean lineAllright = false;
            bool workerAllright = false;

            int broj;

            for (int i = 0; i < linesComboBox.Items.Count; i++)
                if (linesComboBox.Text.Equals(linesComboBox.Items[i].ToString()))
                {
                    lineAllright = true;
                    break;
                }
                else
                    lineAllright = false;
            for (int i = 0; i < workersComboBox.Items.Count; i++)
                if (workersComboBox.Text.Equals(workersComboBox.Items[i].ToString()))
                {
                    workerAllright= true;
                    break;
                }
                else
                    workerAllright = false;

            if(!workerAllright)
            {

            }
            else if (!lineAllright)
            {
                MessageBox.Show("Niste unijeli ispravnu rutu!");
                linesComboBox.Focus();
            }
            else if (carrierComboBox.Text == "")
            {
                MessageBox.Show("Niste unijeli prevoznika!");
            }

            else if (carrierComboBox.Text == "")
            {
                MessageBox.Show("Niste unijeli grad dolaska!");
            }
            else if (seatText.Text == " " && !int.TryParse(seatText.Text, out broj))
            {
                MessageBox.Show("Niste ispravno unijeli broj sjedista!");
            }
            else if (platformText.Text == " " && !int.TryParse(platformText.Text, out broj))
            {
                MessageBox.Show("Niste unijeli broj perona!");
            }

            else if (ticketText.Text == " " && !int.TryParse(ticketText.Text, out broj))
            {
                MessageBox.Show("Niste unijeli broj karata!");
            }
            else if(workersComboBox.Text == "")
            {
                MessageBox.Show("Niste unijeli radnika !");
            }
            else
            {
                        SqlCeCommand command = Connection.CreateCommand();
                        SqlCeCommand command1 = Connection.CreateCommand();
                        SqlCeCommand command2 = Connection.CreateCommand();

                        int indexOfLine = Int32.Parse(linesComboBox.SelectedItem.ToString().Substring(0, linesComboBox.SelectedItem.ToString().IndexOf(' ')));

                string[] name = workersComboBox.SelectedItem.ToString().Split(' ');
                        command.CommandText = "SELECT ID FROM carrier WHERE name = '" + carrierComboBox.Text + "';";
                        command1.CommandText = "SELECT ID FROM workers WHERE first_name  ='" + name[0] + "' AND last_name = '" + name[1] + "';";


                        SqlCeDataReader rdr = command.ExecuteReader();
                        rdr.Read();
                        int carrier = rdr.GetInt32(0);


                        SqlCeDataReader rdr1 = command1.ExecuteReader();
                      rdr1.Read();
                       int workerID = rdr1.GetInt32(0);
                
                DateTime date = DateTime.Now;
                command.CommandText = "INSERT INTO tickets (time, number_of_seats, platform, workers_id, price_listID, number_of_tickets, lineID) VALUES"
            + "('" + toDate(date) + "', " + int.Parse(seatText.Text) + ", " + int.Parse(platformText.Text) + ", " + workerID 
            + ", " + int.Parse(textBox5.Text) + ", " + int.Parse(ticketText.Text) + ", " 
            + indexOfLine + ");";

                        try
                        {
                              command.ExecuteNonQuery();
                            MessageBox.Show("Unos je uspio!");
                            carrierComboBox.Focus();
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show("Unos nije uspio! \r Greska: " + ee.Message);
                            return;
                        }
                    }

        }
        string toDate(DateTime time)
        {
            string text = "" + time.Year + "-";
            text += (time.Month < 10) ? ("0" + time.Month) : ("" + time.Month);
            text += "-" + ((time.Day < 10) ? ("0" + time.Day) : ("" + time.Day));
            text += " " + ((time.Hour < 10) ? ("0" + time.Hour) : ("" + time.Hour));
            text += ":" + ((time.Minute< 10) ? ("0" + time.Minute) : ("" + time.Minute));
            text += ":" + ((time.Second < 10) ? ("0" + time.Second) : ("" + time.Second));

            return text;
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
                SqlCeDataReader reserveReader;
                string info;
                
                    int from = rdr2.GetInt32(1);
                    int toCity = rdr2.GetInt32(2);

                    command.CommandText = "SELECT name FROM from_the_city WHERE id = " + from + ";";

                    reserveReader = command.ExecuteReader();
                    reserveReader.Read();

                    info = reserveReader.GetString(0);
                    command.CommandText = "SELECT name FROM to_the_city WHERE id = " + toCity + ";";

                    reserveReader = command.ExecuteReader();
                    reserveReader.Read();

                    info += " - " + reserveReader.GetString(0);
                linesComboBox.Items.Add(rdr2.GetInt32(0) +" " + info);
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

        private void linesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            function();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            function();
        }
        
        private void function()
        {

            SqlCeConnection Connection = DbConnection.Instance.Connection;
            Boolean lineAllright = false;

            for (int i = 0; i < linesComboBox.Items.Count; i++)
                if (linesComboBox.Text.Equals(linesComboBox.Items[i].ToString()))
                {
                    lineAllright = true;
                    break;
                }
                else
                    lineAllright = false;
            if (lineAllright)
            {
                int index = Int32.Parse(linesComboBox.SelectedItem.ToString().Substring(0, linesComboBox.SelectedItem.ToString().IndexOf(' ')));
                SqlCeCommand command = new SqlCeCommand("SELECT price FROM lines WHERE id = " + index + ";", Connection);
                SqlCeDataReader reader = command.ExecuteReader();
                int broj;
                if (reader.Read())
                    if (Int32.TryParse(ticketText.Text, out broj))
                    {
                        textBox5.Text = "" + (Int32.Parse(ticketText.Text) * reader.GetInt32(0));
                    }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void nazadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
