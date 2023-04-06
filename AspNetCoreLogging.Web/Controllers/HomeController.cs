using AspNetCoreLogging.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreLogging.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        // INFO: ILoggerFactory ile loglamalarımızı kategorilendirebiliriz.Örneğin "Index" metodundaki loglama Output'ta aşağıdaki gibi gözükecektir.
        //HomeClass: Debug: Index page opened with Log Debug

        private readonly ILoggerFactory _loggerFactory;

        public HomeController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public IActionResult Index()
        {
            var _logger=_loggerFactory.CreateLogger("HomeClass");

            _logger.LogTrace("Index page opened with Log Trace");
            _logger.LogDebug("Index page opened with Log Debug");
            _logger.LogInformation("Index page opened with Log Information");
            _logger.LogWarning("Index page opened with Log Warning");
            _logger.LogError("Index page opened with Log Error");
            _logger.LogCritical("Index page opened with Log Critical");

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
    }
}