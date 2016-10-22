using BeuTell.Models;
using BeuTell.Server;
using System.Collections.Generic;
using System.Web.Http;

namespace Server.Controllers
{
    public class ChatMessageController : ApiController
    {

        private DataRepository _data;

        public ChatMessageController()
        {
            this._data = DataRepository.getInstance();
        }

        // GET: api/ChatMessage
        public IEnumerable<ChatMessage> Get()
        {
            return _data.Messages.Values;
        }

        // GET: api/ChatMessage/5
        public ChatMessage Get(string guid)
        {
            return _data.Messages[guid];
        }

        // POST: api/ChatMessage
        public void Post([FromBody]ChatMessage value)
        {
            _data.Messages.Add(value.GUID,value);
        }

        // PUT: api/ChatMessage/5
        public void Put(string guid, [FromBody]ChatMessage value)
        {
            _data.Messages[guid] = value;
        }

        // DELETE: api/ChatMessage/5
        public void Delete(string guid)
        {
            _data.Messages.Remove(guid);
        }
    }
}
