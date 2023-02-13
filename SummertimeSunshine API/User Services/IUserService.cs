using SummertimeSunshine_API.Products_Model;

namespace SummertimeSunshine_API.User_Services
{
    public interface IUserService
    {
        int Register(Userlist userlist);
        bool Login(string username, string password);
    }
}
