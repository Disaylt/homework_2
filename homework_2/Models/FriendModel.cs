

using System.ComponentModel.DataAnnotations;

namespace homework_2.Models
{
    public class FriendModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле FriendName не может быть пустым")]
        public string Name { get; set; } = null!;

        [StringLength(25, ErrorMessage = "Максимальная длинна строки 25 символов")]
        public string Place { get; set; } = string.Empty;
    }
}
