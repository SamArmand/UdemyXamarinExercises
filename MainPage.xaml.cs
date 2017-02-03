using System;
using Xamarin.Forms;

namespace UdemyXamarinExercises
{
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, EventArgs e)
		{
			switch (((Button)sender).Text)
			{
				case ("SignUp"):
					await Navigation.PushModalAsync(new SignUpPage());
					break;
				case ("Relax"):
					await Navigation.PushModalAsync(new RelaxPage());
					break;
				case ("Quotes"):
					await Navigation.PushModalAsync(new QuotesPage());
					break;
				case ("Gallery"):
					await Navigation.PushModalAsync(new GalleryPage());
					break;
				case ("Airbnb"):
					await Navigation.PushModalAsync(new AirbnbApp.SearchListPage());
					break;
				case ("Instagram"):
					await Navigation.PushModalAsync(new NavigationPage(new InstagramApp.MainPage()));
					break;
				case ("Skype"):
					await Navigation.PushAsync(new SkypeApp.MainPage());
					break;
				case ("Netflix Roulette"):
					await Navigation.PushAsync(new NetflixRouletteApp.MoviesSearchPage());
					break;
				default:
					throw new Exception("Unknown Page");
			}
		}
	}
}