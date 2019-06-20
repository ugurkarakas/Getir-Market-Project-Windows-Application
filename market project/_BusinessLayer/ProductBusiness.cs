using _DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BusinessLayer
{
    public class ProductBusiness : DatabaseBusiness<Product>
    {
       private MarketEntities db = new MarketEntities();
        public override void Create(Product t)
        {
            db.Products.Add(t);
            db.SaveChanges();
        }

        public override void Delete(Product t)
        {
            db.Products.Remove(t);
            db.SaveChanges();
        }

        public override void Delete(int id)
        {
            Product cus = db.Products.Find(id);
            db.Products.Remove(cus);
            db.SaveChanges();
        }

        public override List<Product> List()
        {
            return db.Products.ToList();
        }

        public override Product Read(int id)
        {
            return db.Products.SingleOrDefault(c => c.ProductID == id);
        }
        public List<SP_ProductStockByCat_Result> ProductsStockByCategory()
        {
            return db.SP_ProductStockByCat().ToList();
        }

        public override void Update(Product t)
        {
            db.Products.Attach(t);
            db.Entry<Product>(t).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
