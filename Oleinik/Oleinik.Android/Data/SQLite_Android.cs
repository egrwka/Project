using Oleinik.Data;
using Oleinik.Droid.Data;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]

namespace Oleinik.Droid.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "Items.db3";
            string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}