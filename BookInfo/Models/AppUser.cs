using Microsoft.AspNetCore.Identity;

namespace BookInfo.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}