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

            SqlCeConnection Connection = DbConnection.Instance.Connection;

            SqlCeCommand command = new SqlCeCommand("INSERT INTO Workers ([First_name],[Last_name],[JMBG],[contact],[address],[Username],[Password]) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', ' "+jmbgTextBox.Text+"' , '"+contactTextBox.Text +"', '"+ addressTextBox.Text+"','" +  usernameTextBox.Text+"', '"+ passwordTextBox.Text+"' ); ", Connection);

            try
            {
                command.ExecuteNonQuery();
            }

            catch (Exception ee)
            {


                MessageBox.Show("Unos nije uspio! \r Greska: " + ee.Message);
                return;

            }


            if (textBox1.Text == "")
            { MessageBox.Show("Niste unijeli ime!"); }

            else if (textBox2.Text == "")
            { MessageBox.Show("Niste unijeli prezime!"); }

            else if (jmbgTextBox.Text == "")
            {
                MessageBox.Show("Niste unijeli maticni broj!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (contactTextBox.Text == "")
            {
                MessageBox.Show("Niste unijeli broj telefona !", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (addressTextBox.Text == "")
            {
                MessageBox.Show("Niste unijeli adresu stanovanja !", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (usernameTextBox.Text == "")
            {
                MessageBox.Show("Niste unijeli korisnicko ime !", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (passwordTextBox.Text == "")
            {
                MessageBox.Show("Niste unijeli sifru !", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Unos je uspio!");
                textBox1.Clear();
                textBox2.Clear();
                jmbgTextBox.Clear();
                contactTextBox.Clear();
                addressTextBox.Clear();
                usernameTextBox.Clear();
                passwordTextBox.Clear();

                textBox1.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void WorkersEntry_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}


