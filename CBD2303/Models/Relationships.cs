using System;
using System.ComponentModel.DataAnnotations;

namespace CBD2303.Models
{
    public class Relationships
    {
        [Key]
        public long RelationshipId { get; set; }
        public long FollowerID { get; set; }
        public long FollowingID { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}



