﻿using Microsoft.EntityFrameworkCore;
using MusicWebsite.Server.Data.IRepositories;
using System.Collections.Generic;

namespace MusicWebsite.Server.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> values = _dbSet;
            return await values.Where(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await _db.SaveChangesAsync();
        }
    }
}
