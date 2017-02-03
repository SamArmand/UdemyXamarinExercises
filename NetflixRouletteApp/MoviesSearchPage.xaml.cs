using System;
using UdemyXamarinExercises.NetflixRouletteApp.Services;
using UdemyXamarinExercises.NetflixRouletteApp.Models;
using System.Linq;

using Xamarin.Forms;

namespace UdemyXamarinExercises.NetflixRouletteApp
{
	public partial class MoviesSearchPage
	{
		MovieService _service = new MovieService();

		BindableProperty IsSearchingProperty =
			BindableProperty.Create("IsSearching", typeof(bool), typeof(MoviesSearchPage), false);
		public bool IsSearching
		{
			get { return (bool)GetValue(IsSearchingProperty); }
			set { SetValue(IsSearchingProperty, value); }
		}

		public MoviesSearchPage()
		{
			BindingContext = this;

			InitializeComponent();
		}

		async void Handle_TextChanged(object sender, TextChangedEventArgs e)
		{
			string query = e.NewTextValue;

			if (query == null || query.Length < MovieService.MinSearchLength) return;

			try
			{
				IsSearching = true;

				var movies = await _service.FindMoviesByActor(query);
				ListView.ItemsSource = movies;
				ListView.IsVisible = movies.Any();
				Frame.IsVisible = !ListView.IsVisible;
			}
			catch (Exception)
			{
				await DisplayAlert("Error", "Could not retrieve the list of movies.", "OK");
			}
			finally
			{
				IsSearching = false;
			}
		}

		async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) return;

			ListView.SelectedItem = null;

			await Navigation.PushAsync(new MovieDetailPage(e.SelectedItem as Movie));
		}
	}
}
