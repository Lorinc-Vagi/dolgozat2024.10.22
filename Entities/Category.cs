using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Dolgozat2024._10._22.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; } //IdegenKulcs
        [JsonIgnore]
        public IdentityUser User { get; set; }
    }
}
