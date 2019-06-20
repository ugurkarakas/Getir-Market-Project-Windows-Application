using _DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace marketproject.Bridge
{
    public interface ISalesO<T>
    {
        List<T> ShowA();
        T Onceki { get; }
        T Sonraki { get; }
        T Sonuncu { get; }
        T Bastaki { get; }
        T Mevcut { get; }
    }
    public class SalesObject : ISalesO<Sale>
    {
        private MarketEntities dbp = new MarketEntities();
        private List<Sale> prodc;
        private int _mevcut;
        public SalesObject()
        {
            prodc = dbp.Sales.ToList();
        }
        public Sale Onceki
        {
            get
            {
                if (_mevcut > 0)
                    _mevcut--;
                return prodc[_mevcut];

            }
        }
        public Sale Sonraki
        {
            get
            {
                if (_mevcut < prodc.Count - 1)
                    _mevcut++;
                return prodc[_mevcut];
            }
        }
        public Sale Sonuncu
        {
            get
            {
                return prodc[prodc.Count - 1];
            }

        }
        public Sale Bastaki
        {
            get
            {
                return prodc[0];
            }
        }
        public Sale Mevcut
        {
            get

            {
                return prodc[_mevcut];
            }
        }
        public List<Sale> ShowA()
        {
            return prodc;
        }

        List<Sale> ISalesO<Sale>.ShowA()
        {
            return prodc;
        }
    }
    public class ProductsB
    {
        public ISalesO<Sale> ProductObject { get; set; }
        public Sale Onceki { get { return ProductObject.Onceki; } }
        public Sale Sonraki { get { return ProductObject.Sonraki; } }
        public Sale Bastaki { get { return ProductObject.Bastaki; } }
        public Sale Sondaki { get { return ProductObject.Sonuncu; } }
        public Sale Mevcut { get { return ProductObject.Mevcut; } }
        public List<Sale> Show() { return ProductObject.ShowA(); }
    }
}


