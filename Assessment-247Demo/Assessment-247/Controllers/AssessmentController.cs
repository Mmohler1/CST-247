using Assessment_247.Business;
using Assessment_247.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment_247.Controllers
{
    public class AssessmentController : Controller
    {
        //Show the page
        public IActionResult Index()
        {
            return View("Menu");
        }

        //Puts form input into a model and returns page.
        [HttpPost]
        public IActionResult Order()
        {


            //Make new model and add stuff to it
            Food ticket = new Food();

            ticket.name = Request.Form["name"].ToString();
            ticket.calories = Convert.ToInt32(Request.Form["calories"].ToString());
            ticket.ingredient1 = Request.Form["ingre1"].ToString();
            ticket.ingredient2 = Request.Form["ingre2"].ToString();


            //Call business class and insert ticket
            Waiter Joe = new Waiter();
            ticket = Joe.newGuy(ticket);


            ViewBag.yourOrder = "This was your order right? " + ticket.ingredient1 + " " + ticket.ingredient2;

            return View("Menu");
        }
    }


}
