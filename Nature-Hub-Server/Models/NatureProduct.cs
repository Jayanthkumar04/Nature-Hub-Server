using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nature_Hub_Server.Models
{
    public class NatureProduct
    {

        [Key]
        public int ProId { get; set; }
        public string ProName { get; set; }
        public string description { get; set; }

        public string ProCategory { get; set; }
        public double ProPrice { get; set; }
        public string ProImgUrl { get; set; }
    }
}
