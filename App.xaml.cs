﻿using Xamarin.Forms;

namespace UdemyXamarinExercises
{
	public partial class App
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage (new MainPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}