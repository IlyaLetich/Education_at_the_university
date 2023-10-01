using GoldTime.Models;
using GoldTime.Models.DataBase.Entitys;
using GoldTime.Utilities;
using GoldTime.Utilities.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoldTime.ViewModels.Shop
{
    public class OrdersViewModel : ViewModelBase
    {
        #region fields

        private List<Order> orders;

        #endregion

        #region constructors

        #endregion

        #region propertys

        public List<Order> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                orders = value;
                OnPropertyChanged("Orders");
            }
        }

        #endregion

        
    }
}
