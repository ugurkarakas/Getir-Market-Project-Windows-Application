using _DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BusinessLayer
{
    public class StaffBusiness : DatabaseBusiness<Staff>
    {
        private MarketEntities db = new MarketEntities();
        public override void Create(Staff t)
        {
            db.Staffs.Add(t);
            db.SaveChanges();
        }

        public override void Delete(Staff t)
        {
            db.Staffs.Remove(t);
            db.SaveChanges();
        }

        public override void Delete(int id)
        {
            Staff staf = db.Staffs.Find(id);
            db.Staffs.Remove(staf);
            db.SaveChanges();
        }

        public override List<Staff> List()
        {
            return db.Staffs.ToList();
        }

        public override Staff Read(int id)
        {
            return db.Staffs.SingleOrDefault(c => c.StaffID == id);

        }

        public override void Update(Staff t)
        {
            db.Staffs.Attach(t);
            db.Entry<Staff>(t).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        } 
    }
}
