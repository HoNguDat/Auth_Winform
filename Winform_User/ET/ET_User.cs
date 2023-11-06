using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_User
    {
        private string id;
        private string fullName;
        private string userName;
        private string password;
        public ET_User(string id, string fullName, string userName, string password)
        {
            this.id = id;
            this.fullName = fullName;
            this.userName = userName;
            this.password = password;
        }
        public ET_User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
        public string Id { get => id; set => id = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Pass { get => password; set => password = value; }
    }
}
