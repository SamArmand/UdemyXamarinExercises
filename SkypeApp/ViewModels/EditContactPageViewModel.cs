using System;
using System.Threading.Tasks;
using System.Windows.Input;
using UdemyXamarinExercises.Persistence;
using UdemyXamarinExercises.SkypeApp.Models;
using UdemyXamarinExercises.SkypeApp.Persistence;
using UdemyXamarinExercises.SkypeApp.Services;
using Xamarin.Forms;

namespace UdemyXamarinExercises.SkypeApp.ViewModels
{
	public class EditContactPageViewModel : BaseViewModel
	{
		public Contact Contact { get; }

		readonly Contact _selectedContact;

		public ICommand SaveContactCommand { get; private set; }

		readonly IPageService _pageService = new PageService();
		readonly IContactStore _contactStore = new SqliteContactStore(DependencyService.Get<ISqliteDb>());

		public EditContactPageViewModel(Contact contact)
		{
			if (contact == null) throw new ArgumentNullException(nameof(contact));

			_selectedContact = contact;

			Contact = new Contact
			{
				Id = contact.Id,
				FirstName = contact.FirstName,
				LastName = contact.LastName,
				Phone = contact.Phone,
				Email = contact.Email,
				Blocked = contact.Blocked
			};

			SaveContactCommand = new Command(async () => await SaveContact());
		}

		async Task SaveContact()
		{
			if (string.IsNullOrEmpty(Contact.Name))
			{
				await _pageService.DisplayAlert("Error", "Please enter a name.", "OK");
				return;
			}

			if (Contact.Id == 0) 
			{
				await _contactStore.AddContact(Contact);
				MessagingCenter.Send(this, "ContactAdded", Contact);
			}

			else
			{
				await _contactStore.UpdateContact(Contact);

				_selectedContact.Id = Contact.Id;
				_selectedContact.FirstName = Contact.FirstName;
				_selectedContact.LastName = Contact.LastName;
				_selectedContact.Phone = Contact.Phone;
				_selectedContact.Email = Contact.Email;
				_selectedContact.Blocked = Contact.Blocked;

			}

			await _pageService.PopAsync();
		}
	}
}
