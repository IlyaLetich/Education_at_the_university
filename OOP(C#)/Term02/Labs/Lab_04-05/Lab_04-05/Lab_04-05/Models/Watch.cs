using Lab_04_05.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_04_05.Models
{
    public class Watch : ViewModelBase
    {
        private string modelName;
        private string companyName;
        private string description;
        private string imagePath = "C:\\Users\\ilyac\\OneDrive\\Рабочий стол\\ООП(C#)\\Labs\\Lab_04-05\\Lab_04-05\\Lab_04-05\\Assets\\Fon.jpg";

        public string ModelName
        {
            get
            {
                return modelName;
            }
            set
            {
                modelName = value;
                OnPropertyChanged("ModelName");
            }
        }

        public string CompanyName
        {
            get
            {
                return companyName;
            }
            set
            {
                companyName = value;
                OnPropertyChanged("CompanyName");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public string ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        public Watch(string modelName, string companyName, string description, string path)
        {
            this.modelName = modelName;
            this.companyName = companyName;
            this.description = description;
            this.imagePath = path;
        }
    }
}
