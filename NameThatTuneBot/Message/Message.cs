using System;
using System.Collections.Generic;
using System.Text;

namespace NameThatTuneBot.Message
{
    public class Message
    {
        public Type ReceiverClass { get; private set; }
        public string Data { get; set; }
        public long Id { get; private set; }

        public Message(Type receiverClass, string data, long id)
        {
            this.Data = data;
            this.Id = id;
            this.ReceiverClass = receiverClass;
        }
    }
}
