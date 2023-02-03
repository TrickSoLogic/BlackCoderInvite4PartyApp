using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BlackCoderInvite4PartyApp.Models;

namespace BlackCoderInvite4PartyApp.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good morning" : "Good afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult Invite4Party()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Invite4Party(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}
