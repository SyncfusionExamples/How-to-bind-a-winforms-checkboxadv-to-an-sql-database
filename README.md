# How-to-bind-a-winforms-checkboxadv-to-an-sql-database
## Boolean Value
The CheckBoxAdv’s BoolValue property can be used to data bind bool values as illustrated below.

# C#

    public partial class Form1 : Form
        {
             public static string dataBasePath = System.IO.Path.GetFullPath("..\\..\\Database1.mdf");
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

![Boolean Value](https://user-images.githubusercontent.com/93652178/204504169-4a2e7eaf-0fe9-48cf-8644-eefd7464359a.png)

## Integer Value
The CheckBoxAdv’s BoolValue property can be used to data bind Integer values as illustrated below.

# C#

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
                    this.checkBoxAdv1.DataBindings.Add("IntValue", dataTable, "integerValue");

                }
            }
        }

![Integer Value](https://user-images.githubusercontent.com/93652178/204504939-02dc7da6-e560-4c60-b6ca-7b9accdbec70.png)

