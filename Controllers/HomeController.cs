using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using To_Do_App.Data;
using To_Do_App.Models;

namespace To_Do_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        private readonly ApplicationDbContext _context = new ();

        public IActionResult Index(int Page = 1, int RecordsPerPage = 10)
        {
            var duties = _context.Duties
                .OrderBy(x => x.Date)
                .ThenBy(y => y.Time)
                .Skip((Page - 1) * RecordsPerPage)
                .Take(RecordsPerPage);

            ViewBag.Page = Page;
            ViewBag.RecordsPerPage = RecordsPerPage;
            ViewBag.TotalPages = (int)(Math.Ceiling((double)_context.Duties.Count() / RecordsPerPage));

            return View(duties.ToList());

        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Duty duty)
        {
            _context.Duties.Add(duty);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            var duty = _context.Duties.Find(id);

            if (duty is not null)
            {
                return View(duty);
            }

            return RedirectToAction("NotFoundPage", "Home");
        }

        [HttpPost]
        public IActionResult Edit(Duty duty)
        {
            var OldDuty = _context.Duties.AsNoTracking().FirstOrDefault(e => e.Id == duty.Id);

            if (OldDuty is not null)
            {
                _context.Duties.Update(duty);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("NotFoundPage", "Home");
        }

        public IActionResult Delete(int id)
        {
            var duty = _context.Duties.Find(id);

            if (duty is not null)
            {
                _context.Remove(duty);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("NotFoundPage", "Home");
        }

        [HttpPost]
        public IActionResult ToggleStatus(int id)
        {
            var duty = _context.Duties.Find(id);
            if (duty is not null)
            {
                duty.Status = !duty.Status;
                _context.SaveChanges();
            }

            return RedirectToAction("NotFoundPage", "Home");
        }


















        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
