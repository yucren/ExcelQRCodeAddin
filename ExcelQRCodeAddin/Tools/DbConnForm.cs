using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ExcelQRCodeAddin.Tools
{
    public partial class DbConnForm : Form
    {
        public DbConnForm()
        {
            InitializeComponent();
        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ServiceAddTb.Text,
                InitialCatalog = "master",
                UserID = UidTB.Text,
                Password = PwdTb.Text
            };
            using (SqlConnection sqlconn = new SqlConnection(sqlBuilder.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_databases", sqlconn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                new SqlDataAdapter(sqlCommand).Fill(dataTable);
                DbCbox.DataSource = dataTable;
                DbCbox.DisplayMember = "DATABASE_NAME";
            }
          

        }

        private void DbConnForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
