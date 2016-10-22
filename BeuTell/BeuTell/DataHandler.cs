using BeuTell.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BeuTell
{
    class DataHandler
    {
        //----- Sigelton --------------------------------
        private static DataHandler instance = null;

        public static DataHandler getInstance()
        {
            if (instance == null)
                instance = new DataHandler();
            return instance;
        }

        private DataHandler() { }
        //------------------------------------------------

        //Load a List of ChatMessages from ASP Server
        public async Task<List<ChatMessage>> loadMessages()
        {
            //GET "http://localhost:57531/api/ChatMessage" to people
            var httpClient = new HttpClient();

            // raw request just headers
            var response = await httpClient.GetAsync("http://localhost:57531/api/ChatMessage");

            // check headers 20x
            response.EnsureSuccessStatusCode();

            // read string
            var raw = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ChatMessage[]>(raw);

            return data.ToList();
        }

        public async Task<List<Channel>> loadChannel()
        {
            // GET "http://localhost:57531/api/Channel"
            var httpClient = new HttpClient();

            // raw request just headers
            var response = await httpClient.GetAsync("http://localhost:57531/api/Channel");

            // check headers 20x
            response.EnsureSuccessStatusCode();

            // read string
            var raw = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<Channel[]>(raw);

            return data.ToList();
        }

        public async Task sendMessage(int aChanneID, ChatMessage aMessage)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(aMessage);

            // raw request just headers
            var response = await httpClient.PostAsync("http://localhost:57531/api/Channel", new StringContent(json));
            if (response.IsSuccessStatusCode)
            {
                //optional: handle success
            }
            else
            {
                //optional: handle failure
            }
        }
    }
}
