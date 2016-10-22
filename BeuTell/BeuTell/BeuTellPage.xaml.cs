using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using BeuTell.Models;

namespace BeuTell
{
	public partial class BeuTellPage : ContentPage
	{

        private List<Data> people;

        public BeuTellPage()
		{
			InitializeComponent();

			people = new List<Data> {
				new Data ("Steve"),
				new Data ("Steve1"),
				new Data ("Steve2")
			};

            LoadMessages();

			newListView.ItemsSource = people;

		}

        private async Task LoadMessages()
        {
            
        }
    }
}
