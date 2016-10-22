using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using BeuTell.Models;
using System;
using System.Text;

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
			//ChooseBtn.Clicked += ChooseBtnClicked;
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			await LoadMessages();
		}

		private void ChooseBtnClicked(object sender, EventArgs e) 
		{ 
			//newListView
		}


		private async void OnCompleted(object sender, EventArgs e)
		{
			var textVariable = editor.Text;
			var date = DateTime.Now;

			var httpClient = new HttpClient();



			//httpClient.BaseAddress = new Uri("http://beutellserver.azurewebsites.net/api/ChatMessage");

			var url = "http://beutellserver.azurewebsites.net/api/ChatMessage";

			//string json = new ChatMessage

			//string jsonData = "{"Text" : "+" + textVarhhhhiable + "GUID : \"agn466643\", \n\t\t\t\"ParentGUID\" : \"afa99sdfs\", \"TimeStamp\" : \"date\", \"Level\" : 0}";

			//var webClient = new WebClient();

			//httpClient.PostAsync(url, jsonData);

			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");


			httpClient.PostAsync(url, content);


			//HttpResponseMessage response = await client.PostAsync("/foo/login", content);




			//var response = await httpClient.PostAsync(url, jsonData);
		}

        private async Task LoadMessages()
        {
            //Add GET "http://beutellserver.azurewebsites.net/api/ChatMessage" to messages
            var httpClient = new HttpClient();

            // raw request just headers
            var response = await httpClient.GetAsync("http://beutellserver.azurewebsites.net/api/ChatMessage");

            // check headers 20x
            response.EnsureSuccessStatusCode();

            // read string
            var raw = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ChatMessage[]>(raw);

			newListView.ItemsSource = null;

			messages.Clear();

            foreach(ChatMessage message in data)
            {
                messages.Add(new Data(message.Text) );
            }

			newListView.ItemsSource = messages;
        }
    }
}