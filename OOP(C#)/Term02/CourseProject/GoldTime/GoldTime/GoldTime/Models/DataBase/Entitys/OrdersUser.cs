using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTime.Models.DataBase.Entitys
{
    public class OrdersUser
    {
        public int Id { get; set; }
        public List<Order> Orders { get; set; }

        public OrdersUser()
        {
            Orders = new List<Order>();
        }
    }
}
