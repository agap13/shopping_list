using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Shopping.Core.Services;
using SQLite;
using System.IO;
using Shopping.Droid.Services;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace Shopping.Droid.Services
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteAsyncConnection DbConnection()
        {
            var dbName = "ShoppingListDb.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);

            if (!File.Exists(path))
                File.Create(path);


            return new SQLiteAsyncConnection(path);
        }
    }
}