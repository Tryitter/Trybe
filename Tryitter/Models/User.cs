using System.ComponentModel.DataAnnotations;

namespace Tryitter.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [MinLength(3), MaxLength(30)]
        public string? Name { get; set; }
        [MinLength(3), MaxLength(30)]
        public string? Email { get; set; }
        [MinLength(8)]
        public string? ModuloAtual { get; set; }
        [MinLength(8)]
        public string? Password { get; set; }
    }
}
