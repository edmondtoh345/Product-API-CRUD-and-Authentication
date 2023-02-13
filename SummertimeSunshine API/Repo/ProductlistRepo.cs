using Microsoft.EntityFrameworkCore;
using SummertimeSunshine_API.Products_Model;
using System.Xml.Linq;

namespace SummertimeSunshine_API.Repo
{
    public class ProductlistRepo : IProductlistRepo
    {
        private readonly ProductContext db;
        public ProductlistRepo(ProductContext db)
        {
            this.db = db;
        }

        public int AddProduct(Productlist productlist)
        {
            db.Productlist.Add(productlist);
            return db.SaveChanges();
        }

        public int DeleteProduct(int id)
        {
            var tobedeleted = db.Productlist.Where(x => x.ProductID == id).FirstOrDefault();
            db.Productlist.Remove(tobedeleted);
            return db.SaveChanges();
        }

        public List<Productlist> GetAllProducts()
        {
            return db.Productlist.ToList();
        }

        public Productlist GetProductbyId(int id)
        {
            var p = db.Productlist.Where(x => x.ProductID == id).FirstOrDefault();
            return p;
        }

        public List<Productlist> GetProductbyName(string name)
        {
            return db.Productlist.Where(x => x.ProductName.Contains(name)).ToList();
        }

        public List<Productlist> GetProductbyType(string type)
        {
            return db.Productlist.Where(x => x.ProductType == type).ToList();
        }

        public List<Productlist> GetProductsbyPrice(string price)
        {
            return db.Productlist.Where(x => x.ProductPrice.Contains(price)).ToList();
        }

        public List<Productlist> GetProductsbyQty(int qty)
        {
            return db.Productlist.Where(x => x.ProductQuantity == qty).ToList();
        }

        public int UpdateProduct(Productlist productlist, int id)
        {
            var tobeupdated = db.Productlist.Where(x => x.ProductID == id).FirstOrDefault();
            tobeupdated.ProductName = productlist.ProductName;
            tobeupdated.ProductDescription = productlist.ProductDescription;
            tobeupdated.ProductType = productlist.ProductType;
            tobeupdated.ProductBrand = productlist.ProductBrand;
            tobeupdated.ProductPrice = productlist.ProductPrice;
            tobeupdated.ProductQuantity = productlist.ProductQuantity;
            db.Entry<Productlist>(tobeupdated).State = EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
