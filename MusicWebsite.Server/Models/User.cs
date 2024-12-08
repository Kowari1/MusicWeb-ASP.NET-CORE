using System.ComponentModel.DataAnnotations;

namespace MusicWebsite.Server.Models
{
    public class User
    {
        public User() { }

        public User(int Id, string name, string email, string password, string role, ICollection<Playlist> playlists = null)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            Playlists = playlists;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Имя обязателено")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Имя должено содержать минимум 3 символа")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный формат email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пароль обязателен")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Пароль должен содержать минимум 6 символов")]
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<Playlist>? Playlists { get; set; }
    }
}
