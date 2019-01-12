using Microsoft.AspNetCore.Identity;

namespace BookInfo.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}