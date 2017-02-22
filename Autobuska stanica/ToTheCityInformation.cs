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
    public partial class ToTheCityInformation : Form
    {

        private static SqlCeConnection Connection = DbConnection.Instance.Connection;

        public ToTheCityInformation()
        {
            InitializeComponent();
        }

        

    


        private void button1_Click(object sender, EventArgs e)
        {
            refreshingCityList();
        }
        private void refreshingCityList()
        {
            listBox1.Items.Clear();
            SqlCeCommand command = new SqlCeCommand("SELECT * FROM to_the_city", Connection);

            try
            {
                SqlCeDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    listBox1.Items.Add(dr.GetString(1));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ToTheCityInformation_Load(object sender, EventArgs e)
        {
            refreshingCityList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCeConnection Connection = DbConnection.Instance.Connection;

            SqlCeCommand command = Connection.CreateCommand();

            DialogResult dr = MessageBox.Show("Da li želite da izbrišete ?", "Brisanje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                string name = listBox1.SelectedItem.ToString();
                

                command.CommandText = "DELETE FROM to_the_city WHERE name = '" + listBox1.SelectedItem + "'; ";
                try
                {
                    command.ExecuteReader();
                    refreshingCityList();
                }
                catch(SqlCeException ee)
                {
                    MessageBox.Show(ee.ToString());
                }
            }
            else if (dr == DialogResult.No)
            {

                this.Close();
                ToTheCityInformation CI = new ToTheCityInformation();
                CI.Show();

            }
        }
    }
}


       
