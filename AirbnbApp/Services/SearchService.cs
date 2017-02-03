using System.Linq;
using System;
using UdemyXamarinExercises.AirbnbApp.Models;
using System.Collections.Generic;

namespace UdemyXamarinExercises.AirbnbApp.Services
{
	public class SearchService
	{
		readonly List<Search> _searches = new List<Search>
		{
			new Search
			{
				Id = 0,
				Location = "West Hollywood, CA, United States",
				CheckIn = new DateTime(2016, 9, 1),
				CheckOut = new DateTime(2016, 11, 1)
			},
			new Search
			{
				Id = 1,
				Location = "Santa Monica, CA, United States",
				CheckIn = new DateTime(2016, 9, 1),
				CheckOut = new DateTime(2016, 11, 1)
			}
		};

		public IEnumerable<Search> GetSearches(string filter = null) =>
		    string.IsNullOrEmpty(filter) ? _searches
		        : from search in _searches where search.Location.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 select search;

	    public void DeleteSearch(Search search) => _searches.Remove(search);
	}
}
