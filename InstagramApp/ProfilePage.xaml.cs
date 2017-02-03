using System;
using UdemyXamarinExercises.InstagramApp.Models;
using UdemyXamarinExercises.InstagramApp.Services;

namespace UdemyXamarinExercises.InstagramApp
{
	public partial class ProfilePage
	{
		public ProfilePage(Activity activity)
		{
			if (activity == null) throw new ArgumentNullException();

			BindingContext = (new UserService()).GetUser(activity.UserId);

			InitializeComponent();

		}
	}
}
