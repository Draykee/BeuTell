using System.Collections.Generic;
using Xamarin.Forms;


namespace BeuTell
{
	public partial class BeuTellPage : ContentPage
	{
		public BeuTellPage()
		{
			InitializeComponent();

			var people = new List<Data> {
				new Data ("Steve"),
				new Data ("Steve1"),
				new Data ("Steve2"),
				new Data ("Steve3"),
				new Data ("Steve4"),
				new Data ("Steve5"),
				new Data ("Steve6"),
				new Data ("Steve7"),
				new Data ("Steve8"),
				new Data ("Steve9"),
				new Data ("Stevtze"),
				new Data ("Stevrte"),
				new Data ("sdfs")

			};

			newListView.ItemsSource = people;

		}
	}
}
