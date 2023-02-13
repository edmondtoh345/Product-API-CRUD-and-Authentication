using SummertimeSunshine_API.Exceptions;
using SummertimeSunshine_API.Products_Model;
using SummertimeSunshine_API.Repo;
using System.Xml.Linq;

namespace SummertimeSunshine_API.Product_Services
{
    public class ProductlistServices : IProductlistServices
    {
        private readonly IProductlistRepo repo;
        public ProductlistServices(IProductlistRepo repo)
        {
            this.repo = repo;
        }

        public int AddProduct(Productlist productlist)
        {
            if (repo.GetProductbyId(productlist.ProductID) != null)
            {
                throw new ProductAlreadyExistException($"Product with ID:{productlist.ProductID} already exists.");
            }
            return repo.AddProduct(productlist);
        }

        public int DeleteProduct(int id)
        {
            if (repo.GetProductbyId(id) == null)
            {
                throw new ProductNotFoundException($"Product with ID:{id} cannot be found. Please try again.");
            }
            return repo.DeleteProduct(id);
        }

        public List<Productlist> GetAllProducts()
        {
            return repo.GetAllProducts();   
        }

        public Productlist GetProductbyId(int id)
        {
            var result = repo.GetProductbyId(id); 
            if (result == null)
            {
                throw new ProductNotAvailableException($"Product with ID:{id} is not available. Please try again.");
            }
             return result;
            
        }

        public List<Productlist> GetProductbyName(string name)
        {
            var result = repo.GetProductbyName(name);
            if (result == null)
            {
                throw new ProductNotAvailableException($"{name} is not available. Please try again.");
            }
            else
            {
                return result;
            }
        }

        public List<Productlist> GetProductbyType(string type)
        {
            var result = repo.GetProductbyType(type);
            if (result == null)
            {
                throw new ProductNotFoundException($"This Product type:{type} cannot be found at the moment. Please try again.");
            }
            else
            {
                return result;
            }
        }

        public List<Productlist> GetProductsbyPrice(string price)
        {
            var result = repo.GetProductsbyPrice(price);
            if (result == null)
            {
                throw new ProductNotFoundException($"Product priced at {price} cannot be found at the moment. Please try again.");
            }
            else
            {
                return result;
            }
        }

        public List<Productlist> GetProductsbyQty(int qty)
        {
            var result = repo.GetProductsbyQty(qty);
            if (result == null)
            {
                throw new ProductNotFoundException($"Products with quantity:{qty} cannot be found at the moment. Please try again.");
            }
            else
            {
                return result;
            }
        }

        public int UpdateProduct(Productlist productlist, int id)
        {
            if (repo.GetProductbyId(id) == null)
            {
                throw new ProductNotFoundException($"Product with ID:{id} cannot be found. Please try again.");
            }
            return repo.UpdateProduct(productlist, id);

        }

    }
}
