using SQLite;

namespace Shopping.Core.Model.Storage
{
    public interface IDatabaseConnection
    {
        SQLiteAsyncConnection DbConnection();
        SQLiteConnection DbConnectionSync();
    }
}
