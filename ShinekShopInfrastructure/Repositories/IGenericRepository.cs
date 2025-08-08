using ShinekShopInfrastructure.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinekShopInfrastructure.Repositories
{
    public interface IGenericRepository<TEntity> : IAsyncDisposable where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity> GetEntityById (int id);
        Task AddEntity(TEntity entity);
        Task AddRAngeEntity(List<TEntity> entity);
        void DeleteEntity(TEntity entity, int id);
        void EditEntity(int id,TEntity entity);
        Task SaveChangeRepo();

    }
}
