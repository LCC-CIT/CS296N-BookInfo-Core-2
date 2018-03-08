using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BookInfo.Models
{
    public class RoleEditModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
}