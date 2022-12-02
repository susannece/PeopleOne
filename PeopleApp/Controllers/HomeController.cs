using Microsoft.AspNetCore.Mvc;
using PeopleApp.Models;
using PeopleApp.Models.Repos;
using PeopleApp.Models.Services;
using System.Diagnostics;

namespace PeopleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPeopleService _peopleService;

        public HomeController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
        public IActionResult Index()
        {
            return View(_peopleService.LastAdded());
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