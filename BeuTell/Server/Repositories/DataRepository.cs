using BeuTell.Models;
using System.Collections.Generic;

namespace BeuTell.Server
{
    //Needs to be singelton
    public class DataRepository
    {
        public static DataRepository Instance = null;

        public static DataRepository getInstance()
        {
            if (Instance == null)
                Instance = new DataRepository();
            return Instance;
        }

        private DataRepository(){}

        //All available Mesasges
        public IDictionary<string, ChatMessage> Messages {get;} = new Dictionary<string, ChatMessage>();

        //All Channels
        public IDictionary<int, Channel> Channels { get; } = new Dictionary<int, Channel>();

    }
}