using UdemyXamarinExercises.InstagramApp.Models;
using UdemyXamarinExercises.InstagramApp.Services;
using Xamarin.Forms;

namespace UdemyXamarinExercises.InstagramApp
{
	public partial class ActivitiesPage
	{
		public ActivitiesPage()
		{
			InitializeComponent();

			ListView.ItemsSource = (new ActivityService()).GetActivities();
		}

		async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) return;
			
			await Navigation.PushAsync(new ProfilePage(e.SelectedItem as Activity));

			ListView.SelectedItem = null;
		}
	}
}
