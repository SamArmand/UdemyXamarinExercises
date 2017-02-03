using System;
using System.Collections.Generic;
using UdemyXamarinExercises.AirbnbApp.Models;
using UdemyXamarinExercises.AirbnbApp.Services;
using Xamarin.Forms;

namespace UdemyXamarinExercises.AirbnbApp
{
	public partial class SearchListPage
	{
	    readonly SearchService _searchService = new SearchService();
		List<SearchGroup> _searchGroups;

		public SearchListPage()
		{
			InitializeComponent();

			PopulateListView(_searchService.GetSearches());
		}

		void Delete_Clicked(object sender, EventArgs e)
		{
		    var menuItem = sender as MenuItem;
		    if (menuItem == null) return;
		    var search = menuItem.CommandParameter as Search;
		    _searchGroups[0].Remove(search);
		    _searchService.DeleteSearch(search);
		}

		void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e) => ListView.SelectedItem = null;

	    void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
		{
		    var search = e.Item as Search;
		    if (search != null) DisplayAlert("Tapped", search.Location, "OK");
		}

		void Handle_Refreshing(object sender, EventArgs e)
		{
			PopulateListView(_searchService.GetSearches(SearchBar.Text));
			ListView.EndRefresh();
		}

		void PopulateListView(IEnumerable<Search> searches)
		{
			_searchGroups = new List<SearchGroup>
			{
				new SearchGroup("Recent Searches", searches)
			};

			ListView.ItemsSource = _searchGroups;
		}
	}
}
