using System;

namespace KafkaConsumerAPI.Models
{
    public class MessageModel
    {
        public int ID { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}