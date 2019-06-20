using _DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BusinessLayer
{
    public class SaleBusiness : DatabaseBusiness<Sale>
    {
        MarketEntities db = new MarketEntities();

        public override void Create(Sale t)
        {
            db.Sales.Add(t);
            db.SaveChanges();
        }

        public override void Delete(Sale t)
        {
            db.Sales.Remove(t);
            db.SaveChanges();
        }

        public override void Delete(int id)
        {
            Sale cus = db.Sales.Find(id);
            db.Sales.Remove(cus);
            db.SaveChanges();
        }

        public override List<Sale> List()
        {
            return db.Sales.ToList();
        }

        public override Sale Read(int id)
        {
            return db.Sales.SingleOrDefault(c => c.ProductID == id);
        }

        public override void Update(Sale t)
        {
            db.Sales.Attach(t);
            db.Entry<Sale>(t).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
