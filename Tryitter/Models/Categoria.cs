﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tryitter.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        [JsonIgnore]
        public ICollection<Post>? Posts { get; set; }
    }
}
