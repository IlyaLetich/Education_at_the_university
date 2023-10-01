using GoldTime.Models.DataBase.Entitys;
using GoldTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoldTime.Views.Shop
{
    /// <summary>
    /// Логика взаимодействия для NewsView.xaml
    /// </summary>
    public partial class NewsView : Page
    {
        public NewsView()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Ваша логика обработки клика на кнопке
            // Можно получить данные элемента из DataContext кнопки
            // или использовать другие способы получения необходимых данных
            //var button = (Button)sender;
            //var watch = (WatchModel)button.DataContext;
            // Ваш код обработки клика на кнопке
            Button button = (Button)sender;
            int idWatch = (int)button.CommandParameter;

            News news = ControllerApplication.DataBase.NewsRepository.Get(idWatch);
            ControllerApplication.newsDescriptionViewModel.News = news;

            ControllerApplication.SetMainPage("DescriptionNews");
        }
    }
}
