using System.ComponentModel.DataAnnotations;

namespace Nature_Hub_Server.Models
{
    public class Remedy
    {
        [Key]
        public int RemedyId { get; set; }

        public string Description { get; set; }

        public string Preparation { get; set; }

        public string Benefits { get; set; }

        public string Instructions { get; set; }

        public string Category { set; get; }
    }
}
