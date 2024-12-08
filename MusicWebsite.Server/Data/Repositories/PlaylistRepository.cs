using MusicWebsite.Server.Data.IRepositories;
using MusicWebsite.Server.Models;

namespace MusicWebsite.Server.Data.Repositories
{
    internal class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        private ApplicationDbContext _db;

        public PlaylistRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
