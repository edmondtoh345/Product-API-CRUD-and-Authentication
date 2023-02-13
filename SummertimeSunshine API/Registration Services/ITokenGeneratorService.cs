using SummertimeSunshine_API.Products_Model;

namespace SummertimeSunshine_API.Registration_Services
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(string username);
    }
}
