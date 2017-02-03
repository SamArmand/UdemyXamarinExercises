using System;

using Xamarin.Forms;

namespace UdemyXamarinExercises
{
	public partial class QuotesPage
	{
	    readonly string[] _quotes = {
			"Imagination is more important than knowledge.",
			"The important thing is not to stop questioning. Curiosity has its own reason for existing.",
			"Anyone who has never made a mistake has never tried anything new.",
			"Try not to become a man of success, but rather try to become a man of value.",
			"Science without religion is lame, religion without science is blind.",
			"Two things are infinite: the universe and human stupidity; and I'm not sure about the universe.",
			"No problem can be solved from the same level of consciousness that created it.",
			"Everything should be made as simple as possible, but not simpler.",
			"The most beautiful thing we can experience is the mysterious. It is the source of all true art and science.",
			"I have no special talents.I am only passionately curious."
		};

		int _index;

		public QuotesPage()
		{
			InitializeComponent();

			Padding = Device.OnPlatform(
				new Thickness(20, 20, 20, 20),  //iOS
				new Thickness(20, 30, 20, 20),  //Android
				new Thickness(20, 40, 20, 20)   //WinPhone
			);

			QuoteLable.Text = _quotes[_index];
		}

		void Handle_Clicked(object sender, EventArgs e) => QuoteLable.Text = _quotes[(++_index) % _quotes.Length];
	}
}
