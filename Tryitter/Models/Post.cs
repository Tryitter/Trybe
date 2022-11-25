using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tryitter.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [MinLength(1), MaxLength(30)]
        public string? Titulo { get; set; }
        [MinLength(1), MaxLength(280)]
        public string? Descricao { get; set; }

        public DateTime DataPost { get; set; }

        [JsonIgnore]
        public ICollection<Categoria>? Categoria { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
