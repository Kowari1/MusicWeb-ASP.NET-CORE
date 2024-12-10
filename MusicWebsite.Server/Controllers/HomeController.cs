using Microsoft.AspNetCore.Mvc;
using MusicWebsite.Server.Enums;
using MusicWebsite.Server.Models;

namespace MusicWebsite.Server.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : Controller
    {

        private static readonly List<Track> Tracks = new List<Track>
        {
            new Track { Id = 1, Title = "Song 1", Artist = "Artist 1", Genre = Genre.Pop, Duration = TimeSpan.FromMinutes(3).Add(TimeSpan.FromSeconds(45)) },
            new Track { Id = 2, Title = "Song 2", Artist = "Artist 2", Genre = Genre.Rock, Duration = TimeSpan.FromMinutes(4).Add(TimeSpan.FromSeconds(20)) },
            new Track { Id = 3, Title = "Song 3", Artist = "Artist 3", Genre = Genre.Jazz, Duration = TimeSpan.Parse("00:05:10") },
            new Track { Id = 4, Title = "Song 4", Artist = "Artist 4", Genre = Genre.Classical, Duration = new TimeSpan(0, 7, 15) }
        };

        [HttpGet("genres")]
        public IActionResult GetGenres()
        {
            var genres = Enum.GetValues(typeof(Genre)).Cast<Genre>().Select(g => g.ToString()).ToList();
            return Ok(genres);
        }

        [HttpGet("tracks")]
        public IActionResult GetTracks([FromQuery] string? genre, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var filteredTracks = string.IsNullOrEmpty(genre)
                ? Tracks
                : Tracks.Where(t => t.Genre.ToString().Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();

            var pagedTracks = filteredTracks
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(new
            {
                TotalCount = filteredTracks.Count,
                Tracks = pagedTracks
            });
        }
    }
}
