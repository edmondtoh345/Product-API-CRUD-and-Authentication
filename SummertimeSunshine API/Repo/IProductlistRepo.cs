using SummertimeSunshine_API.Products_Model;

namespace SummertimeSunshine_API.Repo
{
    public interface IProductlistRepo
    {
        public List<Productlist> GetAllProducts();
        public Productlist GetProductbyId(int id);
        public List<Productlist> GetProductbyName(string name);
        public List<Productlist> GetProductbyType(string type);
        public List<Productlist> GetProductsbyPrice(string price);
        public List<Productlist> GetProductsbyQty(int qty);

        public int AddProduct(Productlist productlist);
        public int DeleteProduct(int id);
        public int UpdateProduct(Productlist productlist, int id);

    }
}
