using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UdemyXamarinExercises.Persistence;
using UdemyXamarinExercises.SkypeApp.Models;
using UdemyXamarinExercises.SkypeApp.Persistence;
using UdemyXamarinExercises.SkypeApp.Services;
using Xamarin.Forms;

namespace UdemyXamarinExercises.SkypeApp.ViewModels
{
	public class ContactsPageViewModel : BaseViewModel
	{
		bool _isLoaded;

	    public ObservableCollection<Contact> Contacts { get; } = new ObservableCollection<Contact>();

		public ICommand LoadContactsCommand { get; private set; }
		public ICommand AddContactCommand { get; private set; }
		public ICommand SelectContactCommand { get; private set; }
		public ICommand DeleteContactCommand { get; private set; }

		Contact _selectedContact;
		public Contact SelectedContact
		{
			get { return _selectedContact; }
			set { SetValue(ref _selectedContact, value); }
		}

		readonly IContactStore _contactStore = new SqliteContactStore(DependencyService.Get<ISqliteDb>());
		readonly IPageService _pageService = new PageService();

		public ContactsPageViewModel()
		{
			LoadContactsCommand = new Command(async () => await LoadContacts());
			AddContactCommand = new Command(AddContact);
			SelectContactCommand = new Command<Contact>(SelectContact);
			DeleteContactCommand = new Command<Contact>(async contact => await DeleteContact(contact));

			MessagingCenter.Subscribe<EditContactPageViewModel, Contact>(this, "ContactAdded", 
			                                                             (sender, contact) => Contacts.Add(contact));
		}

		async Task LoadContacts()
		{
			if (_isLoaded)
				return;

			var results = await _contactStore.GetContactsAsync();

			foreach (var result in results)
				Contacts.Add(result);

			_isLoaded = true;
		}

		void SelectContact(Contact selectedContact)
		{
			if (selectedContact == null) return;

			SelectedContact = null;

			_pageService.PushAsync(new EditContactPage(_selectedContact));
		}

		void AddContact() =>
			_pageService.PushAsync(new EditContactPage(new Contact()));

		async Task DeleteContact(Contact contact)
		{
			if (await _pageService.DisplayAlert("Warning", "Are you sure you want to delete " + contact.Name + "?",
					   "Accept", "Cancel"))

			Contacts.Remove(contact);
			await _contactStore.DeleteContact(contact);
		}
	}
}