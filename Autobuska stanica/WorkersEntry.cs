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

            SqlCeCommand command = new SqlCeCommand("INSERT INTO Workers ([First_name],[Last_name]) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "'); ", Connection);
            
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

          else  if (textBox2.Text == "")
            { MessageBox.Show("Niste unijeli prezime!"); }

           else { MessageBox.Show("Unos je uspio!");
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
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
