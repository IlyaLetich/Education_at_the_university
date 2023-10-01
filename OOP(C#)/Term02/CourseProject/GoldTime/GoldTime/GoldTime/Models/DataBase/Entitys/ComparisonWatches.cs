using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTime.Models.DataBase.Entitys
{
    public class ComparisonWatches
    {
        public int Id { get; set; }
        public List<Watch> Watches { get; set; }

        public ComparisonWatches()
        {
            Watches = new List<Watch>();
        }
    }
}
