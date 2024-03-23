using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Log
    {
        public int ID { get; set; }

        public int CardID { get; set; }

        public string ActionType { get; set; }

        public string ActionDetails { get; set; }

        public DateTime CreatedAt { get; set; }

        public Card Card { get; set; }
    }
}
