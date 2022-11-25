using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tryitter.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [MaxLength(30)]
        public string? Titulo { get; set; }
        [MaxLength(300)]
        public string? Descricao { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime DataPost { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
    }
}
