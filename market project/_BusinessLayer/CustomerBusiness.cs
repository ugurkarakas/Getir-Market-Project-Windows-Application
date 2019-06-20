using _DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BusinessLayer
{
    public class CustomerBusiness : DatabaseBusiness<Customer>
    {
        private MarketEntities db = new MarketEntities();
        public override void Create(Customer t)
        {
            db.Customers.Add(t);
            db.SaveChanges();
        }

        public override void Delete(Customer t)
        {
            db.Customers.Remove(t);
            db.SaveChanges();
        }

        public override void Delete(int id)
        {
            Customer cus = db.Customers.Find(id);
            db.Customers.Remove(cus);
            db.SaveChanges();
        }

        public override List<Customer> List()
        {
            return db.Customers.ToList();
        }

        public int ExecuteCommand(string v, SqlParameter[] sqlParameter)
        {
            throw new NotImplementedException();
        }

        public override Customer Read(int id)
        {
            return db.Customers.SingleOrDefault(c => c.CustomerID == id);
        }

        public override void Update(Customer t)
        {
            db.Customers.Attach(t);
            db.Entry<Customer>(t).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
