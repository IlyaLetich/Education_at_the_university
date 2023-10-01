using GoldTime.Models.DataBase.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTime.Models.DataBase
{
    public class UnitOfWork : IDisposable
    {
        ApplicationContext db = new ApplicationContext();

        #region fields

        private BasketWatchesRepository basketWatchesRepository;
        private ComparisonWatchesRepository comparisonWatchesRepository;
        private NewsRepository newsRepository;
        private OrdersUserRepository ordersUserRepository;
        private UsersRepository usersRepository;
        private WatchesRepository watchesRepository;
        private OrdersRepository ordersRepository;

        #endregion

        #region propertys

        public OrdersRepository OrdersRepository
        {
            get
            {
                if (ordersRepository == null)
                    ordersRepository = new OrdersRepository(db);
                return ordersRepository;
            }
        }
        public BasketWatchesRepository BasketWatchesRepository
        {
            get
            {
                if (basketWatchesRepository == null)
                    basketWatchesRepository = new BasketWatchesRepository(db);
                return basketWatchesRepository;
            }
        }
        public ComparisonWatchesRepository ComparisonWatchesRepository
        {
            get
            {
                if (comparisonWatchesRepository == null)
                    comparisonWatchesRepository = new ComparisonWatchesRepository(db);
                return comparisonWatchesRepository;
            }
        }

        public NewsRepository NewsRepository
        {
            get
            {
                if (newsRepository == null)
                    newsRepository = new NewsRepository(db);
                return newsRepository;
            }
        }

        public OrdersUserRepository OrdersUserRepository
        {
            get
            {
                if (ordersUserRepository == null)
                    ordersUserRepository = new OrdersUserRepository(db);
                return ordersUserRepository;
            }
        }

        public UsersRepository UsersRepository
        {
            get
            {
                if (usersRepository == null)
                    usersRepository = new UsersRepository(db);
                return usersRepository;
            }
        }

        public WatchesRepository WatchesRepository
        {
            get
            {
                if (watchesRepository == null)
                    watchesRepository = new WatchesRepository(db);
                return watchesRepository;
            }
        }

        #endregion

        #region methods
        public void Save()
        {
            db.SaveChanges(); 
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
