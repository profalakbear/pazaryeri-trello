using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MVC.Models
{
    public class Card
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("listID")]
        public int ListID { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("cards")]
        public ListItem List { get; set; }

        [JsonPropertyName("logs")]
        public ICollection<Log> Logs { get; set; }
    }
}
