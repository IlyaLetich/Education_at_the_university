using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTime.Models.DataBase.Entitys
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public int QuentityWatchOrder { get; set; }
        public decimal PriceOrder { get; set; }

        public List<OrdersUser> OrdersUser { get; set; }

        public Order() 
        { 
            OrdersUser = new List<OrdersUser>();
        }

        public Order(int quentityWatchOrder, decimal priceOrder)
        {
            QuentityWatchOrder = quentityWatchOrder;
            PriceOrder = priceOrder;
            OrdersUser = new List<OrdersUser>();
            DateOrder = DateTime.Now;
        }
    }
}