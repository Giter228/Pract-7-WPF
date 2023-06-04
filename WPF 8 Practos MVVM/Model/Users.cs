using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_8_Practos_MVVM.ViewModel.Helpers;

namespace WPF_8_Practos_MVVM
{
    public class Users
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }

        public Users(string login = "", string password = "", string roleName = "")
        {
            Login = login;
            Password = password;
            RoleName = roleName;
        }
    }
}
