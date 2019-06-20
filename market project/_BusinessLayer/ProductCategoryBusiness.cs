using _DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BusinessLayer
{
    public class ProductCategoryBusiness : DatabaseBusiness<ProductCategory>
    {
        MarketEntities db = new MarketEntities();
        public override void Create(ProductCategory t)
        {
            db.ProductCategories.Add(t);
            db.SaveChanges();
        }

        public override void Delete(ProductCategory t)
        {
            db.ProductCategories.Remove(t);
            db.SaveChanges();
        }

        public override void Delete(int id)
        {
            ProductCategory cus = db.ProductCategories.Find(id);
            db.ProductCategories.Remove(cus);
            db.SaveChanges();
        }

        public override List<ProductCategory> List()
        {
            return db.ProductCategories.ToList();
        }

        public override ProductCategory Read(int id)
        {
            return db.ProductCategories.SingleOrDefault(c => c.categoryID == id);
        }

        public override void Update(ProductCategory t)
        {
            db.ProductCategories.Attach(t);
            db.Entry<ProductCategory>(t).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
