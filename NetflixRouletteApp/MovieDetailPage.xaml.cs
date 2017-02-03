using UdemyXamarinExercises.NetflixRouletteApp.Models;

namespace UdemyXamarinExercises.NetflixRouletteApp
{
	public partial class MovieDetailPage
	{
		public MovieDetailPage(Movie movie)
		{
			BindingContext = movie;

			InitializeComponent();
		}
	}
}
