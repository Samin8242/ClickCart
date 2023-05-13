using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PaymentDetailRepo : Repo, IRepo<PaymentDetail, int, PaymentDetail>
    {
        public PaymentDetail Create(PaymentDetail obj)
        {
            db.PaymentDetails.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.PaymentDetails.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<PaymentDetail> Read()
        {
            return db.PaymentDetails.ToList();
        }

        public PaymentDetail Read(int id)
        {
            return db.PaymentDetails.Find(id);
        }

        public PaymentDetail Update(PaymentDetail obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
