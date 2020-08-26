using SQLite;

namespace Oleinik.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}