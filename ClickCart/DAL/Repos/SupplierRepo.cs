using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SupplierRepo : Repo, IRepo<Supplier, string, Supplier>
    {
        public Supplier Create(Supplier obj)
        {
            db.Suppliers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.Suppliers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Supplier> Read()
        {
            return db.Suppliers.ToList();
        }

        public Supplier Read(string id)
        {
            return db.Suppliers.Find(id);
        }

        public Supplier Update(Supplier obj)
        {
            var ex = Read(obj.Username);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
