using Microsoft.AspNetCore.Identity;

namespace BookInfo.Models
{
    public class AppUser : IdentityUser
    {
        // TODO: Find out why identity didn't add tables to the db
        // until I added UserID. I shouldn't need UserID
        // A bug in Identity or EF?
        public int UserID { get; set; }

        // These properties are in addition to those inherited from IdentityUser
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}