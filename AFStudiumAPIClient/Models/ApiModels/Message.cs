using System;
using System.Collections.Generic;
using System.Text;

namespace AFStudiumAPIClient.Models.ApiModels
{
    public class Message
    {
        public int MessageId { get; set; }
        public int EventId { get; set; }
        public int SendFrom { get; set; }
        public int SendTo { get; set; }
        public string MessageHeader { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageTime { get; set; }
    }
}
