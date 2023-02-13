using SummertimeSunshine_API.Products_Model;

namespace SummertimeSunshine_API.Repo
{
    public interface IUserlistRepo
    {
        int Register(Userlist userlist);
        bool Login (string username, string password);
        Userlist GetUser(string username, string password);
        Userlist GetUser(string username);
    }
}
