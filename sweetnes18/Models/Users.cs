using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

 

namespace Sweetnes18.Models
{
   
    public class Users
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string UType { get; set; }
        public string Pass { get; set; }
        public string NickName { get; set; } 
        public string mobileno { get; set; }
        public string Status { get; set; }
    }
}