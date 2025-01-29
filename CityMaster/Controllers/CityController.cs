using CityMaster.Data;
using CityMaster.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityMaster.Controllers
{
    public class CityController : Controller
    {
        private readonly CityMasterDbContext _context;

        public CityController(CityMasterDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cities = _context.Cities.ToList();
            return View(cities);
        }

        public IActionResult Edit(int id)
        {
            var city = _context.Cities.FirstOrDefault(c => c.CityId == id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        [HttpPost]
        public IActionResult Edit(int id, string cityCode, string cityName)
        {
            var city = _context.Cities.FirstOrDefault(c => c.CityId == id);
            if (city == null)
            {
                return NotFound();
            }

            city.CityCode = cityCode;
            city.CityName = cityName;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var city = _context.Cities.FirstOrDefault(c => c.CityId == id);
            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Add(string cityCode, string cityName)
        {
            var city = new City
            {
                CityCode = cityCode,
                CityName = cityName
            };

            _context.Cities.Add(city);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SwapCity(int cityId, string targetColumn)
        {
            var city = _context.Cities.FirstOrDefault(c => c.CityId == cityId);
            if (city != null)
            {
                city.IsInLeftColumn = targetColumn == "Left";
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> MoveAllCities(string targetColumn)
        {
            var cities = await _context.Cities.ToListAsync();

            foreach (var city in cities)
            {
                if (targetColumn == "Left" && !city.IsInLeftColumn)
                {
                    city.IsInLeftColumn = true; 
                }
                else if (targetColumn == "Right" && city.IsInLeftColumn)
                {
                    city.IsInLeftColumn = false; 
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }



    }
}
