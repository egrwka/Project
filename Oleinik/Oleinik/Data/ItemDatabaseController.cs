using Oleinik.Models;
using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Oleinik.Data
{
    public class ItemDatabaseController
    {
        SQLiteConnection database;
        public ItemDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Item>();
        }

        public Item GetItem(int id)
        {
            return database.Table<Item>().Where(i => i.Id == id).FirstOrDefault();
        }

        public List<Item> GetItems()
        {
            return database.Table<Item>().ToList();
        }
        public List<Item> GetItems(string search)
        {
            return database.Query<Item>("SELECT * FROM Item WHERE Text LIKE '%" + search + "%'");
        }
        public int SaveItem(Item item)
        {
            return database.Insert(item);
        }
        public int UpdateItem(Item item)
        {
            return database.Update(item);
        }

        public int DeleteItem(Item item)
        {
            return database.Delete(item);
        }
    }
}
