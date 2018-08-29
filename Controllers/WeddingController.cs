using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{

    public class WeddingController : Controller
    {
    private WeddingContext _wContext;

    public WeddingController(WeddingContext context)
    {
        _wContext = context;    
    }
        private User ActiveUser 
        {
            get 
            {
                return _wContext.users.Where(u => u.UserId == HttpContext.Session.GetInt32("user_id")).FirstOrDefault();
            }
        }
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if(ActiveUser == null)
            {
                return RedirectToAction("Login", "Home");
            }
            User thisUser = _wContext.users
                .Where(u => u.UserId == HttpContext.Session.GetInt32("user_id"))
                .FirstOrDefault();
            User thisUserName = _wContext.users 
                .Where(u => u.FirstName == HttpContext.Session.GetString("first_name"))
                .FirstOrDefault();
            ViewBag.Weddings = _wContext.weddings
                .Where(w => w.EventDate > System.DateTime.Now)
                .OrderBy(d => d.EventDate)
                .Include(u => u.Host)
                .ToList();
            ViewBag.id = thisUser;
            ViewBag.name = thisUserName;
            return View();
        }
        
        [HttpGet("AddEvent")]
        public IActionResult AddEvent()
        {
            if(ActiveUser == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        [HttpPost("AddEvent/new")]
        public IActionResult AddEventData(AddEventData events)
        {
            if(ActiveUser == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if(ModelState.IsValid)
            {
                Wedding Wedding = events.TheWedding();
                Wedding.Host = ActiveUser;
                _wContext.Add(Wedding);
                _wContext.SaveChanges();
                return RedirectToAction("Dashboard", "Wedding");
            }
            return View("AddEvent");
        }

        [HttpPost("RSVP")]
        public IActionResult RSVP(int id)
        {
            Wedding SelectedWedding = _wContext.weddings
                .Where(w => w.WeddingId == id)
                .SingleOrDefault();
            if(_wContext.wedding_guests.Where(g => g.UserId == ActiveUser.UserId).Where(w => w.WeddingId == SelectedWedding.WeddingId).Count() == 0)
            {
                WeddingGuest NewGuest = new WeddingGuest(SelectedWedding, ActiveUser);
                _wContext.Add(NewGuest);
                _wContext.SaveChanges();
            }
            else
            {
                WeddingGuest NewGuest = _wContext.wedding_guests
                    .Where(g => g.UserId == ActiveUser.UserId)
                    .Where(w => w.WeddingId == SelectedWedding.WeddingId)
                    .SingleOrDefault();
            }
            return RedirectToAction("Dashboard", "Wedding");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}
