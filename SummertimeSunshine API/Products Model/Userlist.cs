using System.ComponentModel.DataAnnotations;

namespace SummertimeSunshine_API.Products_Model
{
    public class Userlist
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserUsername { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public int UserAge { get; set; }
        public string UserCity { get; set; }
    }
}
