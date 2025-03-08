using System.ComponentModel.DataAnnotations;

namespace Nature_Hub_Server.Models
{
    public class HealthTip
    {
        [Key]
        public int TipId { get; set; }
        public string Category { get; set; }

        public string description { get; set; }
    }
}
