using System.Threading.Tasks;
using Xamarin.Forms;

namespace UdemyXamarinExercises.SkypeApp.Services
{
	public interface IPageService
	{
		Task PushAsync(Page page);

		Task PopAsync();

		Task<bool> DisplayAlert(string title, string message, string accept, string cancel);

		Task DisplayAlert(string title, string message, string ok);
	}
}
