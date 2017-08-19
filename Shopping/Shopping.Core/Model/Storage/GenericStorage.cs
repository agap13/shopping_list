using Shopping.Core.Model.Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SQLite;
using Shopping.Core.Services;
using Xamarin.Forms;
using Shopping.Core.POs;
using Shopping.Core.Model.Entities;

namespace Shopping.Core.Model.Storage
{
    public class GenericStorage : IGenericStorage
    {
        private readonly SQLiteConnection _dbSyncConnection;
        private readonly SQLiteAsyncConnection _dbAsyncConnection;

        public GenericStorage()
        {
            _dbSyncConnection = DependencyService.Get<IDatabaseConnection>().DbConnectionSync();//new SQLiteConnection(dbConnection.GetDatabasePath(), false);
            _dbAsyncConnection = DependencyService.Get<IDatabaseConnection>().DbConnection();
            InitializeTables();
        }

        private void InitializeTables()
        {
            _dbSyncConnection.CreateTable<ShoppingItemEntity>();
            _dbSyncConnection.CreateTable<ShoppingItemPerPcs>();
            _dbSyncConnection.CreateTable<ShoppingItemPerWeight>();
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
            {
                await _dbAsyncConnection.DeleteAsync(entity);
            }
        }

       
    }
}
