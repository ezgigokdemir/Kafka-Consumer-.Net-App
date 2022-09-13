using KafkaConsumerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KafkaConsumerAPI.Controllers
{
    public class MessageController : Controller
    {
        private readonly ConsumerService _consumerService;
        private readonly CouchbaseService _couchbaseService;

        public MessageController(ConsumerService consumerService, CouchbaseService couchbaseService)
        {
            _consumerService = consumerService;
            _couchbaseService = couchbaseService;
        }

        [HttpPost]
        [Route("/ConsumeMessages")]
        public void ConsumeMessages(int limit)
        {
            var messages = _consumerService.Consumer(limit);
            _couchbaseService.InsertMessages(messages);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}