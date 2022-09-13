using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using KafkaConsumerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KafkaConsumerAPI.Services
{
    public class CouchbaseService
    {
        private readonly IBucket _bucket;

        //MessageOperations cluster name
        public CouchbaseService(IBucketProvider bucketProvider)
        {
            _bucket = bucketProvider.GetBucket("Messages");
        }

        public void InsertMessages(List<MessageModel> messages)
        {
            foreach (var message in messages)
            {
                var key = Guid.NewGuid().ToString();
                _bucket.Insert(key, message);
            }           
        }
    }
}
