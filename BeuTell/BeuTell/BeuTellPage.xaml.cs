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
            //Add GET "http://localhost:57531/api/ChatMessage" to people
            var httpClient = new HttpClient();

            // raw request just headers
            var response = await httpClient.GetAsync("http://localhost:57531/api/ChatMessage");

            // check headers 20x
            response.EnsureSuccessStatusCode();

            // read string
            var raw = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ChatMessage[]>(raw);

            foreach(ChatMessage message in data)
            {
                people.Add(new Data(message.Text) );
            }
        }
    }
}
