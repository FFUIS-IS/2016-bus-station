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
    public partial class LinesEnetery : Form
    {
        public LinesEnetery()
        {
            InitializeComponent();
        }

        private void LinesEnetery_Load(object sender, EventArgs e)
        {
            SqlCeConnection Connection = DbConnection.Instance.Connection;

            SqlCeCommand command = new SqlCeCommand("INSERT INTO Lines ([from_the_city],[to_the_city]) VALUES ('" + comboBox1.Text + "', '" + comboBox2.Text + "'); ", Connection);

            SqlCeDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                comboBox1.Items.Add(dataReader.GetString(0));

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void WorkersEntry_Load(object sender, EventArgs e)
        {

        }
    }
}


       
