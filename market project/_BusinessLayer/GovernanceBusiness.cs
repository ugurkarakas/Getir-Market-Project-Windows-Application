using _DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BusinessLayer
{
    public class GovernanceBusiness : DatabaseBusiness<Governance>
    {
        private MarketEntities db = new MarketEntities();

        public override void Create(Governance t)
        {
            db.Governances.Add(t);
            db.SaveChanges();
        }

        public override void Delete(Governance t)
        {
            db.Governances.Remove(t);
            db.SaveChanges();
        }

        public override void Delete(int id)
        {
            Governance cus = db.Governances.Find(id);
            db.Governances.Remove(cus);
            db.SaveChanges();
        }

        public override List<Governance> List()
        {
            return db.Governances.ToList();
        }

        public override Governance Read(int id)
        {
            return db.Governances.SingleOrDefault(c => c.GovernanceID == id);
        }

        public override void Update(Governance t)
        {
            db.Governances.Attach(t);
            db.Entry<Governance>(t).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
