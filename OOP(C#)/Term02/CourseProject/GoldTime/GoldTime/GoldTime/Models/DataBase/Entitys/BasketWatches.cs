using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTime.Models.DataBase.Entitys
{
    public class BasketWatches
    {

        public int Id { get; set; }
        public List<Watch> Watches { get; set; }

        public BasketWatches() 
        {
            Watches = new List<Watch>();
        }
    }
}
