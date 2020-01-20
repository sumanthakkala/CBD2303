using System;
namespace CBD2303.Models
{
    public class Users
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public String Country { get; set; }
    }
}
