using API.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ListDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
