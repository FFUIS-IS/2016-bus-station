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


namespace Autobuska_stanica
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCeConnection Connection = DbConnection.Instance.Connection;

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
            else
            {
                SqlCeCommand command = new SqlCeCommand("INSERT INTO Login ([username],[password]) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "' ); ", Connection);

                try
                {

                    command.ExecuteNonQuery();
                    MessageBox.Show("Uspješna registracija", "Registracija", MessageBoxButtons.OK);

                }


                catch (Exception ee)
                {

                    MessageBox.Show("Registracija nije uspjela. \n" + ee.ToString());

                    return;

                }
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();

                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

