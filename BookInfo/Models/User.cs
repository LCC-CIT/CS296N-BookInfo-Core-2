using Microsoft.AspNetCore.Identity;

namespace BookInfo.Models
{
    public class User : IdentityUser
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}