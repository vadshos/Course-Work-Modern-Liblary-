using Course_work_Library.ConnectionToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_work_Library.SingIn
{
    static class SingIn
    {
        public enum UsersRole { user,admin }
        public static bool CheckUser(string userName,string password)
        {
            using(ConnectDB connectDB = new ConnectDB())
            {
                connectDB.Conection();
                try
                {
                    string query = "SELECT Count(*) FROM dbo.tblUser WHERE Username = @UserName AND Password = @Password";
                    return connectDB.GetDataUserfromDB(query, userName, password);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

        }
    }
}
