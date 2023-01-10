using DI.IRepository;
using DI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingleton singleton;
        private readonly IScoped scoped;
        private readonly ITransient transient;
        private readonly ISingleton singleton2;
        private readonly IScoped scoped2;
        private readonly ITransient transient2;

        public HomeController(ILogger<HomeController> logger,
            ISingleton singleton,
            IScoped scoped,
            ITransient transient,
            ISingleton singleton2,
            IScoped scoped2,
            ITransient transient2)
        {
            _logger = logger;
            this.singleton = singleton;
            this.scoped = scoped;
            this.transient = transient;
            this.singleton2 = singleton2;
            this.scoped2 = scoped2;
            this.transient2 = transient2;
        }

        public IActionResult Index()
        {
            TempData["Singleton1"] = singleton.GetGuid();
            TempData["Singleton2"] = singleton2.GetGuid();

            TempData["Scoped1"] = scoped.GetGuid();
            TempData["Scoped2"] = scoped2.GetGuid();

            TempData["Transient1"] = transient.GetGuid();
            TempData["Transient2"] = transient2.GetGuid();
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