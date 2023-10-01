using GoldTime.Models.DataBase.Entitys;
using GoldTime.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldTime.Models.DataBase.Repositorys
{
    public class WatchesRepository : IRepository<Watch>
    {
        private ApplicationContext db;
        public WatchesRepository(ApplicationContext context)
        {
            db = context;
        }
        public void Create(Watch item)
        {
            db.Watches.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Watch watch = db.Watches.Find(id);
            if (watch != null)
                db.Watches.Remove(watch);
            db.SaveChanges();
        }

        public Watch Get(int id)
        {
            return db.Watches.Find(id);
        }

        public IEnumerable<Watch> GetAll()
        {
            return db.Watches;
        }

        public void Update(Watch item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
