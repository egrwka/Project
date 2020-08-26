using SQLite;

namespace Oleinik.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
