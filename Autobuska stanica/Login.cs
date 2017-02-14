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
    public partial class Login : Form
    {
        public static string username;
        public static string password;

        SqlCeConnection Connection = DbConnection.Instance.Connection;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "")
            {
                MessageBox.Show("Niste unijeli Korisnicko ime !", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernameTextBox.Focus();
                return;
            }
            else if (passwordTextBox.Text == "")
            {
                MessageBox.Show("Niste unijeli šifru !", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextBox.Focus();
                return;
            }

            SqlCeCommand command = Connection.CreateCommand();
           //command.CommandText = ("SELECT * FROM Login WHERE username = '" + usernameTextBox.Text + "' AND password = '" + passwordTextBox.Text + "' ; )" , Connection ) ;

            

            SqlCeDataReader rdr = command.ExecuteReader();



            while (rdr.Read())
            {
                if (usernameTextBox.Text == rdr[0].ToString() && passwordTextBox.Text == rdr[1].ToString().Trim())
                {
                    username = rdr[0].ToString();
                    password = rdr[1].ToString();
                }
            }

            if (usernameTextBox.Text == username && passwordTextBox.Text == password.Trim())
            {

                Bus_station p = new Bus_station();
                p.Show();
                this.Hide();

            }

            else
            {
                MessageBox.Show("Pogrešeno uneseno korisnicko ime ili šifra \n \n Pokušajte ponovo", "Prijava greške", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernameTextBox.Clear();
                passwordTextBox.Clear();
                usernameTextBox.Focus();
            }

            Connection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Registration r = new Registration();
            r.Show();
        }
    }
        }
    
    

