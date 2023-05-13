using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class WishListRepo : Repo, IRepo<WishList, int, WishList>
    {
        public WishList Create(WishList obj)
        {
            db.WishLists.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.WishLists.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<WishList> Read()
        {
            return db.WishLists.ToList();
        }

        public WishList Read(int id)
        {
            return db.WishLists.Find(id);
        }

        public WishList Update(WishList obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
