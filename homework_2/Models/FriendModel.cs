

using System.ComponentModel.DataAnnotations;

namespace homework_2.Models
{
    public class FriendModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Place { get; set; } = null!;
    }
}
