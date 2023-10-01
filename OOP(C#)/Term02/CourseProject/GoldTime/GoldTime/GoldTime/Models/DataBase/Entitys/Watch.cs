using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GoldTime.Models.DataBase.Entitys
{
    public class Watch
    {
        public int Id { get; set; }
        public string NameModel { get; set; }
        public string NameCompany { get; set; }
        public string DescriptionModel { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public List<BasketWatches> BasketWatches { get; set; }
        public List<ComparisonWatches> ComparisonWatches { get; set; }

        public Watch()
        {
            BasketWatches = new List<BasketWatches>();
            ComparisonWatches = new List<ComparisonWatches>();
        }

        public Watch(string nameModel, string nameCompany, string descriptionModel, decimal price, string imagePath)
        {
            NameModel = nameModel;
            NameCompany = nameCompany;
            DescriptionModel = descriptionModel;
            Price = price;
            ImagePath = imagePath;
            BasketWatches = new List<BasketWatches>();
            ComparisonWatches = new List<ComparisonWatches>();
        }
    }
}

