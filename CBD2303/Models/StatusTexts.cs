using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBD2303.Models
{
    public class StatusTexts
    {
        [Key]
        public long StatusId { get; set; }
        public long UserID { get; set; }
        public string StatusText { get; set; }
    }
}
