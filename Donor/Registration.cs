using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Donor
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            //string сonnectionString = @"ProektirovanieISU.bak";
            //SqlConnection connection = new SqlConnection(сonnectionString);

            //connection.Open();

            //string sqlquery = "SELECT * FROM Gender";
            //SqlCommand command = new SqlCommand(sqlquery, connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //SqlCommandBuilder combuild = new SqlCommandBuilder(adapter);
            //DataTable datatable = new DataTable();
            //adapter.Fill(datatable);
            //comboBox1.DataSource = datatable;
            //comboBox1.DisplayMember = "Gender";
            //comboBox1.ValueMember = "Gender";
                
        }
    }
}
