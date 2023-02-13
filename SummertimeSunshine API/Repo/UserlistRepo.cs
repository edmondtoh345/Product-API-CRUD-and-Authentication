using SummertimeSunshine_API.Products_Model;

namespace SummertimeSunshine_API.Repo
{
    public class UserlistRepo : IUserlistRepo
    {
        private readonly ProductContext db;
        public UserlistRepo(ProductContext db)
        {
            this.db = db;
        }

        public int Register(Userlist userlist)
        {
            db.Userlist.Add(userlist);
            return db.SaveChanges();
        }

        public bool Login(string username, string password)
        {
            var l = db.Userlist.Where(x => x.UserUsername == username && x.UserPassword == password).FirstOrDefault();
            if (l != null)
            {
                return true;
            }
            return false;
        }

        public Userlist GetUser(string username, string password)
        {
            return db.Userlist.Where(x => x.UserUsername == username && x.UserPassword == password).FirstOrDefault();
        }

        public Userlist GetUser(string username)
        {
            return db.Userlist.Where(x => x.UserUsername == username).FirstOrDefault();
        }
    }
}