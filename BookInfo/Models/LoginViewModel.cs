using System;
using System.ComponentModel.DataAnnotations;

namespace BookInfo.Models
{
    public class LoginViewModel
    {

        [Required]
        [UIHint("email")]
        public string Email { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }

    }
}
