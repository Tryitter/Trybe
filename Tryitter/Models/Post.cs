using System.Text.Json.Serialization;

namespace Tryitter.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }

        public DateTime DataPost { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }
    }
}
