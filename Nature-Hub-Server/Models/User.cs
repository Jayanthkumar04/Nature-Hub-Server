using System.ComponentModel.DataAnnotations;

namespace Nature_Hub_Server.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string Role { get; set; }
    }
}
