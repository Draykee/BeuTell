﻿using System;
using System.Web;

namespace BeuTell.Server.Models
{
    public class ChatMessage
    {
        // The Text the message contained.
        public string Text { get; set; }

        // An unique identificator
        public string GUID;

        // A trace to the parent ChatMessage in case of an awnser
        public string ParentGUID { get; set; }

        // A Actual level (depth of replies)
        public int Level { get; set; }

        // A time stamp
        public string TimeStamp { get; set; }

        //Get GUID Object
        public Guid getGUID()
        {
            return new Guid(GUID);
        }

        //Get GUID String
        public string getGUIDString()
        {
            return this.GUID;
        }

        //Set GUID by string
        public void setGUID(string strGUID)
        {
            this.GUID = strGUID;
        }

        //Set GUID by Guid object
        public void setGUID(Guid Guid)
        {
            this.GUID = Guid.ToString();
        }
    }

}
