using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<ListItem> Lists { get; set; }
    }
}
