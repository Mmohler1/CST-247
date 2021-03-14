using Microsoft.AspNetCore.Mvc;
using Milestone.Models;
using Milestone.Service.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone.Controllers
{
    public class PlayerController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult Register(PlayerInfo player)
        {
            var securityS = new SecurityService();

            if (securityS.ProcessTheRegister(player) == true)
            {
                //Sends user back to index page
                return View("Login");
            }
            //If false keep user on register page
            return View("Register");


        }


        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult doLogin()
        {
            var securityS = new SecurityService();

            string username = Request.Form["Username"].ToString();
            string password = Request.Form["Password"].ToString();

            ViewBag.test = "" + username + " AND " + password;
            if (securityS.ProcessTheLogin(username, password) == true)
            {
                //Sends user to Minesweeper page
                return RedirectToAction("Index", "Minesweeper");
            }

            //If false keep user on register page
            return View("Login");


        }



    }  
}
