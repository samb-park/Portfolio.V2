using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Utility;

namespace Portfolio.Controllers
{
    public class ContactController : Controller
    {


        // GET: Contact
        public IActionResult Index()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Contact contact)
        {
            var result = EmailService.SendEmail(contact.Email, contact.Name, contact.Phone, contact.Message);

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}