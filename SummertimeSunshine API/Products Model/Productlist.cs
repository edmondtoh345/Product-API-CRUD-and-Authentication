using System.ComponentModel.DataAnnotations;

namespace SummertimeSunshine_API.Products_Model
{
    public class Productlist
    {
        [Key]
        public int ProductID { get; set; }  
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
        public string ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}
