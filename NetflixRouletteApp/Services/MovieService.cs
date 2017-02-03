using System.Collections.Generic;
using UdemyXamarinExercises.NetflixRouletteApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Net;

namespace UdemyXamarinExercises.NetflixRouletteApp.Services
{
	public class MovieService
	{
		public static readonly int MinSearchLength = 5;

		readonly HttpClient _client = new HttpClient();
		const string Url = "https://netflixroulette.net/api/api.php?actor=";

		public async Task<IEnumerable<Movie>> FindMoviesByActor(string actor)
		{
			if (actor.Length < MinSearchLength) return Enumerable.Empty<Movie>();

			var response = await _client.GetAsync(Url + actor);

			if (response.StatusCode == HttpStatusCode.NotFound) return Enumerable.Empty<Movie>();

			var content = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<List<Movie>>(content);
		}
	}
}