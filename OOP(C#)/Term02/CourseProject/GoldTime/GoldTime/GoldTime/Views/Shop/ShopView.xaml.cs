using GoldTime.Models;
using GoldTime.Models.DataBase.Entitys;
using GoldTime.ViewModels.MainViewModel;
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
    /// Логика взаимодействия для ShopView.xaml
    /// </summary>
    public partial class ShopView : Page
    {
        public ShopView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int idWatch = (int)button.CommandParameter;

            Watch watch = ControllerApplication.DataBase.WatchesRepository.Get(idWatch);
            ControllerApplication.watchDescriptionViewModel.Watch = watch;

            ControllerApplication.SetMainPage("DescriptionWatch");
        }
    }
}
