using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations.Builders;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Yemeksepeti.Services
{
    public class YemekSepetiServices
    {
        private YemekSepetiDBEntities context;

        public YemekSepetiServices()
        {
            context = new YemekSepetiDBEntities();
        }

        public Users checkUserInformation(string userMail, string userPassword)
        {
            Users theDatabaseUser = null;
            if (!string.IsNullOrEmpty(userMail) && !string.IsNullOrEmpty(userPassword))
            {
                
                var userCheck = context.Users.Count(i => i.UserMail == userMail && i.UserPassword == userPassword);
                if (userCheck>0)
                {
                    theDatabaseUser = context.Users.FirstOrDefault(i => i.UserMail == userMail && i.UserPassword == userPassword);
                }
            }
            return theDatabaseUser;
        }

        public int addNewUser(Users data)
        {
            if (context.Users.Any(i => i.UserMail == data.UserMail))
            {
                return -1;
            }
            else
            {
                context.Users.Add(data);
                context.SaveChanges();
                return 1;
            }
        }
        public List<Restaurants> ListRestaurants()
        {
            return context.Restaurants.ToList();
        }

        public List<Foods> restaurantsInfo(int restaurantID)
        {
            List<Foods> foodsList = new List<Foods>();
            Foods foods = new Foods();
            var result = context.FR_Proc(restaurantID).ToList();
            foreach (var item in result)
            {
                if (item != null)
                {
                    foods = context.Foods.Find(item.Value);
                    foodsList.Add(foods);
                }
            }
            return foodsList;
        }
    }
}
