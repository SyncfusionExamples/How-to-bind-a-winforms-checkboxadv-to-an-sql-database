using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckBoxAdv_DataBinding_Boolean
{
    public partial class Form1 : Form
    {
         public static string dataBasePath = Path.GetFullPath("..\\..\\Database1.mdf");
        public  string connectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dataBasePath + ";Integrated Security=True";
        public Form1()
        {
            InitializeComponent();

            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM [Table]", sqlConnection);

                DataTable dataTable = new DataTable("Table");
                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                this.checkBoxAdv1.DataBindings.Add("BoolValue", dataTable, "CheckValue");
                
            }
        }
    }
}
