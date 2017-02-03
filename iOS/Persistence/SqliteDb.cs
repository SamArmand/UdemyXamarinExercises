using System;
using System.IO;
using SQLite;
using UdemyXamarinExercises.iOS.Persistence;
using UdemyXamarinExercises.Persistence;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteDb))]

namespace UdemyXamarinExercises.iOS.Persistence
{
    public class SqliteDb : ISqliteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}