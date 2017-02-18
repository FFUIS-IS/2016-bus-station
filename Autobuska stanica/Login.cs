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
    public partial class Login : Form
    {
        public static string usernamee;
        public static string passwordd;

        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {


            SqlCeConnection Connection = DbConnection.Instance.Connection;

            SqlCeCommand command = new SqlCeCommand("SELECT Username, Password FROM Login ", Connection);

            SqlCeDataReader dataReader = command.ExecuteReader();
            {

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Niste unijeli Korisničko ime !", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Niste unijeli šifru !", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                    return;
                }



            }

            while (dataReader.Read())
            {
                if (textBox1.Text == dataReader[0].ToString() && textBox2.Text == dataReader[1].ToString().Trim())
                {
                    usernamee = dataReader[0].ToString();
                    passwordd = dataReader[1].ToString();
                }
            }

            if (textBox1.Text == usernamee && textBox2.Text == passwordd.Trim())
            {

                Bus_station p = new Bus_station();
                p.Show();
                this.Hide();

            }

            else
            {
                MessageBox.Show("Pogrešeno uneseno korisničko ime ili šifra \n \n Pokušajte ponovo", "Prijava greške", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Registration r = new Registration();
            r.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}

