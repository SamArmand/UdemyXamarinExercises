using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using UdemyXamarinExercises.Persistence;
using UdemyXamarinExercises.SkypeApp.Models;

namespace UdemyXamarinExercises.SkypeApp.Persistence
{
	public class SqliteContactStore : IContactStore
	{
		readonly SQLiteAsyncConnection _connection;

		public SqliteContactStore(ISqliteDb db)
		{
			_connection = db.GetConnection();
			_connection.CreateTableAsync<Contact>();
		}

		public async Task<IEnumerable<Contact>> GetContactsAsync() =>
			await _connection.Table<Contact>().ToListAsync();

		public async Task DeleteContact(Contact contact) =>
			await _connection.DeleteAsync(contact);

		public async Task AddContact(Contact contact) =>
			await _connection.InsertAsync(contact);

		public async Task UpdateContact(Contact contact) =>
			await _connection.UpdateAsync(contact);

		public async Task<Contact> GetContact(int id) =>
			await _connection.FindAsync<Contact>(id);
	}
}
