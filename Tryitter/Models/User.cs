using System.ComponentModel.DataAnnotations;

namespace Tryitter.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        [MinLength(8)]
        public string? UserName { get; set; }
        [MinLength(8)]
        public string? Password { get; set; }
    }
}
