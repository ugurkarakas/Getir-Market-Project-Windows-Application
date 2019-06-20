using _DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BusinessLayer
{
  public class SepetBusiness : DatabaseBusiness<Sepet>
    {
        MarketEntities db = new MarketEntities();
        public override void Create(Sepet t)
        {
            db.Sepets.Add(t);
            db.SaveChanges();
        }

        public override void Delete(Sepet t)
        {
            db.Sepets.Remove(t);
            db.SaveChanges();
        }

        public override void Delete(int id)
        {
            Sepet cus = db.Sepets.Find(id);
            db.Sepets.Remove(cus);
            db.SaveChanges();
        }

        public override List<Sepet> List()
        {
            return db.Sepets.ToList();
        }

        public override Sepet Read(int id)
        {
            return db.Sepets.SingleOrDefault(c => c.ProductID == id);
        }

        public override void Update(Sepet t)
        {
            db.Sepets.Attach(t);
            db.Entry<Sepet>(t).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
