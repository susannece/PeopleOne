using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleApp.Models;
using PeopleApp.Models.Services;
using PeopleApp.Models.ViewModels;

namespace PeopleApp.Controllers
{
    public class CityController : Controller
    {
        ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: CityController
        public IActionResult Index()
        {
            return View(_cityService.All());
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            return View(new CreateCityViewModel());
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCityViewModel createCity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _cityService.Create(createCity);
                }
                catch(ArgumentException ex)
                {
                    ModelState.AddModelError("City", ex.Message);
                    return View(createCity);
                }
                return RedirectToAction("Index");
            }
            return View(createCity);    
        }
        
        // GET: CityController/Details/5
        public IActionResult Details(int id)
        {
            City city = _cityService.FindById(id);
            if(city == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }
        // GET: CityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            City city = _cityService.FindById(id);
            if(city != null)
            {
                _cityService.Remove(id);
                return PartialView("_CityList", _cityService.All());
            }
            return NotFound();
        }

        // POST: CityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
