using UdemyXamarinExercises.SkypeApp.ViewModels;
using Xamarin.Forms;

namespace UdemyXamarinExercises.SkypeApp
{
	public partial class ContactsPage
	{
		public ContactsPageViewModel ViewModel
		{
			get { return BindingContext as ContactsPageViewModel; }
			set { BindingContext = value; }
		}

		public ContactsPage()
		{
			ViewModel = new ContactsPageViewModel();

			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			ViewModel.LoadContactsCommand.Execute(null);
				
			base.OnAppearing();
		}

		void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e) => 
			ViewModel.SelectContactCommand.Execute(e.SelectedItem);
	}
}
