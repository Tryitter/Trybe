using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tryitter.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [MinLength(3)]
        public string? Nome { get; set; }
        [MinLength(3)]
        public string? Descricao { get; set; }
        [JsonIgnore]
        public ICollection<Post>? Posts { get; set; }
    }
}
