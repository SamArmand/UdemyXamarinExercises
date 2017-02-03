using Xamarin.Forms;

namespace UdemyXamarinExercises.SkypeApp
{
	public partial class PhonePage
	{
		public PhonePage()
		{
			NavigationPage.SetHasNavigationBar(this, false);

			InitializeComponent();
		}

		void Handle_Clicked(object sender, System.EventArgs e) => Label.Text = string.Empty;

		void Number_Clicked(object sender, System.EventArgs e) => Label.Text += ((Button) sender).Text;
	}
}