using SQLite;

namespace Shopping.Core.Model.Storage
{
    /// <summary>
    /// Interface for database sync/async connections.
    /// </summary>
    public interface IDatabaseConnection
    {
        SQLiteAsyncConnection DbConnection();
        SQLiteConnection DbConnectionSync();
    }
}
