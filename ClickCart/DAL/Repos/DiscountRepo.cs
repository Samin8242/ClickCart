using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DiscountRepo : Repo, IRepo<Discount, int, Discount>
    {
        public Discount Create(Discount obj)
        {
            db.Discounts.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Discounts.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Discount> Read()
        {
            return db.Discounts.ToList();
        }

        public Discount Read(int id)
        {
            return db.Discounts.Find(id);
        }

        public Discount Update(Discount obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
