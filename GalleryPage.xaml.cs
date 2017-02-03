using System;
using Xamarin.Forms;

namespace UdemyXamarinExercises
{
	public partial class GalleryPage
	{
	    const string Uri = "http://lorempixel.com/1920/1080/city/";
	    int _pic = 1;

		public GalleryPage()
		{
			InitializeComponent();
			LoadImage();
		}

		void Previous_Clicked(object sender, EventArgs e)
		{
			if (--_pic < 1) _pic = 10;
			LoadImage();
		}

		void Next_Clicked(object sender, EventArgs e)
		{
			if (++_pic > 10) _pic = 1;
			LoadImage();
		}

		void LoadImage()
		{
			Image.Source = new UriImageSource
			{
				Uri = new Uri(Uri + _pic),
				CachingEnabled = false
			};
		}
	}
}
