using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tryitter.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }

        public DateTime DataPost { get; set; }

        [JsonIgnore]
        public ICollection<Categoria>? Categoria { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
