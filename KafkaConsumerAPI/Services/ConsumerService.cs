using KafkaConsumerAPI.Models;
using KafkaNet;
using KafkaNet.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaConsumerAPI.Services
{
    public class ConsumerService
    {
        private readonly Uri uri = new Uri("http://localhost:9092");
        private readonly string topic = "test-topic";

        public List<MessageModel> Consumer(int limit)
        {
            var options = new KafkaOptions(uri);
            var brokerRouter = new BrokerRouter(options);
            var consumer = new Consumer(new ConsumerOptions(topic, brokerRouter));

            var counter = 0;
            var messages = new List<MessageModel>();
            
            foreach (var msg in consumer.Consume())
            {
                var message = Encoding.UTF8.GetString(msg.Value);
                var result = JsonConvert.DeserializeObject<MessageModel>(message);
                messages.Add(result);
                counter++;

                if (counter == limit) break;

            }

            return messages;
        }
    }
}