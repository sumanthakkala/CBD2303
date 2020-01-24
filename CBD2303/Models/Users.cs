using System;
using System.ComponentModel.DataAnnotations;

namespace CBD2303.Models
{
    public class Users
    {
        [Key]
        public long UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public String Country { get; set; }
    }
}
