using Newtonsoft.Json;

namespace UdemyXamarinExercises.NetflixRouletteApp.Models
{
	public class Movie
	{
		[JsonProperty("show_title")]
		public string Title { get; set; }

		[JsonProperty("release_year")]
		public int ReleaseYear { get; set; }

		[JsonProperty("poster")]
		public string PosterUri { get; set; }

		[JsonProperty("summary")]
		public string Summary { get; set; }
	}
}
