using MusicWebsite.Server.Models;

namespace MusicWebsite.Server.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public ICollection<PlaylistDto>? Playlists { get; set; }
    }
}
