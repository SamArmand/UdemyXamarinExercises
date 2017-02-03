using SQLite;

namespace UdemyXamarinExercises.Persistence
{
    public interface ISqliteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

