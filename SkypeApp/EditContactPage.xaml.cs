using System;
using UdemyXamarinExercises.SkypeApp.Models;
using UdemyXamarinExercises.SkypeApp.ViewModels;
using Xamarin.Forms;

namespace UdemyXamarinExercises.SkypeApp
{
	public partial class EditContactPage : ContentPage
	{
		public EditContactPage(Contact contact)
		{
			if (contact == null)
				throw new ArgumentNullException(nameof(contact));

			BindingContext = new EditContactPageViewModel(contact);

			InitializeComponent();
		}
	}
}
