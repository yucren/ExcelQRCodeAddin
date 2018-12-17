using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ExcelQRCodeAddin.Tools
{
    public partial class DbConnForm : Form
    {
        public DbConnForm()
        {
            InitializeComponent();
            this.ComfirmBtn.Enabled = false;
        }
        string connString;
        SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
        private void TestBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();
                sqlBuilder.DataSource = ServiceAddTb.Text;
                sqlBuilder.InitialCatalog = "master";
                sqlBuilder.UserID = UidTB.Text;
                sqlBuilder.Password = PwdTb.Text;                ;
                using (SqlConnection sqlconn = new SqlConnection(sqlBuilder.ConnectionString))
                {
                    sqlconn.Open();
                    SqlCommand sqlCommand = new SqlCommand("sp_databases", sqlconn);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    new SqlDataAdapter(sqlCommand).Fill(dataTable);
                    DbCbox.DataSource = dataTable;
                    DbCbox.DisplayMember = "DATABASE_NAME";
                    DbCbox.ValueMember = "DATABASE_NAME";
                    MessageBox.Show("测试成功");
                    ComfirmBtn.Enabled = true;                
                   
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
          

        }

        private void DbConnForm_Load(object sender, EventArgs e)
        {
            
        }

        private void ComfirmBtn_Click(object sender, EventArgs e)
        {
            sqlBuilder.InitialCatalog = DbCbox.SelectedValue.ToString();
            connString = sqlBuilder.ConnectionString;
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //var dd = ConfigurationManager.ConnectionStrings["mes"];
            if (ConfigurationManager.ConnectionStrings["mes"] == null)
            {
                ConnectionStringSettings connectionStringSettings = new ConnectionStringSettings("mes", connString);

                configuration.ConnectionStrings.ConnectionStrings.Add(connectionStringSettings);

            }
            else
            {
                configuration.ConnectionStrings.ConnectionStrings["mes"].ConnectionString = connString;
            }
           
            
            configuration.Save(ConfigurationSaveMode.Full);
            this.Close();



        }

        private void DbCbox_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}
