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
    public class NewsRepository : IRepository<News>
    {
        private ApplicationContext db;
        public NewsRepository(ApplicationContext context)
        {
            db = context;
        }
        public void Create(News item)
        {
            db.News.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            News news = db.News.Find(id);
            if (news != null)
                db.News.Remove(news);
            db.SaveChanges();
        }

        public News Get(int id)
        {
            return db.News.Find(id);
        }

        public IEnumerable<News> GetAll()
        {
            return db.News;
        }

        public void Update(News item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
