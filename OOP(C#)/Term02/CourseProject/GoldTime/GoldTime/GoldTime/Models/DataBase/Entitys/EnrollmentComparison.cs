using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTime.Models.DataBase.Entitys
{
    public class EnrollmentComparison
    {
        public int WatchId { get; set; }
        public Watch Watch { get; set; }

        public int ComparisonWatchesId { get; set; }
        public ComparisonWatches ComparisonWatches { get; set; }
    }
}
