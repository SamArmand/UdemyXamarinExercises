using SQLite;
using UdemyXamarinExercises.SkypeApp.ViewModels;

namespace UdemyXamarinExercises.SkypeApp.Models
{
	[Table("Recipes")]
	public class Contact : BaseViewModel
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		string _firstName;
		[MaxLength(255)]
		public string FirstName
		{
			get { return _firstName; }
			set 
			{ 
				SetValue(ref _firstName, value);
			    // ReSharper disable once ExplicitCallerInfoArgument
				OnPropertyChanged(nameof(Name));
			}
		}

		string _lastName;
		[MaxLength(255)]
		public string LastName
		{
			get { return _lastName; }
			set
			{
				SetValue(ref _lastName, value);
			    // ReSharper disable once ExplicitCallerInfoArgument
				OnPropertyChanged(nameof(Name));
			}
		}

		[Ignore]
		public string Name => FirstName
		                      + (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) ? " " : string.Empty)
		                      + LastName;

	    [MaxLength(255)]
		public string Phone { get; set; }

		[MaxLength(255)]
		public string Email { get; set; }

		public bool Blocked { get; set; }

	}
}
