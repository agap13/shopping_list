using System;
using System.IO;
using Shopping.Core.Model.Storage;
using Shopping.Droid.Services;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnection_Android))]

namespace Shopping.Droid.Services
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteAsyncConnection DbConnection()
        {
            var dbName = "ShoppingListDb.sqlite"; //
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);

            if (!File.Exists(path))
                File.Create(path);


            return new SQLiteAsyncConnection(path, false);
        }

        public SQLiteConnection DbConnectionSync()
        {
            var dbName = "ShoppingListDb.sqlite";
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);

            if (!File.Exists(path))
                File.Create(path);


            return new SQLiteConnection(path, false);
        }
    }
}