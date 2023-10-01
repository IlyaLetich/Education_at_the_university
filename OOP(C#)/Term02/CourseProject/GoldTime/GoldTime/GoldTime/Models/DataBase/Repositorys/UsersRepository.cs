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
    public class UsersRepository : IRepository<User>
    {
        private ApplicationContext db;
        public UsersRepository(ApplicationContext context)
        {
            db = context;
        }
        public void Create(User item)
        {
            db.Users.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            User student = db.Users.Find(id);
            if (student != null)
                db.Users.Remove(student);
            db.SaveChanges();
        }

        public User Get(int id)
        {
            List<User> users = db.Users.Include(x => x.WatchesBasket.Watches).Include(x => x.OrdersUser.Orders).Include(x => x.ComparisonWatches.Watches).ToList();
            foreach (User user in users)
            {
                if(user.Id == id)
                    return user;
            }
            return new User();

        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
