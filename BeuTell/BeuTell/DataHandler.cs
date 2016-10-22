using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeuTell.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics.Contracts;
using System.Text;

namespace BeuTell
{
    class DataHandler
    {

        private const string CHANNEL = "http://beutelldata.azurewebsites.net/api/Channel";
        private const string MESSAGE = "http://beutelldata.azurewebsites.net/api/ChatMessage";

        //----- Singelton ----------------------------------
        private static DataHandler instance = null;

        public static DataHandler getInstance()
        {
            if (instance == null)
                instance = new DataHandler();
            return instance;
        }

        private DataHandler() { }
        //--------------------------------------------------

        //get all channels
        public async Task< List<Channel> > getChannel()
        {
            var http = new HttpClient();

            var response = await http.GetAsync(CHANNEL);

            response.EnsureSuccessStatusCode();

            var jsonString = response.Content.ReadAsStringAsync().Result;

            var data = JsonConvert.DeserializeObject<List<Channel>>(jsonString);

            return data;
        }

        //get all messages
        public async Task<List<ChatMessage>> getAllMessages()
        {
            var http = new HttpClient();

            var response = await http.GetAsync(MESSAGE);

            response.EnsureSuccessStatusCode();

            var jsonString = response.Content.ReadAsStringAsync().Result;

            var data = JsonConvert.DeserializeObject<List<ChatMessage>>(jsonString);

            return data;
        }

        //Sends message to channel
        public async Task sendMessage(int aChannelID, ChatMessage aMessage)
        {
			Contract.Ensures(Contract.Result<Task>() != null);
			var http = new HttpClient();

            var json = JsonConvert.SerializeObject(aMessage).ToString();

			var write = await http.PostAsync("http://beutelldata.azurewebsites.net/api/channel/"+aChannelID+"/messages", new StringContent(json, Encoding.UTF8, "application/json"));

            if(!write.IsSuccessStatusCode)
            {
                //Error
            }
        }
    }
}
