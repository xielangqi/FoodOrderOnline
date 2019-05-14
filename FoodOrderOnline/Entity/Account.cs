using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderOnline.Entity
{
    public class User
    {
        public int id { get; set; }
        public string account_name { get; set; }
        public bool isadmin { get; set; }
        public string account_password { get; set; }
        public DateTime createtime { get; set; }
        public int phonenumber { get; set; }
    }

    public class Menu
    {
        public int id { get; set; }
        public string menu_name { get; set; }
        public string menu_description { get; set; }
        public int price { get; set; }
    }

    public class Order
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int menu_id { get; set; }
    }
}
