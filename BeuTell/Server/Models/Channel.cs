using System;
using System.Collections.Generic;
using System.Web;

namespace BeuTell.Server.Models
{
    public class Channel
    {
        //Id of the channel
        public int id { get; set; }

        //Title of the channel
        public string Title { get; set; }

        //Container with message GUIDs
        public List<string> messageContainer { get; set; }

        //List of IDs of childs
        public List<int> childContainer { get; set; }

    }
}
