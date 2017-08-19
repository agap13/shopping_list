using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shopping.Core.Model.Entities.Interfaces;

namespace Shopping.Core.Model.Storage.Interfaces
{
    public interface IGenericStorage
    {
        Task<TEntity> GetRow<TEntity>(object primaryKey) where TEntity : class, IEntity, new();

        Task<List<TEntity>> GetRows<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity, new();

        Task<int> InsertRow<TEntity>(TEntity entity) where TEntity : class, IEntity;

        Task<int> InsertOrReplaceRow<TEntity>(TEntity entity) where TEntity : class, IEntity;

        Task<int> InsertRows<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;

        Task DeleteRow<TEntity>(TEntity entity) where TEntity : class, IEntity;

        Task DeleteAll<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;
    }
}