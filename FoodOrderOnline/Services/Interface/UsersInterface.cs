using FoodOrderOnline.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderOnline.Services.Interface
{
    public interface UsersInterface
    {
        User Login(string accountName, string accountPassword);
        int Register(int phonenumber, string accountName, string password);
    }
}
