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
using Autobuska_stanica.Models;
using Autobuska_stanica.Repos;

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
        public bool loginSucces = false;

        private void button1_Click(object sender, EventArgs e)
        {

            username = usernameTextBox.Text;
            password = passwordTextBox.Text;

            User user = new User(username, password);

            try
            {
                UserRepository.Login(user);
                loginSucces = true;
                DialogResult = DialogResult.OK;
                Close();

            }

            catch (Exception exception)
            {

                if (usernameTextBox.Text.Length == 0)
                {
                    MessageBox.Show(exception.Message);
                    usernameTextBox.Text = "";
                    usernameTextBox.Focus();
                }
                else if (passwordTextBox.Text.Length == 0)
                {
                    MessageBox.Show(exception.Message);
                    passwordTextBox.Text = "";
                    passwordTextBox.Focus();
                }
                else if (loginSucces != true)
                {
                    MessageBox.Show(exception.Message);
                    usernameTextBox.Text = "";
                    passwordTextBox.Text = "";
                    usernameTextBox.Focus();
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
        }
    
    

