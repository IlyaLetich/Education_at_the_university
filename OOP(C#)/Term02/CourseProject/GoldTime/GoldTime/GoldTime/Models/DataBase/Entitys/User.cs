using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTime.Models.DataBase.Entitys
{
    public class User
    {
        public int Id { get; set; } = default;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Status Status { get; set; } = Status.User;
        public BasketWatches WatchesBasket { get; set; }
        public ComparisonWatches ComparisonWatches { get; set; }
        public OrdersUser OrdersUser { get; set; }

        public User() 
        {
            WatchesBasket = new BasketWatches();
            ComparisonWatches = new ComparisonWatches();
            OrdersUser = new OrdersUser();
        }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            Status = Status.User;
            WatchesBasket = new BasketWatches();
            ComparisonWatches = new ComparisonWatches();
            OrdersUser = new OrdersUser();
        }
    }
}
