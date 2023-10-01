using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTime.Models.DataBase.Entitys
{
    public class EnrollmentOrders
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int OrdersUserId { get; set; }
        public OrdersUser OrdersUser { get; set; }
    }
}
