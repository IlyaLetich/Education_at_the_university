using GoldTime.Models.DataBase.Entitys;
using GoldTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldTime.Utilities;
using GoldTime.Utilities.Commands;
using System.Windows.Input;
using System.Windows;

namespace GoldTime.ViewModels.Shop
{
    public class BasketViewModel : ViewModelBase
    {
        #region fields

        private List<Watch> watches;
        private decimal totalPrice;

        #endregion

        #region constructors

        #endregion

        #region propertys

        public List<Watch> Watches
        {
            get
            {
                return watches;
            }
            set
            {
                watches = value;
                TotalPrice = watches.Sum(x => x.Price);
                OnPropertyChanged("Watches");
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }

        #endregion

        #region buy

        private DelegateCommand? buy;

        public ICommand Buy
        {
            get
            {
                if (buy == null)
                {
                    buy = new DelegateCommand(BuyWatch);
                }
                return buy;
            }
        }

        private void BuyWatch()
        {
            OrdersUser ordersUser = ControllerApplication.user.OrdersUser;
            BasketWatches basketWatches = ControllerApplication.user.WatchesBasket;

            Order order = new Order(basketWatches.Watches.Count, TotalPrice);

            ControllerApplication.DataBase.OrdersRepository.Create(order);

            ordersUser.Orders.Add(ControllerApplication.DataBase.OrdersRepository.GetAll().ToList().Last());
            ControllerApplication.DataBase.OrdersUserRepository.Update(ordersUser);

            basketWatches.Watches.Clear();
            ControllerApplication.DataBase.BasketWatchesRepository.Update(basketWatches);
            ControllerApplication.UpdateInformationDataBase();
        }

        #endregion
    }
}
