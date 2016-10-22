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
            {
                Instance = new DataRepository();
                //for testing
                Instance.InitChannel();
            }
            return Instance;
        }

        private DataRepository(){}

        //All available Mesasges
        public IDictionary<string, ChatMessage> Messages {get;} = new Dictionary<string, ChatMessage>();

        //All Channels
        public IDictionary<int, Channel> Channels { get; } = new Dictionary<int, Channel>();

        private  void InitChannel()
        {
            for( int i = 0; i < 4; i++)
            {
                Channels.Add(i, new Channel(i, "Fachbereich" + i ) );
            }
            var child = Channels.Count;
            var cChannel = new Channel(child, "ChildChannel");
            Channels.Add(child, cChannel);
            var parent = Channels.Count;
            var pChannel = new Channel(parent, "ParentChannel");
            pChannel.AddChildById(cChannel.ID);
            Channels.Add(parent, pChannel);
        }

    }
}