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
    public class OrdersUserRepository : IRepository<OrdersUser>
    {
        private ApplicationContext db;
        public OrdersUserRepository(ApplicationContext context)
        {
            db = context;
        }
        public void Create(OrdersUser item)
        {
            db.OrdersUser.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            OrdersUser ordersUser = db.OrdersUser.Find(id);
            if (ordersUser != null)
                db.OrdersUser.Remove(ordersUser);
            db.SaveChanges();
        }

        public OrdersUser Get(int id)
        {
            return db.OrdersUser.Find(id);
        }

        public IEnumerable<OrdersUser> GetAll()
        {
            return db.OrdersUser;
        }

        public void Update(OrdersUser item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
