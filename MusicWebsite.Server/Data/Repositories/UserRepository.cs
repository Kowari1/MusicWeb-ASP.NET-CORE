using MusicWebsite.Server.Data.IRepositories;
using MusicWebsite.Server.Enums;
using MusicWebsite.Server.Models;

namespace MusicWebsite.Server.Data.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
