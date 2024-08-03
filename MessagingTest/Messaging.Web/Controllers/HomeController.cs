using Messaging.Framework.RabbitMQ.Publisher;
using Messaging.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Messaging.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPublisher publisher;

        public HomeController(ILogger<HomeController> logger, IPublisher publisher)
        {
            _logger = logger;
            this.publisher = publisher;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SubmitAMessage()
        {
            publisher.Publish(
                "SampleExchange"    // exchange name
                , new { Test = "Test" } // any object
                , "SampleEvent" // the name of the event that raised after executing a command
                , "userId"  // user who performed this command
                //, serviceName
                );
            return View("Index");
        }
    }
}
