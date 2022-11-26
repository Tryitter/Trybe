using Microsoft.EntityFrameworkCore;
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
        [JsonIgnore]
        public int UserId { get; set; }
        [MinLength(3), MaxLength(30)]
        public string? Name { get; set; }
        // [Index(IsUnique = true)]
        [MinLength(3), MaxLength(30)]
        public string? Email { get; set; }
        [MinLength(8)]
        public string? ModuloAtual { get; set; }
        [MaxLength(30)]
        public string? StatusPersonalizado { get; set; }
        [MinLength(8)]
        public string? Password { get; set; }
        [JsonIgnore]
        public IEnumerable<Post> Posts { get; set; }
    }
}
