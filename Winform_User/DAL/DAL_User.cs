using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;

namespace DAL
{
    public class DAL_User
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q57GG44\\SQLEXPRESS;Initial Catalog=Winform_Auth;Integrated Security=True");
        SqlDataAdapter dalUser;
        SqlCommand cmdUser;
        DataTable dtUser;

        public DataTable FetchData()
        {
            try
            {
                con.Open();
                cmdUser = new SqlCommand();
                cmdUser.CommandText = "sp_fetchData";
                cmdUser.CommandType = CommandType.StoredProcedure;
                cmdUser.Connection = con;
                dalUser = new SqlDataAdapter(cmdUser);
                dtUser = new DataTable();
                dalUser.Fill(dtUser);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return dtUser;
        }
        public int Register(ET_User et)
        {
            try
            {
                con.Open(); 
                cmdUser = new SqlCommand();
                cmdUser.CommandText = "sp_Register";
                cmdUser.CommandType = CommandType.StoredProcedure;
                cmdUser.Connection = con;
                cmdUser.Parameters.Add(new SqlParameter("@Id", et.Id));
                cmdUser.Parameters.Add(new SqlParameter("@FullName", et.FullName));
                cmdUser.Parameters.Add(new SqlParameter("@UserName", et.UserName));
                cmdUser.Parameters.Add(new SqlParameter("@Pass", et.Pass));

                if (cmdUser.ExecuteNonQuery() > 0)
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return 0;
        }
        public int Login(ET_User et)
        {
            int i = 0;
            try
            {
                con.Open();

                cmdUser = new SqlCommand("sp_Login", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmdUser.Parameters.Add("@UserName", SqlDbType.VarChar).Value = et.UserName;
                cmdUser.Parameters.Add(@"Pass", SqlDbType.VarChar).Value = et.Pass;
                i = (int)cmdUser.ExecuteScalar();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
            return i;
        }
    }
}
