using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;
using DAL;
namespace BUS
{
    public class BUS_User
    {
        DAL_User dalUser = new DAL_User();
        public int Login(ET_User et)
        {
            return dalUser.Login(et);
        }
        public int Register(ET_User et)
        {
            return dalUser.Register(et);
        }
        public DataTable FetchData()
        {
            return dalUser.FetchData();
        }
    }
}
