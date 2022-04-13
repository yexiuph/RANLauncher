using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YXPHStudios
{
    public class API
    {
        public string ROOTURL = "http://localhost:3000/api/v1";
    }

    public class RegisterData
    {
        public string username { get; set;}
        public string password { get; set;}
        public string email { get; set;}
    
    }

    public class LoginResponse
    {
        public bool isSuccess { get; set; }
    }

    public class Credentials
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class YXVersion
    {
        public int Version { get; set; }
        public int PatchVersion { get; set; }
    }
}
