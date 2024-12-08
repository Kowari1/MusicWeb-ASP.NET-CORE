using MusicWebsite.Server.Data.IRepositories;
using MusicWebsite.Server.Models;

namespace MusicWebsite.Server.Data.Repositories
{
    internal class TrackRepository : Repository<Track>, ITrackRepository
    {
        private ApplicationDbContext _db;

        public TrackRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
