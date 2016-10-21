using System;
using System.Collections.Generic;

namespace BeuTell.Models
{
    public class Channel
    {
        //Id of the channel
        public int ID { get; set; }

        //Title of the channel
        public string Title { get; set; }

        //Container with message GUIDs
        public List<string> MessageContainer { get; set; }

        //List of IDs of childs
        public List<int> ChildContainer { get; set; }

    }
}
