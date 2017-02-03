using System.Threading.Tasks;
using Xamarin.Forms;

namespace UdemyXamarinExercises.SkypeApp.Services
{
	public class PageService : IPageService
	{
		public async Task DisplayAlert(string title, string message, string ok) => 
			await Application.Current.MainPage.DisplayAlert(title, message, ok);

		public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel) => 
			await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);

		public async Task PopAsync() =>
			await Application.Current.MainPage.Navigation.PopAsync();

		public async Task PushAsync(Page page) =>
			await Application.Current.MainPage.Navigation.PushAsync(page);
	}
}