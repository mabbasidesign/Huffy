using Huffy.Models;
using Huffy.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Huffy.Controllers
{
    public class StabsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StabsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new StabFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(StabFormViewModel viewmodel)
        {
            var userId = User.Identity.GetUserId();
            var artist = _context.Users.Single(u => u.Id == userId);
            var gener = _context.Genres.Single(g => g.Id == viewmodel.Genre);
            var stab = new Stab
            {
                Venue = viewmodel.Venue,
                DateTime = DateTime.Parse(string.Format("{0}, {1}", viewmodel.Date, viewmodel.Time)),
                Artist = artist,
                Genre = gener,
            };
            _context.Stabs.Add(stab);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}