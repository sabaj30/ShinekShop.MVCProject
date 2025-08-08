using Microsoft.EntityFrameworkCore;
using ShinekShopInfrastructure.Context;
using ShinekShopInfrastructure.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinekShopInfrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            this._dbSet = _applicationDbContext.Set<TEntity>();
        }

        public async ValueTask DisposeAsync()
        {
            if (_applicationDbContext != null)
            await _applicationDbContext.DisposeAsync();

        }

        public async Task AddEntity(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.LastUpdateDate = DateTime.Now;
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRAngeEntity(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreateDate = DateTime.Now;
                entity.LastUpdateDate = DateTime.Now;
                await _dbSet.AddAsync(entity);
            }
        }


        public void DeleteEntity(TEntity entity, int id)
        {
            _dbSet.Remove(entity);
        }

        public void EditEntity(int id, TEntity entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _dbSet.Update(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public async Task<TEntity> GetEntityById(int id)
        {
            return await _dbSet.SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task SaveChangeRepo()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }

}
