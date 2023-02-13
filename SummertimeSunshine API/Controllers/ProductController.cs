using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SummertimeSunshine_API.Filters;
using SummertimeSunshine_API.Product_Services;
using SummertimeSunshine_API.Products_Model;
using SummertimeSunshine_API.Registration_Services;
using SummertimeSunshine_API.Repo;
using SummertimeSunshine_API.User_Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SummertimeSunshine_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [MyException]

    public class ProductController : ControllerBase
    {
        private readonly IProductlistServices productlistServices;
        private readonly ITokenGeneratorService tokenGeneratorService;
        private readonly IUserService userService;
        public ProductController(IProductlistServices productlistServices, ITokenGeneratorService tokenGeneratorService, IUserService userService)
        {
            this.productlistServices = productlistServices;
            this.tokenGeneratorService = tokenGeneratorService;
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult AddNewProduct(Productlist productlist)
        {
            productlistServices.AddProduct(productlist);
            return StatusCode(201, "The new product has been added successfully");
        }

        [HttpDelete]
        [Route("deleteproduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            return Ok(productlistServices.DeleteProduct(id));
        }

        [HttpGet("getallproducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(productlistServices.GetAllProducts());
        }

        [HttpGet("getbyid/{productID}")]
        public IActionResult getbyid(int productID)
        {
            return Ok(productlistServices.GetProductbyId(productID));
        }

        [HttpGet("getbyname/{productName}")]
        public IActionResult getbyname(string productName)
        {
            return Ok(productlistServices.GetProductbyName(productName));
        }

        [HttpGet("getbytype/{productType}")]
        public IActionResult getbytype(string productType)
        {
            return Ok(productlistServices.GetProductbyType(productType));
        }

        [HttpGet("getbyprice/{productPrice}")]
        public IActionResult getbyprice(string productPrice)
        {
            return Ok(productlistServices.GetProductsbyPrice(productPrice));
        }

        [HttpGet("getbyqty/{productQuantity}")]
        public IActionResult getbyqty(int productQuantity)
        {
            return Ok(productlistServices.GetProductsbyQty(productQuantity));
        }

        [HttpPut("updateproducts/{productID}")]
        public IActionResult update(Productlist productlist, int productID)
        {
            return Ok(productlistServices.UpdateProduct(productlist, productID));
        }

        [HttpPost("register")]
        public IActionResult Register(Userlist user)
        {
            return Ok(userService.Register(user));
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            if (userService.Login(username, password))
            {
                return Ok(tokenGeneratorService.GenerateToken(username));
            }
            return BadRequest();
        }

    }
}