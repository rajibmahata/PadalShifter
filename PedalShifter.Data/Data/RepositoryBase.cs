using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PedalShifter.Data.Interfaces;

namespace PedalShifter.Data.Data
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new()
    {
        protected readonly ApplicationDbContext RepositoryPatternDemoContext;

        public RepositoryBase(ApplicationDbContext repositoryPatternDemoContext)
        {
            RepositoryPatternDemoContext = repositoryPatternDemoContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return RepositoryPatternDemoContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await RepositoryPatternDemoContext.AddAsync(entity);
                await RepositoryPatternDemoContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                RepositoryPatternDemoContext.Update(entity);
                await RepositoryPatternDemoContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    }
}
