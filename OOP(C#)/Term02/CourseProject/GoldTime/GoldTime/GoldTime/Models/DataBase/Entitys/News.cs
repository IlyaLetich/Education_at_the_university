using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTime.Models.DataBase.Entitys
{
    public class News
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string NameNews { get; set; }
        public string InformationsNews { get; set; }
        public DateTime DateTime { get; set; }

        public News(string nameNews, string informationsNews, string imagePath)
        {
            NameNews = nameNews;
            InformationsNews = informationsNews;
            ImagePath = imagePath;
            DateTime = DateTime.Now;
        }
    }
}
