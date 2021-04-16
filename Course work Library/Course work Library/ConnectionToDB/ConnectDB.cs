using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Course_work_Library;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Course_work_Library.ConnectionToDB
{
    class ConnectDB : IDisposable
    {
        SqlConnection sqlCon;
        public string server { get; protected set; }
        public string database { get; protected set; }
        public string uid { get; protected set; }
        public string password { get; protected set; }

        
        //Constructor
        public ConnectDB()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            string connStr = "Data Source=localhost;Initial Catalog=AccountsDB;Integrated Security=true;User ID=root;Password=09092003";
            sqlCon = new SqlConnection(connStr);
        }

        public void Conection()
        {
            
            try
            {
                if(sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool GetDataUserfromDB(string query,string login,string password)
        {
          
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@UserName", login);
            sqlCmd.Parameters.AddWithValue("@Password", password);
            
            int count = 1;
            try
            {
            count =  Convert.ToInt32(sqlCmd.ExecuteScalar());      
            }
            catch (Exception)
            {
                throw;
            }
            if (count == 1)
            {
                return true;    
               
            }
            throw new Exception("User did't find");
        }

        public void Dispose()
        {

            sqlCon?.Close();
        }
        ~ConnectDB()
        {
            Dispose();
        }
    }
}
