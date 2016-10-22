using BeuTell.Server;
using BeuTell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeuTell.Server.Controllers
{
    public class ChannelController : ApiController
    {

        private DataRepository _data;

        public ChannelController()
        {
            this._data = DataRepository.getInstance();
        }

        // GET: api/Channel
        public IEnumerable<Channel> Get()
        {
            return _data.Channels.Values;
        }

        // GET: api/Channel/5
        public Channel Get(int id)
        {
            return _data.Channels[id];
        }

        // POST: api/Channel
        public void Post([FromBody]Channel value)
        {
            _data.Channels.Add(value.ID,value);
        }

        // PUT: api/Channel/5
        public void Put(int id, [FromBody]Channel value)
        {
            _data.Channels[id] = value;
        }

        // DELETE: api/Channel/5
        public void Delete(int id)
        {
            _data.Channels.Remove(id);
        }
    }
}
