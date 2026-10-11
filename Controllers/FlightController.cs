using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_sudinko.Models;

namespace wt_lab4_4mvc_sudinko.Controllers;

public class FlightController : Controller
{
    private static readonly List<Flight> Flights = new()
    {
        new Flight { Id = 1, Number = "B2-701", From = "Минск", To = "Москва", Price = 180, IsAvailable = true },
        new Flight { Id = 2, Number = "B2-455", From = "Минск", To = "Стамбул", Price = 420, IsAvailable = true },
        new Flight { Id = 3, Number = "B2-310", From = "Минск", To = "Санкт-Петербург", Price = 150, IsAvailable = false },
        new Flight { Id = 4, Number = "B2-882", From = "Минск", To = "Дубай", Price = 780, IsAvailable = true },
        new Flight { Id = 5, Number = "B2-120", From = "Минск", To = "Сочи", Price = 310, IsAvailable = false }
    };

    public IActionResult Index()
    {
        return View(Flights);
    }

    public IActionResult Details(int id)
    {
        var flight = Flights.FirstOrDefault(f => f.Id == id);

        if (flight == null)
        {
            return NotFound();
        }

        return View(flight);
    }

        public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Flight flight)
    {
        if (!ModelState.IsValid)
        {
            return View(flight);
        }

        flight.Id = Flights.Any() ? Flights.Max(f => f.Id) + 1 : 1;
        Flights.Add(flight);

        return RedirectToAction("Index");
    }

        [HttpPost]
    public IActionResult Delete(int id)
    {
        var flight = Flights.FirstOrDefault(f => f.Id == id);

        if (flight != null)
        {
            Flights.Remove(flight);
        }

        return RedirectToAction("Index");
    }
}