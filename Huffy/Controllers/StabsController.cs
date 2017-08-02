using Huffy.Models;
using Huffy.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult Mine()
        {
            var stab = _context.Stabs
                .Include(g => g.Genre)
                .ToList();
            return View(stab);
        }


        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new StabFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View("Create", viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StabFormViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                viewmodel.Genres = _context.Genres.ToList();
                return View("create", viewmodel);
            }
            
            var stab = new Stab
            {
                Venue = viewmodel.Venue,
                DateTime = viewmodel.GetDateTime(),
                ArtistId = User.Identity.GetUserId(),
                GenreId = viewmodel.Genre,
            };
            _context.Stabs.Add(stab);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var stab = _context.Stabs.SingleOrDefault(u => u.Id == id && u.ArtistId == userId);

            var viewModel = new StabFormViewModel
            {
                Date = stab.DateTime.ToString("d MMM yyyy"),
                Time = stab.DateTime.ToString("HH:mm"),
                Genre = stab.GenreId,
                Venue = stab.Venue,
                Genres = _context.Genres.ToList(),
                Id = stab.Id,
                Heading = "Edit",
            };

            return View("Edit", viewModel);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StabFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Edit", viewModel);
            }

            var userId = User.Identity.GetUserId();
            var stab = _context.Stabs.Single(u => u.Id == viewModel.Id && u.ArtistId == userId);
            stab.Venue = viewModel.Venue;
            stab.DateTime = viewModel.GetDateTime();
            stab.GenreId = viewModel.Genre;

            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}