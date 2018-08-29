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

        [HttpPost("AddEvent")]
        public IActionResult AddEvent(Wedding events)
        {
            if(ActiveUser == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if(ModelState.IsValid)
            {
                Wedding wedding = new Wedding
                {
                    Host = ActiveUser.UserId,
                    WedderOne = events.WedderOne,
                    WedderTwo = events.WedderTwo,
                    EventName = events.EventName,
                    EventDate = events.EventDate,
                    Address = events.Address
                };
                _wContext.weddings.Add(wedding);
                _wContext.SaveChanges();
                return RedirectToAction("Dashboard", "Wedding");
            }
            return View("AddEvent");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}
