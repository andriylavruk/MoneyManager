using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            //return View();
            return Ok("Hello!");
        }

        public IActionResult Details(int id)
        {
            return Ok("Your id: " + id);
        }
    }
}