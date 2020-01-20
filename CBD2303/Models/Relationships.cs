using System;
namespace CBD2303.Models
{
    public class Relationships
    {
        public long RelationshipID { get; set; }
        public long FollowerID { get; set; }
        public long FollowingID { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
