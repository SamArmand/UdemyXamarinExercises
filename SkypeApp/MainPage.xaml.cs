using Xamarin.Forms;

namespace UdemyXamarinExercises.SkypeApp
{
	public partial class MainPage
	{
		public MainPage()
		{
			NavigationPage.SetHasNavigationBar(this, false);

			InitializeComponent();

			Children.Add(new NavigationPage(new ContactsPage())
			{
				Title = "Contacts",
				Icon = "Address Book/Address Book-29.png"
			});
			Children.Add(new NavigationPage(new PhonePage())
			{
				Title = "Phone",
				Icon = "Phone/Phone-29.png"
			});
			Children.Add(new NavigationPage(new CreditPage())
			{
				Title = "Credit",
				Icon = "Wallet/Wallet-29.png"
			});
		}
	}
}
