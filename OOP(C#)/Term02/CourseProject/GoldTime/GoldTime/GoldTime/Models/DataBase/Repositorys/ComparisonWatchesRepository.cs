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
    public class ComparisonWatchesRepository : IRepository<ComparisonWatches>
    {
        private ApplicationContext db;
        public ComparisonWatchesRepository(ApplicationContext context)
        {
            db = context;
        }
        public void Create(ComparisonWatches item)
        {
            db.ComparisonWatches.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            ComparisonWatches comparisonWatches = db.ComparisonWatches.Find(id);
            if (comparisonWatches != null)
                db.ComparisonWatches.Remove(comparisonWatches);
            db.SaveChanges();
        }

        public ComparisonWatches Get(int id)
        {
            return db.ComparisonWatches.Find(id);
        }

        public IEnumerable<ComparisonWatches> GetAll()
        {
            return db.ComparisonWatches;
        }

        public void Update(ComparisonWatches item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
