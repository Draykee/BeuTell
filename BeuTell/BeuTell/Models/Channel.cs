using System;
using System.Collections.Generic;

namespace BeuTell.Models
{
    public class Channel
    {

        public Channel(int ID, string Title)
        {
            this.ID = ID;
            this.Title = Title;
        }

        //Id of the channel
        public int ID { get; set; }

        //Title of the channel
        public string Title { get; set; }

        //Container with message GUIDs
        public List<string> MessageContainer { get; } = new List<string>();

        //List of IDs of childs
        public List<int> ChildContainer { get; } = new List<int>();

        //Adds child
        public void AddChild(Channel aChannel)
        {
            ChildContainer.Add(aChannel.ID);
        }

        //Adds child by ID
        public void AddChildById(int ID)
        {
            ChildContainer.Add(ID);
        }

        //Add Message
        public void AddMessage(ChatMessage aMessage)
        {
            MessageContainer.Add(aMessage.getGUIDString());
        }

    }
}
