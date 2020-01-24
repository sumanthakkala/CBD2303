using System;
using System.ComponentModel.DataAnnotations;

namespace CBD2303.Models
{
    public class Likes
    {
        [Key]
        public long LikeId { get; set; }
        public long StatusID { get; set; }
        public long UserID { get; set; }
    }
}
