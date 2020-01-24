using System;
using System.Collections.Generic;

namespace CBD2303.Models
{
    public class UserStatuses
    {
        public Users user { get; set; }
        public List<StatusTextsWithLikes> UserStatusesList { get; set; }
    }
    public class StatusTextsWithLikes
    {
        public long StatusId { get; set; }
        public long UserID { get; set; }
        public string StatusText { get; set; }
        public List<Likes> LikeDetails { get; set; }
    }
}
