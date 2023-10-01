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
    /// Логика взаимодействия для BasketView.xaml
    /// </summary>
    public partial class BasketView : Page
    {
        public BasketView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int idWatch = (int)button.CommandParameter;
            BasketWatches basketWatches = ControllerApplication.user.WatchesBasket;
            basketWatches.Watches.Remove(ControllerApplication.DataBase.WatchesRepository.Get(idWatch));

            ControllerApplication.DataBase.BasketWatchesRepository.Update(basketWatches);

            ControllerApplication.UpdateInformationDataBase();
            
        }
    }
}
