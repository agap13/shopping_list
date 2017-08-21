using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shopping.Core.Model.Entities;
using Shopping.Core.Model.Storage.Interfaces;
using Shopping.Core.Services;
using SQLite;
using Xamarin.Forms;

namespace Shopping.Core.Model.Storage
{
    /// <summary>
    /// Class used to execute database operations.
    /// </summary>
    public class GenericStorage : IGenericStorage
    {
        private readonly SQLiteAsyncConnection _dbAsyncConnection;
        private readonly SQLiteConnection _dbSyncConnection;

        public GenericStorage()
        {
            _dbSyncConnection =
                DependencyService.Get<IDatabaseConnection>()
                    .DbConnectionSync();
            _dbAsyncConnection = DependencyService.Get<IDatabaseConnection>().DbConnection();
            InitializeTables();
        }

        async Task<TEntity> IGenericStorage.GetRow<TEntity>(object primaryKey)
        {
            return await _dbAsyncConnection.GetAsync<TEntity>(primaryKey);
        }

        async Task<List<TEntity>> IGenericStorage.GetRows<TEntity>(Expression<Func<TEntity, bool>> filter)
        {
            var entity = _dbAsyncConnection.Table<TEntity>();
            if (filter != null) entity = entity.Where(filter);
            return await entity.ToListAsync();
        }

        async Task<int> IGenericStorage.InsertRow<TEntity>(TEntity entity)
        {
            return await _dbAsyncConnection.InsertAsync(entity);
        }

        async Task<int> IGenericStorage.InsertOrReplaceRow<TEntity>(TEntity entity)
        {
            return await _dbAsyncConnection.InsertOrReplaceAsync(entity);
        }

        async Task<int> IGenericStorage.InsertRows<TEntity>(IEnumerable<TEntity> entities)
        {
            return await _dbAsyncConnection.InsertAllAsync(entities);
        }

        async Task IGenericStorage.DeleteRow<TEntity>(TEntity entity)
        {
            await _dbAsyncConnection.DeleteAsync(entity);
        }

        async Task IGenericStorage.DeleteAll<TEntity>(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                await _dbAsyncConnection.DeleteAsync(entity);
        }

        private void InitializeTables()
        {
            _dbSyncConnection.CreateTable<ShoppingItemEntity>();
            _dbSyncConnection.CreateTable<ShoppingItemPerPcs>();
            _dbSyncConnection.CreateTable<ShoppingItemPerWeight>();
        }
    }
}