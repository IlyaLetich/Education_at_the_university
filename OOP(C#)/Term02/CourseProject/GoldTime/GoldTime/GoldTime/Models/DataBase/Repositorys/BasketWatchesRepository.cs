using GoldTime.Models.DataBase.Entitys;
using GoldTime.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GoldTime.Models.DataBase.Repositorys
{
    public class BasketWatchesRepository : IRepository<BasketWatches>
    {
        private ApplicationContext db;
        public BasketWatchesRepository(ApplicationContext context)
        {
            db = context;
        }

        public void Create(BasketWatches item)
        {
            db.BasketWatches.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            BasketWatches basketWatches = db.BasketWatches.Find(id);
            if (basketWatches != null)
                db.BasketWatches.Remove(basketWatches);
            db.SaveChanges();
        }

        public BasketWatches Get(int id)
        {
            return db.BasketWatches.Find(id);
        }

        public IEnumerable<BasketWatches> GetAll()
        {
            return db.BasketWatches;
        }

        public void Update(BasketWatches item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
