using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyXamarinExercises.SkypeApp.Models;

namespace UdemyXamarinExercises.SkypeApp.Persistence
{
	public interface IContactStore
	{
		Task<IEnumerable<Contact>> GetContactsAsync();

		Task DeleteContact(Contact contact);

		Task AddContact(Contact contact);

		Task UpdateContact(Contact contact);

		Task<Contact> GetContact(int id);
	}
}
