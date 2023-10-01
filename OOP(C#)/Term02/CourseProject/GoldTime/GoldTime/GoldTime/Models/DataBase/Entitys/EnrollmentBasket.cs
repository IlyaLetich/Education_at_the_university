using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTime.Models.DataBase.Entitys
{
    public class EnrollmentBasket
    {
        public int WatchId { get; set; }
        public Watch Watch { get; set; }

        public int 
            Id { get; set; }
        public BasketWatches BasketWatches { get; set; }
    }
}
