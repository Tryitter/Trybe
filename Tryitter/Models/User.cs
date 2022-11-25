using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tryitter.Models
{
    public class User
    {
        public User()
        {
            Posts = new Collection<Post>();
        }
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
        [JsonIgnore]
        public IEnumerable<Post> Posts { get; set; }
    }
}
