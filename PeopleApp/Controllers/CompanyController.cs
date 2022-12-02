using Microsoft.AspNetCore.Mvc;

namespace PeopleApp.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
