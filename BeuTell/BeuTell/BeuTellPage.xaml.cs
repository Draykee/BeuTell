using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using BeuTell.Models;
using System;
using System.Text;
using System.Diagnostics;

namespace BeuTell
{
	public partial class BeuTellPage : ContentPage
	{

        private List<Data> messages;

        public BeuTellPage()
		{
			InitializeComponent();

			messages = new List<Data> { };

			Xamarin.Forms.Device.StartTimer(new System.TimeSpan(0, 0, 3), () =>
			{
				this.LoadMessages();
				return true;
			});

			editor.Completed += OnCompleted;
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			await LoadMessages();
		}

		private async void OnCompleted(object sender, EventArgs e)
		{
			int selectedIndex=channelPIC.SelectedIndex;

			if (selectedIndex == -1) {
				selectedIndex = 0;
			}
						     
			var message = new ChatMessage(editor.Text);

			await DataHandler.getInstance().sendMessage(0, message);

		}

        private async Task LoadMessages()
        {
            //Add GET "http://beutellserver.azurewebsites.net/api/ChatMessage" to messages
            var httpClient = new HttpClient();

            // raw request just headers
            var response = await httpClient.GetAsync("http://beutelldata.azurewebsites.net/api/ChatMessage");

            // check headers 20x
            response.EnsureSuccessStatusCode();

            // read string
            var raw = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ChatMessage[]>(raw);

			newListView.ItemsSource = null;

			messages.Clear();

			var list = await DataHandler.getInstance().getAllMessages();
			foreach(var message in list)
            {
                messages.Add(new Data(message.Text) );
            }

			newListView.ItemsSource = messages;
        }
    }
}