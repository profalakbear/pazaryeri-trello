using API.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CardDTO
    {
        public int ID { get; set; }

        public int ListID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int Position { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
