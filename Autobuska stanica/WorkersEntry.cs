using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using System.Data.SqlClient;

using Autobuska_stanica;

namespace Autobuska_stanica
{
    public partial class WorkersEntry : Form
    {
        public WorkersEntry()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (textBox1.Text == "")
            { MessageBox.Show("Niste unijeli ime!"); }

            else if (textBox2.Text == "")
            { MessageBox.Show("Niste unijeli prezime!"); }
            else if (jmbgTextBox.Text == "")
            { MessageBox.Show("Niste unijeli jedinstven maticni broj!"); }
            else if (contactTextBox.Text == "")
            { MessageBox.Show("Niste unijeli broj telefona!"); }
            else if (addressTextBox.Text == "")
            { MessageBox.Show("Niste unijeli adresu stanovanja!"); }


            else
            {
            

            SqlCeConnection Connection = DbConnection.Instance.Connection;

            SqlCeCommand command = new SqlCeCommand("", Connection);
            command.CommandText = "SELECT count(*) FROM workers;";
            SqlCeDataReader reader = command.ExecuteReader();

            reader.Read();
            if (reader.GetInt32(0) < 5)
            {
                command.CommandText = "INSERT INTO Workers ([first_name],[last_name],[address],[jmbg],[contact]) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + addressTextBox.Text + "', '" + jmbgTextBox.Text + "', '" + contactTextBox.Text + "'); ";
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Unos je uspio!");
                        textBox1.Clear();
                        textBox2.Clear();
                        jmbgTextBox.Clear();
                        contactTextBox.Clear();
                        addressTextBox.Clear();
                        textBox1.Focus();
                    }

                    catch (Exception ee)
                    {
                        MessageBox.Show("Unos nije uspio! \n" + ee.Message);
                        return;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void WorkersEntry_Load(object sender, EventArgs e)
        {

        }

        
    }
}


